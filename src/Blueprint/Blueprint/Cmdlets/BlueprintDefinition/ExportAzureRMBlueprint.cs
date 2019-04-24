using System;
using System.Collections.Generic;
using System.IO;
using System.Management.Automation;
using System.Text;
using Microsoft.Azure.Commands.Blueprint.Common;
using Microsoft.Azure.Commands.Blueprint.Models;

namespace Microsoft.Azure.Commands.Blueprint.Cmdlets
{
    [Cmdlet("Export", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "Blueprint", DefaultParameterSetName =
         BlueprintConstants.ParameterSetNames.SubscriptionScope), OutputType(typeof(string))]
    public class ExportAzureRmBlueprint : BlueprintCmdletBase
    {
        private const string ExportToFileParamSet = "ExportToFile";
        private const string ExportToStringParamSet = "ExportToJSON";

        [Parameter(
            Mandatory = true,
            HelpMessage = "The Blueprint definition object to export.",
            ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public PSBlueprintBase Blueprint { get; set; }

        [Parameter(
            ParameterSetName = ExportToFileParamSet,
            Mandatory = true,
            HelpMessage = "Path to a file on disk where to export the Blueprint definition in JSON format.")]
        [ValidateNotNullOrEmpty]
        public string OutputFile { get; set; }

        [Parameter(
            ParameterSetName = ExportToStringParamSet,
            Mandatory = true,
            HelpMessage = "The actual Blueprint definition as a JSON string printed on screen.")]
        public SwitchParameter ToJsonString { get; set; }

        /// <summary>
        /// Gets or sets a value that indicates if the user should be prompted for confirmation.
        /// </summary>
        [Parameter(
            Mandatory = false,
            HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        public override void ExecuteCmdlet()
        {
            string serializedDefinition =
                BlueprintClient.GetBlueprintDefinitionJsonFromObject(Blueprint);

            if (!string.IsNullOrWhiteSpace(this.OutputFile))
            {
                var currentPath = this.SessionState.Path.CurrentFileSystemLocation.Path;
                var definitionFileFullPath =
                    Path.IsPathRooted(this.OutputFile) ?
                        this.OutputFile :
                        Path.Combine(currentPath, this.OutputFile);

                bool fileExisting = File.Exists(definitionFileFullPath);
                this.ConfirmAction(
                    this.Force || !fileExisting,
                    "Want to overwriting the output file?",
                    "Overwriting the output file",
                    definitionFileFullPath,
                    () => File.WriteAllText(definitionFileFullPath, serializedDefinition));
            }
            else
            {
                this.WriteObject(serializedDefinition);
            }

            //Let's see if we can create a new blueprint from what we exported.

        }
    }
}
