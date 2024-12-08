using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dilitium
{
    public class Functions
    {

        static SecureRandom random = new SecureRandom();
        static DilithiumKeyGenerationParameters keyGenParameters = new DilithiumKeyGenerationParameters(random, DilithiumParameters.Dilithium3);
        public static AsymmetricCipherKeyPair GenerateKeys()
        {
            var dilithiumKeyPairGenerator = new DilithiumKeyPairGenerator();
            dilithiumKeyPairGenerator.Init(keyGenParameters);
            return dilithiumKeyPairGenerator.GenerateKeyPair();
        }
        public static Sign CreateSign(byte[] data, AsymmetricCipherKeyPair keyPair)
        {
            var publicKey = (DilithiumPublicKeyParameters)keyPair.Public;
            var privateKey = (DilithiumPrivateKeyParameters)keyPair.Private;
            var pubEncoded = publicKey.GetEncoded();
            //var privateEncoded = privateKey.GetEncoded();
            var alice = new DilithiumSigner();
            alice.Init(true, privateKey);
            var signature = alice.GenerateSignature(data);
            return new Sign { signature = Convert.ToBase64String(signature), publicKey = Convert.ToBase64String(pubEncoded) };
        }
        public static bool CheckSign(byte[] data, Sign sign)
        {
            var signature = Convert.FromBase64String(sign.signature);
            var pk = Convert.FromBase64String(sign.publicKey);
            var publicKey = new DilithiumPublicKeyParameters(DilithiumParameters.Dilithium3, pk);
            var bob = new DilithiumSigner();
            bob.Init(false, publicKey);
            var verified = bob.VerifySignature(data, signature);
            return verified;
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetCurrentThread();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern void QueryThreadCycleTime(IntPtr threadHandle, out ulong cycleTime);

        public static (ulong cycles, long memoryUsage) GetCpuCyclesAndMemory(Action action)
        {
            IntPtr currentThread = GetCurrentThread();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            QueryThreadCycleTime(currentThread, out ulong startCycles);
            long initialMemory = GC.GetTotalMemory(forceFullCollection: true);

            action();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            QueryThreadCycleTime(currentThread, out ulong endCycles);
            long finalMemory = GC.GetTotalMemory(forceFullCollection: true);

            long memoryUsed = finalMemory - initialMemory;

            return (endCycles - startCycles, memoryUsed);
        }
    }
    public class Sign
    {
        public string signature { get; set; }
        public string publicKey { get; set; }
    }
}
