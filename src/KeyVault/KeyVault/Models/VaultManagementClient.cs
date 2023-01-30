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
using System.Linq;
using System.Net;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.KeyVault;
using PSKeyVaultProperties = Microsoft.Azure.Commands.KeyVault.Properties;
using PSKeyVaultPropertiesResources = Microsoft.Azure.Commands.KeyVault.Properties.Resources;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Rest.Azure;
using System.ComponentModel;
using Microsoft.Azure.Commands.Common.MSGraph.Version1_0;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Sku = Microsoft.Azure.Management.KeyVault.Models.Sku;
using Newtonsoft.Json.Converters;
using System.Globalization;
using Microsoft.Azure.Commands.KeyVault.Commands;
using Microsoft.WindowsAzure.Commands.Common;
using System.Threading.Tasks;
// using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01.Models;
// using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01;
// using Microsoft.Azure.Management.ResourceManager;
// using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers;
using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources;
using Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.Collections;
using Microsoft.Azure.Commands.Common.Exceptions;
using System.Reflection;
using ProvisioningState = Microsoft.Azure.PowerShell.Cmdlets.KeyVault.Helpers.Resources.Models.ProvisioningState;
using System.Text;
using Microsoft.Azure.Commands.KeyVault.Extensions;
using Microsoft.Azure.Commands.KeyVault.Progress;
using System.Security.Cryptography;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Strategies;
using System.Threading;
using Microsoft.Azure.Commands.KeyVault.Utilities;

namespace Microsoft.Azure.Commands.KeyVault.Models
{
    public enum ResourceTypeName
    {
        Vault = 0,
        Hsm = 1
    }
    public enum PublicNetworkAccess
    {
        Enabled = 0,
        Disabled = 1
    }

    public enum NetworkRuleAction
    {
        Allow,
        Deny
    }

    public class VaultManagementClient
    {
        public readonly string VaultsResourceType = "Microsoft.KeyVault/vaults";
        public readonly string ManagedHsmResourceType = "Microsoft.KeyVault/managedHSMs";
        public Action<string> ErrorLogger { get; set; }
        public Action<string> WarningLogger { get; set; }
        public Action<string> VerboseLogger { get; set; }
        public const string ErrorFormat = "Error: Code={0}; Message={1}\r\n";
        /// <summary>
        /// Used when provisioning the deployment status.
        /// </summary>
        private List<DeploymentOperation> operations;
        public VaultManagementClient(IAzureContext context)
        {
            KeyVaultManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<KeyVaultManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
        }
        public VaultManagementClient(IAzureContext context, bool isARM)
        {
            KeyVaultManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<KeyVaultManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            if (isARM)
            {
                ResourceManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager);
            }
        }
        /// <summary>
        /// Parameterless constructor for mocking
        /// </summary>
        public VaultManagementClient()
        { }

        private IKeyVaultManagementClient KeyVaultManagementClient
        {
            get;
            set;
        }

        private IResourceManagementClient ResourceManagementClient
        {
            get;
            set;
        }

        #region Constants

        private const string DefaultTemplatePath = "Microsoft.Azure.Commands.KeyVault.Resources.keyvaultTemplate.json";

        #endregion

        #region Vault-related METHODS
        /// <summary>
        /// Create a new vault
        /// </summary>
        /// <param name="parameters">vault creation parameters</param>
        /// <param name="graphClient">the active directory client</param>
        /// <param name="networkRuleSet">the network rule set of the vault</param>
        /// <param name="cmdlet"></param>
        /// <returns></returns>
        public PSKeyVault CreateNewVault(VaultCreationOrUpdateParameters parameters, IMicrosoftGraphClient graphClient = null, PSKeyVaultNetworkRuleSet networkRuleSet = null, KeyVaultManagementCmdletBase cmdlet = null)
        {
            if (parameters == null)
                throw new ArgumentNullException("parameters");
            if (string.IsNullOrWhiteSpace(parameters.Name))
                throw new ArgumentNullException("parameters.Name");
            if (string.IsNullOrWhiteSpace(parameters.ResourceGroupName))
                throw new ArgumentNullException("parameters.ResourceGroupName");
            if (string.IsNullOrWhiteSpace(parameters.Location))
                throw new ArgumentNullException("parameters.Location");

            parameters.Name = GenerateDeploymentName(parameters);
            Deployment deployment = CreateBasicDeployment(parameters, parameters.DeploymentMode, parameters.DeploymentDebugLogLevel, networkRuleSet);
            parameters.Location = null;
            var existed = ResourceManagementClient.Deployments.CheckExistence(parameters.ResourceGroupName, parameters.Name);

            //WriteInfo("Validating KeyVault creation...", cmdlet);
            this.RunDeploymentValidation(parameters, deployment, cmdlet);
            this.BeginDeployment(parameters, deployment, cmdlet);
            var dep = ProvisionDeploymentStatus(parameters, deployment, cmdlet, existed).ToPSDeployment(resourceGroupName: parameters.ResourceGroupName);
            
            return GetVault(parameters.Name, parameters.ResourceGroupName);
        }
        private void WriteInfo(string s, Cmdlet cmdlet)
        {
            string statusMessage = s;
            var clearMessage = new string(' ', statusMessage.Length);
            var information = new HostInformationMessage { Message = statusMessage, NoNewLine = true };
            var clearInformation = new HostInformationMessage { Message = $"\r{clearMessage}\r", NoNewLine = true };
            var tags = new[] { "PSHOST" };
            cmdlet.WriteInformation(information, tags);
        }
        private void WriteDeploymentProgress(VaultCreationOrUpdateParameters parameters, DeploymentOperationErrorInfo deploymentOperationError)
        {
            var result = ListDeploymentOperations(parameters.ResourceGroupName, parameters.Name);
            var newOperations = GetNewOperations(operations, result);
            operations.AddRange(newOperations);

            foreach (DeploymentOperation operation in newOperations)
            {
                if (operation.Properties.ProvisioningState == ProvisioningState.Failed.ToString())
                {
                    deploymentOperationError.ProcessError(operation);
                }
            }
        }
        public DeploymentExtended ProvisionDeploymentStatus(VaultCreationOrUpdateParameters parameters, Deployment deployment, KeyVaultManagementCmdletBase cmdlet = null, bool existed = false)
        {
            operations = new List<DeploymentOperation>();
            ProvisioningState[] status = new ProvisioningState[] { ProvisioningState.Canceled, ProvisioningState.Succeeded, ProvisioningState.Failed };
            var getDeploymentFunc = this.GetDeploymentAction(parameters);
            var deploymentOperationError = new DeploymentOperationErrorInfo();
            Action writeProgressAction = () => this.WriteDeploymentProgress(parameters, deploymentOperationError);

            int progressBarTimeSpan = 220;
            if (existed) { progressBarTimeSpan = 20; }
            int step = 5;
            int phaseOne = 400;
            var downloadStatus = new ProgressStatus(0, progressBarTimeSpan);
            Program.SyncOutput = new PSSyncOutputEvents(cmdlet);

            DeploymentExtended deploymentExtended = null;

            ProgressTracker progressTracker = new ProgressTracker(downloadStatus, Program.SyncOutput.ProgressOperationStatus, Program.SyncOutput.ProgressOperationComplete);
            do
            {
                if (writeProgressAction != null)
                {
                    writeProgressAction();
                }
                var getDeploymentTask = getDeploymentFunc();
                var getResult = getDeploymentTask.ConfigureAwait(false).GetAwaiter().GetResult();
                
                var actionName = "Creation in progress...";
                deploymentExtended = getResult.Body;
                var response = getResult.Response;
                if (response != null && response.Headers.RetryAfter != null && response.Headers.RetryAfter.Delta.HasValue)
                {
                    step = response.Headers.RetryAfter.Delta.Value.Seconds;
                }
                else
                {
                    step = phaseOne > 0 ? 5 : 60;
                }
                progressTracker.Update(actionName);
            } while (!status.Any(s => s.ToString().Equals(deploymentExtended.Properties.ProvisioningState, StringComparison.OrdinalIgnoreCase))); 

            if (deploymentOperationError.ErrorMessages.Count > 0)
            {
                WriteError(GetDeploymentErrorMessagesWithOperationId(deploymentOperationError,
                    parameters.Name,
                    deploymentExtended?.Properties?.CorrelationId));
                throw new InvalidOperationException(deploymentOperationError.ErrorMessages.FirstOrDefault().Message);
            }

            return deploymentExtended;
        }

        Func<Task<AzureOperationResponse<DeploymentExtended>>> GetDeploymentAction(VaultCreationOrUpdateParameters parameters)
        {
            return () => ResourceManagementClient.Deployments.GetWithHttpMessagesAsync(parameters.ResourceGroupName, parameters.Name);
        }

        public string GetDeploymentErrorMessagesWithOperationId(DeploymentOperationErrorInfo errorInfo, string deploymentName = null, string correlationId = null)
        {
            if (errorInfo.ErrorMessages.Count == 0)
                return String.Empty;

            var sb = new StringBuilder();

            int maxErrors = errorInfo.ErrorMessages.Count > DeploymentOperationErrorInfo.MaxErrorsToShow
               ? DeploymentOperationErrorInfo.MaxErrorsToShow
               : errorInfo.ErrorMessages.Count;

            // Add outer message showing the total number of errors.
            sb.AppendFormat("DeploymentOperationOuterError", deploymentName, maxErrors, errorInfo.ErrorMessages.Count);

            // Add each error message
            errorInfo.ErrorMessages
                .Take(maxErrors).ToList()
                .ForEach(m => sb
                    .AppendLine()
                    .AppendFormat("DeploymentOperationOuterError", m
                            .ToFormattedString())
                    .AppendLine());

            // Add correlationId
            sb.AppendLine().AppendFormat("DeploymentCorrelationId", correlationId);

            return sb.ToString();
        }

        private List<DeploymentOperation> GetNewOperations(List<DeploymentOperation> old, IPage<DeploymentOperation> current)
        {
            List<DeploymentOperation> newOperations = new List<DeploymentOperation>();
            foreach (DeploymentOperation operation in current)
            {
                DeploymentOperation operationWithSameIdAndProvisioningState = old.Find(o => o.OperationId.Equals(operation.OperationId) && o.Properties.ProvisioningState.Equals(operation.Properties.ProvisioningState));
                if (operationWithSameIdAndProvisioningState == null)
                {
                    newOperations.Add(operation);
                }

                //If nested deployment, get the operations under those deployments as well
                if (operation.Properties.TargetResource?.ResourceType?.Equals(Constants.MicrosoftResourcesDeploymentType, StringComparison.OrdinalIgnoreCase) == true)
                {
                    HttpStatusCode statusCode;
                    Enum.TryParse<HttpStatusCode>(operation.Properties.StatusCode, out statusCode);
                    if (!statusCode.IsClientFailureRequest())
                    {
                        var nestedDeploymentOperations = this.GetNestedDeploymentOperations(operation.Properties.TargetResource.Id);

                        foreach (DeploymentOperation op in nestedDeploymentOperations)
                        {
                            DeploymentOperation nestedOperationWithSameIdAndProvisioningState = newOperations.Find(o => o.OperationId.Equals(op.OperationId) && o.Properties.ProvisioningState.Equals(op.Properties.ProvisioningState));

                            if (nestedOperationWithSameIdAndProvisioningState == null)
                            {
                                newOperations.Add(op);
                            }
                        }
                    }
                }
            }

            return newOperations;
        }
        private IPage<DeploymentOperation> ListDeploymentOperations(string resourceGroupName, string deploymentName)
        {
            return ResourceManagementClient.DeploymentOperations.List(resourceGroupName, deploymentName, null);
        }
        private List<DeploymentOperation> GetNestedDeploymentOperations(string deploymentId)
        {
            var resourceGroupName = ResourceIdUtility.GetResourceGroupName(deploymentId);
            var deploymentName = ResourceIdUtility.GetDeploymentName(deploymentId);
            
            if (ResourceManagementClient.Deployments.CheckExistence(resourceGroupName, deploymentName) == true)
            {
                var result = this.ListDeploymentOperations(resourceGroupName, deploymentName);

                return GetNewOperations(operations, result);
            }

            return new List<DeploymentOperation>();
        }

        private void WriteVerbose(string progress)
        {
            if (VerboseLogger != null)
            {
                VerboseLogger(progress);
            }
        }

        private string GenerateDeploymentName(VaultCreationOrUpdateParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.Name))
            {
                return parameters.Name;
            }
            else
            {
                return Guid.NewGuid().ToString();
            }
        }
        private void BeginDeployment(VaultCreationOrUpdateParameters parameters, Deployment deployment, KeyVaultManagementCmdletBase cmdlet = null)
        {
            bool threadCompleted = false;
            var progressBarTimeSpan = 65;
            Program.SyncOutput = new PSSyncOutputEvents(cmdlet);
            var creationStatus = new ProgressStatus(0, progressBarTimeSpan);
            var actionName = "Starting creating KeyVault...";
            Action onComplete = () =>
            {
                threadCompleted = true;
            };
            var creationThread = new Thread(
                () =>
                {
                    try
                    {
                        ResourceManagementClient.Deployments.BeginCreateOrUpdate(parameters.ResourceGroupName, parameters.Name, deployment);
                    }
                    finally
                    {
                        onComplete();
                    }
                });
            creationThread.Start();
            // validationResult = this.GetTemplateValidationResult(parameters, deployment);
            ProgressTracker progressTracker = new ProgressTracker(creationStatus, Program.SyncOutput.ProgressOperationStatus, Program.SyncOutput.ProgressOperationComplete);
            while (!threadCompleted)
            {
                progressTracker.Update(actionName);
                Thread.Sleep(500);
            }

            
        }

        
        
        private void RunDeploymentValidation(VaultCreationOrUpdateParameters parameters, Deployment deployment, KeyVaultManagementCmdletBase cmdlet = null)
        {
            TemplateValidationInfo validationResult = null;
            var progressBarTimeSpan = 50;
            var downloadStatus = new ProgressStatus(0, progressBarTimeSpan);
            var actionName = "Validating KeyVault";
            Program.SyncOutput = new PSSyncOutputEvents(cmdlet);
            bool threadCompleted = false;

            Action onComplete = () =>
            {
                threadCompleted = true;
            };
            var validationThread = new Thread(
                () =>
                {
                    try
                    {
                        validationResult = this.GetTemplateValidationResult(parameters, deployment);
                    }
                    finally
                    {
                        onComplete();
                    }
                });
            validationThread.Start();
            ProgressTracker progressTracker = new ProgressTracker(downloadStatus, Program.SyncOutput.ProgressOperationStatus, Program.SyncOutput.ProgressOperationComplete);
            while (!threadCompleted)
            {
                progressTracker.Update(actionName);
                Thread.Sleep(500);
            }

            
            
            if (validationResult.Errors.Count != 0)
            {
                foreach (var error in validationResult.Errors)
                {
                    WriteError(string.Format(ErrorFormat, error.Code, error.Message));
                    if (error.Details != null && error.Details.Count > 0)
                    {
                        foreach (var innerError in error.Details)
                        {
                            DisplayInnerDetailErrorMessage(innerError);
                        }
                    }
                }
                throw new InvalidOperationException(validationResult.Errors.FirstOrDefault().Message);
            }
            else
            {
                WriteVerbose("TemplateValid");
            }
        }
        private TemplateValidationInfo GetTemplateValidationResult(VaultCreationOrUpdateParameters parameters, Deployment deployment)
        {
            try
            {
                // WriteVerbose("Start validating");
                var validationResult = this.ValidateDeployment(parameters, deployment);
                // WriteVerbose("Got result.");
                return new TemplateValidationInfo(validationResult);
            }
            catch (Exception ex)
            {
                var error = HandleError(ex).FirstOrDefault();
                return new TemplateValidationInfo(new DeploymentValidateResult(error));
            }
        }

        private List<ErrorResponse> HandleError(Exception ex)
        {
            if (ex == null)
            {
                return null;
            }

            ErrorResponse error = null;
            var innerException = HandleError(ex.InnerException);
            if (ex is CloudException)
            {
                var cloudEx = ex as CloudException;
                error = new ErrorResponse(cloudEx.Body?.Code, cloudEx.Body?.Message, cloudEx.Body?.Target, innerException);
            }
            else
            {
                error = new ErrorResponse(null, ex.Message, null, innerException);
            }

            return new List<ErrorResponse> { error };

        }

        private DeploymentValidateResult ValidateDeployment(VaultCreationOrUpdateParameters parameters, Deployment deployment)
        {
            return ResourceManagementClient.Deployments.BeginValidate(parameters.ResourceGroupName, parameters.Name, deployment);
        }
        private void WriteError(string error)
        {
            if (ErrorLogger != null)
            {
                ErrorLogger(error);
            }
        }
        private void DisplayInnerDetailErrorMessage(ErrorResponse error)
        {
            WriteError(string.Format(ErrorFormat, error.Code, error.Message));
            if (error.Details != null)
            {
                foreach (var innerError in error.Details)
                {
                    DisplayInnerDetailErrorMessage(innerError);
                }
            }
        }
        private Deployment CreateBasicDeployment(VaultCreationOrUpdateParameters parameters, DeploymentMode deploymentMode, string debugSetting, PSKeyVaultNetworkRuleSet networkRuleSet)
        {
            Deployment deployment = new Deployment
            {
                Properties = new DeploymentProperties
                {
                    Mode = deploymentMode
                }
            };

            if (!string.IsNullOrEmpty(debugSetting))
            {
                deployment.Properties.DebugSetting = new DebugSetting
                {
                    DetailLevel = debugSetting
                };
            }

            string templateContent = null;
            try
            {
                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(DefaultTemplatePath))
                using (var reader = new StreamReader(stream))
                {
                    templateContent = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new AzPSArgumentException(string.Format(PSKeyVaultPropertiesResources.FileNotFound, ex.Message), "TemplateFile");
            };
            var jsonInfo = JObject.Parse(templateContent);

            jsonInfo["resources"][0]["name"] = parameters.Name;
            jsonInfo["resources"][0]["location"] = parameters.Location;
            if (string.IsNullOrWhiteSpace(parameters.SkuFamilyName))
                throw new ArgumentNullException("parameters.SkuFamilyName");
            if (parameters.TenantId == Guid.Empty)
                throw new ArgumentException("parameters.TenantId");
            if (!string.IsNullOrWhiteSpace(parameters.SkuName))
            {
                if (Enum.TryParse(parameters.SkuName, true, out SkuName _))
                {
                    jsonInfo["resources"][0]["properties"]["sku"]["skuName"] = parameters.SkuName;
                }
                else
                {
                    throw new InvalidEnumArgumentException("parameters.SkuName");
                }
            }
            if( parameters.EnabledForDeployment is true)
                jsonInfo["resources"][0]["properties"]["enabledForDeployment"] = parameters.EnabledForDeployment;
            if (parameters.EnabledForTemplateDeployment is true)
                jsonInfo["resources"][0]["properties"]["enabledForTemplateDeployment"] = parameters.EnabledForTemplateDeployment;
            if (parameters.EnabledForDiskEncryption is true)
                jsonInfo["resources"][0]["properties"]["enabledForDiskEncryption"] = parameters.EnabledForDiskEncryption;
            if (parameters.EnableRbacAuthorization is true)
                jsonInfo["resources"][0]["properties"]["enableRbacAuthorization"] = parameters.EnableRbacAuthorization;
            jsonInfo["resources"][0]["properties"]["softDeleteRetentionInDays"] = parameters.SoftDeleteRetentionInDays;
            if (parameters.EnabledForDeployment is true)
                jsonInfo["resources"][0]["properties"]["enabledForDeployment"] = parameters.EnabledForDeployment;
            jsonInfo["resources"][0]["properties"]["publicNetworkAccess"] = parameters.PublicNetworkAccess;
            if (networkRuleSet != null)
            {
                jsonInfo["resources"][0]["properties"]["networkAcls"]["bypass"] = networkRuleSet.Bypass.ToString();
                jsonInfo["resources"][0]["properties"]["networkAcls"]["defaultAction"] = networkRuleSet.DefaultAction.ToString();
                if (networkRuleSet.IpAddressRanges != null && networkRuleSet.IpAddressRanges.Count > 0)
                {
                    var ipAddresses = JToken.FromObject(networkRuleSet.IpAddressRanges);
                    jsonInfo["parameters"]["ipRules"]["defaultValue"] = ipAddresses;
                }
                if (networkRuleSet.VirtualNetworkResourceIds != null && networkRuleSet.VirtualNetworkResourceIds.Count > 0)
                {
                    var virtualNetworkIds = JToken.FromObject(networkRuleSet.VirtualNetworkResourceIds);
                    jsonInfo["parameters"]["virtualNetworkRules"]["defaultValue"] = virtualNetworkIds;
                }
            }

            deployment.Properties.Template = jsonInfo;
            
            if (Uri.IsWellFormedUriString(parameters.ParameterUri, UriKind.Absolute))
            {
                deployment.Properties.ParametersLink = new ParametersLink
                {
                    Uri = parameters.ParameterUri
                };
            }
            else
            {
                // ToDictionary is needed for extracting value from a secure string. Do not remove it.
                Dictionary<string, object> parametersDictionary = parameters.TemplateParameterObject?.ToDictionary(false);
                string parametersContent = parametersDictionary != null
                    ? PSJsonSerializer.Serialize(parametersDictionary)
                    : null;
                // NOTE(jcotillo): Adding FromJson<> to parameters as well 
                deployment.Properties.Parameters = !string.IsNullOrEmpty(parametersContent)
                    ? parametersContent.FromJson<JObject>()
                    : null;
            }

            deployment.Tags = parameters?.Tags == null ? null : new Dictionary<string, string>((IDictionary<string, string>)parameters.Tags);
            deployment.Properties.OnErrorDeployment = parameters.OnErrorDeployment;

            return deployment;
        }

        /// <summary>
        /// Executes deployment What-If at the specified scope.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="kvParameters"></param>
        /// <param name="networkRuleSet"></param>
        /// <returns></returns>
        public virtual PSWhatIfOperationResult ExecuteDeploymentWhatIf(PSDeploymentWhatIfCmdletParameters parameters, VaultCreationOrUpdateParameters kvParameters, PSKeyVaultNetworkRuleSet networkRuleSet = null)
        {
            IDeploymentsOperations deployments = this.ResourceManagementClient.Deployments;
            DeploymentWhatIf deploymentWhatIf = parameters.ToDeploymentWhatIf(parameters, kvParameters, networkRuleSet);
            ScopedDeploymentWhatIf scopedDeploymentWhatIf = new ScopedDeploymentWhatIf(deploymentWhatIf.Location, deploymentWhatIf.Properties);

            try
            {
                WhatIfOperationResult whatIfOperationResult = null;
                whatIfOperationResult = deployments.WhatIf(parameters.ResourceGroupName, parameters.DeploymentName, deploymentWhatIf.Properties);

               if (parameters.ExcludeChangeTypes != null)
                {
                    whatIfOperationResult.Changes = whatIfOperationResult.Changes
                        .Where(change => parameters.ExcludeChangeTypes.All(changeType => changeType != change.ChangeType))
                        .ToList();
                }

                return new PSWhatIfOperationResult(whatIfOperationResult);
            }
            catch (CloudException ce)
            {
                string errorMessage = $"{Environment.NewLine}{BuildCloudErrorMessage(ce.Body)}";
                throw new CloudException(errorMessage);
            }
        }

        private static string BuildCloudErrorMessage(CloudError cloudError)
        {
            if (cloudError == null)
            {
                return string.Empty;
            }

            IList<string> messages = new List<string>
            {
                $"{cloudError.Code} - {cloudError.Message}"
            };

            foreach (CloudError innerError in cloudError.Details)
            {
                messages.Add(BuildCloudErrorMessage(innerError));
            }

            return string.Join(Environment.NewLine, messages);
        }


        /// <summary>
        /// Get an existing vault. Returns null if vault is not found.
        /// </summary>
        /// <param name="vaultName">vault name</param>
        /// <param name="resourceGroupName">resource group name</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns>the retrieved vault</returns>
        public PSKeyVault GetVault(string vaultName, string resourceGroupName, IMicrosoftGraphClient graphClient = null)
        {
            if (string.IsNullOrWhiteSpace(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrWhiteSpace(resourceGroupName))
                throw new ArgumentNullException("resourceGroupName");

            try
            {
                var response = KeyVaultManagementClient.Vaults.Get(resourceGroupName, vaultName);

                return new PSKeyVault(response, graphClient);
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw;
            }
        }

        /// <summary>
        /// Update an existing vault. Only EnablePurgeProtection, EnableRbacAuthorization and Tags can be updated currently.
        /// </summary>
        /// <param name="existingVault">the existing vault</param>
        /// <param name="updatedParamater">updated paramater</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns>the updated vault</returns>
        public PSKeyVault UpdateVault(
            PSKeyVault existingVault,
            VaultCreationOrUpdateParameters updatedParamater,
            IMicrosoftGraphClient graphClient = null)
        {
            if (existingVault == null)
                throw new ArgumentNullException("existingVault");
            if (existingVault.OriginalVault == null)
                throw new ArgumentNullException("existingVault.OriginalVault");

            //Update the vault properties in the object received from server
            var properties = existingVault.OriginalVault.Properties;

            if (!(properties.EnablePurgeProtection.HasValue && properties.EnablePurgeProtection.Value)
                && updatedParamater.EnablePurgeProtection.HasValue
                && updatedParamater.EnablePurgeProtection.Value)
                properties.EnablePurgeProtection = updatedParamater.EnablePurgeProtection;

            properties.EnableRbacAuthorization = updatedParamater.EnableRbacAuthorization;
            properties.PublicNetworkAccess = string.IsNullOrEmpty(updatedParamater.PublicNetworkAccess)? 
                existingVault.PublicNetworkAccess : updatedParamater.PublicNetworkAccess;

            var response = KeyVaultManagementClient.Vaults.CreateOrUpdate(
                resourceGroupName: existingVault.ResourceGroupName,
                vaultName: existingVault.VaultName,
                parameters: new VaultCreateOrUpdateParameters
                {
                    Location = existingVault.Location,
                    Properties = properties,
                    Tags = TagsConversionHelper.CreateTagDictionary(updatedParamater.Tags, validate: true)
                }
                );
            return new PSKeyVault(response, graphClient);
        }

        /// <summary>
        /// Update an existing vault. Only EnabledForDeployment and AccessPolicies can be updated currently.
        /// </summary>
        /// <param name="existingVault">the existing vault</param>
        /// <param name="updatedPolicies">the update access policies</param>
        /// <param name="updatedEnabledForDeployment">enabled for deployment</param>
        /// <param name="updatedEnabledForTemplateDeployment">enabled for template deployment</param>
        /// <param name="updatedEnabledForDiskEncryption">enabled for disk encryption</param>
        /// <param name="updatedSoftDeleteSwitch">enabled for soft delete</param>
        /// <param name="updatedPurgeProtectionSwitch">enabled for purge protection</param>
        /// <param name="updatedRbacAuthorization">enabled for rbac authorization</param>
        /// <param name="softDeleteRetentionInDays">soft delete retention period (days)</param>
        /// <param name="updatedNetworkAcls">updated network rule set</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns>the updated vault</returns>
        public PSKeyVault UpdateVault(
            PSKeyVault existingVault,
            PSKeyVaultAccessPolicy[] updatedPolicies,
            bool? updatedEnabledForDeployment,
            bool? updatedEnabledForTemplateDeployment,
            bool? updatedEnabledForDiskEncryption,
            bool? updatedSoftDeleteSwitch,
            bool? updatedPurgeProtectionSwitch,
            bool? updatedRbacAuthorization,
            int? softDeleteRetentionInDays,
            PSKeyVaultNetworkRuleSet updatedNetworkAcls,
            IMicrosoftGraphClient graphClient = null)
        {
            if (existingVault == null)
                throw new ArgumentNullException("existingVault");
            if (existingVault.OriginalVault == null)
                throw new ArgumentNullException("existingVault.OriginalVault");

            //Update the vault properties in the object received from server
            //Only access policies and EnabledForDeployment can be changed
            var properties = existingVault.OriginalVault.Properties;
            properties.EnabledForDeployment = updatedEnabledForDeployment;
            properties.EnabledForTemplateDeployment = updatedEnabledForTemplateDeployment;
            properties.EnabledForDiskEncryption = updatedEnabledForDiskEncryption;
            properties.SoftDeleteRetentionInDays = softDeleteRetentionInDays;

            // soft delete flags can only be applied if they enable their respective behaviors
            // and if different from the current corresponding properties on the vault.
            if (!(properties.EnableSoftDelete.HasValue && properties.EnableSoftDelete.Value)
                && updatedSoftDeleteSwitch.HasValue
                && updatedSoftDeleteSwitch.Value)
                properties.EnableSoftDelete = updatedSoftDeleteSwitch;

            if (!(properties.EnablePurgeProtection.HasValue && properties.EnablePurgeProtection.Value)
                && updatedPurgeProtectionSwitch.HasValue
                && updatedPurgeProtectionSwitch.Value)
                properties.EnablePurgeProtection = updatedPurgeProtectionSwitch;

            // Update EnableRbacAuthorization when specified, otherwise stay current value
            properties.EnableRbacAuthorization = updatedRbacAuthorization;

            properties.AccessPolicies = (updatedPolicies == null) ?
                new List<AccessPolicyEntry>() :
                updatedPolicies.Select(a => new AccessPolicyEntry
                {
                    TenantId = a.TenantId,
                    ObjectId = a.ObjectId,
                    ApplicationId = a.ApplicationId,
                    Permissions = new Permissions
                    {
                        Keys = a.PermissionsToKeys.ToArray(),
                        Secrets = a.PermissionsToSecrets.ToArray(),
                        Certificates = a.PermissionsToCertificates.ToArray(),
                        Storage = a.PermissionsToStorage.ToArray(),
                    }
                }).ToList();

            UpdateVaultNetworkRuleSetProperties(properties, updatedNetworkAcls);

            var response = KeyVaultManagementClient.Vaults.CreateOrUpdate(
                resourceGroupName: existingVault.ResourceGroupName,
                vaultName: existingVault.VaultName,
                parameters: new VaultCreateOrUpdateParameters
                {
                    Location = existingVault.Location,
                    Properties = properties,
                    Tags = TagsConversionHelper.CreateTagDictionary(existingVault.Tags, validate: true)
                }
                );
            return new PSKeyVault(response, graphClient);
        }

        /// <summary>
        /// Delete an existing vault. Throws if vault is not found.
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="resourceGroupName"></param>
        public void DeleteVault(string vaultName, string resourceGroupName)
        {
            if (string.IsNullOrWhiteSpace(vaultName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrWhiteSpace(resourceGroupName))
                throw new ArgumentNullException("resourceGroupName");

            try
            {
                KeyVaultManagementClient.Vaults.Delete(resourceGroupName, vaultName);
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.NoContent || ce.Response.StatusCode == HttpStatusCode.NotFound)
                    throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.VaultNotFound, vaultName, resourceGroupName));
                throw;
            }
        }

        /// <summary>
        /// Purge a deleted vault. Throws if vault is not found.
        /// </summary>
        /// <param name="vaultName"></param>
        /// <param name="location"></param>
        public void PurgeVault(string vaultName, string location)
        {
            if (string.IsNullOrWhiteSpace(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentNullException(nameof(location));

            try
            {
                KeyVaultManagementClient.Vaults.PurgeDeleted(vaultName, location);
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.NoContent || ce.Response.StatusCode == HttpStatusCode.NotFound)
                    throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.DeletedVaultNotFound, vaultName, location));
                throw;
            }
        }

        /// <summary>
        /// Gets a deleted vault.
        /// </summary>
        /// <param name="vaultName">vault name</param>
        /// <param name="location">resource group name</param>
        /// <returns>the retrieved deleted vault. Null if vault is not found.</returns>
        public PSDeletedKeyVault GetDeletedVault(string vaultName, string location)
        {
            if (string.IsNullOrWhiteSpace(vaultName))
                throw new ArgumentNullException(nameof(vaultName));
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentNullException(nameof(location));

            try
            {
                var response = KeyVaultManagementClient.Vaults.GetDeleted(vaultName, location);

                return new PSDeletedKeyVault(response);
            }
            catch (CloudException ce)
            {
                if (ce.Response.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw;
            }
        }

        /// <summary>
        /// Lists deleted vault in a subscription.
        /// </summary>
        /// <returns>the retrieved deleted vault</returns>
        public List<PSDeletedKeyVault> ListDeletedVaults()
        {
            var deletedVaults = new List<PSDeletedKeyVault>();

            var response = KeyVaultManagementClient.Vaults.ListDeleted();

            foreach (var deletedVault in response)
            {
                deletedVaults.Add(new PSDeletedKeyVault(deletedVault));
            }

            while (response?.NextPageLink != null)
            {
                response = KeyVaultManagementClient.Vaults.ListDeletedNext(response.NextPageLink);

                foreach (var deletedVault in response)
                {
                    deletedVaults.Add(new PSDeletedKeyVault(deletedVault));
                }
            }

            return deletedVaults;
        }

        #endregion

        #region Managedhsm-related METHOD

        /// <summary>
        /// Create a Managed HSM pool
        /// </summary>
        /// <param name="parameters">vault creation parameters</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns></returns>
        public PSManagedHsm CreateOrRecoverManagedHsm(VaultCreationOrUpdateParameters parameters, IMicrosoftGraphClient graphClient = null)
        {
            if (parameters == null)
                throw new ArgumentNullException("parameters");
            if (string.IsNullOrWhiteSpace(parameters.Name))
                throw new ArgumentNullException("parameters.Name");
            if (string.IsNullOrWhiteSpace(parameters.ResourceGroupName))
                throw new ArgumentNullException("parameters.ResourceGroupName");
            if (string.IsNullOrWhiteSpace(parameters.Location))
                throw new ArgumentNullException("parameters.Location");

            ManagedHsm response = null;
            var properties = new ManagedHsmProperties();
            var managedHsmSku = new ManagedHsmSku();
            if (parameters.CreateMode != CreateMode.Recover)
            {
                if (parameters.Administrator?.Length == 0)
                    throw new ArgumentNullException("parameters.Administrator");
                if (string.IsNullOrWhiteSpace(parameters.SkuFamilyName))
                    throw new ArgumentNullException("parameters.SkuFamilyName");
                if (parameters.TenantId == Guid.Empty)
                    throw new ArgumentException("parameters.TenantId");
                if (!string.IsNullOrWhiteSpace(parameters.SkuName))
                {
                    if (Enum.TryParse(parameters.SkuName, true, out ManagedHsmSkuName skuName))
                    {
                        managedHsmSku.Name = skuName;
                    }
                    else
                    {
                        throw new InvalidEnumArgumentException("parameters.SkuName");
                    }
                }
                properties.TenantId = parameters.TenantId;
                properties.InitialAdminObjectIds = parameters.Administrator;
                properties.EnableSoftDelete = parameters.EnableSoftDelete;
                properties.SoftDeleteRetentionInDays = parameters.SoftDeleteRetentionInDays;
                properties.EnablePurgeProtection = parameters.EnablePurgeProtection;
                properties.NetworkAcls = parameters.MhsmNetworkAcls;
                properties.PublicNetworkAccess = parameters.PublicNetworkAccess;
                if (PublicNetworkAccess.Disabled.ToString().Equals(parameters.PublicNetworkAccess))
                {
                    properties.NetworkAcls.DefaultAction = NetworkRuleAction.Deny.ToString();
                }

                response = KeyVaultManagementClient.ManagedHsms.CreateOrUpdate(
                    resourceGroupName: parameters.ResourceGroupName,
                    name: parameters.Name,
                    parameters: new ManagedHsm
                    {
                        Location = parameters.Location,
                        Sku = managedHsmSku,
                        Tags = TagsConversionHelper.CreateTagDictionary(parameters.Tags, validate: true),
                        Properties = properties
                    });
            }
            else
            {
                properties.CreateMode = CreateMode.Recover;
                response = KeyVaultManagementClient.ManagedHsms.CreateOrUpdate(
                    resourceGroupName: parameters.ResourceGroupName,
                    name: parameters.Name,
                    parameters: new ManagedHsm
                    {
                        Location = parameters.Location,
                        // Can't update Tags
                        // Tags = TagsConversionHelper.CreateTagDictionary(parameters.Tags, validate: true),
                        Properties = properties
                    });
            }


            return new PSManagedHsm(response, graphClient);
        }

        /// <summary>
        /// Get an existing managed HSM. Returns null if managed HSM is not found.
        /// </summary>
        /// <param name="managedHsmName">managed HSM name</param>
        /// <param name="resourceGroupName">resource group name</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns>the retrieved Managed HSM</returns>
        public PSManagedHsm GetManagedHsm(string managedHsmName, string resourceGroupName, IMicrosoftGraphClient graphClient = null)
        {
            if (string.IsNullOrWhiteSpace(managedHsmName))
                throw new ArgumentNullException("vaultName");
            if (string.IsNullOrWhiteSpace(resourceGroupName))
                throw new ArgumentNullException("resourceGroupName");

            try
            {
                var response = KeyVaultManagementClient.ManagedHsms.Get(resourceGroupName, managedHsmName);

                return new PSManagedHsm(response, graphClient);
            }
            catch (ManagedHsmErrorException ce) when (ce.IsNotFoundException())
            {
                return null;
            }
        }

        public PSDeletedManagedHsm GetDeletedManagedHsm(string managedHsmName, string location)
        {
            if (string.IsNullOrWhiteSpace(managedHsmName))
                throw new ArgumentNullException("HsmName");
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentNullException("Location");

            try
            {
                var response = KeyVaultManagementClient.ManagedHsms.GetDeleted(managedHsmName, location);

                return new PSDeletedManagedHsm(response);
            }
            catch (ManagedHsmErrorException ce) when (ce.IsNotFoundException())
            {
                return null;
            }
        }


        /// <summary>
        /// List all existing Managed HSMs.
        /// </summary>
        /// <param name="resourceGroupName">resource group name</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns>the retrieved Managed HSM</returns>
        public List<PSManagedHsm> ListManagedHsms(string resourceGroupName, IMicrosoftGraphClient graphClient = null)
        {
            return resourceGroupName == null ? ListManagedHsmsBySubscription(graphClient) :
                ListManagedHsmsByResourceGroup(resourceGroupName, graphClient);
        }

        private List<PSManagedHsm> ListManagedHsmsByResourceGroup(string resourceGroupName, IMicrosoftGraphClient graphClient = null)
        {
            List<PSManagedHsm> managedHsms = new List<PSManagedHsm>();
            IPage<ManagedHsm> response = KeyVaultManagementClient.ManagedHsms.ListByResourceGroupAsync(resourceGroupName).GetAwaiter().GetResult();
            foreach (var managedHsm in response)
            {
                managedHsms.Add(new PSManagedHsm(managedHsm, graphClient));
            }

            while (response?.NextPageLink != null)
            {
                response = KeyVaultManagementClient.ManagedHsms.ListByResourceGroupNextAsync(response.NextPageLink).GetAwaiter().GetResult();

                foreach (var managedHsm in response)
                {
                    managedHsms.Add(new PSManagedHsm(managedHsm, graphClient));
                }
            }

            return managedHsms;
        }

        private List<PSManagedHsm> ListManagedHsmsBySubscription(IMicrosoftGraphClient graphClient = null)
        {
            List<PSManagedHsm> managedHsms = new List<PSManagedHsm>();
            IPage<ManagedHsm> response = KeyVaultManagementClient.ManagedHsms.ListBySubscriptionAsync().GetAwaiter().GetResult();

            foreach (var managedHsm in response)
            {
                managedHsms.Add(new PSManagedHsm(managedHsm, graphClient));
            }

            while (response?.NextPageLink != null)
            {
                response = KeyVaultManagementClient.ManagedHsms.ListBySubscriptionNextAsync(response.NextPageLink).GetAwaiter().GetResult();

                foreach (var managedHsm in response)
                {
                    managedHsms.Add(new PSManagedHsm(managedHsm, graphClient));
                }
            }

            return managedHsms;
        }

        public List<PSDeletedManagedHsm> ListDeletedManagedHsms()
        {
            List<PSDeletedManagedHsm> deletedManagedHsms = new List<PSDeletedManagedHsm>();
            IPage<DeletedManagedHsm> response = KeyVaultManagementClient.ManagedHsms.ListDeleted();

            foreach (var deletedManagedHsm in response)
            {
                deletedManagedHsms.Add(new PSDeletedManagedHsm(deletedManagedHsm));
            }

            while (response?.NextPageLink != null)
            {
                response = KeyVaultManagementClient.ManagedHsms.ListDeletedNext(response.NextPageLink);

                foreach (var deletedManagedHsm in response)
                {
                    deletedManagedHsms.Add(new PSDeletedManagedHsm(deletedManagedHsm));
                }
            }

            return deletedManagedHsms;
        }
       
        /// <summary>
        /// Update an existing Managed HSM.
        /// </summary>
        /// <param name="existingManagedHsm">existing Managed HSM</param>
        /// <param name="parameters">HSM update parameters</param>
        /// <param name="graphClient">the active directory client</param>
        /// <returns>the updated Managed HSM</returns>
        public PSManagedHsm UpdateManagedHsm(PSManagedHsm existingManagedHsm, VaultCreationOrUpdateParameters parameters, IMicrosoftGraphClient graphClient = null)
        {
            if (existingManagedHsm == null)
                throw new ArgumentNullException("existingManagedHsm");
            if (existingManagedHsm.OriginalManagedHsm == null)
                throw new ArgumentNullException("existingManagedHsm.OriginalManagedHsm");

            //Update the vault properties in the object received from server
            var properties = existingManagedHsm.OriginalManagedHsm.Properties;
            properties.EnablePurgeProtection = parameters.EnablePurgeProtection;
            if (!string.IsNullOrEmpty(parameters.PublicNetworkAccess))
            {
                properties.PublicNetworkAccess = parameters.PublicNetworkAccess;
                properties.NetworkAcls.DefaultAction = PublicNetworkAccess.Enabled.ToString().Equals(parameters.PublicNetworkAccess) ? 
                    NetworkRuleAction.Allow.ToString() : NetworkRuleAction.Deny.ToString();
            }
            var response = KeyVaultManagementClient.ManagedHsms.Update(
                resourceGroupName: existingManagedHsm.ResourceGroupName,
                name: existingManagedHsm.Name,
                parameters: new ManagedHsm
                {
                    Location = existingManagedHsm.Location,
                    Sku = new ManagedHsmSku
                    {
                        Name = (ManagedHsmSkuName)Enum.Parse(typeof(ManagedHsmSkuName), existingManagedHsm.Sku)
                    },
                    Tags = TagsConversionHelper.CreateTagDictionary(parameters.Tags, validate: true),
                    Properties = properties
                });

            return new PSManagedHsm(response, graphClient);
        }

        /// <summary>
        /// Delete an existing Managed HSM.
        /// </summary>
        /// <param name="managedHsm"></param>
        /// <param name="resourceGroupName"></param>
        public void DeleteManagedHsm(string managedHsm, string resourceGroupName)
        {
            if (string.IsNullOrWhiteSpace(managedHsm))
                throw new ArgumentNullException("managedHsm");
            if (string.IsNullOrWhiteSpace(resourceGroupName))
                throw new ArgumentNullException("resourceGroupName");

            try
            {
                KeyVaultManagementClient.ManagedHsms.Delete(resourceGroupName, managedHsm);
            }
            catch (ManagedHsmErrorException ce) when (ce.IsNotFoundException())
            {
                // there's a known issue that the long running delete operation will
                // finally throws an not found exception,
                // we'll just ignore it
            }
        }

        /// <summary>
        /// Purge a deleted Managed HSM. Throws if Managed HSM is not found.
        /// </summary>
        /// <param name="managedHsmName"></param>
        /// <param name="location"></param>
        public void PurgeManagedHsm(string managedHsmName, string location)
        {
            if (string.IsNullOrWhiteSpace(managedHsmName))
                throw new ArgumentNullException(nameof(managedHsmName));
            if (string.IsNullOrWhiteSpace(location))
                throw new ArgumentNullException(nameof(location));

            try
            {
                KeyVaultManagementClient.ManagedHsms.PurgeDeleted(managedHsmName, location);
            }
            catch (ManagedHsmErrorException ce) when (ce.IsNotFoundException() || ce.IsNoContentException())
            {
                throw new ArgumentException(string.Format(PSKeyVaultProperties.Resources.DeletedManagedHsmNotFound, managedHsmName, location));
            }
        }

        #endregion

        #region HELP_METHODS
        /// <summary>
        /// Update vault network rule set
        /// </summary>
        /// <param name="vaultProperties">Vault property</param>
        /// <param name="psRuleSet">Network rule set input</param>
        private static void UpdateVaultNetworkRuleSetProperties(VaultProperties vaultProperties, PSKeyVaultNetworkRuleSet psRuleSet)
        {
            if (vaultProperties == null)
                return;

            var updatedRuleSet = new NetworkRuleSet();       // It contains default settings
            if (psRuleSet != null)
            {
                updatedRuleSet.DefaultAction = psRuleSet.DefaultAction.ToString();
                updatedRuleSet.Bypass = psRuleSet.Bypass.ToString();

                if (psRuleSet.IpAddressRanges != null && psRuleSet.IpAddressRanges.Count > 0)
                {
                    updatedRuleSet.IpRules = psRuleSet.IpAddressRanges.Select(ipAddress => new IPRule { Value = ipAddress }).ToList();
                }
                else
                {   // Send empty array [] to server to override default
                    updatedRuleSet.IpRules = new List<IPRule>();
                }

                if (psRuleSet.VirtualNetworkResourceIds != null && psRuleSet.VirtualNetworkResourceIds.Count > 0)
                {
                    updatedRuleSet.VirtualNetworkRules = psRuleSet.VirtualNetworkResourceIds.Select(resourceId => new VirtualNetworkRule { Id = resourceId }).ToList();
                }
                else
                {   // Send empty array [] to server to override default
                    updatedRuleSet.VirtualNetworkRules = new List<VirtualNetworkRule>();
                }
            }

            vaultProperties.NetworkAcls = updatedRuleSet;
        }
        #endregion
    }
}
