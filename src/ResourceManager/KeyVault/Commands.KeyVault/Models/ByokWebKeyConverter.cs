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

using Microsoft.Azure.KeyVault.WebKey;
using System;
using System.IO;
using System.Security;
using KeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using Microsoft.Azure.KeyVault.Models;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    /// <summary>
    /// Utility class that creates web key from a BYOK file
    /// </summary>
    internal class ByokWebKeyConverter : IWebKeyConverter
    {
        public ByokWebKeyConverter(IWebKeyConverter next = null)
        {
            this.next = next;
        }

        public JsonWebKey ConvertKeyFromFile(FileInfo fileInfo, SecureString password)
        {
            if (CanProcess(fileInfo))
                return Convert(fileInfo.FullName);
            else if (next != null)
                return next.ConvertKeyFromFile(fileInfo, password);
            else
                throw new ArgumentException(string.Format(KeyVaultProperties.Resources.UnsupportedFileFormat, fileInfo.Name));
        }

        private bool CanProcess(FileInfo fileInfo)
        {
            if (fileInfo == null || string.IsNullOrEmpty(fileInfo.Extension))
                return false;

            return ByokFileExtension.Equals(fileInfo.Extension, StringComparison.OrdinalIgnoreCase);
        }

        private JsonWebKey Convert(string byokFileName)
        {
            byte[] byokBlob = File.ReadAllBytes(byokFileName);

            if (byokBlob == null || byokBlob.Length == 0)
                throw new ArgumentException(string.Format(KeyVaultProperties.Resources.InvalidKeyBlob, "BYOK"));
            return new JsonWebKey()
            {
                Kty = JsonWebKeyType.RsaHsm,
                T = byokBlob,
            };
        }

        private IWebKeyConverter next;
        private const string ByokFileExtension = ".byok";

    }
}
