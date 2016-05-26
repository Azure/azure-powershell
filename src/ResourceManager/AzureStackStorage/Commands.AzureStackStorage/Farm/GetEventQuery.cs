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

using Microsoft.AzureStack.Management.StorageAdmin;
using Microsoft.AzureStack.Management.StorageAdmin.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     SYNTAX
    ///          Get-EventQuery [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} [-StartTime] {DateTime} [-EndTime] {DateTime} [[-NodeName] {string}]
    ///             [[-ResourceUri] {string}] [[-ProviderGuid] {Guid}] [[-EventIds] {int[]}] [{CommonParameters}] 
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminFarmEventQuery)]
    public sealed class GetEventQuery : AdminCmdlet
    {
        /// <summary>
        ///    
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
        public string FarmName
        {
            get;
            set;
        }

        /// <summary>
        ///    
        /// </summary>
        [Parameter(Mandatory = true, Position = 5)]
        public DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        ///   
        /// </summary>
        [Parameter(Mandatory = true, Position = 6)]
        public DateTime EndTime
        {
            get;
            set;
        }

        /// <summary>
        ///    
        /// </summary>
        [Parameter(Mandatory = false, Position = 7)]
        public string NodeName
        {
            get;
            set;
        }

        /// <summary>
        ///  
        /// </summary>
        [Parameter(Mandatory = false, Position = 8)]
        public string ResourceUri
        {
            get;
            set;
        }

        /// <summary>
        ///    
        /// </summary>
        [Parameter(Mandatory = false, Position = 9)]
        public Guid? ProviderGuid
        {
            get;
            set;
        }

        /// <summary>
        ///    
        /// </summary>
        [Parameter(Mandatory = false, Position = 10)]
        public int[] EventId
        {
            get;
            set;
        }

        protected override void Execute()
        {
            List<string> filterList = new List<string>();
            filterList.Add(string.Format(CultureInfo.InvariantCulture, "startTime eq '{0:O}'", StartTime.ToUniversalTime()));
            filterList.Add(string.Format(CultureInfo.InvariantCulture, "endTime eq '{0:O}'", EndTime.ToUniversalTime()));
            if (!string.IsNullOrEmpty(NodeName))
            {
                filterList.Add(string.Format(CultureInfo.InvariantCulture, "computerName eq '{0}'", NodeName));
            }
            if (!string.IsNullOrEmpty(ResourceUri))
            {
                filterList.Add(string.Format(CultureInfo.InvariantCulture, "resourceUri eq '{0}'", ResourceUri));
            }
            if (ProviderGuid != null)
            {
                filterList.Add(string.Format(CultureInfo.InvariantCulture, "providerId eq '{0}'", ProviderGuid));
            }
            if (EventId != null)
            {
                List<string> eventIdFilters = new List<string>();
                foreach (var eventId in EventId)
                {
                    eventIdFilters.Add(string.Format(CultureInfo.InvariantCulture, "eventId eq '{0}'", eventId));
                }
                if (eventIdFilters.Any())
                {
                    string eventIdFilter = eventIdFilters.Aggregate((current, next) => string.Format(CultureInfo.InvariantCulture, "{0} or {1}", current, next));
                    filterList.Add(string.Format(CultureInfo.InvariantCulture, "({0})", eventIdFilter));
                }
            }
            string filter = filterList.Aggregate((current, next) => string.Format(CultureInfo.InvariantCulture, "{0} and {1}", current, next));

            EventQuery eventQuery = Client.Farms.GetEventQuery(ResourceGroupName, FarmName, filter);
            WriteObject(eventQuery, true);
        }
    }
}