function Get-AzLabServicesUserVM_User {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachine])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.User]
        ${User},
  
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile}
    )
    
    process {
            $PSBoundParameters = $User.BindResourceParameters($PSBoundParameters)
            $PSBoundParameters.Email = $user.Email
            $PSBoundParameters.Remove("UserName") > $null
            $PSBoundParameters.Remove("User") > $null

            return Az.LabServices\Get-AzLabServicesUserVM @PSBoundParameters
    }
    
}
    