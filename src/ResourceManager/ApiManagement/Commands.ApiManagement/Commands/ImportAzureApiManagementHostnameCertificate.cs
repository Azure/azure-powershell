//  
// Copyright (c) Microsoft.  All rights reserved.
// 
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

namespace Microsoft.Azure.Commands.ApiManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.Models;
    using ResourceManager.Common.ArgumentCompleters;
    using System;
    using System.Management.Automation;

    [Cmdlet(VerbsData.Import, "AzureRmApiManagementHostnameCertificate"), OutputType(typeof(PsApiManagementHostnameCertificate))]
    [Obsolete("This cmdlet has been marked for deprecation in an upcoming release. Please use the " +
        "Set-AzureRmApiManagement cmdlet from the AzureRM.ApiManagement module instead.",
        false)]
    public class ImportAzureApiManagementHostnameCertificate : AzureApiManagementCmdletBase
    {
        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of resource group under which API Management exists.")]
        [ResourceGroupCompleter()]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Name of API Management.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Host name type to upload certificate for.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementHostnameType HostnameType { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Path to a .pfx certificate file.")]
        [ValidateNotNullOrEmpty]
        public string PfxPath { get; set; }

        [Parameter(
            Mandatory = true,
            HelpMessage = "Password for the .pfx certificate file.")]
        [ValidateNotNullOrEmpty]
        public string PfxPassword { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Sends imported PsApiManagementHostnameCertificate to pipeline if operation succeeds.")]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecuteCmdLetWrap(() =>
                Client.UploadCertificate(
                    ResourceGroupName,
                    Name,
                    HostnameType,
                    PfxPath,
                    PfxPassword),
                PassThru.IsPresent);
        }
    }
}