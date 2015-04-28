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

using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets.Library;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class StorSimpleClient
    {
        public GetResourceEncryptionKeyResponse GetResourceEncryptionKey()
        {
            return this.GetStorSimpleClient().ResourceEncryptionKeys.Get(GetCustomRequestHeaders());
        }

        public string GetDevicePublicKey(string deviceId)
        {
            var response = this.GetStorSimpleClient().DevicePublicKey.Get(deviceId, GetCustomRequestHeaders());

            if (response == null || response.DevicePublicKey == null)
            {
                return null;
            }
            else
            {
                return response.DevicePublicKey;
            }
        }

        /// <summary>
        /// Encrypts specified data with the Device Public Key
        /// </summary>
        /// <param name="data">string to be encrypted</param>
        /// <returns>Encrypted string</returns>
        public string EncryptWithDevicePublicKey(string deviceId, string data)
        {
            // Get the public key certificate
            var cert = this.GetDevicePublicKey(deviceId);
            if (cert == null)
            {
                throw new Exception(Resources.ErrorRetrievingDevicePublicKey);
            }
            return CryptoHelper.EncryptSecretRSAPKCS(data, cert);
        }
    }
}
