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

using System;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public class ObjectIdentifier
    {
        internal void SetObjectIdentifier(VaultUriHelper vaultUriHelper, Azure.KeyVault.ObjectIdentifier identifier)
        {
            if (vaultUriHelper == null)
                throw new ArgumentNullException("vaultUriHelper");

            if (identifier == null)
                throw new ArgumentNullException("identifier");

            VaultName = vaultUriHelper.GetVaultName(identifier.Identifier);
            Name = identifier.Name;
            Version = identifier.Version;
            Id = identifier.Identifier;
        }

        internal void SetObjectIdentifier(ObjectIdentifier identifier)
        {
            if (identifier == null)
                throw new ArgumentNullException("identifier");

            VaultName = identifier.VaultName;
            Name = identifier.Name;
            Version = identifier.Version;
            Id = identifier.Id;
        }


        public string VaultName { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public string Id { get; set; }
    }
}
