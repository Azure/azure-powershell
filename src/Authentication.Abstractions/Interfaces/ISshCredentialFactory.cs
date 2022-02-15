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

using System.Security.Cryptography;

using Microsoft.Azure.Commands.Common.Authentication.Abstractions.Models;

namespace Microsoft.Azure.Commands.Common.Authentication.Abstractions
{
    /// <summary>
    /// The factory for get SSH credential of VM
    /// </summary>
    public interface ISshCredentialFactory
    {
        /// <summary>
        /// Get SSH credential
        /// </summary>
        /// <param name="context">The context to use for authentication</param>
        /// <param name="rsaKeyInfo">The RSAParameters import from RSA public key or created in memory</param>
        /// <returns>Credentials for SSH.</returns>
        SshCredential GetSshCredential(IAzureContext context, RSAParameters rsaKeyInfo);
    }
}