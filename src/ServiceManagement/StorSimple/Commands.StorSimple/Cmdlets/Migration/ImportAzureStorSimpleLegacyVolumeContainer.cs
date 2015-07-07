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

using Microsoft.WindowsAzure.Commands.StorSimple.Properties;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    [Cmdlet(VerbsData.Import, "AzureStorSimpleLegacyVolumeContainer")]
    public class ImportAzureStorSimpleLegacyVolumeContainer : StorSimpleCmdletBase
    {
        [Parameter(Mandatory = true, Position = 0, HelpMessage = StorSimpleCmdletHelpMessage.MigrationConfigId)]
        [ValidateNotNullOrEmpty]
        public string LegacyConfigId { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = StorSimpleCmdletParameterSet.MigrateSpecificContainer,
            HelpMessage = StorSimpleCmdletHelpMessage.MigrationLegacyDataContainers)]
        public string[] LegacyContainerNames { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = StorSimpleCmdletParameterSet.MigrateAllContainer,
            HelpMessage = StorSimpleCmdletHelpMessage.MigrationAllContainers)]
        public SwitchParameter All { get; set; }

        [Parameter(Mandatory = false, Position = 2,
            HelpMessage = StorSimpleCmdletHelpMessage.MigrationImportDCWithSkipACRs)]
        public SwitchParameter SkipACRs { get; set; }

        [Parameter(Mandatory = false, Position = 3, HelpMessage = StorSimpleCmdletHelpMessage.MigrationImportDCByForce)]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            try
            {
                var importDataContainerRequest = new MigrationImportDataContainerRequest();
                switch (ParameterSetName)
                {
                    case StorSimpleCmdletParameterSet.MigrateAllContainer:
                        {
                            importDataContainerRequest.DataContainerNames = new List<string>();
                            break;
                        }
                    case StorSimpleCmdletParameterSet.MigrateSpecificContainer:
                        {
                            importDataContainerRequest.DataContainerNames =
                                    new List<string>(LegacyContainerNames.ToList().Distinct(
                                        StringComparer.InvariantCultureIgnoreCase));
                            break;
                        }
                    default:
                        {
                            // unexpected code path.
                            throw new ParameterBindingException(
                                string.Format(Resources.MigrationParameterSetNotFound, ParameterSetName));
                        }
                }

                importDataContainerRequest.ForceOnOtherDevice = Force.IsPresent;
                importDataContainerRequest.SkipACRs = SkipACRs.IsPresent;

                var migrationJobStatus = StorSimpleClient.MigrationImportDataContainer(LegacyConfigId,
                    importDataContainerRequest);
                MigrationCommonModelFormatter opFormatter = new MigrationCommonModelFormatter();
                WriteObject(opFormatter.GetResultMessage(Resources.MigrationImportDataContainerSuccessMessage,
                    migrationJobStatus));
            }
            catch (Exception except)
            {
                this.HandleException(except);
            }
        }
    }
}