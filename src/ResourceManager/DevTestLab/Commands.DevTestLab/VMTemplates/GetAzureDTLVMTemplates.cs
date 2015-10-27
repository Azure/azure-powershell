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
    [Cmdlet(VerbsCommon.Get, "AzureDtlVMTemplate", DefaultParameterSetName = "FilterByLabName")]
    [OutputType(typeof(IEnumerable<Environment>), typeof(Environment))]
    public class GetAzureDtlVMTemplate: DevTestLabBaseCmdlet
    {
        ///////////////////////////////////////////////////////////////////////////////////////////

        #region Optional Parameters

        // We support three parameter sets:
        // 1: Both LabName and lab's ResourceGroupName are specified: Gets all VM templates in that lab.
        // 2: LabName, lab's ResourceGroupName and VMTemplateName specified: Gets specific VM template.

        /// <summary>
        /// <para type="description">@TODO</para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "FilterByLabName")]
        [Parameter(Mandatory = true, ParameterSetName = "FilterByVMTemplateName")]
        [ValidateNotNullOrEmpty]
        public string LabName { get; set; }

        /// <summary>
        /// <para type="description">@TODO</para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "FilterByVMTemplateName")]
        [ValidateNotNullOrEmpty]
        public string VMTemplateName { get; set; }

        /// <summary>
        /// <para type="description">@TODO</para>
        /// </summary>
        [Parameter(Mandatory = true, ParameterSetName = "FilterByLabName")]
        [Parameter(Mandatory = true, ParameterSetName = "FilterByVMTemplateName")]
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
                    WriteObject(this.DtlClient.ListVMTemplatesByLab(this.LabName, this.ResourceGroupName));
                    break;

                case "FilterByVMTemplateName":
                    WriteObject(this.DtlClient.GetVMTemplate(this.LabName, this.ResourceGroupName, this.VMTemplateName));
                    break;
            }

            WriteVerbose("Processing EndTime : " + DateTime.UtcNow.ToString());
        }

        #endregion // Cmdlet Overrides

        ///////////////////////////////////////////////////////////////////////////////////////////
    }
}
