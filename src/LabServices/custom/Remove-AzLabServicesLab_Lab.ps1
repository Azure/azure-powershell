function Remove-AzLabServicesLab_Lab {
[OutputType([System.Boolean])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
param(
    [Parameter(Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.Lab]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Path')]
    ${Lab},

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
    $PSBoundParameters = $Lab.BindResourceParameters($PSBoundParameters)

    $PSBoundParameters.Remove("Lab") > $null
    return Az.LabServices\Remove-AzLabServicesLab @PSBoundParameters
}

}
