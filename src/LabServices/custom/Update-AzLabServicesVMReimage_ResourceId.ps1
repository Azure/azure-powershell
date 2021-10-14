function Update-AzLabServicesVMReimage_ResourceId {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachine])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [System.String]
    ${ResourceId},

    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}
)

process {
    $PSBoundParameters = & $PSScriptRoot\Utilities\HandleVMResourceId.ps1 -ResourceId $ResourceId

    if ($PSBoundParameters) {
        return Az.LabServices\Update-AzLabServicesVMReimage @PSBoundParameters
    } else {
        Write-Error -Message "Error: Invalid Virtual Machine Resource Id." -ErrorAction Stop
    }
}

}
