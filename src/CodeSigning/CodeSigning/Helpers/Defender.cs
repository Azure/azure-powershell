using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Microsoft.Azure.Commands.CodeSigning.Helpers
{  
    public class DefenderHelper
    {
        [DllImport("wintrust.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern Boolean CryptCATAdminAcquireContext2([Out] out IntPtr phCatAdmin, IntPtr pgSubsystem, [MarshalAs(UnmanagedType.LPWStr)] string pwszHashAlgorithm, IntPtr pStrongHashPolicy, UInt32 dwFlags);

        [DllImport("wintrust.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern Boolean CryptCATAdminCalcHashFromFileHandle2(IntPtr hCatAdmin, IntPtr hFile, ref UInt32 pcbHash, IntPtr pbHash, UInt32 dwFlags);

        [DllImport("wintrust.dll", ExactSpelling = true, SetLastError = true, CharSet = CharSet.Unicode)]
        private static extern Boolean CryptCATAdminReleaseContext(IntPtr hCatAdmin, UInt32 dwFlags);

        public static byte[] CalculateAuthenticodeHash(SafeFileHandle safeFileHandle)
        {
            IntPtr hFile = safeFileHandle.DangerousGetHandle();
            IntPtr phCatAdmin = IntPtr.Zero;
            // Get phCatAdmin handle.  First use the function CryptCATAdminAcquireContext2, then use the normal function            
            if (!CryptCATAdminAcquireContext2(out phCatAdmin, IntPtr.Zero, "SHA256", IntPtr.Zero, 0)) { }

            // Calc hash            
            //define file hash and file hash lengeh
            UInt32 fileHashLength = 16;
            IntPtr fileHash = Marshal.AllocHGlobal((int)fileHashLength);

            // Get size of the file hash to be used
            if (!CryptCATAdminCalcHashFromFileHandle2(phCatAdmin, hFile, ref fileHashLength, fileHash, 0))
            {
                // Alloc the correct amount and write the hash
                Marshal.FreeHGlobal(fileHash);
                fileHash = Marshal.AllocHGlobal((int)fileHashLength);

                if (!CryptCATAdminCalcHashFromFileHandle2(phCatAdmin, hFile, ref fileHashLength, fileHash, 0))
                {
                    // clean                   
                    CryptCATAdminReleaseContext(phCatAdmin, 0);
                    Marshal.FreeHGlobal(fileHash);
                }

                byte[] managedArray = new byte[(int)fileHashLength];
                Marshal.Copy(fileHash, managedArray, 0, (int)fileHashLength);
                return managedArray;
            }
            return null;
        }
        public static List<byte[]> GetSigningFileHashList(SafeFileHandle safeFileHandle)
        {
            var fileHash = new byte[] { };
            List<byte[]> fileHashList = new List<byte[]>();

            //compute file hash
            if (!safeFileHandle.IsInvalid)
            {
                FileStream fs = new FileStream(safeFileHandle, FileAccess.Read);
                var sha = SHA256.Create();
                fileHash = sha.ComputeHash(fs);
                fileHashList.Add(fileHash);
            }

            return fileHashList;
        }

        public static List<byte[]> GetSigningFileAuthenticodehashList(SafeFileHandle safeFileHandle)
        {
            var authHash = new byte[] { };
            List<byte[]> authHashList = new List<byte[]>();

            //compute file authenticode hash
            if (!safeFileHandle.IsInvalid)
            {
                authHash = CalculateAuthenticodeHash(safeFileHandle);
                authHashList.Add(authHash);
            }
            return authHashList;
        }
    }
}
