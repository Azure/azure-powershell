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

using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using Microsoft.Rest.Azure.OData;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutomationManagement = Microsoft.Azure.Management.Automation;
using DscNode = Microsoft.Azure.Management.Automation.Models.DscNode;
using Job = Microsoft.Azure.Management.Automation.Models.Job;
using JobSchedule = Microsoft.Azure.Management.Automation.Models.JobSchedule;
using Schedule = Microsoft.Azure.Commands.Automation.Model.Schedule;
using Microsoft.Azure.Management.Internal.ResourceManager.Version2018_05_01;

namespace Microsoft.Azure.Commands.Automation.Common
{
    public partial class AutomationPSClient : IAutomationPSClient
    {
        #region DscConfiguration Operations

        public IEnumerable<Model.DscConfiguration> ListDscConfigurations(
            string resourceGroupName,
            string automationAccountName,
            ref string nextLink)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
                Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

                var dscConfigurations = new List<AutomationManagement.Models.DscConfiguration>();

                Rest.Azure.IPage<AutomationManagement.Models.DscConfiguration> response;

                if (string.IsNullOrEmpty(nextLink))
                {
                    response = this.automationManagementClient.DscConfiguration.ListByAutomationAccount(
                                    resourceGroupName,                                  
                                    automationAccountName);
                }
                else
                {
                    response = this.automationManagementClient.DscConfiguration.ListByAutomationAccountNext(nextLink);
                }
                    
                
                nextLink = response.NextPageLink;
                return response.Select(configuration => new Model.DscConfiguration(resourceGroupName, automationAccountName, configuration));
            }
        }

        public Model.DscConfiguration GetConfiguration(
            string resourceGroupName,
            string automationAccountName,
            string configurationName)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
                Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
                Requires.Argument("ConfigurationName", configurationName).NotNull();

                var configuration =
                            this.automationManagementClient.DscConfiguration.Get(
                                resourceGroupName,
                                automationAccountName,
                                configurationName);

                return new Model.DscConfiguration(resourceGroupName, automationAccountName, configuration);
            }
        }

        public DirectoryInfo GetConfigurationContent(string resourceGroupName, string automationAccountName, string configurationName, bool? isDraft, string outputFolder, bool overwriteExistingFile)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                if (isDraft != null)
                {
                    throw new NotImplementedException(string.Format(CultureInfo.CurrentCulture, Resources.ConfigurationDraftMode));
                }

                try
                {
                    var configuration = this.automationManagementClient.DscConfiguration.GetContent(resourceGroupName, automationAccountName, configurationName);
                    if (configuration == null)
                    {
                        throw new ResourceNotFoundException(typeof(ConfigurationContent),
                            string.Format(CultureInfo.CurrentCulture, Resources.ConfigurationContentNotFound, configurationName));
                    }

                    string outputFolderFullPath = this.GetCurrentDirectory();

                    if (!string.IsNullOrEmpty(outputFolder))
                    {
                        outputFolderFullPath = this.ValidateAndGetFullPath(outputFolder);
                    }

                    var slot = (isDraft == null) ? Constants.Published : Constants.Draft;

                    const string FileExtension = ".ps1";

                    var outputFilePath = outputFolderFullPath + "\\" + configurationName + FileExtension;

                    // file exists and overwrite Not specified
                    if (File.Exists(outputFilePath) && !overwriteExistingFile)
                    {
                        throw new ArgumentException(
                                string.Format(CultureInfo.CurrentCulture, Resources.ConfigurationAlreadyExists, outputFilePath));
                    }

                    // Write to the file
                    this.WriteFile(outputFilePath, new StreamReader(configuration).ReadToEnd());

                    return new DirectoryInfo(configurationName + FileExtension);
                }
                catch (ErrorResponseException ErrorResponseException)
                {
                    if (ErrorResponseException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        throw new ResourceNotFoundException(typeof(ConfigurationContent),
                            string.Format(CultureInfo.CurrentCulture, Resources.ConfigurationContentNotFound, configurationName));
                    }

                    throw;
                }
            }
        }

        public Model.DscConfiguration CreateConfiguration(
            string resourceGroupName,
            string automationAccountName,
            string sourcePath,
            IDictionary tags,
            string description,
            bool? logVerbose,
            bool published,
            bool overWrite)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
                Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
                Requires.Argument("SourcePath", sourcePath).NotNull();

                string fileContent = null;
                string configurationName = String.Empty;

                if (File.Exists(Path.GetFullPath(sourcePath)))
                {
                    fileContent = System.IO.File.ReadAllText(sourcePath);
                }
                else {
                    // exception in accessing the file path
                    throw new FileNotFoundException(
                                        string.Format(
                                            CultureInfo.CurrentCulture,
                                            Resources.ConfigurationSourcePathInvalid));
                }

                // configuration name is same as filename
                configurationName = Path.GetFileNameWithoutExtension(sourcePath);

                if (!System.Text.RegularExpressions.Regex.IsMatch(configurationName, "^([a-zA-Z]{1}([a-zA-Z0-9]|_){0,63})$")) {
                    throw new PSInvalidOperationException("Invalid configuration name. Valid configuration names can contain only letters, numbers, and underscores. The name must start with a letter. The length of the name must be between 1 and 64 characters. ");
                }

                // for the private preview, configuration can be imported in Published mode only
                // Draft mode is not implemented
                if (!published)
                {
                    throw new NotImplementedException(
                                        string.Format(
                                            CultureInfo.CurrentCulture,
                                            Resources.ConfigurationNotPublished));
                }

                // if configuration already exists, ensure overwrite flag is specified
                var configurationModel = this.TryGetConfigurationModel(
                    resourceGroupName,
                    automationAccountName,
                    configurationName);
                if (configurationModel != null)
                {
                    if (!overWrite)
                    {
                        throw new ResourceCommonException(typeof(Model.DscConfiguration),
                            string.Format(CultureInfo.CurrentCulture, Resources.ConfigurationAlreadyExists, configurationName));
                    }
                }

                // location of the configuration is set to same as that of automation account
                string location = this.GetAutomationAccount(resourceGroupName, automationAccountName).Location;

                IDictionary<string, string> configurationTags = null;
                if (tags != null) configurationTags = tags.Cast<DictionaryEntry>().ToDictionary(kvp => kvp.Key.ToString(), kvp => kvp.Value.ToString());

                var configurationCreateParameters = new DscConfigurationCreateOrUpdateParameters()
                {
                    Name = configurationName,
                    Location = location,
                    Tags = configurationTags,

                        Description = String.IsNullOrEmpty(description) ? String.Empty : description,
                        LogVerbose = (logVerbose.HasValue) ? logVerbose.Value : false,
                        Source = new Microsoft.Azure.Management.Automation.Models.ContentSource()
                        {
                            // only embeddedContent supported for now
                            Type = Model.ContentSourceType.embeddedContent.ToString(),
                            Value = fileContent
                        }
                };

                try
                {
                    var configuration =
                        this.automationManagementClient.DscConfiguration.CreateOrUpdate(
                        resourceGroupName,
                        automationAccountName,
                        configurationName,
                        configurationCreateParameters);

                    return new Model.DscConfiguration(resourceGroupName, automationAccountName, configuration);
                }
                catch (Microsoft.Azure.Management.Automation.Models.ErrorResponseException ex)
                {
                    if (ex.Response.Content != null)
                    {
                        throw new Microsoft.Azure.Management.Automation.Models.ErrorResponseException(ex.Response.Content, ex);
                    }
                    else {
                        throw ex;
                    }
                }
                catch (Exception ex) {
                    throw ex;
                }
            }
        }

        private Model.DscConfiguration TryGetConfigurationModel(string resourceGroupName, string automationAccountName, string configurationName)
        {
            Model.DscConfiguration configuration = null;
            try
            {
                configuration = this.GetConfiguration(
                                                resourceGroupName,
                                                automationAccountName,
                                                configurationName);
            }
            catch (ErrorResponseException e)
            {
                if (e.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    configuration = null;
                }
                else
                {
                    throw;
                }
            }
            return configuration;
        }

        public Model.DscConfiguration CreateConfiguration(
           string resourceGroupName,
           string automationAccountName,
           string configrationName,
           string nodeName)
        {
            string configurationContent = "Configuration #configrationName# { Node #nodeName# { } } ";
            configurationContent = configurationContent.Replace("#configrationName#", configrationName);
            configurationContent = configurationContent.Replace("#nodeName#", nodeName);

            using (var request = new RequestSettings(this.automationManagementClient))
            {

                // location of the configuration is set to same as that of automation account
                string location = this.GetAutomationAccount(resourceGroupName, automationAccountName).Location;

                var configurationCreateParameters = new DscConfigurationCreateOrUpdateParameters()
                {
                    Name = configrationName,
                    Location = location,

                    Description = String.Empty,
                    LogVerbose = false,
                    Source = new Microsoft.Azure.Management.Automation.Models.ContentSource()
                    {
                        // only embeddedContent supported for now
                        Type = Model.ContentSourceType.embeddedContent.ToString(),
                        Value = configurationContent
                    }
                };

                var configuration =
                    this.automationManagementClient.DscConfiguration.CreateOrUpdate(
                        resourceGroupName,
                        automationAccountName,
                        configrationName,
                        configurationCreateParameters);

                return new Model.DscConfiguration(resourceGroupName, automationAccountName, configuration);
            }
        }

        public void DeleteConfiguration(string resourceGroupName, string automationAccountName, string name)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                try
                {
                    this.automationManagementClient.DscConfiguration.Delete(resourceGroupName, automationAccountName, name);
                }
                catch (ErrorResponseException ErrorResponseException)
                {
                    if (ErrorResponseException.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        throw new ResourceNotFoundException(
                            typeof(Model.DscConfiguration),
                            string.Format(CultureInfo.CurrentCulture, Resources.ConfigurationNotFound, name));
                    }
                    throw;
                }
            }
        }

        #endregion

        #region DscMetaConfig Operations
        public DirectoryInfo GetDscMetaConfig(string resourceGroupName, string automationAccountName, string outputFolder, string[] computerNames, bool overwriteExistingFile)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
                Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

                string outputFolderFullPath = this.GetCurrentDirectory(); // initialize with current directory;

                if (!String.IsNullOrEmpty(outputFolder))
                {
                    outputFolderFullPath = this.ValidateAndGetFullPath(outputFolder);
                }

                var dscMetaConfig = this.automationManagementClient.AgentRegistrationInformation.Get(
                    resourceGroupName,
                    automationAccountName);

                // get the metaconfig value
                string dscMetaConfigValue = new DscOnboardingMetaconfig(resourceGroupName, automationAccountName, dscMetaConfig).DscMetaConfiguration;

                if (computerNames == null)
                {
                    computerNames = new[] { "localhost" }; // No computer specified. Initialize with Localhost
                }

                string outputFilePath = String.Empty;
                const string FileExtension = ".meta.mof"; // this will be .meta.mof
                const string DscMetaConfigsFolder = "DscMetaConfigs"; // Folder name where metaconfigs are stored

                outputFolderFullPath = System.IO.Path.Combine(outputFolderFullPath, DscMetaConfigsFolder);

                this.CreateOutputFolder(outputFolderFullPath);

                foreach (string computerName in computerNames)
                {
                    outputFilePath = outputFolderFullPath + "\\" + computerName + FileExtension;

                    // file exists and overwrite Not specified
                    if (File.Exists(outputFilePath) && !overwriteExistingFile)
                    {
                        throw new ArgumentException(
                                string.Format(CultureInfo.CurrentCulture, Resources.MetaconfigAlreadyExists, outputFilePath));
                    }

                    // Write to the file
                    this.WriteFile(outputFilePath, dscMetaConfigValue);
                }

                return new DirectoryInfo(outputFolderFullPath);
            }
        }

        private void CreateOutputFolder(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    System.IO.Directory.CreateDirectory(folderPath);
                }
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException(
                        string.Format(CultureInfo.CurrentCulture, Resources.UnauthorizedAccess, folderPath));
            }
        }

        /// <summary>
        /// Get the current directory path
        /// </summary>
        /// <returns>full path of the current directory</returns>
        private string GetCurrentDirectory()
        {
            string currentDirectory = String.Empty;

            try
            {
                currentDirectory = Directory.GetCurrentDirectory();
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException(
                        string.Format(CultureInfo.CurrentCulture, Resources.UnauthorizedAccess, currentDirectory));
            }

            return currentDirectory;
        }

        /// <summary>
        /// Validate and return the full folder path
        /// </summary>
        /// <param name="folderPath">Folder path to be validated</param>
        private string ValidateAndGetFullPath(string folderPath)
        {
            string fullPath = String.Empty;

            // check if folder exists - path can be absolute or relative
            if (Directory.Exists(folderPath))
            {
                // get the full path
                fullPath = Path.GetFullPath(folderPath);
            }
            else
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture, Resources.InvalidFolderPath, folderPath));
            }

            return fullPath;
        }

        private void WriteFile(string outputFilePath, string fileContent)
        {
            try
            {
                File.WriteAllText(outputFilePath, fileContent);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.CurrentCulture, Resources.InvalidFilePath, outputFilePath));
            }
            catch (UnauthorizedAccessException)
            {
                throw new UnauthorizedAccessException(
                    string.Format(CultureInfo.CurrentCulture, Resources.UnauthorizedAccess, outputFilePath));
            }
        }

        #endregion

        #region AgentRegistration Operations
        public Model.AgentRegistration GetAgentRegistration(string resourceGroupName, string automationAccountName)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
                Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

                var agentRegistration = this.automationManagementClient.AgentRegistrationInformation.Get(
                    resourceGroupName,
                    automationAccountName);

                return new Model.AgentRegistration(resourceGroupName, automationAccountName, agentRegistration);
            }
        }

        public Model.AgentRegistration NewAgentRegistrationKey(
            string resourceGroupName,
            string automationAccountName,
            string keyType)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
                Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
                Requires.Argument("KeyType", keyType).NotNull();

                AgentRegistrationRegenerateKeyParameter keyName = new AgentRegistrationRegenerateKeyParameter() { KeyName = keyType };

                var agentRegistration = this.automationManagementClient.AgentRegistrationInformation.RegenerateKey(
                    resourceGroupName,
                    automationAccountName,
                    keyName);

                return new Model.AgentRegistration(resourceGroupName, automationAccountName, agentRegistration);
            }
        }
        #endregion

        #region DscNode Operations
        public Model.DscNode GetDscNodeById(
            string resourceGroupName,
            string automationAccountName,
            Guid nodeId)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
                Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
                Requires.Argument("NodeId", nodeId).NotNull();

                try
                {
                    var node =
                                this.automationManagementClient.DscNode.Get(
                                    resourceGroupName,
                                    automationAccountName,
                                    nodeId.ToString());

                    return new Model.DscNode(resourceGroupName, automationAccountName, node);
                }
                catch (ErrorResponseException ErrorResponseException)
                {
                    if (ErrorResponseException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        throw new ResourceNotFoundException(typeof(DscNode), string.Format(CultureInfo.CurrentCulture, Resources.NodeNotFound, nodeId));
                    }

                    throw;
                }
            }
        }

        public IEnumerable<Model.DscNode> ListDscNodesByName(
            string resourceGroupName,
            string automationAccountName,
            string nodeName,
            string status,
            ref string nextLink)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
                Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
                Requires.Argument("NodeName", nodeName).NotNull();

                Rest.Azure.IPage<AutomationManagement.Models.DscNode> response;

                if (string.IsNullOrEmpty(nextLink))
                {
                    response = this.automationManagementClient.DscNode.ListByAutomationAccount(
                                    resourceGroupName,
                                    automationAccountName,
                                    this.GetNodeListFilterString(status, nodeName));
                }
                else
                {
                    response = this.automationManagementClient.DscNode.ListByAutomationAccountNext(nextLink);
                }

                nextLink = response.NextPageLink;

                return response.Select(dscNode => new Model.DscNode(resourceGroupName, automationAccountName, dscNode));
            }
        }

        public IEnumerable<Model.DscNode> ListDscNodesByNodeConfiguration(
            string resourceGroupName,
            string automationAccountName,
            string nodeConfigurationName,
            string status,
            ref string nextLink)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
                Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
                Requires.Argument("NodeConfigurationName", nodeConfigurationName).NotNull();

                Rest.Azure.IPage<AutomationManagement.Models.DscNode> response;

                if (string.IsNullOrEmpty(nextLink))
                {
                    response = this.automationManagementClient.DscNode.ListByAutomationAccount(
                                            resourceGroupName,
                                            automationAccountName, this.GetNodeListFilterString(status, nodeConfigurationName));
                }
                else
                {
                    response = this.automationManagementClient.DscNode.ListByAutomationAccountNext(nextLink);
                }
                nextLink = response.NextPageLink;
                
                return response.Select(dscNode => new Model.DscNode(resourceGroupName, automationAccountName, dscNode));
            }
        }

        public IEnumerable<Model.DscNode> ListDscNodesByConfiguration(
            string resourceGroupName,
            string automationAccountName,
            string configurationName,
            string status,
            ref string nextLink)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
                Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
                Requires.Argument("ConfigurationName", configurationName).NotNull();

                IEnumerable<Model.DscNode> listOfNodes = Enumerable.Empty<Model.DscNode>();

                // first get the list of node configurations for the given configuration
                var listOfNodeConfigurations = this.automationManagementClient.DscNodeConfiguration.ListByAutomationAccount(
                    resourceGroupName, automationAccountName, null);

                    // todo: configurationName
                    //.EnumerateNodeConfigurationsByConfigurationName(
                    //resourceGroupName,
                    //automationAccountName,
                    //);

                IEnumerable<Model.DscNode> listOfNodesForGivenNodeConfiguration;

                // for each nodeconfiguration, get the list of nodes and concatenate
                foreach (var nodeConfiguration in listOfNodeConfigurations)
                {
                    listOfNodesForGivenNodeConfiguration =
                        this.ListDscNodesByNodeConfiguration(
                            resourceGroupName,
                            automationAccountName,
                            nodeConfiguration.Name,
                            status,
                            ref nextLink);

                    if (listOfNodesForGivenNodeConfiguration != null)
                    {
                        listOfNodes = listOfNodes.Concat(listOfNodesForGivenNodeConfiguration);
                    }
                }

                return listOfNodes;
            }
        }

        public IEnumerable<Model.DscNode> ListDscNodes(
            string resourceGroupName,
            string automationAccountName,
            string status,
            ref string nextLink)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
                Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

               Rest.Azure.IPage<AutomationManagement.Models.DscNode> response;
                
                if (string.IsNullOrEmpty(nextLink))
                {
                    response = this.automationManagementClient.DscNode.ListByAutomationAccount(
                            resourceGroupName,
                            automationAccountName,
                            this.GetNodeListFilterString(status, null));
                }
                else
                {
                    response = this.automationManagementClient.DscNode.ListByAutomationAccountNext(nextLink);
                }

                nextLink = response.NextPageLink;
                
                return response.Select(dscNode => new Model.DscNode(resourceGroupName, automationAccountName, dscNode));
            }
        }


        public Model.DscNode SetDscNodeById(
            string resourceGroupName,
            string automationAccountName,
            Guid nodeId,
            string nodeConfigurationName
            )
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
                Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
                Requires.Argument("NodeId", nodeId).NotNull();
                Requires.Argument("NodeConfigurationName", nodeConfigurationName).NotNull();

                try
                {
                    var getNode = this.automationManagementClient.DscNode.Get(
                            resourceGroupName,
                            automationAccountName,
                            nodeId.ToString());
                }
                catch (ErrorResponseException ErrorResponseException)
                {
                    if (ErrorResponseException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.NodeNotFound), ErrorResponseException);
                    }

                    throw;
                }

                // ***
                // Note: No need to check if an existing configuration is already assigned. The confirmation is obtained when the cmdlet is executed
                // *** 

                var nodeConfiguration = new DscNodeUpdateParametersProperties { Name = nodeConfigurationName };

                var node =
                    this.automationManagementClient.DscNode.Update(
                        resourceGroupName,
                        automationAccountName,
                        nodeId.ToString(),
                        new DscNodeUpdateParameters
                        {
                            NodeId = nodeId.ToString(),
                            Properties = nodeConfiguration
                        });

                return new Model.DscNode(resourceGroupName, automationAccountName, node);
            }
        }

        public void DeleteDscNode(string resourceGroupName, string automationAccountName, Guid nodeId)
        {
            try
            {
                using (var request = new RequestSettings(this.automationManagementClient))
                {
                    this.automationManagementClient.DscNode.Delete(
                        resourceGroupName,
                        automationAccountName,
                        nodeId.ToString());
                }
            }
            catch (ErrorResponseException ErrorResponseException)
            {
                if (ErrorResponseException.Response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    throw new ResourceNotFoundException(typeof(DscNode),
                        string.Format(CultureInfo.CurrentCulture, Resources.DscNodeNotFound, nodeId.ToString()));
                }

                throw;
            }
        }

        public void RegisterDscNode(string resourceGroupName,
                                            string automationAccountName,
                                            string azureVMName,
                                            string nodeconfigurationName,
                                            string configurationMode,
                                            int configurationModeFrequencyMins,
                                            int refreshFrequencyMins,
                                            bool rebootFlag,
                                            string actionAfterReboot,
                                            bool moduleOverwriteFlag,
                                            string azureVmResourceGroup,
                                            string azureVmLocation,
                                            IAzureContext azureContext)
        {
            // get the location from AutomationAccountName. This will validate the account too
            string location = this.GetAutomationAccount(resourceGroupName, automationAccountName).Location;

            // if vm location is specified, use that
            if (!String.IsNullOrEmpty(azureVmLocation))
            {
                location = azureVmLocation;
            }

            // if azureVmResourceGroup not specified, use the resource group
            if (String.IsNullOrEmpty(azureVmResourceGroup))
            {
                azureVmResourceGroup = resourceGroupName;
            }

            // get the endpoint and keys
            Model.AgentRegistration agentRegistrationInfo = this.GetAgentRegistration(
                resourceGroupName,
                automationAccountName);

            var parameters = new ParametersObj
            {
                ActionAfterReboot = new TemplateParameters
                {
                    Value = actionAfterReboot
                },
                AllowModuleOverwrite = new TemplateParameters
                {
                    Value = moduleOverwriteFlag
                },
                ConfigurationFunction = new TemplateParameters
                {
                    Value = Constants.ConfigurationFunction
                },
                ConfigurationMode = new TemplateParameters
                {
                    Value = configurationMode
                },
                ConfigurationModeFrequencyMins = new TemplateParameters
                {
                    Value = configurationModeFrequencyMins
                },
                Location = new TemplateParameters
                {
                    Value = location
                },
                ModulesUrl = new TemplateParameters
                {
                    Value = Constants.ModulesUrl
                },
                NodeConfigurationName = new TemplateParameters
                {
                    Value = nodeconfigurationName
                },
                RebootNodeIfNeeded = new TemplateParameters
                {
                    Value = rebootFlag
                },
                RefreshFrequencyMins = new TemplateParameters
                {
                    Value = refreshFrequencyMins
                },
                RegistrationKey = new TemplateParameters
                {
                    Value = agentRegistrationInfo.PrimaryKey
                },
                RegistrationUrl = new TemplateParameters
                {
                    Value = agentRegistrationInfo.Endpoint
                },
                Timestamp = new TemplateParameters
                {
                    Value = DateTimeOffset.UtcNow.ToString("o")
                },
                VmName = new TemplateParameters
                {
                    Value = azureVMName
                }
            };

            var armClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(azureContext, AzureEnvironment.Endpoint.ResourceManager);

            var deployment = new Management.Internal.ResourceManager.Version2018_05_01.Models.Deployment
            {
                Properties = new Management.Internal.ResourceManager.Version2018_05_01.Models.DeploymentProperties
                {
                    TemplateLink = new Management.Internal.ResourceManager.Version2018_05_01.Models.TemplateLink(Constants.TemplateFile),
                    Parameters = parameters
                }
            };

            Task.Run(() => armClient.Deployments.CreateOrUpdateWithHttpMessagesAsync(azureVmResourceGroup, Guid.NewGuid().ToString(), deployment)).Wait();
        }
        #endregion

        #region compilationjob

        public Model.CompilationJob GetCompilationJob(string resourceGroupName, string automationAccountName, Guid Id)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                try
                {
                    var job = this.automationManagementClient.DscCompilationJob.Get(resourceGroupName, automationAccountName, Id.ToString());
                    if (job == null)
                    {
                        throw new ResourceNotFoundException(typeof(DscCompilationJob),
                            string.Format(CultureInfo.CurrentCulture, Resources.CompilationJobNotFound, Id));
                    }

                    return new Model.CompilationJob(resourceGroupName, automationAccountName, job);
                }
                catch (ErrorResponseException ErrorResponseException)
                {
                    if (ErrorResponseException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        throw new ResourceNotFoundException(typeof(DscCompilationJob),
                            string.Format(CultureInfo.CurrentCulture, Resources.CompilationJobNotFound, Id));
                    }

                    throw;
                }
            }
        }

        public IEnumerable<Model.CompilationJob> ListCompilationJobsByConfigurationName(string resourceGroupName, string automationAccountName, string configurationName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus, ref string nextLink)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Rest.Azure.IPage<AutomationManagement.Models.DscCompilationJob> response;

                if(string.IsNullOrEmpty(nextLink))
                {
                    response = this.automationManagementClient.DscCompilationJob.ListByAutomationAccount(
                                        resourceGroupName,
                                        automationAccountName, this.GetDscJobFilterString(configurationName, startTime, endTime, jobStatus));
                }
                else
                {
                    response = this.automationManagementClient.DscCompilationJob.ListByAutomationAccountNext(nextLink);
                }

                nextLink = response.NextPageLink;

                return response.Select(jobModel => new Model.CompilationJob(resourceGroupName, automationAccountName, jobModel));
            }
        }

        public IEnumerable<Model.CompilationJob> ListCompilationJobs(string resourceGroupName, string automationAccountName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus, ref string nextLink)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Rest.Azure.IPage<AutomationManagement.Models.DscCompilationJob> response;

                if (string.IsNullOrEmpty(nextLink))
                {
                    response = this.automationManagementClient.DscCompilationJob.ListByAutomationAccount(
                                        resourceGroupName,
                                        automationAccountName, this.GetDscJobFilterString(null, startTime, endTime, jobStatus));
                }
                else
                {
                    response = this.automationManagementClient.DscCompilationJob.ListByAutomationAccountNext(nextLink);
                }

                nextLink = response.NextPageLink;

                return response.Select(jobModel => new Model.CompilationJob(resourceGroupName, automationAccountName, jobModel));
            }
        }

        public CompilationJob StartCompilationJob(string resourceGroupName, string automationAccountName, string configurationName, IDictionary parameters, IDictionary configurationData, bool incrementNodeConfigurationBuild)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var createJobParameters = new DscCompilationJobCreateParameters()
                {
                     Configuration = new DscConfigurationAssociationProperty()
                     {
                          Name = configurationName
                     },
                     Parameters = this.ProcessConfigurationParameters(parameters, configurationData),
					 IncrementNodeConfigurationBuild = incrementNodeConfigurationBuild

                };

                var job = this.automationManagementClient.DscCompilationJob.Create(resourceGroupName, automationAccountName, Guid.NewGuid().ToString(), createJobParameters);

                return new Model.CompilationJob(resourceGroupName, automationAccountName, job);
            }
        }

        public IEnumerable<Model.JobStream> GetDscCompilationJobStream(string resourceGroupName, string automationAccountName, Guid jobId, DateTimeOffset? time, string streamType)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                if (string.IsNullOrWhiteSpace(streamType))
                {
                    streamType = CompilationJobStreamType.Any.ToString();
                }

                var jobStreams = this.automationManagementClient.JobStream.ListByJob(resourceGroupName, automationAccountName, jobId.ToString(), this.GetDscJobStreamFilterString(time, streamType));
                return jobStreams.Select(stream => this.CreateJobStreamFromJobStreamModel(stream, resourceGroupName, automationAccountName, jobId)).ToList();
            }
        }

#endregion

#region node configuration
        public Model.NodeConfiguration TryGetNodeConfiguration(string resourceGroupName, string automationAccountName, string nodeConfigurationName, string rollupStatus)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                try
                {
                    return GetNodeConfiguration(resourceGroupName, automationAccountName, nodeConfigurationName, rollupStatus);
                }
                catch (ResourceNotFoundException)
                {
                    return null;
                }
            }
        }

        public Model.NodeConfiguration GetNodeConfiguration(string resourceGroupName, string automationAccountName, string nodeConfigurationName, string rollupStatus)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                try
                {
                    var nodeConfiguration = this.automationManagementClient.DscNodeConfiguration.Get(resourceGroupName, automationAccountName, nodeConfigurationName);

                    string computedRollupStatus = GetRollupStatus(resourceGroupName, automationAccountName, nodeConfigurationName);

                    if (string.IsNullOrEmpty(rollupStatus) || (rollupStatus != null && computedRollupStatus.Equals(rollupStatus)))
                    {
                        return new Model.NodeConfiguration(resourceGroupName, automationAccountName, nodeConfiguration, computedRollupStatus);
                    }

                    return null;
                }
                catch (ErrorResponseException ErrorResponseException)
                {
                    if (ErrorResponseException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        throw new ResourceNotFoundException(typeof(NodeConfiguration), string.Format(CultureInfo.CurrentCulture, Resources.NodeConfigurationNotFound, nodeConfigurationName));
                    }

                    throw;
                }
            }
        }

        public IEnumerable<Model.NodeConfiguration> ListNodeConfigurationsByConfigurationName(string resourceGroupName, string automationAccountName, string configurationName, string rollupStatus, ref string nextLink)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Rest.Azure.IPage<AutomationManagement.Models.DscNodeConfiguration> response;

                if (string.IsNullOrEmpty(nextLink))
                {
                    response = this.automationManagementClient.DscNodeConfiguration.ListByAutomationAccount(
                                       resourceGroupName,
                                       automationAccountName,
                                       this.GetNodeConfigurationListFilterString(configurationName));
                }
                else
                {
                    response = this.automationManagementClient.DscNodeConfiguration.ListByAutomationAccountNext(nextLink);
                }

                nextLink = response.NextPageLink;

                var nodeConfigurations = new List<NodeConfiguration>();
                foreach (var nodeConfiguration in response)
                {
                    string computedRollupStatus = GetRollupStatus(resourceGroupName, automationAccountName, nodeConfiguration.Name);

                    if (string.IsNullOrEmpty(rollupStatus) || (rollupStatus != null && computedRollupStatus.Equals(rollupStatus)))
                    {
                        nodeConfigurations.Add(new Model.NodeConfiguration(resourceGroupName, automationAccountName, nodeConfiguration, computedRollupStatus));
                    }
                }

                return nodeConfigurations;
            }
        }

        public IEnumerable<Model.NodeConfiguration> ListNodeConfigurations(string resourceGroupName, string automationAccountName, string rollupStatus, ref string nextLink)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Rest.Azure.IPage<AutomationManagement.Models.DscNodeConfiguration> response;
                if (string.IsNullOrEmpty(nextLink))
                {
                    response = this.automationManagementClient.DscNodeConfiguration.ListByAutomationAccount(
                                        resourceGroupName,
                                        automationAccountName);
                }
                else
                {
                    response = this.automationManagementClient.DscNodeConfiguration.ListByAutomationAccountNext(nextLink);
                }

                nextLink = response.NextPageLink;

                var nodeConfigurations = new List<Model.NodeConfiguration>();
                foreach (var nodeConfiguration in response)
                {
                    string computedRollupStatus = GetRollupStatus(resourceGroupName, automationAccountName, nodeConfiguration.Name);

                    if (string.IsNullOrEmpty(rollupStatus) || (rollupStatus != null && computedRollupStatus.Equals(rollupStatus)))
                    {
                        nodeConfigurations.Add(new Model.NodeConfiguration(resourceGroupName, automationAccountName, nodeConfiguration, computedRollupStatus));
                    }
                }

                return nodeConfigurations.AsEnumerable<Model.NodeConfiguration>();
            }
        }

        public Model.NodeConfiguration CreateNodeConfiguration(
            string resourceGroupName,
            string automationAccountName,
            string sourcePath,
            string configurationName,
            bool incrementNodeConfigurationBuild,
            bool overWrite)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Requires.Argument("ResourceGroupName", resourceGroupName).NotNullOrEmpty();
                Requires.Argument("AutomationAccountName", automationAccountName).NotNullOrEmpty();
                Requires.Argument("SourcePath", sourcePath).NotNullOrEmpty();
                Requires.Argument("configurationName", configurationName).NotNullOrEmpty();

                string fileContent = null;
                string nodeConfigurationName = null;
                string nodeName = null;

                if (File.Exists(Path.GetFullPath(sourcePath)))
                {
                    fileContent = System.IO.File.ReadAllText(sourcePath);
                    nodeName = System.IO.Path.GetFileNameWithoutExtension(sourcePath);
                    nodeConfigurationName = configurationName + "." + nodeName;
                }
                else
                {
                    // file path not valid.
                    throw new FileNotFoundException(
                                        string.Format(
                                            CultureInfo.CurrentCulture,
                                            Resources.ConfigurationSourcePathInvalid));
                }

                // if configuration already exists, ensure overwrite flag is specified
                var configurationModel = this.TryGetConfigurationModel(
                    resourceGroupName,
                    automationAccountName,
                    configurationName);
                if (configurationModel == null)
                {
                    //create empty configuration if its empty
                    this.CreateConfiguration(resourceGroupName, automationAccountName, configurationName, nodeName);
                }

                var nodeConfigurationCreateParameters = new  DscNodeConfigurationCreateOrUpdateParameters()
                {
                    Name = nodeConfigurationName,
                    Source = new Microsoft.Azure.Management.Automation.Models.ContentSource()
                    {
                        // only embeddedContent supported for now
                        Type = Model.ContentSourceType.embeddedContent.ToString(),
                        Value = fileContent
                    },
                    Configuration = new DscConfigurationAssociationProperty()
                    {
                        Name = configurationName
                    }
                };
                nodeConfigurationCreateParameters.IncrementNodeConfigurationBuild = incrementNodeConfigurationBuild;

                var nodeConfiguration =
                    this.automationManagementClient.DscNodeConfiguration.CreateOrUpdate(
                        resourceGroupName,
                        automationAccountName,
                        nodeConfigurationName,
                        nodeConfigurationCreateParameters);


                return new Model.NodeConfiguration(resourceGroupName, automationAccountName, nodeConfiguration, null);
            }
        }

        public void DeleteNodeConfiguration(string resourceGroupName, string automationAccountName, string name, bool ignoreNodeMappings)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            Requires.Argument("NodeConfigurationName", name).NotNull();

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                try
                {
                    if (ignoreNodeMappings)
                    {
                        this.automationManagementClient.DscNodeConfiguration.Delete(resourceGroupName, automationAccountName, name);
                    }
                    else
                    {
                        var nextLink = string.Empty;
                        List<Model.DscNode> nodeList = new List<Model.DscNode>();
                        do
                        {
                            nodeList.AddRange(this.ListDscNodesByNodeConfiguration(resourceGroupName, automationAccountName, name, null, ref nextLink));
                        } while (!string.IsNullOrEmpty(nextLink));
                        
                        if (nodeList.Any())
                        {
                            throw new ResourceCommonException(
                                typeof(Model.NodeConfiguration),
                                string.Format(CultureInfo.CurrentCulture, Resources.CannotDeleteNodeConfiguration, name));
                        }
                        else
                        {
                            this.automationManagementClient.DscNodeConfiguration.Delete(resourceGroupName, automationAccountName, name);
                        }
                    }
                }
                catch (ErrorResponseException ErrorResponseException)
                {
                    if (ErrorResponseException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        throw new ResourceNotFoundException(
                            typeof(Model.NodeConfiguration),
                            string.Format(CultureInfo.CurrentCulture, Resources.NodeConfigurationNotFound, name));
                    }
                    throw;
                }
            }
        }

        public NodeConfigurationDeployment StartNodeConfigurationDeployment(string resourceGroupName, string automationAccountName, 
            string nodeConfiguraionName, string[][] nodeNames, Schedule schedule)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNullOrEmpty().ValidAutomationAccountName();
            Requires.Argument("NodeConfiguraionName", nodeConfiguraionName).NotNullOrEmpty().ValidNodeConfigurationName();

            const string runbookName = "Deploy-NodeConfigurationToAutomationDscNodesV1";

            IDictionary<string, string> processedParameters =
                    this.ProcessRunbookParameters(BuildParametersForNodeConfigurationDeploymentRunbook(),
                        ProcessParametersFornodeConfigurationRunbook(resourceGroupName, automationAccountName,
                            nodeConfiguraionName, nodeNames));

            JobSchedule jobSchedule = null;
            Job job = null;

            if (schedule == null)
            {
                job = this.automationManagementClient.Job.Create(
                    resourceGroupName,
                    automationAccountName,
                    new Guid().ToString(),
                    new JobCreateParameters
                    {
                        Runbook = new RunbookAssociationProperty
                        {
                            Name = runbookName
                        },
                        Parameters = processedParameters ?? null
                    });
            }
            else
            {
                jobSchedule = this.automationManagementClient.JobSchedule.Create(
                    resourceGroupName,
                    automationAccountName, 
                    new Guid(),
                    new JobScheduleCreateParameters
                    {
                        Schedule = new ScheduleAssociationProperty { Name = schedule.Name },
                        Runbook = new RunbookAssociationProperty { Name = runbookName },
                        Parameters = processedParameters ?? null
                    });
            }

            return new NodeConfigurationDeployment(resourceGroupName, automationAccountName, nodeConfiguraionName, job, jobSchedule);
        }

        public NodeConfigurationDeployment GetNodeConfigurationDeployment(string resourceGroupName, string automationAccountName, Guid jobId)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNullOrEmpty().ValidAutomationAccountName();

            var nodeLists = new List<IList<string>>();
            var nodesStatus = new List<IDictionary<string, string>>();
            Job job = null;
            string nodeConfigurationName = null;

            if (jobId != Guid.Empty)
            {
                job = this.automationManagementClient.Job.Get(resourceGroupName, automationAccountName, jobId.ToString());

                nodeConfigurationName = PowerShellJsonConverter
                    .Deserialize(job.Parameters["NodeConfigurationName"]).ToString();

                // Fetch Nodes from the Param List.
                var nodesJsonArray = PowerShellJsonConverter.Serialize(job.Parameters["ListOfNodeNames"]);
                var stringArray =
                    Newtonsoft.Json.Linq.JArray.Parse(JsonConvert.DeserializeObject<string>(nodesJsonArray));

                nodeLists.AddRange(stringArray.Select(jt => jt.Select(node => node.ToString()).ToList()));

                // Fetch the status of each node.
                foreach (var nodeList in nodeLists)
                {
                    IDictionary<string, string> dscNodeGroup = new Dictionary<string, string>();
                    foreach (var node in nodeList)
                    {
                        var nextLink = string.Empty;
                        IEnumerable<Model.DscNode> dscNodes;
                        do
                        {
                            dscNodes = this.ListDscNodesByName(resourceGroupName, automationAccountName, node, null,
                                ref nextLink);
                        } while (!string.IsNullOrEmpty(nextLink));
                        dscNodeGroup.Add(node, dscNodes.First().Status);
                    }
                    nodesStatus.Add(dscNodeGroup);
                }
            }
            else
            {
                throw new ArgumentNullException(nameof(jobId), Resources.NoJobIdPassedToGetJobInformationCall);
            }
            return new NodeConfigurationDeployment(resourceGroupName, automationAccountName, nodeConfigurationName, job, nodesStatus);
        }


        public NodeConfigurationDeploymentSchedule GetNodeConfigurationDeploymentSchedule(string resourceGroupName, string automationAccountName, Guid jobScheduleId)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNullOrEmpty().ValidAutomationAccountName();

            AutomationManagement.Models.JobSchedule jobSchedule = null;

            if (jobScheduleId != Guid.Empty)
            {
                try {
                    jobSchedule = this.automationManagementClient.JobSchedule.Get(
                    resourceGroupName,
                    automationAccountName,
                    jobScheduleId);
                } catch (ErrorResponseException ErrorResponseException)
                {
                    if (ErrorResponseException.Response.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        throw new ResourceNotFoundException(typeof(JobSchedule),
                            string.Format(CultureInfo.CurrentCulture, Resources.JobScheduleWithIdNotFound, jobScheduleId));
                    }

                    throw;
                }
            }
            return new NodeConfigurationDeploymentSchedule(resourceGroupName, automationAccountName, jobSchedule);
        }

        public IEnumerable<NodeConfigurationDeployment> ListNodeConfigurationDeployment(string resourceGroupName, string automationAccountName,
            DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus, ref string nextLink)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNullOrEmpty();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNullOrEmpty().ValidAutomationAccountName();

            Rest.Azure.IPage<AutomationManagement.Models.JobCollectionItem> response;
            // TODO: Fix this cmdlets const string runbookName = "Deploy-NodeConfigurationToAutomationDscNodesV1";

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Job.ListByAutomationAccount(
                    resourceGroupName,
                    automationAccountName,
                    this.GetDscJobFilterString(null, startTime, endTime, jobStatus));
            }
            else
            {
                response = this.automationManagementClient.Job.ListByAutomationAccountNext(nextLink);
            }

            nextLink = response.NextPageLink;
            return response.Select(c => new NodeConfigurationDeployment(resourceGroupName, automationAccountName, null, c));
        }

        public IEnumerable<NodeConfigurationDeploymentSchedule> ListNodeConfigurationDeploymentSchedules(string resourceGroupName, string automationAccountName, ref string nextLink)
        {
            const string runbookName = "Deploy-NodeConfigurationToAutomationDscNodesV1";

            var response = string.IsNullOrEmpty(nextLink) ? this.automationManagementClient.JobSchedule.ListByAutomationAccount(resourceGroupName, automationAccountName) : this.automationManagementClient.JobSchedule.ListByAutomationAccountNext(nextLink);

            nextLink = response.NextPageLink;

            return response.Where(js => string.Equals(js.Runbook.Name, runbookName, StringComparison.OrdinalIgnoreCase)).
                Select(js => new NodeConfigurationDeploymentSchedule(resourceGroupName, automationAccountName, js));
        }

        public void StopNodeConfigurationDeployment(string resourceGroupName, string automationAccountName, Guid jobId)
        {
            this.StopJob(resourceGroupName, automationAccountName, jobId);
        }

#endregion

#region dsc reports
        public Model.DscNodeReport GetDscNodeReportByReportId(string resourceGroupName, string automationAccountName, Guid nodeId, Guid reportId)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            Requires.Argument("NodeId", nodeId).NotNull();
            Requires.Argument("ReportId", reportId).NotNull();

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var nodeReport =
                    this.automationManagementClient.NodeReports.Get(
                        resourceGroupName,
                        automationAccountName,
                        nodeId.ToString(),
                        reportId.ToString());

                return new Model.DscNodeReport(resourceGroupName, automationAccountName, nodeId.ToString("D"), nodeReport);
            }
        }

        public DirectoryInfo GetDscNodeReportContent(string resourceGroupName, string automationAccountName, Guid nodeId, Guid reportId, string outputFolder, bool overwriteExistingFile)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            Requires.Argument("NodeId", nodeId).NotNull();
            Requires.Argument("ReportId", reportId).NotNull();

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var nodeReportContent =
                    this.automationManagementClient.NodeReports.GetContent(
                        resourceGroupName,
                        automationAccountName,
                        nodeId.ToString(),
                        reportId.ToString());

                string outputFolderFullPath = this.GetCurrentDirectory();

                if (!string.IsNullOrEmpty(outputFolder))
                {
                    outputFolderFullPath = this.ValidateAndGetFullPath(outputFolder);
                }

                const string FileExtension = ".txt";

                var outputFilePath = outputFolderFullPath + "\\" + nodeId + "_" + reportId + FileExtension;

                // file exists and overwrite Not specified
                if (File.Exists(outputFilePath) && !overwriteExistingFile)
                {
                    throw new ArgumentException(
                            string.Format(CultureInfo.CurrentCulture, Resources.NodeReportAlreadyExists, outputFilePath));
                }

                // Write to the file
                // TODO: Change the GetContent to string
                this.WriteFile(outputFilePath, null);

                return new DirectoryInfo(outputFilePath);
            }
        }

        public Model.DscNodeReport GetLatestDscNodeReport(string resourceGroupName, string automationAccountName, Guid nodeId)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            Requires.Argument("NodeId", nodeId).NotNull();

            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var nodeReport =
                    this.automationManagementClient.NodeReports.ListByNode(
                        resourceGroupName,
                        automationAccountName, nodeId.ToString(), null
                        ).OrderByDescending(report => report.StartTime).FirstOrDefault();

                return new Model.DscNodeReport(resourceGroupName, automationAccountName, nodeId.ToString("D"), nodeReport);
            }
        }

        public IEnumerable<Model.DscNodeReport> ListDscNodeReports(string resourceGroupName, string automationAccountName, Guid nodeId, DateTimeOffset? startTime, DateTimeOffset? endTime, ref string nextLink)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                Rest.Azure.IPage<AutomationManagement.Models.DscNodeReport> response;

                if (string.IsNullOrEmpty(nextLink))
                {
                    response = this.automationManagementClient.NodeReports.ListByNode(
                                        resourceGroupName,
                                        automationAccountName,
                                        nodeId.ToString(),
                                        this.GetNodeReportListFilterString(null, startTime, endTime, null));
                }
                else
                {
                    response = this.automationManagementClient.NodeReports.ListByNodeNext(nextLink);
                }

                nextLink = response.NextPageLink;

                return response.Select(report => new Commands.Automation.Model.DscNodeReport(resourceGroupName, automationAccountName, nodeId.ToString("D"), report));
            }
        }
#endregion


#region privatemethods
        
        private string GetRollupStatus(string resourceGroupName, string automationAccountName, string nodeConfigurationName)
        {
            var nextLink = string.Empty;
            List<Model.DscNode> nodes = new List<Model.DscNode>();
            do
            {
                nodes.AddRange(this.ListDscNodesByNodeConfiguration(resourceGroupName, automationAccountName, nodeConfigurationName, null, ref nextLink));
            } while (!string.IsNullOrEmpty(nextLink));
            
            foreach (var node in nodes)
            {
                if (node.Status.Equals("Not Compliant") || node.Status.Equals("Failed") || node.Status.Equals("Unresponsive"))
                {
                    return "Bad";
                }
            }

            return "Good";
        }

        private string FormatDateTime(DateTimeOffset dateTime)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:O}", dateTime.DateTime.ToUniversalTime());
        }

        private IDictionary<string, string> ProcessConfigurationParameters(IDictionary parameters, IDictionary configurationData)
        {
            parameters = parameters ?? new Dictionary<string, string>();
            var filteredParameters = new Dictionary<string, string>();
            if (configurationData != null)
            {
                filteredParameters.Add("ConfigurationData", JsonConvert.SerializeObject(configurationData));
            }
            foreach (var key in parameters.Keys)
            {
                try
                {
                    filteredParameters.Add(key.ToString(), JsonConvert.SerializeObject(parameters[key]));
                }
                catch (JsonSerializationException)
                {
                    throw new ArgumentException(string.Format(
                        CultureInfo.CurrentCulture, Resources.ConfigurationParameterCannotBeSerializedToJson, key.ToString()));
                }
            }
            return filteredParameters;
        }

        private IEnumerable<KeyValuePair<string, DscConfigurationParameter>> ListConfigurationParameters(string resourceGroupName, string automationAccountName, string configurationName)
        {
            Model.DscConfiguration configuration = this.GetConfiguration(resourceGroupName, automationAccountName, configurationName);
            if (configuration == null || 0 == String.Compare(configuration.State, RunbookState.New, CultureInfo.InvariantCulture,
                     CompareOptions.IgnoreCase))
            {
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.ConfigurationHasNoPublishedVersion, configurationName));
            }
            return configuration.Parameters.Cast<DictionaryEntry>().ToDictionary(k => k.Key.ToString(), k => (DscConfigurationParameter)k.Value);
        }

        private Model.JobStream CreateJobStreamFromJobStreamModel(AutomationManagement.Models.JobStream jobStream, string resourceGroupName, string automationAccountName, Guid jobId)
        {
            Requires.Argument("jobStream", jobStream).NotNull();
            Requires.Argument("resourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("automationAccountName", automationAccountName).NotNull();
            Requires.Argument("jobId", jobId).NotNull();
            return new Model.JobStream(jobStream, resourceGroupName, automationAccountName, jobId);
        }

        private IDictionary<string, object> ProcessParametersFornodeConfigurationRunbook(string resourceGroup,
            string automationAccountName, string nodeConfigurationName, string[][] nodeNames, int waitingPeriod = 0,
            int numberOfAttempts = 0)
        {
            var parameters = new Dictionary<string, object>();

            try
            {
                parameters.Add("ResourceGroupName", resourceGroup);
                parameters.Add("AutomationAccountName", automationAccountName);
                parameters.Add("NodeConfigurationName", nodeConfigurationName);
                parameters.Add("ListOfNodeNames", nodeNames);
            }
            catch (JsonSerializationException)
            {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.CurrentCulture, Resources.RunbookParameterCannotBeSerializedToJson, nodeNames));
            }

            if (waitingPeriod != 0)
            {
                parameters.Add("WaitingPeriod", waitingPeriod.ToString());
            }
            if (numberOfAttempts != 0)
            {
                parameters.Add("NumberOfTriesPerGroup", numberOfAttempts.ToString());
            }

            return parameters;
        }

        private IEnumerable<KeyValuePair<string, RunbookParameter>> BuildParametersForNodeConfigurationDeploymentRunbook
            ()
        {
            var paramsForRunbook = new List<KeyValuePair<string, RunbookParameter>>
            {
                new KeyValuePair<string, RunbookParameter>("ResourceGroupName", new RunbookParameter
                {
                    IsMandatory = true,
                    Position = 0,
                    DefaultValue = "",
                    Type = "System.String"
                }),
                new KeyValuePair<string, RunbookParameter>("AutomationAccountName", new RunbookParameter
                {
                    IsMandatory = true,
                    Position = 1,
                    DefaultValue = "",
                    Type = "System.String"
                }),
                new KeyValuePair<string, RunbookParameter>("NodeConfigurationName", new RunbookParameter
                {
                    IsMandatory = true,
                    Position = 2,
                    DefaultValue = "",
                    Type = "System.String"
                }),
                new KeyValuePair<string, RunbookParameter>("ListOfNodeNames", new RunbookParameter
                {
                    IsMandatory = true,
                    Position = 3,
                    Type = "System.Array"
                }),
                new KeyValuePair<string, RunbookParameter>("WaitingPeriod", new RunbookParameter
                {
                    IsMandatory = false,
                    Position = 4,
                    DefaultValue = "60",
                    Type = "System.Int32"
                }),
                new KeyValuePair<string, RunbookParameter>("NumberOfTriesPerGroup", new RunbookParameter
                {
                    IsMandatory = false,
                    Position = 5,
                    DefaultValue = "100",
                    Type = "System.Int32"
                })
            };

            return paramsForRunbook;
        }

        private string GetDscJobFilterString(string configurationName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus)
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
            if (!string.IsNullOrWhiteSpace(configurationName))
            {
                odataFilter.Add("properties/configuration/name eq '" + Uri.EscapeDataString(configurationName) + "'");
            }
            if (odataFilter.Count > 0)
            {
                filter = string.Join(" and ", odataFilter);
            }

            return filter;
        }

        private string GetDscJobStreamFilterString(DateTimeOffset? time, string streamType)
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

        private string GetNodeListFilterString(string status, string nodeConfigurationName)
        {
            var filter = new ODataQuery<DscNodeConfiguration>(node => node.Name == nodeConfigurationName)
            {
                Top = 20,
                Skip = 0
            };

            return filter.ToString();
        }

        private string GetNodeReportListFilterString(string type, DateTimeOffset? startTime, DateTimeOffset? endTime, DateTimeOffset? lastModifiedTime)
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
            if (string.IsNullOrWhiteSpace(type))
            {
                odataFilter.Add("properties/type eq '" + Uri.EscapeDataString(type) + "'");
            }
            if (lastModifiedTime.HasValue)
            {
                odataFilter.Add("properties/lastModifiedTime ge " + this.FormatDateTime(startTime.Value));
            }
            if (odataFilter.Count > 0)
            {
                filter = string.Join(" and ", odataFilter);
            }

            return filter;
        }

        private string GetNodeConfigurationListFilterString(string configurationName)
        {
            string filter = null;
            List<string> odataFilter = new List<string>();
            if (!string.IsNullOrWhiteSpace(configurationName))
            {
                odataFilter.Add("properties/configuration/name eq " + Uri.EscapeDataString(configurationName) + "'");
            }
            if (odataFilter.Count > 0)
            {
                filter = string.Join(" and ", odataFilter);
            }

            return filter;
        }

        #endregion
    }

    internal class ParametersObj
    {
        [JsonProperty("vmName")]
        public TemplateParameters VmName { get; set; }

        [JsonProperty("location")]
        public TemplateParameters Location { get; set; }

        [JsonProperty("modulesUrl")]
        public TemplateParameters ModulesUrl { get; set; }

        [JsonProperty("configurationFunction")]
        public TemplateParameters ConfigurationFunction { get; set; }

        [JsonProperty("registrationKey")]
        public TemplateParameters RegistrationKey { get; set; }

        [JsonProperty("registrationUrl")]
        public TemplateParameters RegistrationUrl { get; set; }

        [JsonProperty("nodeConfigurationName")]
        public TemplateParameters NodeConfigurationName { get; set; }

        [JsonProperty("configurationMode")]
        public TemplateParameters ConfigurationMode { get; set; }

        [JsonProperty("configurationModeFrequencyMins")]
        public TemplateParameters ConfigurationModeFrequencyMins { get; set; }

        [JsonProperty("refreshFrequencyMins")]
        public TemplateParameters RefreshFrequencyMins { get; set; }

        [JsonProperty("rebootNodeIfNeeded")]
        public TemplateParameters RebootNodeIfNeeded { get; set; }

        [JsonProperty("actionAfterReboot")]
        public TemplateParameters ActionAfterReboot { get; set; }

        [JsonProperty("allowModuleOverwrite")]
        public TemplateParameters AllowModuleOverwrite { get; set; }

        [JsonProperty("timestamp")]
        public TemplateParameters Timestamp { get; set; }
    }

    internal class TemplateParameters
    {
        [JsonProperty("value")]
        public object Value { get; set; }
    }
}
