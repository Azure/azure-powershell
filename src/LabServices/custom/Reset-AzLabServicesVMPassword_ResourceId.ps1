function Reset-AzLabServicesVMPassword_ResourceId {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachine])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter(Mandatory)]
        [System.String]
        ${ResourceId},
  
        [Parameter()]
        [System.String]
        ${Username},

        [Parameter(Mandatory)]
        [System.String]
        ${Password},

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
            return Az.LabServices\Reset-AzLabServicesVMPassword @PSBoundParameters
        } else {
            Write-Error -Message "Error: Invalid VM Resource Id." -ErrorAction Stop
        }

    }
}
    