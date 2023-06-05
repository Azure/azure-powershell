function Remove-AzStackHCIVMVirtualMachineDataDisk {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.Api20221215Preview.IVirtualMachines])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Alias('VirtualMachineName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [System.String]
    # Name of the virtual machine
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByResourceId', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${ResourceId},

    [Parameter(ParameterSetName='ByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String[]]
    # Data Disks - list of data disks to be attached to the virtual machine
    ${DataDiskIds},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String[]]
    # 
    ${DataDiskNames},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
    [System.String]
    # 
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

    $VM = Az.StackHCIVM\Get-AzStackHCIVMVirtualMachine @PSBoundParameters
    $StorageProfileDataDisk =  $VM.StorageProfileDataDisk
    if ($DataDiskIds){
        $DataDisks = $PSBoundParameters['DataDiskIds']
        $null = $PSBoundParameters.Remove("DataDiskIds")

        $VM = Az.StackHCIVM\Get-AzStackHCIVMVirtualMachine @PSBoundParameters
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

        $VM = Az.StackHCIVM\Get-AzStackHCIVMVirtualMachine @PSBoundParameters
        $StorageProfileDataDisk =  $VM.StorageProfileDataDisk

        foreach ($DataDiskName in $DataDiskNames){
            $DataDiskId = "/subscriptions/$SubscriptionId/resourceGroups/$rg/providers/Microsoft.StackHCIVM/virtualharddisks/$DataDiskName"
            if ($DataDiskId -in $StorageProfileDataDisk){
                $StorageProfileDataDisk.Remove($DataDiskId)
            } else {
                Write-Error "Data Disk is not currently attached: $DataDisk"
            }
        }

        $null = $PSBoundParameters.Remove("DataDiskNames")
        $null = $PSBoundParameters.Remove("DataDiskResourceGroup")
        $PSBoundParameters.Add('StorageProfileDataDisk',  $StorageProfileDataDisk)
    }

    return Az.StackHCIVM\Update-AzStackHCIVMVirtualMachine @PSBoundParameters
}