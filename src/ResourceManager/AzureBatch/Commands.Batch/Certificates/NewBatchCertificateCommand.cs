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
using System.Management.Automation;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.New, Constants.AzureBatchCertificate, DefaultParameterSetName = FileParameterSet)]
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
        [ValidateNotNullOrEmpty]
        public string Password { get; set; }

        public override void ExecuteCmdlet()
        {
            NewCertificateParameters parameters = new NewCertificateParameters(this.BatchContext, this.FilePath, this.RawData,
                this.AdditionalBehaviors)
            {
                Password = this.Password
            };

            BatchClient.AddCertificate(parameters);
        }
    }
}
