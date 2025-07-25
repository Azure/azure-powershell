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

using Microsoft.Azure.Commands.Batch.Models;
using System;
using System.Management.Automation;
using System.Security;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Batch
{
    [System.Obsolete]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzurePrefix + "BatchCertificate", DefaultParameterSetName = FileParameterSet), OutputType(typeof(void))]
    public class NewBatchCertificateCommand : BatchObjectModelCmdletBase
    {
        internal const string FileParameterSet = "File";
        internal const string RawDataParameterSet = "RawData";

        [Parameter(Position = 0, ParameterSetName = FileParameterSet, Mandatory = true,
            HelpMessage = "The path to the certificate file. The certificate must be in either .cer or .pfx format.")]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        [Parameter(Position = 0, ParameterSetName = RawDataParameterSet, Mandatory = true, ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true, HelpMessage = "The raw certificate data in either .cer or .pfx format.")]
        [ValidateNotNullOrEmpty]
        public byte[] RawData { get; set; }

        [Parameter]
        [ValidateNotNull]
        public SecureString Password { get; set; }

        [Parameter]
        [ValidateNotNull]
        public PSCertificateKind Kind { get; set; }

        protected override void ExecuteCmdletImpl()
        {
            string password = this.Password?.ConvertToString();

            NewCertificateParameters parameters = new NewCertificateParameters(
                this.BatchContext,
                this.FilePath,
                this.RawData,
                // If kind has been specified, take that -- otherwise, default to old logic of using password to guess
                this.IsParameterBound(c => c.Kind) ? this.Kind : (password == null ? PSCertificateKind.Cer : PSCertificateKind.Pfx),
                this.AdditionalBehaviors)
            {
                Password = password
            };

            BatchClient.AddCertificate(parameters);
        }
    }
}
