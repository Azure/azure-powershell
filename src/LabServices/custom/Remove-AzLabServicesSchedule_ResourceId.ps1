function Remove-AzLabServicesSchedule_ResourceId {
[OutputType([System.Boolean])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
param(
    [Parameter(Mandatory)]
    [System.String]
    ${ResourceId},

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
    $PSBoundParameters = & $PSScriptRoot\Utilities\HandleScheduleResourceId.ps1 -ResourceId $ResourceId

    if ($PSBoundParameters) {
        return Az.LabServices\Remove-AzLabServicesSchedule @PSBoundParameters
    } else {
        Write-Error -Message "Error: Invalid Schedule Resource Id." -ErrorAction Stop
    }
}

}
