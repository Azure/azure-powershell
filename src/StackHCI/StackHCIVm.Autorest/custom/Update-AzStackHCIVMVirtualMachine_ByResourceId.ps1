
function Update-AzStackHciVMVirtualMachine_ByResourceId {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20221215Preview.IVirtualMachines])]
[CmdletBinding(PositionalBinding=$false)]

param(
 
    
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The ARM Resource ID of the virtual machine.
    ${ResourceId},

   
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20221215Preview.IGalleryImagesUpdateRequestTags]))]
    [System.Collections.Hashtable]
    # Resource tags
    ${Tags},

    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile}

)
  process {

    if ($ResourceId -match $vmRegex){
        
        $subscriptionId = $($Matches['subscriptionId'])
        $resourceGroupName = $($Matches['resourceGroupName'])
        $resourceName = $($Matches['vmName'])
        $null = $PSBoundParameters.Remove("ResourceId")
        $PSBoundParameters.Add("Name", $resourceName)
        $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
        $null = $PSBoundParameters.Remove("SubscriptionId")
        $PSBoundParameters.Add("SubscriptionId", $subscriptionId)

        return  Az.StackHciVM\Update-AzStackHciVMVirtualMachine @PSBoundParameters

    } else {             
        Write-Error "Resource ID is invalid: $ResourceId"
    }
        
    }
} 