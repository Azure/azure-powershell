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

using Azure.Storage.Blobs.Models;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageBlobQueryArrowField"), OutputType(typeof(PSBlobQueryArrowField))]
    public class NewAzStorageBlobQueryArrowFieldCommand : AzureDataCmdlet
    {

        //[Parameter(Mandatory = true, HelpMessage = "The type of the field. Required. ")]
        //public string Type { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The type of the field. Required. ")]
        [PSArgumentCompleter("Int64", "Bool", "Timestamp", "String", "Double", "Decimal")]
        [ValidateNotNullOrEmpty]
        public string Type
        {
            get
            {
                return type is null ? null : type.Value.ToString();
            }

            set
            {
                type = ((BlobQueryArrowFieldType)Enum.Parse(typeof(BlobQueryArrowFieldType), value, true));
            }
        }
        private BlobQueryArrowFieldType? type = null;

        [Parameter(Mandatory = false, HelpMessage = "The name of the field. Optional. ")]
        [ValidateNotNull]
        public string Name { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "The precision of the field. Required if Type is Decimal.")]
        public int Precision
        { get
            {
                return precision is null ? 0 : precision.Value;
            }
            set
            {
                precision = value;
            }
        }
        private int? precision;

        [Parameter(Mandatory = false, HelpMessage = "The scale  of the field. Required if Type is Decimal.")]
        public int Scale
        {
            get
            {
                return scale is null ? 0 : scale.Value;
            }
            set
            {
                scale = value;
            }
        }
        private int? scale;

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            PSBlobQueryArrowField arrowField = new PSBlobQueryArrowField()
            {
                Name = this.Name
            };

            if (this.type != null)
            {
                arrowField.Type = this.type.Value;
            }

            if (this.precision != null)
            {
                arrowField.Precision = this.precision.Value;
            }

            if (this.scale != null)
            {
                arrowField.Scale = this.scale.Value;
            }

            WriteObject(arrowField);
        }
    }
}
