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
using System.Globalization;
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    ///     dismiss faults
    ///    
    ///     SYNTAX
    ///         Resolve-Fault [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} [-FaultId] {string} [-Force] [ {CommonParameters}]
    ///     
    /// </summary>
    [Cmdlet(VerbsDiagnostic.Resolve, Nouns.AdminFault, SupportsShouldProcess = true)]
    public sealed class ResolveFault : AdminCmdlet
    {
        const string ShouldProcessTargetFormat = "fault {0} ";
        const string ShouldContinueQuery = "Continue with resolve fault?";
        const string ShouldContinueCaption = "Confirm";

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
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, Position = 5)]
        [ValidateNotNull]
        public string FaultId
        {
            get;
            set;
        }

        [Parameter]
        public SwitchParameter Force
        {
            get;
            set;
        }

        protected override void Execute()
        {
            if (ShouldProcess(string.Format(CultureInfo.InvariantCulture, ShouldProcessTargetFormat, FaultId)) &&
                (Force || ShouldContinue(ShouldContinueQuery, ShouldContinueCaption)))
            {
                Client.Faults.Dismiss(ResourceGroupName, FarmName, FaultId);
            }
        }
    }
}
