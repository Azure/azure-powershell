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
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Common.Authentication.Models;
using Newtonsoft.Json;

using AutomationAccount = Microsoft.Azure.Commands.Automation.Model.AutomationAccount;
using Module = Microsoft.Azure.Commands.Automation.Model.Module;


namespace Microsoft.Azure.Commands.Automation.Common
{
    using AutomationManagement = Azure.Management.Automation;
    using Microsoft.Azure.Common.Authentication;
    using Hyak.Common;


    public partial class AutomationClient : IAutomationClient
    {
        private readonly AutomationManagement.IAutomationManagementClient automationManagementClient;

        // Injection point for unit tests
        public AutomationClient()
        {
        }

        public AutomationClient(AzureProfile profile, AzureSubscription subscription)
            : this(subscription,
            AzureSession.ClientFactory.CreateClient<AutomationManagement.AutomationManagementClient>(profile, subscription, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public AutomationClient(AzureSubscription subscription,
            AutomationManagement.IAutomationManagementClient automationManagementClient)
        {
            Requires.Argument("automationManagementClient", automationManagementClient).NotNull();

            this.Subscription = subscription;
            this.automationManagementClient = automationManagementClient;
        }

        void SetClientIdHeader(string clientRequestId)
        {
            var client = ((AutomationManagementClient) this.automationManagementClient);
            client.HttpClient.DefaultRequestHeaders.Remove(Constants.ClientRequestIdHeaderName);
            client.HttpClient.DefaultRequestHeaders.Add(Constants.ClientRequestIdHeaderName, clientRequestId);   
        }

        public AzureSubscription Subscription { get; private set; }

        #region Account Operations

        public IEnumerable<Model.AutomationAccount> ListAutomationAccounts(string resourceGroupName)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();

            return AutomationManagementClient
                .ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.AutomationAccounts.List(
                            resourceGroupName);
                        return new ResponseWithSkipToken<AutomationManagement.Models.AutomationAccount>(
                            response, response.AutomationAccounts);
                    }).Select(c => new Model.AutomationAccount(resourceGroupName, c));
        }

        public AutomationAccount GetAutomationAccount(string resourceGroupName, string automationAccountName)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            var account = this.automationManagementClient.AutomationAccounts.Get(resourceGroupName, automationAccountName).AutomationAccount;

            return new Model.AutomationAccount(resourceGroupName, account);
        }

        public AutomationAccount CreateAutomationAccount(string resourceGroupName, string automationAccountName, string location, string plan, IDictionary tags)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("Location", location).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).ValidAutomationAccountName();

            IDictionary<string, string> accountTags = null;
            if (tags != null) accountTags = tags.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());

            var accountCreateParameters = new AutomationAccountCreateOrUpdateParameters()
            {
                Location = location,
                Name = automationAccountName,
                Properties = new AutomationAccountCreateOrUpdateProperties()
                {
                    Sku = new Sku()
                    {
                        Name = String.IsNullOrWhiteSpace(plan) ? Constants.DefaultPlan : plan,
                    }
                },
                Tags = accountTags
            };

            var account =
                this.automationManagementClient.AutomationAccounts.CreateOrUpdate(resourceGroupName,
                    accountCreateParameters).AutomationAccount;


            return new AutomationAccount(resourceGroupName, account);
        }

        public AutomationAccount UpdateAutomationAccount(string resourceGroupName, string automationAccountName, string plan, IDictionary tags)
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
                accountTags = automationAccount.Tags.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString()); ;
            }

            var accountUpdateParameters = new AutomationAccountPatchParameters()
            {
                Name = automationAccountName,
                Properties = new AutomationAccountPatchProperties()
                {
                    Sku = new Sku()
                    {
                        Name = String.IsNullOrWhiteSpace(plan) ? automationAccount.Plan : plan,
                    }
                },
                Tags = accountTags,
            };

            var account =
                this.automationManagementClient.AutomationAccounts.Patch(resourceGroupName,
                    accountUpdateParameters).AutomationAccount;


            return new AutomationAccount(resourceGroupName, account);
        }

        public void DeleteAutomationAccount(string resourceGroupName, string automationAccountName)
        {
            try
            {
                this.automationManagementClient.AutomationAccounts.Delete(
                    resourceGroupName,
                    automationAccountName);
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(AutomationAccount),
                        string.Format(CultureInfo.CurrentCulture, Resources.AutomationAccountNotFound, automationAccountName));
                }

                throw;
            }
        }

        #endregion

        #region Modules
        public Module CreateModule(string resourceGroupName, string automationAccountName, Uri contentLink, string moduleName)
        {
            var createdModule = this.automationManagementClient.Modules.CreateOrUpdate(resourceGroupName, automationAccountName,
                new AutomationManagement.Models.ModuleCreateOrUpdateParameters()
                {
                    Name = moduleName,
                    Properties = new AutomationManagement.Models.ModuleCreateOrUpdateProperties()
                    {
                        ContentLink = new AutomationManagement.Models.ContentLink()
                        {
                            Uri = contentLink,
                            ContentHash = null,
                            Version = null
                        }
                    },
                });

            return this.GetModule(resourceGroupName, automationAccountName, moduleName);
        }

        public Module GetModule(string resourceGroupName, string automationAccountName, string name)
        {
            try
            {
                var module = this.automationManagementClient.Modules.Get(resourceGroupName, automationAccountName, name).Module;
                return new Module(resourceGroupName, automationAccountName, module);
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

        public IEnumerable<Module> ListModules(string resourceGroupName, string automationAccountName)
        {
            IList<AutomationManagement.Models.Module> modulesModels = AutomationManagementClient
                .ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.Modules.List(resourceGroupName, automationAccountName);
                        return new ResponseWithSkipToken<AutomationManagement.Models.Module>(
                            response, response.Modules);
                    });

            return modulesModels.Select(c => new Module(resourceGroupName, automationAccountName, c));
        }

        public Module UpdateModule(string resourceGroupName, string automationAccountName, string name, Uri contentLinkUri, string contentLinkVersion)
        {
            var moduleModel = this.automationManagementClient.Modules.Get(resourceGroupName, automationAccountName, name).Module;
            if (contentLinkUri != null)
            {
                var modulePatchParameters = new AutomationManagement.Models.ModulePatchParameters();

                modulePatchParameters.Name = name;
                modulePatchParameters.Properties = new ModulePatchProperties();
                modulePatchParameters.Properties.ContentLink = new AutomationManagement.Models.ContentLink();
                modulePatchParameters.Properties.ContentLink.Uri = contentLinkUri;
                modulePatchParameters.Properties.ContentLink.Version =
                    (String.IsNullOrWhiteSpace(contentLinkVersion))
                        ? Guid.NewGuid().ToString()
                        : contentLinkVersion;

                modulePatchParameters.Tags = moduleModel.Tags;

                this.automationManagementClient.Modules.Patch(resourceGroupName, automationAccountName, modulePatchParameters);
            }

            var updatedModule = this.automationManagementClient.Modules.Get(resourceGroupName, automationAccountName, name).Module;
            return new Module(resourceGroupName, automationAccountName, updatedModule);
        }

        public void DeleteModule(string resourceGroupName, string automationAccountName, string name)
        {
            try
            {
                var module = this.automationManagementClient.Modules.Delete(resourceGroupName, automationAccountName, name);
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
       
    }
}