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
    [Cmdlet(VerbsCommon.Get, "AzDataBoxJobs", DefaultParameterSetName = ListParameterSet), OutputType(typeof(JobResource))]
    public class GetDataBoxJobs : AzureDataBoxCmdletBase
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

        public static string TenantId { get; internal set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public static string SubscriptionId { get; internal set; }

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet)]
        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, ParameterSetName = GetByNameParameterSet)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetByResourceIdParameterSet)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet )]
        public SwitchParameter Completed { get; set; } = false;

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet)]
        public SwitchParameter CompletedWithErrors { get; set; } = false;

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet)]
        public SwitchParameter Cancelled { get; set; } = false;

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet)]
        public SwitchParameter Aborted { get; set; } = false;

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet)]
        public SwitchParameter Detatiled { get; set; } = false;

        public override void ExecuteCmdlet()
        {
            //if (this.IsParameterBound(c => c.ResourceId))
            //{
            //    var resourceIdentifier = new ResourceIdentifier(this.ResourceId);
            //    this.ResourceGroupName = resourceIdentifier.ResourceGroupName;
            //    this.Name = resourceIdentifier.ResourceName;
            //}

            // Initializes a new instance of the DataBoxManagementClient class.

            this.DataBoxManagementClient.SubscriptionId = SubscriptionId;
            if (Name != null && string.IsNullOrWhiteSpace(Name))
            {
                throw new PSArgumentNullException("Name");
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
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
                IPage<JobResource> jobPageList = null;
                List<JobResource> result = new List<JobResource>();
                
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

                    
                    if (Completed || Cancelled || Aborted || CompletedWithErrors)
                    {
                        foreach (var job in jobPageList)
                        {
                            if ((Completed && job.Status == StageName.Completed) 
                                || (Cancelled && job.Status == StageName.Cancelled) 
                                || (Aborted && job.Status == StageName.Aborted)
                                || (CompletedWithErrors && job.Status == StageName.CompletedWithErrors))
                            {
                                result.Add(job);
                            }
                        }
                    }
                    else
                    {
                        result.AddRange(jobPageList.ToList());
                    }

                } while (!(string.IsNullOrEmpty(jobPageList.NextPageLink)));
                WriteObject(result, true);
            }
            else
            {
                WriteObject("asdjfkl");
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
                    if (Completed || Cancelled || Aborted || CompletedWithErrors)
                    {
                        foreach (var job in jobPageList)
                        {
                            if ((Completed && job.Status == StageName.Completed) 
                                || (Cancelled && job.Status == StageName.Cancelled) 
                                || (Aborted && job.Status == StageName.Aborted)
                                || (CompletedWithErrors && job.Status == StageName.CompletedWithErrors))
                            {
                                result.Add(job);
                            }
                        }
                    }
                    else
                    {

                        result.AddRange(jobPageList.ToList());
                    }

                } while (!(string.IsNullOrEmpty(jobPageList.NextPageLink)));

                WriteObject(result, true);
            }
        }
    }


}
