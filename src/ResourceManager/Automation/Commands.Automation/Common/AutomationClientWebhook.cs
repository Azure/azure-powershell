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
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;

namespace Microsoft.Azure.Commands.Automation.Common
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net;
using Hyak.Common;

    using Microsoft.Azure.Commands.Automation.Properties;

    public partial class AutomationClient : IAutomationClient
    {
        public Model.Webhook CreateWebhook(
            string resourceGroupName,
            string automationAccountName,
            string name,
            string runbookName,
            bool isEnabled,
            DateTimeOffset expiryTime,
            Dictionary<string, string> runbookParameters)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            var createOrUpdateProperties = new WebhookCreateOrUpdateProperties
                                               {
                                                   IsEnabled = isEnabled,
                                                   ExpiryTime = expiryTime,
                                                   Runbook = { Name = runbookName },
                                                   Parameters = runbookParameters,
                                                   Uri =
                                                       this.automationManagementClient
                                                       .Webhooks.GenerateUri(
                                                           resourceGroupName,
                                                           automationAccountName).Uri
                                               };

            var webhookCreateOrUpdateParameters = new WebhookCreateOrUpdateParameters(name, createOrUpdateProperties);
            
            var webhook = this.automationManagementClient.Webhooks.CreateOrUpdate(
                             resourceGroupName,
                             automationAccountName,
                             webhookCreateOrUpdateParameters).Webhook;

            return new Model.Webhook(resourceGroupName, automationAccountName, webhook);
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

        public Model.Webhook UpdateWebhook(
            string resourceGroupName,
            string automationAccountName,
            string name,
            string runbookName,
            Dictionary<string, string> parameters,
            bool isEnabled)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            var webhookCreateOrUpdateProperties = new WebhookCreateOrUpdateProperties
                                                      {
                                                          IsEnabled = isEnabled,
                                                          Parameters = parameters,
                                                          Runbook = new RunbookAssociationProperty{Name = runbookName}
                                                      };
            var webhookCreateOrUpdateParameters = new WebhookCreateOrUpdateParameters(
                name,
                webhookCreateOrUpdateProperties);

            var webhook =
                this.automationManagementClient.Webhooks.CreateOrUpdate(
                    resourceGroupName,
                    automationAccountName,
                    webhookCreateOrUpdateParameters).Webhook;
            return new Model.Webhook(resourceGroupName, automationAccountName, webhook);
        }

        public void DeleteWebhook(
         string resourceGroupName,
         string automationAccountName,
         string name)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            this.automationManagementClient.Webhooks.Delete(
                resourceGroupName,
                automationAccountName,
                name);
        }
    }
}
