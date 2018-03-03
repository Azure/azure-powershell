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
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.ActiveDirectory
{
    /// <summary>
    /// Get AD users.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmADServicePrincipal", DefaultParameterSetName = ParameterSet.Empty, SupportsPaging = true), OutputType(typeof(List<PSADServicePrincipal>))]
    public class GetAzureADServicePrincipalCommand : ActiveDirectoryBaseCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SearchString,
            HelpMessage = "The service principal search string.")]
        [ValidateNotNullOrEmpty]
        public string SearchString { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId,
            HelpMessage = "The service principal object id.")]
        [ValidateNotNullOrEmpty]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationId,
            HelpMessage = "The service principal application id.")]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPN,
            HelpMessage = "The user SPN.")]
        [ValidateNotNullOrEmpty]
        [Alias("SPN")]
        public string ServicePrincipalName { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                Rest.Azure.OData.ODataQuery<ServicePrincipal> odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>();
                if (this.IsParameterBound(c => c.ObjectId))
                {
                    var objectId = ObjectId.ToString();
                    odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.ObjectId == objectId);
                }
                else if (this.IsParameterBound(c => c.ApplicationId))
                {
                    var appId = ApplicationId.ToString();
                    odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.AppId == appId);
                }
                else if (this.IsParameterBound(c => c.ServicePrincipalName))
                {
                    odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.ServicePrincipalNames.Contains(ServicePrincipalName));
                }
                else if (this.IsParameterBound(c => c.SearchString))
                {
                    odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.DisplayName.StartsWith(SearchString));
                }

                ulong first = MyInvocation.BoundParameters.ContainsKey("First") ? this.PagingParameters.First : ulong.MaxValue;
                ulong skip = MyInvocation.BoundParameters.ContainsKey("Skip") ? this.PagingParameters.Skip : 0;
                WriteObject(ActiveDirectoryClient.FilterServicePrincipals(odataQuery, first, skip), true);
            });
        }
    }
}