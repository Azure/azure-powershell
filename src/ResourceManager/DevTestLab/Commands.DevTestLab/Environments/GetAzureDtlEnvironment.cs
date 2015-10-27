using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using Microsoft.Azure.Management.DevTestLab.Models;
using Microsoft.Azure.Management.DevTestLab;
using Environment = Microsoft.Azure.Management.DevTestLab.Models.Environment;
using Microsoft.Azure.Commands.DevTestLab.Models;

namespace DevTestLab.PS
{
    [Cmdlet(VerbsCommon.Get, "AzureDtlEnvironment", DefaultParameterSetName = "FilterNone")]
    [OutputType(typeof(IEnumerable<Environment>), typeof(Environment))]
    public class GetAzureDtlEnvironment : DevTestLabBaseCmdlet
    {
        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Optional Parameters

        // We support three parameter sets:
        // 1: No parameters: Get all environments in current subscription.
        // 2: Only ResourceGroupName specified: Gets all environments in that resource group.
        // 3: Both LabName and lab's ResourceGroupName are specified: Gets all environments in that lab.
        // 4: Both EnvironmentName and ResourceGroupName are specified: Gets the specific environment.

        /// <summary>
        /// <para type="description">@TODO</para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "FilterByEnvironmentName")]
        [ValidateNotNullOrEmpty]
        public string EnvironmentName { get; set; }

        /// <summary>
        /// <para type="description">@TODO</para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "FilterByLabName")]
        [ValidateNotNullOrEmpty]
        public string LabName { get; set; }

        /// <summary>
        /// <para type="description">@TODO</para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "FilterByLabName")]
        [Parameter(Mandatory = true, ParameterSetName = "FilterByEnvironmentName")]
        [Parameter(Mandatory = true, ParameterSetName = "FilterByResourceGroupName")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        #endregion // Optional Parameters

        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Cmdlet Overrides

        /// <summary>
        /// Implements the Get-AzureDTLLab cmdlet.
        /// </summary>
        protected override void ProcessRecord()
        {
            WriteVerbose("Processing StartTime : " + DateTime.UtcNow.ToString());

            switch (ParameterSetName)
            {
                case "FilterByEnvironmentName":
                    WriteObject(this.DtlClient.GetEnvironment(this.ResourceGroupName, this.EnvironmentName));
                    break;

                case "FilterByResourceGroupName":
                    WriteObject(this.DtlClient.ListEnvironmentByResourceGroup(this.ResourceGroupName));
                    break;

                case "FilterByLabName":
                    WriteObject(this.DtlClient.ListEnvironmentByLab(this.ResourceGroupName, this.LabName));
                    break;

                case "FilterNone":
                default:
                    WriteObject(this.DtlClient.ListEnvironments());
                    break;
            }

            WriteVerbose("Processing EndTime : " + DateTime.UtcNow.ToString());
        }

        #endregion // Cmdlet Overrides

        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}
