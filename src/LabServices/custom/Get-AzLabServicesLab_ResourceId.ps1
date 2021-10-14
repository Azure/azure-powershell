function Get-AzLabServicesLab_ResourceId {
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
        $PSBoundParameters = & $PSScriptRoot\Utilities\HandleLabResourceId.ps1 -ResourceId $ResourceId

        if ($PSBoundParameters) {
            return Az.LabServices.private\Get-AzLabServicesLab_Get @PSBoundParameters
        } else {
            Write-Error -Message "Error: Invalid Lab Resource Id." -ErrorAction Stop            
        }
       
    }
}