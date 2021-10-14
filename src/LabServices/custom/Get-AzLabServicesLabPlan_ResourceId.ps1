function Get-AzLabServicesLabPlan_ResourceId {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILabPlan])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory, ValueFromPipeline)]
    [System.String]
    ${ResourceId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
)

process {

    $PSBoundParameters = & $PSScriptRoot\Utilities\HandleLabPlanResourceId.ps1 -ResourceId $ResourceId

    if ($PSBoundParameters) {
        return Az.LabServices\Get-AzLabServicesLabPlan @PSBoundParameters
    } else {
        Write-Error -Message "Error: Invalid Lab Plan Resource Id." -ErrorAction Stop
    }
}

}
