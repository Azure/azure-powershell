function Remove-AzLabServicesUser_ResourceId {
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
    $PSBoundParameters = & $PSScriptRoot\Utilities\HandleUserResourceId.ps1 -ResourceId $ResourceId

    $PSBoundParameters.Remove("Name") > $null
    $PSBoundParameters.Add("Name", $PSBoundParameters.UserName)
    $PSBoundParameters.Remove("UserName") > $null


    if ($PSBoundParameters) {
        return Az.LabServices\Remove-AzLabServicesUser @PSBoundParameters
    } else {
        Write-Error -Message "Error: Invalid User Resource Id." -ErrorAction Stop
    }
}

}
