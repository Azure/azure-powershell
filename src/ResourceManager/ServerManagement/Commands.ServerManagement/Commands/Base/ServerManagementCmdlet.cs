// Copyright Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// 
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Microsoft.Azure.Commands.ServerManagement.Commands.Base
{
    using System;
    using System.Runtime.InteropServices;
    using System.Security;
    using Common.Authentication;
    using Common.Authentication.Models;
    using Management.ServerManagement;
    using ResourceManager.Common;

    public class ServerManagementCmdlet : AzureRMCmdlet
    {
        private ServerManagementClient _client;

        internal ServerManagementClient Client
        {
            get
            {
                return _client ??
                       (_client = AzureSession.ClientFactory.CreateArmClient<ServerManagementClient>(DefaultContext,
                           AzureEnvironment.Endpoint.ResourceManager));
            }
            set { _client = value; }
        }

        protected string ToPlainText(SecureString secureString)
        {
            if (secureString == null)
            {
                throw new ArgumentNullException("secureString");
            }

            var valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(secureString);

                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }
    }
}