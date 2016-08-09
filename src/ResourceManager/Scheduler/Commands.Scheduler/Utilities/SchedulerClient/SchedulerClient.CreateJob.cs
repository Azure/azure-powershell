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

namespace Microsoft.Azure.Commands.Scheduler.Utilities
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.Azure.Commands.Scheduler.Models;
    using Microsoft.Azure.Commands.Scheduler.Properties;
    using Microsoft.Azure.Management.Scheduler;
    using Microsoft.Azure.Management.Scheduler.Models;
    using PSManagement = System.Management.Automation;

    public partial class SchedulerClient
    {
        /// <summary>
        /// Create a job.
        /// </summary>
        /// <param name="createJobParams">Job properties entered via powershell.</param>
        /// <returns>The Job definition.</returns>
        public PSSchedulerJobDefinition CreateJob(PSJobParams createJobParams)
        {
            if (string.IsNullOrWhiteSpace(createJobParams.ResourceGroupName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "ResourceGroupName");
            }

            if (string.IsNullOrWhiteSpace(createJobParams.JobCollectionName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "JobCollectionName");
            }

            if (string.IsNullOrWhiteSpace(createJobParams.JobName))
            {
                throw new PSManagement.PSArgumentNullException(paramName: "JobName");
            }

            if (!DoesResourceGroupExists(createJobParams.ResourceGroupName))
            {
                throw new PSManagement.PSArgumentException(Resources.SchedulerInvalidResourceGroup);
            }

            IList<JobCollectionDefinition> jobCollection = ListJobCollection(createJobParams.ResourceGroupName, createJobParams.JobCollectionName);

            if (jobCollection == null || jobCollection.Count < 1)
            {
                throw new PSManagement.PSInvalidOperationException(string.Format(Resources.JobCollectionDoesnotExist, createJobParams.JobCollectionName, createJobParams.ResourceGroupName));
            }
            else
            {
                if (JobExists(createJobParams.ResourceGroupName, createJobParams.JobCollectionName, createJobParams.JobName))
                {
                    throw new PSManagement.PSArgumentException(string.Format(Resources.SchedulerExistingJob, createJobParams.JobName, createJobParams.JobCollectionName));
                }

                IList<JobDefinition> listOfJobs = ListJobs(createJobParams.ResourceGroupName, createJobParams.JobCollectionName, jobState: null);

                if (listOfJobs != null)
                {
                    Validate(jobCollection[0], listOfJobs.Count);
                }
            }

            JobAction jobAction = this.GetJobAction(createJobParams);

            JobRecurrence jobRecurrence = this.GetJobRecurrence(createJobParams.JobRecurrence);

            var properties = new JobProperties()
            {
                Action = jobAction,
                Recurrence = jobRecurrence,
                StartTime = createJobParams.StartTime,
                State = createJobParams.JobState.GetValueOrDefaultEnum<JobState?>(defaultValue: null)
            };

            var jobDefinition = new JobDefinition(name: createJobParams.JobName)
            {
                Properties = properties
            };

            JobDefinition jobDefinitionResult =  this.SchedulerManagementClient.Jobs.CreateOrUpdate(createJobParams.ResourceGroupName, createJobParams.JobCollectionName, createJobParams.JobName, jobDefinition);

            return Converter.ConvertJobDefinitionToPS(jobDefinitionResult);
        }

        /// <summary>
        /// Get JobAction instance.
        /// </summary>
        /// <param name="jobParams">Job properties specified via PowerShell.</param>
        /// <returns>JobActio instance.</returns>
        private JobAction GetJobAction(PSJobParams jobParams)
        {
            var jobAction = new JobAction();

            this.PopulateJobAction(jobParams.JobAction, ref jobAction);

            // Populate error job action.
            if (jobParams.JobErrorAction != null)
            {
                var jobErrorAction = new JobErrorAction();
                this.PopulateJobErrorAction(jobParams.JobErrorAction, ref jobErrorAction);
                jobAction.ErrorAction = jobErrorAction;
            }

            return jobAction;
        }

        /// <summary>
        /// Gets job recurrence.
        /// </summary>
        /// <param name="jobRecurrenceParams">Job recurrence properties specified via PowerShell.</param>
        /// <returns>JobRecurrence object.</returns>
        private JobRecurrence GetJobRecurrence(PSJobRecurrenceParams jobRecurrenceParams)
        {
            if (jobRecurrenceParams != null &&
               (jobRecurrenceParams.Interval != null ||
                jobRecurrenceParams.ExecutionCount != null ||
                !string.IsNullOrWhiteSpace(jobRecurrenceParams.Frequency) ||
                jobRecurrenceParams.EndTime != null))
            {
                var jobRecurrence = new JobRecurrence()
                {
                    Count = jobRecurrenceParams.ExecutionCount ?? default(int?),
                    Interval = jobRecurrenceParams.Interval ?? default(int?),
                    EndTime = jobRecurrenceParams.EndTime ?? default(DateTime?),
                    Frequency = jobRecurrenceParams.Frequency.GetValueOrDefaultEnum<RecurrenceFrequency?>(defaultValue: null)
                };

                return jobRecurrence;
            }

            return null;
        }

        /// <summary>
        /// Populate job action values.
        /// </summary>
        /// <param name="jobActionParams">Job action properties specified via PowerShell.</param>
        /// <param name="jobAction">JobAction object to be populated.</param>
        private void PopulateJobAction(PSJobActionParams jobActionParams, ref JobAction jobAction)
        {
            switch (jobActionParams.JobActionType)
            {
                case JobActionType.Http:
                case JobActionType.Https:
                    jobAction.Type = jobActionParams.JobActionType;
                    jobAction.Request = this.GetHttpJobAction(jobActionParams.HttpJobAction);
                    break;

                case JobActionType.StorageQueue:
                    jobAction.Type = JobActionType.StorageQueue;
                    jobAction.QueueMessage = this.GetStorageQueue(jobActionParams.StorageJobAction);
                    break;

                case JobActionType.ServiceBusQueue:
                    jobAction.Type = JobActionType.ServiceBusQueue;
                    jobAction.ServiceBusQueueMessage = this.GetServiceBusQueue(jobActionParams.ServiceBusAction);
                    break;

                case JobActionType.ServiceBusTopic:
                    jobAction.Type = JobActionType.ServiceBusTopic;
                    jobAction.ServiceBusTopicMessage = this.GetServiceBusTopic(jobActionParams.ServiceBusAction);
                    break;
            }
        }

        /// <summary>
        /// Populate job error action values.
        /// </summary>
        /// <param name="jobErrorActionParams">Job error action properties specified via PowerShell.</param>
        /// <param name="jobErrorAction">JobErrorAction object to be populated.</param>
        private void PopulateJobErrorAction(PSJobActionParams jobErrorActionParams, ref JobErrorAction jobErrorAction)
        {
            if (jobErrorActionParams != null)
            {
                if (jobErrorAction == null)
                {
                    jobErrorAction = new JobErrorAction();
                }

                switch (jobErrorActionParams.JobActionType)
                {
                    case JobActionType.Http:
                    case JobActionType.Https:
                        jobErrorAction.Type = jobErrorActionParams.JobActionType;
                        jobErrorAction.Request = this.GetHttpJobAction(jobErrorActionParams.HttpJobAction);
                        break;

                    case JobActionType.StorageQueue:
                        jobErrorAction.Type = JobActionType.StorageQueue;
                        jobErrorAction.QueueMessage = this.GetStorageQueue(jobErrorActionParams.StorageJobAction);
                        break;

                    case JobActionType.ServiceBusQueue:
                        jobErrorAction.Type = JobActionType.ServiceBusQueue;
                        jobErrorAction.ServiceBusQueueMessage = this.GetServiceBusQueue(jobErrorActionParams.ServiceBusAction);
                        break;

                    case JobActionType.ServiceBusTopic:
                        jobErrorAction.Type = JobActionType.ServiceBusTopic;
                        jobErrorAction.ServiceBusTopicMessage = this.GetServiceBusTopic(jobErrorActionParams.ServiceBusAction);
                        break;
                }
            }
            else
            {
                jobErrorAction = null;
            }
        }

        /// <summary>
        /// Gets http job action.
        /// </summary>
        /// <param name="httpActionParams">Http job aciton properties specified via PowerShell.</param>
        /// <returns>HttpRequest object.</returns>
        private HttpRequest GetHttpJobAction(PSHttpJobActionParams httpActionParams)
        {
            if (string.IsNullOrWhiteSpace(httpActionParams.RequestMethod) ||
               httpActionParams.Uri == null)
            {
                throw new PSManagement.PSArgumentException(Resources.SchedulerInvalidHttpRequest);
            }

            var httpRequest = new HttpRequest()
            {
                Method = httpActionParams.RequestMethod,
                Uri = httpActionParams.Uri.ToString(),
                Authentication = this.PopulateHttpAuthentication(httpActionParams.RequestAuthentication)
            };

            if (httpActionParams.RequestHeaders != null)
            {
                httpRequest.Headers = httpActionParams.RequestHeaders.ToDictionary();
            }

            if ((httpActionParams.RequestMethod.Equals(Constants.HttpMethodPOST, StringComparison.InvariantCultureIgnoreCase) ||
                    httpActionParams.RequestMethod.Equals(Constants.HttpMethodPUT, StringComparison.InvariantCultureIgnoreCase)) &&
                    httpActionParams.RequestBody != null)
            {
                if (httpRequest.Headers != null && httpRequest.Headers.ContainsKeyInvariantCultureIgnoreCase("content-type"))
                {
                    httpRequest.Body = httpActionParams.RequestBody;
                }
                else
                {
                    throw new PSManagement.PSArgumentException(Resources.SchedulerNoJobContentType);
                }
            }

            return httpRequest;
        }

        /// <summary>
        /// Get Http job authentication.
        /// </summary>
        /// <param name="authenticationParams">Http authentication properties specified via PowerShell.</param>
        /// <returns>HttpAuthentication object.</returns>
        private HttpAuthentication PopulateHttpAuthentication(PSHttpJobAuthenticationParams authenticationParams)
        {
            if (authenticationParams == null ||
                authenticationParams.HttpAuthType == null ||
                authenticationParams.HttpAuthType.Equals(Constants.HttpAuthenticationNone, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }
            else if (authenticationParams.HttpAuthType.Equals(Constants.HttpAuthenticationClientCertificate, StringComparison.InvariantCultureIgnoreCase))
            {
                if(string.IsNullOrWhiteSpace(authenticationParams.ClientCertPfx) ||
                    string.IsNullOrWhiteSpace(authenticationParams.ClientCertPassword))
                {
                    throw new PSManagement.PSArgumentException(Resources.SchedulerInvalidClientCertAuthRequest);
                }

                var clientCert = new ClientCertAuthentication()
                {
                    Type = HttpAuthenticationType.ClientCertificate,
                    Pfx = authenticationParams.ClientCertPfx,
                    Password = authenticationParams.ClientCertPassword
                };

                return clientCert;
            }
            else if (authenticationParams.HttpAuthType.Equals(Constants.HttpAuthenticationActiveDirectoryOAuth, StringComparison.InvariantCultureIgnoreCase))
            {
                if (string.IsNullOrWhiteSpace(authenticationParams.Tenant) ||
                    string.IsNullOrWhiteSpace(authenticationParams.ClientId) ||
                    string.IsNullOrWhiteSpace(authenticationParams.Secret) ||
                    string.IsNullOrWhiteSpace(authenticationParams.Audience))
                {
                    throw new PSManagement.PSArgumentException(Resources.SchedulerInvalidActiveDirectoryOAuthRequest);
                }

                var adOAuth = new OAuthAuthentication()
                {
                    Type = HttpAuthenticationType.ActiveDirectoryOAuth,
                    Audience = authenticationParams.Audience,
                    ClientId = authenticationParams.ClientId,
                    Secret = authenticationParams.Secret,
                    Tenant = authenticationParams.Tenant
                };

                return adOAuth;
            }
            else if (authenticationParams.HttpAuthType.Equals(Constants.HttpAuthenticationBasic, StringComparison.InvariantCultureIgnoreCase))
            {
                if(string.IsNullOrWhiteSpace(authenticationParams.Username) ||
                   string.IsNullOrWhiteSpace(authenticationParams.Password))
                {
                    throw new PSManagement.PSArgumentException(Resources.SchedulerInvalidBasicRequest);
                }

                var basic = new BasicAuthentication()
                {
                    Type = HttpAuthenticationType.Basic,
                    Username = authenticationParams.Username,
                    Password = authenticationParams.Password
                };

                return basic;
            }
            else
            {
                throw new PSManagement.PSArgumentException(Resources.SchedulerInvalidAuthenticationType);
            }
        }

        /// <summary>
        /// Gets storage queue.
        /// </summary>
        /// <param name="storageActionParams">Storage queue action propertis specified via PowerShell.</param>
        /// <returns>StorageQueueMessage object.</returns>
        private StorageQueueMessage GetStorageQueue(PSStorageJobActionParams storageActionParams)
        {
            if (string.IsNullOrWhiteSpace(storageActionParams.StorageAccount) ||
                string.IsNullOrWhiteSpace(storageActionParams.StorageQueueMessage) ||
                string.IsNullOrWhiteSpace(storageActionParams.StorageQueueName) ||
                string.IsNullOrWhiteSpace(storageActionParams.StorageSasToken))
            {
                throw new PSManagement.PSArgumentException(Resources.SchedulerInvalidStorageQueue);
            }

            var storageQueue = new StorageQueueMessage()
            {
                Message = storageActionParams.StorageQueueMessage,
                QueueName = storageActionParams.StorageQueueName,
                SasToken = storageActionParams.StorageSasToken,
                StorageAccount = storageActionParams.StorageAccount,
            };

            return storageQueue;
        }

        /// <summary>
        /// Gets Service bus queue.
        /// </summary>
        /// <param name="serviceBusQueueActionParams">Service bus queue action propertis specified via PowerShell.</param>
        /// <returns>serviceBusQueueMessage object.</returns>
        private ServiceBusQueueMessage GetServiceBusQueue(PSServiceBusParams serviceBusQueueActionParams)
        {
            if (string.IsNullOrWhiteSpace(serviceBusQueueActionParams.QueueName))
            {
                throw new PSManagement.PSArgumentException(Resources.SchedulerInvalidServiceBusQueueName);
            }

            var serviceBusQueueMessage = new ServiceBusQueueMessage()
            {
                QueueName = serviceBusQueueActionParams.QueueName
            };

            this.PopulateServiceBusMessage(serviceBusQueueActionParams, serviceBusQueueMessage);

            return serviceBusQueueMessage;
        }

        /// <summary>
        /// Get Service bus topic.
        /// </summary>
        /// <param name="serviceBusQueueActionParams">Servie bus properities specified via PowerShell.</param>
        /// <returns>ServiceBusTopicMessage object.</returns>
        private ServiceBusTopicMessage GetServiceBusTopic(PSServiceBusParams serviceBusQueueActionParams)
        {
            if (string.IsNullOrWhiteSpace(serviceBusQueueActionParams.TopicPath))
            {
                throw new PSManagement.PSArgumentException(Resources.SchedulerInvalidServiceBusTopicPath);
            }

            var serviceBusTopicMessage = new ServiceBusTopicMessage()
            {
                TopicPath = serviceBusQueueActionParams.TopicPath
            };

            this.PopulateServiceBusMessage(serviceBusQueueActionParams, serviceBusTopicMessage);

            return serviceBusTopicMessage;
        }

        /// <summary>
        /// Populates Service bus message object with valid values.
        /// </summary>
        /// <param name="serviceBusQueueActionParams">Service bus properties specified via PowerShell.</param>
        /// <param name="serviceBusMessage">Servce message object to be populated.</param>
        private void PopulateServiceBusMessage(PSServiceBusParams serviceBusQueueActionParams, ServiceBusMessage serviceBusMessage)
        {
            if (string.IsNullOrWhiteSpace(serviceBusQueueActionParams.NamespaceProperty) ||
                string.IsNullOrWhiteSpace(serviceBusQueueActionParams.Message) ||
                string.IsNullOrWhiteSpace(serviceBusQueueActionParams.TransportType))
            {
                throw new PSManagement.PSArgumentException(Resources.SchedulerInvalidServiceBus);
            }

            if (serviceBusMessage == null)
            {
                throw new ArgumentException("serviceBusMessage: Object must be initialized");
            }

            ServiceBusAuthentication authentication = this.GetServiceBusAuthentication(serviceBusQueueActionParams.Authentication);

            serviceBusMessage.Authentication = this.GetServiceBusAuthentication(serviceBusQueueActionParams.Authentication);
            serviceBusMessage.Message = serviceBusQueueActionParams.Message;
            serviceBusMessage.NamespaceProperty = serviceBusQueueActionParams.NamespaceProperty;
            serviceBusMessage.TransportType = serviceBusQueueActionParams.TransportType.GetValueOrDefaultEnum<ServiceBusTransportType>(defaultValue: ServiceBusTransportType.NetMessaging);
        }

        /// <summary>
        /// Get service bus authentication.
        /// </summary>
        /// <param name="serviceBusAuthenticationParams">Service bus authentication properties specified via PowerShell</param>
        /// <returns>ServiceBusAuthentication instance.</returns>
        private ServiceBusAuthentication GetServiceBusAuthentication(PSServiceBusAuthenticationParams serviceBusAuthenticationParams)
        {
            if (serviceBusAuthenticationParams == null ||
                string.IsNullOrWhiteSpace(serviceBusAuthenticationParams.SasKeyName) ||
                string.IsNullOrWhiteSpace(serviceBusAuthenticationParams.SasKey) ||
                string.IsNullOrWhiteSpace(serviceBusAuthenticationParams.Type))
            {
                throw new PSManagement.PSArgumentException();
            }

            return new ServiceBusAuthentication()
            {
                SasKey = serviceBusAuthenticationParams.SasKey,
                SasKeyName = serviceBusAuthenticationParams.SasKeyName,
                Type = serviceBusAuthenticationParams.Type.GetValueOrDefaultEnum<ServiceBusAuthenticationType>(defaultValue:ServiceBusAuthenticationType.NotSpecified)
            };
        }

        /// <summary>
        /// Validates whether max job count supported by chosen plan.
        /// </summary>
        /// <param name="jobCollection">Job collection name.</param>
        /// <param name="numberOfJobs">Requested maximum number of jobs.</param>
        private void Validate(JobCollectionDefinition jobCollection, int numberOfJobs)
        {
            int maxJobCount = 0;

            if (jobCollection != null &&
                jobCollection.Properties != null)
            {
                if (jobCollection.Properties.Quota != null &&
                    jobCollection.Properties.Quota.MaxJobCount != null)
                {
                    maxJobCount = jobCollection.Properties.Quota.MaxJobCount.Value;
                }
                else if (jobCollection.Properties.Sku != null &&
                        jobCollection.Properties.Sku.Name != null)
                {
                    switch (jobCollection.Properties.Sku.Name.Value)
                    {
                        case SkuDefinition.Free:
                            maxJobCount = Constants.MaxJobCountQuotaFree;
                            break;

                        case SkuDefinition.Standard:
                            maxJobCount = Constants.MaxJobCountQuotaStandard;
                            break;

                        case SkuDefinition.P10Premium:
                            maxJobCount = Constants.MaxJobCountQuotaP10Premium;
                            break;

                        case SkuDefinition.P20Premium:
                            maxJobCount = Constants.MaxJobCountQuotaP20Premium;
                            break;
                    }
                }

            }

            if (numberOfJobs >= maxJobCount)
            {
                throw new PSManagement.PSArgumentException(string.Format(Resources.JobCollectionReachedQuota, maxJobCount));
            }
        }
    }
}
