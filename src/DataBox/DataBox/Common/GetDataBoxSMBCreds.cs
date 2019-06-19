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
    [Cmdlet(VerbsCommon.Get, "AzDataBoxSMBCreds"), OutputType(typeof(List<DataBoxSMBCredentials>))]

    public class GetDataBoxSMBCreds : AzureDataBoxCmdletBase
    {
        public static string TenantId { get; internal set; }



        public static List<DataBoxSMBCredentials> Credentials;

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
            Credentials = new List<DataBoxSMBCredentials>();

            this.DataBoxManagementClient.SubscriptionId = this.SubscriptionId;
            if (Name != null && string.IsNullOrWhiteSpace(Name))
            {
                throw new PSArgumentNullException("Name");
            }

            string sku = JobsOperationsExtensions.Get(DataBoxManagementClient.Jobs, ResourceGroupName, Name, "details").Sku.Name.ToString();

            IEnumerable<UnencryptedCredentials> result = DataBoxManagementClient.Jobs.ListCredentials(ResourceGroupName, Name);

            
            if (sku.Equals("DataBox"))
            {
                DataboxJobSecrets secrets = result.ToList()[0].JobSecrets as DataboxJobSecrets;
                //WriteObject(secrets);
                foreach (var obj in secrets.PodSecrets[0].AccountCredentialDetails[0].ShareCredentialDetails)
                {
                    Credentials.Add(new DataBoxSMBCredentials(obj.ShareName, obj.UserName , obj.Password));
                }
            }
            else
            {
                DataBoxHeavyJobSecrets secrets = result.ToList()[0].JobSecrets as DataBoxHeavyJobSecrets;
                foreach (var obj in secrets.CabinetPodSecrets[0].AccountCredentialDetails[0].ShareCredentialDetails)
                {
                    Credentials.Add(new DataBoxSMBCredentials(obj.ShareName, obj.UserName, obj.Password));
                }
            }

            WriteObject(Credentials);
        }
    }

    public class DataBoxSMBCredentials
    {
        public string shareName { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public DataBoxSMBCredentials(string shareName, string username, string password)
        {
            this.shareName = shareName;
            this.username = username;
            this.password = password;
        }
    }
}
    

