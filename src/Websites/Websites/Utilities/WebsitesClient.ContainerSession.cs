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
//
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text.RegularExpressions;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Management.WebSites.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;

namespace Microsoft.Azure.Commands.WebApps.Utilities
{
    public partial class WebsitesClient
    {
        public void RunWebAppContainerPSSessionScript(
            PSCmdlet cmdlet,
            string resourceGroupName,
            string webSiteName,
            string slotName = null,
            bool newPSSession = false)
        {
            string operatingSystem = GetPsOperatingSystem(cmdlet);
            var minimumVersion = new Version(6, 1, 0, 0);

            WriteVerbose("Operating System: {0}", operatingSystem);

            if (operatingSystem.IndexOf(
                    "windows",
                    StringComparison.InvariantCultureIgnoreCase) == -1)
            {
                List<Version> compatibleVersions = GetPsCompatibleVersions(cmdlet);
                foreach (Version version in compatibleVersions)
                {
                    WriteVerbose("Compatible version: {0}", version);
                }

                if (!compatibleVersions.Any(
                        version => version.CompareTo(minimumVersion) > 0))
                {
                    WriteError(
                        Properties.Resources
                            .EnterContainerPSSessionPSCoreVersionNotSupported);
                    return;
                }
            }

            if (operatingSystem.IndexOf(
                    "windows",
                    StringComparison.InvariantCultureIgnoreCase) > 0)
            {
                bool isBasicAuthEnabled = ExecuteScriptAndGetVariableAsBool(
                    cmdlet,
                    "${0} = (Get-Item WSMAN:\\LocalHost\\Client\\Auth\\Basic " +
                    "-ErrorAction SilentlyContinue).Value",
                    false);
                if (!isBasicAuthEnabled)
                {
                    WriteWarning(
                        Properties.Resources
                            .EnterCotnainerPSSessionBasicAuthWarning);
                    return;
                }

                const string defaultTrustedHostsScriptResult =
                    "<empty or non-existent>";
                string trustedHostsScriptResult = ExecuteScriptAndGetVariable(
                    cmdlet,
                    "${0} = (Get-Item WSMAN:\\LocalHost\\Client\\TrustedHosts " +
                    "-ErrorAction SilentlyContinue).Value",
                    defaultTrustedHostsScriptResult);
                string siteHostName = string.IsNullOrWhiteSpace(slotName)
                    ? webSiteName
                    : webSiteName + "-" + slotName;
                var expression = new Regex(
                    @"^\*$|((^\*|^" + siteHostName + @").azurewebsites.net)");

                if (!trustedHostsScriptResult
                        .Split(',')
                        .Any(host => expression.IsMatch(host)))
                {
                    WriteWarning(
                        string.Format(
                            Properties.Resources
                                .EnterContainerPSSessionFormatForTrustedHostsWarning,
                            string.IsNullOrWhiteSpace(trustedHostsScriptResult)
                                ? defaultTrustedHostsScriptResult
                                : trustedHostsScriptResult) +
                        Environment.NewLine +
                        Environment.NewLine +
                        string.Format(
                            Properties.Resources
                                .EnterContainerPSSessionFormatForTrustedHostsSuggestion,
                            string.IsNullOrWhiteSpace(trustedHostsScriptResult)
                                ? string.Empty
                                : trustedHostsScriptResult + ",",
                            siteHostName));
                    return;
                }
            }

            Site site = GetWebApp(
                resourceGroupName,
                webSiteName,
                slotName);
            User user = GetPublishingCredentials(
                resourceGroupName,
                webSiteName,
                slotName);
            const string variablePrefix = "webAppPSSession";
            string publishingUserName = user.PublishingUserName.Length <= 20
                ? user.PublishingUserName
                : user.PublishingUserName.Substring(0, 20);

            string script = string.Format(
                "${3}User = '{0}' \n" +
                "${3}Password = ConvertTo-SecureString -String '{1}' " +
                "-AsPlainText -Force \n" +
                "${3}Credential = New-Object -TypeName PSCredential " +
                "-ArgumentList ${3}User, ${3}Password\n" +
                (newPSSession
                    ? "${3}NewPsSession = New-PSSession"
                    : "Enter-PSSession") +
                " -ConnectionUri https://{2}/WSMAN -Authentication Basic " +
                "-Credential ${3}Credential \n",
                publishingUserName,
                user.PublishingPassword,
                site.DefaultHostName,
                variablePrefix);

            cmdlet.ExecuteScript<object>(script);
            if (newPSSession)
            {
                cmdlet.WriteObject(
                    cmdlet.GetVariableValue(variablePrefix + "NewPsSession"));
            }
            cmdlet.ExecuteScript<object>($"Clear-Variable {variablePrefix}*");
        }

        private static string GetPsOperatingSystem(PSCmdlet cmdlet)
        {
            return ExecuteScriptAndGetVariable(
                cmdlet,
                "${0} = $PSVersionTable.OS",
                "windows");
        }

        private static List<Version> GetPsCompatibleVersions(PSCmdlet cmdlet)
        {
            object versionsTable = ExecuteScriptAndGetVariable(
                cmdlet,
                "${0} = $PSVersionTable.PSCompatibleVersions");
            return versionsTable is Version[] versions
                ? versions.ToList()
                : new List<Version>();
        }

        private static bool ExecuteScriptAndGetVariableAsBool(
            PSCmdlet cmdlet,
            string scriptFormatString,
            bool defaultValue)
        {
            string scriptResult = ExecuteScriptAndGetVariable(
                cmdlet,
                scriptFormatString,
                bool.FalseString);
            return bool.TryParse(scriptResult, out bool returnValue)
                ? returnValue
                : defaultValue;
        }

        private static string ExecuteScriptAndGetVariable(
            PSCmdlet cmdlet,
            string scriptFormatString,
            string defaultValue)
        {
            const string outputVariable = "outputVariable";
            cmdlet.ExecuteScript<object>(
                string.Format(scriptFormatString, outputVariable));
            return cmdlet
                .GetVariableValue(outputVariable, defaultValue)
                .ToString();
        }

        private static object ExecuteScriptAndGetVariable(
            PSCmdlet cmdlet,
            string scriptFormatString)
        {
            const string outputVariable = "outputVariable";
            cmdlet.ExecuteScript<object>(
                string.Format(scriptFormatString, outputVariable));
            return cmdlet.GetVariableValue(outputVariable);
        }
    }
}
