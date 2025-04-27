﻿// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Management.DataBoxEdge.Models;
using Microsoft.Rest;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.DataBoxEdge
{
    public static partial class ExtendedClientMethods
    {

        /// <summary>
        /// Use this method to encrypt the user secrets (Storage Account Access Key, Volume Container Encryption Key etc.) using activation key
        /// </summary>
        /// <param name="deviceName">
        /// The resource name.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="plainTextSecret">
        /// The plain text secret.
        /// </param>
        /// <returns>
        /// The <see cref="AsymmetricEncryptedSecret"/>.
        /// </returns>
        /// <exception cref="ValidationException">
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public static AsymmetricEncryptedSecret GetAsymmetricEncryptedSecretUsingActivationKey(
            this IDevicesOperations operations,
                string deviceName,
            string resourceGroupName,

            string plainTextSecret,
            string activationKey)
        {
            if (string.IsNullOrWhiteSpace(activationKey))
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "activationKey");
            }



            string channelIntegrationKey = GetChannelIntegrityKey(activationKey);
            return operations.GetAsymmetricEncryptedSecret(deviceName, resourceGroupName, plainTextSecret, channelIntegrationKey);
        }

        /// <summary>
        /// Use this method to encrypt the user secrets (Storage Account Access Key, Volume Container Encryption Key etc.) using CIK
        /// </summary>
        /// <param name="deviceName">
        /// The resource name.
        /// </param>
        /// <param name="resourceGroupName">
        /// The resource group name.
        /// </param>
        /// <param name="plainTextSecret">
        /// The plain text secret.
        /// </param>
        /// <returns>
        /// The <see cref="AsymmetricEncryptedSecret"/>.
        /// </returns>
        /// <exception cref="ValidationException">
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        public static AsymmetricEncryptedSecret GetAsymmetricEncryptedSecret(
            this IDevicesOperations operations,
                string deviceName,
                string resourceGroupName,
                string plainTextSecret,
                string channelIntegrationKey)
        {
            if (string.IsNullOrWhiteSpace(plainTextSecret))
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "plainTextSecret");
            }

            if (string.IsNullOrWhiteSpace(resourceGroupName))
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "resourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(deviceName))
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "resourceName");
            }

            DataBoxEdgeDeviceExtendedInfo extendedInfo = operations.GetExtendedInformation(deviceName, resourceGroupName);
            string encryptionKey = extendedInfo.EncryptionKey;
            string encryptionKeyThumbprint = extendedInfo.EncryptionKeyThumbprint;

            string ChannelEncryptionKey = CryptoUtilities.DecryptStringAES(encryptionKey, channelIntegrationKey);

            var secret = new AsymmetricEncryptedSecret()
            {
                EncryptionAlgorithm = EncryptionAlgorithm.AES256,
                EncryptionCertThumbprint = encryptionKeyThumbprint,
                Value = CryptoUtilities.EncryptStringRsaPkcs1v15(plainTextSecret, ChannelEncryptionKey)
            };

            return secret;
        }


        private static string GetChannelIntegrityKey(string activationKey)
        {
            string[] keys = activationKey.Split('#');
            string encodedString = keys[0];
            byte[] data = Convert.FromBase64String(encodedString);
            string decodedString = Encoding.UTF8.GetString(data);
            var jsondata = (JObject)JsonConvert.DeserializeObject(decodedString);
            string serviceDataIntegrityKey = jsondata["serviceDataIntegrityKey"].Value<string>();
            return serviceDataIntegrityKey;
        }
    }
}