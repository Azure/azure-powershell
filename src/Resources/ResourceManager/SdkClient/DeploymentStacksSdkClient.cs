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
using System.Text;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels;
using Newtonsoft.Json.Linq;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Management.Automation;
using System.Linq;
using Microsoft.Rest.Azure;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using ProjectResources = Microsoft.Azure.Commands.ResourceManager.Cmdlets.Properties.Resources;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.Deployments;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Newtonsoft.Json;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStacks;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient
{
    public class DeploymentStacksSdkClient
    {
        public const string ErrorFormat = "Error: Code={0}; Message={1}\r\n";

        public IDeploymentStacksClient DeploymentStacksClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        private IAzureContext azureContext;

        public DeploymentStacksSdkClient(IDeploymentStacksClient deploymentStacksClient)
        {
            this.DeploymentStacksClient = deploymentStacksClient;
        }

        /// <summary>
        /// Field that holds the resource client instance
        /// </summary>
        private NewResourceManagerSdkClient resourceManagerSdkClient;

        /// <summary>
        /// Gets or sets the resource manager sdk client
        /// </summary>
        private NewResourceManagerSdkClient ResourceManagerSdkClient
        {
            get
            {
                if (this.resourceManagerSdkClient == null)
                {
                    this.resourceManagerSdkClient = new NewResourceManagerSdkClient(azureContext);
                }

                this.resourceManagerSdkClient.VerboseLogger = WriteVerbose;
                this.resourceManagerSdkClient.ErrorLogger = WriteError;
                this.resourceManagerSdkClient.WarningLogger = WriteWarning;

                return this.resourceManagerSdkClient;
            }

            set { this.resourceManagerSdkClient = value; }
        }

        private enum DeploymentStackScope
        {
            ResourceGroup = 0,
            Subscription,
            ManagementGroup
        }

        /// <summary>
        /// Parameter-less constructor for mocking
        /// </summary>
        public DeploymentStacksSdkClient()
        {
        }

        public DeploymentStacksSdkClient(IAzureContext context)
            : this(
                AzureSession.Instance.ClientFactory.CreateArmClient<DeploymentStacksClient>(context,
                    AzureEnvironment.Endpoint.ResourceManager))
        {
            this.azureContext = context;
        }

        public PSDeploymentStack GetResourceGroupDeploymentStack(
            string resourceGroupName,
            string deploymentStackName,
            bool throwIfNotExists = true)
        {
            try
            {
                var deploymentStack = DeploymentStacksClient.DeploymentStacks.GetAtResourceGroup(resourceGroupName, deploymentStackName);

                return new PSDeploymentStack(deploymentStack);
            }
            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Deployment Stack does not exist
                        if (!throwIfNotExists)
                            return null;
                        else
                            throw new PSArgumentException(
                            $"DeploymentStack '{deploymentStackName}' in Resource Group '{resourceGroupName}' not found."
                        );
                    }
                    else
                    {
                        throw new PSArgumentException(dex.Body.Error.Message);
                    }
                }

                throw;
            }
        }

        public PSDeploymentStackTemplateDefinition SaveResourceGroupDeploymentStack(
            string resourceGroupName,
           string deploymentStackName,
           bool throwIfNotExists = true)
        {
            try
            {
                var deploymentStack = DeploymentStacksClient.DeploymentStacks.ExportTemplateAtResourceGroup(resourceGroupName, deploymentStackName);

                return new PSDeploymentStackTemplateDefinition(deploymentStack.Template, deploymentStack.TemplateLink);
            }
            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Deployment Stack does not exist
                        if (!throwIfNotExists)
                            return null;
                        else
                            throw new PSArgumentException(
                            $"DeploymentStack '{deploymentStackName}' in Resource Group '{resourceGroupName}' not found."
                        );
                    }
                    else
                    {
                        throw new PSArgumentException(dex.Body.Error.Message);
                    }
                }

                throw;
            }
        }

        public PSDeploymentStackTemplateDefinition SaveSubscriptionDeploymentStack(
            string deploymentStackName,
            bool throwIfNotExists = true)
        {
            try
            {
                var deploymentStack = DeploymentStacksClient.DeploymentStacks.ExportTemplateAtSubscription(deploymentStackName);

                return new PSDeploymentStackTemplateDefinition(deploymentStack.Template, deploymentStack.TemplateLink);
            }
            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Deployment Stack does not exist
                        if (!throwIfNotExists)
                            return null;
                        else
                            throw new PSArgumentException(
                            $"DeploymentStack '{deploymentStackName}' in active subscription not found."
                        );
                    }
                    else
                    {
                        throw new PSArgumentException(dex.Body.Error.Message);
                    }
                }

                throw;
            }
        }

        public PSDeploymentStackTemplateDefinition SaveManagementGroupDeploymentStack(
            string managementGroupId,
            string deploymentStackName,
            bool throwIfNotExists = true)
        {
            try
            {
                var deploymentStack = DeploymentStacksClient.DeploymentStacks.ExportTemplateAtManagementGroup(managementGroupId, deploymentStackName);

                return new PSDeploymentStackTemplateDefinition(deploymentStack.Template, deploymentStack.TemplateLink);
            }
            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Deployment Stack does not exist
                        if (!throwIfNotExists)
                            return null;
                        else
                            throw new PSArgumentException(
                            $"DeploymentStack '{deploymentStackName}' in Management Group '{managementGroupId}' not found."
                        );
                    }
                    else
                    {
                        throw new PSArgumentException(dex.Body.Error.Message);
                    }
                }

                throw;
            }
        }

        public IList<PSDeploymentStack> ListResourceGroupDeploymentStack(string resourceGroupName, bool throwIfNotExists = true)
        {
            try
            {
                var list = new List<PSDeploymentStack>();

                var deploymentStacks = DeploymentStacksClient.DeploymentStacks.ListAtResourceGroup(resourceGroupName);

                list.AddRange(deploymentStacks.Select(stack => PSDeploymentStack.FromAzureSDKDeploymentStack(stack)));

                while (deploymentStacks.NextPageLink != null)
                {
                    deploymentStacks =
                        DeploymentStacksClient.DeploymentStacks.ListAtResourceGroupNext(deploymentStacks.NextPageLink);
                    list.AddRange(deploymentStacks.Select(stack => PSDeploymentStack.FromAzureSDKDeploymentStack(stack)));
                }
                return list;
            }
            catch (Exception ex)
            {
                if (!throwIfNotExists)
                    return null;

                if (ex is DeploymentStacksErrorException dex)
                    throw new PSArgumentException(dex.Body.Error.Message);

                throw ex;
            }
        }

        public PSDeploymentStack GetSubscriptionDeploymentStack(string stackName, bool throwIfNotExists = true)
        {
            try
            {
                var deploymentStack = DeploymentStacksClient.DeploymentStacks.GetAtSubscription(stackName);

                return new PSDeploymentStack(deploymentStack);
            }

            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Deployment Stack does not exist
                        if (!throwIfNotExists)
                            return null;
                        else
                            throw new PSArgumentException(
                            $"DeploymentStack '{stackName}' not found in current subscription scope."
                        );
                    }
                    else
                    {
                        throw new PSArgumentException(dex.Body.Error.Message);
                    }
                }

                throw;
            }
        }

        public IEnumerable<PSDeploymentStack> ListSubscriptionDeploymentStack(bool throwIfNotExists = true)
        {
            try
            {
                var list = new List<PSDeploymentStack>();

                var deploymentStacks = DeploymentStacksClient.DeploymentStacks.ListAtSubscription();

                list.AddRange(deploymentStacks.Select(stack => PSDeploymentStack.FromAzureSDKDeploymentStack(stack)));

                while (deploymentStacks.NextPageLink != null)
                {
                    deploymentStacks =
                        DeploymentStacksClient.DeploymentStacks.ListAtSubscriptionNext(deploymentStacks.NextPageLink);
                    list.AddRange(deploymentStacks.Select(stack => PSDeploymentStack.FromAzureSDKDeploymentStack(stack)));
                }
                return list;
            }
            catch (Exception ex)
            {
                if (!throwIfNotExists)
                    return null;

                if (ex is DeploymentStacksErrorException dex)
                    throw new PSArgumentException(dex.Body.Error.Message);

                throw ex;
            }
        }

        public PSDeploymentStack GetManagementGroupDeploymentStack(string managementGroupId, string deploymentStackName, bool throwIfNotExists = true)
        {
            try
            {
                var deploymentStack = DeploymentStacksClient.DeploymentStacks.GetAtManagementGroup(managementGroupId, deploymentStackName);

                return new PSDeploymentStack(deploymentStack);
            }
            catch (Exception ex)
            {
                if (ex is DeploymentStacksErrorException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        // Deployment Stack does not exist
                        if (!throwIfNotExists)
                            return null;
                        else
                            throw new PSArgumentException(
                            $"DeploymentStack '{deploymentStackName}' in Management Group '{managementGroupId}' not found."
                        );
                    }
                    else
                    {
                        throw new PSArgumentException(dex.Body.Error.Message);
                    }
                }

                throw;
            }
        }

        public IList<PSDeploymentStack> ListManagementGroupDeploymentStack(string managementGroupId, bool throwIfNotExists = true)
        {
            try
            {
                var list = new List<PSDeploymentStack>();

                var deploymentStacks = DeploymentStacksClient.DeploymentStacks.ListAtManagementGroup(managementGroupId);

                list.AddRange(deploymentStacks.Select(stack => PSDeploymentStack.FromAzureSDKDeploymentStack(stack)));

                while (deploymentStacks.NextPageLink != null)
                {
                    deploymentStacks =
                        DeploymentStacksClient.DeploymentStacks.ListAtManagementGroupNext(deploymentStacks.NextPageLink);
                    list.AddRange(deploymentStacks.Select(stack => PSDeploymentStack.FromAzureSDKDeploymentStack(stack)));
                }
                return list;
            }
            catch (Exception ex)
            {
                if (!throwIfNotExists)
                    return null;

                if (ex is DeploymentStacksErrorException dex)
                    throw new PSArgumentException(dex.Body.Error.Message);

                throw ex;
            }
        }

        public PSDeploymentStack ResourceGroupCreateOrUpdateDeploymentStack(
            string deploymentStackName,
            string resourceGroupName,
            string templateFile,
            string templateUri,
            string templateSpec,
            Hashtable templateObject,
            string parameterUri,
            Hashtable parameters,
            string description,
            string resourcesCleanupAction,
            string resourceGroupsCleanupAction,
            string managementGroupsCleanupAction,
            string denySettingsMode,
            string[] denySettingsExcludedPrincipals,
            string[] denySettingsExcludedActions,
            bool denySettingsApplyToChildScopes,
            Hashtable tags,
            bool bypassStackOutOfSyncError
            )
        {
            // Create Deployment stack deployment model:
            var deploymentStackModel = CreateDeploymentStackModel(
                location: null,
                templateFile,
                templateUri,
                templateSpec,
                templateObject,
                parameterUri,
                parameters,
                description,
                resourcesCleanupAction,
                resourceGroupsCleanupAction,
                managementGroupsCleanupAction,
                deploymentScope: null,
                denySettingsMode,
                denySettingsExcludedPrincipals,
                denySettingsExcludedActions,
                denySettingsApplyToChildScopes,
                tags,
                bypassStackOutOfSyncError
                );

            ValidateDeploymentStack(deploymentStackModel, deploymentStackName, DeploymentStackScope.ResourceGroup, resourceGroupName);

            var deploymentStack = DeploymentStacksClient.DeploymentStacks.BeginCreateOrUpdateAtResourceGroup(resourceGroupName, deploymentStackName, deploymentStackModel);
            var getStackFunc = this.GetStackAction(deploymentStackName, DeploymentStackScope.ResourceGroup, rgName: resourceGroupName);

            var finalStack = this.waitStackCompletion(
                getStackFunc,
                "Succeeded",
                "SucceededWithFailures",
                "Failed",
                "Canceled"
                );

            HandleErrors(finalStack);
            return new PSDeploymentStack(finalStack);
        }

        public void ResourceGroupValidateDeploymentStack(
           string deploymentStackName,
           string resourceGroupName,
           string templateFile,
           string templateUri,
           string templateSpec,
           Hashtable templateObject,
           string parameterUri,
           Hashtable parameters,
           string description,
           string resourcesCleanupAction,
           string resourceGroupsCleanupAction,
           string managementGroupsCleanupAction,
           string denySettingsMode,
           string[] denySettingsExcludedPrincipals,
           string[] denySettingsExcludedActions,
           bool denySettingsApplyToChildScopes,
           Hashtable tags,
           bool bypassStackOutOfSyncError
           )
        {
            // Create Deployment stack deployment model:
            var deploymentStackModel = CreateDeploymentStackModel(
                location: null,
                templateFile,
                templateUri,
                templateSpec,
                templateObject,
                parameterUri,
                parameters,
                description,
                resourcesCleanupAction,
                resourceGroupsCleanupAction,
                managementGroupsCleanupAction,
                deploymentScope: null,
                denySettingsMode,
                denySettingsExcludedPrincipals,
                denySettingsExcludedActions,
                denySettingsApplyToChildScopes,
                tags,
                bypassStackOutOfSyncError
                );

            ValidateDeploymentStack(deploymentStackModel, deploymentStackName, DeploymentStackScope.ResourceGroup, resourceGroupName);
        }

        internal void DeleteResourceGroupDeploymentStack(
            string resourceGroupName, 
            string name, 
            string resourcesCleanupAction, 
            string resourceGroupsCleanupAction, 
            string managementGroupsCleanupAction,
            bool bypassStackOutOfSyncError
        )
        {
            var deleteResponse = DeploymentStacksClient.DeploymentStacks
                .DeleteAtResourceGroupWithHttpMessagesAsync(resourceGroupName, name, resourcesCleanupAction, resourceGroupsCleanupAction, managementGroupsCleanupAction, bypassStackOutOfSyncError)
                .GetAwaiter()
                .GetResult();

            if (deleteResponse.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                throw new PSArgumentException(
                        $"DeploymentStack '{name}' in ResourceGroup '{resourceGroupName}' not found."
                    );
            }

            return;
        }

        internal void DeleteSubscriptionDeploymentStack(
            string name, 
            string resourcesCleanupAction, 
            string resourceGroupsCleanupAction, 
            string managementGroupsCleanupAction,
            bool bypassStackOutOfSyncError
        )
        {
            var deleteResponse = DeploymentStacksClient.DeploymentStacks.DeleteAtSubscriptionWithHttpMessagesAsync(name, resourcesCleanupAction, resourceGroupsCleanupAction, managementGroupsCleanupAction, bypassStackOutOfSyncError)
                .GetAwaiter()
                .GetResult();

            if (deleteResponse.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                throw new PSArgumentException(
                        $"DeploymentStack '{name}' not found in the curent subscription scope."
                    );
            }

            return;
        }

        public PSDeploymentStack SubscriptionCreateOrUpdateDeploymentStack(
            string deploymentStackName,
            string location,
            string templateFile,
            string templateUri,
            string templateSpec,
            Hashtable templateObject,
            string parameterUri,
            Hashtable parameters,
            string description,
            string resourcesCleanupAction,
            string resourceGroupsCleanupAction,
            string managementGroupsCleanupAction,
            string deploymentScope,
            string denySettingsMode,
            string[] denySettingsExcludedPrincipals,
            string[] denySettingsExcludedActions,
            bool denySettingsApplyToChildScopes,
            Hashtable tags,
            bool bypassStackOutOfSyncError
        )
        {
            // Create Deployment stack deployment model:
            var deploymentStackModel = CreateDeploymentStackModel(
                location,
                templateFile,
                templateUri,
                templateSpec,
                templateObject,
                parameterUri,
                parameters,
                description,
                resourcesCleanupAction,
                resourceGroupsCleanupAction,
                managementGroupsCleanupAction,
                deploymentScope,
                denySettingsMode,
                denySettingsExcludedPrincipals,
                denySettingsExcludedActions,
                denySettingsApplyToChildScopes,
                tags,
                bypassStackOutOfSyncError
                );

            ValidateDeploymentStack(deploymentStackModel, deploymentStackName, DeploymentStackScope.Subscription);

            var deploymentStack = DeploymentStacksClient.DeploymentStacks.BeginCreateOrUpdateAtSubscription(deploymentStackName, deploymentStackModel);
            var getStackFunc = this.GetStackAction(deploymentStackName, DeploymentStackScope.Subscription);

            var finalStack = this.waitStackCompletion(
                getStackFunc,
                "Succeeded",
                "SucceededWithFailures",
                "Failed",
                "Canceled"
                );

            HandleErrors(finalStack);
            return new PSDeploymentStack(finalStack);
        }

    public void SubscriptionValidateDeploymentStack(
        string deploymentStackName,
        string location,
        string templateFile,
        string templateUri,
        string templateSpec,
        Hashtable templateObject,
        string parameterUri,
        Hashtable parameters,
        string description,
        string resourcesCleanupAction,
        string resourceGroupsCleanupAction,
        string managementGroupsCleanupAction,
        string deploymentScope,
        string denySettingsMode,
        string[] denySettingsExcludedPrincipals,
        string[] denySettingsExcludedActions,
        bool denySettingsApplyToChildScopes,
        Hashtable tags,
        bool bypassStackOutOfSyncError
)
        {
            // Create Deployment stack deployment model:
            var deploymentStackModel = CreateDeploymentStackModel(
                location,
                templateFile,
                templateUri,
                templateSpec,
                templateObject,
                parameterUri,
                parameters,
                description,
                resourcesCleanupAction,
                resourceGroupsCleanupAction,
                managementGroupsCleanupAction,
                deploymentScope,
                denySettingsMode,
                denySettingsExcludedPrincipals,
                denySettingsExcludedActions,
                denySettingsApplyToChildScopes,
                tags,
                bypassStackOutOfSyncError
                );

            ValidateDeploymentStack(deploymentStackModel, deploymentStackName, DeploymentStackScope.Subscription);
        }

        internal void DeleteManagementGroupDeploymentStack(
            string name, 
            string managementGroupId, 
            string resourcesCleanupAction, 
            string resourceGroupsCleanupAction, 
            string managementGroupsCleanupAction,
            bool bypassStackOutOfSyncError
        )
        {
            var deleteResponse = DeploymentStacksClient.DeploymentStacks
                    .DeleteAtManagementGroupWithHttpMessagesAsync(managementGroupId, name, resourcesCleanupAction, resourceGroupsCleanupAction, managementGroupsCleanupAction, bypassStackOutOfSyncError)
                    .GetAwaiter()
                    .GetResult();

            if (deleteResponse.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                throw new PSArgumentException(
                        $"DeploymentStack '{name}' not found in Management Group '{managementGroupId}'."
                    );
            }

            return;
        }

        public PSDeploymentStack ManagementGroupCreateOrUpdateDeploymentStack(
            string deploymentStackName,
            string managementGroupId,
            string location,
            string templateFile,
            string templateUri,
            string templateSpec,
            Hashtable templateObject,
            string parameterUri,
            Hashtable parameters,
            string description,
            string resourcesCleanupAction,
            string resourceGroupsCleanupAction,
            string managementGroupsCleanupAction,
            string deploymentScope,
            string denySettingsMode,
            string[] denySettingsExcludedPrincipals,
            string[] denySettingsExcludedActions,
            bool denySettingsApplyToChildScopes,
            Hashtable tags,
            bool bypassStackOutOfSyncError
        )
        {
            // Create Deployment stack deployment model:
            var deploymentStackModel = CreateDeploymentStackModel(
                location,
                templateFile,
                templateUri,
                templateSpec,
                templateObject,
                parameterUri,
                parameters,
                description,
                resourcesCleanupAction,
                resourceGroupsCleanupAction,
                managementGroupsCleanupAction,
                deploymentScope,
                denySettingsMode,
                denySettingsExcludedPrincipals,
                denySettingsExcludedActions,
                denySettingsApplyToChildScopes,
                tags,
                bypassStackOutOfSyncError
                );

            ValidateDeploymentStack(deploymentStackModel, deploymentStackName, DeploymentStackScope.ManagementGroup, managementGroupId);

            var deploymentStack = DeploymentStacksClient.DeploymentStacks.BeginCreateOrUpdateAtManagementGroup(managementGroupId,
                deploymentStackName, deploymentStackModel);

            // TODO: This should not be a defaulted parameter
            var getStackFunc = this.GetStackAction(deploymentStackName, DeploymentStackScope.ManagementGroup, mgId: managementGroupId);

            var finalStack = this.waitStackCompletion(
                getStackFunc,
                "Succeeded",
                "SucceededWithFailures",
                "Failed",
                "Canceled"
                );

            HandleErrors(finalStack);
            return new PSDeploymentStack(finalStack);
        }

        public void ManagementGroupValidateDeploymentStack(
           string deploymentStackName,
           string managementGroupId,
           string location,
           string templateFile,
           string templateUri,
           string templateSpec,
           Hashtable templateObject,
           string parameterUri,
           Hashtable parameters,
           string description,
           string resourcesCleanupAction,
           string resourceGroupsCleanupAction,
           string managementGroupsCleanupAction,
           string deploymentScope,
           string denySettingsMode,
           string[] denySettingsExcludedPrincipals,
           string[] denySettingsExcludedActions,
           bool denySettingsApplyToChildScopes,
           Hashtable tags,
           bool bypassStackOutOfSyncError
       )
        {
            // Create Deployment stack deployment model:
            var deploymentStackModel = CreateDeploymentStackModel(
                location,
                templateFile,
                templateUri,
                templateSpec,
                templateObject,
                parameterUri,
                parameters,
                description,
                resourcesCleanupAction,
                resourceGroupsCleanupAction,
                managementGroupsCleanupAction,
                deploymentScope,
                denySettingsMode,
                denySettingsExcludedPrincipals,
                denySettingsExcludedActions,
                denySettingsApplyToChildScopes,
                tags,
                bypassStackOutOfSyncError
                );

            ValidateDeploymentStack(deploymentStackModel, deploymentStackName, DeploymentStackScope.ManagementGroup, managementGroupId);
        }

        public DeploymentStack CreateDeploymentStackModel(
           string location,
           string templateFile,
           string templateUri,
           string templateSpec,
           Hashtable templateObject,
           string parameterUri,
           Hashtable parameters,
           string description,
           string resourcesCleanupAction,
           string resourceGroupsCleanupAction,
           string managementGroupsCleanupAction,
           string deploymentScope,
           string denySettingsMode,
           string[] denySettingsExcludedPrincipals,
           string[] denySettingsExcludedActions,
           bool denySettingsApplyToChildScopes,
           Hashtable tags,
           bool bypassStackOutOfSyncError
       )
        {
            var actionOnUnmanage = new ActionOnUnmanage
            {
                Resources = resourcesCleanupAction,
                ResourceGroups = resourceGroupsCleanupAction,
                ManagementGroups = managementGroupsCleanupAction
            };
            var denySettings = new DenySettings
            {
                Mode = denySettingsMode,
                ExcludedPrincipals = denySettingsExcludedPrincipals,
                ExcludedActions = denySettingsExcludedActions,
                ApplyToChildScopes = denySettingsApplyToChildScopes
            };

            var deploymentStackModel = new DeploymentStack
            {
                Description = description,
                Location = location,
                ActionOnUnmanage = actionOnUnmanage,
                DeploymentScope = deploymentScope,
                DenySettings = denySettings,
                Tags = TagsHelper.ConvertToTagsDictionary(tags),
                BypassStackOutOfSyncError = bypassStackOutOfSyncError
            };

            // Evaulate Template:
            if (templateSpec != null)
            {
                deploymentStackModel.TemplateLink = new DeploymentStacksTemplateLink
                {
                    Id = templateSpec,
                };
            }
            else if (Uri.IsWellFormedUriString(templateUri, UriKind.Absolute))
            {
                deploymentStackModel.TemplateLink = new DeploymentStacksTemplateLink
                {
                    Uri = templateUri,
                };
            }
            else if (!string.IsNullOrEmpty(templateFile))
            {
                // NOTE(jcotillo): JsonExtensions.FromJson<> extension uses a custom serialization settings
                // that preserves DateTime values as string (DateParseHandling = DateParseHandling.None),
                // plus other custom settings (see: JsonExtensions.JsonObjectTypeSerializer)
                deploymentStackModel.Template =
                    FileUtilities.DataStore.ReadFileAsStream(templateFile).FromJson<JObject>();
            }
            else
            {
                deploymentStackModel.Template = templateObject.ToJToken();
            }

            // Evaluate Template Parameters:
            if (Uri.IsWellFormedUriString(parameterUri, UriKind.Absolute))
            {
                DeploymentStacksParametersLink parametersLink = new DeploymentStacksParametersLink();
                parametersLink.Uri = parameterUri;
                deploymentStackModel.ParametersLink = parametersLink;
            }
            else if (parameters != null)
            {
                deploymentStackModel.Parameters = ConvertParameterHashtableToDictionary(parameters);
            }

            return deploymentStackModel;
        }

        private void HandleErrors(DeploymentStack deploymentStack)
        {
            if (deploymentStack.Error != null)
            {
                var error = deploymentStack.Error;
                var sb = new StringBuilder();
                List<string> errorMessages = ExtractErrorMessages(error);
                sb.AppendFormat(ProjectResources.DeploymentStackOperationOuterError, deploymentStack.Name, errorMessages.Count, errorMessages.Count);
                sb.AppendLine();

                foreach (string message in errorMessages)
                {
                    sb.AppendLine(message);
                }

                WriteError(sb.ToString());
            }
        }

        private IDictionary<string, DeploymentParameter> ConvertParameterHashtableToDictionary(Hashtable parameters)
        {
            var paramDictionary = new Dictionary<string, DeploymentParameter>();

            foreach (string key in parameters.Keys)
            {
                paramDictionary[key] = new DeploymentParameter();
                var paramTable = (Hashtable)parameters[key];

                if (paramTable["reference"] != null)
                {
                    paramDictionary[key].Reference = JsonConvert.DeserializeObject<KeyVaultParameterReference>(paramTable["reference"].ToString());
                }
                else
                {
                    paramDictionary[key].Value = paramTable["value"];
                }
            }

            return paramDictionary;
        }

        private DeploymentStack waitStackCompletion(Func<Task<AzureOperationResponse<DeploymentStack>>> getStack, params string[] status)
        {
            //Poll stack deployment based on RetryAfter. If no RetyrAfter is present, polling status in two phases.
            //Phase one: poll every 5 seconds for 400 seconds. If not completed in this duration, move to phase two
            //Phase two: poll every 60 seconds
            DeploymentStack stack;

            const int counterUnit = 1000;
            int step = 5;
            int phaseOne = 400;
            bool deploymentOperationFlag = true;
            do
            {
                WriteVerbose(string.Format("Checking stack deployment status", step));
                TestMockSupport.Delay(step * counterUnit);

                if (phaseOne > 0)
                    phaseOne -= step;

                var getStackTask = getStack();

                using (var getResult = getStackTask.ConfigureAwait(false).GetAwaiter().GetResult())
                {
                    stack = getResult.Body;
                    var response = getResult.Response;

                    if (response != null && response.Headers.RetryAfter != null && response.Headers.RetryAfter.Delta.HasValue)
                    {
                        step = response.Headers.RetryAfter.Delta.Value.Seconds;
                    }
                    else
                    {
                        step = phaseOne > 0 ? 5 : 60;
                    }
                }

                if (!string.IsNullOrEmpty(stack.DeploymentId) && deploymentOperationFlag)
                {
                    deploymentOperationFlag = false;
                    PollDeployments(stack);
                }

            } while (!status.Any(s => s.Equals(stack.ProvisioningState, StringComparison.OrdinalIgnoreCase)));

            return stack;
        }

        Func<Task<AzureOperationResponse<DeploymentStack>>> GetStackAction(string stackName, DeploymentStackScope scope, string rgName = null, string mgId = null)
        {
            switch (scope)
            {
                case DeploymentStackScope.Subscription:
                    return () => DeploymentStacksClient.DeploymentStacks.GetAtSubscriptionWithHttpMessagesAsync(stackName);

                case DeploymentStackScope.ManagementGroup:
                    return () => DeploymentStacksClient.DeploymentStacks.GetAtManagementGroupWithHttpMessagesAsync(mgId, stackName);

                case DeploymentStackScope.ResourceGroup:
                    return () => DeploymentStacksClient.DeploymentStacks.GetAtResourceGroupWithHttpMessagesAsync(rgName, stackName);

                default:
                    throw new NotImplementedException("Scope not supported.");
            }
        }

        private DeploymentStack PollDeployments(DeploymentStack stack)
        {
            string deploymentId = stack.DeploymentId;
            PSDeploymentCmdletParameters parameters = new PSDeploymentCmdletParameters();
            parameters.DeploymentName = ResourceIdUtility.GetDeploymentName(deploymentId);
            parameters.ResourceGroupName = ResourceIdUtility.GetResourceGroupName(deploymentId);
            parameters.ManagementGroupId = ResourceIdUtility.GetManagementGroupId(deploymentId);
            if (parameters.ResourceGroupName != null)
                parameters.ScopeType = DeploymentScopeType.ResourceGroup;
            else if (parameters.ManagementGroupId != null)
                parameters.ScopeType = DeploymentScopeType.ManagementGroup;
            else
                parameters.ScopeType = DeploymentScopeType.Subscription;
            WriteVerbose("Starting DeploymentOperations polling");
            try
            {
                ResourceManagerSdkClient.ProvisionDeploymentStatus(parameters, new Deployment());
            }
            catch (Exception)
            {
                WriteVerbose("DeploymentOperations polling failed");
            }
            return stack;
        }

        private void WriteVerbose(string progress)
        {
            if (VerboseLogger != null)
            {
                VerboseLogger(progress);
            }
        }

        private void WriteWarning(string warning)
        {
            if (WarningLogger != null)
            {
                WarningLogger(warning);
            }
        }

        private void WriteError(string error)
        {
            if (ErrorLogger != null)
            {
                ErrorLogger(error);
            }
        }

        private List<string> ExtractErrorMessages(ErrorDetail error)
        {
            List<string> errorMessages = new List<string>();

            Stack<ErrorDetail> stack = new Stack<ErrorDetail>();
            stack.Push(error);

            while (stack.Count > 0)
            {
                var currentError = stack.Pop();
                errorMessages.Add(string.Format(ErrorFormat, currentError.Code, currentError.Message));
                if (currentError.Details != null)
                {
                    foreach (ErrorDetail detail in currentError.Details)
                    {
                        stack.Push(detail);
                    }
                }
            }
            return errorMessages;
        }

        private PSDeploymentStackValidationInfo ValidateDeploymentStack(DeploymentStack deploymentStack, string deploymentStackName, DeploymentStackScope scope, string scopeName = "")
        {
            var validationResult = RunDeploymentStackValidation(deploymentStack, deploymentStackName, scope, scopeName);   

            if (validationResult.Error != null)
            {
                var sb = new StringBuilder();
                List<string> errorMessages = ExtractErrorMessages(validationResult.Error);

                foreach (string message in errorMessages)
                {
                    sb.AppendLine(message);
                }

                WriteError(sb.ToString());
                
                throw new InvalidOperationException($"Validation for deployment stack '{deploymentStackName}' failed.");
            }
            else
            {
                WriteVerbose(ProjectResources.TemplateValid);
                
                return validationResult;
            }
        }

        private PSDeploymentStackValidationInfo RunDeploymentStackValidation(DeploymentStack deploymentStack, string deploymentStackName, DeploymentStackScope scope, string scopeName)
        {
            try
            {
                var validationResult = this.RunDeploymentStackValidationAtScope(deploymentStack, deploymentStackName, scope, scopeName);

                return new PSDeploymentStackValidationInfo(validationResult);
            }
            catch (Exception ex)
            {
                return new PSDeploymentStackValidationInfo(new DeploymentStackValidateResult(error: ConvertValidationExceptionToError(ex)));
            }
        }

        private DeploymentStackValidateResult RunDeploymentStackValidationAtScope(DeploymentStack deploymentStack, string deploymentStackName, DeploymentStackScope scope, string scopeName)
        {
            switch (scope)
            {
                case DeploymentStackScope.ResourceGroup:
                    return DeploymentStacksClient.DeploymentStacks.ValidateStackAtResourceGroup(scopeName, deploymentStackName, deploymentStack);

                case DeploymentStackScope.Subscription:
                    return DeploymentStacksClient.DeploymentStacks.ValidateStackAtSubscription(deploymentStackName, deploymentStack);

                case DeploymentStackScope.ManagementGroup:
                    return DeploymentStacksClient.DeploymentStacks.ValidateStackAtManagementGroup(scopeName, deploymentStackName, deploymentStack);

                default:
                    throw new NotImplementedException("Scope not supported.");

            }
        }

        private ErrorDetail ConvertValidationExceptionToError(Exception ex)
        {
            if (ex == null)
            {
                return null;
            }

            if (ex is DeploymentStacksErrorException)
            {
                var stackEx = ex as DeploymentStacksErrorException;
                return new ErrorDetail(stackEx.Body?.Error.Code, stackEx.Body?.Error.Message, stackEx.Body?.Error.Target, stackEx.Body?.Error.Details);
            }
            else if (ex is CloudException)
            {
                var cloudEx = ex as CloudException;
                return new ErrorDetail(cloudEx.Body?.Code, cloudEx.Body?.Message, cloudEx.Body?.Target, ConvertCloudErrorListToErrorDetailList(cloudEx.Body?.Details));
            }
            else
            {
                var innerExceptionAsError = ConvertValidationExceptionToError(ex.InnerException);
                return new ErrorDetail(null, ex.Message, null, innerExceptionAsError != null ? new ErrorDetail[] { innerExceptionAsError } : null);
            }
        }

        private IList<ErrorDetail> ConvertCloudErrorListToErrorDetailList(IList<CloudError> errors)
        {
            List<ErrorDetail> convertedErrors = new List<ErrorDetail>();

            foreach (CloudError error in errors)
            {
                convertedErrors.Add(new ErrorDetail(error.Code, error.Message, error.Target, error.Details != null ? ConvertCloudErrorListToErrorDetailList(error.Details) : null));
            }

            return convertedErrors;
        }
    }
}