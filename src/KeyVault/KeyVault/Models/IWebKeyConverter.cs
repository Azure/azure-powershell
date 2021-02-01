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

using System.IO;
using System.Security;
using Track2Sdk = Azure.Security.KeyVault.Keys;
using Track1Sdk = Microsoft.Azure.KeyVault.WebKey;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    internal interface IWebKeyConverter
    {
        Track1Sdk.JsonWebKey ConvertKeyFromFile(FileInfo fileInfo, SecureString password, WebKeyConverterExtraInfo extraInfo = null);

        Track2Sdk.JsonWebKey ConvertToTrack2SdkKeyFromFile(FileInfo fileInfo, SecureString password);
    }

    /// <summary>
    /// Extra information you may append to the converted JWK
    /// </summary>
    internal class WebKeyConverterExtraInfo {
        public string KeyType;
        public string CurveName;
    }
}
