function Remove-AzStackHciVMVirtualMachineNic {
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
    # NetworkInterfaces - list of network interfaces to be attached from  the virtual machine in id format. 
    ${NicIds},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String[]]
    # NetworkInterfaces - list of network interfaces to be removed from the virtual machine in name format.
    ${NicNames},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Category('Body')]
    [System.String]
    # NetworkInterfaces - resource group of the network interfaces 
    ${NicResourceGroup}
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
    
    if ($NicIds){
        $NicIds = $PSBoundParameters['NicIds']
        $null = $PSBoundParameters.Remove("NicIds")

        $VM = Az.StackHciVM\Get-AzStackHciVMVirtualMachine @PSBoundParameters
        $NetworkProfileNetworkInterface =  $VM.NetworkProfileNetworkInterface
        
        foreach ($NicId in $NicIds){
            if ($NicId -in $NetworkProfileNetworkInterface){
                $NetworkProfileNetworkInterface.Remove($NicId)
            } else {
                Write-Error "Network Interface not currently attached: $NicId"
            }
        }

        $PSBoundParameters.Add('NetworkProfileNetworkInterface',  $NetworkProfileNetworkInterface)
    } elseif ($NicNames){
        $rg = $ResourceGroupName
        if($NicResourceGroup){
          $rg = $NicResourceGroup
        }

        $null = $PSBoundParameters.Remove("NicNames")
        $null = $PSBoundParameters.Remove("NicResourceGroup")

        $VM = Az.StackHciVM\Get-AzStackHciVMVirtualMachine @PSBoundParameters
        $NetworkProfileNetworkInterface =  $VM.NetworkProfileNetworkInterface
        
        foreach ($NicName in $NicNames){
            $NicId = "/subscriptions/$SubscriptionId/resourceGroups/$rg/providers/Microsoft.AzureStackHCI/networkinterfaces/$NicName"
            if ($NicId -in $NetworkProfileNetworkInterface){
                $NetworkProfileNetworkInterface.Remove($NicId)
            } else {
                Write-Error "Network Interface not currently attached: $NicId"
            }
        }

        $PSBoundParameters.Add('NetworkProfileNetworkInterface',  $NetworkProfileNetworkInterface)
    }

    return Az.StackHciVM\Update-AzStackHciVMVirtualMachine @PSBoundParameters
}