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

using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;

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

            var runFilters = new RunFilterParameters()
            {
                LastUpdatedAfter = pipelineRunFilter.LastUpdatedAfter,
                LastUpdatedBefore = pipelineRunFilter.LastUpdatedBefore,
                Filters = new List<RunQueryFilter>(),
                OrderBy = new List<RunQueryOrderBy>(),
            };

            if (pipelineRunFilter.PipelineName != null)
            {
                runFilters.Filters.Add(
                    new RunQueryFilter()
                    {
                        Operand = RunQueryFilterOperand.PipelineName,
                        OperatorProperty = RunQueryFilterOperator.Equals,
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
                    new RunQueryOrderBy()
                    {
                        Order = RunQueryOrder.DESC,
                        OrderBy = RunQueryOrderByField.RunEnd
                    });
            }

            PipelineRunsQueryResponse response = this.DataFactoryManagementClient.PipelineRuns.QueryByFactory(pipelineRunFilter.ResourceGroupName, pipelineRunFilter.DataFactoryName, runFilters);

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
            var runFilters = new RunFilterParameters()
            {
                LastUpdatedAfter = triggerRunFilter.TriggerRunStartedAfter,
                LastUpdatedBefore = triggerRunFilter.TriggerRunStartedBefore,
                Filters = new List<RunQueryFilter>(),
                OrderBy = new List<RunQueryOrderBy>(),
            };

            if (triggerRunFilter.TriggerName != null)
            {
                runFilters.Filters.Add(
                    new RunQueryFilter()
                    {
                        Operand = RunQueryFilterOperand.TriggerName,
                        OperatorProperty = RunQueryFilterOperator.Equals,
                        Values = new List<string>() { triggerRunFilter.TriggerName }
                    });
            }

            TriggerRunsQueryResponse response = this.DataFactoryManagementClient.TriggerRuns.QueryByFactory(
                    triggerRunFilter.ResourceGroupName,
                    triggerRunFilter.DataFactoryName,
                    runFilters);

            triggerRuns.AddRange(response.Value.Select(tr =>
                 new PSTriggerRun(tr, triggerRunFilter.ResourceGroupName, triggerRunFilter.DataFactoryName)));

            string continuationToken = response.ContinuationToken;
            while (!string.IsNullOrWhiteSpace(continuationToken))
            {
                runFilters.ContinuationToken = continuationToken;
                response = this.DataFactoryManagementClient.TriggerRuns.QueryByFactory(triggerRunFilter.ResourceGroupName,
                    triggerRunFilter.DataFactoryName, runFilters);

                triggerRuns.AddRange(response.Value.Select(tr =>
                     new PSTriggerRun(tr, triggerRunFilter.ResourceGroupName, triggerRunFilter.DataFactoryName)));

                continuationToken = response.ContinuationToken;
            }
            return triggerRuns;
        }

        public virtual List<PSActivityRun> ListActivityRuns(ActivityRunFilterOptions activityRunFilter)
        {
            List<PSActivityRun> activityRuns = new List<PSActivityRun>();
            var runFilters = new RunFilterParameters()
            {
                LastUpdatedAfter = activityRunFilter.RunStartedAfter,
                LastUpdatedBefore = activityRunFilter.RunStartedBefore,
                Filters = new List<RunQueryFilter>(),
                OrderBy = new List<RunQueryOrderBy>(),
            };

            if (activityRunFilter.ActivityName != null)
            {
                runFilters.Filters.Add(
                    new RunQueryFilter()
                    {
                        Operand = RunQueryFilterOperand.ActivityName,
                        OperatorProperty = RunQueryFilterOperator.Equals,
                        Values = new List<string>() { activityRunFilter.ActivityName }
                    });
            }
            if (activityRunFilter.Status != null)
            {
                runFilters.Filters.Add(
                    new RunQueryFilter()
                    {
                        Operand = RunQueryFilterOperand.Status,
                        OperatorProperty = RunQueryFilterOperator.Equals,
                        Values = new List<string>() { activityRunFilter.Status }
                    });
            }
            ActivityRunsQueryResponse response = this.DataFactoryManagementClient.ActivityRuns.QueryByPipelineRun(
                    activityRunFilter.ResourceGroupName,
                    activityRunFilter.DataFactoryName,
                    activityRunFilter.PipelineRunId,
                    runFilters);

            activityRuns.AddRange(response.Value.Select(ar => 
                 new PSActivityRun(ar, activityRunFilter.ResourceGroupName, activityRunFilter.DataFactoryName)));

            string continuationToken = response.ContinuationToken;
            while (!string.IsNullOrWhiteSpace(continuationToken))
            {
                runFilters.ContinuationToken = continuationToken;
                response = this.DataFactoryManagementClient.ActivityRuns.QueryByPipelineRun(activityRunFilter.ResourceGroupName,
                    activityRunFilter.DataFactoryName, activityRunFilter.PipelineRunId, runFilters);

                activityRuns.AddRange(response.Value.Select(ar =>
                     new PSActivityRun(ar, activityRunFilter.ResourceGroupName, activityRunFilter.DataFactoryName)));

                continuationToken = response.ContinuationToken;
            }
            return activityRuns;
        }
    }
}