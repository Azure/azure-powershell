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

using Microsoft.WindowsAzure.Commands.Common;
using Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel;
using Microsoft.WindowsAzure.Commands.Storage;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Management.Storage
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "StorageBlobQueryConfig", DefaultParameterSetName = CsvParameterSet), OutputType(typeof(PSBlobQueryTextConfiguration))]
    public class NewAzStorageBlobQueryConfigCommand : AzureDataCmdlet
    {
        /// <summary>
        /// default parameter set name
        /// </summary>
        private const string CsvParameterSet = "Csv";

        /// <summary>
        /// Json parameter set name
        /// </summary>
        private const string JsonParameterSet = "Json";

        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "Indicate to create a Blob Query Configuration for CSV.", 
            ParameterSetName = CsvParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AsCsv { get; set; }

        [Parameter(Mandatory = true,
            Position = 0,
            HelpMessage = "Indicate to create a Blob Query Configuration for Json.", 
            ParameterSetName = JsonParameterSet)]
        [ValidateNotNullOrEmpty]
        public SwitchParameter AsJson { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Optional. The string used to separate records.", ParameterSetName = CsvParameterSet)]
        [Parameter(Mandatory = false, HelpMessage = "Optional. The string used to separate records.", ParameterSetName = JsonParameterSet)]
        public string RecordSeparator { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Optional. The string used to separate columns.", ParameterSetName = CsvParameterSet)]
        public string ColumnSeparator { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Optional. The char used to quote a specific field.", ParameterSetName = CsvParameterSet)]
        public char QuotationCharacter
        {
            get
            {
                if (quotationCharacter != null)
                {
                    return quotationCharacter.Value;
                }
                else
                {
                    return '\0';
                }
            }
            set
            {
                quotationCharacter = value;
            }
        }
        public char? quotationCharacter = null;

        [Parameter(Mandatory = false, HelpMessage = "Optional. The char used as an escape character.", ParameterSetName = CsvParameterSet)]
        public char? EscapeCharacter
        {
            get
            {
                if (escapeCharacter != null)
                {
                    return escapeCharacter.Value;
                }
                else
                {
                    return '\0';
                }
            }
            set
            {
                escapeCharacter = value;
            }
        }
        public char? escapeCharacter = null;

        [Parameter(Mandatory = false, HelpMessage = "Optional. Indicate it represent the data has headers.", ParameterSetName = CsvParameterSet)]
        public SwitchParameter HasHeader { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public virtual SwitchParameter AsJob { get; set; }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            if (this.AsJson.IsPresent) //Json
            {
                PSBlobQueryTextConfiguration queryConfig = new PSBlobQueryJsonTextConfiguration()
                {
                    RecordSeparator = this.RecordSeparator,
                    Type = BlobQueryConfigType.Json
                };
                WriteObject(queryConfig);
            }
            else // Csv
            {
                PSBlobQueryTextConfiguration queryConfig = new PSBlobQueryCsvTextConfiguration()
                {
                    RecordSeparator = this.RecordSeparator,
                    ColumnSeparator = this.ColumnSeparator,
                    QuotationCharacter = this.quotationCharacter,
                    EscapeCharacter = this.escapeCharacter,
                    HasHeaders = this.HasHeader.IsPresent,
                    Type = BlobQueryConfigType.Csv
                };
                WriteObject(queryConfig);
            }
        }
    }
}
