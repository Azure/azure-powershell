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

using Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.Model;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.ImagePublishing
{
    [Cmdlet(VerbsCommon.New, "AzurePlatformComputeImageConfig"), OutputType(typeof(ComputeImageConfig))]
    public class NewAzurePlatformComputeImageConfig : PSCmdlet
    {
        [Parameter, ValidateNotNullOrEmpty]
        public string Offer { get; set; }

        [Parameter, ValidateNotNullOrEmpty]
        public string Sku { get; set; }

        [Parameter, ValidateNotNullOrEmpty]
        public string Version { get; set; }

        protected override void ProcessRecord()
        {
            ServiceManagementProfile.Initialize();

            var result = new ComputeImageConfig
            {
                Offer = Offer,
                Sku = Sku,
                Version = Version
            };

            WriteObject(result);
        }
    }
}
