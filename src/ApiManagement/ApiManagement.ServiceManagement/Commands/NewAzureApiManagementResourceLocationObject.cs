//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.

using System.Collections;
using System.Linq;

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using System.Management.Automation;

    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "ApiManagementResourceLocationObject")]
    [OutputType(typeof(PsApiManagementResourceLocation))]
    public class NewAzureApiManagementResourceLocationObject : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = true,
            HelpMessage = "Location Name. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Location City. This parameter is optional.")]
        public string City { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Location District. This parameter is optional.")]
        public string District { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = false,
            Mandatory = false,
            HelpMessage = "Location Country or Region. This parameter is optional.")]
        public string CountryOrRegion { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            var location = new PsApiManagementResourceLocation();

            if (Name != null)
            {
                location.Name = Name;
            }

            if (District != null)
            {
                location.District = District;
            }

            if (City != null)
            {
                location.City = City;
            }

            if (CountryOrRegion != null)
            {
                location.CountryOrRegion = CountryOrRegion;
            }

            WriteObject(location);
        }
    }
}
