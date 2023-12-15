<#
.Synopsis
The operation to add a network interface to a virtual machine. 

.Description
The operation to add a network interface to a virtual machine. 


.Outputs
Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Models.Api20230901Preview.IVirtualMachineInstance
.Link
https://learn.microsoft.com/powershell/module/az.stackhcivm/add-azstackhcivmvirtualmachinenetworkinterface
#>

function Add-AzStackHCIVMVirtualMachineNetworkInterface {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.StackHciVM.Models.IVirtualMachineInstance])]
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
        # The ARM Id of the Virtual Machine
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
        # NetworkInterfaces - list of network interfaces to be attached to the virtual machine in id format
        ${NicId},
      
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
        [System.String[]]
        # NetworkInterfaces - list of network interfaces to be attached to the virtual machine in name format
        ${NicName},
    
        [Parameter(ParameterSetName='ByResourceId')]
        [Parameter(ParameterSetName='ByName')]
        [AllowEmptyCollection()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Body')]
        [System.String]
        # Resource Group of the Network Interfaces
        ${NicResourceGroup},

        
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},
    
        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},
    
        [Parameter(DontShow)]
        [Microsoft.Azure.PowerShell.Cmdlets.StackHCIVM.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials}
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
        if ($NicId){
            foreach ($NId in $NicId){
                if ($NId -notmatch $nicRegex){
                    Write-Error "Invalid Nic Id provided: $NId." -ErrorAction Stop
                }
                $Nic = @{Id = $NId}
                [void]$NetworkProfileNetworkInterface.Add($Nic)
            }
    
            $null = $PSBoundParameters.Remove("NicId")
           
        } elseif ($NicName){
            $rg = $ResourceGroupName
            if($NicResourceGroup){
              $rg = $NicResourceGroup
            }
    
            foreach ($NName in $NicName){
                $NicIdNew = "/subscriptions/$SubscriptionId/resourceGroups/$rg/providers/Microsoft.AzureStackHCI/networkinterfaces/$NName"
                $Nic = @{Id = $NicIdNew}
                [void]$NetworkProfileNetworkInterface.Add($Nic)
            }
    
            $null = $PSBoundParameters.Remove("NicName")
            $null = $PSBoundParameters.Remove("NicResourceGroup")
           
        }
    
        $vm = Az.StackHCIVM.internal\Get-AzStackHCIVMVirtualMachine @PSBoundParameters
        $nics = $vm.NetworkProfileNetworkInterface
    
        foreach ($nic in $nics){
            $Nic= @{Id = $nic.Id}
            [void]$NetworkProfileNetworkInterface.Add($Nic)
        }
    
        $PSBoundParameters.Add('NetworkProfileNetworkInterface',  $NetworkProfileNetworkInterface)
        return Az.StackHCIVM.internal\Update-AzStackHCIVMVirtualMachine @PSBoundParameters
    }