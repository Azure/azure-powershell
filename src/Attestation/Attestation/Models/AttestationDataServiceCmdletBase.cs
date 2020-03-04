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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common;

namespace Microsoft.Azure.Commands.Attestation.Models
{
    public class AttestationDataServiceCmdletBase : AzureRMCmdlet
    {
        private AttestationDataServiceClient _attestationDataPlaneClient;

        #region Parameter Sets

        protected const string NameParameterSet = "NameParameterSet";
        protected const string ResourceIdParameterSet = "ResourceIdParameterSet";

        #endregion

        public AttestationDataServiceClient AttestationDataPlaneClient
        {
            get
            {
                if (_attestationDataPlaneClient == null)
                {
                    _attestationDataPlaneClient = new AttestationDataServiceClient(AzureSession.Instance.AuthenticationFactory, DefaultContext);
                }
                return _attestationDataPlaneClient;
            }
            set { _attestationDataPlaneClient = value; }
        }
    }
}
