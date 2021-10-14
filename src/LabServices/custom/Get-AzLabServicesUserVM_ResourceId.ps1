function Get-AzLabServicesUserVM_ResourceId {
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
        & $PSScriptRoot\Utilities\VerificationRegex.ps1
        if ($ResourceId -match $userRegex){
            $user = Get-AzLabServicesUser -ResourceId $ResourceId

            if ($user) {
                $PSBoundParameters.Remove("ResourceId") > $null
                $PSBoundParameters.Add("User", $user)
                return Az.LabServices\Get-AzLabServicesUserVM @PSBoundParameters
            }
            else {
                Write-Error -Message "No User exists for that id." -ErrorAction Stop
            }
        } else {
            Write-Error -Message "Error: Invalid User Resource Id." -ErrorAction Stop
        }
    }
    
}
    