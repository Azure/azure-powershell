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

using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAzure.Commands.Utilities.Store
{
    using Resource = Management.Store.Models.CloudServiceListResponse.CloudService.AddOnResource;

    public class WindowsAzureAddOn
    {
        public const string DataSetType = "DataMarket";

        public const string DataType = "Data";

        public const string AppServiceType = "App Service";

        public string Type { get; set; }

        public string AddOn { get; set; }

        public string Name { get; set; }

        public string Plan { get; set; }

        public string SchemaVersion { get; set; }

        public string ETag { get; set; }

        public string State { get; set; }

        public List<Resource.UsageLimit> UsageMeters { get; set; }

        public Dictionary<string, string> OutputItems { get; set; }

        public Resource.OperationStatus LastOperationStatus { get; set; }

        public string Location { get; set; }

        public string CloudService { get; set; }

        /// <summary>
        /// Creates new instance from AddOn
        /// </summary>
        /// <param name="resource">The add on details</param>
        /// <param name="geoRegion">The add on region</param>
        public WindowsAzureAddOn(Resource resource, string geoRegion, string cloudService)
        {
            Type = resource.Namespace == DataSetType ? DataType : AppServiceType;

            AddOn = resource.Type;

            Name = resource.Name;

            Plan = resource.Plan;

            SchemaVersion = resource.SchemaVersion;

            ETag = resource.ETag;

            State = resource.State;

            UsageMeters = resource.UsageLimits.ToList();

            OutputItems = (Type == AppServiceType) ? new Dictionary<string, string>(resource.OutputItems) :
                new Dictionary<string, string>();

            LastOperationStatus = resource.Status;

            Location = geoRegion;

            CloudService = cloudService;
        }
    }
}
