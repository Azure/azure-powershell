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

namespace Microsoft.Azure.Commands.Compute
{
    /// <summary>
    /// Helper cmdlet to construct instance of Storage settings class
    /// </summary>
    [Cmdlet(
         VerbsCommon.New,
         AzureRmVMSqlServerStorageConfigNoun),
     OutputType(
         typeof(StorageSettings))]
    public class NewAzureRmVMSqlServerStorageConfig : PSCmdlet
    {
        protected const string AzureRmVMSqlServerStorageConfigNoun = "AzureRmVMSqlServerStorageConfig";

        [Parameter(
            Mandatory = false,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "If set, it will create a new virtual disk. Otherwise, it will expand the existing one.")]
        [ValidateNotNullOrEmpty]
        public SwitchParameter NewStorage { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 1,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The size of virtual disk to be created.")]
        [ValidateNotNullOrEmpty]
        public int SizeInTB { get; set; }

        [Parameter(
           Mandatory = true,
           Position = 2,
           ValueFromPipelineByPropertyName = true,
           HelpMessage = "The type of workload which can be general, DW or OLTP.")]
        [ValidateNotNullOrEmpty]
        [ValidateSetAttribute(new string[] { "General", "DW", "OLTP" })]
        public string WorkLoadType { get; set; }

        /// <summary>
        /// Creates and returns <see cref="StorageSettings"/> object.
        /// </summary>
        protected override void ProcessRecord()
        {
            StorageSettings storageSettings = new StorageSettings();
            storageSettings.NewStorage = (NewStorage.IsPresent) ? NewStorage.ToBool() : false;
            storageSettings.SizeInTB = SizeInTB;
            storageSettings.WorkLoadType = WorkLoadType;
            WriteObject(storageSettings);
        }
    }
}
