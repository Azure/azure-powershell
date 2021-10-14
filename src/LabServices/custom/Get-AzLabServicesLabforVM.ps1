function Get-AzLabServicesLabForVM {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.ILab])]
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
        ${DefaultProfile}        
    )
    
    process {
        $PSBoundParameters = & $PSScriptRoot\Utilities\HandleVMResourceId.ps1 -ResourceId $ResourceId

        if ($PSBoundParameters) {
            $PSBoundParameters.Remove("VirtualMachineName") > $null
            $PSBoundParameters.Add("Name", $PSBoundParameters.LabName)
            $PSBoundParameters.Remove("LabName") > $null

            return Az.LabServices.private\Get-AzLabServicesLab_Get @PSBoundParameters
        } else {
            Write-Error -Message "Error: Invalid Virtual Machine Resource Id." -ErrorAction Stop
        }
    }
}