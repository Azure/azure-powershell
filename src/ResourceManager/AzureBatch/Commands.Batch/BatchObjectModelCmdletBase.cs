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

using Microsoft.Azure.Batch;
using Microsoft.Azure.Commands.Batch.Properties;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Batch
{
    /// <summary>
    /// Base class for cmdlets that use the Batch OM.
    /// </summary>
    public class BatchObjectModelCmdletBase : BatchCmdletBase
    {
        /// <summary>
        /// Collection of custom behaviors to perform on service calls
        /// </summary>
        internal IEnumerable<BatchClientBehavior> AdditionalBehaviors { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true, HelpMessage = "The BatchAccountContext instance to use when interacting with the Batch service. " +
            "If you use the Get-AzBatchAccount cmdlet to get your BatchAccountContext, then Azure Active Directory authentication will be used when interacting " +
            "with the Batch service. To use shared key authentication instead, use the Get-AzBatchAccountKeys cmdlet to get a BatchAccountContext object with " +
            "its access keys populated. When using shared key authentication, the primary access key is used by default. To change the key to use, set the " +
            "BatchAccountContext.KeyInUse property.")]
        [ValidateNotNullOrEmpty]
        public BatchAccountContext BatchContext { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            string verboseMessage = this.BatchContext.HasKeys ?
                string.Format(Resources.UsingSharedKeyAuth, this.BatchContext.KeyInUse) :
                Resources.UsingAadAuth;
            WriteVerboseWithTimestamp(verboseMessage);
        }
    }
}
