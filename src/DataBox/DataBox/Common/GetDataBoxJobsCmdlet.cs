using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.DataBox.Common;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Rest.Azure;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;
using System.Threading;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace MMicrosoft.Azure.Commands.DataBox.Common
{
    [Cmdlet(VerbsCommon.Get, "AzDataBoxJobs", DefaultParameterSetName = ListParameterSet)]//, OutputType(typeof(IList<JobResource>))]
    public class GetDataBoxJobs : AzureDataBoxCmdletBase
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        public static string TenantId { get; internal set; }
        public static string SubscriptionId { get; internal set; }

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        public override void ExecuteCmdlet()
        {
            /*if (this.IsParameterBound(c => c.ResourceId))
            {
                var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
                this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
                this.Name = resourceIdentifier.ResourceName;
            }*/

            // Initializes a new instance of the DataBoxManagementClient class.
            //DataBoxManagementClient dataBoxManagementClient = InitializeDataBoxClient();
            this.DataBoxManagementClient.SubscriptionId = "05b5dd1c-793d-41de-be9f-6f9ed142f695";
            if (Name != null && string.IsNullOrWhiteSpace(Name))
            {
                throw new PSArgumentNullException("Name");
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                WriteObject("Getting the job with specified name...");
                List<JobResource> result = new List<JobResource>();
                result.Add(JobsOperationsExtensions.Get(
                                this.DataBoxManagementClient.Jobs,
                                this.ResourceGroupName,
                                this.Name,
                                "details"));
                WriteObject(result);
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                WriteObject("Getting all the jobs under the specified resource group...");
                IPage<JobResource> jobPageList = null;
                List<JobResource> result = new List<JobResource>();
                //var result = this.MySDKClient.TopLevelResource.ListByResourceGroup(this.ResourceGroupName).Select(r => new PSTopLevelResource(r));
                
                do
                {
                    // Lists all the jobs available under resource group.
                    if (jobPageList == null)
                    {
                        jobPageList = JobsOperationsExtensions.ListByResourceGroup(
                                        this.DataBoxManagementClient.Jobs,
                                        this.ResourceGroupName);
                    }
                    else
                    {
                        jobPageList = JobsOperationsExtensions.ListByResourceGroupNext(
                                        this.DataBoxManagementClient.Jobs,
                                        jobPageList.NextPageLink);
                    }

                    result.AddRange(jobPageList.ToList());

                } while (!(string.IsNullOrEmpty(jobPageList.NextPageLink)));
                WriteObject(result, true);
            }
            else
            {
                WriteObject("Getting all the jobs...");

                //var result = this.DataBoxManagementClient.Jobs.List().Select(r => new PSTopLevelResource(r));
                //var result = this.DataBoxManagementClient.Jobs.List().ToArray();
                //DataBoxManagementClient dataBoxManagementClient = InitializeDataBoxClient();
                //var result = dataBoxManagementClient.Jobs.List().ToList();
                //WriteObject(result.Count.ToString());
                
                //WriteObject(this.DataBoxManagementClient.SubscriptionId.ToString());
                //WriteObject(this.DataBoxManagementClient.Jobs.List().Count());
                 IPage<JobResource> jobPageList = null;
                 List<JobResource> result = new List<JobResource>();

                 do
                 {
                     // Lists all the jobs available under the subscription.
                     if (jobPageList == null)
                     {
                         jobPageList = JobsOperationsExtensions.List(
                                         this.DataBoxManagementClient.Jobs);
                     }
                     else
                     {
                         jobPageList = JobsOperationsExtensions.ListNext(
                                         this.DataBoxManagementClient.Jobs,
                                         jobPageList.NextPageLink);
                     }

                    // WriteObject(jobPageList.ToList());
                     result.AddRange(jobPageList.ToList());

                 } while (!(string.IsNullOrEmpty(jobPageList.NextPageLink)));
                 foreach (var job in result)
                 {
                     WriteObject("Name : " + job.Name + "\t Status : " + job.Status);
                 }
                WriteObject("Total No of Jobs : " + result.Count);
                //WriteObject(result, true);
            }
           // WriteObject("Finished Executing Cmdlet");
        }

        private static DataBoxManagementClient InitializeDataBoxClient()
        {
            const string prodAuthenticationEndpoint = "https://login.windows.net/";
            const string prodAzureServiceEndpoint = "https://management.core.windows.net/";
            SynchronizationContext.SetSynchronizationContext(new SynchronizationContext());

            TenantId = "72f988bf-86f1-41af-91ab-2d7cd011db47";
            SubscriptionId = "05b5dd1c-793d-41de-be9f-6f9ed142f695";

            ServiceClientCredentials creds = UserTokenProvider.LoginByDeviceCodeAsync(
                "1950a258-227b-4e31-a9cf-717495945fc2", TenantId, new ActiveDirectoryServiceSettings
                {
                    AuthenticationEndpoint = new Uri(prodAuthenticationEndpoint),
                    TokenAudience = new Uri(prodAzureServiceEndpoint),
                    ValidateAuthority = true
                }, DisplayDeviceCode).GetAwaiter().GetResult();

            var dataBoxManagementClient = new DataBoxManagementClient(creds)
            {
                SubscriptionId = SubscriptionId
            };

            return dataBoxManagementClient;
        }

        private static bool DisplayDeviceCode(DeviceCodeResult a)
        {
            Console.WriteLine($"Go to URL - {a.VerificationUrl} and enter code {a.UserCode}");
            return true;
        }
    }

}
