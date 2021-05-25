using Microsoft.Azure.Management.OperationalInsights.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSDataExport
    {
        public string Name { get; set; }//for creation only - same as table name
        public string Id { get; set; }// TODO add this to all ARM resources i added
        public  string Type { get; set; }// TODO add this to all ARM resources i added

        //Add resource group , subscriptionId already oob in PSH
        //workspaceName

        public string DataExportId { get; set; } //read only property

        public IList<string> TableNames { get; set; } //for create+update

        public string ResourceId { get; set; } //for create+update

        public string DataExportType { get; }  //type of destination in swagger not the tyupe of the actual resource //read only property

        public string EventHubName { get; set; } // optional

        public bool? Enable { get; set; } //true by default - can be passed as null and translatted to true on backend

        public string CreatedDate { get; set; }//read only property

        public string LastModifiedDate { get; set; }//read only property

        public PSDataExport() 
        { 
            //TODO dabenham add constructor with all parameters manually
        }


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
