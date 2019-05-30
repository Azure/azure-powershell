---
external help file:
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/set-azwebsitemanagedhostingenvironmentmanagedhostingenvironment
schema: 2.0.0
---

# Set-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment

## SYNOPSIS
Create or update a managed hosting environment.

## SYNTAX

### Update (Default)
```
Set-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment -ResourceGroupName <String> [-Name <String>]
 [-SubscriptionId <String>] [-ManagedHostingEnvironmentEnvelope <IHostingEnvironment>] [-PassThru]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Set-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment -InputObject <IWebSiteIdentity>
 -Location <String> -Status <HostingEnvironmentStatus> [-Name <String>] [-SubscriptionId <String>] [-PassThru]
 [-AllowedMultiSize <String>] [-AllowedWorkerSize <String>] [-ApiManagementAccountId <String>]
 [-ClusterSetting <INameValuePair[]>] [-DatabaseEdition <String>] [-DatabaseServiceObjective <String>]
 [-DnsSuffix <String>] [-EnvironmentCapacity <IStampCapacity[]>] [-EnvironmentIsHealthy]
 [-EnvironmentStatu <String>] [-Id <String>] [-InternalLoadBalancingMode <InternalLoadBalancingMode>]
 [-IpsslAddressCount <Int32>] [-Kind <String>] [-LastAction <String>] [-LastActionResult <String>]
 [-MaximumNumberOfMachine <Int32>] [-MultiRoleCount <Int32>] [-MultiSize <String>]
 [-NetworkAccessControlList <INetworkAccessControlEntry[]>] [-PropertiesLocation <String>]
 [-PropertiesName <String>] [-ProvisioningState <ProvisioningState>] [-ResourceGroup <String>] [-Suspended]
 [-Tag <IResourceTags>] [-Type <String>] [-UpgradeDomain <Int32>] [-VipMapping <IVirtualIPMapping[]>]
 [-VirtualNetworkId <String>] [-VirtualNetworkName <String>] [-VirtualNetworkSubnet <String>]
 [-VirtualNetworkType <String>] [-VnetName <String>] [-VnetResourceGroupName <String>]
 [-VnetSubnetName <String>] [-WorkerPool <IWorkerPool[]>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment -ResourceGroupName <String> -Location <String>
 -Status <HostingEnvironmentStatus> [-Name <String>] [-SubscriptionId <String>] [-PassThru]
 [-AllowedMultiSize <String>] [-AllowedWorkerSize <String>] [-ApiManagementAccountId <String>]
 [-ClusterSetting <INameValuePair[]>] [-DatabaseEdition <String>] [-DatabaseServiceObjective <String>]
 [-DnsSuffix <String>] [-EnvironmentCapacity <IStampCapacity[]>] [-EnvironmentIsHealthy]
 [-EnvironmentStatu <String>] [-Id <String>] [-InternalLoadBalancingMode <InternalLoadBalancingMode>]
 [-IpsslAddressCount <Int32>] [-Kind <String>] [-LastAction <String>] [-LastActionResult <String>]
 [-MaximumNumberOfMachine <Int32>] [-MultiRoleCount <Int32>] [-MultiSize <String>] [-Name1 <String>]
 [-NetworkAccessControlList <INetworkAccessControlEntry[]>] [-PropertiesLocation <String>]
 [-PropertiesName <String>] [-PropertiesSubscriptionId <String>] [-ProvisioningState <ProvisioningState>]
 [-ResourceGroup <String>] [-Suspended] [-Tag <IResourceTags>] [-Type <String>] [-UpgradeDomain <Int32>]
 [-VipMapping <IVirtualIPMapping[]>] [-VirtualNetworkId <String>] [-VirtualNetworkName <String>]
 [-VirtualNetworkSubnet <String>] [-VirtualNetworkType <String>] [-VnetName <String>]
 [-VnetResourceGroupName <String>] [-VnetSubnetName <String>] [-WorkerPool <IWorkerPool[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Set-AzWebSiteManagedHostingEnvironmentManagedHostingEnvironment -InputObject <IWebSiteIdentity>
 [-ManagedHostingEnvironmentEnvelope <IHostingEnvironment>] [-PassThru] [-DefaultProfile <PSObject>] [-AsJob]
 [-Confirm] [-WhatIf] [<CommonParameters>]
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ClusterSetting
Custom settings for changing the behavior of the hosting environment

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.INameValuePair[]
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IStampCapacity[]
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -EnvironmentStatu
Detailed message about with results of the last check of the hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -InternalLoadBalancingMode
Specifies which endpoints to serve internally in the hostingEnvironment's (App Service Environment) VNET

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.InternalLoadBalancingMode
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Kind
Kind of resource

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IHostingEnvironment
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: False
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MultiRoleCount
Number of front-end instances

```yaml
Type: System.Int32
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -MultiSize
Front-end VM size, e.g.
"Medium", "Large"

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Resource Name

```yaml
Type: System.String
Parameter Sets: Update, UpdateViaIdentityExpanded, UpdateExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.INetworkAccessControlEntry[]
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -PropertiesLocation
Location of the hostingEnvironment (App Service Environment), e.g.
"West US"

```yaml
Type: System.String
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.ProvisioningState
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: Update, UpdateExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.HostingEnvironmentStatus
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Subscription of the hostingEnvironment (App Service Environment)

```yaml
Type: System.String
Parameter Sets: Update, UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Resource tags

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801Preview.IResourceTags
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VipMapping
Description of IP SSL mapping for this hostingEnvironment (App Service Environment)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IVirtualIPMapping[]
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IWorkerPool[]
Parameter Sets: UpdateViaIdentityExpanded, UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20150801.IHostingEnvironment

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity

## OUTPUTS

### System.Boolean

## ALIASES

## RELATED LINKS

