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

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public partial class DataFactoryClient
    {
        public virtual PSPipelineRun GetPipelineRun(string resourceGroup, string datafactoryName, string pipelineRunId)
        {
            PipelineRun pipelineRun = this.DataFactoryManagementClient.PipelineRuns.Get(resourceGroup, datafactoryName, pipelineRunId);
            return new PSPipelineRun(pipelineRun, resourceGroup, datafactoryName);
        }

        public virtual List<PSPipelineRun> ListPipelineRuns(PipelineRunFilterOptions pipelineRunFilter)
        {
            var pipelineRuns = new List<PSPipelineRun>();

            var runFilters = new PipelineRunFilterParameters()
            {
                LastUpdatedAfter = pipelineRunFilter.LastUpdatedAfter,
                LastUpdatedBefore = pipelineRunFilter.LastUpdatedBefore,
                Filters = new List<PipelineRunQueryFilter>(),
                OrderBy = new List<PipelineRunQueryOrderBy>(),
            };

            if (pipelineRunFilter.PipelineName != null)
            {
                runFilters.Filters.Add(
                    new PipelineRunQueryFilter()
                    {
                        Operand = PipelineRunQueryFilterOperand.PipelineName,
                        OperatorProperty = PipelineRunQueryFilterOperator.Equals,
                        Values = new List<string>() { pipelineRunFilter.PipelineName }
                    });
            }
            else if (pipelineRunFilter.Filters != null)
            {
                runFilters.Filters = pipelineRunFilter.Filters;
            }

            if (pipelineRunFilter.OrderBy != null)
            {
                runFilters.OrderBy = pipelineRunFilter.OrderBy;
            }
            else
            {
                runFilters.OrderBy.Add(
                    new PipelineRunQueryOrderBy()
                    {
                        Order = PipelineRunQueryOrder.DESC,
                        OrderBy = PipelineRunQueryOrderByField.RunEnd
                    });
            }

            PipelineRunQueryResponse response = this.DataFactoryManagementClient.PipelineRuns.QueryByFactory(pipelineRunFilter.ResourceGroupName, pipelineRunFilter.DataFactoryName, runFilters);

            pipelineRuns.AddRange(response.Value.Select(pr =>
                 new PSPipelineRun(pr, pipelineRunFilter.ResourceGroupName, pipelineRunFilter.DataFactoryName)));

            string continuationToken = response.ContinuationToken;
            while (!string.IsNullOrWhiteSpace(continuationToken))
            {
                runFilters.ContinuationToken = continuationToken;
                response = this.DataFactoryManagementClient.PipelineRuns.QueryByFactory(pipelineRunFilter.ResourceGroupName, pipelineRunFilter.DataFactoryName, runFilters);

                pipelineRuns.AddRange(response.Value.Select(pr =>
                     new PSPipelineRun(pr, pipelineRunFilter.ResourceGroupName, pipelineRunFilter.DataFactoryName)));

                continuationToken = response.ContinuationToken;
            }
            return pipelineRuns;
        }

        public virtual List<PSTriggerRun> ListTriggerRuns(TriggerRunFilterOptions triggerRunFilter)
        {
            List<PSTriggerRun> triggerRuns = new List<PSTriggerRun>();
            IPage<TriggerRun> response = this.DataFactoryManagementClient.Triggers.ListRuns(
                    triggerRunFilter.ResourceGroupName,
                    triggerRunFilter.DataFactoryName,
                    triggerRunFilter.TriggerName,
                    triggerRunFilter.TriggerRunStartedAfter,
                    triggerRunFilter.TriggerRunStartedBefore);

            triggerRuns.AddRange(response.Select(tr =>
                 new PSTriggerRun(tr, triggerRunFilter.ResourceGroupName, triggerRunFilter.DataFactoryName)));

            string nextLink = response.NextPageLink;
            while (nextLink.IsNextPageLink())
            {
                response = this.DataFactoryManagementClient.Triggers.ListRunsNext(nextLink);
                triggerRuns.AddRange(response.Select(tr =>
                     new PSTriggerRun(tr, triggerRunFilter.ResourceGroupName, triggerRunFilter.DataFactoryName)));
                nextLink = response.NextPageLink;
            }
            return triggerRuns;
        }

        public virtual List<PSActivityRun> ListActivityRuns(ActivityRunFilterOptions activityRunFilter)
        {
            List<PSActivityRun> activityRuns = new List<PSActivityRun>();
            IPage<ActivityRun> response = this.DataFactoryManagementClient.ActivityRuns.ListByPipelineRun(
                    activityRunFilter.ResourceGroupName,
                    activityRunFilter.DataFactoryName,
                    activityRunFilter.PipelineRunId,
                    activityRunFilter.RunStartedAfter,
                    activityRunFilter.RunStartedBefore,
                    activityRunFilter.Status,
                    activityRunFilter.ActivityName,
                    activityRunFilter.LinkedServiceName);

            activityRuns.AddRange(response.Select(ar => 
                 new PSActivityRun(ar, activityRunFilter.ResourceGroupName, activityRunFilter.DataFactoryName)));

            string nextLink = response.NextPageLink;
            while (nextLink.IsNextPageLink())
            {
                response = this.DataFactoryManagementClient.ActivityRuns.ListByPipelineRunNext(nextLink);
                activityRuns.AddRange(response.Select(ar => 
                     new PSActivityRun(ar, activityRunFilter.ResourceGroupName, activityRunFilter.DataFactoryName)));
                nextLink = response.NextPageLink;
            }
            return activityRuns;
        }
    }
}