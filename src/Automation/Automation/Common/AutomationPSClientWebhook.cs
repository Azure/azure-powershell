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

using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Rest.Azure.OData;

namespace Microsoft.Azure.Commands.Automation.Common
{
    using System.Collections;
    using System.Linq;

    public partial class AutomationPSClient : IAutomationPSClient
    {
        public Model.Webhook CreateWebhook(
            string resourceGroupName,
            string automationAccountName,
            string name,
            string runbookName,
            bool isEnabled,
            DateTimeOffset expiryTime,
            IDictionary runbookParameters,
            string runOn)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var rbAssociationProperty = new RunbookAssociationProperty { Name = runbookName };

                var webhookCreateOrUpdateParameters = new WebhookCreateOrUpdateParameters {
                    Name = name,
                    IsEnabled = isEnabled,
                    ExpiryTime = expiryTime.DateTime.ToUniversalTime(),
                    Runbook = rbAssociationProperty,
                    Uri = this.automationManagementClient.Webhook.GenerateUri(resourceGroupName, automationAccountName),
                    Parameters = (runbookParameters != null) ? this.ProcessRunbookParameters(resourceGroupName, automationAccountName, runbookName, runbookParameters) : null,
                    RunOn = runOn
                };

            var webhook =
                    this.automationManagementClient.Webhook.CreateOrUpdate(
                        resourceGroupName,
                        automationAccountName,
                        name,
                        webhookCreateOrUpdateParameters);

                return new Model.Webhook(
                    resourceGroupName,
                    automationAccountName,
                    webhook,
                    webhookCreateOrUpdateParameters.Uri);
            }
        }

        public Model.Webhook GetWebhook(string resourceGroupName, string automationAccountName, string name)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                try
                {
                    var webhook =
                        this.automationManagementClient.Webhook.Get(resourceGroupName, automationAccountName, name);
                    if (webhook == null)
                    {
                        throw new ResourceNotFoundException(
                            typeof(Webhook),
                            string.Format(CultureInfo.CurrentCulture, Resources.WebhookNotFound, name));
                    }

                    return new Model.Webhook(resourceGroupName, automationAccountName, webhook);
                }
                catch (ErrorResponseException ErrorResponseException)
                {
                    if (ErrorResponseException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        throw new ResourceNotFoundException(
                            typeof(Webhook),
                            string.Format(CultureInfo.CurrentCulture, Resources.WebhookNotFound, name));
                    }

                    throw;
                }
            }
        }

        public IEnumerable<Model.Webhook> ListWebhooks(string resourceGroupName, string automationAccountName, string runbookName, ref string nextLink)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            Rest.Azure.IPage<Webhook> response;

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                if (string.IsNullOrEmpty(nextLink))
                {
                    if (runbookName == null)
                    {
                        response = this.automationManagementClient.Webhook.ListByAutomationAccount(
                            resourceGroupName,
                            automationAccountName,
                            null);
                    }
                    else
                    {
                        var filter = GetRunbookNameFilterString(runbookName);
                        response = this.automationManagementClient.Webhook.ListByAutomationAccount(
                            resourceGroupName,
                            automationAccountName,
                            new ODataQuery<Webhook>(filter));
                    }
                }
                else
                {
                    response = this.automationManagementClient.Webhook.ListByAutomationAccountNext(nextLink);
                }

                nextLink = response.NextPageLink;
                return
                    response.Select(w => new Model.Webhook(resourceGroupName, automationAccountName, w))
                        .ToList();
            }
        }

        public Model.Webhook UpdateWebhook(
            string resourceGroupName,
            string automationAccountName,
            string name,
            IDictionary parameters,
            bool? isEnabled,
            string RunOn)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var webhookModel =
                    this.automationManagementClient.Webhook.Get(resourceGroupName, automationAccountName, name);
                var webhookPatchParameters = new WebhookUpdateParameters
                {
                    Name = name
                };
                if (webhookModel != null)
                {
                    if (isEnabled != null)
                    {
                        webhookPatchParameters.IsEnabled = isEnabled.Value;
                    }
                    if (parameters != null)
                    {
                        webhookPatchParameters.Parameters =
                            this.ProcessRunbookParameters(resourceGroupName, automationAccountName, webhookModel.Runbook.Name, parameters);
                    }
                    if (RunOn != null)
                    {
                        webhookPatchParameters.RunOn = RunOn;

                    }
                }
                
                var webhook =
                    this.automationManagementClient.Webhook.Update(
                        resourceGroupName,
                        automationAccountName,
                        name,
                        webhookPatchParameters);

                return new Model.Webhook(resourceGroupName, automationAccountName, webhook);
            }
        }

        public void DeleteWebhook(string resourceGroupName, string automationAccountName, string name)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                try
                {
                    this.automationManagementClient.Webhook.Delete(resourceGroupName, automationAccountName, name);
                }
                catch (ErrorResponseException ErrorResponseException)
                {
                    if (ErrorResponseException.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        throw new ResourceNotFoundException(
                            typeof(Webhook),
                            string.Format(CultureInfo.CurrentCulture, Resources.WebhookNotFound, name));
                    }
                    throw;
                }
            }
        }

        private string GetRunbookNameFilterString(string runbookName)
        {
            string filter = null;
            List<string> odataFilter = new List<string>();

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
    }
}
