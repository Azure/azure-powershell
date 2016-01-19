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

using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Pairs storage classification
    /// </summary>
    [Cmdlet(VerbsLifecycle.Start, "AzureRmSiteRecoveryStorageClassificationMappingJob", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRStorageClassification>))]
    public class StartAzureSiteRecoveryStorageClassificationMappingJob : SiteRecoveryCmdletBase
    {
        #region Parameters

        /// <summary>
        /// Gets or sets primary storage classification.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public ASRStorageClassification PrimaryStorageClassification { get; set; }

        /// <summary>
        /// Gets or sets recovery storage classification.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByObject, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public ASRStorageClassification RecoveryStorageClassification { get; set; }
        #endregion

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.WriteObject(RecoveryServicesClient.MapStorageClassification(
                PrimaryStorageClassification,
                RecoveryStorageClassification));
        }
    }
}
