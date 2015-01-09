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
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Common.Extensions.Models;
using Newtonsoft.Json;

using Runbook = Microsoft.Azure.Commands.Automation.Model.Runbook;
using Schedule = Microsoft.Azure.Commands.Automation.Model.Schedule;
using Job = Microsoft.Azure.Commands.Automation.Model.Job;
using Variable = Microsoft.Azure.Commands.Automation.Model.Variable;
using JobStream = Microsoft.Azure.Commands.Automation.Model.JobStream;
using Credential = Microsoft.Azure.Commands.Automation.Model.Credential;
using Module = Microsoft.Azure.Commands.Automation.Model.Module;
using JobSchedule = Microsoft.Azure.Commands.Automation.Model.JobSchedule;

namespace Microsoft.Azure.Commands.Automation.Common
{
    using AutomationManagement = Management.Automation;
    using Microsoft.Azure.Common.Extensions;

    public class AutomationClient : IAutomationClient
    {
        private readonly AutomationManagement.IAutomationManagementClient automationManagementClient;

        // Injection point for unit tests
        public AutomationClient()
        {
        }

        public AutomationClient(AzureSubscription subscription)
            : this(subscription,
                AzureSession.ClientFactory.CreateClient<AutomationManagement.AutomationManagementClient>(subscription,
                    AzureEnvironment.Endpoint.ServiceManagement))
        {
        }

        public AutomationClient(AzureSubscription subscription,
            AutomationManagement.IAutomationManagementClient automationManagementClient)
        {
            Requires.Argument("automationManagementClient", automationManagementClient).NotNull();

            this.Subscription = subscription;
            this.automationManagementClient = automationManagementClient;
        }

        public AzureSubscription Subscription { get; private set; }

        #region Schedule Operations

        public Schedule CreateSchedule(string automationAccountName, Schedule schedule)
        {
            var scheduleCreateParameters = new AutomationManagement.Models.ScheduleCreateParameters
            {
                Name = schedule.Name,
                Properties = new AutomationManagement.Models.ScheduleCreateProperties
                {
                    StartTime = schedule.StartTime,
                    ExpiryTime = schedule.ExpiryTime,
                    Description = schedule.Description,
                    Interval = schedule.Interval,
                    Frequency = schedule.Frequency.ToString()
                }
            };

            var scheduleCreateResponse = this.automationManagementClient.Schedules.Create(
                automationAccountName,
                scheduleCreateParameters);

            return this.GetSchedule(automationAccountName, schedule.Name);
        }

        public void DeleteSchedule(string automationAccountName, string scheduleName)
        {
            try
            {
                this.automationManagementClient.Schedules.Delete(
                    automationAccountName,
                    scheduleName);
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Schedule),
                        string.Format(CultureInfo.CurrentCulture, Resources.ScheduleNotFound, scheduleName));
                }

                throw;
            }
        }

        public Schedule GetSchedule(string automationAccountName, string scheduleName)
        {
            AutomationManagement.Models.Schedule scheduleModel = this.GetScheduleModel(automationAccountName,
                scheduleName);
            return this.CreateScheduleFromScheduleModel(automationAccountName, scheduleModel);
        }

        public IEnumerable<Schedule> ListSchedules(string automationAccountName)
        {
            IList<AutomationManagement.Models.Schedule> scheduleModels = AutomationManagementClient
                .ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.Schedules.List(
                            automationAccountName, skipToken);

                        return new ResponseWithSkipToken<AutomationManagement.Models.Schedule>(
                            response, response.Schedules);
                    });

            return scheduleModels.Select(scheduleModel => new Schedule(automationAccountName, scheduleModel));
        }

        public Schedule UpdateSchedule(string automationAccountName, string scheduleName, bool? isEnabled, string description)
        {
            AutomationManagement.Models.Schedule scheduleModel = this.GetScheduleModel(automationAccountName,
                scheduleName);
            return this.UpdateScheduleHelper(automationAccountName, scheduleModel, isEnabled, description);
        }

        #endregion

        #region RunbookOperations

        public Runbook GetRunbook(string automationAccountName, string runbookName)
        {
            var runbookModel = this.TryGetRunbookModel(automationAccountName, runbookName);
            if (runbookModel == null)
            {
                throw new ResourceCommonException(typeof(Runbook),
                    string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
            }

            return new Runbook(automationAccountName, runbookModel);
        }

        public IEnumerable<Runbook> ListRunbooks(string automationAccountName)
        {
            return AutomationManagementClient
                .ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.Runbooks.List(
                            automationAccountName, skipToken);
                        return new ResponseWithSkipToken<AutomationManagement.Models.Runbook>(
                            response, response.Runbooks);
                    }).Select(c => new Runbook(automationAccountName, c));
        }

        public Runbook CreateRunbookByName(string automationAccountName, string runbookName, string description,
            IDictionary<string, string> tags)
        {
            var runbookModel = this.TryGetRunbookModel(automationAccountName, runbookName);
            if (runbookModel != null)
            {
                throw new ResourceCommonException(typeof(Runbook),
                    string.Format(CultureInfo.CurrentCulture, Resources.RunbookAlreadyExists, runbookName));
            }

            var rdcprop = new RunbookCreateDraftProperties()
            {
                Description = description,
                RunbookType = RunbookTypeEnum.Script,
                Draft = new RunbookDraft()
            };

            var rdcparam = new RunbookCreateDraftParameters() { Name = runbookName, Properties = rdcprop, Location = "" };

            this.automationManagementClient.Runbooks.CreateWithDraftParameters(automationAccountName, rdcparam);

            return this.GetRunbook(automationAccountName, runbookName);
        }

        public Runbook CreateRunbookByPath(string automationAccountName, string runbookPath, string description,
            IDictionary<string, string> tags)
        {
            var runbookName = Path.GetFileNameWithoutExtension(runbookPath);

            var runbookModel = this.TryGetRunbookModel(automationAccountName, runbookName);
            if (runbookModel != null)
            {
                throw new ResourceCommonException(typeof(Runbook),
                    string.Format(CultureInfo.CurrentCulture, Resources.RunbookAlreadyExists, runbookName));
            }

            var runbook = this.CreateRunbookByName(automationAccountName, runbookName, description, tags);

            var rduprop = new RunbookDraftUpdateParameters()
            {
                Name = runbookName,
                Stream = File.ReadAllText(runbookPath)
            };

            this.automationManagementClient.RunbookDraft.Update(automationAccountName, rduprop);

            return runbook;
        }

        public void DeleteRunbook(string automationAccountName, string runbookName)
        {
            this.automationManagementClient.Runbooks.Delete(automationAccountName, runbookName);
        }

        public Runbook UpdateRunbook(string automationAccountName, string runbookName, string description,
            IDictionary<string, string> tags, bool? logProgress, bool? logVerbose)
        {
            var runbookUpdateParameters = new RunbookUpdateParameters();
            runbookUpdateParameters.Name = runbookName;
            if (tags != null) runbookUpdateParameters.Tags = tags;
            runbookUpdateParameters.Properties =  new RunbookUpdateProperties();
            if (description != null) runbookUpdateParameters.Properties.Description = description;
            if (logProgress.HasValue) runbookUpdateParameters.Properties.LogProgress = logProgress.Value;
            if (logVerbose.HasValue) runbookUpdateParameters.Properties.LogVerbose = logVerbose.Value;

            var runbook =
                this.automationManagementClient.Runbooks.Update(automationAccountName, runbookUpdateParameters).Runbook;

            return new Runbook(automationAccountName, runbook);
        }

        public RunbookDefinition UpdateRunbookDefinition(string automationAccountName, string runbookName,
            string runbookPath, bool overwrite)
        {
            var runbook = this.TryGetRunbookModel(automationAccountName, runbookName);
            if (runbook == null)
            {
                throw new ResourceNotFoundException(typeof(Runbook),
                    string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
            }

            if ((0 ==
                 String.Compare(runbook.Properties.State, RunbookState.Edit, CultureInfo.InvariantCulture,
                     CompareOptions.IgnoreCase) && overwrite == false))
            {
                throw new ResourceCommonException(typeof(Runbook),
                    string.Format(CultureInfo.CurrentCulture, Resources.RunbookAlreadyHasDraft, runbookName));
            }

            this.automationManagementClient.RunbookDraft.Update(automationAccountName,
                new RunbookDraftUpdateParameters { Name = runbookName, Stream = File.ReadAllText(runbookPath) });

            var content =
                this.automationManagementClient.RunbookDraft.Content(automationAccountName, runbookName).Stream;

            return new RunbookDefinition(automationAccountName, runbook, content, Constants.Draft);
        }

        public IEnumerable<RunbookDefinition> ListRunbookDefinitionsByRunbookName(string automationAccountName,
            string runbookName, bool? isDraft)
        {
            var ret = new List<RunbookDefinition>();

            var runbook = this.TryGetRunbookModel(automationAccountName, runbookName);
            if (runbook == null)
            {
                throw new ResourceNotFoundException(typeof(Runbook),
                    string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
            }

            if (0 !=
                String.Compare(runbook.Properties.State, RunbookState.Published, CultureInfo.InvariantCulture,
                    CompareOptions.IgnoreCase) && isDraft != null && isDraft.Value == true)
            {
                var draftContent =
                    this.automationManagementClient.RunbookDraft.Content(automationAccountName, runbookName).Stream;
                ret.Add(new RunbookDefinition(automationAccountName, runbook, draftContent, Constants.Draft));
            }
            else
            {
                var publishedContent =
                    this.automationManagementClient.Runbooks.Content(automationAccountName, runbookName).Stream;
                ret.Add(new RunbookDefinition(automationAccountName, runbook, publishedContent, Constants.Published));
            }

            return ret;
        }

        public Runbook PublishRunbook(string automationAccountName, string runbookName)
        {
            this.automationManagementClient.RunbookDraft.Publish(
                automationAccountName,
                new RunbookDraftPublishParameters
                {
                    Name = runbookName,
                    PublishedBy = Constants.ClientIdentity
                });

            return this.GetRunbook(automationAccountName, runbookName);
        }

        public Job StartRunbook(string automationAccountName, string runbookName, IDictionary parameters)
        {
            IDictionary<string, string> processedParameters = this.ProcessRunbookParameters(automationAccountName, runbookName, parameters);
            var job = this.automationManagementClient.Jobs.Create(
                                    automationAccountName,
                                    new JobCreateParameters
                                    {
                                        Properties = new JobCreateProperties
                                        {
                                            Runbook = new RunbookAssociationProperty
                                            {
                                                Name = runbookName
                                            },
                                            Parameters = processedParameters ?? null
                                        },
                                        Location = ""
                                     }).Job;

            return new Job(automationAccountName, job);
        }

        #endregion

        #region Variables

        public Variable CreateVariable(string automationAccountName, Variable variable)
        {
            bool variableExists = true;

            try
            {
                this.GetVariable(automationAccountName, variable.Name);
            }
            catch (ResourceNotFoundException)
            {
                variableExists = false;
            }

            if (variableExists)
            {
                throw new AzureAutomationOperationException(string.Format(CultureInfo.CurrentCulture,
                    Resources.VariableAlreadyExists, variable.Name));
            }

            if (variable.Encrypted)
            {
                var createParams = new AutomationManagement.Models.EncryptedVariableCreateParameters()
                {
                    Name = variable.Name,
                    Properties = new AutomationManagement.Models.EncryptedVariableCreateProperties()
                    {
                        Value = variable.Value,
                        Description = variable.Description
                    }
                };

                var sdkCreatedVariable =
                    this.automationManagementClient.EncryptedVariables.Create(automationAccountName, createParams)
                        .EncryptedVariable;

                return new Variable(sdkCreatedVariable, automationAccountName);
            }
            else
            {
                var createParams = new AutomationManagement.Models.VariableCreateParameters()
                {
                    Name = variable.Name,
                    Properties = new AutomationManagement.Models.VariableCreateProperties()
                    {
                        Value = variable.Value,
                        Description = variable.Description
                    }
                };

                var sdkCreatedVariable =
                    this.automationManagementClient.Variables.Create(automationAccountName, createParams).Variable;

                return new Variable(sdkCreatedVariable, automationAccountName);
            }
        }

        public void DeleteVariable(string automationAccountName, string variableName)
        {
            try
            {
                var existingVarible = this.GetVariable(automationAccountName, variableName);

                if (existingVarible.Encrypted)
                {
                    this.automationManagementClient.EncryptedVariables.Delete(automationAccountName, variableName);
                }
                else
                {
                    this.automationManagementClient.Variables.Delete(automationAccountName, variableName);
                }
            }
            catch (ResourceNotFoundException)
            {
                // the variable does not exists or already deleted. Do nothing. Return.
                return;
            }
        }

        public Variable UpdateVariable(string automationAccountName, Variable variable)
        {
            var existingVarible = this.GetVariable(automationAccountName, variable.Name);
            variable.Encrypted = existingVarible.Encrypted;

            if (variable.Encrypted)
            {
                var updateParams = new AutomationManagement.Models.EncryptedVariableUpdateParameters()
                {
                    Name = variable.Name,
                    Properties = new AutomationManagement.Models.EncryptedVariableUpdateProperties()
                    {
                        Value = variable.Value,
                        Description = variable.Description
                    }
                };

                this.automationManagementClient.EncryptedVariables.Update(automationAccountName, updateParams);
            }
            else
            {
                var updateParams = new AutomationManagement.Models.VariableUpdateParameters()
                {
                    Name = variable.Name,
                    Properties = new AutomationManagement.Models.VariableUpdateProperties()
                    {
                        Value = variable.Value,
                        Description = variable.Description
                    }
                };

                this.automationManagementClient.Variables.Update(automationAccountName, updateParams);
            }

            return this.GetVariable(automationAccountName, variable.Name);
        }

        public Variable GetVariable(string automationAccountName, string name)
        {
            try
            {
                var sdkEncryptedVariable = this.automationManagementClient.EncryptedVariables.Get(
                    automationAccountName, name).EncryptedVariable;

                if (sdkEncryptedVariable != null)
                {
                    return new Variable(sdkEncryptedVariable, automationAccountName);
                }
            }
            catch (CloudException)
            {
                // do nothing
            }

            try
            {
                var sdkVarible = this.automationManagementClient.Variables.Get(automationAccountName, name).Variable;

                if (sdkVarible != null)
                {
                    return new Variable(sdkVarible, automationAccountName);
                }
            }
            catch (CloudException)
            {
                // do nothing
            }

            throw new ResourceNotFoundException(typeof(Variable),
                string.Format(CultureInfo.CurrentCulture, Resources.VariableNotFound, name));
        }

        public IEnumerable<Variable> ListVariables(string automationAccountName)
        {
            IList<AutomationManagement.Models.Variable> variables = AutomationManagementClient.ContinuationTokenHandler(
               skipToken =>
               {
                   var response = this.automationManagementClient.Variables.List(
                       automationAccountName, skipToken);
                   return new ResponseWithSkipToken<AutomationManagement.Models.Variable>(
                       response, response.Variables);
               });

            var result = variables.Select(variable => this.CreateVariableFromVariableModel(variable, automationAccountName)).ToList();

            IList<AutomationManagement.Models.EncryptedVariable> encryptedVariables = AutomationManagementClient.ContinuationTokenHandler(
               skipToken =>
               {
                   var response = this.automationManagementClient.EncryptedVariables.List(
                       automationAccountName, skipToken);
                   return new ResponseWithSkipToken<AutomationManagement.Models.EncryptedVariable>(
                       response, response.EncryptedVariables);
               });

            result.AddRange(encryptedVariables.Select(variable => this.CreateVariableFromVariableModel(variable, automationAccountName)).ToList());

            return result;
        }
        #endregion 

        #region Credentials

        public Credential CreateCredential(string automationAccountName, string name, string userName, string password,
            string description)
        {
            var credentialCreateParams = new AutomationManagement.Models.CredentialCreateParameters();
            credentialCreateParams.Name = name;
            credentialCreateParams.Properties = new AutomationManagement.Models.CredentialCreateProperties();
            if (description != null) credentialCreateParams.Properties.Description = description;

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                new AzureAutomationOperationException(string.Format(Resources.ParameterEmpty, "Username or Password"));
            }

            credentialCreateParams.Properties.UserName = userName;
            credentialCreateParams.Properties.Password = password;

            var createdCredential = this.automationManagementClient.PsCredentials.Create(automationAccountName,
                credentialCreateParams);

            if (createdCredential == null || createdCredential.StatusCode != HttpStatusCode.Created)
            {
                new AzureAutomationOperationException(string.Format(Resources.AutomationOperationFailed, "Create",
                    "credential", name, automationAccountName));
            }
            return new Credential(automationAccountName, createdCredential.Credential);
        }

        public Credential UpdateCredential(string automationAccountName, string name, string userName, string password,
            string description)
        {
            var credentialUpdateParams = new AutomationManagement.Models.CredentialUpdateParameters();
            credentialUpdateParams.Name = name;
            credentialUpdateParams.Properties = new AutomationManagement.Models.CredentialUpdateProperties();
            if (description != null) credentialUpdateParams.Properties.Description = description;

            Requires.Argument("userName", userName).NotNull();
            Requires.Argument("password", password).NotNull();

            credentialUpdateParams.Properties.UserName = userName;
            credentialUpdateParams.Properties.Password = password;

            var credential = this.automationManagementClient.PsCredentials.Update(automationAccountName,
                credentialUpdateParams);

            if (credential == null || credential.StatusCode != HttpStatusCode.OK)
            {
                new AzureAutomationOperationException(string.Format(Resources.AutomationOperationFailed, "Update",
                    "credential", name, automationAccountName));
            }

            var updatedCredential = this.GetCredential(automationAccountName, name);

            return updatedCredential;
        }

        public Credential GetCredential(string automationAccountName, string name)
        {
            var credential = this.automationManagementClient.PsCredentials.Get(automationAccountName, name).Credential;
            if (credential == null)
            {
                throw new ResourceNotFoundException(typeof(Credential), string.Format(CultureInfo.CurrentCulture, Resources.CredentialNotFound, name));
            }

            return new Credential(automationAccountName, credential);
        }

        private Credential CreateCredentialFromCredentialModel(AutomationManagement.Models.Credential credential)
        {
            Requires.Argument("credential", credential).NotNull();

            return new Credential(null, credential);
        }

        public IEnumerable<Credential> ListCredentials(string automationAccountName)
        {
            IList<AutomationManagement.Models.Credential> credentialModels = AutomationManagementClient
                .ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.PsCredentials.List(automationAccountName,
                            skipToken);
                        return new ResponseWithSkipToken<AutomationManagement.Models.Credential>(
                            response, response.Credentials);
                    });

            return credentialModels.Select(c => new Credential(automationAccountName, c));
        }

        public void DeleteCredential(string automationAccountName, string name)
        {
            try
            {
                var credential = this.automationManagementClient.PsCredentials.Delete(automationAccountName, name);
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Schedule), string.Format(CultureInfo.CurrentCulture, Resources.CredentialNotFound, name));
                }

                throw;
            }
        }

        #endregion

        #region Modules
        public Module CreateModule(string automationAccountName, Uri contentLink, string moduleName,
            IDictionary<string, string> Tags)
        {
            var createdModule = this.automationManagementClient.Modules.Create(automationAccountName,
                new AutomationManagement.Models.ModuleCreateParameters()
                {
                    Name = moduleName,
                    Tags = Tags,
                    Properties = new AutomationManagement.Models.ModuleCreateProperties()
                    {
                        ContentLink = new AutomationManagement.Models.ContentLink()
                        {
                            Uri = contentLink,
                            ContentHash = null,
                            Version = null
                        }
                    },
                });

            return this.GetModule(automationAccountName, moduleName);
        }

        public Module GetModule(string automationAccountName, string name)
        {
            var module = this.automationManagementClient.Modules.Get(automationAccountName, name).Module;
            if (module == null)
            {
                throw new ResourceNotFoundException(typeof(Module), string.Format(CultureInfo.CurrentCulture, Resources.ModuleNotFound, name));
            }

            return new Module(automationAccountName, module);
        }

        public IEnumerable<Module> ListModules(string automationAccountName)
        {
            IList<AutomationManagement.Models.Module> modulesModels = AutomationManagementClient
                .ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.Modules.List(automationAccountName, skipToken);
                        return new ResponseWithSkipToken<AutomationManagement.Models.Module>(
                            response, response.Modules);
                    });

            return modulesModels.Select(c => new Module(automationAccountName, c));
        }

        public Module UpdateModule(string automationAccountName, IDictionary<string, string> tags, string name)
        {
            var existingModule = this.GetModule(automationAccountName, name);

            var moduleUpdateParameters = new AutomationManagement.Models.ModuleUpdateParameters();
            moduleUpdateParameters.Name = name;
            if (tags != null) moduleUpdateParameters.Tags = tags;
            moduleUpdateParameters.Location = existingModule.Location;

            var updatedModule = this.automationManagementClient.Modules.Update(automationAccountName,
                moduleUpdateParameters);

            if (updatedModule == null || updatedModule.StatusCode != HttpStatusCode.OK)
            {
                new AzureAutomationOperationException(string.Format(Resources.AutomationOperationFailed, "Update",
                    "Module", name, automationAccountName));
            }

            return new Module(automationAccountName, updatedModule.Module);
        }

        public void DeleteModule(string automationAccountName, string name)
        {
            try
            {
                var module = this.automationManagementClient.Modules.Delete(automationAccountName, name);
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Schedule), string.Format(CultureInfo.CurrentCulture, Resources.ModuleNotFound, name));
                }

                throw;
            }
        }

        #endregion

        #region Jobs
        public IEnumerable<JobStream> GetJobStream(string automationAccountName, Guid jobId, DateTime? time,
           string streamType)
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

            var jobStreams = this.automationManagementClient.JobStreams.List(automationAccountName, jobId, listParams).JobStreams;
            return jobStreams.Select(stream => this.CreateJobStreamFromJobStreamModel(stream, automationAccountName, jobId)).ToList();
        }

        public Job GetJob(string automationAccountName, Guid Id)
        {
            var job = this.automationManagementClient.Jobs.Get(automationAccountName, Id).Job;
            if (job == null)
            {
                throw new ResourceNotFoundException(typeof(Job),
                    string.Format(CultureInfo.CurrentCulture, Resources.JobNotFound, Id));
            }

            return new Job(automationAccountName, job);
        }

        public IEnumerable<Job> ListJobsByRunbookName(string automationAccountName, string runbookName, DateTime? startTime, DateTime? endTime, string jobStatus)
        {
            // Assume local time if DateTimeKind.Unspecified 
            if (startTime.HasValue && startTime.Value.Kind == DateTimeKind.Unspecified)
            {
                startTime = DateTime.SpecifyKind(startTime.Value, DateTimeKind.Local);
            }


            if (endTime.HasValue && endTime.Value.Kind == DateTimeKind.Unspecified)
            {
                endTime = DateTime.SpecifyKind(endTime.Value, DateTimeKind.Local);
            }
            
            IEnumerable<AutomationManagement.Models.Job> jobModels;

            if (startTime.HasValue && endTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.Jobs.List(
                                automationAccountName,
                                new AutomationManagement.Models.JobListParameters
                                {
                                    StartTime = FormatDateTime(startTime.Value),
                                    EndTime = FormatDateTime(endTime.Value),
                                    RunbookName = runbookName,
                                    Status = jobStatus,
                                    SkipToken = skipToken
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }
            else if (startTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                     skipToken =>
                     {
                         var response =
                              this.automationManagementClient.Jobs.List(
                                 automationAccountName,
                                   new AutomationManagement.Models.JobListParameters
                                   {
                                       StartTime = FormatDateTime(startTime.Value),
                                       RunbookName = runbookName,
                                       Status = jobStatus,
                                       SkipToken = skipToken
                                   });
                         return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                     });
            }
            else if (endTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.Jobs.List(
                                automationAccountName,
                                new AutomationManagement.Models.JobListParameters
                                {
                                    EndTime = FormatDateTime(endTime.Value),
                                    RunbookName = runbookName,
                                    Status = jobStatus,
                                    SkipToken = skipToken
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }
            else
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.Jobs.List(
                            automationAccountName,
                            new AutomationManagement.Models.JobListParameters
                            {
                                SkipToken = skipToken,
                                Status = jobStatus,
                                RunbookName = runbookName
                            });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }

            return jobModels.Select(jobModel => new Job(automationAccountName, jobModel));
        }

        public IEnumerable<Job> ListJobs(string automationAccountName, DateTime? startTime, DateTime? endTime, string jobStatus)
        {
            // Assume local time if DateTimeKind.Unspecified 
            if (startTime.HasValue && startTime.Value.Kind == DateTimeKind.Unspecified)
            {
                startTime = DateTime.SpecifyKind(startTime.Value, DateTimeKind.Local);
            }


            if (endTime.HasValue && endTime.Value.Kind == DateTimeKind.Unspecified)
            {
                endTime = DateTime.SpecifyKind(endTime.Value, DateTimeKind.Local);
            }

            IEnumerable<AutomationManagement.Models.Job> jobModels;

            if (startTime.HasValue && endTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.Jobs.List(
                                automationAccountName,
                                new AutomationManagement.Models.JobListParameters
                                {
                                    StartTime = FormatDateTime(startTime.Value),
                                    EndTime = FormatDateTime(endTime.Value),
                                    Status = jobStatus,
                                    SkipToken = skipToken
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }
            else if (startTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                     skipToken =>
                     {
                         var response =
                              this.automationManagementClient.Jobs.List(
                                 automationAccountName,
                                   new AutomationManagement.Models.JobListParameters
                                   {
                                       StartTime = FormatDateTime(startTime.Value),
                                       Status = jobStatus,
                                       SkipToken = skipToken
                                   });
                         return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                     });
            }
            else if (endTime.HasValue)
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response =
                            this.automationManagementClient.Jobs.List(
                                automationAccountName,
                                new AutomationManagement.Models.JobListParameters
                                {
                                    EndTime = FormatDateTime(endTime.Value),
                                    Status = jobStatus,
                                    SkipToken = skipToken
                                });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }
            else
            {
                jobModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.Jobs.List(
                            automationAccountName,
                            new AutomationManagement.Models.JobListParameters { Status = jobStatus, SkipToken = skipToken, });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }

            return jobModels.Select(jobModel => new Job(automationAccountName, jobModel));
        }

        public void ResumeJob(string automationAccountName, Guid id)
        {
            this.automationManagementClient.Jobs.Resume(automationAccountName, id);
        }

        public void StopJob(string automationAccountName, Guid id)
        {
            this.automationManagementClient.Jobs.Stop(automationAccountName, id);
        }

        public void SuspendJob(string automationAccountName, Guid id)
        {
            this.automationManagementClient.Jobs.Suspend(automationAccountName, id);
        }

        #endregion

        #region JobSchedules

        public JobSchedule GetJobSchedule(string automationAccountName, Guid jobScheduleId)
        {
            AutomationManagement.Models.JobSchedule jobScheduleModel = null;

            try
            {
                jobScheduleModel = this.automationManagementClient.JobSchedules.Get(
                    automationAccountName,
                    jobScheduleId)
                    .JobSchedule;
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(JobSchedule),
                        string.Format(CultureInfo.CurrentCulture, Resources.JobScheduleWithIdNotFound, jobScheduleId));
                }

                throw;
            }
 
            return this.CreateJobScheduleFromJobScheduleModel(automationAccountName, jobScheduleModel);
        }

        public JobSchedule GetJobSchedule(string automationAccountName, string runbookName, string scheduleName)
        {
            var jobSchedules = this.ListJobSchedules(automationAccountName);
            JobSchedule jobSchedule = null;
            bool jobScheduleFound = false;

            foreach (var js in jobSchedules)
            {
                if (String.Equals(js.RunbookName, runbookName, StringComparison.OrdinalIgnoreCase) && 
                    String.Equals(js.ScheduleName, scheduleName, StringComparison.OrdinalIgnoreCase))
                {
                    jobSchedule = this.GetJobSchedule(automationAccountName, new Guid(js.Id));
                    jobScheduleFound = true;
                    break;
                }
            }
            if (!jobScheduleFound)
            {
                throw new ResourceNotFoundException(typeof(Schedule),
                        string.Format(CultureInfo.CurrentCulture, Resources.JobScheduleNotFound, runbookName, scheduleName));
            }

            return jobSchedule;
        }

        public IEnumerable<JobSchedule> ListJobSchedules(string automationAccountName)
        {
            IList<AutomationManagement.Models.JobSchedule> jobScheduleModels = AutomationManagementClient
                .ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.JobSchedules.List(
                            automationAccountName, skipToken);

                        return new ResponseWithSkipToken<AutomationManagement.Models.JobSchedule>(
                            response, response.JobSchedules);
                    });

            return jobScheduleModels.Select(jobScheduleModel => new JobSchedule(automationAccountName, jobScheduleModel));
        }

        public IEnumerable<JobSchedule> ListJobSchedulesByRunbookName(string automationAccountName, string runbookName)
        {
            var jobSchedules = this.ListJobSchedules(automationAccountName);

            IEnumerable<JobSchedule> jobSchedulesOfRunbook = new List<JobSchedule>();

            jobSchedulesOfRunbook = jobSchedules.Where(js => String.Equals(js.RunbookName, runbookName, StringComparison.OrdinalIgnoreCase));

            return jobSchedulesOfRunbook;
        }

        public IEnumerable<JobSchedule> ListJobSchedulesByScheduleName(string automationAccountName, string scheduleName)
        {
            var jobSchedules = this.ListJobSchedules(automationAccountName);

            IEnumerable<JobSchedule> jobSchedulesOfSchedule = new List<JobSchedule>();

            jobSchedulesOfSchedule = jobSchedules.Where(js => String.Equals(js.ScheduleName, scheduleName, StringComparison.OrdinalIgnoreCase));

            return jobSchedulesOfSchedule;
        }

        public JobSchedule RegisterScheduledRunbook(string automationAccountName, string runbookName, string scheduleName, IDictionary parameters)
        {
            var processedParameters = this.ProcessRunbookParameters(automationAccountName, runbookName, parameters);
            var sdkJobSchedule = this.automationManagementClient.JobSchedules.Create(
                automationAccountName,
                new AutomationManagement.Models.JobScheduleCreateParameters
                {
                    Properties = new AutomationManagement.Models.JobScheduleCreateProperties
                    {
                        Schedule = new ScheduleAssociationProperty { Name = scheduleName },
                        Runbook = new RunbookAssociationProperty { Name = runbookName },
                        Parameters = processedParameters
                    }
                }).JobSchedule;

            return new JobSchedule(automationAccountName, sdkJobSchedule);
        }

        public void UnregisterScheduledRunbook(string automationAccountName, Guid jobScheduleId)
        {
            try
            {
                this.automationManagementClient.JobSchedules.Delete(
                    automationAccountName,
                    jobScheduleId);
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Schedule),
                        string.Format(CultureInfo.CurrentCulture, Resources.JobScheduleWithIdNotFound, jobScheduleId));
                }

                throw;
            }
        }

        public void UnregisterScheduledRunbook(string automationAccountName, string runbookName, string scheduleName)
        {
            var jobSchedules = this.ListJobSchedules(automationAccountName);
            bool jobScheduleFound = false;

            foreach (var jobSchedule in jobSchedules)
            {
                if (jobSchedule.RunbookName == runbookName && jobSchedule.ScheduleName == scheduleName)
                {
                    this.UnregisterScheduledRunbook(automationAccountName, new Guid(jobSchedule.Id));
                    jobScheduleFound = true;
                    break;
                }
            }
            if(!jobScheduleFound)
            {
                throw new ResourceNotFoundException(typeof(Schedule),
                        string.Format(CultureInfo.CurrentCulture, Resources.JobScheduleNotFound, runbookName, scheduleName));
            }
        }

        #endregion

        #region Private Methods

        private Schedule CreateScheduleFromScheduleModel(string automationAccountName, AutomationManagement.Models.Schedule schedule)
        {
            Requires.Argument("schedule", schedule).NotNull();

            return new Schedule(automationAccountName, schedule);
        }

        private JobSchedule CreateJobScheduleFromJobScheduleModel(string automationAccountName, AutomationManagement.Models.JobSchedule jobSchedule)
        {
            Requires.Argument("jobSchedule", jobSchedule).NotNull();

            return new JobSchedule(automationAccountName, jobSchedule);
        }

        private Management.Automation.Models.Runbook TryGetRunbookModel(string automationAccountName, string runbookName)
        {
            Management.Automation.Models.Runbook runbook = null;
            try
            {
                runbook = this.automationManagementClient.Runbooks.Get(automationAccountName, runbookName).Runbook;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    runbook = null;
                }
                else
                {
                    throw;
                }
            }
            return runbook;
        }

        private IDictionary<string, RunbookParameter> ListRunbookParameters(string automationAccountName, string runbookName)
        {
            Runbook runbook = this.GetRunbook(automationAccountName, runbookName);
            if (0 == String.Compare(runbook.State, RunbookState.New, CultureInfo.InvariantCulture,
                     CompareOptions.IgnoreCase))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.RunbookHasNoPublishedVersion, runbookName));
            }
            return runbook.Parameters;
        }

        private IDictionary<string, string> ProcessRunbookParameters(string automationAccountName, string runbookName, IDictionary parameters)
        {
            parameters = parameters ?? new Dictionary<string, string>();
            IDictionary<string, RunbookParameter> runbookParameters = this.ListRunbookParameters(automationAccountName, runbookName);
            var filteredParameters = new Dictionary<string, string>();

            foreach (var runbookParameter in runbookParameters)
            {
                if (parameters.Contains(runbookParameter.Key))
                {
                    object paramValue = parameters[runbookParameter.Key];
                    try
                    {
                        filteredParameters.Add(runbookParameter.Key, JsonConvert.SerializeObject(paramValue, new JsonSerializerSettings() { DateFormatHandling = DateFormatHandling.MicrosoftDateFormat }));
                    }
                    catch (JsonSerializationException)
                    {
                        throw new ArgumentException(
                        string.Format(
                            CultureInfo.CurrentCulture, Resources.RunbookParameterCannotBeSerializedToJson, runbookParameter.Key));
                    }
                }
                else if (runbookParameter.Value.IsMandatory)
                {
                    throw new ArgumentException(
                        string.Format(
                            CultureInfo.CurrentCulture, Resources.RunbookParameterValueRequired, runbookParameter.Key));
                }
            }

            if (filteredParameters.Count != parameters.Count)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture, Resources.InvalidRunbookParameters));
            }

            var hasJobStartedBy = filteredParameters.Any(filteredParameter => filteredParameter.Key == Constants.JobStartedByParameterName);

            if (!hasJobStartedBy)
            {
                filteredParameters.Add(Constants.JobStartedByParameterName, Constants.ClientIdentity);
            }

            return filteredParameters;
        }

        private JobStream CreateJobStreamFromJobStreamModel(AutomationManagement.Models.JobStream jobStream, string automationAccountName, Guid jobId)
        {
            Requires.Argument("jobStream", jobStream).NotNull();
            Requires.Argument("automationAccountName", automationAccountName).NotNull();
            Requires.Argument("jobId", jobId).NotNull();
            return new JobStream(jobStream, automationAccountName, jobId);
        }

        private Variable CreateVariableFromVariableModel(AutomationManagement.Models.Variable variable, string automationAccountName)
        {
            Requires.Argument("variable", variable).NotNull();

            return new Variable(variable, automationAccountName);
        }

        private Variable CreateVariableFromVariableModel(AutomationManagement.Models.EncryptedVariable variable, string automationAccountName)
        {
            Requires.Argument("variable", variable).NotNull();

            return new Variable(variable, automationAccountName);
        }


        private AutomationManagement.Models.Schedule GetScheduleModel(string automationAccountName, string scheduleName)
        {
            AutomationManagement.Models.Schedule scheduleModel;

            try
            {
                scheduleModel = this.automationManagementClient.Schedules.Get(
                    automationAccountName,
                    scheduleName)
                    .Schedule;
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Schedule), string.Format(CultureInfo.CurrentCulture, Resources.ScheduleNotFound, scheduleName));
                }

                throw;
            }

            return scheduleModel;
        }

        private string FormatDateTime(DateTime dateTime)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:O}", dateTime.ToUniversalTime());
        }

        private Schedule UpdateScheduleHelper(string automationAccountName,
            AutomationManagement.Models.Schedule schedule, bool? isEnabled, string description)
        {

            if (isEnabled.HasValue)
            {
                schedule.Properties.IsEnabled = isEnabled.Value;
            }

            if (description != null)
            {
                schedule.Properties.Description = description;
            }

            var scheduleUpdateParameters = new AutomationManagement.Models.ScheduleUpdateParameters
            {
                Name = schedule.Name,
                Properties = new AutomationManagement.Models.ScheduleUpdateProperties
                {
                    Description = schedule.Properties.Description,
                    IsEnabled = schedule.Properties.IsEnabled
                }
            };

            this.automationManagementClient.Schedules.Update(
                automationAccountName,
                scheduleUpdateParameters);

            return this.GetSchedule(automationAccountName, schedule.Name);
        }

        #endregion
    }
}