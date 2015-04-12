﻿// ----------------------------------------------------------------------------------
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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Net;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Common.Authentication.Models;
using Newtonsoft.Json;

using AutomationAccount = Microsoft.Azure.Commands.Automation.Model.AutomationAccount;


namespace Microsoft.Azure.Commands.Automation.Common
{
    using AutomationManagement = Azure.Management.Automation;
    using Microsoft.Azure.Common.Authentication;
    using Hyak.Common;


    public partial class AutomationClient : IAutomationClient
    {
        #region DscConfiguration Operations

        public IEnumerable<Model.DscConfiguration> ListAutomationConfigurations(
            string resourceGroupName,
            string automationAccountName)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            // todo fix paging
            return AutomationManagementClient.ContinuationTokenHandler(
                skipToken =>
                    {
                        var response = this.automationManagementClient.Configurations.List(
                            resourceGroupName,
                            automationAccountName);
                        return new ResponseWithSkipToken<AutomationManagement.Models.DscConfiguration>(
                            response,
                            response.Configurations);
                    }).Select(c => new Model.DscConfiguration(resourceGroupName, automationAccountName, c));
        }

        public Model.DscConfiguration GetConfiguration(
            string resourceGroupName,
            string automationAccountName,
            string configurationName)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            Requires.Argument("ConfigurationName", configurationName).NotNull();

            var configuration =
                this.automationManagementClient.Configurations.Get(
                    resourceGroupName,
                    automationAccountName,
                    configurationName).Configuration;

            return new Model.DscConfiguration(resourceGroupName, automationAccountName, configuration);
        }

        public Model.DscConfiguration CreateConfiguration(
            string resourceGroupName,
            string automationAccountName,
            string configurationName,
            string sourcePath,
            string description,
            bool? logVerbose)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            Requires.Argument("ConfigurationName", configurationName).NotNull();
            Requires.Argument("SourcePath", sourcePath).NotNull();

            string fileContent = null;

            if (File.Exists(Path.GetFullPath(sourcePath)))
            {
                fileContent = System.IO.File.ReadAllText(sourcePath);
            }
            string location = this.GetAutomationAccount(resourceGroupName, automationAccountName).Location;
            var configurationCreateParameters = new DscConfigurationCreateOrUpdateParameters()
                                                    {
                                                        Name = configurationName,
                                                        Location = location,
                                                        Properties = new DscConfigurationCreateOrUpdateProperties()
                                                                {
                                                                    Description = String.IsNullOrEmpty(description) ? String.Empty : description,
                                                                    LogVerbose = logVerbose.GetValueOrDefault(),
                                                                    Source = new Microsoft.Azure.Management.Automation.Models.ContentSource()
                                                                            {
                                                                                // only embeddedContent supported for now
                                                                                ContentType = "embeddedContent",
                                                                                Value = fileContent
                                                                            }
                                                                }
                                                    };

            var configuration =
                this.automationManagementClient.Configurations.CreateOrUpdate(
                    resourceGroupName,
                    automationAccountName,
                    configurationCreateParameters).Configuration;

            return new Model.DscConfiguration(resourceGroupName, automationAccountName, configuration);
        }

    #endregion

        #region AgentRegistration Operations
        public Model.AgentRegistration GetAgentRegistration(string resourceGroupName, string automationAccountName)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
        
            var agentRegistration = this.automationManagementClient.AgentRegistrationInformation.Get(
                resourceGroupName,
                automationAccountName).AgentRegistration;

            return new Model.AgentRegistration(resourceGroupName, automationAccountName, agentRegistration);
        }

        public Model.AgentRegistration NewAgentRegistrationKey(
            string resourceGroupName,
            string automationAccountName,
            string keyType)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            Requires.Argument("KeyType", keyType).NotNull();

            AgentRegistrationRegenerateKeyParameter keyName = new AgentRegistrationRegenerateKeyParameter() { KeyName = keyType};

            var agentRegistration = this.automationManagementClient.AgentRegistrationInformation.RegenerateKey(
                resourceGroupName,
                automationAccountName,
                keyName).AgentRegistration;

            return new Model.AgentRegistration(resourceGroupName, automationAccountName, agentRegistration);
        }
        #endregion

        #region compilationjob

        public Model.DscCompilationJob GetCompilationJob(string resourceGroupName, string automationAccountName, Guid Id)
        {
            var job = this.automationManagementClient.CompilationJobs.Get(resourceGroupName, automationAccountName, Id).DscCompilationJob;
            if (job == null)
            {
                throw new ResourceNotFoundException(typeof(Job),
                    string.Format(CultureInfo.CurrentCulture, Resources.CompilationJobNotFound, Id));
            }

            return new Model.DscCompilationJob(automationAccountName, job);
        }

        public IEnumerable<Model.DscCompilationJob> ListCompilationJobsByConfigurationName(string resourceGroupName, string automationAccountName, string configurationName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus)
        {
            IEnumerable<AutomationManagement.Models.DscCompilationJob> jobModels;

            if (startTime.HasValue && endTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.CompilationJobs.List(
                                resourceGroupName,
                                automationAccountName,
                                new AutomationManagement.Models.DscCompilationJobListParameters
                                {
                                    StartTime = FormatDateTime(startTime.Value),
                                    EndTime = FormatDateTime(endTime.Value),
                                    ConfigurationName = configurationName,
                                    Status = jobStatus,
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.DscCompilationJob>(response, response.DscCompilationJobs);
                    });
            }
            else if (startTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                     skipToken =>
                     {
                         var response =
                              this.automationManagementClient.CompilationJobs.List(
                                 resourceGroupName,
                                 automationAccountName,
                                   new AutomationManagement.Models.DscCompilationJobListParameters
                                   {
                                       StartTime = FormatDateTime(startTime.Value),
                                       ConfigurationName = configurationName,
                                       Status = jobStatus
                                   });
                         return new ResponseWithSkipToken<AutomationManagement.Models.DscCompilationJob>(response, response.DscCompilationJobs);
                     });
            }
            else if (endTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.CompilationJobs.List(
                                resourceGroupName,
                                automationAccountName,
                                new AutomationManagement.Models.DscCompilationJobListParameters
                                {
                                    EndTime = FormatDateTime(endTime.Value),
                                    ConfigurationName = configurationName,
                                    Status = jobStatus,
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.DscCompilationJob>(response, response.DscCompilationJobs);
                    });
            }
            else
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.CompilationJobs.List(
                            resourceGroupName,
                            automationAccountName,
                            new AutomationManagement.Models.DscCompilationJobListParameters
                            {
                                Status = jobStatus,
                                ConfigurationName = configurationName
                            });
                        return new ResponseWithSkipToken<AutomationManagement.Models.DscCompilationJob>(response, response.DscCompilationJobs);
                    });
            }

            return jobModels.Select(jobModel => new Commands.Automation.Model.DscCompilationJob(automationAccountName, jobModel));
        }

        public IEnumerable<Model.DscCompilationJob> ListCompilationJobs(string resourceGroupName, string automationAccountName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus)
        {
            IEnumerable<AutomationManagement.Models.DscCompilationJob> jobModels;

            if (startTime.HasValue && endTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.CompilationJobs.List(
                                resourceGroupName,
                                automationAccountName,
                                new AutomationManagement.Models.DscCompilationJobListParameters
                                {
                                    StartTime = FormatDateTime(startTime.Value),
                                    EndTime = FormatDateTime(endTime.Value),
                                    Status = jobStatus,
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.DscCompilationJob>(response, response.DscCompilationJobs);
                    });
            }
            else if (startTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                     skipToken =>
                     {
                         var response =
                              this.automationManagementClient.CompilationJobs.List(
                                   resourceGroupName,
                                   automationAccountName,
                                   new AutomationManagement.Models.DscCompilationJobListParameters
                                   {
                                       StartTime = FormatDateTime(startTime.Value),
                                       Status = jobStatus,
                                   });
                         return new ResponseWithSkipToken<AutomationManagement.Models.DscCompilationJob>(response, response.DscCompilationJobs);
                     });
            }
            else if (endTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.CompilationJobs.List(
                                resourceGroupName,
                                automationAccountName,
                                new AutomationManagement.Models.DscCompilationJobListParameters
                                {
                                    EndTime = FormatDateTime(endTime.Value),
                                    Status = jobStatus,
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.DscCompilationJob>(response, response.DscCompilationJobs);
                    });
            }
            else
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.CompilationJobs.List(
                            resourceGroupName,
                            automationAccountName,
                            new AutomationManagement.Models.DscCompilationJobListParameters { Status = jobStatus });
                        return new ResponseWithSkipToken<AutomationManagement.Models.DscCompilationJob>(response, response.DscCompilationJobs);
                    });
            }

            return jobModels.Select(jobModel => new Model.DscCompilationJob(automationAccountName, jobModel));
        }

        public Model.DscCompilationJob StartCompilationJob(string resourceGroupName, string automationAccountName, string configurationName, IDictionary parameters)
        {
            var createJobParameters = new DscCompilationJobCreateParameters()
            {
                Properties = new DscCompilationJobCreateProperties()
                {
                    Configuration = new DscConfigurationAssociationProperty()
                    {
                        Name = configurationName
                    },
                    Parameters = this.ProcessConfigurationParameters(resourceGroupName, automationAccountName, configurationName, parameters)
                }
            };
            
            var job = this.automationManagementClient.CompilationJobs.Compile(resourceGroupName, automationAccountName, createJobParameters);

            return new Model.DscCompilationJob(automationAccountName, job.DscCompilationJob);
        }

        public IEnumerable<Model.JobStream> GetDscCompilationJobStream(string resourceGroupName, string automationAccountName, Guid jobId, DateTimeOffset? time, string streamType)
        {
            var listParams = new AutomationManagement.Models.JobStreamListParameters();

            if (time.HasValue)
            {
                listParams.Time = this.FormatDateTime(time.Value);
            }

            if (streamType != null)
            {
                listParams.StreamType = streamType;
            }

            var jobStreams = this.automationManagementClient.JobStreams.List(resourceGroupName, automationAccountName, jobId, listParams).JobStreams;
            return jobStreams.Select(stream => this.CreateJobStreamFromJobStreamModel(stream, automationAccountName, jobId)).ToList();
        }

        #endregion

        #region privatemethods

        private string FormatDateTime(DateTimeOffset dateTime)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:O}", dateTime.ToUniversalTime());
        }

        private IDictionary<string, string> ProcessConfigurationParameters(string resourceGroupName, string automationAccountName, string configurationName, IDictionary parameters)
        {
            parameters = parameters ?? new Dictionary<string, string>();
            IEnumerable<KeyValuePair<string, DscConfigurationParameter>> configurationParameters = this.ListConfigurationParameters(resourceGroupName, automationAccountName, configurationName);
            var filteredParameters = new Dictionary<string, string>();

            foreach (var configParameter in configurationParameters)
            {
                if (parameters.Contains(configParameter.Key))
                {
                    object paramValue = parameters[configParameter.Key];
                    try
                    {
                        filteredParameters.Add(configParameter.Key, paramValue.ToString());
                    }
                    catch (JsonSerializationException)
                    {
                        throw new ArgumentException(
                        string.Format(
                            CultureInfo.CurrentCulture, Resources.ConfigurationParameterCannotBeSerializedToJson, configParameter.Key));
                    }
                }
                else if (configParameter.Value.IsMandatory)
                {
                    throw new ArgumentException(
                        string.Format(
                            CultureInfo.CurrentCulture, Resources.ConfigurationParameterValueRequired, configParameter.Key));
                }
            }

            if (filteredParameters.Count != parameters.Count)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture, Resources.InvalidConfigurationParameters));
            }

            return filteredParameters;
        }

        private IEnumerable<KeyValuePair<string, DscConfigurationParameter>> ListConfigurationParameters(string resourceGroupName, string automationAccountName, string configurationName)
        {
            Model.DscConfiguration configuration = this.GetConfiguration(resourceGroupName, automationAccountName, configurationName);
            if (configuration == null || 0 == String.Compare(configuration.State, RunbookState.New, CultureInfo.InvariantCulture,
                     CompareOptions.IgnoreCase))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.ConfigurationHasNoPublishedVersion, configurationName));
            }
            return configuration.Parameters.Cast<DictionaryEntry>().ToDictionary(k => k.Key.ToString(), k => (DscConfigurationParameter)k.Value);
        }

        private Model.JobStream CreateJobStreamFromJobStreamModel(AutomationManagement.Models.JobStream jobStream, string automationAccountName, Guid jobId)
        {
            Requires.Argument("jobStream", jobStream).NotNull();
            Requires.Argument("automationAccountName", automationAccountName).NotNull();
            Requires.Argument("jobId", jobId).NotNull();
            return new Model.JobStream(jobStream, automationAccountName, jobId);
        }

        #endregion
    }
}