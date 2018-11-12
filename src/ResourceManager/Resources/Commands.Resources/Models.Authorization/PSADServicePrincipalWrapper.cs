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

using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using System.Security;

namespace Microsoft.Azure.Commands.Resources.Models.Authorization
{
    public class PSADServicePrincipalWrapper : PSADServicePrincipal
    {
        public PSADServicePrincipalWrapper(PSADServicePrincipal sp)
        {
            if (sp != null)
            {
                AdfsId = sp.AdfsId;
                ApplicationId = sp.ApplicationId;
                DisplayName = sp.DisplayName;
                Id = sp.Id;
                ServicePrincipalNames = sp.ServicePrincipalNames;
                Type = sp.Type;
            }
        }
        public SecureString Secret { get; set; }
    }
}
