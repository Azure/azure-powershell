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

namespace Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Commands
{
    using Microsoft.Azure.Commands.ApiManagement.ServiceManagement.Models;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;

    [Cmdlet(VerbsCommon.Get, Constants.ApiManagementOpenIdConnectProvider, DefaultParameterSetName = GetAll)]
    [OutputType(typeof(IList<PsApiManagementOpenIdConnectProvider>), ParameterSetName = new[] { GetAll })]
    [OutputType(typeof(PsApiManagementOpenIdConnectProvider), ParameterSetName = new[] { GetById })]
    public class GetAzureApiManagementOpenIdConnectProvider : AzureApiManagementCmdletBase
    {
        private const string GetAll = "Get all OpenID Connect Providers";
        private const string GetById = "Get by OpenID Connect Provider ID";
        private const string FindByName = "Find by OpenID Connect Provider friendly Name";

        [Parameter(
            ValueFromPipelineByPropertyName = true,
            Mandatory = true,
            HelpMessage = "Instance of PsApiManagementContext. This parameter is required.")]
        [ValidateNotNullOrEmpty]
        public PsApiManagementContext Context { get; set; }

        [Parameter(
            ParameterSetName = GetById,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "Identifier of a OpenID Connect Provider. " +
                          "If specified will try to find openId Connect Provider by the identifier. " +
                          "This parameter is optional.")]
        public String OpenIdConnectProviderId { get; set; }

        [Parameter(
            ParameterSetName = FindByName,
            ValueFromPipelineByPropertyName = true,
            Mandatory = false,
            HelpMessage = "OpenID Connect Provider friendly name." +
                          " If specified will try to find openID Connect Provider by the name. " +
                          "This parameter is optional.")]
        public String Name { get; set; }

        public override void ExecuteApiManagementCmdlet()
        {
            if (ParameterSetName.Equals(GetAll))
            {
                var openIdConnectProviders = Client.OpenIdConnectProvidersList(Context);
                WriteObject(openIdConnectProviders, true);
            }
            else if (ParameterSetName.Equals(GetById))
            {
                var openIdConnectProvider = Client.OpenIdConnectProviderById(Context, OpenIdConnectProviderId);
                WriteObject(openIdConnectProvider);
            }
            else if (ParameterSetName.Equals(FindByName))
            {
                var openIdConnectProviders = Client.OpenIdConnectProviderByName(Context, Name);
                WriteObject(openIdConnectProviders, true);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Parameter set name '{0}' is not supported.", ParameterSetName));
            }
        }
    }
}
