// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Components;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Json;
using Microsoft.WindowsAzure.Commands.Common;
using System.Linq;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStackWhatIf;
using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Extensions;
using Microsoft.Azure.Management.Resources.DeploymentStacks;
using Microsoft.Azure.Management.Resources.DeploymentStacks.Models;
using AzSdkModels = Microsoft.Azure.Management.Resources.DeploymentStacks.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkClient
{
    /// <summary>
    /// SDK client for Deployment Stack What-If operations. Kept separate from DeploymentStacksSdkClient
    /// because WhatIf is a distinct resource type.
    /// </summary>
    public class DeploymentStacksWhatIfSdkClient
    {
        public IDeploymentStacksClient DeploymentStacksClient { get; set; }
        public Action<string> VerboseLogger { get; set; }
        public Action<string> ErrorLogger { get; set; }
        public Action<string> WarningLogger { get; set; }
        public Action<int> DelayAction { get; set; } = milliseconds => System.Threading.Thread.Sleep(milliseconds);
        private IAzureContext azureContext;

        public DeploymentStacksWhatIfSdkClient(IDeploymentStacksClient deploymentStacksClient)
        {
            this.DeploymentStacksClient = deploymentStacksClient;
        }

        public DeploymentStacksWhatIfSdkClient(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<DeploymentStacksClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
            this.azureContext = context;
        }

        private void WriteVerbose(string msg) => VerboseLogger?.Invoke(msg);
        private void WriteError(string msg) => ErrorLogger?.Invoke(msg);
        private void WriteWarning(string msg) => WarningLogger?.Invoke(msg);

        private static bool IsWhatIfApiUnavailable(ErrorResponseException exception)
        {
            var statusCode = exception?.Response?.StatusCode;
            string errorCode = exception?.Body?.Error?.Code;
            string errorMessage = exception?.Body?.Error?.Message;

            if (statusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                return string.Equals(errorCode, "DeploymentStackWhatIfOperationFailed", StringComparison.OrdinalIgnoreCase);
            }

            if (statusCode == System.Net.HttpStatusCode.NotFound)
            {
                return string.Equals(errorCode, "ResourceNotFound", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(errorCode, "DeploymentStackWhatIfResourceNotFound", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(errorCode, "NoRegisteredProviderFound", StringComparison.OrdinalIgnoreCase) ||
                       string.Equals(errorCode, "InvalidResourceType", StringComparison.OrdinalIgnoreCase);
            }

            return statusCode == System.Net.HttpStatusCode.BadRequest &&
                   errorMessage?.IndexOf("what-if result", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private PSDeploymentStackWhatIfResult CreateUnavailableWhatIfResult(
            string deploymentStackName,
            DeploymentStacksWhatIfResult request,
            string stackResourceId,
            string retentionInterval,
            string deploymentScope,
            bool bypassStackOutOfSyncError,
            ErrorResponseException serviceError)
        {
            string resolvedStackResourceId = request?.Properties?.DeploymentStackResourceId ?? stackResourceId;
            string resolvedRetentionInterval = !string.IsNullOrEmpty(retentionInterval)
                ? retentionInterval
                : System.Xml.XmlConvert.ToString(request?.Properties?.RetentionInterval ?? TimeSpan.FromHours(2));
            string errorCode = serviceError?.Body?.Error?.Code ?? "WhatIfApiUnavailable";
            string errorMessage = serviceError?.Body?.Error?.Message ?? serviceError?.Message;
            var serviceErrorInfo = new JObject
            {
                ["httpStatusCode"] = serviceError?.Response != null ? (int)serviceError.Response.StatusCode : (int?)null,
                ["httpStatus"] = serviceError?.Response?.StatusCode.ToString(),
                ["details"] = serviceError?.Body?.Error?.Details != null
                    ? JToken.FromObject(serviceError.Body.Error.Details)
                    : new JArray()
            };

            return new PSDeploymentStackWhatIfResult
            {
                Name = deploymentStackName,
                Type = "Microsoft.Resources/deploymentStacksWhatIfResults",
                Properties = new PSDeploymentStackWhatIfProperties
                {
                    DeploymentStackResourceId = resolvedStackResourceId,
                    RetentionInterval = resolvedRetentionInterval,
                    ProvisioningState = "What-If API not available",
                    DeploymentScope = request?.Properties?.DeploymentScope ?? deploymentScope,
                    BypassStackOutOfSyncError = bypassStackOutOfSyncError,
                    Diagnostics = new List<PSDeploymentStackWhatIfDiagnostic>
                    {
                        new PSDeploymentStackWhatIfDiagnostic
                        {
                            Level = "Warning",
                            Code = errorCode,
                            Message = errorMessage,
                            Target = serviceError?.Body?.Error?.Target ?? resolvedStackResourceId,
                            AdditionalInfo = new JArray
                            {
                                new JObject
                                {
                                    ["type"] = "ServiceError",
                                    ["info"] = serviceErrorInfo
                                }
                            }
                        }
                    }
                }
            };
        }

        public DeploymentStacksWhatIfResult WaitWhatIfResultCompletion(
            DeploymentStacksWhatIfResult initialResult,
            Func<DeploymentStacksWhatIfResult> getResult,
            params string[] terminalStates)
        {
            DeploymentStacksWhatIfResult finalResult = initialResult;
            const int maxPollingAttempts = 60;
            const int pollingIntervalInMilliseconds = 5000;
            int attempts = 0;

            while (finalResult.Properties?.ProvisioningState == "Running" && attempts < maxPollingAttempts)
            {
                WriteVerbose($"Polling What-If result... attempt {attempts + 1}");
                DelayAction(pollingIntervalInMilliseconds);
                finalResult = getResult();
                attempts++;
            }

            return finalResult;
        }

        private IDictionary<string, DeploymentParameter> ConvertParameterHashtableToDictionary(Hashtable parameters)
        {
            Dictionary<string, object> parametersDictionary = parameters?.ToDictionary(false);
            string parametersContent = parametersDictionary != null
                ? PSJsonSerializer.Serialize(parametersDictionary)
                : null;

            return !string.IsNullOrEmpty(parametersContent)
                ? parametersContent.FromJson<Dictionary<string, DeploymentParameter>>()
                : null;
        }


        /// <summary>
        /// Converts Azure SDK What-If result to PowerShell model
        /// </summary>
        private PSDeploymentStackWhatIfResult ConvertToPSDeploymentStackWhatIfResult(object sdkWhatIfResult)
        {
            // Serialize SDK result to JSON and deserialize to PS model
            // This provides a flexible conversion that handles the complex nested structure
            var json = JsonConvert.SerializeObject(sdkWhatIfResult);
            var psResult = JsonConvert.DeserializeObject<PSDeploymentStackWhatIfResult>(json);

            if (sdkWhatIfResult is DeploymentStacksWhatIfResult sdkResult && psResult?.Properties != null)
            {
                psResult.Properties.RetentionInterval = System.Xml.XmlConvert.ToString(sdkResult.Properties.RetentionInterval);
            }

            return psResult;
        }

        /// <summary>
        /// Creates a DeploymentStacksWhatIfResult request object for the What-If operation
        /// </summary>
        private DeploymentStacksWhatIfResult CreateDeploymentStacksWhatIfResult(
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
            string deploymentStackName,
            string resourceGroupName,
            string managementGroupId,
            string stackResourceId = null,
            string retentionInterval = null,
            string validationLevel = null,
            string debugSettingDetailLevel = null,
            bool bypassStackOutOfSyncError = false)
        {
            // Convert PS models to SDK models
            var actionOnUnmanage = new AzSdkModels.ActionOnUnmanage(
                resources: resourcesCleanupAction,
                resourceGroups: resourceGroupsCleanupAction,
                managementGroups: managementGroupsCleanupAction);

            var denySettings = new AzSdkModels.DenySettings(
                mode: denySettingsMode,
                excludedPrincipals: denySettingsExcludedPrincipals?.ToList(),
                excludedActions: denySettingsExcludedActions?.ToList(),
                applyToChildScopes: denySettingsApplyToChildScopes);

            // Use user-provided stackResourceId if available, else construct from name + scope
            string resolvedStackResourceId = stackResourceId;
            if (string.IsNullOrEmpty(resolvedStackResourceId))
            {
                if (!string.IsNullOrEmpty(resourceGroupName))
                {
                    if (string.IsNullOrEmpty(azureContext?.Subscription?.Id))
                    {
                        throw new PSArgumentException("A subscription context is required to construct the deployment stack resource ID.");
                    }

                    resolvedStackResourceId = $"/subscriptions/{azureContext.Subscription.Id}/resourceGroups/{resourceGroupName}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}";
                }
                else if (!string.IsNullOrEmpty(managementGroupId))
                {
                    resolvedStackResourceId = $"/providers/Microsoft.Management/managementGroups/{managementGroupId}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}";
                }
                else
                {
                    if (string.IsNullOrEmpty(azureContext?.Subscription?.Id))
                    {
                        throw new PSArgumentException("A subscription context is required to construct the deployment stack resource ID.");
                    }

                    resolvedStackResourceId = $"/subscriptions/{azureContext.Subscription.Id}/providers/Microsoft.Resources/deploymentStacks/{deploymentStackName}";
                }
            }

            var properties = new DeploymentStacksWhatIfResultProperties(
                actionOnUnmanage: actionOnUnmanage,
                denySettings: denySettings,
                deploymentStackResourceId: resolvedStackResourceId,
                retentionInterval: !string.IsNullOrEmpty(retentionInterval) ? System.Xml.XmlConvert.ToTimeSpan(retentionInterval) : TimeSpan.FromHours(2))
            {
                Description = description,
                DeploymentScope = deploymentScope,
                ValidationLevel = validationLevel,
                DebugSetting = !string.IsNullOrEmpty(debugSettingDetailLevel)
                    ? new AzSdkModels.DeploymentStacksDebugSetting(debugSettingDetailLevel)
                    : null
            };

            // Evaluate Template
            if (templateSpec != null)
            {
                properties.TemplateLink = new DeploymentStacksTemplateLink
                {
                    Id = templateSpec,
                };
            }
            else if (Uri.IsWellFormedUriString(templateUri, UriKind.Absolute))
            {
                properties.TemplateLink = new DeploymentStacksTemplateLink
                {
                    Uri = templateUri,
                };
            }
            else if (!string.IsNullOrEmpty(templateFile))
            {
                var templateJObject = FileUtilities.DataStore.ReadFileAsStream(templateFile).FromJson<JObject>();
                properties.Template = templateJObject.ToObject<Dictionary<string, object>>();
            }
            else
            {
                var templateJToken = templateObject.ToJToken();
                properties.Template = templateJToken.ToObject<Dictionary<string, object>>();
            }

            // Evaluate Template Parameters
            if (Uri.IsWellFormedUriString(parameterUri, UriKind.Absolute))
            {
                properties.ParametersLink = new DeploymentStacksParametersLink
                {
                    Uri = parameterUri
                };
            }
            else if (parameters != null)
            {
                properties.Parameters = ConvertParameterHashtableToDictionary(parameters);
            }

            var whatIfResult = new DeploymentStacksWhatIfResult
            {
                Location = location,
                Properties = properties
            };

            return whatIfResult;
        }

        #region What-If Resource CRUD Operations

        public PSDeploymentStackWhatIfResult GetResourceGroupDeploymentStackWhatIfResult(string resourceGroupName, string whatIfResultName, bool throwIfNotExists = true)
        {
            try
            {
                var result = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtResourceGroup.Get(resourceGroupName, whatIfResultName);
                return ConvertToPSDeploymentStackWhatIfResult(result);
            }
            catch (Exception ex)
            {
                if (ex is ErrorResponseException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        if (!throwIfNotExists)
                            return null;
                        throw new PSArgumentException($"WhatIf result '{whatIfResultName}' in Resource Group '{resourceGroupName}' not found.");
                    }
                    throw new PSArgumentException(dex.Body?.Error?.Message ?? dex.Message);
                }
                throw;
            }
        }

        public PSDeploymentStackWhatIfResult GetResourceGroupDeploymentStackWhatIfResultWithPropertyChanges(string resourceGroupName, string whatIfResultName, bool throwIfNotExists = true)
        {
            try
            {
                var result = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtResourceGroup.WhatIf(resourceGroupName, whatIfResultName);
                return ConvertToPSDeploymentStackWhatIfResult(result);
            }
            catch (Exception ex)
            {
                if (ex is ErrorResponseException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        if (!throwIfNotExists)
                            return null;
                        throw new PSArgumentException($"WhatIf result '{whatIfResultName}' in Resource Group '{resourceGroupName}' not found.");
                    }
                    throw new PSArgumentException(dex.Body?.Error?.Message ?? dex.Message);
                }
                throw;
            }
        }

        public IList<PSDeploymentStackWhatIfResult> ListResourceGroupDeploymentStackWhatIfResults(string resourceGroupName)
        {
            try
            {
                var list = new List<PSDeploymentStackWhatIfResult>();
                var results = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtResourceGroup.List(resourceGroupName);
                list.AddRange(results.Select(r => ConvertToPSDeploymentStackWhatIfResult(r)));
                while (results.NextPageLink != null)
                {
                    results = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtResourceGroup.ListNext(results.NextPageLink);
                    list.AddRange(results.Select(r => ConvertToPSDeploymentStackWhatIfResult(r)));
                }
                return list;
            }
            catch (Exception ex)
            {
                if (ex is ErrorResponseException dex)
                    throw new PSArgumentException(dex.Body?.Error?.Message ?? dex.Message);
                throw;
            }
        }

        public void DeleteResourceGroupDeploymentStackWhatIfResult(string resourceGroupName, string whatIfResultName)
        {
            try
            {
                DeploymentStacksClient.DeploymentStacksWhatIfResultsAtResourceGroup.Delete(resourceGroupName, whatIfResultName);
            }
            catch (Exception ex)
            {
                if (ex is ErrorResponseException dex)
                    throw new PSArgumentException(dex.Body?.Error?.Message ?? dex.Message);
                throw;
            }
        }

        public PSDeploymentStackWhatIfResult GetSubscriptionDeploymentStackWhatIfResult(string whatIfResultName, bool throwIfNotExists = true)
        {
            try
            {
                var result = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtSubscription.Get(whatIfResultName);
                return ConvertToPSDeploymentStackWhatIfResult(result);
            }
            catch (Exception ex)
            {
                if (ex is ErrorResponseException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        if (!throwIfNotExists)
                            return null;
                        throw new PSArgumentException($"WhatIf result '{whatIfResultName}' not found in the current subscription.");
                    }
                    throw new PSArgumentException(dex.Body?.Error?.Message ?? dex.Message);
                }
                throw;
            }
        }

        public PSDeploymentStackWhatIfResult GetSubscriptionDeploymentStackWhatIfResultWithPropertyChanges(string whatIfResultName, bool throwIfNotExists = true)
        {
            try
            {
                var result = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtSubscription.WhatIf(whatIfResultName);
                return ConvertToPSDeploymentStackWhatIfResult(result);
            }
            catch (Exception ex)
            {
                if (ex is ErrorResponseException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        if (!throwIfNotExists)
                            return null;
                        throw new PSArgumentException($"WhatIf result '{whatIfResultName}' not found in the current subscription.");
                    }
                    throw new PSArgumentException(dex.Body?.Error?.Message ?? dex.Message);
                }
                throw;
            }
        }

        public IList<PSDeploymentStackWhatIfResult> ListSubscriptionDeploymentStackWhatIfResults()
        {
            try
            {
                var list = new List<PSDeploymentStackWhatIfResult>();
                var results = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtSubscription.List();
                list.AddRange(results.Select(r => ConvertToPSDeploymentStackWhatIfResult(r)));
                while (results.NextPageLink != null)
                {
                    results = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtSubscription.ListNext(results.NextPageLink);
                    list.AddRange(results.Select(r => ConvertToPSDeploymentStackWhatIfResult(r)));
                }
                return list;
            }
            catch (Exception ex)
            {
                if (ex is ErrorResponseException dex)
                    throw new PSArgumentException(dex.Body?.Error?.Message ?? dex.Message);
                throw;
            }
        }

        public void DeleteSubscriptionDeploymentStackWhatIfResult(string whatIfResultName)
        {
            try
            {
                DeploymentStacksClient.DeploymentStacksWhatIfResultsAtSubscription.Delete(whatIfResultName);
            }
            catch (Exception ex)
            {
                if (ex is ErrorResponseException dex)
                    throw new PSArgumentException(dex.Body?.Error?.Message ?? dex.Message);
                throw;
            }
        }

        public PSDeploymentStackWhatIfResult GetManagementGroupDeploymentStackWhatIfResult(string managementGroupId, string whatIfResultName, bool throwIfNotExists = true)
        {
            try
            {
                var result = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtManagementGroup.Get(managementGroupId, whatIfResultName);
                return ConvertToPSDeploymentStackWhatIfResult(result);
            }
            catch (Exception ex)
            {
                if (ex is ErrorResponseException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        if (!throwIfNotExists)
                            return null;
                        throw new PSArgumentException($"WhatIf result '{whatIfResultName}' in Management Group '{managementGroupId}' not found.");
                    }
                    throw new PSArgumentException(dex.Body?.Error?.Message ?? dex.Message);
                }
                throw;
            }
        }

        public PSDeploymentStackWhatIfResult GetManagementGroupDeploymentStackWhatIfResultWithPropertyChanges(string managementGroupId, string whatIfResultName, bool throwIfNotExists = true)
        {
            try
            {
                var result = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtManagementGroup.WhatIf(managementGroupId, whatIfResultName);
                return ConvertToPSDeploymentStackWhatIfResult(result);
            }
            catch (Exception ex)
            {
                if (ex is ErrorResponseException dex)
                {
                    if (dex.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        if (!throwIfNotExists)
                            return null;
                        throw new PSArgumentException($"WhatIf result '{whatIfResultName}' in Management Group '{managementGroupId}' not found.");
                    }
                    throw new PSArgumentException(dex.Body?.Error?.Message ?? dex.Message);
                }
                throw;
            }
        }

        public IList<PSDeploymentStackWhatIfResult> ListManagementGroupDeploymentStackWhatIfResults(string managementGroupId)
        {
            try
            {
                var list = new List<PSDeploymentStackWhatIfResult>();
                var results = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtManagementGroup.List(managementGroupId);
                list.AddRange(results.Select(r => ConvertToPSDeploymentStackWhatIfResult(r)));
                while (results.NextPageLink != null)
                {
                    results = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtManagementGroup.ListNext(results.NextPageLink);
                    list.AddRange(results.Select(r => ConvertToPSDeploymentStackWhatIfResult(r)));
                }
                return list;
            }
            catch (Exception ex)
            {
                if (ex is ErrorResponseException dex)
                    throw new PSArgumentException(dex.Body?.Error?.Message ?? dex.Message);
                throw;
            }
        }

        public void DeleteManagementGroupDeploymentStackWhatIfResult(string managementGroupId, string whatIfResultName)
        {
            try
            {
                DeploymentStacksClient.DeploymentStacksWhatIfResultsAtManagementGroup.Delete(managementGroupId, whatIfResultName);
            }
            catch (Exception ex)
            {
                if (ex is ErrorResponseException dex)
                    throw new PSArgumentException(dex.Body?.Error?.Message ?? dex.Message);
                throw;
            }
        }

        #endregion

        #region What-If Operations

        /// <summary>
        /// Executes a what-if operation for a deployment stack.
        /// Main entry point that determines scope and routes to appropriate method.
        /// NOTE: What-If for Deployment Stacks is not yet supported by the Azure REST API.
        /// </summary>
        public PSDeploymentStackWhatIfResult ExecuteDeploymentStackWhatIf(PSDeploymentStackWhatIfParameters parameters)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            // Determine scope and call appropriate method
            if (!string.IsNullOrEmpty(parameters.ResourceGroupName))
            {
                return ExecuteResourceGroupDeploymentStackWhatIf(
                    parameters.StackName,
                    parameters.ResourceGroupName,
                    parameters.TemplateFile,
                    parameters.TemplateUri,
                    parameters.TemplateSpecId,
                    parameters.TemplateObject,
                    parameters.TemplateParameterUri,
                    parameters.TemplateParameterObject,
                    parameters.Description,
                    parameters.ResourcesCleanupAction,
                    parameters.ResourceGroupsCleanupAction,
                    parameters.ManagementGroupsCleanupAction,
                    parameters.DenySettingsMode,
                    parameters.DenySettingsExcludedPrincipals,
                    parameters.DenySettingsExcludedActions,
                    parameters.DenySettingsApplyToChildScopes,
                    parameters.BypassStackOutOfSyncError,
                    parameters.StackResourceId,
                    parameters.RetentionInterval,
                    parameters.ValidationLevel,
                    parameters.DebugSettingDetailLevel);
            }
            else if (!string.IsNullOrEmpty(parameters.ManagementGroupId))
            {
                return ExecuteManagementGroupDeploymentStackWhatIf(
                    parameters.StackName,
                    parameters.ManagementGroupId,
                    parameters.Location,
                    parameters.TemplateFile,
                    parameters.TemplateUri,
                    parameters.TemplateSpecId,
                    parameters.TemplateObject,
                    parameters.TemplateParameterUri,
                    parameters.TemplateParameterObject,
                    parameters.Description,
                    parameters.ResourcesCleanupAction,
                    parameters.ResourceGroupsCleanupAction,
                    parameters.ManagementGroupsCleanupAction,
                    parameters.DeploymentScope,
                    parameters.DenySettingsMode,
                    parameters.DenySettingsExcludedPrincipals,
                    parameters.DenySettingsExcludedActions,
                    parameters.DenySettingsApplyToChildScopes,
                    parameters.BypassStackOutOfSyncError,
                    parameters.StackResourceId,
                    parameters.RetentionInterval,
                    parameters.ValidationLevel,
                    parameters.DebugSettingDetailLevel);
            }
            else
            {
                return ExecuteSubscriptionDeploymentStackWhatIf(
                    parameters.StackName,
                    parameters.Location,
                    parameters.TemplateFile,
                    parameters.TemplateUri,
                    parameters.TemplateSpecId,
                    parameters.TemplateObject,
                    parameters.TemplateParameterUri,
                    parameters.TemplateParameterObject,
                    parameters.Description,
                    parameters.ResourcesCleanupAction,
                    parameters.ResourceGroupsCleanupAction,
                    parameters.ManagementGroupsCleanupAction,
                    parameters.DeploymentScope,
                    parameters.DenySettingsMode,
                    parameters.DenySettingsExcludedPrincipals,
                    parameters.DenySettingsExcludedActions,
                    parameters.DenySettingsApplyToChildScopes,
                    parameters.BypassStackOutOfSyncError,
                    parameters.StackResourceId,
                    parameters.RetentionInterval,
                    parameters.ValidationLevel,
                    parameters.DebugSettingDetailLevel);
            }
        }

        /// <summary>
        /// Executes a what-if operation for a deployment stack at resource group scope.
        /// This uses the two-step process: CreateOrUpdate the WhatIf result, then call WhatIf to get changes.
        /// </summary>
        public PSDeploymentStackWhatIfResult ExecuteResourceGroupDeploymentStackWhatIf(
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
            bool bypassStackOutOfSyncError,
            string stackResourceId = null,
            string retentionInterval = null,
            string validationLevel = null,
            string debugSettingDetailLevel = null)
        {
            DeploymentStacksWhatIfResult whatIfRequest = null;

            try
            {
                WriteVerbose($"Executing What-If for deployment stack '{deploymentStackName}' in resource group '{resourceGroupName}'");

                // Step 1: Create what-if result object to submit
                whatIfRequest = CreateDeploymentStacksWhatIfResult(
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
                    deploymentStackName,
                    resourceGroupName,
                    null,
                    stackResourceId,
                    retentionInterval,
                    validationLevel,
                    debugSettingDetailLevel,
                    bypassStackOutOfSyncError
                );

                // Step 2: Submit the WhatIf request (CreateOrUpdate creates/updates a WhatIf result resource)
                WriteVerbose("Creating What-If result resource...");
                var createResult = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtResourceGroup.CreateOrUpdate(
                    resourceGroupName,
                    deploymentStackName,
                    whatIfRequest);

                // The createResult should already contain the changes - check if we need to poll or if it's complete
                WriteVerbose($"Initial What-If result state: {createResult.Properties?.ProvisioningState}");
                
                // Poll for completion if the result is being computed asynchronously
                DeploymentStacksWhatIfResult finalResult = createResult;
                const int maxPollingAttempts = 60; // 5 minutes max
                int pollingInterval = 5; // seconds
                int attempts = 0;
                
                while (finalResult.Properties?.ProvisioningState == "Running" && attempts < maxPollingAttempts)
                {
                    WriteVerbose($"Polling What-If result... attempt {attempts + 1}");
                    System.Threading.Thread.Sleep(pollingInterval * 1000);
                    finalResult = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtResourceGroup.Get(
                        resourceGroupName,
                        deploymentStackName);
                    attempts++;
                }

                WriteVerbose($"Final What-If result state: {finalResult.Properties?.ProvisioningState}");

                // Call WhatIf POST to get result with property changes (delta) populated
                WriteVerbose("Fetching What-If result with property changes...");
                try
                {
                    var resultWithChanges = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtResourceGroup.WhatIf(
                        resourceGroupName,
                        deploymentStackName);
                    return ConvertToPSDeploymentStackWhatIfResult(resultWithChanges);
                }
                catch (Exception postEx)
                {
                    WriteVerbose($"WhatIf POST not available, returning GET result: {postEx.Message}");
                    return ConvertToPSDeploymentStackWhatIfResult(finalResult);
                }
            }
            catch (ErrorResponseException ex) when (IsWhatIfApiUnavailable(ex))
            {
                // What-If API not available - provide informational message
                WriteWarning("Deployment Stacks What-If API is not yet available in this region or subscription.");
                WriteWarning("The deployment stack would be created/updated with the following configuration:");
                WriteWarning($"  Name: {deploymentStackName}");
                WriteWarning($"  Resource Group: {resourceGroupName}");
                WriteWarning($"  Action on unmanaged resources: {resourcesCleanupAction}");
                WriteWarning($"  Action on unmanaged resource groups: {resourceGroupsCleanupAction}");
                WriteWarning($"  Deny Settings Mode: {denySettingsMode}");
                WriteWarning($"  Service Error: {ex.Body?.Error?.Code ?? ex.Response?.StatusCode.ToString()} - {ex.Body?.Error?.Message ?? ex.Message}");

                return CreateUnavailableWhatIfResult(
                    deploymentStackName,
                    whatIfRequest,
                    stackResourceId,
                    retentionInterval,
                    deploymentScope: null,
                    bypassStackOutOfSyncError,
                    ex);
            }
            catch (ErrorResponseException ex)
            {
                WriteError($"Error executing What-If (HTTP {ex.Response?.StatusCode}): {ex.Body?.Error?.Message ?? ex.Message}");
                if (ex.Body?.Error?.Details != null && ex.Body.Error.Details.Any())
                {
                    foreach (var detail in ex.Body.Error.Details)
                    {
                        WriteError($"  - {detail.Code}: {detail.Message}");
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                WriteError($"Error executing What-If: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Executes a what-if operation for a deployment stack at subscription scope.
        /// </summary>
        public PSDeploymentStackWhatIfResult ExecuteSubscriptionDeploymentStackWhatIf(
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
            bool bypassStackOutOfSyncError,
            string stackResourceId = null,
            string retentionInterval = null,
            string validationLevel = null,
            string debugSettingDetailLevel = null)
        {
            DeploymentStacksWhatIfResult whatIfRequest = null;

            try
            {
                WriteVerbose($"Executing What-If for deployment stack '{deploymentStackName}' at subscription scope");

                // Create what-if result object to submit
                whatIfRequest = CreateDeploymentStacksWhatIfResult(
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
                    deploymentStackName,
                    null,
                    null,
                    stackResourceId,
                    retentionInterval,
                    validationLevel,
                    debugSettingDetailLevel,
                    bypassStackOutOfSyncError
                );

                // Execute What-If operation using Track 1 SDK
                WriteVerbose("Creating What-If result resource...");
                var createResult = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtSubscription.CreateOrUpdate(
                    deploymentStackName,
                    whatIfRequest);

                // Poll for completion if needed
                WriteVerbose($"Initial What-If result state: {createResult.Properties?.ProvisioningState}");
                
                DeploymentStacksWhatIfResult finalResult = createResult;
                const int maxPollingAttempts = 60;
                int pollingInterval = 5;
                int attempts = 0;
                
                while (finalResult.Properties?.ProvisioningState == "Running" && attempts < maxPollingAttempts)
                {
                    WriteVerbose($"Polling What-If result... attempt {attempts + 1}");
                    System.Threading.Thread.Sleep(pollingInterval * 1000);
                    finalResult = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtSubscription.Get(deploymentStackName);
                    attempts++;
                }

                WriteVerbose($"Final What-If result state: {finalResult.Properties?.ProvisioningState}");

                // Call WhatIf POST to get result with property changes (delta) populated
                WriteVerbose("Fetching What-If result with property changes...");
                try
                {
                    var resultWithChanges = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtSubscription.WhatIf(deploymentStackName);
                    return ConvertToPSDeploymentStackWhatIfResult(resultWithChanges);
                }
                catch (Exception postEx)
                {
                    WriteVerbose($"WhatIf POST not available, returning GET result: {postEx.Message}");
                    return ConvertToPSDeploymentStackWhatIfResult(finalResult);
                }
            }
            catch (ErrorResponseException ex) when (IsWhatIfApiUnavailable(ex))
            {
                // What-If API not available - provide informational message
                WriteWarning("Deployment Stacks What-If API is not yet available in this region or subscription.");
                WriteWarning("The deployment stack would be created/updated with the following configuration:");
                WriteWarning($"  Name: {deploymentStackName}");
                WriteWarning($"  Location: {location}");
                WriteWarning($"  Action on unmanaged resources: {resourcesCleanupAction}");
                WriteWarning($"  Action on unmanaged resource groups: {resourceGroupsCleanupAction}");
                WriteWarning($"  Deny Settings Mode: {denySettingsMode}");
                WriteWarning($"  Service Error: {ex.Body?.Error?.Code ?? ex.Response?.StatusCode.ToString()} - {ex.Body?.Error?.Message ?? ex.Message}");

                return CreateUnavailableWhatIfResult(
                    deploymentStackName,
                    whatIfRequest,
                    stackResourceId,
                    retentionInterval,
                    deploymentScope,
                    bypassStackOutOfSyncError,
                    ex);
            }
            catch (ErrorResponseException ex)
            {
                WriteError($"Error executing What-If (HTTP {ex.Response?.StatusCode}): {ex.Body?.Error?.Message ?? ex.Message}");
                if (ex.Body?.Error?.Details != null && ex.Body.Error.Details.Any())
                {
                    foreach (var detail in ex.Body.Error.Details)
                    {
                        WriteError($"  - {detail.Code}: {detail.Message}");
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                WriteError($"Error executing What-If: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Executes a what-if operation for a deployment stack at management group scope.
        /// </summary>
        public PSDeploymentStackWhatIfResult ExecuteManagementGroupDeploymentStackWhatIf(
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
            bool bypassStackOutOfSyncError,
            string stackResourceId = null,
            string retentionInterval = null,
            string validationLevel = null,
            string debugSettingDetailLevel = null)
        {
            DeploymentStacksWhatIfResult whatIfRequest = null;

            try
            {
                WriteVerbose($"Executing What-If for deployment stack '{deploymentStackName}' in management group '{managementGroupId}'");

                // Create what-if result object to submit
                whatIfRequest = CreateDeploymentStacksWhatIfResult(
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
                    deploymentStackName,
                    null,
                    managementGroupId,
                    stackResourceId,
                    retentionInterval,
                    validationLevel,
                    debugSettingDetailLevel,
                    bypassStackOutOfSyncError
                );

                // Execute What-If operation using Track 1 SDK
                WriteVerbose("Creating What-If result resource...");
                var createResult = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtManagementGroup.CreateOrUpdate(
                    managementGroupId,
                    deploymentStackName,
                    whatIfRequest);

                // Poll for completion if needed
                WriteVerbose($"Initial What-If result state: {createResult.Properties?.ProvisioningState}");
                
                DeploymentStacksWhatIfResult finalResult = createResult;
                const int maxPollingAttempts = 60;
                int pollingInterval = 5;
                int attempts = 0;
                
                while (finalResult.Properties?.ProvisioningState == "Running" && attempts < maxPollingAttempts)
                {
                    WriteVerbose($"Polling What-If result... attempt {attempts + 1}");
                    System.Threading.Thread.Sleep(pollingInterval * 1000);
                    finalResult = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtManagementGroup.Get(
                        managementGroupId,
                        deploymentStackName);
                    attempts++;
                }

                WriteVerbose($"Final What-If result state: {finalResult.Properties?.ProvisioningState}");

                // Call WhatIf POST to get result with property changes (delta) populated
                WriteVerbose("Fetching What-If result with property changes...");
                try
                {
                    var resultWithChanges = DeploymentStacksClient.DeploymentStacksWhatIfResultsAtManagementGroup.WhatIf(
                        managementGroupId,
                        deploymentStackName);
                    return ConvertToPSDeploymentStackWhatIfResult(resultWithChanges);
                }
                catch (Exception postEx)
                {
                    WriteVerbose($"WhatIf POST not available, returning GET result: {postEx.Message}");
                    return ConvertToPSDeploymentStackWhatIfResult(finalResult);
                }
            }
            catch (ErrorResponseException ex) when (IsWhatIfApiUnavailable(ex))
            {
                // What-If API not available - provide informational message
                WriteWarning("Deployment Stacks What-If API is not yet available in this region or subscription.");
                WriteWarning("The deployment stack would be created/updated with the following configuration:");
                WriteWarning($"  Name: {deploymentStackName}");
                WriteWarning($"  Management Group: {managementGroupId}");
                WriteWarning($"  Location: {location}");
                WriteWarning($"  Action on unmanaged resources: {resourcesCleanupAction}");
                WriteWarning($"  Action on unmanaged resource groups: {resourceGroupsCleanupAction}");
                WriteWarning($"  Deny Settings Mode: {denySettingsMode}");
                WriteWarning($"  Service Error: {ex.Body?.Error?.Code ?? ex.Response?.StatusCode.ToString()} - {ex.Body?.Error?.Message ?? ex.Message}");

                return CreateUnavailableWhatIfResult(
                    deploymentStackName,
                    whatIfRequest,
                    stackResourceId,
                    retentionInterval,
                    deploymentScope,
                    bypassStackOutOfSyncError,
                    ex);
            }
            catch (ErrorResponseException ex)
            {
                WriteError($"Error executing What-If (HTTP {ex.Response?.StatusCode}): {ex.Body?.Error?.Message ?? ex.Message}");
                if (ex.Body?.Error?.Details != null && ex.Body.Error.Details.Any())
                {
                    foreach (var detail in ex.Body.Error.Details)
                    {
                        WriteError($"  - {detail.Code}: {detail.Message}");
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                WriteError($"Error executing What-If: {ex.Message}");
                throw;
            }
        }

        #endregion
    }
}
