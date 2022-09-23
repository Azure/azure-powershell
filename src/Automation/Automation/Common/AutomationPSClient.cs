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

using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime;
using Microsoft.Rest.ClientRuntime.Azure;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using AutomationAccount = Microsoft.Azure.Commands.Automation.Model.AutomationAccount;
using AutomationManagement = Microsoft.Azure.Management.Automation;
using Certificate = Microsoft.Azure.Commands.Automation.Model.CertificateInfo;
using Connection = Microsoft.Azure.Commands.Automation.Model.Connection;
using Credential = Microsoft.Azure.Commands.Automation.Model.CredentialInfo;
using Job = Microsoft.Azure.Commands.Automation.Model.Job;
using JobSchedule = Microsoft.Azure.Commands.Automation.Model.JobSchedule;
using JobStream = Microsoft.Azure.Commands.Automation.Model.JobStream;
using Module = Microsoft.Azure.Commands.Automation.Model.Module;
using Runbook = Microsoft.Azure.Commands.Automation.Model.Runbook;
using Schedule = Microsoft.Azure.Commands.Automation.Model.Schedule;
using Variable = Microsoft.Azure.Commands.Automation.Model.Variable;
using HybridRunbookWorkerGroup = Microsoft.Azure.Commands.Automation.Model.HybridRunbookWorkerGroup;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;

namespace Microsoft.Azure.Commands.Automation.Common
{
    public partial class AutomationPSClient : IAutomationPSClient
    {
        private readonly AutomationManagement.IAutomationClient automationManagementClient;

        // Injection point for unit tests
        public AutomationPSClient()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AutomationPSClient(IAzureContext context)
            : this(context.Subscription,
                AzureSession.Instance.ClientFactory.CreateArmClient<AutomationManagement.AutomationClient>(context,
                    AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public AutomationPSClient(IAzureSubscription subscription,
            AutomationManagement.IAutomationClient automationManagementClient)
        {
            Requires.Argument("automationManagementClient", automationManagementClient).NotNull();

            this.Subscription = subscription;
            this.automationManagementClient = automationManagementClient;
        }

        private void SetClientIdHeader(string clientRequestId)
        {
            var client = ((AutomationManagement.AutomationClient)this.automationManagementClient);
            client.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            client.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);
        }

        public IAzureSubscription Subscription { get; private set; }

        #region Account Operations

        public IEnumerable<Model.AutomationAccount> ListAutomationAccounts(string resourceGroupName, ref string nextLink)
        {
            Rest.Azure.IPage<AutomationManagement.Models.AutomationAccount> response;
            if(!string.IsNullOrWhiteSpace(resourceGroupName))
            {
                if(string.IsNullOrWhiteSpace(nextLink))
                {
                    response = this.automationManagementClient.AutomationAccount.ListByResourceGroup(resourceGroupName);
                }
                else
                {
                    response = this.automationManagementClient.AutomationAccount.ListByResourceGroupNext(nextLink);
                }
                
            }
            else
            {
                if (string.IsNullOrWhiteSpace(nextLink))
                {
                    response = this.automationManagementClient.AutomationAccount.List();
                }
                else
                {
                    response = this.automationManagementClient.AutomationAccount.ListNext(nextLink);
                }
            }

            nextLink = response.NextPageLink;
            return response.Select(c => new AutomationAccount(resourceGroupName, c));
        }

        public AutomationAccount GetAutomationAccount(string resourceGroupName, string automationAccountName)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            try
            {
                var account = this.automationManagementClient.AutomationAccount.Get(resourceGroupName, automationAccountName);
                return new Model.AutomationAccount(resourceGroupName, account);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(AutomationAccount),
                        string.Format(CultureInfo.CurrentCulture, Resources.AutomationAccountNotFound,
                            automationAccountName));
                }

                throw;
            }
        }

        public AutomationAccount CreateAutomationAccount(string resourceGroupName, string automationAccountName,
            string location, string plan, IDictionary tags, bool addSystemId, string[] userIds, bool enableAMK, bool enableCMK, string KeyName, string KeyVersion, string KeyVaultUri, string UserIdentityEncryption, bool disablePublicNetworkAccess)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("Location", location).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            IDictionary<string, string> accountTags = null;
            if (tags != null)
                accountTags = tags.Cast<DictionaryEntry>()
                    .ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());

            var accountCreateOrUpdateParameters = new AutomationAccountCreateOrUpdateParameters()
            {
                Location = location,
                Name = automationAccountName,
                Sku = new Sku()
                {
                    Name = String.IsNullOrWhiteSpace(plan) ? Constants.DefaultPlan : plan,
                },
                Tags = accountTags
            };

            if (addSystemId == true)
            {
                accountCreateOrUpdateParameters.Identity = new Identity(null, null, ResourceIdentityType.SystemAssigned);
            }
            if ((userIds != null) && userIds.Any())
            {
                var userIdDict = new Dictionary<string, IdentityUserAssignedIdentitiesValue>();
                foreach (var id in userIds)
                {
                    userIdDict.Add(id, new IdentityUserAssignedIdentitiesValue());
                }

                var IdType = ResourceIdentityType.UserAssigned;
                if (addSystemId == true)
                {
                    IdType = ResourceIdentityType.SystemAssignedUserAssigned;
                }

                accountCreateOrUpdateParameters.Identity = new Identity(null, null, IdType, userIdDict);
            }
            if (enableAMK == true)
            {
                accountCreateOrUpdateParameters.Encryption = new EncryptionProperties(null, EncryptionKeySourceType.MicrosoftAutomation);
            }
            if (enableCMK == true)
            {
                if (String.IsNullOrEmpty(UserIdentityEncryption))
                {
                    accountCreateOrUpdateParameters.Encryption = new EncryptionProperties(
                        new KeyVaultProperties(KeyVaultUri, KeyName, KeyVersion),
                        EncryptionKeySourceType.MicrosoftKeyvault
                        );
                }
                else
                {
                    accountCreateOrUpdateParameters.Encryption = new EncryptionProperties(
                        new KeyVaultProperties(KeyVaultUri, KeyName, KeyVersion),
                        EncryptionKeySourceType.MicrosoftKeyvault,
                        new EncryptionPropertiesIdentity(UserIdentityEncryption)
                        );
                }
            }

            if (disablePublicNetworkAccess == true)
            {
                accountCreateOrUpdateParameters.PublicNetworkAccess = false;
            }

            var account = this.automationManagementClient.AutomationAccount.CreateOrUpdate(resourceGroupName, automationAccountName, accountCreateOrUpdateParameters);

            return new AutomationAccount(resourceGroupName, account);
        }

        public AutomationAccount UpdateAutomationAccount(string resourceGroupName, string automationAccountName,
            string plan, IDictionary tags, bool addSystemId, string[] userIds, bool enableAMK, bool enableCMK, string KeyName, string KeyVersion, string KeyVaultUri, string UserIdentityEncryption, bool disablePublicNetworkAccess)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            var automationAccount = GetAutomationAccount(resourceGroupName, automationAccountName);

            IDictionary<string, string> accountTags = null;
            if (tags != null)
            {
                accountTags = tags.Cast<DictionaryEntry>()
                    .ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());
            }
            else
            {
                accountTags = automationAccount.Tags.Cast<DictionaryEntry>()
                    .ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());
                ;
            }

            var accountUpdateParameters = new AutomationAccountUpdateParameters()
            {
                Name = automationAccountName,
                Sku = new Sku()
                {
                    Name = String.IsNullOrWhiteSpace(plan) ? automationAccount.Plan : plan,
                },
                Tags = accountTags,
            };

            if (addSystemId == true)
            {
                accountUpdateParameters.Identity = new Identity(null, null, ResourceIdentityType.SystemAssigned);
            }
            if ((userIds != null) && userIds.Any())
            {
                var userIdDict = new Dictionary<string, IdentityUserAssignedIdentitiesValue>();
                foreach (var id in userIds)
                {
                    userIdDict.Add(id, new IdentityUserAssignedIdentitiesValue());
                }

                var IdType = ResourceIdentityType.UserAssigned;
                if (addSystemId == true)
                {
                    IdType = ResourceIdentityType.SystemAssignedUserAssigned;
                }

                accountUpdateParameters.Identity = new Identity(null, null, IdType, userIdDict);
            }
            if (enableAMK == true)
            {
                accountUpdateParameters.Encryption = new EncryptionProperties(null, EncryptionKeySourceType.MicrosoftAutomation);
            }
            if (enableCMK == true)
            {
                if (String.IsNullOrEmpty(UserIdentityEncryption))
                {
                    accountUpdateParameters.Encryption = new EncryptionProperties(
                        new KeyVaultProperties(KeyVaultUri, KeyName, KeyVersion),
                        EncryptionKeySourceType.MicrosoftKeyvault
                        );
                }
                else
                {
                    accountUpdateParameters.Encryption = new EncryptionProperties(
                        new KeyVaultProperties(KeyVaultUri, KeyName, KeyVersion),
                        EncryptionKeySourceType.MicrosoftKeyvault,
                        new EncryptionPropertiesIdentity(UserIdentityEncryption)
                        );
                }
            }

            if (disablePublicNetworkAccess == true)
            {
                accountUpdateParameters.PublicNetworkAccess = false;
            }

            var account = this.automationManagementClient.AutomationAccount.Update(resourceGroupName, automationAccountName, accountUpdateParameters);

            return new AutomationAccount(resourceGroupName, account);
        }

        public void DeleteAutomationAccount(string resourceGroupName, string automationAccountName)
        {
            try
            {
                this.automationManagementClient.AutomationAccount.Delete(
                    resourceGroupName,
                    automationAccountName);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(AutomationAccount),
                        string.Format(CultureInfo.CurrentCulture, Resources.AutomationAccountNotFound,
                            automationAccountName));
                }

                throw;
            }
        }

        #endregion

        #region Module

        public Module CreateModule(string resourceGroupName, string automationAccountName, Uri contentLink,
            string moduleName)
        {
            var createdModule = this.automationManagementClient.Module.CreateOrUpdate(resourceGroupName,
                automationAccountName,
                moduleName,
                new AutomationManagement.Models.ModuleCreateOrUpdateParameters()
                {
                    Name = moduleName,
                    ContentLink = new AutomationManagement.Models.ContentLink()
                    {
                         Uri = contentLink.ToString(),
                         ContentHash = null,
                         Version = null
                    },
                });

            return this.GetModule(resourceGroupName, automationAccountName, moduleName);
        }

        public Module GetModule(string resourceGroupName, string automationAccountName, string name)
        {
            try
            {
                var module =
                    this.automationManagementClient.Module.Get(resourceGroupName, automationAccountName, name);
                return new Module(resourceGroupName, automationAccountName, module);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Module),
                        string.Format(CultureInfo.CurrentCulture, Resources.ModuleNotFound, name));
                }

                throw;
            }
        }

        public IEnumerable<Module> ListModules(string resourceGroupName, string automationAccountName,
            ref string nextLink)
        {
            Rest.Azure.IPage<AutomationManagement.Models.Module> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Module.ListByAutomationAccount(resourceGroupName, automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.Module.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return response.Select(c => new Module(resourceGroupName, automationAccountName, c));
        }

        public Module UpdateModule(string resourceGroupName, string automationAccountName, string name,
            Uri contentLinkUri, string contentLinkVersion)
        {
            try
            {
                var moduleModel =
                this.automationManagementClient.Module.Get(resourceGroupName, automationAccountName, name);
                if (contentLinkUri != null)
                {
                    var updateModule = this.automationManagementClient.Module.CreateOrUpdate(resourceGroupName,
                    automationAccountName,
                    name,
                    new AutomationManagement.Models.ModuleCreateOrUpdateParameters()
                    {
                        Name = name,
                        ContentLink = new AutomationManagement.Models.ContentLink()
                        {
                            Uri = contentLinkUri.ToString(),
                            ContentHash = null,
                            Version =
                            (String.IsNullOrWhiteSpace(contentLinkVersion))
                            ? Guid.NewGuid().ToString()
                            : contentLinkVersion
                        },
                    });
                }
            var updatedModule =
            this.automationManagementClient.Module.Get(resourceGroupName, automationAccountName, name);
            return new Module(resourceGroupName, automationAccountName, updatedModule);
            }
            catch (ErrorResponseException cloudException)
            {
                 if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                 {
                     throw new ResourceNotFoundException(typeof(Module),
                         string.Format(CultureInfo.CurrentCulture, Resources.ModuleNotFound, name));

                 }

                 throw;
             }
        }

        public void DeleteModule(string resourceGroupName, string automationAccountName, string name)
        {
            try
            {
                this.automationManagementClient.Module.Delete(resourceGroupName, automationAccountName, name);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(Module),
                        string.Format(CultureInfo.CurrentCulture, Resources.ModuleNotFound, name));
                }

                throw;
            }
        }

        #endregion

        #region Schedule Operations

        public Schedule CreateSchedule(string resourceGroupName, string automationAccountName, Schedule schedule)
        {
            var scheduleCreateOrUpdateParameters = new ScheduleCreateOrUpdateParameters
            {
               Name = schedule.Name,
               StartTime = schedule.StartTime,
               ExpiryTime = schedule.ExpiryTime,
               Description = schedule.Description,
               Interval = schedule.Interval,
               Frequency = schedule.Frequency.ToString(),
               AdvancedSchedule = schedule.GetAdvancedSchedule(),
               TimeZone = schedule.TimeZone,
            };

            var scheduleCreateResponse = this.automationManagementClient.Schedule.CreateOrUpdate(
                resourceGroupName,
                automationAccountName,
                schedule.Name,
                scheduleCreateOrUpdateParameters);

            return this.GetSchedule(resourceGroupName, automationAccountName, schedule.Name);
        }

        public void DeleteSchedule(string resourceGroupName, string automationAccountName, string scheduleName)
        {
            try
            {
                this.automationManagementClient.Schedule.Delete(resourceGroupName, automationAccountName, scheduleName);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(Schedule),
                        string.Format(CultureInfo.CurrentCulture, Resources.ScheduleNotFound, scheduleName));
                }

                throw;
            }
        }

        public Schedule GetSchedule(string resourceGroupName, string automationAccountName, string scheduleName)
        {
            AutomationManagement.Models.Schedule scheduleModel = this.GetScheduleModel(resourceGroupName, automationAccountName,
                scheduleName);
            return this.CreateScheduleFromScheduleModel(resourceGroupName, automationAccountName, scheduleModel);
        }

        public IEnumerable<Schedule> ListSchedules(string resourceGroupName, string automationAccountName, ref string nextLink)
        {
            Rest.Azure.IPage<AutomationManagement.Models.Schedule> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Schedule.ListByAutomationAccount(resourceGroupName, automationAccountName);;
            }
            else
            {
                response = this.automationManagementClient.Schedule.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return response.Select(c => new Schedule(resourceGroupName, automationAccountName, c));
        }

        public Schedule UpdateSchedule(string resourceGroupName, string automationAccountName, string scheduleName, bool? isEnabled,
            string description)
        {
            AutomationManagement.Models.Schedule scheduleModel = this.GetScheduleModel(resourceGroupName, automationAccountName,
                scheduleName);
            isEnabled = (isEnabled.HasValue) ? isEnabled : scheduleModel.IsEnabled;
            description = description ?? scheduleModel.Description;
            return this.UpdateScheduleHelper(resourceGroupName, automationAccountName, scheduleName, isEnabled, description);
        }

        #endregion

        #region Runbook Operations

        public Runbook GetRunbook(string resourceGroupName, string automationAccountName, string runbookName)
        {
            var runbookModel = this.TryGetRunbookModel(resourceGroupName, automationAccountName, runbookName);
            if (runbookModel == null)
            {
                throw new ResourceCommonException(typeof(Runbook),
                    string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
            }

            return new Runbook(resourceGroupName, automationAccountName, runbookModel);
        }

        public IEnumerable<Runbook> ListRunbooks(string resourceGroupName, string automationAccountName, ref string nextLink)
        {
            Rest.Azure.IPage<AutomationManagement.Models.Runbook> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Runbook.ListByAutomationAccount(resourceGroupName, automationAccountName);;
            }
            else
            {
                response = this.automationManagementClient.Runbook.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return response.Select(c => new Runbook(resourceGroupName, automationAccountName, c));
        }

        public Runbook CreateRunbookByName(string resourceGroupName, string automationAccountName, string runbookName, string description,
            IDictionary tags, string type, bool? logProgress, bool? logVerbose, bool overwrite)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var runbookModel = this.TryGetRunbookModel(resourceGroupName, automationAccountName, runbookName);
                if (runbookModel != null && overwrite == false)
                {
                    throw new ResourceCommonException(typeof(Runbook),
                        string.Format(CultureInfo.CurrentCulture, Resources.RunbookAlreadyExists, runbookName));
                }

                IDictionary<string, string> runbooksTags = null;
                if (tags != null) runbooksTags = tags.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());

                var rdcparam = new RunbookCreateOrUpdateParameters()
                {
                    Name = runbookName,
                    Description = description,
                    RunbookType = String.IsNullOrWhiteSpace(type) ? RunbookTypeEnum.Script : type,
                    LogProgress = logProgress.HasValue && logProgress.Value,
                    LogVerbose = logVerbose.HasValue && logVerbose.Value,
                    Draft = new RunbookDraft(),
                    Tags = runbooksTags,
                    Location = GetAutomationAccount(resourceGroupName, automationAccountName).Location
                };

                this.automationManagementClient.Runbook.CreateOrUpdate(resourceGroupName, automationAccountName, runbookName, rdcparam);

                return this.GetRunbook(resourceGroupName, automationAccountName, runbookName);
            }
        }

        public Runbook ImportRunbook(string resourceGroupName, string automationAccountName, string runbookPath, string description, IDictionary tags, string type, bool? logProgress, bool? logVerbose, bool published, bool overwrite, string name)
        {
            var fileExtension = Path.GetExtension(runbookPath);

            if (0 !=
                string.Compare(fileExtension, Constants.SupportedFileExtensions.PowerShellScript,
                    StringComparison.OrdinalIgnoreCase) &&
                0 !=
                string.Compare(fileExtension, Constants.SupportedFileExtensions.Graph,
                    StringComparison.OrdinalIgnoreCase) &&
                0 !=
                string.Compare(fileExtension, Constants.SupportedFileExtensions.Python,
                    StringComparison.OrdinalIgnoreCase))
            {
                throw new ResourceCommonException(typeof(Runbook),
                        string.Format(CultureInfo.CurrentCulture, Resources.InvalidImportFile, runbookPath));
            }

            // if graph runbook make sure type is not null and has right value
            if (0 == string.Compare(fileExtension, Constants.SupportedFileExtensions.Graph, StringComparison.OrdinalIgnoreCase) 
                && (string.IsNullOrWhiteSpace(type) || !IsGraphRunbook(type)))
            {
                throw new ResourceCommonException(typeof(Runbook),
                        string.Format(CultureInfo.CurrentCulture, Resources.InvalidRunbookTypeForExtension, fileExtension));
            }

            var runbookName = Path.GetFileNameWithoutExtension(runbookPath);

            if (String.IsNullOrWhiteSpace(name) == false)
            {
                if (0 == string.Compare(type, Constants.RunbookType.PowerShellWorkflow, StringComparison.OrdinalIgnoreCase))
                {
                    if (0 != string.Compare(runbookName, name, StringComparison.CurrentCultureIgnoreCase))
                    {
                        throw new ResourceCommonException(typeof(Runbook),
                        string.Format(CultureInfo.CurrentCulture, Resources.FileNameRunbookNameMismatch));
                    }
                }

                runbookName = name;
            }

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var runbook = this.CreateRunbookByName(resourceGroupName, automationAccountName, runbookName, description, tags, type, logProgress, logVerbose, overwrite);

                using(FileStream SourceStream = File.Open(runbookPath, FileMode.Open))
                {
                    this.automationManagementClient.RunbookDraft.ReplaceContent(resourceGroupName, automationAccountName, runbookName, SourceStream);
                }

                if (published)
                {
                    runbook = this.PublishRunbook(resourceGroupName, automationAccountName, runbookName);
                }

                return runbook;
            }
        }

        public void DeleteRunbook(string resourceGroupName, string automationAccountName, string runbookName)
        {
            try
            {
                using (var request = new RequestSettings(this.automationManagementClient))
                {
                    this.automationManagementClient.Runbook.Delete(resourceGroupName, automationAccountName, runbookName);
                }
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(Connection),
                        string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
                }

                throw;
            }

        }

        public Runbook UpdateRunbook(string resourceGroupName, string automationAccountName, string runbookName, string description,
            IDictionary tags, bool? logProgress, bool? logVerbose)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var runbookModel = this.TryGetRunbookModel(resourceGroupName, automationAccountName, runbookName);
                if (runbookModel == null)
                {
                    throw new ResourceCommonException(typeof(Runbook),
                        string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
                }

                var runbookUpdateParameters = new RunbookUpdateParameters();
                runbookUpdateParameters.Name = runbookName;
                runbookUpdateParameters.Tags = null;

                IDictionary<string, string> runbooksTags = null;
                if (tags != null) runbooksTags = tags.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());

                runbookUpdateParameters.Description = description ?? runbookModel.Description;
                runbookUpdateParameters.LogProgress = (logProgress.HasValue)
                    ? logProgress.Value
                    : runbookModel.LogProgress;
                runbookUpdateParameters.LogVerbose = (logVerbose.HasValue)
                    ? logVerbose.Value
                    : runbookModel.LogVerbose;
                runbookUpdateParameters.Tags = runbooksTags ?? runbookModel.Tags;

                var runbook =
                    this.automationManagementClient.Runbook.Update(resourceGroupName, automationAccountName, runbookName, runbookUpdateParameters);

                return new Runbook(resourceGroupName, automationAccountName, runbook);
            }
        }

        public DirectoryInfo ExportRunbook(string resourceGroupName, string automationAccountName,
            string runbookName, bool? isDraft, string outputFolder, bool overwrite)
        {
            DirectoryInfo ret = null;
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var runbook = this.TryGetRunbookModel(resourceGroupName, automationAccountName, runbookName);
                if (runbook == null)
                {
                    throw new ResourceNotFoundException(typeof(Runbook),
                        string.Format(CultureInfo.CurrentCulture, Resources.RunbookNotFound, runbookName));
                }

                var draftContent = String.Empty;
                var publishedContent = String.Empty;

                if (0 !=
                    String.Compare(runbook.State, RunbookState.Published, CultureInfo.InvariantCulture,
                        CompareOptions.IgnoreCase) && (!isDraft.HasValue || isDraft.Value))
                {
                    var stream = this.automationManagementClient.RunbookDraft.GetContent(resourceGroupName, automationAccountName, runbookName);
                    if (stream != null)
                    {
                        var reader = new StreamReader(stream);
                        draftContent = reader.ReadToEnd();
                    }
                }
                if (0 !=
                    String.Compare(runbook.State, RunbookState.New, CultureInfo.InvariantCulture,
                        CompareOptions.IgnoreCase) && (!isDraft.HasValue || !isDraft.Value))
                {
                    var stream = this.automationManagementClient.Runbook.GetContent(resourceGroupName, automationAccountName, runbookName);
                    if (stream != null)
                    {
                        var reader = new StreamReader(stream);
                        publishedContent = reader.ReadToEnd();
                    }
                }

                // if no slot specified return both draft and publish content
                if (false == isDraft.HasValue)
                {
                    if (false == String.IsNullOrEmpty(publishedContent))
                    {
                        ret = WriteRunbookToFile(outputFolder, runbook.Name, publishedContent, runbook.RunbookType,
                               overwrite);
                    }
                    else if (false == String.IsNullOrEmpty(draftContent))
                    {
                        ret = WriteRunbookToFile(outputFolder, runbook.Name, draftContent, runbook.RunbookType,
                                overwrite);
                    }
                }
                else
                {
                    if (true == isDraft.Value)
                    {

                        if (String.IsNullOrEmpty(draftContent))
                            throw new ResourceCommonException(typeof(Runbook),
                                string.Format(CultureInfo.CurrentCulture, Resources.RunbookHasNoDraftVersion,
                                    runbookName));
                        if (false == String.IsNullOrEmpty(draftContent))
                            ret = WriteRunbookToFile(outputFolder, runbook.Name, draftContent, runbook.RunbookType,
                                overwrite);
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(publishedContent))
                            throw new ResourceCommonException(typeof(Runbook),
                                string.Format(CultureInfo.CurrentCulture, Resources.RunbookHasNoPublishedVersion,
                                    runbookName));

                        if (false == String.IsNullOrEmpty(publishedContent))
                            ret = WriteRunbookToFile(outputFolder, runbook.Name, publishedContent, runbook.RunbookType,
                                overwrite);
                    }
                }
            }

            return ret;
        }

        public Runbook PublishRunbook(string resourceGroupName, string automationAccountName, string runbookName)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                this.automationManagementClient.Runbook.Publish(resourceGroupName, automationAccountName, runbookName);

                return this.GetRunbook(resourceGroupName, automationAccountName, runbookName);
            }
        }

        public Job StartRunbook(string resourceGroupName, string automationAccountName, string runbookName, IDictionary parameters, string runOn)
        {
            IDictionary<string, string> processedParameters = this.ProcessRunbookParameters(resourceGroupName, automationAccountName,
                runbookName, parameters);
            var job = this.automationManagementClient.Job.Create(
                resourceGroupName,
                automationAccountName,
                Guid.NewGuid().ToString(),
                new JobCreateParameters
                {
                    Runbook = new RunbookAssociationProperty
                    {
                        Name = runbookName
                    },
                    RunOn = String.IsNullOrWhiteSpace(runOn) ? null : runOn,
                    Parameters = processedParameters ?? null
                });

            return new Job(resourceGroupName, automationAccountName, job);
        }

        #endregion

        #region Variables

        public Variable CreateVariable(Variable variable)
        {
            bool variableExists = true;

            try
            {
                this.GetVariable(variable.ResourceGroupName, variable.AutomationAccountName, variable.Name);
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

            var createParams = new AutomationManagement.Models.VariableCreateOrUpdateParameters()
            {
                Name = variable.Name,
                Value = PowerShellJsonConverter.Serialize(variable.Value),
                Description = variable.Description,
                IsEncrypted = variable.Encrypted
            };

            var sdkCreatedVariable = this.automationManagementClient.Variable.CreateOrUpdate(variable.ResourceGroupName, variable.AutomationAccountName, variable.Name, createParams);

            return new Variable(sdkCreatedVariable, variable.AutomationAccountName, variable.ResourceGroupName);
        }

        public void DeleteVariable(string resourceGroupName, string automationAccountName, string variableName)
        {
            try
            {
                this.automationManagementClient.Variable.Delete(resourceGroupName, automationAccountName, variableName);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(Variable),
                        string.Format(CultureInfo.CurrentCulture, Resources.VariableNotFound, variableName));
                }

                throw;
            }
        }

        public Variable UpdateVariable(Variable variable, VariableUpdateFields updateFields)
        {
            var existingVariable = this.GetVariable(variable.ResourceGroupName, variable.AutomationAccountName, variable.Name);

            if (existingVariable.Encrypted != variable.Encrypted && updateFields == VariableUpdateFields.OnlyValue)
            {
                throw new ResourceNotFoundException(typeof(Variable),
                    string.Format(CultureInfo.CurrentCulture, Resources.VariableEncryptionCannotBeChanged, variable.Name,
                        existingVariable.Encrypted));
            }

            var updateParams = new AutomationManagement.Models.VariableUpdateParameters()
            {
                Name = variable.Name,
            };

            if (updateFields == VariableUpdateFields.OnlyDescription)
            {
                updateParams.Description = variable.Description;
            }
            else
            {
                updateParams.Value = PowerShellJsonConverter.Serialize(variable.Value);
            }

            this.automationManagementClient.Variable.Update(variable.ResourceGroupName, variable.AutomationAccountName, variable.Name, updateParams);

            return this.GetVariable(variable.ResourceGroupName, variable.AutomationAccountName, variable.Name);
        }

        public Variable GetVariable(string resourceGroupName, string automationAccountName, string name)
        {
            try
            {
                var sdkVarible = this.automationManagementClient.Variable.Get(resourceGroupName, automationAccountName, name);

                if (sdkVarible != null)
                {
                    return new Variable(sdkVarible, automationAccountName, resourceGroupName);
                }

                throw new ResourceNotFoundException(typeof(Variable),
                    string.Format(CultureInfo.CurrentCulture, Resources.VariableNotFound, name));
            }
            catch (ErrorResponseException)
            {
                throw new ResourceNotFoundException(typeof(Variable),
                    string.Format(CultureInfo.CurrentCulture, Resources.VariableNotFound, name));
            }
        }

        public IEnumerable<Variable> ListVariables(string resourceGroupName, string automationAccountName, ref string nextLink)
        {
            Rest.Azure.IPage<AutomationManagement.Models.Variable> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Variable.ListByAutomationAccount(resourceGroupName, automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.Variable.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return response.Select(c => new Variable(c, automationAccountName, resourceGroupName));
        }

        #endregion

        #region Credentials

        public CredentialInfo CreateCredential(string resourceGroupName, string automationAccountName, string name, string userName,
            string password,
            string description)
        {
            var credentialCreateParams = new AutomationManagement.Models.CredentialCreateOrUpdateParameters();
            credentialCreateParams.Name = name;
            if (description != null) credentialCreateParams.Description = description;

            Requires.Argument("userName", userName).NotNull();
            Requires.Argument("password", password).NotNull();

            credentialCreateParams.UserName = userName;
            credentialCreateParams.Password = password;

            var createdCredential = this.automationManagementClient.Credential.CreateOrUpdate(resourceGroupName, automationAccountName, name, credentialCreateParams);

            return new CredentialInfo(resourceGroupName, automationAccountName, createdCredential);
        }

        public CredentialInfo UpdateCredential(string resourceGroupName, string automationAccountName, string name, string userName,
            string password,
            string description)
        {
            var existingCredential = this.GetCredential(resourceGroupName, automationAccountName, name);
            var credentialUpdateParams = new CredentialUpdateParameters();
            credentialUpdateParams.Name = name;
            credentialUpdateParams.Description = description ?? existingCredential.Description;

            if (!string.IsNullOrWhiteSpace(userName))
            {
                credentialUpdateParams.UserName = userName;
                credentialUpdateParams.Password = password;
            }

            var credential = this.automationManagementClient.Credential.Update(resourceGroupName, automationAccountName, name,
                credentialUpdateParams);

            var updatedCredential = this.GetCredential(resourceGroupName, automationAccountName, name);

            return updatedCredential;
        }

        public CredentialInfo GetCredential(string resourceGroupName, string automationAccountName, string name)
        {
            var credential = this.automationManagementClient.Credential.Get(resourceGroupName, automationAccountName, name);
            if (credential == null)
            {
                throw new ResourceNotFoundException(typeof(Credential),
                    string.Format(CultureInfo.CurrentCulture, Resources.CredentialNotFound, name));
            }

            return new CredentialInfo(resourceGroupName, automationAccountName, credential);
        }

        public IEnumerable<Credential> ListCredentials(string resourceGroupName, string automationAccountName, ref string nextLink)
        {
            Rest.Azure.IPage<AutomationManagement.Models.Credential> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Credential.ListByAutomationAccount(resourceGroupName, automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.Credential.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return response.Select(c => new Credential(resourceGroupName, automationAccountName, c));
        }

        public void DeleteCredential(string resourceGroupName, string automationAccountName, string name)
        {
            try
            {
                this.automationManagementClient.Credential.Delete(resourceGroupName, automationAccountName, name);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Credential),
                        string.Format(CultureInfo.CurrentCulture, Resources.CredentialNotFound, name));
                }

                throw;
            }
        }

        #endregion

        #region Job

        public IEnumerable<JobStream> GetJobStream(string resourceGroupName, string automationAccountName, Guid jobId, DateTimeOffset? time,
            string streamType, ref string nextLink)
        {
            Rest.Azure.IPage<AutomationManagement.Models.JobStream> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.JobStream.ListByJob(resourceGroupName, automationAccountName, jobId.ToString(), this.GetJobStreamFilterString(time, streamType));
            }
            else
            {
                response = this.automationManagementClient.JobStream.ListByJobNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return
                response.Select(
                    stream => this.CreateJobStreamFromJobStreamModel(stream, resourceGroupName, automationAccountName, jobId));
        }
        
        public JobStreamRecord GetJobStreamRecord(string resourceGroupName, string automationAccountName, Guid jobId, string jobStreamId)
        {
            var response = this.automationManagementClient.JobStream.Get(resourceGroupName, automationAccountName, jobId.ToString(), jobStreamId);

            return new JobStreamRecord(response, resourceGroupName, automationAccountName, jobId);
        }

        public object GetJobStreamRecordAsPsObject(string resourceGroupName, string automationAccountName, Guid jobId, string jobStreamId)
        {
            var response = this.automationManagementClient.JobStream.Get(resourceGroupName, automationAccountName, jobId.ToString(), jobStreamId);

            if (response == null || response.Value == null) return null;

            // PowerShell Workflow runbook jobs would have the below additional properties, remove them from job output
            // we do not know the runbook type, remove will only remove if exists 
            response.Value.Remove("PSComputerName");
            response.Value.Remove("PSShowComputerName");
            response.Value.Remove("PSSourceJobInstanceId");

            var paramTable = new Hashtable();

            foreach (var kvp in response.Value)
            {
                object paramValue;
                try
                {
                    if (kvp.Value != null)
                    {
                        if (IsValidJson(kvp.Value.ToString()))
                        {
                            paramValue = ((object)PowerShellJsonConverter.Deserialize(kvp.Value.ToString()));
                        }
                        else
                        {
                            paramValue = kvp.Value;
                        }
                    }
                    else
                    {
                        paramValue = null;
                    }
                }
                catch (CmdletInvocationException exception)
                {
                    if (!exception.Message.Contains("Invalid JSON primitive"))
                        throw;

                    paramValue = kvp.Value;
                }

                // for primitive outputs, the record will be in form "value" : "primitive type value". Return the key and return the primitive type value  
                if (response.Value.Count == 1 && response.Value.ContainsKey("value"))
                {
                    return paramValue;
                }

                paramTable.Add(kvp.Key, paramValue);
            }

            return paramTable;
        }

        public Job GetJob(string resourceGroupName, string automationAccountName, Guid Id)
        {
            var job = this.automationManagementClient.Job.Get(resourceGroupName, automationAccountName, Id.ToString());
            if (job == null)
            {
                throw new ResourceNotFoundException(typeof(Job),
                    string.Format(CultureInfo.CurrentCulture, Resources.JobNotFound, Id));
            }

            return new Job(resourceGroupName, automationAccountName, job);
        }

        public IEnumerable<Job> ListJobsByRunbookName(string resourceGroupName, string automationAccountName, string runbookName,
            DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus, ref string nextLink)
        {
            Rest.Azure.IPage<JobCollectionItem> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Job.ListByAutomationAccount(
                    resourceGroupName,
                    automationAccountName,
                    this.GetJobFilterString(runbookName, startTime, endTime, jobStatus));
            }
            else
            {
                response = this.automationManagementClient.Job.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return response.Select(c => new Job(resourceGroupName, automationAccountName, c));
        }
                
        public IEnumerable<Job> ListJobs(string resourceGroupName, string automationAccountName, DateTimeOffset? startTime,
            DateTimeOffset? endTime, string jobStatus, ref string nextLink)
        {
            Rest.Azure.IPage<AutomationManagement.Models.JobCollectionItem> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Job.ListByAutomationAccount(
                    resourceGroupName,
                    automationAccountName,
                    this.GetJobFilterString(null, startTime, endTime, jobStatus));
            }
            else
            {
                response = this.automationManagementClient.Job.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return response.Select(c => new Job(resourceGroupName, automationAccountName, c));
        }

        public void ResumeJob(string resourceGroupName, string automationAccountName, Guid id)
        {
            this.automationManagementClient.Job.Resume(resourceGroupName, automationAccountName, id.ToString());
        }

        public void StopJob(string resourceGroupName, string automationAccountName, Guid id)
        {
            this.automationManagementClient.Job.Stop(resourceGroupName, automationAccountName, id.ToString());
        }

        public void SuspendJob(string resourceGroupName, string automationAccountName, Guid id)
        {
            this.automationManagementClient.Job.Suspend(resourceGroupName, automationAccountName, id.ToString());
        }

        #endregion

        #region Certificate Operations

        public CertificateInfo CreateCertificate(string resourceGroupName, string automationAccountName, string name, string path,
            SecureString password,
            string description, bool exportable)
        {
            var certificateModel = this.TryGetCertificateModel(resourceGroupName, automationAccountName, name);
            if (certificateModel != null)
            {
                throw new ResourceCommonException(typeof(CertificateInfo),
                    string.Format(CultureInfo.CurrentCulture, Resources.CertificateAlreadyExists, name));
            }

            return CreateCertificateInternal(resourceGroupName, automationAccountName, name, path, password, description, exportable);
        }


        public CertificateInfo UpdateCertificate(string resourceGroupName, string automationAccountName, string name, string path,
            SecureString password,
            string description, bool? exportable)
        {
            if (String.IsNullOrWhiteSpace(path) && (password != null || exportable.HasValue))
            {
                throw new ResourceCommonException(typeof(CertificateInfo),
                    string.Format(CultureInfo.CurrentCulture, Resources.SetCertificateInvalidArgs, name));
            }

            var certificateModel = this.TryGetCertificateModel(resourceGroupName, automationAccountName, name);
            if (certificateModel == null)
            {
                throw new ResourceCommonException(typeof(CertificateInfo),
                    string.Format(CultureInfo.CurrentCulture, Resources.CertificateNotFound, name));
            }

            var createOrUpdateDescription = description ?? certificateModel.Description;
            var createOrUpdateIsExportable = (exportable.HasValue)
                ? exportable.Value
                : certificateModel.IsExportable;

            if (path != null)
            {
                return this.CreateCertificateInternal(resourceGroupName, automationAccountName, name, path, password,
                    createOrUpdateDescription,
                    createOrUpdateIsExportable);
            }

            var cuparam = new CertificateUpdateParameters()
            {
                Name = name,
                Description = createOrUpdateDescription
            };

            this.automationManagementClient.Certificate.Update(resourceGroupName, automationAccountName, name, cuparam);

            return new CertificateInfo(resourceGroupName, automationAccountName,
                this.automationManagementClient.Certificate.Get(resourceGroupName, automationAccountName, name));
        }

        public CertificateInfo GetCertificate(string resourceGroupName, string automationAccountName, string name)
        {
            var certificateModel = this.TryGetCertificateModel(resourceGroupName, automationAccountName, name);
            if (certificateModel == null)
            {
                throw new ResourceCommonException(typeof(CertificateInfo),
                    string.Format(CultureInfo.CurrentCulture, Resources.CertificateNotFound, name));
            }

            return new Certificate(resourceGroupName, automationAccountName, certificateModel);
        }

        public IEnumerable<CertificateInfo> ListCertificates(string resourceGroupName, string automationAccountName, ref string nextLink)
        {
            Rest.Azure.IPage<AutomationManagement.Models.Certificate> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Certificate.ListByAutomationAccount(resourceGroupName, automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.Certificate.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return response.Select(c => new CertificateInfo(resourceGroupName, automationAccountName, c));
        }

        public void DeleteCertificate(string resourceGroupName, string automationAccountName, string name)
        {
            try
            {
                this.automationManagementClient.Certificate.Delete(resourceGroupName, automationAccountName, name);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(Schedule),
                        string.Format(CultureInfo.CurrentCulture, Resources.CertificateNotFound, name));
                }

                throw;
            }
        }

        #endregion

        #region Connection Operations

        public Connection CreateConnection(string resourceGroupName, string automationAccountName, string name, string connectionTypeName,
            IDictionary connectionFieldValues,
            string description)
        {
            var connectionModel = this.TryGetConnectionModel(resourceGroupName, automationAccountName, name);
            if (connectionModel != null)
            {
                throw new ResourceCommonException(typeof(Connection),
                    string.Format(CultureInfo.CurrentCulture, Resources.ConnectionAlreadyExists, name));
            }

            var ccparam = new ConnectionCreateOrUpdateParameters() { Name = name,
                Description = description,
                ConnectionType = new ConnectionTypeAssociationProperty() { Name = connectionTypeName },
                FieldDefinitionValues =
                    connectionFieldValues.Cast<DictionaryEntry>()
                        .ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString())
            };

            var connection = this.automationManagementClient.Connection.CreateOrUpdate(resourceGroupName, automationAccountName, name, ccparam);

            return new Connection(resourceGroupName, automationAccountName, connection);
        }

        public Connection UpdateConnectionFieldValue(string resourceGroupName, string automationAccountName, string name,
            string connectionFieldName, object value)
        {
            var connectionModel = this.TryGetConnectionModel(resourceGroupName, automationAccountName, name);
            if (connectionModel == null)
            {
                throw new ResourceCommonException(typeof(Connection),
                    string.Format(CultureInfo.CurrentCulture, Resources.ConnectionNotFound, name));
            }

            if (connectionModel.FieldDefinitionValues.ContainsKey(connectionFieldName))
            {
                if (value is string)
                {
                    connectionModel.FieldDefinitionValues[connectionFieldName] = value.ToString();
                }
                else
                {
                    connectionModel.FieldDefinitionValues[connectionFieldName] =
                        PowerShellJsonConverter.Serialize(value);
                }
            }
            else
            {
                throw new ResourceCommonException(typeof(Connection),
                    string.Format(CultureInfo.CurrentCulture, Resources.ConnectionFieldNameNotFound, name));
            }

            var cuparam = new ConnectionUpdateParameters()
            {
                Name = name,
                Description = connectionModel.Description,
                FieldDefinitionValues = connectionModel.FieldDefinitionValues
            };

            this.automationManagementClient.Connection.Update(resourceGroupName, automationAccountName, name, cuparam);

            return new Connection(resourceGroupName, automationAccountName,
                this.automationManagementClient.Connection.Get(resourceGroupName, automationAccountName, name));
        }

        public Connection GetConnection(string resourceGroupName, string automationAccountName, string name)
        {
            var connectionModel = this.TryGetConnectionModel(resourceGroupName, automationAccountName, name);
            if (connectionModel == null)
            {
                throw new ResourceCommonException(typeof(Connection),
                    string.Format(CultureInfo.CurrentCulture, Resources.ConnectionNotFound, name));
            }

            return new Connection(resourceGroupName, automationAccountName, connectionModel);
        }

        public IEnumerable<Connection> ListConnectionsByType(string resourceGroupName, string automationAccountName, string typeName)
        {
            var connections = new List<Connection>();
            string nextLink = string.Empty;

            do
            {
                connections.AddRange(this.ListConnections(resourceGroupName, automationAccountName, ref nextLink));

            } while (!string.IsNullOrEmpty(nextLink));

            return
                connections.Where(
                    c => c.ConnectionTypeName.Equals(typeName, StringComparison.InvariantCultureIgnoreCase));
        }

        public IEnumerable<Connection> ListConnections(string resourceGroupName, string automationAccountName, ref string nextLink)
        {
            Rest.Azure.IPage<AutomationManagement.Models.Connection> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Connection.ListByAutomationAccount(resourceGroupName, automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.Connection.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return response.Select(c => new Connection(resourceGroupName, automationAccountName, c));
        }

        public void DeleteConnection(string resourceGroupName, string automationAccountName, string name)
        {
            try
            {
                this.automationManagementClient.Connection.Delete(resourceGroupName, automationAccountName, name);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(Connection),
                        string.Format(CultureInfo.CurrentCulture, Resources.ConnectionNotFound, name));
                }

                throw;
            }
        }

        #endregion

        #region HybridRunbookworkerGroups

        public HybridRunbookWorkerGroup GetHybridWorkerGroup(string resourceGroupName, string automationAccountName, string name)
        {
            var hybridRunbookWorkerGroupModel = this.TryGetHybridRunbookWorkerModel(resourceGroupName, automationAccountName, name);
            if (hybridRunbookWorkerGroupModel == null)
            {
                throw new ResourceCommonException(typeof(HybridRunbookWorkerGroup),
                    string.Format(CultureInfo.CurrentCulture, Resources.HybridRunbookWorkerGroupNotFound, name));
            }

            return new HybridRunbookWorkerGroup(resourceGroupName, automationAccountName, hybridRunbookWorkerGroupModel);

        }

        public AutomationManagement.Models.HybridRunbookWorkerGroup CreateOrUpdateRunbookWorkerGroup(string resourceGroupName, string automationAccountName, string hybridRunbookWorkerGroupName, string credentialName = null)
        {
            AutomationManagement.Models.HybridRunbookWorkerGroup response;

            var hybridWorkerGroupCreationParams = new HybridRunbookWorkerGroupCreateOrUpdateParameters()
            {
                Name = hybridRunbookWorkerGroupName,
            };

            if (!string.IsNullOrEmpty(credentialName))
            {
                hybridWorkerGroupCreationParams.Credential = new RunAsCredentialAssociationProperty(credentialName);
            }

            response = this.automationManagementClient.HybridRunbookWorkerGroup.Create(resourceGroupName, automationAccountName, hybridRunbookWorkerGroupName, hybridWorkerGroupCreationParams);

            return response;
        }

        public IEnumerable<Management.Automation.Models.HybridRunbookWorkerGroup> ListHybridRunbookWorkerGroups(string resourceGroupName, string automationAccountName, ref string nextLink)
        {
            Rest.Azure.IPage<Management.Automation.Models.HybridRunbookWorkerGroup> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.HybridRunbookWorkerGroup.ListByAutomationAccount(resourceGroupName, automationAccountName);;
            }
            else
            {
                response = this.automationManagementClient.HybridRunbookWorkerGroup.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;

            return response.Select(c =>  c);
        }

        public Management.Automation.Models.HybridRunbookWorkerGroup GetHybridRunbookWorkerGroup(string resourceGroupName, string automationAccountName, string name)
        {
            var hybridRunbookWorkerGroupModel = this.TryGetHybridRunbookWorkerGroupModel(resourceGroupName, automationAccountName, name);
            if (hybridRunbookWorkerGroupModel == null)
            {
                throw new ResourceCommonException(typeof(HybridRunbookWorkerGroup),
                    string.Format(CultureInfo.CurrentCulture, Resources.HybridRunbookWorkerGroupNotFound, name));
            }

            return hybridRunbookWorkerGroupModel;
            
        }

        public void DeleteHybridRunbookWorkerGroup(string resourceGroupName, string automationAccountName, string name)
        {
            try
            {
                this.automationManagementClient.HybridRunbookWorkerGroup.Delete(resourceGroupName, automationAccountName, name);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Credential),
                        string.Format(CultureInfo.CurrentCulture, Resources.HybridRunbookWorkerGroupNotFound, name));
                }

                throw;
            }
        }

        #endregion


        #region HybridRunbookWorkers


        public Management.Automation.Models.HybridRunbookWorker GetHybridRunbookWorkers(string resourceGroupName, string automationAccountName, string hybridWorkerGroupName, string workerName)
        {
            var hybridRunbookWokerModel = this.TryGetHybridRunbookWorkerModel(resourceGroupName, automationAccountName, hybridWorkerGroupName, workerName);

            if (hybridRunbookWokerModel == null)
            {
                throw new ResourceCommonException(typeof(Management.Automation.Models.HybridRunbookWorker),
                    string.Format(CultureInfo.CurrentCulture, Resources.HybridRunbookWorkerNotFound, workerName));
            }

            return hybridRunbookWokerModel;
        }

        public IEnumerable<Management.Automation.Models.HybridRunbookWorker> ListHybridRunbookWorkers(string resourceGroupName, string automationAccountName, string hybridWorkerGroupName, ref string nextLink)
        {

            Rest.Azure.IPage<Management.Automation.Models.HybridRunbookWorker> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.HybridRunbookWorkers.ListByHybridRunbookWorkerGroup(resourceGroupName, automationAccountName, hybridWorkerGroupName);
            }
            else
            {
                response = this.automationManagementClient.HybridRunbookWorkers.ListByHybridRunbookWorkerGroupNext(nextLink);
            }

            nextLink = response.NextPageLink;

            return response;
        }

        public Management.Automation.Models.HybridRunbookWorker CreateOrUpdateRunbookWorker(string resourceGroupName, string automationAccountName, string hybridRunbookWorkerGroupName, string workerName, string vmResourceId)
        {
            AutomationManagement.Models.HybridRunbookWorker response;

            var hybridWorkerCreationParams = new HybridRunbookWorkerCreateParameters()
            {
                Name = hybridRunbookWorkerGroupName,
                VmResourceId = vmResourceId,
            };

            response = this.automationManagementClient.HybridRunbookWorkers.Create(resourceGroupName, automationAccountName, hybridRunbookWorkerGroupName, workerName, hybridWorkerCreationParams);

            return response;
        }


        public void DeleteHybridRunbookWorker(string resourceGroupName, string automationAccountName, string hybridRunbookWorkerGroupName, string name)
        {
            try
            {
                this.automationManagementClient.HybridRunbookWorkers.Delete(resourceGroupName, automationAccountName, hybridRunbookWorkerGroupName, name);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Credential),
                        string.Format(CultureInfo.CurrentCulture, Resources.HybridRunbookWorkerGroupNotFound, name));
                }

                throw;
            }
        }

        public void MoveRunbookWorker(string resourceGroupName, string automationAccountName, string hybridRunbookWorkerGroupName, string targetHybridRunbookWorkerGroupName, string workerName)
        {
            var workerMoveParams = new HybridRunbookWorkerMoveParameters()
            {
                HybridRunbookWorkerGroupName = targetHybridRunbookWorkerGroupName
            };
            this.automationManagementClient.HybridRunbookWorkers.Move(resourceGroupName, automationAccountName, hybridRunbookWorkerGroupName, workerName, workerMoveParams);
        }

        #endregion
        #region JobSchedule

        public JobSchedule GetJobSchedule(string resourceGroupName, string automationAccountName, Guid jobScheduleId)
        {
            AutomationManagement.Models.JobSchedule jobScheduleModel = null;

            try
            {
                jobScheduleModel = this.automationManagementClient.JobSchedule.Get(
                    resourceGroupName,
                    automationAccountName,
                    jobScheduleId);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(JobSchedule),
                        string.Format(CultureInfo.CurrentCulture, Resources.JobScheduleWithIdNotFound, jobScheduleId));
                }

                throw;
            }

            return this.CreateJobScheduleFromJobScheduleModel(resourceGroupName, automationAccountName, jobScheduleModel);
        }

        public JobSchedule GetJobSchedule(string resourceGroupName, string automationAccountName, string runbookName, string scheduleName)
        {
            const bool jobScheduleFound = false;
            var nextLink = string.Empty;

            do
            {
                var schedules = this.ListJobSchedules(resourceGroupName, automationAccountName, ref nextLink);
                var jobSchedule =
                    schedules.FirstOrDefault(
                        js => String.Equals(js.RunbookName, runbookName, StringComparison.OrdinalIgnoreCase) &&
                              String.Equals(js.ScheduleName, scheduleName, StringComparison.OrdinalIgnoreCase));

                if (jobSchedule != null)
                {
                    this.GetJobSchedule(resourceGroupName, automationAccountName, new Guid(jobSchedule.JobScheduleId));
                    return jobSchedule;
                }

            } while (!string.IsNullOrEmpty(nextLink));

            if (!jobScheduleFound)
            {
                throw new ResourceNotFoundException(typeof(Schedule),
                    string.Format(CultureInfo.CurrentCulture, Resources.JobScheduleNotFound, runbookName, scheduleName));
            }
        }

        public IEnumerable<JobSchedule> ListJobSchedules(string resourceGroupName, string automationAccountName, ref string nextLink)
        {
            Rest.Azure.IPage<AutomationManagement.Models.JobSchedule> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.JobSchedule.ListByAutomationAccount(resourceGroupName, automationAccountName);;
            }
            else
            {
                response = this.automationManagementClient.JobSchedule.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return response.Select(c => new JobSchedule(resourceGroupName, automationAccountName, c));
        }

        public IEnumerable<JobSchedule> ListJobSchedulesByRunbookName(string resourceGroupName, string automationAccountName, string runbookName)
        {
            var jobSchedulesOfRunbook = new List<JobSchedule>();
            var nextLink = string.Empty;

            do
            {
                var schedules = this.ListJobSchedules(resourceGroupName, automationAccountName, ref nextLink);
                jobSchedulesOfRunbook.AddRange(
                    schedules.Where(js => String.Equals(js.RunbookName, runbookName, StringComparison.OrdinalIgnoreCase)));

            } while (!string.IsNullOrEmpty(nextLink));

            return jobSchedulesOfRunbook;
        }

        public IEnumerable<JobSchedule> ListJobSchedulesByScheduleName(string resourceGroupName, string automationAccountName, string scheduleName)
        {
            var jobSchedulesOfSchedules = new List<JobSchedule>();
            var nextLink = string.Empty;

            do
            {
                var schedules = this.ListJobSchedules(resourceGroupName, automationAccountName, ref nextLink);
                jobSchedulesOfSchedules.AddRange(
                    schedules.Where(
                        js => String.Equals(js.ScheduleName, scheduleName, StringComparison.OrdinalIgnoreCase)));

            } while (!string.IsNullOrEmpty(nextLink));

            return jobSchedulesOfSchedules;
        }

        public JobSchedule RegisterScheduledRunbook(string resourceGroupName, string automationAccountName, string runbookName,
            string scheduleName, IDictionary parameters, string runOn)
        {
            var processedParameters = this.ProcessRunbookParameters(resourceGroupName, automationAccountName, runbookName, parameters);
            var sdkJobSchedule = this.automationManagementClient.JobSchedule.Create(
                resourceGroupName,
                automationAccountName,
                Guid.NewGuid(),
                new JobScheduleCreateParameters
                {
                     Schedule = new ScheduleAssociationProperty { Name = scheduleName },
                     Runbook = new RunbookAssociationProperty { Name = runbookName },
                     Parameters = processedParameters,
                     RunOn = runOn
                });

            return new JobSchedule(resourceGroupName, automationAccountName, sdkJobSchedule);
        }

        public void UnregisterScheduledRunbook(string resourceGroupName, string automationAccountName, Guid jobScheduleId)
        {
            try
            {
                this.automationManagementClient.JobSchedule.Delete(
                    resourceGroupName,
                    automationAccountName,
                    jobScheduleId);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Schedule),
                        string.Format(CultureInfo.CurrentCulture, Resources.JobScheduleWithIdNotFound, jobScheduleId));
                }

                throw;
            }
        }

        public void UnregisterScheduledRunbook(string resourceGroupName, string automationAccountName, string runbookName, string scheduleName)
        {
            const bool jobScheduleFound = false;
            var nextLink = string.Empty;

            do
            {
                var schedules = this.ListJobSchedules(resourceGroupName, automationAccountName, ref nextLink);
                var jobSchedule =
                    schedules.FirstOrDefault(
                        js => String.Equals(js.RunbookName, runbookName, StringComparison.OrdinalIgnoreCase) &&
                              String.Equals(js.ScheduleName, scheduleName, StringComparison.OrdinalIgnoreCase));

                if (jobSchedule != null)
                {
                    this.UnregisterScheduledRunbook(resourceGroupName, automationAccountName, new Guid(jobSchedule.JobScheduleId));
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

        public void DeleteConnectionType(string resourceGroupName, string automationAccountName, string name)
        {
            try
            {
                this.automationManagementClient.ConnectionType.Delete(resourceGroupName, automationAccountName, name);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(ConnectionType),
                        string.Format(CultureInfo.CurrentCulture, Resources.ConnectionTypeNotFound, name));
                }

                throw;
            }
        }

        #endregion

        #region Python3Package

        public IEnumerable<Module> ListPython3Package(string resourceGroupName, string automationAccountName,
            ref string nextLink)
        {
            Rest.Azure.IPage<AutomationManagement.Models.Module> response;

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Python3Package.ListByAutomationAccount(resourceGroupName, automationAccountName);
            }
            else
            {
                response = this.automationManagementClient.Python3Package.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return response.Select(c => new Module(resourceGroupName, automationAccountName, c));
        }

        public void DeletePython3Package(string resourceGroupName, string automationAccountName, string name)
        {
            try
            {
                this.automationManagementClient.Python3Package.Delete(resourceGroupName, automationAccountName, name);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(Module),
                        string.Format(CultureInfo.CurrentCulture, Resources.ModuleNotFound, name));
                }

                throw;
            }
        }

        public Module GetPython3Package(string resourceGroupName, string automationAccountName, string name)
        {
            try
            {
                var module =
                    this.automationManagementClient.Python3Package.Get(resourceGroupName, automationAccountName, name);
                return new Module(resourceGroupName, automationAccountName, module);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Module),
                        string.Format(CultureInfo.CurrentCulture, Resources.ModuleNotFound, name));
                }

                throw;
            }
        }



        public Module CreatePython3Package(string resourceGroupName, string automationAccountName, Uri contentLink,
            string moduleName)
        {
            var createdModule = this.automationManagementClient.Python3Package.CreateOrUpdate(resourceGroupName,
                automationAccountName,
                moduleName,
                new AutomationManagement.Models.PythonPackageCreateParameters()
                { 
                    ContentLink = new AutomationManagement.Models.ContentLink()
                    {
                        Uri = contentLink.ToString(),
                        ContentHash = null,
                        Version = null
                    },
                });

            return this.GetPython3Package(resourceGroupName, automationAccountName, moduleName);
        }

        public Module UpdatePython3Package(string resourceGroupName, string automationAccountName, string name,
            Uri contentLinkUri, string contentLinkVersion)
        {
            try
            {
                var moduleModel =
                this.automationManagementClient.Python3Package.Get(resourceGroupName, automationAccountName, name);
                if (contentLinkUri != null)
                {
                    var updateModule = this.automationManagementClient.Python3Package.Update(resourceGroupName,
                    automationAccountName,
                    name,
                    new AutomationManagement.Models.PythonPackageUpdateParameters());
                }
                var updatedModule =
                this.automationManagementClient.Python3Package.Get(resourceGroupName, automationAccountName, name);
                return new Module(resourceGroupName, automationAccountName, updatedModule);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Module),
                        string.Format(CultureInfo.CurrentCulture, Resources.ModuleNotFound, name));

                }

                throw;
            }
        }

        #endregion



        #region Private Methods

        private Schedule CreateScheduleFromScheduleModel(string resourceGroupName, string automationAccountName,
            AutomationManagement.Models.Schedule schedule)
        {
            Requires.Argument("schedule", schedule).NotNull();

            return new Schedule(resourceGroupName, automationAccountName, schedule);
        }

        private JobSchedule CreateJobScheduleFromJobScheduleModel(string resourceGroupName, string automationAccountName,
            AutomationManagement.Models.JobSchedule jobSchedule)
        {
            Requires.Argument("jobSchedule", jobSchedule).NotNull();

            return new JobSchedule(resourceGroupName, automationAccountName, jobSchedule);
        }

        private Azure.Management.Automation.Models.Runbook TryGetRunbookModel(string resourceGroupName, string automationAccountName,
            string runbookName)
        {
            Azure.Management.Automation.Models.Runbook runbook = null;
            try
            {
                runbook = this.automationManagementClient.Runbook.Get(resourceGroupName, automationAccountName, runbookName);
            }
            catch (ErrorResponseException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
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

        private Azure.Management.Automation.Models.HybridRunbookWorkerGroup TryGetHybridRunbookWorkerModel(string resourceGroupName, string automationAccountName, string HybridRunbookWorkerGroupName)
        {
            Azure.Management.Automation.Models.HybridRunbookWorkerGroup hybridRunbookWorkerGroup = null;
            try
            {
                hybridRunbookWorkerGroup = this.automationManagementClient.HybridRunbookWorkerGroup.Get(resourceGroupName, automationAccountName, HybridRunbookWorkerGroupName);
            }
            catch (ErrorResponseException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    hybridRunbookWorkerGroup = null;
                }
                else
                {
                    throw;
                }
            }
            return hybridRunbookWorkerGroup;
        }

        private Management.Automation.Models.HybridRunbookWorkerGroup TryGetHybridRunbookWorkerGroupModel(string resourceGroupName, string automationAccountName, string HybridRunbookWorkerGroupName)
        {
            Azure.Management.Automation.Models.HybridRunbookWorkerGroup hybridRunbookWorkerGroup = null;
            try
            {
                hybridRunbookWorkerGroup = this.automationManagementClient.HybridRunbookWorkerGroup.Get(resourceGroupName, automationAccountName, HybridRunbookWorkerGroupName);
            }
            catch (ErrorResponseException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    hybridRunbookWorkerGroup = null;
                }
                else
                {
                    throw;
                }
            }
            return hybridRunbookWorkerGroup;
        }


        private Management.Automation.Models.HybridRunbookWorker TryGetHybridRunbookWorkerModel(string resourceGroupName, string automationAccountName, string HybridRunbookWorkerGroupName, string workerId)
        {
            Azure.Management.Automation.Models.HybridRunbookWorker hybridRunbookWorker = null;
            try
            {
                hybridRunbookWorker = this.automationManagementClient.HybridRunbookWorkers.Get(resourceGroupName, automationAccountName, HybridRunbookWorkerGroupName, workerId);
            }
            catch (ErrorResponseException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    hybridRunbookWorker = null;
                }
                else
                {
                    throw;
                }
            }
            return hybridRunbookWorker;
        }

        private Azure.Management.Automation.Models.Certificate TryGetCertificateModel(string resourceGroupName, string automationAccountName, 
            string certificateName)
        {
            Azure.Management.Automation.Models.Certificate certificate = null;
            try
            {
                certificate =
                    this.automationManagementClient.Certificate.Get(resourceGroupName, automationAccountName, certificateName);
            }
            catch (ErrorResponseException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
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

        private IEnumerable<KeyValuePair<string, RunbookParameter>> ListRunbookParameters(string resourceGroupName, string automationAccountName,
            string runbookName)
        {
            Runbook runbook = null;
            try
            {
                runbook = this.GetRunbook(resourceGroupName, automationAccountName, runbookName);
            }
            catch(ResourceCommonException)
            {
                // Ignore if runbook does not exists in the account. This is to start global runbooks by name
                return new Dictionary<string, RunbookParameter>();
            }

            if (0 == String.Compare(runbook.State, RunbookState.New, CultureInfo.InvariantCulture,
                CompareOptions.IgnoreCase))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                    Resources.RunbookHasNoPublishedVersion, runbookName));
            }
            return runbook.Parameters.Cast<DictionaryEntry>()
                .ToDictionary(k => k.Key.ToString(), k => (RunbookParameter)k.Value);
        }

        private IDictionary<string, string> ProcessRunbookParameters(string resourceGroupName, string automationAccountName, string runbookName,
            IDictionary parameters)
        {
            Runbook runbook = null;
            IEnumerable<KeyValuePair<string, RunbookParameter>> runbookParameters = null;
            parameters = parameters ?? new Dictionary<string, string>();
            var filteredParameters = new Dictionary<string, string>();
            
            try
            {
                runbook = this.GetRunbook(resourceGroupName, automationAccountName, runbookName);
            }
            catch (ResourceCommonException)
            {
                // Ignore if runbook does not exists in the account. This is to start global runbooks by name
                runbookParameters = new Dictionary<string, RunbookParameter>();
            }
            
            if (runbook != null && 0 == String.Compare(runbook.State, RunbookState.New, CultureInfo.InvariantCulture, CompareOptions.IgnoreCase))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                    Resources.RunbookHasNoPublishedVersion, runbookName));
            }
            
            if (runbook != null && (runbook.RunbookType == "Python2" || runbook.RunbookType == "Python3")) {
                int i = 1;

                foreach (var key in parameters.Keys) {
                    object paramValue = parameters[key];
                    try {
                        filteredParameters.Add("[Parameter " + i.ToString() + "]", PowerShellJsonConverter.Serialize(paramValue));
                    }
                    catch(JsonSerializationException)
                    {
                        throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.RunbookParameterCannotBeSerializedToJson, key));
                    }
                    i++;
                }
            }
            else {
                runbookParameters = runbook.Parameters.Cast<DictionaryEntry>().ToDictionary(k => k.Key.ToString(), k => (RunbookParameter)k.Value);

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
                                    CultureInfo.CurrentCulture, Resources.RunbookParameterCannotBeSerializedToJson,
                                    runbookParameter.Key));
                        }
                    }
                    else if (runbookParameter.Value.IsMandatory.HasValue && runbookParameter.Value.IsMandatory.Value)
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
            }
            
            return filteredParameters;
        }

        private IDictionary<string, string> ProcessRunbookParameters(IEnumerable<KeyValuePair<string, RunbookParameter>> runbookParameters,
            IDictionary<string, object> parameters)
        {
            parameters = parameters ?? new Dictionary<string, object>();

            var filteredParameters = new Dictionary<string, string>();

            foreach (var runbookParameter in runbookParameters)
            {
                if (parameters.ContainsKey(runbookParameter.Key))
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
                                CultureInfo.CurrentCulture, Resources.RunbookParameterCannotBeSerializedToJson,
                                runbookParameter.Key));
                    }
                }
                else if (runbookParameter.Value.IsMandatory.HasValue && runbookParameter.Value.IsMandatory.Value)
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

            return filteredParameters;
        }

        
        private AutomationManagement.Models.Schedule GetScheduleModel(string resourceGroupName, string automationAccountName, string scheduleName)
        {
            AutomationManagement.Models.Schedule scheduleModel;
            try
            {
                scheduleModel = this.automationManagementClient.Schedule.Get(
                    resourceGroupName,
                    automationAccountName,
                    scheduleName);
            }
            catch (ErrorResponseException cloudException)
            {
                if (cloudException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Schedule),
                        string.Format(CultureInfo.CurrentCulture, Resources.ScheduleNotFound, scheduleName));
                }

                throw;
            }

            return scheduleModel;
        }


        private Schedule UpdateScheduleHelper(string resourceGroupName, string automationAccountName,
            string scheduleName, bool? isEnabled, string description)
        {
            var scheduleUpdateParameters = new AutomationManagement.Models.ScheduleUpdateParameters
            {
                Name = scheduleName,
                Description = description,
                IsEnabled = isEnabled
            };

            this.automationManagementClient.Schedule.Update(
                resourceGroupName,
                automationAccountName,
                scheduleName,
                scheduleUpdateParameters);

            return this.GetSchedule(resourceGroupName, automationAccountName, scheduleName);
        }

        private Certificate CreateCertificateInternal(string resourceGroupName, string automationAccountName, string name, string path,
            SecureString password, string description, bool exportable)
        {
            var cert = (password == null)
                ? new X509Certificate2(path, String.Empty,
                    X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet |
                    X509KeyStorageFlags.MachineKeySet)
                : new X509Certificate2(path, password,
                    X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet |
                    X509KeyStorageFlags.MachineKeySet);

            var ccparam = new CertificateCreateOrUpdateParameters()
            {
                Name = name,
                Description = description,
                Base64Value = Convert.ToBase64String(cert.Export(X509ContentType.Pkcs12)),
                Thumbprint = cert.Thumbprint,
                IsExportable = exportable
            };

            var certificate =
                this.automationManagementClient.Certificate.CreateOrUpdate(resourceGroupName, automationAccountName, name, ccparam);

            return new Certificate(resourceGroupName, automationAccountName, certificate);
        }

        private Azure.Management.Automation.Models.Connection TryGetConnectionModel(string resourceGroupName, string automationAccountName,
            string connectionName)
        {
            Azure.Management.Automation.Models.Connection connection = null;
            try
            {
                connection =
                    this.automationManagementClient.Connection.Get(resourceGroupName, automationAccountName, connectionName);
            }
            catch (ErrorResponseException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
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

        private DirectoryInfo WriteRunbookToFile(string outputFolder, string runbookName, string content, string runbookType, bool overwriteExistingFile)
        {
            string outputFolderFullPath = this.GetCurrentDirectory();

            if (!string.IsNullOrEmpty(outputFolder))
            {
                outputFolderFullPath = this.ValidateAndGetFullPath(outputFolder);
            }

            var fileExtension = IsGraphRunbook(runbookType) ? Constants.SupportedFileExtensions.Graph : Constants.SupportedFileExtensions.PowerShellScript;

            var outputFilePath = Path.Combine(outputFolderFullPath, runbookName + fileExtension);

            // file exists and overwrite Not specified
            if (File.Exists(outputFilePath) && !overwriteExistingFile)
            {
                throw new ArgumentException(
                        string.Format(CultureInfo.CurrentCulture, Resources.RunbookFileAlreadyExists, outputFilePath));
            }

            // Write to the file
            this.WriteFile(outputFilePath, content);

            return new DirectoryInfo(runbookName + fileExtension);
        }

        private string GetJobFilterString(string runbookName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus)
        {
            string filter = null;
            List<string> odataFilter = new List<string>();
            if (startTime.HasValue)
            {
                odataFilter.Add("properties/startTime ge " + this.FormatDateTime(startTime.Value));
            }
            if (endTime.HasValue)
            {
                odataFilter.Add("properties/endTime le " + this.FormatDateTime(endTime.Value));
            }
            if (!string.IsNullOrWhiteSpace(jobStatus))
            {
                odataFilter.Add("properties/status eq '" + Uri.EscapeDataString(jobStatus) + "'");
            }
            if (!string.IsNullOrWhiteSpace(runbookName))
            {
                odataFilter.Add("properties/runbook/name eq '" + Uri.EscapeDataString(runbookName) + "'");
            }
            if (odataFilter.Count > 0)
            {
                filter = string.Join(" and ", odataFilter);
            }

            return filter;
        }

        private string GetJobStreamFilterString(DateTimeOffset? time, string streamType)
        {
            string filter = null;
            List<string> odataFilter = new List<string>();
            if (time.HasValue)
            {
                odataFilter.Add("properties/time ge " + this.FormatDateTime(time.Value));
            }
            if (!string.IsNullOrWhiteSpace(streamType))
            {
                odataFilter.Add("properties/streamType eq '" + Uri.EscapeDataString(streamType) + "'");
            }

            if (odataFilter.Count > 0)
            {
                filter = string.Join(" and ", odataFilter);
            }

            return filter;
        }

        private static bool IsGraphRunbook(string runbookType)
        {
            return (string.Equals(runbookType, RunbookTypeEnum.Graph, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(runbookType, RunbookTypeEnum.GraphPowerShell, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(runbookType, RunbookTypeEnum.GraphPowerShellWorkflow, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsValidJson(string value)
        {
            try
            {
                var json = JContainer.Parse(value);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
