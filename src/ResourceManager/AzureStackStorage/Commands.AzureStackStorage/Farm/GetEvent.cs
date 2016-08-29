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

using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System;
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     SYNTAX
    ///         Parameter Set: EventWithFilter
    ///         Get-Event  [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} -ResourceGroupName {string} 
    ///             [-SkipCertificateValidation] -FarmName {string} -StartTime {DateTime} -EndTime {DateTime} [-NodeName {string}]
    ///             [-ResourceUri {string}] [-ProviderGuid {Guid}] -EventIds {int[]} [{CommonParameters}]
    ///  
    ///         Parameter Set: EventWithLocation
    ///         Get-Event  [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} -EventQuery {EventQuery}
    ///             [{CommonParameters}] 
    ///  
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminFarmEvent, DefaultParameterSetName = EventWithFilterSet)]
    public sealed class GetEvent : AdminCmdlet
    {
        const string EventWithFilterSet = "EventWithFilter";

        const string EventWithLocationSet = "EventWithLocation";

        Action func;

        /// <summary>
        ///    
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = EventWithFilterSet)]
        [ValidateNotNull]
        public string FarmName
        {
            get;
            set;
        }

        /// <summary>
        ///    
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = EventWithFilterSet)]
        public DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        ///  
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = EventWithFilterSet)]
        public DateTime EndTime
        {
            get;
            set;
        }

        /// <summary>
        ///    
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = EventWithFilterSet)]
        public String NodeName
        {
            get;
            set;
        }

        /// <summary>
        ///   
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = EventWithFilterSet)]
        public String ResourceUri
        {
            get;
            set;
        }

        /// <summary>
        ///    
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = EventWithFilterSet)]
        public Guid ProviderGuid
        {
            get;
            set;
        }

        /// <summary>
        ///    
        /// </summary>
        [Parameter(Mandatory = false, ParameterSetName = EventWithFilterSet)]
        public int[] EventId
        {
            get;
            set;
        }

        /// <summary>
        ///     
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = EventWithLocationSet)]
        public EventQuery EventQuery
        {
            get;
            set;
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            switch (ParameterSetName)
            {
                case EventWithFilterSet:
                    {
                        func = () => WriteObject(
                            Client.Farms.ExecuteEventQuery(ResourceGroupName, FarmName, StartTime, EndTime, NodeName, ResourceUri, ProviderGuid, EventId));
                    }
                    break;
                case EventWithLocationSet:
                    {
                        func = () => WriteObject(
                            Client.Farms.ExecuteEventQuery(EventQuery),
                            true);
                    }
                    break;
                default:
                    throw new ArgumentException(Resources.BadParameterSet);
            }
        }

        protected override void Execute()
        {
            func();
        }
    }
}