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
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Security;
using Microsoft.Azure.Commands.Automation.Model;
using Microsoft.Azure.Common.Authentication.Models;

namespace Microsoft.Azure.Commands.Automation.Common
{
    public interface IAutomationClient
    {
        AzureSubscription Subscription { get; }

        #region Accounts

        IEnumerable<AutomationAccount> ListAutomationAccounts(string resourceGroupName);

        AutomationAccount GetAutomationAccount(string resourceGroupName, string automationAccountName);

        AutomationAccount CreateAutomationAccount(string resourceGroupName, string automationAccountName, string location, string plan, IDictionary tags);

        AutomationAccount UpdateAutomationAccount(string resourceGroupName, string automationAccountName, string plan, IDictionary tags);

        void DeleteAutomationAccount(string resourceGroupName, string automationAccountName);
        
        #endregion

        #region Configurations

        IEnumerable<DscConfiguration> ListDscConfigurations(string resourceGroupName, string automationAccountName);

        DscConfiguration GetConfiguration(string resourceGroupName, string automationAccountName, string configurationName);

        DscConfiguration CreateConfiguration(string resourceGroupName, string automationAccountName, string sourcePath, IDictionary tags, string description, bool? logVerbose, bool published, bool overWrite);

        #endregion

        #region AgentRegistrationInforamtion
        AgentRegistration GetAgentRegistration(string resourceGroupName, string automationAccountName);

        AgentRegistration NewAgentRegistrationKey(string resourceGroupName, string automationAccountName, string keyType);
        #endregion

        #region DscMetaConfiguration
        DirectoryInfo GetDscMetaConfig(string resourceGroupName, string automationAccountName, string outputFolder, string[] computerNames, bool overwriteExistingFile);
        #endregion

        #region DscNode Operations
        
        DscNode GetDscNodeById(string resourceGroupName, string automationAccountName, Guid nodeId);

        IEnumerable<DscNode> ListDscNodes(string resourceGroupName, string automationAccountName, string status);

        IEnumerable<DscNode> ListDscNodesByName(string resourceGroupName, string automationAccountName, string nodeName, string status);
        IEnumerable<DscNode> ListDscNodesByNodeConfiguration(string resourceGroupName, string automationAccountName, string nodeConfigurationName, string status);

        DscNode SetDscNodeById(string resourceGroupName, string automationAccountName, Guid nodeId, string nodeConfigurationName, bool force);

        void DeleteDscNode(string resourceGroupName, string automationAccountName, Guid nodeId);

        #endregion
    }
}