// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Commands.NetAppFiles.Models
{
    public class PSNetAppFilesBindPasswordAkvConfig
    {
        public string AzureKeyVaultUri { get; set; }
        public string SecretName { get; set; }
        public string UserAssignedIdentity { get; set; }
    }
}
