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

using System.IO;
using System.Management.Automation;
using Microsoft.Azure.Commands.Common.Authentication.Models;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.ServiceBus;
using Microsoft.WindowsAzure.Commands.Utilities.Websites;
using Microsoft.Azure.Commands.Common.Authentication;
using System.Reflection;

namespace Microsoft.WindowsAzure.Commands.CloudService
{
    [Cmdlet(VerbsDiagnostic.Test, "AzureName"), OutputType(typeof(bool))]
    public class TestAzureNameCommand : AzureSMCmdlet, IModuleAssemblyInitializer
    {
        internal ServiceBusClientExtensions ServiceBusClient { get; set; }
        internal ICloudServiceClient CloudServiceClient { get; set; }
        internal IWebsitesClient WebsitesClient { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "Service", HelpMessage = "Test for a cloud service name.")]
        public SwitchParameter Service { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "Storage", HelpMessage = "Test for a storage account name.")]
        public SwitchParameter Storage { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "ServiceBusNamespace", HelpMessage = "Test for a service bus namespace name.")]
        public SwitchParameter ServiceBusNamespace { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = "Website", HelpMessage = "Test for a website name.")]
        public SwitchParameter Website { get; set; }

        [Parameter(Position = 1, ParameterSetName = "Service", Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Cloud service name.")]
        [Parameter(Position = 1, ParameterSetName = "Storage", Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Storage account name.")]
        [Parameter(Position = 1, ParameterSetName = "ServiceBusNamespace", Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Service bus namespace name.")]
        [Parameter(Position = 1, ParameterSetName = "Website", Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "Website name.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        public bool IsDNSAvailable(AzureSubscription subscription, string name)
        {
            EnsureCloudServiceClientInitialized(subscription);
            bool available = this.CloudServiceClient.CheckHostedServiceNameAvailability(name);
            WriteObject(!available);
            return available;
        }

        public bool IsStorageServiceAvailable(AzureSubscription subscription, string name)
        {
            EnsureCloudServiceClientInitialized(subscription);
            bool available = this.CloudServiceClient.CheckStorageServiceAvailability(name);
            WriteObject(!available);
            return available;
        }

        public bool IsServiceBusNamespaceAvailable(string subscriptionId, string name)
        {
            bool result = ServiceBusClient.IsAvailableNamespace(name);

            WriteObject(!result);

            return result;
        }

        private void EnsureCloudServiceClientInitialized(AzureSubscription subscription)
        {
            this.CloudServiceClient = this.CloudServiceClient ?? new CloudServiceClient(
                Profile,
                subscription,
                SessionState.Path.CurrentLocation.Path,
                WriteDebug,
                WriteVerbose,
                WriteWarning);
        }

        public bool IsWebsiteAvailable(string name)
        {
            bool available = this.WebsitesClient.CheckWebsiteNameAvailability(name);
            WriteObject(!available);
            return available;
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (Service.IsPresent)
            {
                IsDNSAvailable(Profile.Context.Subscription, Name);
            }
            else if (Storage.IsPresent)
            {
                IsStorageServiceAvailable(Profile.Context.Subscription, Name);
            }
            else if (Website.IsPresent)
            {
                WebsitesClient = WebsitesClient ?? new WebsitesClient(Profile, Profile.Context.Subscription, WriteDebug);
                IsWebsiteAvailable(Name);
            }
            else
            {
                ServiceBusClient = ServiceBusClient ?? new ServiceBusClientExtensions(Profile);
                IsServiceBusNamespaceAvailable(Profile.Context.Subscription.Id.ToString(), Name);
            }
        }

        public void OnImport()
        {
            try
            {
                System.Management.Automation.PowerShell invoker = null;
                invoker = System.Management.Automation.PowerShell.Create(RunspaceMode.CurrentRunspace);
                invoker.AddScript(File.ReadAllText(FileUtilities.GetContentFilePath(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "ServiceManagementStartup.ps1")));
                invoker.Invoke();
            }
            catch
            {
                // This will throw exception for tests, ignore.
            }
        }
    }
}