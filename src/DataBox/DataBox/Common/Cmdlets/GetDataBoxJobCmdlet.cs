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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.DataBox;
using Microsoft.Azure.Management.DataBox.Models;
using Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

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
