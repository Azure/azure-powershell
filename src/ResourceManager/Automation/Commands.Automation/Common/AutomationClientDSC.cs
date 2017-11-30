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

using Hyak.Common;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using Newtonsoft.Json;
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
using AutomationManagement = Microsoft.Azure.Management.Automation;
using DscNode = Microsoft.Azure.Management.Automation.Models.DscNode;
using Job = Microsoft.Azure.Management.Automation.Models.Job;
using JobSchedule = Microsoft.Azure.Management.Automation.Models.JobSchedule;
using Schedule = Microsoft.Azure.Commands.Automation.Model.Schedule;

namespace Microsoft.Azure.Commands.Automation.Common
{
    public partial class AutomationClient : IAutomationClient
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

                DscConfigurationListResponse response;
                if (string.IsNullOrEmpty(nextLink))
                {
                    response = this.automationManagementClient.Configurations.List(
                                    resourceGroupName,
                                    automationAccountName);
                }
                else
                {
                    response = this.automationManagementClient.Configurations.ListNext(nextLink);
                }
                    
                
                nextLink = response.NextLink;
                return response.Configurations.Select(configuration => new Model.DscConfiguration(resourceGroupName, automationAccountName, configuration));
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
                            this.automationManagementClient.Configurations.Get(
                                resourceGroupName,
                                automationAccountName,
                                configurationName).Configuration;

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
                    var configuration = this.automationManagementClient.Configurations.GetContent(resourceGroupName, automationAccountName, configurationName);
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
                    this.WriteFile(outputFilePath, configuration.Content);

                    return new DirectoryInfo(configurationName + FileExtension);
                }
                catch (CloudException cloudException)
                {
                    if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
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

                try
                {
                    if (File.Exists(Path.GetFullPath(sourcePath)))
                    {
                        fileContent = System.IO.File.ReadAllText(sourcePath);
                    }
                }
                catch (Exception)
                {
                    // exception in accessing the file path
                    throw new FileNotFoundException(
                                        string.Format(
                                            CultureInfo.CurrentCulture,
                                            Resources.ConfigurationSourcePathInvalid));
                }

                // configuration name is same as filename
                configurationName = Path.GetFileNameWithoutExtension(sourcePath);

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
                    Properties = new DscConfigurationCreateOrUpdateProperties()
                    {
                        Description = String.IsNullOrEmpty(description) ? String.Empty : description,
                        LogVerbose = (logVerbose.HasValue) ? logVerbose.Value : false,
                        Source = new Microsoft.Azure.Management.Automation.Models.ContentSource()
                        {
                            // only embeddedContent supported for now
                            ContentType = Model.ContentSourceType.embeddedContent.ToString(),
                            Value = fileContent
                        }
                    }
                };

                var configuration =
                    this.automationManagementClient.Configurations.CreateOrUpdate(
                        resourceGroupName,
                        automationAccountName,
                        configurationCreateParameters).Configuration;

                return new Model.DscConfiguration(resourceGroupName, automationAccountName, configuration);
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
            catch (CloudException e)
            {
                if (e.Response.StatusCode == HttpStatusCode.NotFound)
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
                    Properties = new DscConfigurationCreateOrUpdateProperties()
                    {
                        Description = String.Empty,
                        LogVerbose = false,
                        Source = new Microsoft.Azure.Management.Automation.Models.ContentSource()
                        {
                            // only embeddedContent supported for now
                            ContentType = Model.ContentSourceType.embeddedContent.ToString(),
                            Value = configurationContent
                        }
                    }
                };

                var configuration =
                    this.automationManagementClient.Configurations.CreateOrUpdate(
                        resourceGroupName,
                        automationAccountName,
                        configurationCreateParameters).Configuration;

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
                    this.automationManagementClient.Configurations.Delete(resourceGroupName, automationAccountName, name);
                }
                catch (CloudException cloudException)
                {
                    if (cloudException.Response.StatusCode == HttpStatusCode.NoContent)
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
                    automationAccountName).AgentRegistration;

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
                    automationAccountName).AgentRegistration;

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
                    keyName).AgentRegistration;

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
                                this.automationManagementClient.Nodes.Get(
                                    resourceGroupName,
                                    automationAccountName,
                                    nodeId).Node;

                    return new Model.DscNode(resourceGroupName, automationAccountName, node);
                }
                catch (CloudException cloudException)
                {
                    if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
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

                DscNodeListResponse response;
                if (string.IsNullOrEmpty(nextLink))
                {
                    if (!string.IsNullOrEmpty(status))
                    {
                        response = this.automationManagementClient.Nodes.List(
                                    resourceGroupName,
                                    automationAccountName,
                                    new DscNodeListParameters { Status = status, Name = nodeName });
                    }
                    else
                    {
                        response = this.automationManagementClient.Nodes.List(
                                    resourceGroupName,
                                    automationAccountName,
                                    new DscNodeListParameters { Name = nodeName });
                    }
                }
                else
                {
                    response = this.automationManagementClient.Nodes.ListNext(nextLink);
                }

                nextLink = response.NextLink;

                return response.Nodes.Select(dscNode => new Model.DscNode(resourceGroupName, automationAccountName, dscNode));
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

                DscNodeListResponse response;
                if (string.IsNullOrEmpty(nextLink))
                {
                    if (!string.IsNullOrEmpty(status))
                    {
                        response = this.automationManagementClient.Nodes.List(
                                            resourceGroupName,
                                            automationAccountName,
                                            new DscNodeListParameters
                                            {
                                                Status = status,
                                                NodeConfigurationName = nodeConfigurationName
                                            });
                    }
                    else
                    {
                        response = this.automationManagementClient.Nodes.List(
                                            resourceGroupName,
                                            automationAccountName,
                                            new DscNodeListParameters { NodeConfigurationName = nodeConfigurationName });
                    }
                }
                else
                {
                    response = this.automationManagementClient.Nodes.ListNext(nextLink);
                }
                nextLink = response.NextLink;
                
                return response.Nodes.Select(dscNode => new Model.DscNode(resourceGroupName, automationAccountName, dscNode));
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
                IEnumerable<Model.NodeConfiguration> listOfNodeConfigurations = this.EnumerateNodeConfigurationsByConfigurationName(
                    resourceGroupName,
                    automationAccountName,
                    configurationName);

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

                DscNodeListResponse response;
                
                if (string.IsNullOrEmpty(nextLink))
                {
                    if (!string.IsNullOrEmpty(status))
                    {
                        response = this.automationManagementClient.Nodes.List(
                            resourceGroupName,
                            automationAccountName,
                            new DscNodeListParameters { Status = status });
                    }
                    else
                    {
                        response = this.automationManagementClient.Nodes.List(
                                resourceGroupName,
                                automationAccountName,
                                new DscNodeListParameters { });
                    }
                }
                else
                {
                    response = this.automationManagementClient.Nodes.ListNext(nextLink);
                }

                nextLink = response.NextLink;
                
                return response.Nodes.Select(dscNode => new Model.DscNode(resourceGroupName, automationAccountName, dscNode));
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
                    var getNode = this.automationManagementClient.Nodes.Get(
                            resourceGroupName,
                            automationAccountName,
                            nodeId).Node;
                }
                catch (CloudException cloudException)
                {
                    if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.NodeNotFound), cloudException);
                    }

                    throw;
                }

                // ***
                // Note: No need to check if an existing configuration is already assigned. The confirmation is obtained when the cmdlet is executed
                // *** 

                var nodeConfiguration = new DscNodeConfigurationAssociationProperty { Name = nodeConfigurationName };

                var node =
                    this.automationManagementClient.Nodes.Patch(
                        resourceGroupName,
                        automationAccountName,
                        new DscNodePatchParameters
                        {
                            NodeId = nodeId,
                            NodeConfiguration = nodeConfiguration
                        }).Node;

                return new Model.DscNode(resourceGroupName, automationAccountName, node);
            }
        }

        public void DeleteDscNode(string resourceGroupName, string automationAccountName, Guid nodeId)
        {
            try
            {
                using (var request = new RequestSettings(this.automationManagementClient))
                {
                    this.automationManagementClient.Nodes.Delete(
                        resourceGroupName,
                        automationAccountName,
                        nodeId);
                }
            }
            catch (CloudException cloudException)
            {
                if (cloudException.Response.StatusCode == HttpStatusCode.NoContent)
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
                                            string azureVmLocation)
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

            string deploymentName = System.DateTimeOffset.Now.LocalDateTime.ToString("yyyyMMddhhmmss");

            // get the endpoint and keys
            Model.AgentRegistration agentRegistrationInfo = this.GetAgentRegistration(
                resourceGroupName,
                automationAccountName);

            // prepare the parameters to be used in New-AzureRmResourceGroupDeployment cmdlet
            Hashtable templateParameters = new Hashtable();
            templateParameters.Add("vmName", azureVMName);
            templateParameters.Add("location", location);
            templateParameters.Add("modulesUrl", Constants.ModulesUrl);
            templateParameters.Add("configurationFunction", Constants.ConfigurationFunction);
            templateParameters.Add("registrationUrl", agentRegistrationInfo.Endpoint);
            templateParameters.Add("registrationKey", agentRegistrationInfo.PrimaryKey);
            templateParameters.Add("nodeConfigurationName", nodeconfigurationName);
            templateParameters.Add("configurationMode", configurationMode);
            templateParameters.Add("configurationModeFrequencyMins", configurationModeFrequencyMins);
            templateParameters.Add("refreshFrequencyMins", refreshFrequencyMins);
            templateParameters.Add("rebootNodeIfNeeded", rebootFlag);
            templateParameters.Add("actionAfterReboot", actionAfterReboot);
            templateParameters.Add("allowModuleOverwrite", moduleOverwriteFlag);
            templateParameters.Add("timestamp", DateTimeOffset.UtcNow.ToString("o"));

            // invoke the New-AzureRmResourceGroupDeployment cmdlet
            using (Pipeline pipe = Runspace.DefaultRunspace.CreateNestedPipeline())
            {
                Command invokeCommand = new Command("New-AzureRmResourceGroupDeployment");
                invokeCommand.Parameters.Add("Name", deploymentName);
                invokeCommand.Parameters.Add("ResourceGroupName", azureVmResourceGroup);
                invokeCommand.Parameters.Add("TemplateParameterObject", templateParameters);
                invokeCommand.Parameters.Add("TemplateFile", Constants.TemplateFile);

                pipe.Commands.Add(invokeCommand);

                pipe.Commands.Add("Out-Default");

                Collection<PSObject> results = pipe.Invoke();
            }
        }

        #endregion

        #region compilationjob

        public Model.CompilationJob GetCompilationJob(string resourceGroupName, string automationAccountName, Guid Id)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                try
                {
                    var job = this.automationManagementClient.CompilationJobs.Get(resourceGroupName, automationAccountName, Id).DscCompilationJob;
                    if (job == null)
                    {
                        throw new ResourceNotFoundException(typeof(DscCompilationJob),
                            string.Format(CultureInfo.CurrentCulture, Resources.CompilationJobNotFound, Id));
                    }

                    return new Model.CompilationJob(resourceGroupName, automationAccountName, job);
                }
                catch (CloudException cloudException)
                {
                    if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
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
                DscCompilationJobListResponse response;

                if(string.IsNullOrEmpty(nextLink))
                { 
                    if (startTime.HasValue && endTime.HasValue)
                    {
                        response = this.automationManagementClient.CompilationJobs.List(
                                        resourceGroupName,
                                        automationAccountName,
                                        new AutomationManagement.Models.DscCompilationJobListParameters
                                        {
                                            StartTime = FormatDateTime(startTime.Value),
                                            EndTime = FormatDateTime(endTime.Value),
                                            ConfigurationName = configurationName,
                                            Status = jobStatus,
                                        });
                    }
                    else if (startTime.HasValue)
                    {
                        response = this.automationManagementClient.CompilationJobs.List(
                                        resourceGroupName,
                                        automationAccountName,
                                        new AutomationManagement.Models.DscCompilationJobListParameters
                                        {
                                            StartTime = FormatDateTime(startTime.Value),
                                            ConfigurationName = configurationName,
                                            Status = jobStatus
                                        });
                    }
                    else if (endTime.HasValue)
                    {
                        response = this.automationManagementClient.CompilationJobs.List(
                                    resourceGroupName,
                                    automationAccountName,
                                    new AutomationManagement.Models.DscCompilationJobListParameters
                                    {
                                        EndTime = FormatDateTime(endTime.Value),
                                        ConfigurationName = configurationName,
                                        Status = jobStatus,
                                    });
                    }
                    else
                    {
                        response = this.automationManagementClient.CompilationJobs.List(
                                    resourceGroupName,
                                    automationAccountName,
                                    new AutomationManagement.Models.DscCompilationJobListParameters
                                    {
                                        Status = jobStatus,
                                        ConfigurationName = configurationName
                                    });
                    }
                }
                else
                {
                    response = this.automationManagementClient.CompilationJobs.ListNext(nextLink);
                }

                nextLink = response.NextLink;

                return response.DscCompilationJobs.Select(jobModel => new Model.CompilationJob(resourceGroupName, automationAccountName, jobModel));
            }
        }

        public IEnumerable<Model.CompilationJob> ListCompilationJobs(string resourceGroupName, string automationAccountName, DateTimeOffset? startTime, DateTimeOffset? endTime, string jobStatus, ref string nextLink)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                DscCompilationJobListResponse response;

                if (string.IsNullOrEmpty(nextLink))
                {
                    if (startTime.HasValue && endTime.HasValue)
                    {
                        response = this.automationManagementClient.CompilationJobs.List(
                                        resourceGroupName,
                                        automationAccountName,
                                        new AutomationManagement.Models.DscCompilationJobListParameters
                                        {
                                            StartTime = FormatDateTime(startTime.Value),
                                            EndTime = FormatDateTime(endTime.Value),
                                            Status = jobStatus,
                                        });

                    }
                    else if (startTime.HasValue)
                    {
                        response = this.automationManagementClient.CompilationJobs.List(
                                           resourceGroupName,
                                           automationAccountName,
                                           new AutomationManagement.Models.DscCompilationJobListParameters
                                           {
                                               StartTime = FormatDateTime(startTime.Value),
                                               Status = jobStatus,
                                           });
                    }
                    else if (endTime.HasValue)
                    {
                        response = this.automationManagementClient.CompilationJobs.List(
                                        resourceGroupName,
                                        automationAccountName,
                                        new AutomationManagement.Models.DscCompilationJobListParameters
                                        {
                                            EndTime = FormatDateTime(endTime.Value),
                                            Status = jobStatus,
                                        });
                    }
                    else
                    {
                        response = this.automationManagementClient.CompilationJobs.List(
                                    resourceGroupName,
                                    automationAccountName,
                                    new AutomationManagement.Models.DscCompilationJobListParameters { Status = jobStatus });
                    }
                }
                else
                {
                    response = this.automationManagementClient.CompilationJobs.ListNext(nextLink);
                }

                nextLink = response.NextLink;

                return response.DscCompilationJobs.Select(jobModel => new Model.CompilationJob(resourceGroupName, automationAccountName, jobModel));
            }
        }

        public CompilationJob StartCompilationJob(string resourceGroupName, string automationAccountName, string configurationName, IDictionary parameters, IDictionary configurationData, bool incrementNodeConfigurationBuild)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var createJobParameters = new DscCompilationJobCreateParameters()
                {
                    Properties = new DscCompilationJobCreateProperties()
                    {
                        Configuration = new DscConfigurationAssociationProperty()
                        {
                            Name = configurationName
                        },
                        Parameters = this.ProcessConfigurationParameters(parameters, configurationData),
                        IncrementNodeConfigurationBuild = incrementNodeConfigurationBuild
                    }
                };

                var job = this.automationManagementClient.CompilationJobs.Create(resourceGroupName, automationAccountName, createJobParameters);

                return new Model.CompilationJob(resourceGroupName, automationAccountName, job.DscCompilationJob);
            }
        }

        public IEnumerable<Model.JobStream> GetDscCompilationJobStream(string resourceGroupName, string automationAccountName, Guid jobId, DateTimeOffset? time, string streamType)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                var listParams = new AutomationManagement.Models.JobStreamListParameters();

                if (time.HasValue)
                {
                    listParams.Time = this.FormatDateTime(time.Value);
                }

                if (streamType != null)
                {
                    listParams.StreamType = streamType;
                }
                else
                {
                    listParams.StreamType = CompilationJobStreamType.Any.ToString();
                }

                var jobStreams = this.automationManagementClient.JobStreams.List(resourceGroupName, automationAccountName, jobId, listParams).JobStreams;
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
                    var nodeConfiguration = this.automationManagementClient.NodeConfigurations.Get(resourceGroupName, automationAccountName, nodeConfigurationName).NodeConfiguration;

                    string computedRollupStatus = GetRollupStatus(resourceGroupName, automationAccountName, nodeConfigurationName);

                    if (string.IsNullOrEmpty(rollupStatus) || (rollupStatus != null && computedRollupStatus.Equals(rollupStatus)))
                    {
                        return new Model.NodeConfiguration(resourceGroupName, automationAccountName, nodeConfiguration, computedRollupStatus);
                    }

                    return null;
                }
                catch (CloudException cloudException)
                {
                    if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
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
                DscNodeConfigurationListResponse response;
                if (string.IsNullOrEmpty(nextLink))
                {
                    response = this.automationManagementClient.NodeConfigurations.List(
                                       resourceGroupName,
                                       automationAccountName,
                                       new AutomationManagement.Models.DscNodeConfigurationListParameters
                                       {
                                           ConfigurationName = configurationName
                                       });
                }
                else
                {
                    response = this.automationManagementClient.NodeConfigurations.ListNext(nextLink);
                }

                nextLink = response.NextLink;

                var nodeConfigurations = new List<Model.NodeConfiguration>();
                foreach (var nodeConfiguration in response.DscNodeConfigurations)
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

        public IEnumerable<Model.NodeConfiguration> ListNodeConfigurations(string resourceGroupName, string automationAccountName, string rollupStatus, ref string nextLink)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                DscNodeConfigurationListResponse response;
                if (string.IsNullOrEmpty(nextLink))
                {
                    response = this.automationManagementClient.NodeConfigurations.List(
                                        resourceGroupName,
                                        automationAccountName,
                                        new AutomationManagement.Models.DscNodeConfigurationListParameters());
                }
                else
                {
                    response = this.automationManagementClient.NodeConfigurations.ListNext(nextLink);
                }

                nextLink = response.NextLink;

                var nodeConfigurations = new List<Model.NodeConfiguration>();
                foreach (var nodeConfiguration in response.DscNodeConfigurations)
                {
                    string computedRollupStatus = GetRollupStatus(resourceGroupName, automationAccountName, nodeConfiguration.Configuration.Name);

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

                var nodeConfigurationCreateParameters = new DscNodeConfigurationCreateOrUpdateParameters()
                {
                    Name = nodeConfigurationName,
                    Source = new Microsoft.Azure.Management.Automation.Models.ContentSource()
                    {
                        // only embeddedContent supported for now
                        ContentType = Model.ContentSourceType.embeddedContent.ToString(),
                        Value = fileContent
                    },
                    Configuration = new DscConfigurationAssociationProperty()
                    {
                        Name = configurationName
                    }
                };
                nodeConfigurationCreateParameters.IncrementNodeConfigurationBuild = incrementNodeConfigurationBuild;

                var nodeConfiguration =
                    this.automationManagementClient.NodeConfigurations.CreateOrUpdate(
                        resourceGroupName,
                        automationAccountName,
                        nodeConfigurationCreateParameters).NodeConfiguration;


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
                        this.automationManagementClient.NodeConfigurations.Delete(resourceGroupName, automationAccountName, name);
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
                            this.automationManagementClient.NodeConfigurations.Delete(resourceGroupName, automationAccountName, name);
                        }
                    }
                }
                catch (CloudException cloudException)
                {
                    if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
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
                job = this.automationManagementClient.Jobs.Create(
                    resourceGroupName,
                    automationAccountName,
                    new JobCreateParameters
                    {
                        Properties = new JobCreateProperties
                        {
                            Runbook = new RunbookAssociationProperty
                            {
                                Name = runbookName
                            },
                            Parameters = processedParameters ?? null
                        }
                    }).Job;
            }
            else
            {
                jobSchedule = this.automationManagementClient.JobSchedules.Create(
                    resourceGroupName,
                    automationAccountName,
                    new JobScheduleCreateParameters
                    {
                        Properties = new JobScheduleCreateProperties
                        {
                            Schedule = new ScheduleAssociationProperty {Name = schedule.Name},
                            Runbook = new RunbookAssociationProperty {Name = runbookName},
                            Parameters = processedParameters ?? null
                        }
                    }).JobSchedule;
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
                job = this.automationManagementClient.Jobs.Get(resourceGroupName, automationAccountName, jobId).Job;

                nodeConfigurationName = PowerShellJsonConverter
                    .Deserialize(job.Properties.Parameters["NodeConfigurationName"]).ToString();

                // Fetch Nodes from the Param List.
                var nodesJsonArray = PowerShellJsonConverter.Serialize(job.Properties.Parameters["ListOfNodeNames"]);
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
                    jobSchedule = this.automationManagementClient.JobSchedules.Get(
                    resourceGroupName,
                    automationAccountName,
                    jobScheduleId).JobSchedule;
                } catch (CloudException cloudException)
                {
                    if (cloudException.Response.StatusCode == HttpStatusCode.NotFound)
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

            JobListResponse response;
            const string runbookName = "Deploy-NodeConfigurationToAutomationDscNodesV1";

            if (string.IsNullOrEmpty(nextLink))
            {
                response = this.automationManagementClient.Jobs.List(
                    resourceGroupName,
                    automationAccountName,
                    new JobListParameters
                    {
                        StartTime = (startTime.HasValue) ? FormatDateTime(startTime.Value) : null,
                        EndTime = (endTime.HasValue) ? FormatDateTime(endTime.Value) : null,
                        RunbookName = runbookName,
                        Status = jobStatus,
                    });
            }
            else
            {
                response = this.automationManagementClient.Jobs.ListNext(nextLink);
            }

            nextLink = response.NextLink;
            return response.Jobs.Select(c => new NodeConfigurationDeployment(resourceGroupName, automationAccountName, null, c));
        }

        public IEnumerable<NodeConfigurationDeploymentSchedule> ListNodeConfigurationDeploymentSchedules(string resourceGroupName, string automationAccountName, ref string nextLink)
        {
            const string runbookName = "Deploy-NodeConfigurationToAutomationDscNodesV1";

            var response = string.IsNullOrEmpty(nextLink) ? this.automationManagementClient.JobSchedules.List(resourceGroupName, automationAccountName) : this.automationManagementClient.JobSchedules.ListNext(nextLink);

            nextLink = response.NextLink;

            return response.JobSchedules.Where(js => string.Equals(js.Properties.Runbook.Name, runbookName, StringComparison.OrdinalIgnoreCase)).
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
                        nodeId,
                        reportId).NodeReport;

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
                        nodeId,
                        reportId).Content;

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
                this.WriteFile(outputFilePath, nodeReportContent);

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
                    this.automationManagementClient.NodeReports.List(
                        resourceGroupName,
                        automationAccountName,
                        new DscNodeReportListParameters { NodeId = nodeId }
                        ).NodeReports.OrderByDescending(report => report.StartTime).FirstOrDefault();

                return new Model.DscNodeReport(resourceGroupName, automationAccountName, nodeId.ToString("D"), nodeReport);
            }
        }

        public IEnumerable<Model.DscNodeReport> ListDscNodeReports(string resourceGroupName, string automationAccountName, Guid nodeId, DateTimeOffset? startTime, DateTimeOffset? endTime, ref string nextLink)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                DscNodeReportListResponse response;

                if (string.IsNullOrEmpty(nextLink))
                {
                    if (startTime.HasValue && endTime.HasValue)
                    {
                        response = this.automationManagementClient.NodeReports.List(
                                        resourceGroupName,
                                        automationAccountName,
                                        new AutomationManagement.Models.DscNodeReportListParameters
                                        {
                                            NodeId = nodeId,
                                            StartTime = FormatDateTime(startTime.Value),
                                            EndTime = FormatDateTime(endTime.Value)
                                        });
                    }
                    else if (startTime.HasValue)
                    {
                        response = this.automationManagementClient.NodeReports.List(
                                         resourceGroupName,
                                         automationAccountName,
                                         new AutomationManagement.Models.DscNodeReportListParameters
                                         {
                                             NodeId = nodeId,
                                             StartTime = FormatDateTime(startTime.Value)
                                         });
                    }
                    else if (endTime.HasValue)
                    {
                        response = this.automationManagementClient.NodeReports.List(
                            resourceGroupName,
                            automationAccountName,
                            new AutomationManagement.Models.DscNodeReportListParameters
                            {
                                NodeId = nodeId,
                                EndTime = FormatDateTime(endTime.Value)
                            });
                    }
                    else
                    {
                        response = this.automationManagementClient.NodeReports.List(
                            resourceGroupName,
                            automationAccountName,
                            new AutomationManagement.Models.DscNodeReportListParameters
                            {
                                NodeId = nodeId
                            });
                    }
                }
                else
                {
                    response = this.automationManagementClient.NodeReports.ListNext(nextLink);
                }

                nextLink = response.NextLink;

                return response.NodeReports.Select(report => new Commands.Automation.Model.DscNodeReport(resourceGroupName, automationAccountName, nodeId.ToString("D"), report));
            }
        }
        #endregion 


        #region privatemethods
        
        /// <summary>
        /// Enumerate the list of NodeConfigurations for given configuration - without any rollup status
        /// </summary>
        /// <param name="resourceGroupName">Resource group name</param>
        /// <param name="automationAccountName">Automation account</param>
        /// <param name="configurationName">Name of configuration</param>
        /// <returns>List of NodeConfigurations</returns>
        private IEnumerable<Model.NodeConfiguration> EnumerateNodeConfigurationsByConfigurationName(string resourceGroupName, string automationAccountName, string configurationName)
        {
            using (var request = new RequestSettings(this.automationManagementClient))
            {
                IEnumerable<AutomationManagement.Models.DscNodeConfiguration> nodeConfigModels;

                nodeConfigModels = AutomationManagementClient.ContinuationTokenHandler(
                    skipToken =>
                    {
                        var response = this.automationManagementClient.NodeConfigurations.List(
                            resourceGroupName,
                            automationAccountName,
                            new AutomationManagement.Models.DscNodeConfigurationListParameters
                            {
                                ConfigurationName = configurationName
                            });
                        return new ResponseWithSkipToken<AutomationManagement.Models.DscNodeConfiguration>(response, response.DscNodeConfigurations);
                    });

                return nodeConfigModels.Select(nodeConfigModel => new Commands.Automation.Model.NodeConfiguration(resourceGroupName, automationAccountName, nodeConfigModel, null));
            }
        }

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
            return string.Format(CultureInfo.InvariantCulture, "{0:O}", dateTime.ToUniversalTime());
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

        #endregion
    }
}
