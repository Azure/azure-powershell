function Reset-AzLabServicesVMPassword_VM {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IVirtualMachine])]
    [CmdletBinding(PositionalBinding=$false)]
    param(
        [Parameter(Mandatory, ValueFromPipeline)]
        [Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.VirtualMachine]
        ${VM},
  
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
        return Az.LabServices\Reset-AzLabServicesVMPassword -ResourceId $VM.Id -Username $Username -Password $Password
    }
}
    