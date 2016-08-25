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

using System.Management.Automation;

using Microsoft.Azure.Commands.Batch.Models;
using Constants = Microsoft.Azure.Commands.Batch.Utils.Constants;

namespace Microsoft.Azure.Commands.Batch
{
    [Cmdlet(VerbsCommon.New, Constants.AzureRmBatchApplicationPackage, DefaultParameterSetName = UploadAndActivateSet), OutputType(typeof(PSApplicationPackage))]
    public class NewBatchApplicationPackageCommand : BatchCmdletBase
    {
        internal const string ActivateOnlySet = "ActivateOnly";
        internal const string UploadAndActivateSet = "UpdateAndActivate";

        [Parameter(Position = 0, ParameterSetName = UploadAndActivateSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Specifies the name of the Batch account.")]
        [Parameter(Position = 0, ParameterSetName = ActivateOnlySet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Specifies the name of the Batch account.")]
        [ValidateNotNullOrEmpty]
        public string AccountName { get; set; }

        [Parameter(Position = 1, ParameterSetName = UploadAndActivateSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Specifies the name of the resource group that contains the Batch account.")]
        [Parameter(Position = 1, ParameterSetName = ActivateOnlySet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Specifies the name of the resource group that contains the Batch account.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 2, ParameterSetName = UploadAndActivateSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Specifies the id of the application.")]
        [Parameter(Position = 2, ParameterSetName = ActivateOnlySet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Specifies the id of the application.")]
        [ValidateNotNullOrEmpty]
        public string ApplicationId { get; set; }

        [Parameter(Position = 3, ParameterSetName = UploadAndActivateSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Specifies the version of the application.")]
        [Parameter(Position = 3, ParameterSetName = ActivateOnlySet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Specifies the version of the application.")]
        [ValidateNotNullOrEmpty]
        public string ApplicationVersion { get; set; }

        [Parameter(Position = 4, ParameterSetName = UploadAndActivateSet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Specifies the format of the application package binary file.")]
        [Parameter(Position = 4, ParameterSetName = ActivateOnlySet, ValueFromPipelineByPropertyName = true, Mandatory = true, HelpMessage = "Specifies the format of the application package binary file.")]
        [ValidateNotNullOrEmpty]
        public string Format { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = UploadAndActivateSet, Mandatory = true, HelpMessage = "Specifies the file path of the application that will be uploaded to Azure Storage.")]
        [ValidateNotNullOrEmpty]
        public string FilePath { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = ActivateOnlySet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter ActivateOnly { get; set; }

        public override void ExecuteCmdlet()
        {
            PSApplicationPackage response = BatchClient.UploadAndActivateApplicationPackage(
                this.ResourceGroupName,
                this.AccountName,
                this.ApplicationId,
                this.ApplicationVersion,
                this.FilePath,
                this.Format,
                this.ActivateOnly.IsPresent);
            WriteObject(response);
        }
    }
}
