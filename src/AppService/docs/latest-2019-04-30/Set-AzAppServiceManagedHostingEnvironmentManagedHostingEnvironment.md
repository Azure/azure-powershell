---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/set-azappservicemanagedhostingenvironmentmanagedhostingenvironment
schema: 2.0.0
---

# Set-AzAppServiceManagedHostingEnvironmentManagedHostingEnvironment

## SYNOPSIS
Create or update a managed hosting environment.

## SYNTAX

### UpdateExpanded (Default)
```
Set-AzAppServiceManagedHostingEnvironmentManagedHostingEnvironment -Name <String> -ResourceGroupName <String>
 -Location <String> [-SubscriptionId <String>] [-AllowedMultiSize <String>] [-AllowedWorkerSize <String>]
 [-ApiManagementAccountId <String>] [-ClusterSetting <INameValuePair[]>] [-DatabaseEdition <String>]
 [-DatabaseServiceObjective <String>] [-DnsSuffix <String>] [-EnvironmentCapacity <IStampCapacity[]>]
 [-EnvironmentIsHealthy] [-EnvironmentStatus <String>] [-Id <String>]
 [-InternalLoadBalancingMode <InternalLoadBalancingMode>] [-IpsslAddressCount <Int32>] [-Kind <String>]
 [-LastAction <String>] [-LastActionResult <String>] [-MaximumNumberOfMachine <Int32>]
 [-MultiRoleCount <Int32>] [-MultiSize <String>] [-Name1 <String>]
 [-NetworkAccessControlList <INetworkAccessControlEntry[]>] [-PropertiesLocation <String>]
 [-PropertiesName <String>] [-PropertiesSubscriptionId <String>] [-ProvisioningState <ProvisioningState>]
 [-ResourceGroup <String>] [-Status <HostingEnvironmentStatus>] [-Suspended] [-Tag <Hashtable>]
 [-Type <String>] [-UpgradeDomain <Int32>] [-VipMapping <IVirtualIPMapping[]>] [-VirtualNetworkId <String>]
 [-VirtualNetworkName <String>] [-VirtualNetworkSubnet <String>] [-VirtualNetworkType <String>]
 [-VnetName <String>] [-VnetResourceGroupName <String>] [-VnetSubnetName <String>]
 [-WorkerPool <IWorkerPool[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Update
```
Set-AzAppServiceManagedHostingEnvironmentManagedHostingEnvironment -Name <String> -ResourceGroupName <String>
 -ManagedHostingEnvironmentEnvelope <IHostingEnvironment> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a managed hosting environment.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AllowedMultiSize
List of comma separated strings describing which VM sizes are allowed for front-ends

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AllowedWorkerSize
List of comma separated strings describing which VM sizes are allowed for workers

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ApiManagementAccountId
Api Management Account associated with this Hosting Environment

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ClusterSetting
Custom settings for changing the behavior of the hosting environment
To construct, see NOTES section for CLUSTERSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.INameValuePair[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DatabaseEdition
Edition of the metadata database for the hostingEnvironment (App Service Environment) e.g.
"Standard"

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DatabaseServiceObjective
Service objective of the metadata database for the hostingEnvironment (App Service Environment) e.g.
"S0"

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DnsSuffix
DNS suffix of the hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnvironmentCapacity
Current total, used, and available worker capacities
To construct, see NOTES section for ENVIRONMENTCAPACITY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.IStampCapacity[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnvironmentIsHealthy
True/false indicating whether the hostingEnvironment (App Service Environment) is healthy

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnvironmentStatus
Detailed message about with results of the last check of the hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Id
Resource Id

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InternalLoadBalancingMode
Specifies which endpoints to serve internally in the hostingEnvironment's (App Service Environment) VNET

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.InternalLoadBalancingMode
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -IpsslAddressCount
Number of IP SSL addresses reserved for this hostingEnvironment (App Service Environment)

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LastAction
Last deployment action on this hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -LastActionResult
Result of the last deployment action on this hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource Location

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ManagedHostingEnvironmentEnvelope
Description of an hostingEnvironment (App Service Environment)
To construct, see NOTES section for MANAGEDHOSTINGENVIRONMENTENVELOPE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.IHostingEnvironment
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -MaximumNumberOfMachine
Maximum number of VMs in this hostingEnvironment (App Service Environment)

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MultiRoleCount
Number of front-end instances

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MultiSize
Front-end VM size, e.g.
"Medium", "Large"

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of managed hosting environment

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name1
Resource Name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkAccessControlList
Access control list for controlling traffic to the hostingEnvironment (App Service Environment)
To construct, see NOTES section for NETWORKACCESSCONTROLLIST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.INetworkAccessControlEntry[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesLocation
Location of the hostingEnvironment (App Service Environment), e.g.
"West US"

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesName
Name of the hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PropertiesSubscriptionId
Subscription of the hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProvisioningState
Provisioning state of the hostingEnvironment (App Service Environment)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.ProvisioningState
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroup
Resource group of the hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of resource group

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Status
Current status of the hostingEnvironment (App Service Environment)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Support.HostingEnvironmentStatus
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Suspended
True/false indicating whether the hostingEnvironment is suspended.
The environment can be suspended e.g.
when the management endpoint is no longer available (most likely because NSG blocked the incoming traffic)

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Type
Resource type

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -UpgradeDomain
Number of upgrade domains of this hostingEnvironment (App Service Environment)

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VipMapping
Description of IP SSL mapping for this hostingEnvironment (App Service Environment)
To construct, see NOTES section for VIPMAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.IVirtualIPMapping[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VirtualNetworkId
Resource id of the virtual network

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VirtualNetworkName
Name of the virtual network (read-only)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VirtualNetworkSubnet
Subnet within the virtual network

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VirtualNetworkType
Resource type of the virtual network (read-only)

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetName
Name of the hostingEnvironment's (App Service Environment) virtual network

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetResourceGroupName
Resource group of the hostingEnvironment's (App Service Environment) virtual network

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VnetSubnetName
Subnet of the hostingEnvironment's (App Service Environment) virtual network

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WorkerPool
Description of worker pools with worker size ids, VM sizes, and number of workers in each pool
To construct, see NOTES section for WORKERPOOL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.IWorkerPool[]
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20150801.IHostingEnvironment

## OUTPUTS

### System.Boolean

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### CLUSTERSETTING <INameValuePair[]>: Custom settings for changing the behavior of the hosting environment
  - `[Name <String>]`: Pair name.
  - `[Value <String>]`: Pair value.

#### ENVIRONMENTCAPACITY <IStampCapacity[]>: Current total, used, and available worker capacities
  - `[AvailableCapacity <Int64?>]`: Available capacity (# of machines, bytes of storage etc...).
  - `[ComputeMode <ComputeModeOptions?>]`: Shared/dedicated workers.
  - `[ExcludeFromCapacityAllocation <Boolean?>]`: If <code>true</code>, it includes basic apps.         Basic apps are not used for capacity allocation.
  - `[IsApplicableForAllComputeMode <Boolean?>]`: <code>true</code> if capacity is applicable for all apps; otherwise, <code>false</code>.
  - `[Name <String>]`: Name of the stamp.
  - `[SiteMode <String>]`: Shared or Dedicated.
  - `[TotalCapacity <Int64?>]`: Total capacity (# of machines, bytes of storage etc...).
  - `[Unit <String>]`: Name of the unit.
  - `[WorkerSize <WorkerSizeOptions?>]`: Size of the machines.
  - `[WorkerSizeId <Int32?>]`: Size ID of machines:         0 - Small         1 - Medium         2 - Large

#### MANAGEDHOSTINGENVIRONMENTENVELOPE <IHostingEnvironment>: Description of an hostingEnvironment (App Service Environment)
  - `Location <String>`: Resource Location
  - `Status <HostingEnvironmentStatus>`: Current status of the hostingEnvironment (App Service Environment)
  - `[Id <String>]`: Resource Id
  - `[Kind <String>]`: Kind of resource
  - `[Name <String>]`: Resource Name
  - `[Tag <IResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Type <String>]`: Resource type
  - `[AllowedMultiSize <String>]`: List of comma separated strings describing which VM sizes are allowed for front-ends
  - `[AllowedWorkerSize <String>]`: List of comma separated strings describing which VM sizes are allowed for workers
  - `[ApiManagementAccountId <String>]`: Api Management Account associated with this Hosting Environment
  - `[ClusterSetting <INameValuePair[]>]`: Custom settings for changing the behavior of the hosting environment
    - `[Name <String>]`: Pair name.
    - `[Value <String>]`: Pair value.
  - `[DatabaseEdition <String>]`: Edition of the metadata database for the hostingEnvironment (App Service Environment) e.g. "Standard"
  - `[DatabaseServiceObjective <String>]`: Service objective of the metadata database for the hostingEnvironment (App Service Environment) e.g. "S0"
  - `[DnsSuffix <String>]`: DNS suffix of the hostingEnvironment (App Service Environment)
  - `[EnvironmentCapacity <IStampCapacity[]>]`: Current total, used, and available worker capacities
    - `[AvailableCapacity <Int64?>]`: Available capacity (# of machines, bytes of storage etc...).
    - `[ComputeMode <ComputeModeOptions?>]`: Shared/dedicated workers.
    - `[ExcludeFromCapacityAllocation <Boolean?>]`: If <code>true</code>, it includes basic apps.         Basic apps are not used for capacity allocation.
    - `[IsApplicableForAllComputeMode <Boolean?>]`: <code>true</code> if capacity is applicable for all apps; otherwise, <code>false</code>.
    - `[Name <String>]`: Name of the stamp.
    - `[SiteMode <String>]`: Shared or Dedicated.
    - `[TotalCapacity <Int64?>]`: Total capacity (# of machines, bytes of storage etc...).
    - `[Unit <String>]`: Name of the unit.
    - `[WorkerSize <WorkerSizeOptions?>]`: Size of the machines.
    - `[WorkerSizeId <Int32?>]`: Size ID of machines:         0 - Small         1 - Medium         2 - Large
  - `[EnvironmentIsHealthy <Boolean?>]`: True/false indicating whether the hostingEnvironment (App Service Environment) is healthy
  - `[EnvironmentStatus <String>]`: Detailed message about with results of the last check of the hostingEnvironment (App Service Environment)
  - `[InternalLoadBalancingMode <InternalLoadBalancingMode?>]`: Specifies which endpoints to serve internally in the hostingEnvironment's (App Service Environment) VNET
  - `[IpsslAddressCount <Int32?>]`: Number of IP SSL addresses reserved for this hostingEnvironment (App Service Environment)
  - `[LastAction <String>]`: Last deployment action on this hostingEnvironment (App Service Environment)
  - `[LastActionResult <String>]`: Result of the last deployment action on this hostingEnvironment (App Service Environment)
  - `[MaximumNumberOfMachine <Int32?>]`: Maximum number of VMs in this hostingEnvironment (App Service Environment)
  - `[MultiRoleCount <Int32?>]`: Number of front-end instances
  - `[MultiSize <String>]`: Front-end VM size, e.g. "Medium", "Large"
  - `[NetworkAccessControlList <INetworkAccessControlEntry[]>]`: Access control list for controlling traffic to the hostingEnvironment (App Service Environment)
    - `[Action <AccessControlEntryAction?>]`: Action object.
    - `[Description <String>]`: Description of network access control entry.
    - `[Order <Int32?>]`: Order of precedence.
    - `[RemoteSubnet <String>]`: Remote subnet.
  - `[PropertiesLocation <String>]`: Location of the hostingEnvironment (App Service Environment), e.g. "West US"
  - `[PropertiesName <String>]`: Name of the hostingEnvironment (App Service Environment)
  - `[ProvisioningState <ProvisioningState?>]`: Provisioning state of the hostingEnvironment (App Service Environment)
  - `[ResourceGroup <String>]`: Resource group of the hostingEnvironment (App Service Environment)
  - `[SubscriptionId <String>]`: Subscription of the hostingEnvironment (App Service Environment)
  - `[Suspended <Boolean?>]`: True/false indicating whether the hostingEnvironment is suspended. The environment can be suspended e.g. when the management endpoint is no longer available                     (most likely because NSG blocked the incoming traffic)
  - `[UpgradeDomain <Int32?>]`: Number of upgrade domains of this hostingEnvironment (App Service Environment)
  - `[VipMapping <IVirtualIPMapping[]>]`: Description of IP SSL mapping for this hostingEnvironment (App Service Environment)
    - `[InUse <Boolean?>]`: Is virtual IP mapping in use.
    - `[InternalHttpPort <Int32?>]`: Internal HTTP port.
    - `[InternalHttpsPort <Int32?>]`: Internal HTTPS port.
    - `[VirtualIP <String>]`: Virtual IP address.
  - `[VirtualNetworkId <String>]`: Resource id of the virtual network
  - `[VirtualNetworkName <String>]`: Name of the virtual network (read-only)
  - `[VirtualNetworkSubnet <String>]`: Subnet within the virtual network
  - `[VirtualNetworkType <String>]`: Resource type of the virtual network (read-only)
  - `[VnetName <String>]`: Name of the hostingEnvironment's (App Service Environment) virtual network
  - `[VnetResourceGroupName <String>]`: Resource group of the hostingEnvironment's (App Service Environment) virtual network
  - `[VnetSubnetName <String>]`: Subnet of the hostingEnvironment's (App Service Environment) virtual network
  - `[WorkerPool <IWorkerPool[]>]`: Description of worker pools with worker size ids, VM sizes, and number of workers in each pool
    - `Location <String>`: Resource Location
    - `[Id <String>]`: Resource Id
    - `[Kind <String>]`: Kind of resource
    - `[Name <String>]`: Resource Name
    - `[Tag <IResourceTags>]`: Resource tags
    - `[Type <String>]`: Resource type
    - `[ComputeMode <ComputeModeOptions?>]`: Shared or dedicated web app hosting
    - `[InstanceName <String[]>]`: Names of all instances in the worker pool (read only)
    - `[SkuCapacity <Int32?>]`: Current number of instances assigned to the resource.
    - `[SkuFamily <String>]`: Family code of the resource SKU.
    - `[SkuName <String>]`: Name of the resource SKU.
    - `[SkuSize <String>]`: Size specifier of the resource SKU.
    - `[SkuTier <String>]`: Service tier of the resource SKU.
    - `[WorkerCount <Int32?>]`: Number of instances in the worker pool
    - `[WorkerSize <String>]`: VM size of the worker pool instances
    - `[WorkerSizeId <Int32?>]`: Worker size id for referencing this worker pool

#### NETWORKACCESSCONTROLLIST <INetworkAccessControlEntry[]>: Access control list for controlling traffic to the hostingEnvironment (App Service Environment)
  - `[Action <AccessControlEntryAction?>]`: Action object.
  - `[Description <String>]`: Description of network access control entry.
  - `[Order <Int32?>]`: Order of precedence.
  - `[RemoteSubnet <String>]`: Remote subnet.

#### VIPMAPPING <IVirtualIPMapping[]>: Description of IP SSL mapping for this hostingEnvironment (App Service Environment)
  - `[InUse <Boolean?>]`: Is virtual IP mapping in use.
  - `[InternalHttpPort <Int32?>]`: Internal HTTP port.
  - `[InternalHttpsPort <Int32?>]`: Internal HTTPS port.
  - `[VirtualIP <String>]`: Virtual IP address.

#### WORKERPOOL <IWorkerPool[]>: Description of worker pools with worker size ids, VM sizes, and number of workers in each pool
  - `Location <String>`: Resource Location
  - `[Id <String>]`: Resource Id
  - `[Kind <String>]`: Kind of resource
  - `[Name <String>]`: Resource Name
  - `[Tag <IResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[Type <String>]`: Resource type
  - `[ComputeMode <ComputeModeOptions?>]`: Shared or dedicated web app hosting
  - `[InstanceName <String[]>]`: Names of all instances in the worker pool (read only)
  - `[SkuCapacity <Int32?>]`: Current number of instances assigned to the resource.
  - `[SkuFamily <String>]`: Family code of the resource SKU.
  - `[SkuName <String>]`: Name of the resource SKU.
  - `[SkuSize <String>]`: Size specifier of the resource SKU.
  - `[SkuTier <String>]`: Service tier of the resource SKU.
  - `[WorkerCount <Int32?>]`: Number of instances in the worker pool
  - `[WorkerSize <String>]`: VM size of the worker pool instances
  - `[WorkerSizeId <Int32?>]`: Worker size id for referencing this worker pool

## RELATED LINKS

