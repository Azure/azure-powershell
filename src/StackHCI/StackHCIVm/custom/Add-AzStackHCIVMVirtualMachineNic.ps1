function Add-AzStackHciVMVirtualMachineNic {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.Api20230901Preview.IVirtualMachineInstance])]
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
        # The ARM Id of the Virtual Machine
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
        # NetworkInterfaces - list of network interfaces to be attached to the virtual machine in id format
        ${NicIds},
      
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
        [System.String[]]
        # NetworkInterfaces - list of network interfaces to be attached to the virtual machine in name format
        ${NicNames},
    
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
        [System.String]
        # Resource Group of the Network Interfaces
        ${NicResourceGroup}
    )
    
    if (($ResourceId -match $vmRegex) -or ($Name -and $ResourceGroupName -and $SubscriptionId)){
        if ($ResourceId -match $vmRegex){
            $SubscriptionId = $($Matches['subscriptionId'])
            $ResourceGroupName = $($Matches['resourceGroupName'])
            $Name = $($Matches['machineName'])
        }
        $null = $PSBoundParameters.Remove("Name")
        $null = $PSBoundParameters.Remove("ResourceGroupName")
        $null = $PSBoundParameters.Remove("SubscriptionId")
        $null = $PSBoundParameters.Remove("ResourceId")
        $resourceUri = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + $ResourceGroupName + "/providers/Microsoft.HybridCompute/machines/" + $Name
        $PSBoundParameters.Add("ResourceUri", $resourceUri)
        } else {
            Write-Error "One or more input parameters are invalid. Resource ID is: $ResourceId, name is $name, resource group name is $resourcegroupname, subscription id is $subscriptionid"
        }
    
        $NetworkProfileNetworkInterface =  [System.Collections.ArrayList]::new()
        if ($NicIds){
            foreach ($NicId in $NicIds){
                if ($NicId -notmatch $nicRegex){
                    Write-Error "Invalid Nic Id provided: $NicId." -ErrorAction Stop
                }
                $Nic = @{Id = $NicId}
                [void]$NetworkProfileNetworkInterface.Add($Nic)
            }
    
            $null = $PSBoundParameters.Remove("NicIds")
           
        } elseif ($NicNames){
            $rg = $ResourceGroupName
            if($NicResourceGroup){
              $rg = $NicResourceGroup
            }
    
            foreach ($NicName in $NicNames){
                $NicId = "/subscriptions/$SubscriptionId/resourceGroups/$rg/providers/Microsoft.AzureStackHCI/networkinterfaces/$NicName"
                $Nic = @{Id = $NicId}
                [void]$NetworkProfileNetworkInterface.Add($Nic)
            }
    
            $null = $PSBoundParameters.Remove("NicNames")
            $null = $PSBoundParameters.Remove("NicResourceGroup")
           
        }
    
        $vm = Az.StackHciVM.internal\Get-AzStackHciVMVirtualMachine @PSBoundParameters
        $nics = $vm.NetworkProfileNetworkInterface
    
        foreach ($nic in $nics){
            $Nic= @{Id = $nic.Id}
            [void]$NetworkProfileNetworkInterface.Add($Nic)
        }
    
        $PSBoundParameters.Add('NetworkProfileNetworkInterface',  $NetworkProfileNetworkInterface)
        return Az.StackHciVM.internal\Update-AzStackHciVMVirtualMachine @PSBoundParameters
    }