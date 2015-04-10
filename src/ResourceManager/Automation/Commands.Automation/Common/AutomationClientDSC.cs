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
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Net;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Azure.Commands.Automation.Properties;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Management.Automation;
using Microsoft.Azure.Management.Automation.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.Azure.Common.Authentication.Models;
using Newtonsoft.Json;

using AutomationAccount = Microsoft.Azure.Commands.Automation.Model.AutomationAccount;


namespace Microsoft.Azure.Commands.Automation.Common
{
    using Microsoft.Azure.Management.Resources.Models;

    using AutomationManagement = Azure.Management.Automation;
    using Microsoft.Azure.Common.Authentication;
    using Hyak.Common;


    public partial class AutomationClient : IAutomationClient
    {
        #region DscConfiguration Operations

        public IEnumerable<Model.DscConfiguration> ListAutomationConfigurations(
            string resourceGroupName,
            string automationAccountName)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();

            // todo fix paging
            return AutomationManagementClient.ContinuationTokenHandler(
                skipToken =>
                    {
                        var response = this.automationManagementClient.Configurations.List(
                            resourceGroupName,
                            automationAccountName);
                        return new ResponseWithSkipToken<AutomationManagement.Models.DscConfiguration>(
                            response,
                            response.Configurations);
                    }).Select(c => new Model.DscConfiguration(resourceGroupName, automationAccountName, c));
        }

        public Model.DscConfiguration GetConfiguration(
            string resourceGroupName,
            string automationAccountName,
            string configurationName)
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

        public Model.DscConfiguration CreateConfiguration(
            string resourceGroupName,
            string automationAccountName,
            string configurationName,
            string sourcePath,
            IDictionary tags, 
            string description,
            bool logVerbose,
            bool logProgress,
            bool published,
            bool overWrite)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            Requires.Argument("ConfigurationName", configurationName).NotNull();
            Requires.Argument("SourcePath", sourcePath).NotNull();

            // for the private preivew, configuration can be imported in Published mode only
            // Draft mode is not implemented
            if (!published)
            {
                throw new NotImplementedException(
                                    string.Format(
                                        CultureInfo.CurrentCulture,
                                        Resources.ConfigurationNotPublished));
            }

            // if configuration already exists, ensure overwrite flag is specified
            if (this.TryGetConfigurationModel(resourceGroupName, automationAccountName, configurationName) != null)
            {
                if (!overWrite)
                {
                    throw new ResourceCommonException(typeof(Model.DscConfiguration),
                        string.Format(CultureInfo.CurrentCulture, Resources.ConfigurationAlreadyExists, configurationName));
                }
            }

            string fileContent = null;

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
                                                                    LogVerbose = logVerbose,
                                                                    LogProgress = logProgress,
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

    #endregion

        #region AgentRegistration Operations
        public Model.AgentRegistration GetAgentRegistration(string resourceGroupName, string automationAccountName)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
        
            var agentRegistration = this.automationManagementClient.AgentRegistrationInformation.Get(
                resourceGroupName,
                automationAccountName).AgentRegistration;

            return new Model.AgentRegistration(resourceGroupName, automationAccountName, agentRegistration);
        }

        public Model.AgentRegistration NewAgentRegistrationKey(
            string resourceGroupName,
            string automationAccountName,
            string keyType)
        {
            Requires.Argument("ResourceGroupName", resourceGroupName).NotNull();
            Requires.Argument("AutomationAccountName", automationAccountName).NotNull();
            Requires.Argument("KeyType", keyType).NotNull();

            AgentRegistrationRegenerateKeyParameter keyName = new AgentRegistrationRegenerateKeyParameter() { KeyName = keyType};

            var agentRegistration = this.automationManagementClient.AgentRegistrationInformation.RegenerateKey(
                resourceGroupName,
                automationAccountName,
                keyName).AgentRegistration;

            return new Model.AgentRegistration(resourceGroupName, automationAccountName, agentRegistration);
        }
        #endregion
    }
}