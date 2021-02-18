<<<<<<< HEAD
﻿using AutoMapper;
using Microsoft.Azure.Commands.Network.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.Tags;
using Microsoft.Azure.Management.Network;
using System;
using System.Management.Automation;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using MNM = Microsoft.Azure.Management.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Network
{
    public class PrivateEndpointConnectionBaseCmdlet : PrivateLinkServiceBaseCmdlet
=======
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

using Microsoft.Azure.Commands.Network.PrivateLinkService.PrivateLinkServiceProvider;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Network
{
    public abstract class PrivateEndpointConnectionBaseCmdlet : NetworkBaseCmdlet, IDynamicParameters
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    {
        [Parameter(
            Mandatory = true,
            ParameterSetName = "ByResourceId",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Alias("ResourceName")]
        [Parameter(
<<<<<<< HEAD
           Mandatory = true,
=======
           Mandatory = false,
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The resource name.",
           ParameterSetName = "ByResource")]
        [ValidateNotNullOrEmpty]
<<<<<<< HEAD
        public string Name { get; set; }

        [Parameter(
           Mandatory = true,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The private link service name.",
           ParameterSetName = "ByResource")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }
=======
        [SupportsWildcards]
        public virtual string Name { get; set; }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

        [Parameter(
            Mandatory = true,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The resource group name.",
            ParameterSetName = "ByResource")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public virtual string ResourceGroupName { get; set; }

        [Parameter(
<<<<<<< HEAD
          Mandatory = false,
          ValueFromPipelineByPropertyName = true,
          HelpMessage = "The reason of action.")]
        public string Description { get; set; }

=======
          Mandatory = true,
          ValueFromPipelineByPropertyName = true,
             HelpMessage = "The private link service name.",
           ParameterSetName = "ByResource")]
        [ValidateNotNullOrEmpty]
        public string ServiceName { get; set; }

        protected RuntimeDefinedParameterDictionary DynamicParameters;

        public const string privateEndpointTypeName = "PrivateLinkResourceType";
        string NamedContextParameterSet = "ByResource";
        public object GetDynamicParameters()
        {
            var parameters = new RuntimeDefinedParameterDictionary();
            RuntimeDefinedParameter namedParameter;
            if (ProviderConfiguration.TryGetProvideServiceParameter(privateEndpointTypeName, NamedContextParameterSet, out namedParameter))
            {
                parameters.Add(privateEndpointTypeName, namedParameter);
            }
            DynamicParameters = parameters;
            return parameters;
        }

        public string PrivateLinkResourceType { get; set; }

        public string Subscription { get; set; }

        protected IPrivateLinkProvider BuildProvider(string subscription, string privateLinkResourceType)
        {
            return PrivateLinkProviderFactory.CreatePrivateLinkProvder(this, subscription, privateLinkResourceType);
        }
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
    }
}
