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

using Microsoft.Azure.Graph.RBAC.Version1_6.ActiveDirectory;
using Microsoft.Azure.Graph.RBAC.Version1_6.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Gets the AD application.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmADApplication", DefaultParameterSetName = ParameterSet.Empty, SupportsPaging = true), OutputType(typeof(List<PSADApplication>))]
    public class GetAzureADApplicationCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationObjectId, HelpMessage = "The application object id.")]
        [ValidateGuidNotEmpty]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationId, HelpMessage = "The application id.")]
        [ValidateGuidNotEmpty]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SearchString, HelpMessage = "Used to find applications that begin with the provided string.")]
        [ValidateNotNullOrEmpty]
        public string DisplayNameStartWith { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayName, HelpMessage = "The display name of the application.")]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationIdentifierUri, HelpMessage = "The identifierUri of the application.")]
        [ValidateNotNullOrEmpty]
        public string IdentifierUri { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.ObjectId))
                {
                    WriteObject(ActiveDirectoryClient.GetApplication(ObjectId));
                }
                else
                {
                    Rest.Azure.OData.ODataQuery<Application> odataQueryFilter = new Rest.Azure.OData.ODataQuery<Application>();

                    if (this.IsParameterBound(c => c.ApplicationId))
                    {
                        string appId = ApplicationId.ToString();
                        odataQueryFilter = new Rest.Azure.OData.ODataQuery<Application>(a => a.AppId == appId);
                    }
                    else if (this.IsParameterBound(c => c.DisplayNameStartWith))
                    {
                        odataQueryFilter = new Rest.Azure.OData.ODataQuery<Application>(a => a.DisplayName.StartsWith(DisplayNameStartWith));
                    }
                    else if (this.IsParameterBound(c => c.IdentifierUri))
                    {
                        odataQueryFilter = new Rest.Azure.OData.ODataQuery<Application>(a => a.IdentifierUris.Contains(IdentifierUri));
                    }
                    else if (this.IsParameterBound(c => c.DisplayName))
                    {
                        odataQueryFilter = new Rest.Azure.OData.ODataQuery<Application>(a => a.DisplayName == DisplayName);
                    }

                    ulong first = MyInvocation.BoundParameters.ContainsKey("First") ? this.PagingParameters.First : ulong.MaxValue;
                    ulong skip = MyInvocation.BoundParameters.ContainsKey("Skip") ? this.PagingParameters.Skip : 0;
                    WriteObject(ActiveDirectoryClient.GetApplicationWithFilters(odataQueryFilter, first, skip), enumerateCollection: true);
                }
            });
        }
    }
}