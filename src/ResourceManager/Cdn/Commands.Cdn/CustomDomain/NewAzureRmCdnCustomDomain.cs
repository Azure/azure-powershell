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
using System.Management.Automation;
using System.Net;
using System.Reflection;
using Microsoft.Azure.Commands.Cdn.Common;
using Microsoft.Azure.Commands.Cdn.Helpers;
using Microsoft.Azure.Commands.Cdn.Models.CustomDomain;
using Microsoft.Azure.Commands.Cdn.Properties;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;

namespace Microsoft.Azure.Commands.Cdn.CustomDomain
{
    [Cmdlet(VerbsCommon.New, "AzureRmCdnCustomDomain"), OutputType(typeof(PSCustomDomain))]
    public class NewAzureRmCdnCustomDomain : AzureCdnCmdletBase, IModuleAssemblyInitializer
    {
        [Parameter(Mandatory = true, HelpMessage = "Host name of the Azure Cdn CustomDomain name.")]
        [ValidateNotNullOrEmpty]
        public string HostName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Cdn CustomDomain name.")]
        [ValidateNotNullOrEmpty]
        public string CustomDomainName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Cdn endpoint name.")]
        [ValidateNotNullOrEmpty]
        public string EndpointName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "Azure Cdn profile name.")]
        [ValidateNotNullOrEmpty]
        public string ProfileName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The resource group of the Azure Cdn Profile")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                CdnManagementClient.CustomDomains.GetWithHttpMessagesAsync(
                    CustomDomainName, 
                    EndpointName, 
                    ProfileName,
                    ResourceGroupName).Wait();

                throw new PSArgumentException(string.Format(
                    Resources.Error_CreateExistingCustomDomain, 
                    CustomDomainName,
                    EndpointName,
                    ProfileName,
                    ResourceGroupName));
            }
            catch (AggregateException exception)
            {
                var errorResponseException = exception.InnerException as ErrorResponseException;
                if (errorResponseException == null)
                {
                    throw;
                }

                if (errorResponseException.Response.StatusCode.Equals(HttpStatusCode.NotFound))
                {
                    var customDomain = CdnManagementClient.CustomDomains.Create(
                        CustomDomainName,
                        EndpointName,
                        ProfileName,
                        ResourceGroupName,
                        HostName);

                    WriteVerbose(Resources.Success);
                    WriteObject(customDomain.ToPsCustomDomain());
                }
                else
                {
                    throw;
                }
            }
        }

        public void OnImport()
        {
                System.Management.Automation.PowerShell invoker = null;
                invoker = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace);
                invoker.AddScript(File.ReadAllText(FileUtilities.GetContentFilePath(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "CdnStartup.ps1")));
                invoker.Invoke();
        }
    }
}
