function Remove-AzLabServicesLab_LabPlan {
[OutputType([System.Boolean])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.LabPlan]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
    ${LabPlan},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
    [System.String]
    # The name of the user that uniqely identifies it within containing lab.
    # Used in resource URIs.
    ${Name},

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
    if ($LabPlan.Type -eq "Microsoft.LabServices/labPlans") {
        $PSBoundParameters = $LabPlan.BindResourceParameters($PSBoundParameters)

        $PSBoundParameters.Remove("LabPlan") > $null
        $PSBoundParameters.Remove("LabPlanName") > $null
        return Az.LabServices\Remove-AzLabServicesLab @PSBoundParameters
    } else {
        Write-Error -Message "Error: Invalid Lab Plan Object." -ErrorAction Stop
    }
}

}
