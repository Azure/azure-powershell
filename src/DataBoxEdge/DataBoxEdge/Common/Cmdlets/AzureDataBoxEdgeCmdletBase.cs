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

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Common;
using Microsoft.Azure.Management.EdgeGateway;
using System.Text;
using Microsoft.Azure.Management.EdgeGateway.Models;

namespace Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Common
{
    /// <summary>
    /// Base class of Azure Databox Cmdlet.
    /// </summary>
    public class AzureDataBoxEdgeCmdletBase : AzureRMCmdlet
    {
        private DataBoxEdgeManagementClient _dataBoxManagementClient;


        public static Dictionary<K, V> HashtableToDictionary<K, V>(Hashtable table)
        {
            return table
                .Cast<DictionaryEntry>()
                .ToDictionary(kvp => (K) kvp.Key, kvp => (V) kvp.Value);
        }

        /// <summary>
        /// Gets or sets the Databox management client.
        /// </summary>
        public DataBoxEdgeManagementClient DataBoxEdgeManagementClient
        {
            get
            {
                return _dataBoxManagementClient ??
                       (_dataBoxManagementClient =
                           AzureSession.Instance.ClientFactory.CreateArmClient<DataBoxEdgeManagementClient>(
                               DefaultProfile.DefaultContext,
                               AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _dataBoxManagementClient = value; }
        }

        internal DataBoxEdgeDeviceExtendedInfo GetExtendedInfo(string resourceGroupName, string deviceName)
        {
            return DevicesOperationsExtensions.GetExtendedInformation(
                this.DataBoxEdgeManagementClient.Devices,
                deviceName,
                resourceGroupName);
        }

        internal string GetEncryptedKeyFromExtendedInfo(string resourceGroupName, string deviceName)
        {
            var info = GetExtendedInfo(resourceGroupName, deviceName);
            return info.EncryptionKey;
        }

        private static byte[] _salt = Encoding.ASCII.GetBytes("o6806642kbM7c5");

        private static byte[] ReadByteArray(Stream s)
        {
            byte[] rawLength = new byte[sizeof(int)];
            if (s.Read(rawLength, 0, rawLength.Length) != rawLength.Length)
            {
                throw new SystemException("Stream did not contain properly formatted byte array");
            }

            byte[] buffer = new byte[BitConverter.ToInt32(rawLength, 0)];
            if (s.Read(buffer, 0, buffer.Length) != buffer.Length)
            {
                throw new SystemException("Did not read byte array properly");
            }

            return buffer;
        }


        private static string DecryptStringAES(string cipherText, string sharedSecret)
        {
            if (string.IsNullOrEmpty(cipherText))
                return cipherText;

            AesManaged aesAlg = null;
            string plaintext = null;

            // generate the key from the shared secret and the salt
            Rfc2898DeriveBytes key = new Rfc2898DeriveBytes(sharedSecret, _salt);

            // Create the streams used for decryption.
            byte[] bytes = Convert.FromBase64String(cipherText);
            using (MemoryStream msDecrypt = new MemoryStream(bytes))
            {
                aesAlg = new AesManaged();
                aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
                // Get the initialization vector from the encrypted stream
                aesAlg.IV = ReadByteArray(msDecrypt);
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (CryptoStream csDecrypt =
                    new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                }
            }

            return plaintext;
        }

        public static string GetAES(string encryptedKey, string encryptionKey)
        {
            return DecryptStringAES(encryptedKey, encryptionKey);
        }
    }
}