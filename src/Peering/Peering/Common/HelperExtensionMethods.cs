// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------
namespace Microsoft.Azure.PowerShell.Cmdlets.Peering.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Net;
    using System.Net.Sockets;
    using System.Numerics;
    using System.Reflection;

    using Microsoft.Azure.Commands.Peering.Properties;

    /// <summary>
    /// Helper Extension Methods
    /// </summary>
    public static class HelperExtensionMethods
    {
        /// <summary>
        /// Big INT from IPAddress
        /// </summary>
        /// <param name="self">IPAddress to convert</param>
        /// <returns>Big INT of IPAddress</returns>
        public static BigInteger BigUIntFromIpAddress(this IPAddress self)
        {
            var addressBytes = self.GetAddressBytes();

            var paddedAddressBytes = GetUnsignedBigEndianBytes(addressBytes);

            return new BigInteger(paddedAddressBytes);
        }

        /// <summary>
        /// The Bit array always stored data like a IPAddress in big-indian format
        /// </summary>
        /// <param name="self">The self.</param>
        /// <param name="addressFamily">The address family.</param>
        /// <returns>Converted BitArray</returns>
        public static BitArray ToBitArray(this BigInteger self, AddressFamily addressFamily)
        {
            var addressBytes = GetBigIntegerContent(self, addressFamily);

            if (BitConverter.IsLittleEndian)
            {
                // little-endian machines store multi-byte integers with the
                // least significant byte first. this is a problem, as integer
                // values are sent over the network in big-endian mode. reversing
                // the order of the bytes is a quick way to get the BitConverter
                // methods to convert the byte arrays in big-endian mode.
                Array.Reverse(addressBytes);
            }

            addressBytes = SwapBytes(addressBytes);

            return new BitArray(addressBytes);
        }

        /// <summary>
        /// Toes the IP address.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <param name="addressFamily">The address family.</param>
        /// <returns>Converted IPAddress</returns>
        public static IPAddress ToIpAddress(this BigInteger self, AddressFamily addressFamily)
        {
            var addressBytes = GetBigIntegerContent(self, addressFamily);

            if (BitConverter.IsLittleEndian)
            {
                // little-endian machines store multi-byte integers with the
                // least significant byte first. this is a problem, as integer
                // values are sent over the network in big-endian mode. reversing
                // the order of the bytes is a quick way to get the BitConverter
                // methods to convert the byte arrays in big-endian mode.
                Array.Reverse(addressBytes);
            }

            return new IPAddress(addressBytes);
        }

        /// <summary>
        /// Bit Array to IPAddress
        /// </summary>
        /// <param name="self">BitArray to convert</param>
        /// <returns>Converted IPAddress</returns>
        public static IPAddress ToIpAddress(this BitArray self)
        {
            return new IPAddress(self.ToByteArray());
        }

        /// <summary>
        /// The detailed compare.
        /// </summary>
        /// <param name="val1">
        /// The val 1.
        /// </param>
        /// <param name="val2">
        /// The val 2.
        /// </param>
        /// <typeparam name="T"> The Type parameter
        /// </typeparam>
        /// <returns>
        /// The <see cref="List{Variance}"/>.
        /// </returns>
        public static List<Variance> DetailedCompare<T>(this T val1, T val2)
        {
            List<Variance> variances = new List<Variance>();
            PropertyInfo[] pr = (val1.GetType().GetProperties());
            foreach (PropertyInfo p in pr)
            {
                Variance v = new Variance();
                v.Prop = p.Name;
                v.ValA = p.GetValue(val1);
                v.ValB = p.GetValue(val2);
                if (!Equals(v.ValA, v.ValB))
                    variances.Add(v);
            }
            return variances;
        }

        /// <summary>
        /// To byte array
        /// </summary>
        /// <param name="self">BitArray to convert</param>
        /// <returns>Byte array</returns>
        public static byte[] ToByteArray(this BitArray self)
        {
            var byteArray = new byte[Math.Max(1, self.Count / 8)];

            int byteIndex = 0, bitIndex = 0;

            for (var i = 0; i < self.Count; i++)
            {
                if (self[i])
                {
                    byteArray[byteIndex] |= (byte)(1 << (7 - bitIndex));
                }

                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }

            return byteArray;
        }

        /// <summary>
        /// Swap Bytes
        /// </summary>
        /// <param name="addressBytes">Address bytes array</param>
        /// <returns>Byte array swapped</returns>
        private static byte[] SwapBytes(byte[] addressBytes)
        {
            var destBytes = new byte[addressBytes.Length];

            for (var i = 0; i < addressBytes.Length; i++)
            {
                destBytes[i] = SwapByte(addressBytes[i]);
            }

            return destBytes;
        }

        /// <summary>
        /// This method swap byte
        /// </summary>
        /// <param name="value">Byte to swap</param>
        /// <returns>swapped byte</returns>
        private static byte SwapByte(byte value)
        {
            byte result = 0;

            var counter = 8;
            while (counter-- > 0)
            {
                result <<= 1;
                result |= (byte)(value & 1);
                value = (byte)(value >> 1);
            }

            return result;
        }

        /// <summary>
        /// Get Big INT content
        /// </summary>
        /// <param name="bigInteger">BigInteger to convert</param>
        /// <param name="addressFamily">AddressFamily of IPAddress</param>
        /// <returns>Byte array</returns>
        private static byte[] GetBigIntegerContent(BigInteger bigInteger, AddressFamily addressFamily)
        {
            var addressBytes = bigInteger.ToByteArray();
            byte[] notPaddedAddressBytes;

            // Remove padding for negative numbers if present
            if (addressBytes.Length > 4 && addressBytes.Length % 4 != 0)
            {
                notPaddedAddressBytes = new byte[addressBytes.Length - 1];
                Array.Copy(addressBytes, notPaddedAddressBytes, addressBytes.Length - 1);
            }
            else
            {
                notPaddedAddressBytes = addressBytes;
            }

            // Special case BigInteger = 0
            if (addressBytes.Length == 1 && addressBytes[0] == 0)
            {
                if (addressFamily == AddressFamily.InterNetwork)
                {
                    notPaddedAddressBytes = new byte[4];
                }
                else if (addressFamily == AddressFamily.InterNetworkV6)
                {
                    notPaddedAddressBytes = new byte[16];
                }
            }

            return notPaddedAddressBytes;
        }

        /// <summary>
        /// Get unsigned bytes
        /// </summary>
        /// <param name="addressBytes">Address bytes</param>
        /// <returns>Byte array unsigned</returns>
        private static byte[] GetUnsignedBigEndianBytes(byte[] addressBytes)
        {
            if (BitConverter.IsLittleEndian)
            {
                // little-endian machines store multi-byte integers with the
                // least significant byte first. this is a problem, as integer
                // values are sent over the network in big-endian mode. reversing
                // the order of the bytes is a quick way to get the BitConverter
                // methods to convert the byte arrays in big-endian mode.
                Array.Reverse(addressBytes);
            }

            // Pad with zero to prevent negative numbers
            var paddedAddressBytes = new byte[addressBytes.Length + 1];
            Array.Copy(addressBytes, paddedAddressBytes, addressBytes.Length);
            return paddedAddressBytes;
        }

        public static bool IsValidEmail(string email)
        {
            if (email.Contains("@"))
            {
                return true;
            }
            throw new PSArgumentException(string.Format(Resources.Error_InvalidEmailAddress, email));
        }
    }
}