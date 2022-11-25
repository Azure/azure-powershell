using Microsoft.Win32.SafeHandles;

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Commands.KeyVault.Helpers
{
    // Solution from https://github.com/dotnet/runtime/issues/77590 and
    // https://stackoverflow.com/questions/57269726/x509certificate2-import-with-ncrypt-allow-plaintext-export-flag/57330499#57330499
    internal static class CertificateExportHelper
    {
        internal static X509Certificate2 GetExportableCertificate(byte[] pfxBytes, string password, bool machineScope = false)
        {
            X509KeyStorageFlags flags = X509KeyStorageFlags.Exportable;

            if (machineScope)
            {
                flags |= X509KeyStorageFlags.MachineKeySet;
            }
            else
            {
                flags |= X509KeyStorageFlags.UserKeySet;
            }

            X509Certificate2 cert = new X509Certificate2(pfxBytes, password, flags);

            try
            {
                bool gotKey = NativeMethods.Crypt32.CryptAcquireCertificatePrivateKey(
                    cert.Handle,
                    NativeMethods.Crypt32.AcquireCertificateKeyOptions.CRYPT_ACQUIRE_ONLY_NCRYPT_KEY_FLAG,
                    IntPtr.Zero,
                    out SafeNCryptKeyHandle keyHandle,
                    out int keySpec,
                    out bool callerFree);

                if (!gotKey)
                {
                    keyHandle.Dispose();
                    throw new InvalidOperationException("No private key");
                }

                if (!callerFree)
                {
                    keyHandle.SetHandleAsInvalid();
                    keyHandle.Dispose();
                    throw new InvalidOperationException("Key is not persisted");
                }

                using (keyHandle)
                {
                    // -1 == CNG, otherwise CAPI
                    if (keySpec == -1)
                    {
                        using (CngKey cngKey = CngKey.Open(keyHandle, CngKeyHandleOpenOptions.None))
                        {
                            // If the CNG->CAPI bridge opened the key then AllowPlaintextExport is already set.
                            if ((cngKey.ExportPolicy & CngExportPolicies.AllowPlaintextExport) == 0)
                            {
                                FixExportability(cngKey, machineScope);
                            }
                        }
                    }
                }
            }
            catch
            {
                cert.Reset();
                throw;
            }

            return cert;
        }

        internal static void FixExportability(CngKey cngKey, bool machineScope)
        {
            string password = nameof(NativeMethods.Crypt32.AcquireCertificateKeyOptions);
            byte[] encryptedPkcs8 = ExportEncryptedPkcs8(cngKey, password, 1);
            string keyName = cngKey.KeyName;

            using (SafeNCryptProviderHandle provHandle = cngKey.ProviderHandle)
            {
                ImportEncryptedPkcs8Overwrite(
                    encryptedPkcs8,
                    keyName,
                    provHandle,
                    machineScope,
                    password);
            }
        }

        internal const string NCRYPT_PKCS8_PRIVATE_KEY_BLOB = "PKCS8_PRIVATEKEY";
        private static readonly byte[] s_pkcs12TripleDesOidBytes =
            System.Text.Encoding.ASCII.GetBytes("1.2.840.113549.1.12.1.3\0");

        private static unsafe byte[] ExportEncryptedPkcs8(
            CngKey cngKey,
            string password,
            int kdfCount)
        {
            var pbeParams = new NativeMethods.NCrypt.PbeParams();
            NativeMethods.NCrypt.PbeParams* pbeParamsPtr = &pbeParams;

            byte[] salt = new byte[NativeMethods.NCrypt.PbeParams.RgbSaltSize];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            pbeParams.Params.cbSalt = salt.Length;
            Marshal.Copy(salt, 0, (IntPtr)pbeParams.rgbSalt, salt.Length);
            pbeParams.Params.iIterations = kdfCount;

            fixed (char* stringPtr = password)
            fixed (byte* oidPtr = s_pkcs12TripleDesOidBytes)
            {
                NativeMethods.NCrypt.NCryptBuffer* buffers =
                    stackalloc NativeMethods.NCrypt.NCryptBuffer[3];

                buffers[0] = new NativeMethods.NCrypt.NCryptBuffer
                {
                    BufferType = NativeMethods.NCrypt.BufferType.PkcsSecret,
                    cbBuffer = checked(2 * (password.Length + 1)),
                    pvBuffer = (IntPtr)stringPtr,
                };

                if (buffers[0].pvBuffer == IntPtr.Zero)
                {
                    buffers[0].cbBuffer = 0;
                }

                buffers[1] = new NativeMethods.NCrypt.NCryptBuffer
                {
                    BufferType = NativeMethods.NCrypt.BufferType.PkcsAlgOid,
                    cbBuffer = s_pkcs12TripleDesOidBytes.Length,
                    pvBuffer = (IntPtr)oidPtr,
                };

                buffers[2] = new NativeMethods.NCrypt.NCryptBuffer
                {
                    BufferType = NativeMethods.NCrypt.BufferType.PkcsAlgParam,
                    cbBuffer = sizeof(NativeMethods.NCrypt.PbeParams),
                    pvBuffer = (IntPtr)pbeParamsPtr,
                };

                var desc = new NativeMethods.NCrypt.NCryptBufferDesc
                {
                    cBuffers = 3,
                    pBuffers = (IntPtr)buffers,
                    ulVersion = 0,
                };

                using (var keyHandle = cngKey.Handle)
                {
                    int result = NativeMethods.NCrypt.NCryptExportKey(
                        keyHandle,
                        IntPtr.Zero,
                        NCRYPT_PKCS8_PRIVATE_KEY_BLOB,
                        ref desc,
                        null,
                        0,
                        out int bytesNeeded,
                        0);

                    if (result != 0)
                    {
                        throw new Win32Exception(result);
                    }

                    byte[] exported = new byte[bytesNeeded];

                    result = NativeMethods.NCrypt.NCryptExportKey(
                        keyHandle,
                        IntPtr.Zero,
                        NCRYPT_PKCS8_PRIVATE_KEY_BLOB,
                        ref desc,
                        exported,
                        exported.Length,

                out bytesNeeded,
                0);

                    if (result != 0)
                    {
                        throw new Win32Exception(result);
                    }

                    if (bytesNeeded != exported.Length)
                    {
                        Array.Resize(ref exported, bytesNeeded);
                    }

                    return exported;
                }
            }
        }

        private static unsafe void ImportEncryptedPkcs8Overwrite(
            byte[] encryptedPkcs8,
            string keyName,
            SafeNCryptProviderHandle provHandle,
            bool machineScope,
            string password)
        {
            SafeNCryptKeyHandle keyHandle;

            fixed (char* passwordPtr = password)
            fixed (char* keyNamePtr = keyName)
            fixed (byte* blobPtr = encryptedPkcs8)
            {
                NativeMethods.NCrypt.NCryptBuffer* buffers = stackalloc NativeMethods.NCrypt.NCryptBuffer[2];

                buffers[0] = new NativeMethods.NCrypt.NCryptBuffer
                {
                    BufferType = NativeMethods.NCrypt.BufferType.PkcsSecret,
                    cbBuffer = checked(2 * (password.Length + 1)),
                    pvBuffer = new IntPtr(passwordPtr),
                };

                if (buffers[0].pvBuffer == IntPtr.Zero)
                {
                    buffers[0].cbBuffer = 0;
                }

                buffers[1] = new NativeMethods.NCrypt.NCryptBuffer
                {
                    BufferType = NativeMethods.NCrypt.BufferType.PkcsName,
                    cbBuffer = checked(2 * (keyName.Length + 1)),
                    pvBuffer = new IntPtr(keyNamePtr),
                };

                NativeMethods.NCrypt.NCryptBufferDesc desc = new NativeMethods.NCrypt.NCryptBufferDesc
                {
                    cBuffers = 2,
                    pBuffers = (IntPtr)buffers,
                    ulVersion = 0,
                };

                NativeMethods.NCrypt.NCryptImportFlags flags =
                    NativeMethods.NCrypt.NCryptImportFlags.NCRYPT_OVERWRITE_KEY_FLAG |
                    NativeMethods.NCrypt.NCryptImportFlags.NCRYPT_DO_NOT_FINALIZE_FLAG;

                if (machineScope)
                {
                    flags |= NativeMethods.NCrypt.NCryptImportFlags.NCRYPT_MACHINE_KEY_FLAG;
                }

                int errorCode = NativeMethods.NCrypt.NCryptImportKey(
                    provHandle,
                    IntPtr.Zero,
                    NCRYPT_PKCS8_PRIVATE_KEY_BLOB,
                    ref desc,
                    out keyHandle,
                    new IntPtr(blobPtr),
                    encryptedPkcs8.Length,
                    flags);

                if (errorCode != 0)
                {
                    keyHandle.Dispose();
                    throw new Win32Exception(errorCode);
                }

                using (keyHandle)
                using (CngKey cngKey = CngKey.Open(keyHandle, CngKeyHandleOpenOptions.None))
                {
                    const CngExportPolicies desiredPolicies =
                        CngExportPolicies.AllowExport | CngExportPolicies.AllowPlaintextExport;

                    cngKey.SetProperty(
                        new CngProperty(
                            "Export Policy",
                            BitConverter.GetBytes((int)desiredPolicies),
                            CngPropertyOptions.Persist));

                    int error = NativeMethods.NCrypt.NCryptFinalizeKey(keyHandle, 0);

                    if (error != 0)
                    {
                        throw new Win32Exception(error);
                    }
                }
            }
        }
    }

    internal static class NativeMethods
    {
        internal static class Crypt32
        {
            internal enum AcquireCertificateKeyOptions
            {
                None = 0x00000000,
                CRYPT_ACQUIRE_ONLY_NCRYPT_KEY_FLAG = 0x00040000,
            }

            [DllImport("crypt32.dll", SetLastError = true)]
            internal static extern bool CryptAcquireCertificatePrivateKey(
                IntPtr pCert,
                AcquireCertificateKeyOptions dwFlags,
                IntPtr pvReserved,
                out SafeNCryptKeyHandle phCryptProvOrNCryptKey,
                out int dwKeySpec,
                out bool pfCallerFreeProvOrNCryptKey);
        }

        internal static class NCrypt
        {
            [DllImport("ncrypt.dll", CharSet = CharSet.Unicode)]
            internal static extern int NCryptExportKey(
                SafeNCryptKeyHandle hKey,
                IntPtr hExportKey,
                string pszBlobType,
                ref NCryptBufferDesc pParameterList,
                byte[] pbOutput,
                int cbOutput,
                [Out] out int pcbResult,
                int dwFlags);

            [StructLayout(LayoutKind.Sequential)]
            internal unsafe struct PbeParams
            {
                internal const int RgbSaltSize = 8;

                internal CryptPkcs12PbeParams Params;
                internal fixed byte rgbSalt[RgbSaltSize];
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct CryptPkcs12PbeParams
            {
                internal int iIterations;
                internal int cbSalt;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct NCryptBufferDesc
            {
                public int ulVersion;
                public int cBuffers;
                public IntPtr pBuffers;
            }

            [StructLayout(LayoutKind.Sequential)]
            internal struct NCryptBuffer
            {
                public int cbBuffer;
                public BufferType BufferType;
                public IntPtr pvBuffer;
            }

            internal enum BufferType
            {
                PkcsAlgOid = 41,
                PkcsAlgParam = 42,
                PkcsName = 45,
                PkcsSecret = 46,
            }

            [DllImport("ncrypt.dll", CharSet = CharSet.Unicode)]
            internal static extern int NCryptOpenStorageProvider(
                out SafeNCryptProviderHandle phProvider,
                string pszProviderName,
                int dwFlags);

            internal enum NCryptImportFlags
            {
                None = 0,
                NCRYPT_MACHINE_KEY_FLAG = 0x00000020,
                NCRYPT_OVERWRITE_KEY_FLAG = 0x00000080,
                NCRYPT_DO_NOT_FINALIZE_FLAG = 0x00000400,
            }

            [DllImport("ncrypt.dll", CharSet = CharSet.Unicode)]
            internal static extern int NCryptImportKey(
                SafeNCryptProviderHandle hProvider,
                IntPtr hImportKey,
                string pszBlobType,
                ref NCryptBufferDesc pParameterList,
                out SafeNCryptKeyHandle phKey,
                IntPtr pbData,
                int cbData,
                NCryptImportFlags dwFlags);

            [DllImport("ncrypt.dll", CharSet = CharSet.Unicode)]
            internal static extern int NCryptFinalizeKey(SafeNCryptKeyHandle hKey, int dwFlags);
        }
    }

}

