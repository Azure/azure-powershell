---
external help file:
Module Name: Az.ContainerService
online version: https://docs.microsoft.com/en-us/powershell/module/az.containerservice/new-azopenshiftmanagedcluster
schema: 2.0.0
---

# New-AzOpenShiftManagedCluster

## SYNOPSIS
Creates or updates a OpenShift managed cluster with the specified configuration for agents and OpenShift version.

## SYNTAX

### CreateExpanded (Default)
```
New-AzOpenShiftManagedCluster -ResourceGroupName <String> -ResourceName <String> -SubscriptionId <String>
 -Location <String> [-AgentPoolProfile <IOpenShiftManagedClusterAgentPoolProfile[]>]
 [-AuthProfileIdentityProvider <IOpenShiftManagedClusterIdentityProvider[]>] [-MasterPoolProfileCount <Int32>]
 [-MasterPoolProfileName <String>] [-MasterPoolProfileOSType <OSType>] [-MasterPoolProfileSubnetCidr <String>]
 [-MasterPoolProfileVMSize <OpenShiftContainerServiceVMSize>] [-MonitorProfileEnabled]
 [-MonitorProfileWorkspaceResourceId <String>] [-NetworkProfilePeerVnetId <String>]
 [-NetworkProfileVnetCidr <String>] [-NetworkProfileVnetId <String>] [-OpenShiftVersion <String>]
 [-PlanName <String>] [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>]
 [-RouterProfile <IOpenShiftRouterProfile[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzOpenShiftManagedCluster -ResourceGroupName <String> -ResourceName <String> -SubscriptionId <String>
 -Parameter <IOpenShiftManagedCluster> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzOpenShiftManagedCluster -InputObject <IContainerServiceIdentity> -Parameter <IOpenShiftManagedCluster>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzOpenShiftManagedCluster -InputObject <IContainerServiceIdentity> -Location <String>
 [-AgentPoolProfile <IOpenShiftManagedClusterAgentPoolProfile[]>]
 [-AuthProfileIdentityProvider <IOpenShiftManagedClusterIdentityProvider[]>] [-MasterPoolProfileCount <Int32>]
 [-MasterPoolProfileName <String>] [-MasterPoolProfileOSType <OSType>] [-MasterPoolProfileSubnetCidr <String>]
 [-MasterPoolProfileVMSize <OpenShiftContainerServiceVMSize>] [-MonitorProfileEnabled]
 [-MonitorProfileWorkspaceResourceId <String>] [-NetworkProfilePeerVnetId <String>]
 [-NetworkProfileVnetCidr <String>] [-NetworkProfileVnetId <String>] [-OpenShiftVersion <String>]
 [-PlanName <String>] [-PlanProduct <String>] [-PlanPromotionCode <String>] [-PlanPublisher <String>]
 [-RouterProfile <IOpenShiftRouterProfile[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a OpenShift managed cluster with the specified configuration for agents and OpenShift version.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
To view examples, please use the -Online parameter with Get-Help or navigate to: https://docs.microsoft.com/en-us/powershell/module/az.containerservice/new-azopenshiftmanagedcluster
```



## PARAMETERS

### -AgentPoolProfile
Configuration of OpenShift cluster VMs.
To construct, see NOTES section for AGENTPOOLPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20190930Preview.IOpenShiftManagedClusterAgentPoolProfile[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -AuthProfileIdentityProvider
Type of authentication profile to use.
To construct, see NOTES section for AUTHPROFILEIDENTITYPROVIDER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20190930Preview.IOpenShiftManagedClusterIdentityProvider[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.IContainerServiceIdentity
Parameter Sets: CreateViaIdentity, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Location
Resource location

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MasterPoolProfileCount
Number of masters (VMs) to host docker containers.
The default value is 3.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MasterPoolProfileName
Unique name of the master pool profile in the context of the subscription and resource group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MasterPoolProfileOSType
OsType to be used to specify os type.
Choose from Linux and Windows.
Default to Linux.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.OSType
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MasterPoolProfileSubnetCidr
Subnet CIDR for the peering.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MasterPoolProfileVMSize
Size of agent VMs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Support.OpenShiftContainerServiceVMSize
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MonitorProfileEnabled
If the Log analytics integration should be turned on or off

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MonitorProfileWorkspaceResourceId
Azure Resource Manager Resource ID for the Log Analytics workspace to integrate with.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkProfilePeerVnetId
CIDR of the Vnet to peer.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkProfileVnetCidr
CIDR for the OpenShift Vnet.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NetworkProfileVnetId
ID of the Vnet created for OSA cluster.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -OpenShiftVersion
Version of OpenShift specified when creating the cluster.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
OpenShift Managed cluster.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20190930Preview.IOpenShiftManagedCluster
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -PlanName
The plan ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanProduct
Specifies the product of the image from the marketplace.
This is the same value as Offer under the imageReference element.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanPromotionCode
The promotion code.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PlanPublisher
The plan ID.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceName
The name of the OpenShift managed cluster resource.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -RouterProfile
Configuration for OpenShift router(s).
To construct, see NOTES section for ROUTERPROFILE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20190930Preview.IOpenShiftRouterProfile[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20190930Preview.IOpenShiftManagedCluster

### Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.IContainerServiceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerService.Models.Api20190930Preview.IOpenShiftManagedCluster

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### AGENTPOOLPROFILE <IOpenShiftManagedClusterAgentPoolProfile[]>: Configuration of OpenShift cluster VMs.
  - `Count <Int32>`: Number of agents (VMs) to host docker containers.
  - `Name <String>`: Unique name of the pool profile in the context of the subscription and resource group.
  - `VMSize <OpenShiftContainerServiceVMSize>`: Size of agent VMs.
  - `[OSType <OSType?>]`: OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
  - `[Role <OpenShiftAgentPoolProfileRole?>]`: Define the role of the AgentPoolProfile.
  - `[SubnetCidr <String>]`: Subnet CIDR for the peering.

#### AUTHPROFILEIDENTITYPROVIDER <IOpenShiftManagedClusterIdentityProvider[]>: Type of authentication profile to use.
  - `ProviderKind <String>`: The kind of the provider.
  - `[Name <String>]`: Name of the provider.

#### INPUTOBJECT <IContainerServiceIdentity>: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the agent pool.
  - `[ContainerServiceName <String>]`: The name of the container service in the specified subscription and resource group.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The name of a supported Azure region.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[ResourceName <String>]`: The name of the managed cluster resource.
  - `[RoleName <String>]`: The name of the role for managed cluster accessProfile resource.
  - `[SubscriptionId <String>]`: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

#### PARAMETER <IOpenShiftManagedCluster>: OpenShift Managed cluster.
  - `Location <String>`: Resource location
  - `MasterPoolProfileCount <Int32>`: Number of masters (VMs) to host docker containers. The default value is 3.
  - `MasterPoolProfileVMSize <OpenShiftContainerServiceVMSize>`: Size of agent VMs.
  - `OpenShiftVersion <String>`: Version of OpenShift specified when creating the cluster.
  - `[Tag <IResourceTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[AgentPoolProfile <IOpenShiftManagedClusterAgentPoolProfile[]>]`: Configuration of OpenShift cluster VMs.
    - `Count <Int32>`: Number of agents (VMs) to host docker containers.
    - `Name <String>`: Unique name of the pool profile in the context of the subscription and resource group.
    - `VMSize <OpenShiftContainerServiceVMSize>`: Size of agent VMs.
    - `[OSType <OSType?>]`: OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
    - `[Role <OpenShiftAgentPoolProfileRole?>]`: Define the role of the AgentPoolProfile.
    - `[SubnetCidr <String>]`: Subnet CIDR for the peering.
  - `[AuthProfileIdentityProvider <IOpenShiftManagedClusterIdentityProvider[]>]`: Type of authentication profile to use.
    - `ProviderKind <String>`: The kind of the provider.
    - `[Name <String>]`: Name of the provider.
  - `[MasterPoolProfileName <String>]`: Unique name of the master pool profile in the context of the subscription and resource group.
  - `[MasterPoolProfileOSType <OSType?>]`: OsType to be used to specify os type. Choose from Linux and Windows. Default to Linux.
  - `[MasterPoolProfileSubnetCidr <String>]`: Subnet CIDR for the peering.
  - `[MonitorProfileEnabled <Boolean?>]`: If the Log analytics integration should be turned on or off
  - `[MonitorProfileWorkspaceResourceId <String>]`: Azure Resource Manager Resource ID for the Log Analytics workspace to integrate with.
  - `[NetworkProfilePeerVnetId <String>]`: CIDR of the Vnet to peer.
  - `[NetworkProfileVnetCidr <String>]`: CIDR for the OpenShift Vnet.
  - `[NetworkProfileVnetId <String>]`: ID of the Vnet created for OSA cluster.
  - `[PlanName <String>]`: The plan ID.
  - `[PlanProduct <String>]`: Specifies the product of the image from the marketplace. This is the same value as Offer under the imageReference element.
  - `[PlanPromotionCode <String>]`: The promotion code.
  - `[PlanPublisher <String>]`: The plan ID.
  - `[RouterProfile <IOpenShiftRouterProfile[]>]`: Configuration for OpenShift router(s).
    - `[Name <String>]`: Name of the router profile.

#### ROUTERPROFILE <IOpenShiftRouterProfile[]>: Configuration for OpenShift router(s).
  - `[Name <String>]`: Name of the router profile.

## RELATED LINKS

