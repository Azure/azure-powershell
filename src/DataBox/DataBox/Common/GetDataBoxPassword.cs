using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.DataBox.Common;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Threading;

namespace Microsoft.Azure.Commands.DataBox.Common
{
    [Cmdlet(VerbsCommon.Get, "AzDataBoxPassword"), OutputType(typeof(IEnumerable<UnencryptedCredentials>))]
    public class GetDataBoxPassword : AzureDataBoxCmdletBase
    {
        public static string TenantId { get; internal set; }

        

        public static List<DataBoxCredentials> Credentials;

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string SubscriptionId { get; internal set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public override void ExecuteCmdlet()
        {
            //if (this.IsParameterBound(c => c.ResourceId))
            //{
            //    var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
            //    this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            //    this.Name = resourceIdentifier.ResourceName;
            //}

            // Initializes a new instance of the DataBoxManagementClient class.
            Credentials = new List<DataBoxCredentials>();

            this.DataBoxManagementClient.SubscriptionId = this.SubscriptionId;
            if (Name != null && string.IsNullOrWhiteSpace(Name))
            {
                throw new PSArgumentNullException("Name");
            }

            string sku = JobsOperationsExtensions.Get(DataBoxManagementClient.Jobs, ResourceGroupName, Name, "details").Sku.Name.ToString();

            IEnumerable<UnencryptedCredentials> result = DataBoxManagementClient.Jobs.ListCredentials(ResourceGroupName, Name);

            if (sku.Equals("DataBoxDisk"))
            {
                DataBoxDiskJobSecrets secrets = result.ToList()[0].JobSecrets as DataBoxDiskJobSecrets;
                foreach (var obj in secrets.DiskSecrets)
                {
                    Credentials.Add(new DataBoxCredentials(obj.DiskSerialNumber, obj.BitLockerKey));
                }
            }
            else if (sku.Equals("DataBox"))
            {
                DataboxJobSecrets secrets = result.ToList()[0].JobSecrets as DataboxJobSecrets;
                foreach (var obj in secrets.PodSecrets)
                {
                    Credentials.Add(new DataBoxCredentials(obj.DeviceSerialNumber, obj.DevicePassword));
                }
            }
            else
            {
                DataBoxHeavyJobSecrets secrets = result.ToList()[0].JobSecrets as DataBoxHeavyJobSecrets;
                foreach (var obj in secrets.CabinetPodSecrets)
                {
                    Credentials.Add(new DataBoxCredentials(obj.DeviceSerialNumber, obj.DevicePassword));
                }
            }
            
            WriteObject(Credentials);
        }
    }

    public class DataBoxCredentials
    {
        public string serialNo { get; set; }
        public string password { get; set; }

        public DataBoxCredentials(string serialNo, string password)
        {
            this.serialNo = serialNo;
            this.password = password;
        }
    }
}
