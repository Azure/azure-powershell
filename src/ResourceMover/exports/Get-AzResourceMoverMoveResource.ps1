
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Gets the Move Resource.
.Description
Gets the Move Resource.
.Example
PS C:\>Get-AzResourceMoverMoveResource -MoveCollectionName "PS-centralus-westcentralus-demoRMS" -ResourceGroupName "RG-MoveCollection-demoRMS"         

DependsOn                         : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Network/networkInterfaces/psdemov
                                    m111, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/PSDemoRM}
DependsOnOverride                 : {}
ErrorsPropertiesCode              : 
ErrorsPropertiesDetail            : 
ErrorsPropertiesMessage           : 
ErrorsPropertiesTarget            : 
ExistingTargetId                  : 
Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveColle
                                    ctions/PS-centralus-westcentralus-demoRMS1/moveResources/PSDemoVM
IsResolveRequired                 : False
JobStatusJobName                  : 
JobStatusJobProgress              : 
MoveStatusErrorsPropertiesCode    : 
MoveStatusErrorsPropertiesDetail  : 
MoveStatusErrorsPropertiesMessage : 
MoveStatusErrorsPropertiesTarget  : 
MoveStatusMoveState               : PreparePending
Name                              : PSDemoVM
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.VirtualMachineResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.VirtualMachineResourceSettings
TargetId                          : 
Type                              : 

DependsOn                         : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/psdemorm/providers/Microsoft.Network/virtualNetworks/psdemorm-
                                    vnet, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm/providers/microsoft.network/networksecuritygroup
                                    s/psdemovm-nsg, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm}
DependsOnOverride                 : {}
ErrorsPropertiesCode              : 
ErrorsPropertiesDetail            : 
ErrorsPropertiesMessage           : 
ErrorsPropertiesTarget            : 
ExistingTargetId                  : 
Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveColle
                                    ctions/PS-centralus-westcentralus-demoRMS1/moveResources/psdemovm111
IsResolveRequired                 : False
JobStatusJobName                  : 
JobStatusJobProgress              : 
MoveStatusErrorsPropertiesCode    : 
MoveStatusErrorsPropertiesDetail  : 
MoveStatusErrorsPropertiesMessage : 
MoveStatusErrorsPropertiesTarget  : 
MoveStatusMoveState               : PreparePending
Name                              : psdemovm111
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.NetworkInterfaceResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm/providers/microsoft.network/networkinterfaces/psdemovm
                                    111
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.NetworkInterfaceResourceSettings
TargetId                          : 
Type                              : 

DependsOn                         : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm}
DependsOnOverride                 : {}
ErrorsPropertiesCode              : 
ErrorsPropertiesDetail            : 
ErrorsPropertiesMessage           : 
ErrorsPropertiesTarget            : 
ExistingTargetId                  : 
Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveColle
                                    ctions/PS-centralus-westcentralus-demoRMS1/moveResources/psdemorm-vnet
IsResolveRequired                 : False
JobStatusJobName                  : 
JobStatusJobProgress              : 
MoveStatusErrorsPropertiesCode    : 
MoveStatusErrorsPropertiesDetail  : 
MoveStatusErrorsPropertiesMessage : 
MoveStatusErrorsPropertiesTarget  : 
MoveStatusMoveState               : PreparePending
Name                              : psdemorm-vnet
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.VirtualNetworkResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/psdemorm/providers/Microsoft.Network/virtualNetworks/psdemorm-v
                                    net
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.VirtualNetworkResourceSettings
TargetId                          : 
Type                              : 

DependsOn                         : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm}
DependsOnOverride                 : {}
ErrorsPropertiesCode              : 
ErrorsPropertiesDetail            : 
ErrorsPropertiesMessage           : 
ErrorsPropertiesTarget            : 
ExistingTargetId                  : 
Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveColle
                                    ctions/PS-centralus-westcentralus-demoRMS1/moveResources/psdemovm-nsg
IsResolveRequired                 : False
JobStatusJobName                  : 
JobStatusJobProgress              : 
MoveStatusErrorsPropertiesCode    : 
MoveStatusErrorsPropertiesDetail  : 
MoveStatusErrorsPropertiesMessage : 
MoveStatusErrorsPropertiesTarget  : 
MoveStatusMoveState               : PreparePending
Name                              : psdemovm-nsg
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.NetworkSecurityGroupResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm/providers/microsoft.network/networksecuritygroups/psde
                                    movm-nsg
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.NetworkSecurityGroupResourceSettings
TargetId                          : 
Type                              : 

DependsOn                         : {}
DependsOnOverride                 : {}
ErrorsPropertiesCode              : 
ErrorsPropertiesDetail            : 
ErrorsPropertiesMessage           : 
ErrorsPropertiesTarget            : 
ExistingTargetId                  : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/PSDemoRM-target
Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveColle
                                    ctions/PS-centralus-westcentralus-demoRMS1/moveResources/psdemorm
IsResolveRequired                 : False
JobStatusJobName                  : 
JobStatusJobProgress              : 
MoveStatusErrorsPropertiesCode    : 
MoveStatusErrorsPropertiesDetail  : 
MoveStatusErrorsPropertiesMessage : 
MoveStatusErrorsPropertiesTarget  : 
MoveStatusMoveState               : DeleteSourcePending
Name                              : psdemorm
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.ResourceSettings
TargetId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/PSDemoRM-target
Type                              :

.Example
PS C:\> Get-AzResourceMoverMoveResource -MoveCollectionName "PS-centralus-westcentralus-demoRMS" -ResourceGroupName "RG-MoveCollection-demoRMS" -Name "PSDemoVM"   
                                                     
DependsOn                         : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Network/networkInterfaces/psdemov
                                    m111, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/PSDemoRM}
DependsOnOverride                 : {}
ErrorsPropertiesCode              : 
ErrorsPropertiesDetail            : 
ErrorsPropertiesMessage           : 
ErrorsPropertiesTarget            : 
ExistingTargetId                  : 
Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveColle
                                    ctions/PS-centralus-westcentralus-demoRMS/moveResources/PSDemoVM
IsResolveRequired                 : False
JobStatusJobName                  : 
JobStatusJobProgress              : 
MoveStatusErrorsPropertiesCode    : 
MoveStatusErrorsPropertiesDetail  : 
MoveStatusErrorsPropertiesMessage : 
MoveStatusErrorsPropertiesTarget  : 
MoveStatusMoveState               : PreparePending
Name                              : PSDemoVM
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.VirtualMachineResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/PSDemoRM/providers/Microsoft.Compute/virtualMachines/PSDemoVM
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.VirtualMachineResourceSettings
TargetId                          : 
Type                              : 

.Example
PS C:\WINDOWS\system32> Get-AzResourceMoverMoveResource -MoveCollectionName "PS-centralus-westcentralus-demoRMS1" -ResourceGroupName "RG-MoveCollection-demoRMS" -Filter "Properties/SourceResourceName eq 'psdemovm111'"


DependsOn                         : {/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/psdemorm/providers/Microsoft.Network/virtualNetworks/psdemorm-
                                    vnet, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm/providers/microsoft.network/networksecuritygroup
                                    s/psdemovm-nsg, /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm}
DependsOnOverride                 : {}
ErrorsPropertiesCode              : 
ErrorsPropertiesDetail            : 
ErrorsPropertiesMessage           : 
ErrorsPropertiesTarget            : 
ExistingTargetId                  : 
Id                                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/RG-MoveCollection-demoRMS/providers/Microsoft.Migrate/moveColle
                                    ctions/PS-centralus-westcentralus-demoRMS1/moveResources/psdemovm111
IsResolveRequired                 : False
JobStatusJobName                  : 
JobStatusJobProgress              : 
MoveStatusErrorsPropertiesCode    : 
MoveStatusErrorsPropertiesDetail  : 
MoveStatusErrorsPropertiesMessage : 
MoveStatusErrorsPropertiesTarget  : 
MoveStatusMoveState               : PreparePending
Name                              : psdemovm111
ProvisioningState                 : Succeeded
ResourceSetting                   : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.NetworkInterfaceResourceSettings
SourceId                          : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/psdemorm/providers/microsoft.network/networkinterfaces/psdemovm
                                    111
SourceResourceSetting             : Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.NetworkInterfaceResourceSettings
TargetId                          : 
Type                              : 


.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResource
.Link
https://docs.microsoft.com/powershell/module/az.resourcemover/get-azresourcemovermoveresource
#>
function Get-AzResourceMoverMoveResource {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Models.Api202101.IMoveResource])]
[CmdletBinding(DefaultParameterSetName='List', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Path')]
    [System.String]
    # The Move Collection Name.
    ${MoveCollectionName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Path')]
    [System.String]
    # The Resource Group Name.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Get', Mandatory)]
    [Alias('MoveResourceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Path')]
    [System.String]
    # The Move Resource Name.
    ${Name},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String[]]
    # The Subscription ID.
    ${SubscriptionId},

    [Parameter(ParameterSetName='List')]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Query')]
    [System.String]
    # The filter to apply on the operation.
    # For example, you can use $filter=Properties/ProvisioningState eq 'Succeeded'.
    ${Filter},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ResourceMover.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Get = 'Az.ResourceMover.private\Get-AzResourceMoverMoveResource_Get';
            List = 'Az.ResourceMover.private\Get-AzResourceMoverMoveResource_List';
        }
        if (('Get', 'List') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
