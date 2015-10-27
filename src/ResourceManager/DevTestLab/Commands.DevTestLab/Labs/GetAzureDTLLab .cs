using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using Microsoft.Azure.Management.DevTestLab.Models;
using Microsoft.Azure.Management.DevTestLab;
using Microsoft.Azure.Commands.DevTestLab.Models;

namespace DevTestLab.PS
{
    [Cmdlet(VerbsCommon.Get, "AzureDtlLab", DefaultParameterSetName = "FilterNone")]
    [OutputType(typeof(IEnumerable<Lab>), typeof(Lab))]
    public class GetAzureDtlLab : DevTestLabBaseCmdlet
    {
        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Optional Parameters

        // We support three parameter sets:
        // 1: No parameters: Get all labs in current subscription.
        // 2: Only ResourceGroupName specified: Gets all labs in that resource group.
        // 3: Both LabName and ResourceGroupName are specified: Gets the specific lab.

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
                case "FilterByLabName":
                    WriteObject(this.DtlClient.GetLab(this.ResourceGroupName, this.LabName));
                    break;

                case "FilterByResourceGroupName":
                    WriteObject(this.DtlClient.ListLabsByResourceGroup(this.ResourceGroupName));
                    break;

                case "FilterNone":
                default:
                    WriteObject(this.DtlClient.ListLabs());
                    break;
            }

            WriteVerbose("Processing EndTime : " + DateTime.UtcNow.ToString());
        }

        #endregion // Cmdlet Overrides

        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}
