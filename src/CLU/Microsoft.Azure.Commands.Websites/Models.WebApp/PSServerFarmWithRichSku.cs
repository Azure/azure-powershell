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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Resources;
using Microsoft.Azure.Management.WebSites.Models;
using Newtonsoft.Json;
using Microsoft.Azure.Commands.Resources.Models;

namespace Microsoft.Azure.Commands.Websites.Models.WebApp
{
    public class PSServerFarmWithRichSku : PSFlattenedResource
    {
        public static implicit operator PSServerFarmWithRichSku(ServerFarmWithRichSku farm)
        {
            return new PSServerFarmWithRichSku(farm);
        }

        public PSServerFarmWithRichSku()
        {
        }

        protected PSServerFarmWithRichSku(ServerFarmWithRichSku farm) : base(farm)
        {
            AdminSiteName = farm.AdminSiteName;
            GeoRegion = farm.GeoRegion;
            HostingEnvironmentProfile = farm.HostingEnvironmentProfile;
            MaximumNumberOfWorkers = farm.MaximumNumberOfWorkers;
            NumberOfSites = farm.NumberOfSites;
            PerSiteScaling = farm.PerSiteScaling;
            ResourceGroup = farm.ResourceGroup;
            ServerFarmWithRichSkuName = farm.ServerFarmWithRichSkuName;
            Sku = farm.Sku;
            Status = farm.Status;
            Subscription = farm.Subscription;
        }

        public SkuDescription Sku { get; set; }

        [JsonIgnore]
        public string SkuText {
            get { return Sku.SerializeJson();}
        }

        /// <summary>
        /// Name for the App Service Plan
        /// </summary>
        public string ServerFarmWithRichSkuName { get; set; }

        /// <summary>
        /// App Service Plan Status. Possible values for this property
        /// include: 'Ready', 'Pending'.
        /// </summary>
        public StatusOptions? Status { get; private set; }

        /// <summary>
        /// App Service Plan Subscription
        /// </summary>
        public string Subscription { get; private set; }

        /// <summary>
        /// App Service Plan administration site
        /// </summary>
        public string AdminSiteName { get; set; }

        /// <summary>
        /// Specification for the hosting environment (App Service
        /// Environment) to use for the App Service Plan
        /// </summary>
        public HostingEnvironmentProfile HostingEnvironmentProfile { get; set; }

        [JsonIgnore]
        public string HostingEnvironmentProfileText { get { return HostingEnvironmentProfile.SerializeJson(); } }

        /// <summary>
        /// Maximum number of instances that can be assigned to this App
        /// Service Plan
        /// </summary>
        public int? MaximumNumberOfWorkers { get; set; }

        /// <summary>
        /// Geographical location for the App Service Plan
        /// </summary>
        public string GeoRegion { get; private set; }

        /// <summary>
        /// If True apps assigned to this App Service Plan can be scaled
        /// independently
        /// If False apps assigned to this App Service Plan will
        /// scale to all instances of the plan
        /// </summary>
        public bool? PerSiteScaling { get; set; }

        /// <summary>
        /// Number of web apps assigned to this App Service Plan
        /// </summary>
        public int? NumberOfSites { get; private set; }

        /// <summary>
        /// Resource group of the serverfarm
        /// </summary>
        public string ResourceGroup { get; private set; }

    }
}
