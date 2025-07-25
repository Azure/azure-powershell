using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using Microsoft.Azure.Commands.KeyVault.SecurityDomain.Common;

namespace Microsoft.Azure.Commands.KeyVault.SecurityDomain.Models
{
    internal class KDF
    {
        static public byte[] to_big_endian(Int32 value)
        {
            byte[] result = new byte[4];
            result[3] = (byte)((value & 0x000000FF));
            result[2] = (byte)((value & 0x0000FF00) >> 8);
            result[1] = (byte)((value & 0x00FF0000) >> 16);
            result[0] = (byte)((value & 0xFF000000) >> 24);
            return result;
        }
        static public byte[] to_big_endian(UInt64 value)
        {
            byte[] result = new byte[8];
            result[7] = (byte)((value & 0x00000000000000FF));
            result[6] = (byte)((value & 0x000000000000FF00) >> 8);
            result[5] = (byte)((value & 0x0000000000FF0000) >> 16);
            result[4] = (byte)((value & 0x00000000FF000000) >> 24);
            result[3] = (byte)((value & 0x000000FF00000000) >> 32);
            result[2] = (byte)((value & 0x0000FF0000000000) >> 40);
            result[1] = (byte)((value & 0x00FF000000000000) >> 48);
            result[0] = (byte)((value & 0xFF00000000000000) >> 56);
            return result;
        }

        static public bool self_test_sp800_108()
        {
            string label = "label";
            string context = "context";
            Int32 bitLength = 256;
            string hex_result = "f0ca51f6308791404bf68b56024ee7c64d6c737716f81d47e1e68b5c4e399575";

            byte[] key = Enumerable.Repeat((byte)0x41, 32).ToArray();
            HMACSHA512 hmac = new HMACSHA512();

            byte[] new_key = sp800_108(key, label, context, hmac, bitLength);

            string hex = BitConverter.ToString(new_key).Replace("-", "");

            return (hex.ToLower() == hex_result);
        }

        // Note - initialize out to be the number of bytes of keying material that you need
        // This implements SP 800-108 in counter mode, see section 5.1
        /*
        Fixed values:
            1. h - The length of the output of the PRF in bits, and
            2. r - The length of the binary representation of the counter i.

        Input: KI, Label, Context, and L.

        Process:
            1. n := ⎡L/h⎤.
            2. If n > 2^(r-1), then indicate an error and stop.
            3. result(0):= ∅.
            4. For i = 1 to n, do
                a. K(i) := PRF (KI, [i]2 || Label || 0x00 || Context || [L]2)
                b. result(i) := result(i-1) || K(i).

            5. Return: KO := the leftmost L bits of result(n). 
        */
        static public byte[] sp800_108(byte[] key_in, string label, string context, HMAC hMAC, Int32 bit_length)
        {
            if (bit_length <= 0 || bit_length % 8 != 0)
                return null;

            Int32 L = bit_length;
            Int32 bytes_needed = bit_length / 8;
            Int32 n = 0;
            Int32 hash_bits = 0;

            hash_bits = hMAC.HashSize;

            n = L / hash_bits;

            if (L % hash_bits != 0)
                n++;

            Int32 hmac_data_size = 4 + label.Length + 1 + context.Length + 4;
            byte[] hmac_data_suffix = null;

            using (MemoryStream mem = new MemoryStream())
            {
                byte[] zero = new byte[1];
                zero[0] = 0;

                mem.Write(Encoding.UTF8.GetBytes(label));
                mem.Write(zero);
                mem.Write(Encoding.UTF8.GetBytes(context));
                mem.Write(to_big_endian(bit_length));
                hmac_data_suffix = mem.ToArray();
            }

            using (MemoryStream out_stm = new MemoryStream())
            {
                for (Int32 i = 0; i < n; ++i)
                {
                    byte[] hmac_data = null;

                    using (MemoryStream mem = new MemoryStream())
                    {
                        mem.Write(to_big_endian(i + 1));
                        mem.Write(hmac_data_suffix);
                        hmac_data = mem.ToArray();
                    }

                    hMAC.Key = key_in;
                    byte[] hash_value = hMAC.ComputeHash(hmac_data);

                    if (bytes_needed > hash_value.Length)
                    {
                        out_stm.Write(hash_value);
                        bytes_needed -= hash_value.Length;
                    }
                    else
                    {
                        out_stm.Write(hash_value, (int)out_stm.Length, bytes_needed);
                        return out_stm.ToArray();
                    }
                    // reset hmac for next round
                    hMAC.Initialize();
                }
            }
            return null;
        }
    }
}
