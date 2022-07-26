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
    using Helpers;
    using System;
    using System.Linq;

    public class PsApiManagementRegion
    {
        public PsApiManagementRegion()
        {
        }

        internal PsApiManagementRegion(AdditionalLocation additionalLocation)
            : this()
        {
            if (additionalLocation == null)
            {
                throw new ArgumentNullException("regionResource");
            }

            Location = additionalLocation.Location;
            Sku = Mappers.MapSku(additionalLocation.Sku.Name);
            Capacity = additionalLocation.Sku.Capacity;
            RuntimeRegionalUrl = additionalLocation.GatewayRegionalUrl;
            PublicIPAddresses = additionalLocation.PublicIPAddresses != null ? additionalLocation.PublicIPAddresses.ToArray() : null;
            PrivateIPAddresses = additionalLocation.PrivateIPAddresses != null ? additionalLocation.PrivateIPAddresses.ToArray() : null;
            Zone = additionalLocation.Zones?.ToArray();
            DisableGateway = additionalLocation.DisableGateway;
            PublicIpAddressId = additionalLocation.PublicIpAddressId;
            PlatformVersion = additionalLocation.PlatformVersion;
            if (additionalLocation.VirtualNetworkConfiguration != null)
            {
                VirtualNetwork = new PsApiManagementVirtualNetwork(additionalLocation.VirtualNetworkConfiguration);
            }
        }

        public PsApiManagementVirtualNetwork VirtualNetwork { get; set; }

        public string[] PublicIPAddresses { get; private set; }

        public string[] PrivateIPAddresses { get; private set; }

        public int Capacity { get; set; }

        public PsApiManagementSku Sku { get; set; }

        public string Location { get; set; }

        public string RuntimeRegionalUrl { get; set; }

        public string[] Zone { get; set; }

        public bool? DisableGateway { get; set; }

        public string PublicIpAddressId { get; set; }

        //
        // Summary:
        //     Gets compute Platform Version running the service. Possible values include: 'undetermined',
        //     'stv1', 'stv2', 'mtv1'
        public string PlatformVersion { get; set; }
    }
}