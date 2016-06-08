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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Model
{
    public class StorageServicePropertiesOperationContext : StorageServiceOperationContext
    {
        public string StorageAccountDescription { get; set; }

        public string AffinityGroup { get; set; }

        public string Location { get; set; }

        public string GeoPrimaryLocation { get; set; }

        public string GeoSecondaryLocation { get; set; } 

        public string Label { get; set; }

        public string StorageAccountStatus { get; set; }

        public string StatusOfPrimary { get; set; }

        public string StatusOfSecondary { get; set; }

        public IEnumerable<string> Endpoints { get; set; }

        public string AccountType { get; set; }

        public DateTime? LastGeoFailoverTime { get; set; }

        public string MigrationState { get; set; }
    }
}
