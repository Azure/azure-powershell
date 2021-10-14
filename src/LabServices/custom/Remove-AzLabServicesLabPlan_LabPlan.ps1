function Remove-AzLabServicesLabPlan_LabPlan {
[OutputType([System.Boolean])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
param(
    [Parameter(Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.LabPlan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
    ${LabPlan},

    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob}
)

process {
    $PSBoundParameters = $LabPlan.BindResourceParameters($PSBoundParameters)
    $PSBoundParameters.Remove("LabPlan") > $null
    $PSBoundParameters.Remove("Name") > $null
    $PSBoundParameters.Add("Name", $PSBoundParameters.LabPlanName)
    $PSBoundParameters.Remove("LabPlanName") > $null
    return Az.LabServices\Remove-AzLabServicesLabPlan @PSBoundParameters
}

}

