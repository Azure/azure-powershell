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
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using Newtonsoft.Json;

using Runbook = Microsoft.Azure.Commands.Automation.Model.Runbook;
using Schedule = Microsoft.Azure.Commands.Automation.Model.Schedule;
using Job = Microsoft.Azure.Commands.Automation.Model.Job;
using Variable = Microsoft.Azure.Commands.Automation.Model.Variable;
using JobStream = Microsoft.Azure.Commands.Automation.Model.JobStream;
using Credential = Microsoft.Azure.Commands.Automation.Model.CredentialInfo;
using Module = Microsoft.Azure.Commands.Automation.Model.Module;
using JobSchedule = Microsoft.Azure.Commands.Automation.Model.JobSchedule;
using Certificate = Microsoft.Azure.Commands.Automation.Model.CertificateInfo;
using Connection = Microsoft.Azure.Commands.Automation.Model.Connection;

namespace Microsoft.Azure.Commands.Automation.Common
{
    using AutomationManagement = Management.Automation;
    using Microsoft.Azure.Common.Extensions.Models;
    using Microsoft.Azure.Common.Extensions;
    using Hyak.Common;


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
                            automationAccountName);

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

        #region Runbook Operations

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
                            automationAccountName);
                        return new ResponseWithSkipToken<AutomationManagement.Models.Runbook>(
                            response, response.Runbooks);
                    }).Select(c => new Runbook(automationAccountName, c));
        }

        public Runbook CreateRunbookByName(string automationAccountName, string runbookName, string description,
            IDictionary tags)
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

            var rdcparam = new RunbookCreateDraftParameters() { Name = runbookName, Properties = rdcprop, Tags = (tags != null) ? tags.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString()) : null };

            this.automationManagementClient.Runbooks.CreateWithDraft(automationAccountName, rdcparam);

            return this.GetRunbook(automationAccountName, runbookName);
        }

        public Runbook CreateRunbookByPath(string automationAccountName, string runbookPath, string description,
            IDictionary tags)
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
            IDictionary tags, bool? logProgress, bool? logVerbose)
        {
            var runbookModel = this.TryGetRunbookModel(automationAccountName, runbookName);
            if (runbookModel == null)
            {
                throw new ResourceCommonException(typeof(Runbook),
                    string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
            }

            var runbookUpdateParameters = new RunbookUpdateParameters();
            runbookUpdateParameters.Name = runbookName;
            runbookUpdateParameters.Tags = (tags != null)
                    ? tags.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString())
                    : runbookModel.Tags;
            runbookUpdateParameters.Properties =  new RunbookUpdateProperties();
            runbookUpdateParameters.Properties.Description = description ?? runbookModel.Properties.Description;
            runbookUpdateParameters.Properties.LogProgress = (logProgress.HasValue) ?  logProgress.Value : runbookModel.Properties.LogProgress;
            runbookUpdateParameters.Properties.LogVerbose = (logProgress.HasValue) ? logProgress.Value : runbookModel.Properties.LogVerbose;

            var runbook = this.automationManagementClient.Runbooks.Update(automationAccountName, runbookUpdateParameters).Runbook;

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
                                        }
                                     }).Job;

            return new Job(automationAccountName, job);
        }

        #endregion

        #region Variables

        public Variable CreateVariable(Variable variable)
        {
            bool variableExists = true;

            try
            {
                this.GetVariable(variable.AutomationAccountName, variable.Name);
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
                        Value = JsonConvert.SerializeObject(variable.Value),
                        Description = variable.Description
                    }
                };

                var sdkCreatedVariable =
                    this.automationManagementClient.EncryptedVariables.Create(variable.AutomationAccountName, createParams)
                        .EncryptedVariable;

                return new Variable(sdkCreatedVariable, variable.AutomationAccountName);
            }
            else
            {
                var createParams = new AutomationManagement.Models.VariableCreateParameters()
                {
                    Name = variable.Name,
                    Properties = new AutomationManagement.Models.VariableCreateProperties()
                    {
                        Value = JsonConvert.SerializeObject(variable.Value),
                        Description = variable.Description
                    }
                };

                var sdkCreatedVariable =
                    this.automationManagementClient.Variables.Create(variable.AutomationAccountName, createParams).Variable;

                return new Variable(sdkCreatedVariable, variable.AutomationAccountName);
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

        public Variable UpdateVariable(Variable variable, VariableUpdateFields updateFields)
        {
            var existingVariable = this.GetVariable(variable.AutomationAccountName, variable.Name);

            if (existingVariable.Encrypted != variable.Encrypted)
            {
                throw new ResourceNotFoundException(typeof(Variable),
                    string.Format(CultureInfo.CurrentCulture, Resources.VariableEncryptionCannotBeChanged, variable.Name, existingVariable.Encrypted));
            }

            if (variable.Encrypted)
            {
                var updateParams = new AutomationManagement.Models.EncryptedVariableUpdateParameters()
                {
                    Name = variable.Name
                };

                if (updateFields == VariableUpdateFields.OnlyDescription)
                {
                    updateParams.Properties = new AutomationManagement.Models.EncryptedVariableUpdateProperties()
                    {
                        Description = variable.Description
                    };
                }
                else
                {
                    updateParams.Properties = new AutomationManagement.Models.EncryptedVariableUpdateProperties()
                    {
                        Value = JsonConvert.SerializeObject(variable.Value)
                    };
                }

                this.automationManagementClient.EncryptedVariables.Update(variable.AutomationAccountName, updateParams);
            }
            else
            {
                var updateParams = new AutomationManagement.Models.VariableUpdateParameters()
                {
                    Name = variable.Name,
                };

                if (updateFields == VariableUpdateFields.OnlyDescription)
                {
                    updateParams.Properties = new AutomationManagement.Models.VariableUpdateProperties()
                    {
                        Description = variable.Description
                    };
                }
                else
                {
                    updateParams.Properties = new AutomationManagement.Models.VariableUpdateProperties()
                    {
                        Value = JsonConvert.SerializeObject(variable.Value)
                    };
                }

                this.automationManagementClient.Variables.Update(variable.AutomationAccountName, updateParams);
            }

            return this.GetVariable(variable.AutomationAccountName, variable.Name);
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
                       automationAccountName);
                   return new ResponseWithSkipToken<AutomationManagement.Models.Variable>(
                       response, response.Variables);
               });

            var result = variables.Select(variable => this.CreateVariableFromVariableModel(variable, automationAccountName)).ToList();

            IList<AutomationManagement.Models.EncryptedVariable> encryptedVariables = AutomationManagementClient.ContinuationTokenHandler(
               skipToken =>
               {
                   var response = this.automationManagementClient.EncryptedVariables.List(
                       automationAccountName);
                   return new ResponseWithSkipToken<AutomationManagement.Models.EncryptedVariable>(
                       response, response.EncryptedVariables);
               });

            result.AddRange(encryptedVariables.Select(variable => this.CreateVariableFromVariableModel(variable, automationAccountName)).ToList());

            return result;
        }
        #endregion 

        #region Credentials

        public CredentialInfo CreateCredential(string automationAccountName, string name, string userName, string password,
            string description)
        {
            var credentialCreateParams = new AutomationManagement.Models.CredentialCreateParameters();
            credentialCreateParams.Name = name;
            credentialCreateParams.Properties = new AutomationManagement.Models.CredentialCreateProperties();
            if (description != null) credentialCreateParams.Properties.Description = description;

            Requires.Argument("userName", userName).NotNull();
            Requires.Argument("password", password).NotNull();

            credentialCreateParams.Properties.UserName = userName;
            credentialCreateParams.Properties.Password = password;

            var createdCredential = this.automationManagementClient.PsCredentials.Create(automationAccountName,
                credentialCreateParams);

            if (createdCredential == null || createdCredential.StatusCode != HttpStatusCode.Created)
            {
                new AzureAutomationOperationException(string.Format(Resources.AutomationOperationFailed, "Create",
                    "credential", name, automationAccountName));
            }
            return new CredentialInfo(automationAccountName, createdCredential.Credential);
        }

        public CredentialInfo UpdateCredential(string automationAccountName, string name, string userName, string password,
            string description)
        {
            var credentialUpdateParams = new AutomationManagement.Models.CredentialUpdateParameters();
            credentialUpdateParams.Name = name;
            credentialUpdateParams.Properties = new AutomationManagement.Models.CredentialUpdateProperties();
            if (description != null) credentialUpdateParams.Properties.Description = description;

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

        public CredentialInfo GetCredential(string automationAccountName, string name)
        {
            var credential = this.automationManagementClient.PsCredentials.Get(automationAccountName, name).Credential;
            if (credential == null)
            {
                throw new ResourceNotFoundException(typeof(Credential), string.Format(CultureInfo.CurrentCulture, Resources.CredentialNotFound, name));
            }

            return new CredentialInfo(automationAccountName, credential);
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
                        var response = this.automationManagementClient.PsCredentials.List(automationAccountName);
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
            IDictionary tags)
        {
            IDictionary<string, string> moduleTags = null;
            if (tags != null) moduleTags = tags.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());
            var createdModule = this.automationManagementClient.Modules.Create(automationAccountName,
                new AutomationManagement.Models.ModuleCreateParameters()
                {
                    Name = moduleName,
                    Tags = moduleTags,
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
                        var response = this.automationManagementClient.Modules.List(automationAccountName);
                        return new ResponseWithSkipToken<AutomationManagement.Models.Module>(
                            response, response.Modules);
                    });

            return modulesModels.Select(c => new Module(automationAccountName, c));
        }

        public Module UpdateModule(string automationAccountName, IDictionary tags, string name, Uri contentLinkUri)
        {
            if(tags != null && contentLinkUri != null)
            {
                var moduleCreateParameters = new AutomationManagement.Models.ModuleCreateParameters();
                
                moduleCreateParameters.Name = name;
                moduleCreateParameters.Tags = tags.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());

                moduleCreateParameters.Properties = new ModuleCreateProperties();
                moduleCreateParameters.Properties.ContentLink = new AutomationManagement.Models.ContentLink();
                moduleCreateParameters.Properties.ContentLink.Uri = contentLinkUri;

                this.automationManagementClient.Modules.Create(automationAccountName,
                    moduleCreateParameters);

            }
            else if (contentLinkUri != null)
            {
                var moduleUpdateParameters = new AutomationManagement.Models.ModuleUpdateParameters();

                moduleUpdateParameters.Name = name;
                moduleUpdateParameters.Properties = new ModuleUpdateProperties();
                moduleUpdateParameters.Properties.ContentLink = new AutomationManagement.Models.ContentLink();
                moduleUpdateParameters.Properties.ContentLink.Uri = contentLinkUri;

                this.automationManagementClient.Modules.Update(automationAccountName, moduleUpdateParameters);
            }
            else if(tags != null)
            {
                var moduleUpdateParameters = new AutomationManagement.Models.ModuleUpdateParameters();
                
                moduleUpdateParameters.Name = name;
                moduleUpdateParameters.Tags = tags.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());
                moduleUpdateParameters.Properties = new ModuleUpdateProperties();

                this.automationManagementClient.Modules.Update(automationAccountName, moduleUpdateParameters);
            }

            var updatedModule = this.automationManagementClient.Modules.Get(automationAccountName, name).Module;
            return new Module(automationAccountName, updatedModule);
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
        public IEnumerable<JobStream> GetJobStream(string automationAccountName, Guid jobId, DateTimeOffset? time,
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

        public IEnumerable<Job> ListJobsByRunbookName(string automationAccountName, string runbookName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus)
        {
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
                                Status = jobStatus,
                                RunbookName = runbookName
                            });
                        return new ResponseWithSkipToken<AutomationManagement.Models.Job>(response, response.Jobs);
                    });
            }

            return jobModels.Select(jobModel => new Job(automationAccountName, jobModel));
        }

        public IEnumerable<Job> ListJobs(string automationAccountName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus)
        {
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
                            new AutomationManagement.Models.JobListParameters { Status = jobStatus });
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

        #region Account Operations

        public IEnumerable<AutomationAccount> ListAutomationAccounts(string automationAccountName, string location)
        {
            if (automationAccountName != null)
            {
                Requires.Argument("AutomationAccountName", automationAccountName).ValidAutomationAccountName();
            }

            var automationAccounts = new List<AutomationAccount>();
            var cloudServices = new List<CloudService>(this.automationManagementClient.CloudServices.List().CloudServices);

            foreach (var cloudService in cloudServices)
            {
                automationAccounts.AddRange(cloudService.Resources.Select(resource => new AutomationAccount(cloudService, resource)));
            }

            // RDFE does not support server-side filtering, hence we filter on the client-side.
            if (automationAccountName != null)
            {
                automationAccounts = automationAccounts.Where(account => string.Equals(account.AutomationAccountName, automationAccountName, StringComparison.OrdinalIgnoreCase)).ToList();

                if (!automationAccounts.Any())
                {
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.AutomationAccountNotFound));
                }
            }

            if (location != null)
            {
                automationAccounts = automationAccounts.Where(account => string.Equals(account.Location, location, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return automationAccounts;
        }

        public AutomationAccount CreateAutomationAccount(string automationAccountName, string location)
        {

            Requires.Argument("AutomationAccountName", automationAccountName).ValidAutomationAccountName();

            try
            {
                var existingAccount = this.ListAutomationAccounts(automationAccountName, location);

                if (existingAccount != null)
                {
                    throw new ResourceCommonException(typeof (AutomationAccount),
                        string.Format(CultureInfo.CurrentCulture, Resources.AutomationAccountAlreadyExists,
                            automationAccountName));
                }
            }
            catch (ArgumentException)
            {
                // ArgumentException is thrown when account does not exists, so ignore it
            }

            this.automationManagementClient.CreateAutomationAccount(automationAccountName, location);

            return this.ListAutomationAccounts(automationAccountName, location).FirstOrDefault();
        }


        public void DeleteAutomationAccount(string automationAccountName)
        {
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            var csName = string.Empty;

            var cloudServices = this.automationManagementClient.CloudServices.List().CloudServices;

            foreach (var cloudService in cloudServices)
            {
                if (cloudService.Resources.Any(resource => 0 == String.Compare(resource.Name, automationAccountName, CultureInfo.InvariantCulture,
                    CompareOptions.IgnoreCase)))
                {
                    csName = cloudService.Name;
                    break;
                }
            }

            this.automationManagementClient.AutomationAccounts.Delete(csName, automationAccountName);
        }

        #endregion

        #region Certificate Operations

        public CertificateInfo CreateCertificate(string automationAccountName, string name, string path, SecureString password,
            string description, bool exportable)
        {
            var certificateModel = this.TryGetCertificateModel(automationAccountName, name);
            if (certificateModel != null)
            {
                throw new ResourceCommonException(typeof(CertificateInfo),
                    string.Format(CultureInfo.CurrentCulture, Resources.CertificateAlreadyExists, name));
            }

            return CreateCertificateInternal(automationAccountName, name, path, password, description, exportable);
        }


        public CertificateInfo UpdateCertificate(string automationAccountName, string name, string path, SecureString password,
            string description, bool? exportable)
        {
            if (String.IsNullOrWhiteSpace(path) && password != null && exportable.HasValue)
            {
                throw new ResourceCommonException(typeof(CertificateInfo),
                    string.Format(CultureInfo.CurrentCulture, Resources.SetCertificateInvalidArgs, name));
            }

            var certificateModel = this.TryGetCertificateModel(automationAccountName, name);
            if (certificateModel == null)
            {
                throw new ResourceCommonException(typeof(CertificateInfo),
                    string.Format(CultureInfo.CurrentCulture, Resources.CertificateNotFound, name));
            }
            
            var createOrUpdateDescription  = description ?? certificateModel.Properties.Description;
            var createOrUpdateIsExportable = (exportable.HasValue) ? exportable.Value : certificateModel.Properties.IsExportable;

            if (path != null)
            {
                return this.CreateCertificateInternal(automationAccountName, name, path, password, createOrUpdateDescription,
                    createOrUpdateIsExportable);
            }

            var cuparam = new CertificateUpdateParameters() 
            { 
                Name = name, 
                Properties = new CertificateUpdateProperties()
                {
                    Description = createOrUpdateDescription,
                    IsExportable = createOrUpdateIsExportable
                } 
            };

            this.automationManagementClient.Certificates.Update(automationAccountName, cuparam);

            return new CertificateInfo(automationAccountName, this.automationManagementClient.Certificates.Get(automationAccountName, name).Certificate);
        }

        public CertificateInfo GetCertificate(string automationAccountName, string name)
        {
            var certificateModel = this.TryGetCertificateModel(automationAccountName, name);
            if (certificateModel == null)
            {
                throw new ResourceCommonException(typeof(CertificateInfo),
                    string.Format(CultureInfo.CurrentCulture, Resources.CertificateNotFound, name));
            }

            return new Certificate(automationAccountName, certificateModel);
        }

        public IEnumerable<CertificateInfo> ListCertificates(string automationAccountName)
        {
            return AutomationManagementClient
               .ContinuationTokenHandler(
                   skipToken =>
                   {
                       var response = this.automationManagementClient.Certificates.List(
                           automationAccountName);
                       return new ResponseWithSkipToken<AutomationManagement.Models.Certificate>(
                           response, response.Certificates);
                   }).Select(c => new CertificateInfo(automationAccountName, c));
        }

        public void DeleteCertificate(string automationAccountName, string name)
        {
            this.automationManagementClient.Certificates.Delete(automationAccountName, name);
        }

        #endregion 

        #region Connection Operations

        public Connection CreateConnection(string automationAccountName, string name, string connectionTypeName, IDictionary connectionFieldValues,
            string description)
        {
            var connectionModel = this.TryGetConnectionModel(automationAccountName, name);
            if (connectionModel != null)
            {
                throw new ResourceCommonException(typeof(Connection),
                    string.Format(CultureInfo.CurrentCulture, Resources.ConnectionAlreadyExists, name));
            }

            var ccprop = new ConnectionCreateProperties()
            {
                Description = description,
                ConnectionType = new ConnectionTypeAssociationProperty() { Name = connectionTypeName },
                FieldDefinitionValues = connectionFieldValues.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString())
            };

            var ccparam = new ConnectionCreateParameters() { Name = name, Properties = ccprop };

            var connection = this.automationManagementClient.Connections.Create(automationAccountName, ccparam).Connection;

            return new Connection(automationAccountName, connection);
        }

        public Connection UpdateConnectionFieldValue(string automationAccountName, string name, string connectionFieldName, object value)
        {
            var connectionModel = this.TryGetConnectionModel(automationAccountName, name);
            if (connectionModel == null)
            {
                throw new ResourceCommonException(typeof(Connection),
                    string.Format(CultureInfo.CurrentCulture, Resources.ConnectionNotFound, name));
            }

            if (connectionModel.Properties.FieldDefinitionValues.ContainsKey(connectionFieldName))
            {
                connectionModel.Properties.FieldDefinitionValues[connectionFieldName] =
                    JsonConvert.SerializeObject(value,
                        new JsonSerializerSettings() {DateFormatHandling = DateFormatHandling.MicrosoftDateFormat});
            }
            else
            {
                throw new ResourceCommonException(typeof(Connection),
                   string.Format(CultureInfo.CurrentCulture, Resources.ConnectionFieldNameNotFound, name));
            }

            var cuparam = new ConnectionUpdateParameters()
            {
                Name = name,
                Properties = new ConnectionUpdateProperties()
                {
                    Description = connectionModel.Properties.Description,
                    FieldDefinitionValues = connectionModel.Properties.FieldDefinitionValues
                }
            };

            this.automationManagementClient.Connections.Update(automationAccountName, cuparam);

            return new Connection(automationAccountName, this.automationManagementClient.Connections.Get(automationAccountName, name).Connection);
        }

        public Connection GetConnection(string automationAccountName, string name)
        {
            var connectionModel = this.TryGetConnectionModel(automationAccountName, name);
            if (connectionModel == null)
            {
                throw new ResourceCommonException(typeof(Connection),
                    string.Format(CultureInfo.CurrentCulture, Resources.ConnectionNotFound, name));
            }

            return new Connection(automationAccountName, connectionModel);
        }

        public IEnumerable<Connection> ListConnectionsByType(string automationAccountName, string typeName)
        {
            var connections = this.ListConnections(automationAccountName);

            return connections.Where(c => c.ConnectionTypeName.Equals(typeName, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<Connection> ListConnections(string automationAccountName)
        {
            return AutomationManagementClient
               .ContinuationTokenHandler(
                   skipToken =>
                   {
                       var response = this.automationManagementClient.Connections.List(
                           automationAccountName);
                       return new ResponseWithSkipToken<AutomationManagement.Models.Connection>(
                           response, response.Connection);
                   }).Select(c => new Connection(automationAccountName, c));
        }

        public void DeleteConnection(string automationAccountName, string name)
        {
            this.automationManagementClient.Connections.Delete(automationAccountName, name);
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
                    jobSchedule = this.GetJobSchedule(automationAccountName, new Guid(js.JobScheduleId));
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
                            automationAccountName);

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
                    this.UnregisterScheduledRunbook(automationAccountName, new Guid(jobSchedule.JobScheduleId));
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

        private Management.Automation.Models.Certificate TryGetCertificateModel(string automationAccountName, string certificateName)
        {
            Management.Automation.Models.Certificate certificate = null;
            try
            {
                certificate = this.automationManagementClient.Certificates.Get(automationAccountName, certificateName).Certificate;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    certificate = null;
                }
                else
                {
                    throw;
                }
            }
            return certificate;
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

        private string FormatDateTime(DateTimeOffset dateTime)
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

        private Certificate CreateCertificateInternal(string automationAccountName, string name, string path,
            SecureString password, string description, bool exportable)
        {
            var cert = (password == null)
                ? new X509Certificate2(path)
                : new X509Certificate2(path, password);

            var ccprop = new CertificateCreateProperties()
            {
                Description = description,
                Base64Value = Convert.ToBase64String(cert.Export(X509ContentType.Pkcs12)),
                Thumbprint = cert.Thumbprint,
                IsExportable = exportable
            };

            var ccparam = new CertificateCreateParameters() { Name = name, Properties = ccprop };

            var certificate = this.automationManagementClient.Certificates.Create(automationAccountName, ccparam).Certificate;

            return new Certificate(automationAccountName, certificate);
        }

        private Management.Automation.Models.Connection TryGetConnectionModel(string automationAccountName, string connectionName)
        {
            Management.Automation.Models.Connection connection = null;
            try
            {
                connection = this.automationManagementClient.Connections.Get(automationAccountName, connectionName).Connection;
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    connection = null;
                }
                else
                {
                    throw;
                }
            }
            return connection;
        }

        #endregion
    }
}