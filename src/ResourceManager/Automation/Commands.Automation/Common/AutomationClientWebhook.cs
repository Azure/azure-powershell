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

using Hyak.Common;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace Microsoft.Azure.Commands.Automation.Common
{
    using System.Collections;
    using System.Linq;

    using Microsoft.WindowsAzure.Commands.Utilities.Common;

    public partial class AutomationClient : IAutomationClient
    {
        public Model.Webhook CreateWebhook(
            string resourceGroupName,
            string automationAccountName,
            string name,
            string runbookName,
            bool isEnabled,
            DateTimeOffset expiryTime,
            Hashtable runbookParameters)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            var rbAssociationProperty = new RunbookAssociationProperty { Name = runbookName };

            var createOrUpdateProperties = new WebhookCreateOrUpdateProperties
                                               {
                                                   IsEnabled = isEnabled,
                                                   ExpiryTime = expiryTime,
                                                   Runbook = rbAssociationProperty,
                                                   Uri =
                                                       this.automationManagementClient
                                                       .Webhooks.GenerateUri(
                                                           resourceGroupName,
                                                           automationAccountName).Uri
                                               };
            if (runbookParameters != null)
            {
                createOrUpdateProperties.Parameters =
                    runbookParameters.Cast<DictionaryEntry>()
                        .ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value);
            }

            var webhookCreateOrUpdateParameters = new WebhookCreateOrUpdateParameters(name, createOrUpdateProperties);
            
            var webhook = this.automationManagementClient.Webhooks.CreateOrUpdate(
                             resourceGroupName,
                             automationAccountName,
                             webhookCreateOrUpdateParameters).Webhook;

            return new Model.Webhook(resourceGroupName, automationAccountName, webhook, webhookCreateOrUpdateParameters.Properties.Uri);
        }

        public Model.Webhook GetWebhook(string resourceGroupName, string automationAccountName, string name)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            try
            {
                var webhook =
                    this.automationManagementClient.Webhooks.Get(resourceGroupName, automationAccountName, name).Webhook;
                if (webhook == null)
                {
                    throw new ResourceNotFoundException(typeof(Webhook),
                        string.Format(CultureInfo.CurrentCulture, Resources.WebhookNotFound, name));
                }

                return new Model.Webhook(resourceGroupName, automationAccountName, webhook);
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    throw new ResourceNotFoundException(typeof(Webhook),
                        string.Format(CultureInfo.CurrentCulture, Resources.WebhookNotFound, name));
                }

                throw;
            }
        }

        public IEnumerable<Model.Webhook> GetWebhooksByRunbookName(string resourceGroupName, string automationAccountName, string runbookName)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            var webhooks =
                this.automationManagementClient.Webhooks.List(resourceGroupName, automationAccountName, runbookName).Webhooks;
            return webhooks.Select(w => new Model.Webhook(resourceGroupName, automationAccountName, w)).ToList();
        }

        public IEnumerable<Model.Webhook> ListWebhooks(string resourceGroupName, string automationAccountName)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            var runbooks =
                this.automationManagementClient.Runbooks.List(resourceGroupName, automationAccountName).Runbooks;
            
            List<Model.Webhook> webhooks = new List<Model.Webhook>();
            foreach (Runbook runbook in runbooks)
            {
                webhooks.AddRange(this.GetWebhooksByRunbookName(resourceGroupName, automationAccountName, runbook.Name).ToList());
            }
            return webhooks;
        }

        public Model.Webhook UpdateWebhook(
            string resourceGroupName,
            string automationAccountName,
            string name,
            Hashtable parameters,
            bool? isEnabled)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            var webhookModel = this.automationManagementClient.Webhooks.Get(resourceGroupName, automationAccountName, name).Webhook;
            var webhookPatchProperties = new WebhookPatchProperties();
            if (webhookModel != null)
            {
                if (isEnabled != null)
                {
                    webhookPatchProperties.IsEnabled = isEnabled.Value;
                }
                if (parameters != null)
                {
                    webhookPatchProperties.Parameters =
                        parameters.Cast<DictionaryEntry>()
                            .ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value);
                }
            }
         
            var webhookPatchParameters = new WebhookPatchParameters(name) { Properties = webhookPatchProperties };
            var webhook =
                this.automationManagementClient.Webhooks.Patch(
                    resourceGroupName,
                    automationAccountName,
                    webhookPatchParameters).Webhook;
            return new Model.Webhook(resourceGroupName, automationAccountName, webhook);
        }

        public void DeleteWebhook(string resourceGroupName, string automationAccountName, string name)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            try
            {
                this.automationManagementClient.Webhooks.Delete(resourceGroupName, automationAccountName, name);
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(Webhook), string.Format(CultureInfo.CurrentCulture, Resources.WebhookNotFound, name));
                }
                throw;
            }
        }
    }
}
