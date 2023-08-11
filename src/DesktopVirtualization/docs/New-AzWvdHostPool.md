---
external help file:
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/new-azwvdhostpool
schema: 2.0.0
---

# New-AzWvdHostPool

## SYNOPSIS
Create or update a host pool.

## SYNTAX

### CreateExpanded (Default)
```
New-AzWvdHostPool -HostPoolType <HostPoolType> -LoadBalancerType <LoadBalancerType> -Name <String>
 -PreferredAppGroupType <PreferredAppGroupType> -ResourceGroupName <String> [-Location <String>]
 [-SubscriptionId <String>] [-AgentUpdateMaintenanceWindow <IMaintenanceWindowProperties[]>]
 [-AgentUpdateMaintenanceWindowTimeZone <String>] [-AgentUpdateType <SessionHostComponentUpdateType>]
 [-AgentUpdateUseSessionHostLocalTime] [-CustomRdpProperty <String>] [-Description <String>]
 [-ExpirationTime <DateTime>] [-FriendlyName <String>] [-IdentityType <ResourceIdentityType>] [-Kind <String>]
 [-ManagedBy <String>] [-MaxSessionLimit <Int32>]
 [-PersonalDesktopAssignmentType <PersonalDesktopAssignmentType>] [-PlanName <String>] [-PlanProduct <String>]
 [-PlanPromotionCode <String>] [-PlanPublisher <String>] [-PlanVersion <String>]
 [-RegistrationInfoToken <String>] [-RegistrationTokenOperation <RegistrationTokenOperation>] [-Ring <Int32>]
 [-SkuCapacity <Int32>] [-SkuFamily <String>] [-SkuName <String>] [-SkuSize <String>] [-SkuTier <SkuTier>]
 [-SsoadfsAuthority <String>] [-SsoClientId <String>] [-SsoClientSecretKeyVaultPath <String>]
 [-SsoSecretType <SsoSecretType>] [-StartVMOnConnect] [-Tag <Hashtable>] [-ValidationEnvironment]
 [-VMTemplate <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### FullSenerioCreate
```
New-AzWvdHostPool -HostPoolType <HostPoolType> -LoadBalancerType <LoadBalancerType> -Location <String>
 -Name <String> -PreferredAppGroupType <PreferredAppGroupType> -ResourceGroupName <String>
 [-DesktopAppGroupName <String>] [-SubscriptionId <String>] [-WorkspaceName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or update a host pool.

## EXAMPLES

### Example 1: Create a Windows Virtual Desktop HostPool by name
```powershell
New-AzWvdHostPool -ResourceGroupName ResourceGroupName `
                            -Name HostPoolName `
                            -Location 'eastus' `
                            -HostPoolType 'Pooled' `
                            -LoadBalancerType 'DepthFirst' `
                            -RegistrationTokenOperation 'Update' `
                            -ExpirationTime $((Get-Date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')) `
                            -Description 'Description' `
                            -FriendlyName 'Friendly Name' `
                            -MaxSessionLimit 5 `
                            -VMTemplate $null `
                            -SsoClientId $null `
                            -SsoClientSecretKeyVaultPath $null `
                            -SsoSecretType $null `
                            -SsoadfsAuthority $null `
                            -CustomRdpProperty $null `
                            -Ring $null `
                            -ValidationEnvironment:$false
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     HostPoolName Microsoft.DesktopVirtualization/hostpools
```

This command creates a Windows Virtual Desktop HostPool in a Resource Group.

### Example 2: Create a Windows Virtual Desktop HostPool by name
```powershell
New-AzWvdHostPool -ResourceGroupName ResourceGroupName `
                            -Name HostPoolName `
                            -Location 'eastus' `
                            -HostPoolType 'Personal' `
                            -LoadBalancerType 'Persistent' `
                            -RegistrationTokenOperation 'Update' `
                            -ExpirationTime $((Get-Date).ToUniversalTime().AddDays(1).ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ')) `
                            -Description 'Description' `
                            -FriendlyName 'Friendly Name' `
                            -MaxSessionLimit 5 `
                            -VMTemplate $null `
                            -SsoClientId $null `
                            -SsoClientSecretKeyVaultPath $null `
                            -SsoSecretType $null `
                            -SsoadfsAuthority $null `
                            -CustomRdpProperty $null `
                            -Ring $null `
                            -ValidationEnvironment:$false
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     HostPoolName Microsoft.DesktopVirtualization/hostpools
```

This command creates a Windows Virtual Desktop HostPool in a Resource Group.

## PARAMETERS

### -AgentUpdateMaintenanceWindow
List of maintenance windows.
Maintenance windows are 2 hours long.
To construct, see NOTES section for AGENTUPDATEMAINTENANCEWINDOW properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IMaintenanceWindowProperties[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AgentUpdateMaintenanceWindowTimeZone
Time zone for maintenance as defined in https://docs.microsoft.com/en-us/dotnet/api/system.timezoneinfo.findsystemtimezonebyidview=net-5.0.
Must be set if useLocalTime is true.

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

### -AgentUpdateType
The type of maintenance for session host components.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SessionHostComponentUpdateType
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AgentUpdateUseSessionHostLocalTime
Whether to use localTime of the virtual machine.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CustomRdpProperty
Custom rdp property of HostPool.

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -Description
Description of HostPool.

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

### -DesktopAppGroupName
Desktop App Group Name

```yaml
Type: System.String
Parameter Sets: FullSenerioCreate
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpirationTime
Expiration time of registration token.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FriendlyName
Friendly name of HostPool.

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

### -HostPoolType
HostPool type for desktop.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.HostPoolType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.ResourceIdentityType
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
Metadata used by portal/tooling/etc to render different UX experiences for resources of the same type; e.g.
ApiApps are a kind of Microsoft.Web/sites type.
If supported, the resource provider must validate and persist this value.

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

### -LoadBalancerType
The type of the load balancer.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.LoadBalancerType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedBy
The fully qualified resource ID of the resource that manages this resource.
Indicates if this resource is managed by another Azure resource.
If this is present, complete mode deployment will not delete the resource if it is removed from the template since it is managed by another resource.

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

### -MaxSessionLimit
The max session limit of HostPool.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the host pool within the specified resource group

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: HostPoolName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PersonalDesktopAssignmentType
PersonalDesktopAssignment type for HostPool.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.PersonalDesktopAssignmentType
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PlanName
A user defined name of the 3rd Party Artifact that is being procured.

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

### -PlanProduct
The 3rd Party artifact that is being procured.
E.g.
NewRelic.
Product maps to the OfferID specified for the artifact at the time of Data Market onboarding.

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

### -PlanPromotionCode
A publisher provided promotion code as provisioned in Data Market for the said product/artifact.

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

### -PlanPublisher
The publisher of the 3rd Party Artifact that is being bought.
E.g.
NewRelic

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

### -PlanVersion
The version of the desired product/artifact.

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

### -PreferredAppGroupType
The type of preferred application group type, default to Desktop Application Group

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.PreferredAppGroupType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegistrationInfoToken
The registration token base64 encoded string.

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

### -RegistrationTokenOperation
The type of resetting the token.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.RegistrationTokenOperation
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ring
The ring number of HostPool.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
If the SKU supports scale out/in then the capacity integer should be included.
If scale out/in is not possible for the resource this may be omitted.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuFamily
If the service has different generations of hardware, for the same SKU, then that can be captured here.

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

### -SkuName
The name of the SKU.
Ex - P3.
It is typically a letter+number code

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

### -SkuSize
The SKU size.
When the name field is the combination of tier and some other value, this would be the standalone code.

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

### -SkuTier
This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required on a PUT.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SkuTier
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SsoadfsAuthority
URL to customer ADFS server for signing WVD SSO certificates.

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

### -SsoClientId
ClientId for the registered Relying Party used to issue WVD SSO certificates.

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

### -SsoClientSecretKeyVaultPath
Path to Azure KeyVault storing the secret used for communication to ADFS.

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

### -SsoSecretType
The type of single sign on Secret Type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.SsoSecretType
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartVMOnConnect
The flag to turn on/off StartVMOnConnect feature.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidationEnvironment
Is validation environment.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMTemplate
VM template for sessionhosts configuration within hostpool.

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

### -WorkspaceName
Workspace Name

```yaml
Type: System.String
Parameter Sets: FullSenerioCreate
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IHostPool

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`AGENTUPDATEMAINTENANCEWINDOW <IMaintenanceWindowProperties[]>`: List of maintenance windows. Maintenance windows are 2 hours long.
  - `[DayOfWeek <DayOfWeek?>]`: Day of the week.
  - `[Hour <Int32?>]`: The update start hour of the day. (0 - 23)

## RELATED LINKS

