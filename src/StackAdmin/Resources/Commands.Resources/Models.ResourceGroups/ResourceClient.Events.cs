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

// TODO: http://vstfrd:8080/Azure/RD/_workitems#_a=edit&id=3247094
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.Azure.Management.Resources;
//using Microsoft.Azure.Management.Resources.Models;
//using ProjectResources = Microsoft.Azure.Commands.Resources.Properties.Resources;
//using Microsoft.Azure.Insights.Models;
//using Microsoft.Azure.Insights;

//namespace Microsoft.Azure.Commands.Resources.Models
//{
//    public partial class ResourcesClient
//    {
//        private const int EventRetentionPeriod = 89;

//        /// <summary>
//        /// Gets event logs.
//        /// </summary>
//        /// <param name="parameters">Input parameters</param>
//        /// <returns>Logs.</returns>
//        public virtual IEnumerable<PSDeploymentEventData> GetResourceGroupLogs(GetPSResourceGroupLogParameters parameters)
//        {
//            if (parameters.All)
//            {
//                EventDataListResponse listOfEvents =
//                    EventsClient.EventData.ListEventsForResourceGroup(new ListEventsForResourceGroupParameters
//                        {
//                            ResourceGroupName = parameters.Name,
//                            StartTime = DateTime.UtcNow - TimeSpan.FromDays(EventRetentionPeriod),
//                            EndTime = DateTime.UtcNow
//                        });
//                return listOfEvents.EventDataCollection.Value.Select(e => e.ToPSDeploymentEventData());
//            }
//            else if (!string.IsNullOrEmpty(parameters.DeploymentName))
//            {
//                DeploymentGetResult deploymentGetResult;
//                try
//                {
//                    deploymentGetResult = ResourceManagementClient.Deployments.Get(parameters.Name,
//                                                                                   parameters.DeploymentName);
//                }
//                catch
//                {
//                    throw new ArgumentException(string.Format(ProjectResources.DeploymentWithNameNotFound, parameters.DeploymentName));
//                }

//                return GetDeploymentLogs(deploymentGetResult.Deployment.Properties.CorrelationId);
//            }
//            else
//            {
//                DeploymentListResult deploymentListResult;
//                try
//                {
//                    deploymentListResult = ResourceManagementClient.Deployments.List(parameters.Name,
//                        new DeploymentListParameters
//                        {
//                            Top = 1
//                        });
//                    if (deploymentListResult.Deployments.Count == 0)
//                    {
//                        throw new ArgumentException(string.Format(ProjectResources.NoDeploymentWereFound, parameters.Name));
//                    }
//                }
//                catch
//                {
//                    throw new ArgumentException(string.Format(ProjectResources.NoDeploymentWereFound, parameters.Name));
//                }

//                return GetDeploymentLogs(deploymentListResult.Deployments[0].Properties.CorrelationId);
//            }
//        }

//        /// <summary>
//        /// Gets event logs by tracking Id.
//        /// </summary>
//        /// <param name="correlationId">CorrelationId Id of the deployment</param>
//        /// <returns>Logs.</returns>
//        public virtual IEnumerable<PSDeploymentEventData> GetDeploymentLogs(string correlationId)
//        {
//            EventDataListResponse listOfEvents = EventsClient.EventData.ListEventsForCorrelationId(new ListEventsForCorrelationIdParameters
//                {
//                    CorrelationId = correlationId,
//                    StartTime = DateTime.UtcNow - TimeSpan.FromDays(EventRetentionPeriod),
//                    EndTime = DateTime.UtcNow
//                });
//            return listOfEvents.EventDataCollection.Value.Select(e => e.ToPSDeploymentEventData());
//        }
//    }
//}