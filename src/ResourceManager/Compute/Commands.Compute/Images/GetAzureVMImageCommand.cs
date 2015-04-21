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

using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet(VerbsCommon.Get, ProfileNouns.VirtualMachineImage, DefaultParameterSetName = ListVirtualMachineImageParamSet)]
    [OutputType(typeof(VirtualMachineImageGetResponse), typeof(VirtualMachineImageResourceList))]
    public class GetAzureVMImageCommand : VirtualMachineImageBaseCmdlet
    {
        protected const string GetVirtualMachineImageDetailsParamSet = "GetVirtualMachineImageDetailsParamSet";
        protected const string ListVirtualMachineImageParamSet = "ListVirtualMachineImageParamSet";

        [Parameter(Mandatory = true), ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = true), ValidateNotNullOrEmpty]
        public string Offer { get; set; }

        [Parameter(Mandatory = true), ValidateNotNullOrEmpty]
        public string PublisherName { get; set; }

        [Parameter(Mandatory = true), ValidateNotNullOrEmpty]
        public string Skus { get; set; }

        [Parameter(ParameterSetName = GetVirtualMachineImageDetailsParamSet), ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(ParameterSetName = ListVirtualMachineImageParamSet), ValidateNotNullOrEmpty]
        public string FilterExpression { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.ParameterSetName == GetVirtualMachineImageDetailsParamSet)
            {
                var parameters = new VirtualMachineImageGetParameters
                {
                    Location = Location,
                    Offer = Offer,
                    PublisherName = PublisherName,
                    Skus = Skus,
                    Version = Version
                };

                VirtualMachineImageGetResponse result = this.VirtualMachineImageClient.Get(parameters);
                WriteObject(result);
            }
            else if (this.ParameterSetName == ListVirtualMachineImageParamSet)
            {
                var parameters = new VirtualMachineImageListParameters
                {
                    Location = Location,
                    Offer = Offer,
                    PublisherName = PublisherName,
                    Skus = Skus,
                    FilterExpression = FilterExpression
                };

                VirtualMachineImageResourceList result = this.VirtualMachineImageClient.List(parameters);
                WriteObject(result);
            }
        }
    }
}
