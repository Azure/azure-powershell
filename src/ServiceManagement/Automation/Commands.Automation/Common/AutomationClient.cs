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
using Microsoft.WindowsAzure.Management.Automation;
using Microsoft.WindowsAzure.Management.Automation.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Commands.Common.Authentication.Models;
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
    using AutomationManagement = WindowsAzure.Management.Automation;
    using Microsoft.Azure.Commands.Common.Authentication;
    using Hyak.Common;


    public class AutomationClient : IAutomationClient
    {
        private readonly AutomationManagement.IAutomationManagementClient automationManagementClient;

        // Injection point for unit tests
        public AutomationClient()
        {
        }

        public AutomationClient(AzureSMProfile profile, AzureSubscription subscription)
            : this(subscription,
            AzureSession.ClientFactory.CreateClient<AutomationManagement.AutomationManagementClient>(profile, subscription, AzureEnvironment.Endpoint.ServiceManagement))
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
                if (cloudException.Response.StatusCode == HttpStatusCode.NoContent)
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

        public IEnumerable<Schedule> ListSchedules(string automationAccountName, ref string nextLink)
        {
            ScheduleListResponse response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Schedules.List(
                    automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.Schedules.ListNext(nextLink);
            }

            nextLink = response.NextLink;
            return response.Schedules.Select(c => new Schedule(automationAccountName, c));
        }

        public Schedule UpdateSchedule(string automationAccountName, string scheduleName, bool? isEnabled, string description)
        {
            AutomationManagement.Models.Schedule scheduleModel = this.GetScheduleModel(automationAccountName,
                scheduleName);
            isEnabled = (isEnabled.HasValue) ? isEnabled : scheduleModel.Properties.IsEnabled;
            description = description ?? scheduleModel.Properties.Description;
            return this.UpdateScheduleHelper(automationAccountName, scheduleName, isEnabled, description);
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

        public IEnumerable<Runbook> ListRunbooks(string automationAccountName, ref string nextLink)
        {
            RunbookListResponse response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Runbooks.List(
                    automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.Runbooks.ListNext(nextLink);
            }

            nextLink = response.NextLink;
            return response.Runbooks.Select(c => new Runbook(automationAccountName, c));
        }

        public Runbook CreateRunbookByName(string automationAccountName, string runbookName, string description,
            string[] tags)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var runbookModel = this.TryGetRunbookModel(automationAccountName, runbookName);
                if (runbookModel != null)
                {
                    throw new ResourceCommonException(typeof (Runbook),
                        string.Format(CultureInfo.CurrentCulture, Resources.RunbookAlreadyExists, runbookName));
                }

                var rdcprop = new RunbookCreateDraftProperties()
                {
                    Description = description,
                    RunbookType = RunbookTypeEnum.Script,
                    Draft = new RunbookDraft(),
                    ServiceManagementTags =
                        (tags != null) ? string.Join(Constants.RunbookTagsSeparatorString, tags) : null
                };

                var rdcparam = new RunbookCreateDraftParameters()
                {
                    Name = runbookName,
                    Properties = rdcprop,
                    Tags = null
                };

                this.automationManagementClient.Runbooks.CreateWithDraft(automationAccountName, rdcparam);

                return this.GetRunbook(automationAccountName, runbookName);
           }
        }

        public Runbook CreateRunbookByPath(string automationAccountName, string runbookPath, string description,
            string[] tags)
        {

            var runbookName = Path.GetFileNameWithoutExtension(runbookPath);

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var runbookModel = this.TryGetRunbookModel(automationAccountName, runbookName);
                if (runbookModel != null)
                {
                    throw new ResourceCommonException(typeof (Runbook),
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
        }

        public void DeleteRunbook(string automationAccountName, string runbookName)
        {
            try
            {
                using (var request = new RequestSettings(this.automationManagementClient))
                {
                    this.automationManagementClient.Runbooks.Delete(automationAccountName, runbookName);
                }
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(Connection), string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
                }

                throw;
            }

        }

        public Runbook UpdateRunbook(string automationAccountName, string runbookName, string description,
            string[] tags, bool? logProgress, bool? logVerbose)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var runbookModel = this.TryGetRunbookModel(automationAccountName, runbookName);
                if (runbookModel == null)
                {
                    throw new ResourceCommonException(typeof (Runbook),
                        string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
                }

                var runbookUpdateParameters = new RunbookUpdateParameters();
                runbookUpdateParameters.Name = runbookName;
                runbookUpdateParameters.Tags = null;

                runbookUpdateParameters.Properties = new RunbookUpdateProperties();
                runbookUpdateParameters.Properties.Description = description ?? runbookModel.Properties.Description;
                runbookUpdateParameters.Properties.LogProgress = (logProgress.HasValue)
                    ? logProgress.Value
                    : runbookModel.Properties.LogProgress;
                runbookUpdateParameters.Properties.LogVerbose = (logVerbose.HasValue)
                    ? logVerbose.Value
                    : runbookModel.Properties.LogVerbose;
                runbookUpdateParameters.Properties.ServiceManagementTags = (tags != null)
                    ? string.Join(Constants.RunbookTagsSeparatorString, tags)
                    : runbookModel.Properties.ServiceManagementTags;

                var runbook =
                    this.automationManagementClient.Runbooks.Update(automationAccountName, runbookUpdateParameters)
                        .Runbook;

                return new Runbook(automationAccountName, runbook);
            }
        }

        public RunbookDefinition UpdateRunbookDefinition(string automationAccountName, string runbookName,
            string runbookPath, bool overwrite)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var runbook = this.TryGetRunbookModel(automationAccountName, runbookName);
                if (runbook == null)
                {
                    throw new ResourceNotFoundException(typeof (Runbook),
                        string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
                }

                if ((0 !=
                     String.Compare(runbook.Properties.State, RunbookState.Published, CultureInfo.InvariantCulture,
                         CompareOptions.IgnoreCase) && overwrite == false))
                {
                    throw new ResourceCommonException(typeof (Runbook),
                        string.Format(CultureInfo.CurrentCulture, Resources.RunbookAlreadyHasDraft, runbookName));
                }

                this.automationManagementClient.RunbookDraft.Update(automationAccountName,
                    new RunbookDraftUpdateParameters {Name = runbookName, Stream = File.ReadAllText(runbookPath)});

                var content =
                    this.automationManagementClient.RunbookDraft.Content(automationAccountName, runbookName).Stream;

                return new RunbookDefinition(automationAccountName, runbook, content, Constants.Draft);
            }
        }

        public IEnumerable<RunbookDefinition> ListRunbookDefinitionsByRunbookName(string automationAccountName,
            string runbookName, bool? isDraft)
        {
            var ret = new List<RunbookDefinition>();
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var runbook = this.TryGetRunbookModel(automationAccountName, runbookName);
                if (runbook == null)
                {
                    throw new ResourceNotFoundException(typeof (Runbook),
                        string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
                }

                var draftContent = String.Empty;
                var publishedContent = String.Empty;

                if (0 !=
                    String.Compare(runbook.Properties.State, RunbookState.Published, CultureInfo.InvariantCulture,
                        CompareOptions.IgnoreCase) && (!isDraft.HasValue || isDraft.Value))
                {
                    draftContent =
                        this.automationManagementClient.RunbookDraft.Content(automationAccountName, runbookName).Stream;
                }
                if (0 !=
                    String.Compare(runbook.Properties.State, RunbookState.New, CultureInfo.InvariantCulture,
                        CompareOptions.IgnoreCase) && (!isDraft.HasValue || !isDraft.Value))
                {
                    publishedContent =
                        this.automationManagementClient.Runbooks.Content(automationAccountName, runbookName).Stream;
                }

                // if no slot specified return both draft and publish content
                if (false == isDraft.HasValue)
                {
                    if (false == String.IsNullOrEmpty(draftContent))
                        ret.Add(new RunbookDefinition(automationAccountName, runbook, draftContent, Constants.Draft));
                    if (false == String.IsNullOrEmpty(publishedContent))
                        ret.Add(new RunbookDefinition(automationAccountName, runbook, publishedContent,
                            Constants.Published));
                }
                else
                {
                    if (true == isDraft.Value)
                    {

                        if (String.IsNullOrEmpty(draftContent))
                            throw new ResourceCommonException(typeof (Runbook),
                                string.Format(CultureInfo.CurrentCulture, Resources.RunbookHasNoDraftVersion,
                                    runbookName));
                        if (false == String.IsNullOrEmpty(draftContent))
                            ret.Add(new RunbookDefinition(automationAccountName, runbook, draftContent, Constants.Draft));
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(publishedContent))
                            throw new ResourceCommonException(typeof (Runbook),
                                string.Format(CultureInfo.CurrentCulture, Resources.RunbookHasNoPublishedVersion,
                                    runbookName));

                        if (false == String.IsNullOrEmpty(publishedContent))
                            ret.Add(new RunbookDefinition(automationAccountName, runbook, publishedContent,
                                Constants.Published));
                    }
                }

                return ret;
            }
        }

        public Runbook PublishRunbook(string automationAccountName, string runbookName)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
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

        }

        public Job StartRunbook(string automationAccountName, string runbookName, IDictionary parameters, string runOn)
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
                                            RunOn = String.IsNullOrWhiteSpace(runOn) ? null : runOn, 
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

            var createParams = new AutomationManagement.Models.VariableCreateParameters()
            {
                Name = variable.Name,
                Properties = new AutomationManagement.Models.VariableCreateProperties()
                {
                    Value = PowerShellJsonConverter.Serialize(variable.Value),
                    Description = variable.Description,
                    IsEncrypted = variable.Encrypted
                }
            };

            var sdkCreatedVariable =
                this.automationManagementClient.Variables.Create(variable.AutomationAccountName, createParams).Variable;

            return new Variable(sdkCreatedVariable, variable.AutomationAccountName);
        }

        public void DeleteVariable(string automationAccountName, string variableName)
        {
            try
            {
                this.automationManagementClient.Variables.Delete(automationAccountName, variableName);
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(Variable),
                        string.Format(CultureInfo.CurrentCulture, Resources.VariableNotFound, variableName));
                }

                throw;
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
                    Value = PowerShellJsonConverter.Serialize(variable.Value)
                };
            }

            this.automationManagementClient.Variables.Update(variable.AutomationAccountName, updateParams);
            
            return this.GetVariable(variable.AutomationAccountName, variable.Name);
        }

        public Variable GetVariable(string automationAccountName, string name)
        {
            try
            {
                var sdkVarible = this.automationManagementClient.Variables.Get(automationAccountName, name).Variable;

                if (sdkVarible != null)
                {
                    return new Variable(sdkVarible, automationAccountName);
                }

                throw new ResourceNotFoundException(typeof(Variable),
                    string.Format(CultureInfo.CurrentCulture, Resources.VariableNotFound, name));
            }
            catch (CloudException)
            {
                throw new ResourceNotFoundException(typeof(Variable),
                    string.Format(CultureInfo.CurrentCulture, Resources.VariableNotFound, name));
            }
        }

        public IEnumerable<Variable> ListVariables(string automationAccountName, ref string nextLink)
        {
            VariableListResponse response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Variables.List(
                    automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.Variables.ListNext(nextLink);
            }

            nextLink = response.NextLink;
            return response.Variables.Select(c => new Variable(c, automationAccountName));
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
            var exisitngCredential = this.GetCredential(automationAccountName, name);
            var credentialUpdateParams = new AutomationManagement.Models.CredentialUpdateParameters();
            credentialUpdateParams.Name = name;
            credentialUpdateParams.Properties = new AutomationManagement.Models.CredentialUpdateProperties();
            credentialUpdateParams.Properties.Description = description ?? exisitngCredential.Description;

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

        public IEnumerable<Credential> ListCredentials(string automationAccountName, ref string nextLink)
        {
            CredentialListResponse response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.PsCredentials.List(
                    automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.PsCredentials.ListNext(nextLink);
            }

            nextLink = response.NextLink;
            return response.Credentials.Select(c => new Credential(automationAccountName, c));
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
                    throw new ResourceNotFoundException(typeof(Credential), string.Format(CultureInfo.CurrentCulture, Resources.CredentialNotFound, name));
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
            try
            {
                var module = this.automationManagementClient.Modules.Get(automationAccountName, name).Module;
                return new Module(automationAccountName, module);
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Module), string.Format(CultureInfo.CurrentCulture, Resources.ModuleNotFound, name));
                }

                throw;
            }
        }

        public IEnumerable<Module> ListModules(string automationAccountName, ref string nextLink)
        {
            ModuleListResponse response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Modules.List(
                    automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.Modules.ListNext(nextLink);
            }

            nextLink = response.NextLink;
            return response.Modules.Select(c => new Module(automationAccountName, c));
        }

        public Module UpdateModule(string automationAccountName, IDictionary tags, string name, Uri contentLinkUri, string contentLinkVersion)
        {
            var moduleModel = this.automationManagementClient.Modules.Get(automationAccountName, name).Module;
            if(tags != null && contentLinkUri != null)
            {
                var moduleCreateParameters = new AutomationManagement.Models.ModuleCreateParameters();
                
                moduleCreateParameters.Name = name;
                moduleCreateParameters.Tags = tags.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());

                moduleCreateParameters.Properties = new ModuleCreateProperties();
                moduleCreateParameters.Properties.ContentLink = new AutomationManagement.Models.ContentLink();
                moduleCreateParameters.Properties.ContentLink.Uri = contentLinkUri;
                moduleCreateParameters.Properties.ContentLink.Version =
                    (String.IsNullOrWhiteSpace(contentLinkVersion))
                        ? Guid.NewGuid().ToString()
                        : contentLinkVersion;

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
                moduleUpdateParameters.Properties.ContentLink.Version =
                    (String.IsNullOrWhiteSpace(contentLinkVersion))
                        ? Guid.NewGuid().ToString()
                        : contentLinkVersion;

                moduleUpdateParameters.Tags = moduleModel.Tags;

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
                if (cloudException.Response.StatusCode == HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(Module), string.Format(CultureInfo.CurrentCulture, Resources.ModuleNotFound, name));
                }

                throw;
            }
        }

        #endregion

        #region Jobs
        public IEnumerable<JobStream> GetJobStream(string automationAccountName, Guid jobId, DateTimeOffset? time,
           string streamType, ref string nextLink)
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

            JobStreamListResponse response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.JobStreams.List(automationAccountName, jobId, listParams);
            }
            else
            {
                response = this.automationManagementClient.JobStreams.ListNext(nextLink);
            }

            nextLink = response.NextLink;
            return response.JobStreams.Select(stream => this.CreateJobStreamFromJobStreamModel(stream, automationAccountName, jobId));
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

        public IEnumerable<Job> ListJobsByRunbookName(string automationAccountName, string runbookName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus, ref string nextLink)
        {
            JobListResponse response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Jobs.List(
                    automationAccountName,
                    new JobListParameters
                    {
                        StartTime = (startTime.HasValue) ? FormatDateTime(startTime.Value) : null,
                        EndTime = (endTime.HasValue) ? FormatDateTime(endTime.Value) : null,
                        RunbookName = runbookName,
                        Status = jobStatus,
                    });
            }
            else
            {
                response = this.automationManagementClient.Jobs.ListNext(nextLink);
            }

            nextLink = response.NextLink;
            return response.Jobs.Select(c => new Job(automationAccountName, c));
        }

        public IEnumerable<Job> ListJobs(string automationAccountName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus, ref string nextLink)
        {
            JobListResponse response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Jobs.List(
                    automationAccountName,
                    new JobListParameters
                                {
                                    StartTime = (startTime.HasValue) ? FormatDateTime(startTime.Value) : null,
                                    EndTime = (endTime.HasValue) ? FormatDateTime(endTime.Value) : null,
                                    Status = jobStatus,
                                });
            }
            else
            {
                response = this.automationManagementClient.Jobs.ListNext(nextLink);
            }

            nextLink = response.NextLink;
            return response.Jobs.Select(c => new Job(automationAccountName, c));
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

            try
            {
                this.automationManagementClient.CreateAutomationAccount(automationAccountName, location);
            }
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ResourceCommonException(typeof (AutomationAccount),
                        string.Format(CultureInfo.CurrentCulture, Resources.AccountCreateInvalidArgs,
                            automationAccountName, location));
                }
                throw;
            }

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
            if (String.IsNullOrWhiteSpace(path) && (password != null || exportable.HasValue))
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

        public IEnumerable<CertificateInfo> ListCertificates(string automationAccountName, ref string nextLink)
        {
            CertificateListResponse response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Certificates.List(
                    automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.Certificates.ListNext(nextLink);
            }

            nextLink = response.NextLink;
            return response.Certificates.Select(c => new CertificateInfo(automationAccountName, c));
        }

        public void DeleteCertificate(string automationAccountName, string name)
        {
            try
            {
                this.automationManagementClient.Certificates.Delete(automationAccountName, name);
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(Schedule), string.Format(CultureInfo.CurrentCulture, Resources.CertificateNotFound, name));
                }

                throw;
            }
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
                    PowerShellJsonConverter.Serialize(value);
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
            var connections = new List<Connection>();
            string nextLink = string.Empty;

            do
            {
                connections.AddRange(this.ListConnections(automationAccountName, ref nextLink));

            } while (!string.IsNullOrEmpty(nextLink));

            return connections.Where(c => c.ConnectionTypeName.Equals(typeName, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<Connection> ListConnections(string automationAccountName, ref string nextLink)
        {
            ConnectionListResponse response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Connections.List(
                    automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.Connections.ListNext(nextLink);
            }

            nextLink = response.NextLink;
            return response.Connection.Select(c => new Connection(automationAccountName, c));
        }

        public void DeleteConnection(string automationAccountName, string name)
        {
            try
            {
                this.automationManagementClient.Connections.Delete(automationAccountName, name);
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(Connection), string.Format(CultureInfo.CurrentCulture, Resources.ConnectionNotFound, name));
                }

                throw;
            }
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
            const bool jobScheduleFound = false;
            var nextLink = string.Empty;

            do
            {
                var schedules = this.ListJobSchedules(automationAccountName, ref nextLink);
                var jobSchedule = schedules.FirstOrDefault(js => String.Equals(js.RunbookName, runbookName, StringComparison.OrdinalIgnoreCase) &&
                                                                 String.Equals(js.ScheduleName, scheduleName, StringComparison.OrdinalIgnoreCase));

                if (jobSchedule != null)
                {
                    this.GetJobSchedule(automationAccountName, new Guid(jobSchedule.JobScheduleId));
                    return jobSchedule;
                }

            } while (!string.IsNullOrEmpty(nextLink));

            if (!jobScheduleFound)
            {
                throw new ResourceNotFoundException(typeof(Schedule),
                        string.Format(CultureInfo.CurrentCulture, Resources.JobScheduleNotFound, runbookName, scheduleName));
            }
        }

        public IEnumerable<JobSchedule> ListJobSchedules(string automationAccountName, ref string nextLink)
        {
            JobScheduleListResponse response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.JobSchedules.List(
                    automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.JobSchedules.ListNext(nextLink);
            }

            nextLink = response.NextLink;
            return response.JobSchedules.Select(c => new JobSchedule(automationAccountName, c));
        }

        public IEnumerable<JobSchedule> ListJobSchedulesByRunbookName(string automationAccountName, string runbookName)
        {
            var jobSchedulesOfRunbook = new List<JobSchedule>();
            var nextLink = string.Empty;

            do
            {
                var schedules = this.ListJobSchedules(automationAccountName, ref nextLink);
                jobSchedulesOfRunbook.AddRange(schedules.Where(js => String.Equals(js.RunbookName, runbookName, StringComparison.OrdinalIgnoreCase)));

            } while (!string.IsNullOrEmpty(nextLink));

            return jobSchedulesOfRunbook;
        }

        public IEnumerable<JobSchedule> ListJobSchedulesByScheduleName(string automationAccountName, string scheduleName)
        {
            var jobSchedulesOfSchedules = new List<JobSchedule>();
            var nextLink = string.Empty;

            do
            {
                var schedules = this.ListJobSchedules(automationAccountName, ref nextLink);
                jobSchedulesOfSchedules.AddRange(schedules.Where(js => String.Equals(js.ScheduleName, scheduleName, StringComparison.OrdinalIgnoreCase)));

            } while (!string.IsNullOrEmpty(nextLink));

            return jobSchedulesOfSchedules;
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
            const bool jobScheduleFound = false;
            var nextLink = string.Empty;

            do
            {
                var schedules = this.ListJobSchedules(automationAccountName, ref nextLink);
                var jobSchedule = schedules.FirstOrDefault(js => String.Equals(js.RunbookName, runbookName, StringComparison.OrdinalIgnoreCase) &&
                                                                 String.Equals(js.ScheduleName, scheduleName, StringComparison.OrdinalIgnoreCase));

                if (jobSchedule != null)
                {
                    this.UnregisterScheduledRunbook(automationAccountName, new Guid(jobSchedule.JobScheduleId));
                    return;
                }

            } while (!string.IsNullOrEmpty(nextLink));

            if (!jobScheduleFound)
            {
                throw new ResourceNotFoundException(typeof(Schedule),
                        string.Format(CultureInfo.CurrentCulture, Resources.JobScheduleNotFound, runbookName, scheduleName));
            }
        }

        #endregion

        #region ConnectionType

        public void DeleteConnectionType(string automationAccountName, string name)
        {
            try
            {
                this.automationManagementClient.ConnectionTypes.Delete(automationAccountName, name);
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(ConnectionType),
                        string.Format(CultureInfo.CurrentCulture, Resources.ConnectionTypeNotFound, name));
                }

                throw;
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

        private WindowsAzure.Management.Automation.Models.Runbook TryGetRunbookModel(string automationAccountName, string runbookName)
        {
            WindowsAzure.Management.Automation.Models.Runbook runbook = null;
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

        private WindowsAzure.Management.Automation.Models.Certificate TryGetCertificateModel(string automationAccountName, string certificateName)
        {
            WindowsAzure.Management.Automation.Models.Certificate certificate = null;
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

        private IEnumerable<KeyValuePair<string, RunbookParameter>> ListRunbookParameters(string automationAccountName, string runbookName)
        {
            Runbook runbook = this.GetRunbook(automationAccountName, runbookName);
            if (0 == String.Compare(runbook.State, RunbookState.New, CultureInfo.InvariantCulture,
                     CompareOptions.IgnoreCase))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.RunbookHasNoPublishedVersion, runbookName));
            }
            return runbook.Parameters.Cast<DictionaryEntry>().ToDictionary(k => k.Key.ToString(), k => (RunbookParameter)k.Value);
        }

        private IDictionary<string, string> ProcessRunbookParameters(string automationAccountName, string runbookName, IDictionary parameters)
        {
            parameters = parameters ?? new Dictionary<string, string>();
            IEnumerable<KeyValuePair<string, RunbookParameter>> runbookParameters = this.ListRunbookParameters(automationAccountName, runbookName);
            var filteredParameters = new Dictionary<string, string>();

            foreach (var runbookParameter in runbookParameters)
            {
                if (parameters.Contains(runbookParameter.Key))
                {
                    object paramValue = parameters[runbookParameter.Key];
                    try
                    {
                        filteredParameters.Add(runbookParameter.Key, PowerShellJsonConverter.Serialize(paramValue));
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
                filteredParameters.Add(Constants.JobStartedByParameterName, PowerShellJsonConverter.Serialize(Constants.ClientIdentity));
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
            string scheduleName, bool? isEnabled, string description)
        {
            var scheduleUpdateParameters = new AutomationManagement.Models.ScheduleUpdateParameters
            {
                Name = scheduleName,
                Properties = new AutomationManagement.Models.ScheduleUpdateProperties
                {
                    Description = description,
                    IsEnabled = isEnabled
                }
            };

            this.automationManagementClient.Schedules.Update(
                automationAccountName,
                scheduleUpdateParameters);

            return this.GetSchedule(automationAccountName, scheduleName);
        }

        private Certificate CreateCertificateInternal(string automationAccountName, string name, string path,
            SecureString password, string description, bool exportable)
        {
            var cert = (password == null)
                ? new X509Certificate2(path, String.Empty, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet)
                : new X509Certificate2(path, password, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);

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

        private WindowsAzure.Management.Automation.Models.Connection TryGetConnectionModel(string automationAccountName, string connectionName)
        {
            WindowsAzure.Management.Automation.Models.Connection connection = null;
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