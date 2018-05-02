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
        [Alias("SearchString")]
        [ValidateNotNullOrEmpty]
        public string DisplayNameBeginsWith { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.DisplayName, HelpMessage = "The service principal display name.")]
        [ValidateNotNullOrEmpty]
        public string DisplayName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ObjectId,
            HelpMessage = "The service principal object id.")]
        [ValidateNotNullOrEmpty]
        public Guid ObjectId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.ApplicationId,
            HelpMessage = "The service principal application id.")]
        public Guid ApplicationId { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, ParameterSetName = ParameterSet.ApplicationObject,
            HelpMessage = "The object representing the application to create an service principal for.")]
        public PSADApplication ApplicationObject { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = ParameterSet.SPN,
            HelpMessage = "The user SPN.")]
        [ValidateNotNullOrEmpty]
        [Alias("SPN")]
        public string ServicePrincipalName { get; set; }

        public override void ExecuteCmdlet()
        {
            ExecutionBlock(() =>
            {
                if (this.IsParameterBound(c => c.ApplicationObject))
                {
                    ApplicationId = ApplicationObject.ApplicationId;
                }

                if (this.IsParameterBound(c => c.ObjectId))
                {
                    var objectId = ObjectId.ToString();
                    var servicePrincipal = ActiveDirectoryClient.GetServicePrincipalByObjectId(objectId);
                    if (servicePrincipal != null)
                    {
                        WriteObject(servicePrincipal);
                    }
                }
                else if (this.IsParameterBound(c => c.ServicePrincipalName))
                {
                    var servicePrincipal = ActiveDirectoryClient.GetServicePrincipalBySPN(ServicePrincipalName);
                    if (servicePrincipal != null)
                    {
                        WriteObject(servicePrincipal);
                    }
                }
                else
                {
                    ulong first = MyInvocation.BoundParameters.ContainsKey("First") ? this.PagingParameters.First : ulong.MaxValue;
                    ulong skip = MyInvocation.BoundParameters.ContainsKey("Skip") ? this.PagingParameters.Skip : 0;
                    if (ApplicationId != Guid.Empty)
                    {
                        var appId = ApplicationId.ToString();
                        Rest.Azure.OData.ODataQuery<ServicePrincipal> odataQuery = new Rest.Azure.OData.ODataQuery<ServicePrincipal>(s => s.AppId == appId);
                        WriteObject(ActiveDirectoryClient.FilterServicePrincipals(odataQuery, first, skip), true);
                    }
                    else
                    {
                        ADObjectFilterOptions options = new ADObjectFilterOptions()
                        {
                            SearchString = this.IsParameterBound(c => c.DisplayNameBeginsWith) ? DisplayNameBeginsWith + "*" : DisplayName
                        };
                        WriteObject(ActiveDirectoryClient.FilterServicePrincipals(options, first, skip), true);
                    }
                }
            });
        }
    }
}