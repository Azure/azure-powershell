function Remove-AzStackHciVMVirtualMachineDataDisk {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20221215Preview.IVirtualMachines])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Alias('VirtualMachineName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # Name of the virtual machine
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByResourceId', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [System.String]
    # The ARM Resource ID of the virtual machine.
    ${ResourceId},

    [Parameter(ParameterSetName='ByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String[]]
    # Data Disks - list of data disks to be removed from  the virtual machine in id format.
    ${DataDiskIds},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String[]]
    # Data Disks - list of data disks to be removed from  the virtual machine in name format.
    ${DataDiskNames},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # Resource Group of the Data Disks.
    ${DataDiskResourceGroup}
)

  
    if ($PSCmdlet.Parameter -eq "ByResourceId"){
        if ($ResourceId -match $vmRegex){
            
            $subscriptionId = $($Matches['subscriptionId'])
            $resourceGroupName = $($Matches['resourceGroupName'])
            $resourceName = $($Matches['vmName'])
            $null = $PSBoundParameters.Remove("ResourceId")
            $PSBoundParameters.Add("Name", $resourceName)
            $PSBoundParameters.Add("ResourceGroupName", $resourceGroupName)
            $null = $PSBoundParameters.Remove("SubscriptionId")
            $PSBoundParameters.Add("SubscriptionId", $subscriptionId)

        } else {             
            Write-Error "Virtual Machine Resource ID is invalid: $ResourceId"
        }
    }



    if ($DataDiskIds){
        $DataDisks = $PSBoundParameters['DataDiskIds']
        $null = $PSBoundParameters.Remove("DataDiskIds")

        $VM = Az.StackHciVM\Get-AzStackHciVMVirtualMachine @PSBoundParameters
        $StorageProfileDataDisk =  $VM.StorageProfileDataDisk
      
        foreach ($DataDisk in $DataDisks){
            if ($DataDisk -in $StorageProfileDataDisk){
                $StorageProfileDataDisk.Remove($DataDisk)
            } else {
                Write-Error "Data Disk is not currently attached: $DataDisk"
            }
        }

        $PSBoundParameters.Add('StorageProfileDataDisk',  $StorageProfileDataDisk)

    } elseif ($DataDiskNames){
        $rg = $ResourceGroupName
        if($DataDiskResourceGroup){
          $rg = $DataDiskResourceGroup
        }

        $null = $PSBoundParameters.Remove("DataDiskNames")
        $null = $PSBoundParameters.Remove("DataDiskResourceGroup")
        
        $VM = Az.StackHciVM\Get-AzStackHciVMVirtualMachine @PSBoundParameters
        $StorageProfileDataDisk =  $VM.StorageProfileDataDisk

        foreach ($DataDiskName in $DataDiskNames){
            $DataDiskId = "/subscriptions/$SubscriptionId/resourceGroups/$rg/providers/Microsoft.AzureStackHCI/virtualharddisks/$DataDiskName"
            if ($DataDiskId -in $StorageProfileDataDisk){
                $StorageProfileDataDisk.Remove($DataDiskId)
            } else {
                Write-Error "Data Disk is not currently attached: $DataDisk"
            }
        }

       
        $PSBoundParameters.Add('StorageProfileDataDisk',  $StorageProfileDataDisk)
    }

    return Az.StackHciVM\Update-AzStackHciVMVirtualMachine @PSBoundParameters
}