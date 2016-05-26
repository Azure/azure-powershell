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

namespace Microsoft.Azure.Commands.ApiManagement.Models
{
    using Microsoft.Azure.Management.ApiManagement.Models;
    using System;

    public class PsApiManagementVirtualNetwork
    {
        public PsApiManagementVirtualNetwork()
        {
        }

        internal PsApiManagementVirtualNetwork(VirtualNetworkConfiguration vnetConfigurationResource)
            : this()
        {
            if (vnetConfigurationResource == null)
            {
                throw new ArgumentNullException("vnetConfigurationResource");
            }

            Location = vnetConfigurationResource.Location;
            SubnetName = vnetConfigurationResource.SubnetName;
            VnetId = vnetConfigurationResource.VnetId;
        }

        public string Location { get; set; }

        public string SubnetName { get; set; }

        public Guid VnetId { get; set; }
    }
}