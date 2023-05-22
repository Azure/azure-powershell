function Add-AzAzureStackHciVirtualMachineDataDisk {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Models.Api20221215Preview.IVirtualMachines])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Alias('VirtualMachineName')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # Name of the virtual machine
    ${Name},

    [Parameter(ParameterSetName='ByName', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='ByResourceId', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [System.String]
    # The ID of the target subscription.
    ${ResourceId},

    [Parameter(ParameterSetName='ByName')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String[]]
    # NetworkInterfaces - list of network interfaces to be attached to the virtual machine
    ${NicIds},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String[]]
    # NetworkInterfaces - list of network interfaces to be attached to the virtual machine
    ${NicNames},

    [Parameter(ParameterSetName='ByResourceId')]
    [Parameter(ParameterSetName='ByName')]
    [AllowEmptyCollection()]
    [Microsoft.Azure.PowerShell.Cmdlets.AzureStackHCI.Category('Body')]
    [System.String]
    # NetworkInterfaces - list of network interfaces to be attached to the virtual machine
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

        $VM = Az.AzureStackHci\Get-AzAzureStackHciVirtualMachine @PSBoundParameters
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

        $VM = Az.AzureStackHci\Get-AzAzureStackHciVirtualMachine @PSBoundParameters
        $NetworkProfileNetworkInterface =  $VM.NetworkProfileNetworkInterface
        
        foreach ($NicName in $NicNames){
            $NicId = "/subscriptions/$SubscriptionId/resourceGroups/$rg/providers/Microsoft.AzureStackHCI/networkinterfaces/$NicName"
            if ($NicId -in $NetworkProfileNetworkInterface){
                $NetworkProfileNetworkInterface.Remove($NicId)
            } else {
                Write-Error "Network Interface not currently attached: $NicId"
            }
        }

        $null = $PSBoundParameters.Remove("NicNames")
        $null = $PSBoundParameters.Remove("NicResourceGroup")
        $PSBoundParameters.Add('NetworkProfileNetworkInterface',  $NetworkProfileNetworkInterface)
    }

    return Az.AzureStackHCI\Update-AzAzureStackHciVirtualMachine @PSBoundParameters
}