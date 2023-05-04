using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Microsoft.Azure.Commands.CodeSigning.Helpers
{
    public class Util
    {
        //Declare DownloadsFolder KNOWNFOLDERID
        private static Guid FolderDownloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");

        /// Import SHGetKnownFolderPath method
        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern int SHGetKnownFolderPath(ref Guid id, int flags, IntPtr token, out IntPtr path);

        /// Declare method that returns the Downloads Path as string
        /// <summary>
        /// Returns the absolute downloads directory specified on the system.
        /// </summary>
        /// <returns></returns>
        public static string GetDownloadsPath()
        {
            if (Environment.OSVersion.Version.Major < 6) throw new NotSupportedException();

            IntPtr pathPtr = IntPtr.Zero;

            try
            {
                SHGetKnownFolderPath(ref FolderDownloads, 0, IntPtr.Zero, out pathPtr);
                return Marshal.PtrToStringUni(pathPtr);
            }
            finally
            {
                Marshal.FreeCoTaskMem(pathPtr);
            }
        }

        public static int GetBigEndianInt32(byte[] b, bool signed = false)
        {
            if (b.Length > 4)
                throw new ArgumentException($"Length of byte array is {b.Length}, greater than max 4 for Int32.");

            // input is big endian, need to pad to make 4 bytes
            int padBytes = 4 - b.Length;

            // two's complement encoding of negative values
            byte pad = 0x00;
            if (signed && b.Length > 0 && b[0] >= 0x80)
                pad = 0xff;

            // input is big endian, concat pad + reversed bigint bytes
            byte[] i = Enumerable.Repeat<byte>(pad, padBytes).Concat(b).ToArray();

            if (BitConverter.IsLittleEndian)
                i = i.Reverse().ToArray();

            return BitConverter.ToInt32(i, 0);
        }
        public static long GetBigEndianInt64(byte[] b, bool signed = false)
        {
            if (b.Length > 8)
                throw new ArgumentException($"Length of byte array is {b.Length}, greater than max 8 for Int64.");

            // need to pad to make 8 bytes
            int padBytes = 8 - b.Length;

            // two's complement encoding of negative values
            byte pad = 0x00;
            if (signed && b.Length > 0 && b[0] >= 0x80)
                pad = 0xff;

            // input is big endian, concat pad + reversed bigint bytes
            byte[] i = Enumerable.Repeat<byte>(pad, padBytes).Concat(b).ToArray();

            if (BitConverter.IsLittleEndian)
                i = i.Reverse().ToArray();

            return BitConverter.ToInt64(i, 0);
        }

        public static byte[] ToBigEndian(byte[] value)
        {
            if (BitConverter.IsLittleEndian)
                Array.Reverse(value);
            return value;
        }

        public static byte[] ConcatBytes(params byte[][] blocks)
        {
            byte[] c = new byte[blocks.Sum(a => a.Length)];
            int offset = 0;

            foreach (byte[] block in blocks)
            {
                Buffer.BlockCopy(block, 0, c, offset, block.Length);
                offset += block.Length;
            }

            return c;
        }

        public static byte[] HexToBytes(string hex)
        {
            hex = hex.Replace(" ", "").Replace("-", "");

            byte[] b = new byte[hex.Length / 2];

            try
            {
                for (int i = 0; i < hex.Length; i += 2)
                {
                    string strB = hex.Substring(i, 2);
                    b[i / 2] = byte.Parse(strB, System.Globalization.NumberStyles.HexNumber);
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Failed to parse hex string '{hex}', error: {e.ToString()}");
            }

            return b;
        }

        public static string BytesToHex(IList<byte> bytes, string separator = "", int linebreak = 0, int maxBytes = 0)
        {
            bool hasSeparator = !string.IsNullOrEmpty(separator);
            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Count; i++)
            {
                if (maxBytes > 0 && i >= maxBytes)
                    break;
                sb.Append(bytes[i].ToString("X2"));
                if (hasSeparator)
                    sb.Append(separator);
            }

            string hex = sb.ToString();

            if (linebreak > 0)
            {
                string hexsep = "";
                int perbyte = separator.Length + 2;
                for (int i = 0; i < hex.Length; i += (linebreak * perbyte))
                {
                    int linelength = linebreak * perbyte;
                    if (hex.Length < i + linelength)
                        linelength = hex.Length - i;
                    hexsep += hex.Substring(i, linelength) + Environment.NewLine;
                }
                return hexsep;
            }
            else
                return hex;
        }
    }
}
