function Update-AzLabServicesPlanImage_ResourceId {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IImage])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [System.String]
    ${ResourceId},

    [Parameter(Mandatory)]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState])]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState]
    # Is the image enabled
    ${EnabledState},

    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
)

process {
    $resourceHash = & $PSScriptRoot\Utilities\HandleImageResourceId.ps1 -ResourceId $ResourceId
    if ($resourceHash) {
        $resourceHash.Keys | ForEach-Object {
            $PSBoundParameters.Add($_, $($resourceHash[$_]))
        }
        $PSBoundParameters.Remove("ResourceId") > $null
        return Az.LabServices\Update-AzLabServicesPlanImage @PSBoundParameters
    } else {
        Write-Error -Message "Error: Invalid Image Resource Id." -ErrorAction Stop
    }
}

}
