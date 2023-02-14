// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSDataExport
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public  string Type { get; set; }

        public string DataExportId { get; set; }

        public List<string> TableNames { get; set; }

        public string ResourceId { get; set; }//Destination Resource Id

        public string DataExportType { get; }

        public string EventHubName { get; set; }

        public bool? Enable { get; set; }

        public string CreatedDate { get; set; }

        public string LastModifiedDate { get; set; }

        public PSDataExport(DataExport dataExport)
        {
            if (dataExport == null)
            {
                throw new ArgumentNullException("dataExport");
            }
            DataExportId = dataExport.DataExportId;
            TableNames = dataExport.TableNames as List<string>;
            ResourceId = dataExport.ResourceId;
            DataExportType = dataExport.DataExportType;
            EventHubName = dataExport.EventHubName;
            Enable = dataExport.Enable;
            CreatedDate = dataExport.CreatedDate;
            LastModifiedDate = dataExport.LastModifiedDate;
            Name = dataExport.Name;
            Id = dataExport.Id;
            Type = dataExport.Type;
        }


        public static DataExport getDataExport(CreatePSDataExportParameters parameters)
        {
            return new DataExport(
                tableNames: parameters.TableNames,
                resourceId: parameters.DestinationResourceId,
                eventHubName: parameters.EventHubName,
                enable: parameters.Enable);
        }

    }
}
