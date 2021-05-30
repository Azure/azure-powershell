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

        public IList<string> TableNames { get; set; }

        public string ResourceId { get; set; }

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
            TableNames = dataExport.TableNames;
            ResourceId = dataExport.ResourceId;
            DataExportType = dataExport.DataExportType;
            EventHubName = dataExport.EventHubName;
            Enable = dataExport.Enable;
            CreatedDate = dataExport.CreatedDate;
            LastModifiedDate = dataExport.LastModifiedDate;
            // TOTO dabenham once this will become TrackedResource in the .NET nuget uncomment these
            //Name = dataExport.Name;
            //Id = dataExport.Id;
            //Type = dataExport.Type;
        }


        public static DataExport getDataExport(CreatePSDataExportParameters parameters)
        {
            return new DataExport(
                tableNames: parameters.TableNames,
                resourceId: parameters.ResourceId,
                eventHubName: parameters.EventHubName,
                enable: parameters.Enable);
        }

    }
}
