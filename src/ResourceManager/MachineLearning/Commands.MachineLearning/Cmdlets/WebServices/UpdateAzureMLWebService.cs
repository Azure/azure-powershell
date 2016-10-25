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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using Microsoft.WindowsAzure.Commands.Common;

namespace Microsoft.Azure.Commands.MachineLearning
{
    [Cmdlet(
        VerbsData.Update, 
        WebServicesCmdletBase.CommandletSuffix, 
        SupportsShouldProcess = true)]
    [OutputType(typeof(WebService))]
    public class UpdateAzureMLWebService : WebServicesCmdletBase
    {
        protected const string UpdateFromArgumentsParameterSet = 
            "Update specific properties of the .";
        protected const string UpdateFromObjectParameterSet = 
            "Create a new Azure ML webservice from a WebService instance definition.";

        [Parameter(Mandatory = true, HelpMessage = "The name of the resource group for the Azure ML web service.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The name of the web service.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureMLWebService.UpdateFromArgumentsParameterSet, 
            Mandatory = false, 
            HelpMessage = "New title for the web service.")]
        public string Title { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureMLWebService.UpdateFromArgumentsParameterSet, 
            Mandatory = false, 
            HelpMessage = "New description for the web service.")]
        public string Description { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureMLWebService.UpdateFromArgumentsParameterSet, 
            Mandatory = false, 
            HelpMessage = "Mark the service as readonly.")]
        public SwitchParameter IsReadOnly { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureMLWebService.UpdateFromArgumentsParameterSet, 
            Mandatory = false, 
            HelpMessage = "New access keys for the web service.")]
        public WebServiceKeys Keys { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureMLWebService.UpdateFromArgumentsParameterSet, 
            Mandatory = false, 
            HelpMessage = "New access key for the storage account associated with the web service. This allows for key rotation if needed.")]
        public string StorageAccountKey { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureMLWebService.UpdateFromArgumentsParameterSet, 
            Mandatory = false, 
            HelpMessage = "New diagnostics settings for the web service.")]
        public DiagnosticsConfiguration Diagnostics { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureMLWebService.UpdateFromArgumentsParameterSet, 
            Mandatory = false, 
            HelpMessage = "New realtime endpoint runtime settings for the web service.")]
        public RealtimeConfiguration RealtimeConfiguration { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureMLWebService.UpdateFromArgumentsParameterSet, 
            Mandatory = false, 
            HelpMessage = "Updated assets for the web service.")]
        public Hashtable Assets { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureMLWebService.UpdateFromArgumentsParameterSet, 
            Mandatory = false, 
            HelpMessage = "Updated input schema for the web service.")]
        public ServiceInputOutputSpecification Input { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureMLWebService.UpdateFromArgumentsParameterSet, 
            Mandatory = false, 
            HelpMessage = "Updated output schema for the web service.")]
        public ServiceInputOutputSpecification Output { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureMLWebService.UpdateFromArgumentsParameterSet, 
            Mandatory = false, 
            HelpMessage = "Updated global parameter values definition for the web service.")]
        public Hashtable Parameters { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureMLWebService.UpdateFromArgumentsParameterSet, 
            Mandatory = false, 
            HelpMessage = "Updated graph package for the web service.")]
        public GraphPackage Package { get; set; }

        [Parameter(
            ParameterSetName = UpdateAzureMLWebService.UpdateFromObjectParameterSet, 
            Mandatory = true, 
            HelpMessage = "An updated definition object to update the referenced web service with.", 
            ValueFromPipeline = true)]
        public WebService ServiceUpdates { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        protected override void RunCmdlet()
        {
            if (ShouldProcess(this.Name, @"Updating machine learning web service.."))
            {
                bool isUpdateToReadonly = this.IsReadOnly.IsPresent;
                if (string.Equals(
                            this.ParameterSetName,
                            UpdateAzureMLWebService.UpdateFromObjectParameterSet,
                            StringComparison.OrdinalIgnoreCase))
                {
                    isUpdateToReadonly = this.ServiceUpdates.Properties != null &&
                                         this.ServiceUpdates.Properties.ReadOnlyProperty.HasValue &&
                                         this.ServiceUpdates.Properties.ReadOnlyProperty.Value;
                }

                var warningMessage = Resources.UpdateServiceWarning.FormatInvariant(this.Name);
                if (isUpdateToReadonly)
                {
                    warningMessage = Resources.UpdateServiceToReadonly.FormatInvariant(this.Name);
                }

                if (this.Force.IsPresent || ShouldContinue(warningMessage, string.Empty))
                {
                    this.UpdateWebServiceResource();
                }
            }
        }

        private void UpdateWebServiceResource()
        {
            WebService serviceDefinitionUpdate = this.ServiceUpdates;
            if (string.Equals(
                this.ParameterSetName, 
                UpdateAzureMLWebService.UpdateFromArgumentsParameterSet, 
                StringComparison.OrdinalIgnoreCase))
            {
                serviceDefinitionUpdate = new WebService
                {
                    Properties = new WebServicePropertiesForGraph
                    {
                        Title = this.Title,
                        Description = this.Description,
                        Diagnostics = this.Diagnostics,
                        Keys = this.Keys,
                        Assets = (this.Assets != null) ? 
                                        this.Assets.Cast<DictionaryEntry>()
                                                .ToDictionary(
                                                    kvp => kvp.Key as string, 
                                                    kvp => kvp.Value as AssetItem)
                                        : null,
                        Input = this.Input,
                        Output = this.Output,
                        ReadOnlyProperty = this.IsReadOnly.IsPresent,
                        RealtimeConfiguration = this.RealtimeConfiguration,
                        Parameters = (this.Parameters != null) ? 
                                        this.Parameters.Cast<DictionaryEntry>()
                                                .ToDictionary(
                                                    kvp => kvp.Key as string,
                                                    kvp => kvp.Value as string)
                                        : null,
                        Package = this.Package
                    }
                };

                if (!string.IsNullOrWhiteSpace(this.StorageAccountKey))
                {
                    serviceDefinitionUpdate.Properties.StorageAccount = 
                        new StorageAccount(null, this.StorageAccountKey);
                }
            }

            WebService updatedService = 
                this.WebServicesClient.UpdateAzureMlWebService(
                                        this.ResourceGroupName, 
                                        this.Name, 
                                        serviceDefinitionUpdate);
            this.WriteObject(updatedService);
        }
    }
}
