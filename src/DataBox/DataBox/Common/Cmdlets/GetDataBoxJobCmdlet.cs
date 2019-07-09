using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;
using System.Linq;
using Microsoft.Azure.Commands.DataBox.Common;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Rest.Azure;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Threading;

namespace Microsoft.Azure.Commands.DataBox.Common
{
    [Cmdlet(VerbsCommon.Get, ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataBoxJob", DefaultParameterSetName = ListParameterSet), OutputType(typeof(PSDataBoxJob))]
    public class GetDataBoxJob : AzureDataBoxCmdletBase
    {
        private const string ListParameterSet = "ListParameterSet";
        private const string GetByNameParameterSet = "GetByNameParameterSet";
        private const string GetByResourceIdParameterSet = "GetByResourceIdParameterSet";

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
        public SwitchParameter CompletedWithError { get; set; } = false;

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet)]
        public SwitchParameter Cancelled { get; set; } = false;

        [Parameter(Mandatory = false, ParameterSetName = ListParameterSet)]
        public SwitchParameter Aborted { get; set; } = false;

        public override void ExecuteCmdlet()
        {
            if (this.ParameterSetName.Equals("GetByResourceIdParameterSet"))
            {
                this.ResourceGroupName = ResourceIdHandler.GetResourceGroupName(ResourceId);
                this.Name = ResourceIdHandler.GetResourceName(ResourceId);
            }

            if (!string.IsNullOrEmpty(this.Name))
            {
                List<PSDataBoxJob> result = new List<PSDataBoxJob>();
                result.Add(new PSDataBoxJob(JobsOperationsExtensions.Get(
                                this.DataBoxManagementClient.Jobs,
                                this.ResourceGroupName,
                                this.Name,
                                "details")));
                WriteObject(result,true);
               
            }
            else if (!string.IsNullOrEmpty(this.ResourceGroupName))
            {
                IPage<JobResource> jobPageList = null;
                List<JobResource> result = new List<JobResource>();
                List<PSDataBoxJob> finalResult = new List<PSDataBoxJob>();
                
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

                    if (Completed || Cancelled || Aborted || CompletedWithError)
                    {
                        foreach (var job in jobPageList)
                        {
                            if ((Completed && job.Status == StageName.Completed) 
                                || (Cancelled && job.Status == StageName.Cancelled) 
                                || (Aborted && job.Status == StageName.Aborted)
                                || (CompletedWithError && job.Status == StageName.CompletedWithErrors))
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

                foreach(var job in result)
                {
                    finalResult.Add(new PSDataBoxJob(job));
                }
                WriteObject(finalResult, true);
            }
            else
            {

                 IPage<JobResource> jobPageList = null;
                 List<JobResource> result = new List<JobResource>();
                 List<PSDataBoxJob> finalResult = new List<PSDataBoxJob>();

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
                    if (Completed || Cancelled || Aborted || CompletedWithError)
                    {
                        foreach (var job in jobPageList)
                        {
                            if ((Completed && job.Status == StageName.Completed) 
                                || (Cancelled && job.Status == StageName.Cancelled) 
                                || (Aborted && job.Status == StageName.Aborted)
                                || (CompletedWithError && job.Status == StageName.CompletedWithErrors))
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

                foreach (var job in result)
                {
                    finalResult.Add(new PSDataBoxJob(job));
                }
                WriteObject(finalResult, true);
            }
        }
    }
}
