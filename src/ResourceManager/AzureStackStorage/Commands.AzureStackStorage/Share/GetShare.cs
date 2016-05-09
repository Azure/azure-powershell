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
using System.Linq;
using System.Management.Automation;

namespace Microsoft.AzureStack.Commands.StorageAdmin
{
    /// <summary>
    /// get shares
    /// 
    ///     SYNTAX
    ///          Get-Share [-SubscriptionId] {string} [-Token] {string} [-AdminUri] {Uri} [-ResourceGroupName] {string} 
    ///             [-SkipCertificateValidation] [-FarmName] {string} [-ShareName] {string} [ {CommonParameters}] 
    /// 
    /// </summary>
    [Cmdlet(VerbsCommon.Get, Nouns.AdminShare)]
    public sealed class GetAdminShare : AdminCmdlet
    {
        /// <summary>
        /// Farm Identifier
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string FarmName
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ShareName
        {
            get;
            set;
        }

        protected override void Execute()
        {
            if (string.IsNullOrEmpty(ShareName))
            {
                var shares = Client.Shares.List(ResourceGroupName, FarmName);

                WriteObject(shares.Shares.Select(_ => new ShareResponse(_)), true);
            }
            else
            {
                var share = Client.Shares.Get(ResourceGroupName, FarmName, ShareName);

                WriteObject(new ShareResponse(share.Share));
            }
        }
    }
}
