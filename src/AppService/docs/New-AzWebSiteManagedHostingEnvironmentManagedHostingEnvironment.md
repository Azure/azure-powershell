---
external help file: Az.WebSite-help.xml
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/new-azwebsitemanagedhostingenvironmentmanagedhostingenvironment
schema: 2.0.0
---

# New-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment

## SYNOPSIS
Create or update a managed hosting environment.

## SYNTAX

### Create (Default)
```
New-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment -Name <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-ManagedHostingEnvironmentEnvelope <IHostingEnvironment>] [-PassThru]
 [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment [-Name <String>] [-SubscriptionId <String>]
 -InputObject <IWebSiteIdentity> [-PassThru] [-AllowedMultiSize <String>] [-AllowedWorkerSize <String>]
 [-ApiManagementAccountId <String>] [-ClusterSetting <INameValuePair[]>] [-DatabaseEdition <String>]
 [-DatabaseServiceObjective <String>] [-DnsSuffix <String>] [-EnvironmentCapacity <IStampCapacity[]>]
 [-EnvironmentIsHealthy <Boolean>] [-EnvironmentStatu <String>] [-Id <String>]
 [-InternalLoadBalancingMode <InternalLoadBalancingMode>] [-IpsslAddressCount <Int32>] [-Kind <String>]
 [-LastAction <String>] [-LastActionResult <String>] -Location <String> [-MaximumNumberOfMachine <Int32>]
 [-MultiRoleCount <Int32>] [-MultiSize <String>] [-NetworkAccessControlList <INetworkAccessControlEntry[]>]
 [-PropertiesLocation <String>] [-PropertiesName <String>] [-ProvisioningState <ProvisioningState>]
 [-ResourceGroup <String>] -Status <HostingEnvironmentStatus> [-Suspended <Boolean>] [-Tag <IResourceTags>]
 [-Type <String>] [-UpgradeDomain <Int32>] [-VipMapping <IVirtualIPMapping[]>] [-VirtualNetworkId <String>]
 [-VirtualNetworkName <String>] [-VirtualNetworkSubnet <String>] [-VirtualNetworkType <String>]
 [-VnetName <String>] [-VnetResourceGroupName <String>] [-VnetSubnetName <String>]
 [-WorkerPool <IWorkerPool[]>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateExpanded
```
New-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment -Name <String> -ResourceGroupName <String>
 -SubscriptionId <String> [-PassThru] [-AllowedMultiSize <String>] [-AllowedWorkerSize <String>]
 [-ApiManagementAccountId <String>] [-ClusterSetting <INameValuePair[]>] [-DatabaseEdition <String>]
 [-DatabaseServiceObjective <String>] [-DnsSuffix <String>] [-EnvironmentCapacity <IStampCapacity[]>]
 [-EnvironmentIsHealthy <Boolean>] [-EnvironmentStatu <String>] [-Id <String>]
 [-InternalLoadBalancingMode <InternalLoadBalancingMode>] [-IpsslAddressCount <Int32>] [-Kind <String>]
 [-LastAction <String>] [-LastActionResult <String>] -Location <String> [-MaximumNumberOfMachine <Int32>]
 [-MultiRoleCount <Int32>] [-MultiSize <String>] [-Name1 <String>]
 [-NetworkAccessControlList <INetworkAccessControlEntry[]>] [-PropertiesLocation <String>]
 [-PropertiesName <String>] [-PropertiesSubscriptionId <String>] [-ProvisioningState <ProvisioningState>]
 [-ResourceGroup <String>] -Status <HostingEnvironmentStatus> [-Suspended <Boolean>] [-Tag <IResourceTags>]
 [-Type <String>] [-UpgradeDomain <Int32>] [-VipMapping <IVirtualIPMapping[]>] [-VirtualNetworkId <String>]
 [-VirtualNetworkName <String>] [-VirtualNetworkSubnet <String>] [-VirtualNetworkType <String>]
 [-VnetName <String>] [-VnetResourceGroupName <String>] [-VnetSubnetName <String>]
 [-WorkerPool <IWorkerPool[]>] [-DefaultProfile <PSObject>] [-AsJob] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment -InputObject <IWebSiteIdentity>
 [-ManagedHostingEnvironmentEnvelope <IHostingEnvironment>] [-PassThru] [-DefaultProfile <PSObject>] [-AsJob]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create or update a managed hosting environment.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AllowedMultiSize
List of comma separated strings describing which VM sizes are allowed for front-ends

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AllowedWorkerSize
List of comma separated strings describing which VM sizes are allowed for workers

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ApiManagementAccountId
Api Management Account associated with this Hosting Environment

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClusterSetting
Custom settings for changing the behavior of the hosting environment

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.INameValuePair[]
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseEdition
Edition of the metadata database for the hostingEnvironment (App Service Environment) e.g.
"Standard"

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseServiceObjective
Service objective of the metadata database for the hostingEnvironment (App Service Environment) e.g.
"S0"

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -DnsSuffix
DNS suffix of the hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentCapacity
Current total, used, and available worker capacities

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IStampCapacity[]
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentIsHealthy
True/false indicating whether the hostingEnvironment (App Service Environment) is healthy

```yaml
Type: System.Boolean
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentStatu
Detailed message about with results of the last check of the hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Resource Id

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InternalLoadBalancingMode
Specifies which endpoints to serve internally in the hostingEnvironment's (App Service Environment) VNET

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.InternalLoadBalancingMode
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpsslAddressCount
Number of IP SSL addresses reserved for this hostingEnvironment (App Service Environment)

```yaml
Type: System.Int32
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
Kind of resource

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastAction
Last deployment action on this hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastActionResult
Result of the last deployment action on this hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Resource Location

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedHostingEnvironmentEnvelope
Description of an hostingEnvironment (App Service Environment)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IHostingEnvironment
Parameter Sets: Create, CreateViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MaximumNumberOfMachine
Maximum number of VMs in this hostingEnvironment (App Service Environment)

```yaml
Type: System.Int32
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -MultiRoleCount
Number of front-end instances

```yaml
Type: System.Int32
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -MultiSize
Front-end VM size, e.g.
"Medium", "Large"

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of managed hosting environment

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name1
Resource Name

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkAccessControlList
Access control list for controlling traffic to the hostingEnvironment (App Service Environment)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.INetworkAccessControlEntry[]
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
When specified, PassThru will force the cmdlet return a 'bool' given that there isn't a return type by default.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesLocation
Location of the hostingEnvironment (App Service Environment), e.g. "West US"

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesName
Name of the hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PropertiesSubscriptionId
Subscription of the hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProvisioningState
Provisioning state of the hostingEnvironment (App Service Environment)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.ProvisioningState
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroup
Resource group of the hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of resource group

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
Current status of the hostingEnvironment (App Service Environment)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.HostingEnvironmentStatus
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Create, CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Suspended
True/false indicating whether the hostingEnvironment is suspended.
The environment can be suspended e.g.
when the management endpoint is no longer available (most likely because NSG blocked the incoming traffic)

```yaml
Type: System.Boolean
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801Preview.IResourceTags
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Resource type

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradeDomain
Number of upgrade domains of this hostingEnvironment (App Service Environment)

```yaml
Type: System.Int32
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
```

### -VipMapping
Description of IP SSL mapping for this hostingEnvironment (App Service Environment)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IVirtualIPMapping[]
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkId
Resource id of the virtual network

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkName
Name of the virtual network (read-only)

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkSubnet
Subnet within the virtual network

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualNetworkType
Resource type of the virtual network (read-only)

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VnetName
Name of the hostingEnvironment's (App Service Environment) virtual network

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VnetResourceGroupName
Resource group of the hostingEnvironment's (App Service Environment) virtual network

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VnetSubnetName
Subnet of the hostingEnvironment's (App Service Environment) virtual network

```yaml
Type: System.String
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkerPool
Description of worker pools with worker size ids, VM sizes, and number of workers in each pool

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IWorkerPool[]
Parameter Sets: CreateViaIdentityExpanded, CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Boolean
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.website/new-azwebsitemanagedhostingenvironmentmanagedhostingenvironment](https://docs.microsoft.com/en-us/powershell/module/az.website/new-azwebsitemanagedhostingenvironmentmanagedhostingenvironment)

