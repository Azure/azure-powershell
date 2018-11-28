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

using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Commands.WebApps.Models;
using Microsoft.Azure.Commands.WebApps.Utilities;
using Microsoft.Azure.Management.WebSites.Models;
using System;
using System.Management.Automation;


namespace Microsoft.Azure.Commands.WebApps
{
    public class WebAppBaseCmdlet : WebAppBaseClientCmdLet
    {
        protected const string ParameterSet1Name = "S1";
        protected const string ParameterSet2Name = "S2";

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 0, Mandatory = true, HelpMessage = "The name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ParameterSetName = ParameterSet1Name, Position = 1, Mandatory = true, HelpMessage = "The name of the web app.", ValueFromPipelineByPropertyName = true)]
        [ResourceNameCompleter("Microsoft.Web/sites", "ResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = ParameterSet2Name, Position = 0, Mandatory = true, HelpMessage = "The web app object", ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSSite WebApp { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.Equals(ParameterSetName, ParameterSet2Name, StringComparison.OrdinalIgnoreCase))
            {
                string rg, name, slot;

                if (!CmdletHelpers.TryParseWebAppMetadataFromResourceId(WebApp.Id, out rg, out name, out slot, true))
                {
                    throw new ValidationMetadataException("Input object is a deployment slot, not a production web app");
                }

                ResourceGroupName = rg;
                Name = name;
            }
        }
    }
}

