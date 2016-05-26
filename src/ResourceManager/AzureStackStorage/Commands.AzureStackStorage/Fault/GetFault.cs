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
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     get faults
    ///    
    ///     SYNTAX
    ///         Parameter Set: GetFault
    ///         Get-Fault [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} -FaultId {string} [ {CommonParameters}] 
    /// 
    ///         Parameter Set: GetCurrentFault
    ///         Get-Fault [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} [-ResourceUri {string}] [ {CommonParameters}] 
    ///     
    ///         Parameter Set: GetHistoryFault
    ///         Get-Fault [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} -StartTime {DateTime} -EndTime {DateTime} [ {CommonParameters}]  
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminFault, DefaultParameterSetName = GetCurrentFaultSet)]
    public sealed class GetFault : AdminCmdlet
    {

        const string GetCurrentFaultSet = "GetCurrentFault";
        const string GetHistoryFaultSet = "GetHistoryFault";
        const string GetFaultSet = "GetFault";
        Action func;

        /// <summary>
        ///     Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 4)]
        [ValidateNotNull]
        public string FarmName
        {
            get;
            set;
        }

        /// <summary>
        ///     Fault Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, ParameterSetName = GetFaultSet)]
        [ValidateNotNull]
        public string FaultId
        {
            get;
            set;
        }

        /// <summary>
        ///     Resource Uri
        /// </summary>
        [Alias("Id")]
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, ParameterSetName = GetCurrentFaultSet)]
        [ValidateNotNull]
        public string ResourceUri
        {
            get;
            set;
        }

        /// <summary>
        ///     Query Fault StartTime 
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetHistoryFaultSet)]
        [ValidateNotNull]
        public DateTime StartTime
        {
            get;
            set;
        }

        /// <summary>
        ///     Query Fault EndTime 
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = GetHistoryFaultSet)]
        [ValidateNotNull]
        public DateTime EndTime
        {
            get;
            set;
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();

            switch (ParameterSetName)
            {
                case GetFaultSet:
                    {
                        func = () =>
                        {
                            FaultGetResponse fault = Client.Faults.Get(ResourceGroupName, FarmName, FaultId);
                            WriteObject(new FaultResponse(fault.Fault));
                        };
                    }
                    break;
                case GetHistoryFaultSet:
                    {
                        func = () =>
                        {
                            FaultListResponse faults = Client.Faults.ListHistoryFaults(ResourceGroupName, FarmName,
                                StartTime.ToString("O", CultureInfo.InvariantCulture),
                                EndTime.ToString("O", CultureInfo.InvariantCulture));
                            WriteObject(faults.Select(_ => new FaultResponse(_)), true);
                        };
                    }
                    break;
                case GetCurrentFaultSet:
                    {
                        func = () =>
                        {
                            FaultListResponse faults = Client.Faults.ListCurrentFaults(ResourceGroupName, FarmName, ResourceUri);
                            WriteObject(faults.Faults.Select(_ => new FaultResponse(_)), true);
                        };
                    }
                    break;
                default:
                    throw new ArgumentException("Bad GetFault parameter set");
            }
        }

        protected override void Execute()
        {
            func();
        }
    }
}
