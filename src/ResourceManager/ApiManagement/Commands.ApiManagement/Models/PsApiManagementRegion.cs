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
    using AutoMapper;
    using Microsoft.Azure.Management.ApiManagement.Models;
    using System;
    using System.Linq;

    public class PsApiManagementRegion
    {
        public PsApiManagementRegion()
        {
        }

        internal PsApiManagementRegion(AdditionalRegion regionResource)
            : this()
        {
            if (regionResource == null)
            {
                throw new ArgumentNullException("regionResource");
            }

            Location = regionResource.Location;
            Sku = Mapper.Map<SkuType, PsApiManagementSku>(regionResource.SkuType);
            Capacity = regionResource.SkuUnitCount ?? 1;
            StaticIPs = regionResource.StaticIPs.ToArray();

            if (regionResource.VirtualNetworkConfiguration != null)
            {
                VirtualNetwork = new PsApiManagementVirtualNetwork(regionResource.VirtualNetworkConfiguration);
            }
        }

        public PsApiManagementVirtualNetwork VirtualNetwork { get; set; }

        public string[] StaticIPs { get; private set; }

        public int Capacity { get; set; }

        public PsApiManagementSku Sku { get; set; }

        public string Location { get; set; }
    }
}