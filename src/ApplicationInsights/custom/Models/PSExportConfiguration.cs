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

using Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20150501;

namespace Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models
{
    public class PSExportConfiguration
    {
        public string ExportId { get; set; }
        public string StorageName { get; set; }
        public string ContainerName { get; set; }
        public string DocumentTypes { get; set; }
        public string DestinationStorageSubscriptionId { get; set; }
        public string DestinationStorageLocationId { get; set; }
        public string DestinationStorageAccountId { get; set; }
        public string IsEnabled { get; set; }
        public string ExportStatus { get; set; }
        public string LastSuccessTime { get; set; }

        public PSExportConfiguration(ApplicationInsightsComponentExportConfiguration response)
        {
            this.ExportId = response.ExportId;

            this.DocumentTypes = string.Join(", ", Utilities.ConvertToDocumentType(response.RecordType.Split(',')));
            this.DestinationStorageSubscriptionId = response.DestinationStorageSubscriptionId;
            this.DestinationStorageLocationId = response.DestinationStorageLocationId;
            this.DestinationStorageAccountId = response.DestinationAccountId;
            this.IsEnabled = response.IsUserEnabled;
            this.ExportStatus = response.ExportStatus;
            this.StorageName = response.StorageName;
            this.ContainerName = response.ContainerName;
            this.LastSuccessTime = response.LastSuccessTime;
        }
    }

    public class PSExportConfigurationTableView : PSExportConfiguration
    {
        public PSExportConfigurationTableView(ApplicationInsightsComponentExportConfiguration response)
            : base(response)
        { }
    }
}

