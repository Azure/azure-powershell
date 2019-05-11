
namespace Microsoft.Azure.Commands.Peering.Test.ScenarioTests
{
    using System;
    using System.Net;
    using System.Net.Sockets;
    using System.Security.Cryptography;
    using System.Text;

    using Microsoft.Azure.PowerShell.Cmdlets.Peering.Common;
    public class IPGenerator
    {
        public Random random = new Random();
        public MD5 md5Hash = MD5.Create();

        public IPGenerator() { }

        public string CreateIpv4Address(int offset = 0, bool maxPrefix = false)
        {
            var bytes = new byte[4];
            new Random(offset).NextBytes(bytes);
            bytes[3] = maxPrefix ? new byte() : bytes[3];
            var ipv4Address = new IPAddress(bytes);
            var addressString = ipv4Address.ToString();
            return maxPrefix ? $"{addressString}/31" : $"{addressString}/32";
        }
        public string CreateIpv6Address(int offset = 0, bool maxPrefix = false)
        {
            var bytes = new byte[16];
            new Random(offset).NextBytes(bytes);
            bytes[15] = maxPrefix ? new byte() : bytes[15];
            var ipv6Address = new IPAddress(bytes);
            var addressString = ipv6Address.ToString();
            return maxPrefix ? $"{addressString}/127" : $"{addressString}/128";
        }
        public string OffSet(string ipAddress, bool v6 = false, int offset = 0, bool hasPrefix = false)
        {
            var route = new RoutePrefix(ipAddress);
            if (route.StartOfPrefixBigInt % 2 != 0)
                if (!v6)
                {
                    return hasPrefix
                               ? $"{(route.StartOfPrefixBigInt + offset).ToIpAddress(AddressFamily.InterNetwork)}/{route.PrefixMaskWidth}"
                               : (route.StartOfPrefixBigInt + offset).ToIpAddress(AddressFamily.InterNetwork)
                               .ToString();
                }
            return hasPrefix
                       ? $"{(route.StartOfPrefixBigInt + offset).ToIpAddress(AddressFamily.InterNetworkV6)}/{route.PrefixMaskWidth}"
                       : (route.StartOfPrefixBigInt + offset).ToIpAddress(AddressFamily.InterNetworkV6).ToString();
        }

        public string BuildHash()
        {
            return this.GetMd5Hash($"{this.random.Next(0, 99999)}SomeNewString{this.random.Next(0, 99999)}").ToString();
        }

        public string GetMd5Hash(string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = this.md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        public uint BuildMaxPrefixes(bool isV6 = false)
        {
            return isV6 ? (uint)this.random.Next(1, 2000) : (uint)this.random.Next(1, 20000);
        }

        public int GetBandwidth()
        {
            return this.random.Next(1, 10) * 10000;
        }
    }
}