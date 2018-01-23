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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using Microsoft.Azure.Commands.DataFactoryV2.Models;
using Microsoft.Azure.Commands.DataFactoryV2.Properties;
using Microsoft.Azure.Management.DataFactory;
using Microsoft.Azure.Management.DataFactory.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.Serialization;

namespace Microsoft.Azure.Commands.DataFactoryV2
{
    public partial class DataFactoryClient
    {
        public virtual HttpStatusCode DeleteTrigger(string resourceGroupName, string dataFactoryName, string triggerName)
        {
            Rest.Azure.AzureOperationResponse response = this.DataFactoryManagementClient.Triggers.DeleteWithHttpMessagesAsync(resourceGroupName,
                dataFactoryName, triggerName).Result;

            return response.Response.StatusCode;
        }

        public virtual List<PSTrigger> FilterPSTriggers(AdfEntityFilterOptions filterOptions)
        {
            if (filterOptions == null)
            {
                throw new ArgumentNullException("filterOptions");
            }
            
            var triggers = new List<PSTrigger>();

            if (filterOptions.Name != null)
            {
                triggers.Add(GetTrigger(filterOptions.ResourceGroupName, filterOptions.DataFactoryName, filterOptions.Name));
            }
            else
            {
                triggers.AddRange(ListTriggers(filterOptions));
            }

            return triggers;
        }

        public virtual PSTrigger CreatePSTrigger(CreatePSAdfEntityParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }

            PSTrigger trigger = null;
            Action createTrigger = () =>
            {
                trigger =
                    new PSTrigger(CreateOrUpdateTrigger(parameters.ResourceGroupName,
                        parameters.DataFactoryName,
                        parameters.Name,
                        parameters.RawJsonContent), parameters.ResourceGroupName,
                        parameters.DataFactoryName
                    );
            };

            parameters.ConfirmAction(
                    parameters.Force,  // prompt only if the linked service exists
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.TriggerExists,
                        parameters.Name,
                        parameters.DataFactoryName),
                    string.Format(
                        CultureInfo.InvariantCulture,
                        Resources.TriggerCreating,
                        parameters.Name,
                        parameters.DataFactoryName),
                    parameters.Name,
                    createTrigger,
                    () => CheckTriggerExists(parameters.ResourceGroupName,
                            parameters.DataFactoryName, parameters.Name));

            return trigger;
        }

        public virtual void StartTrigger(string resourceGroupName, string dataFactoryName, string triggerName)
        {
            this.DataFactoryManagementClient.Triggers.Start(resourceGroupName, dataFactoryName, triggerName);
        }

        public virtual void StopTrigger(string resourceGroupName, string dataFactoryName, string triggerName)
        {
            this.DataFactoryManagementClient.Triggers.Stop(resourceGroupName, dataFactoryName, triggerName);
        }

        private TriggerResource CreateOrUpdateTrigger(string resourceGroupName, string dataFactoryName,
            string triggerName, string rawJsonContent)
        {
            if (string.IsNullOrWhiteSpace(rawJsonContent))
            {
                throw new ArgumentNullException("rawJsonContent");
            }

            TriggerResource triggerResource;
            try
            {
                triggerResource = SafeJsonConvert.DeserializeObject<TriggerResource>(rawJsonContent, this.DataFactoryManagementClient.DeserializationSettings);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(string.Format("Json is not valid. Details: '{0}'", ex));
            }

            // If create or update failed, the current behavior is to throw
            return this.DataFactoryManagementClient.Triggers.CreateOrUpdate(
                    resourceGroupName,
                    dataFactoryName,
                    triggerName,
                    triggerResource);
        }

        private PSTrigger GetTrigger(string resourceGroupName, string dataFactoryName,
            string triggerName)
        {
            TriggerResource response = this.DataFactoryManagementClient.Triggers.Get(resourceGroupName, dataFactoryName,
                triggerName);

            if (response == null)
            {
                return null;
            }
            return new PSTrigger(response, resourceGroupName, dataFactoryName);
        }

        private List<PSTrigger> ListTriggers(AdfEntityFilterOptions filterOptions)
        {
            var triggers = new List<PSTrigger>();

            IPage<TriggerResource> response;
            if (filterOptions.NextLink.IsNextPageLink())
            {
                response = this.DataFactoryManagementClient.Triggers.ListByFactoryNext(filterOptions.NextLink);
            }
            else
            {
                response = this.DataFactoryManagementClient.Triggers.ListByFactory(filterOptions.ResourceGroupName,
                    filterOptions.DataFactoryName);
            }
            filterOptions.NextLink = response != null ? response.NextPageLink : null;

            if (response != null)
            {
                triggers.AddRange(response.ToList().Select(trigger =>
                    new PSTrigger(trigger, filterOptions.ResourceGroupName, filterOptions.DataFactoryName)));
            }

            return triggers;
        }

        private bool CheckTriggerExists(string resourceGroupName, string dataFactoryName, string triggerName)
        {
            try
            {
                PSTrigger trigger = GetTrigger(resourceGroupName, dataFactoryName, triggerName);
                return trigger != null;
            }
            catch (ErrorResponseException e)
            {
                //Get throws Exception message with NotFound Status
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
