---
external help file: Az.Resilience-help.xml
Module Name: Az.Resilience
online version: https://learn.microsoft.com/powershell/module/az.resilience/new-azresiliencedrill
schema: 2.0.0
---

# New-AzResilienceDrill

## SYNOPSIS
Create a Drill

## SYNTAX

### CreateExpanded (Default)
```
New-AzResilienceDrill -Name <String> -ServiceGroupName <String> [-ChaosResourceIdentityForFaultType <String>]
 [-ChaosResourceIdentityForFaultUserAssignedIdentity <String>] [-ChaosResourcePropertiesIdentityType <String>]
 [-ChaosResourcePropertiesIdentityUserAssignedIdentity <String>] [-DrillAssetPropertyRegion <String>]
 [-DrillAssetPropertyResourceGroup <String>] [-DrillAssetPropertySubscription <String>] [-DrillType <String>]
 [-EnableSystemAssignedIdentity] [-HealthModelMonitoringPropertiesIdentityType <String>]
 [-HealthModelMonitoringPropertiesIdentityUserAssignedIdentity <String>]
 [-HealthModelMonitoringPropertyDiscoveryRuleId <String>] [-MonitoringPropertiesIdentityType <String>]
 [-MonitoringPropertiesIdentityUserAssignedIdentity <String>] [-RbacSetupMode <String>]
 [-RecoveryPlanPropertiesIdentityType <String>] [-RecoveryPlanPropertiesIdentityUserAssignedIdentity <String>]
 [-SliMonitoringPropertiesIdentityType <String>]
 [-SliMonitoringPropertiesIdentityUserAssignedIdentity <String>] [-SliMonitoringPropertySli <ISliSelection[]>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzResilienceDrill -Name <String> -ServiceGroupName <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzResilienceDrill -Name <String> -ServiceGroupName <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityServiceGroupExpanded
```
New-AzResilienceDrill -Name <String> -ServiceGroupInputObject <IResilienceIdentity>
 [-ChaosResourceIdentityForFaultType <String>] [-ChaosResourceIdentityForFaultUserAssignedIdentity <String>]
 [-ChaosResourcePropertiesIdentityType <String>]
 [-ChaosResourcePropertiesIdentityUserAssignedIdentity <String>] [-DrillAssetPropertyRegion <String>]
 [-DrillAssetPropertyResourceGroup <String>] [-DrillAssetPropertySubscription <String>] [-DrillType <String>]
 [-EnableSystemAssignedIdentity] [-HealthModelMonitoringPropertiesIdentityType <String>]
 [-HealthModelMonitoringPropertiesIdentityUserAssignedIdentity <String>]
 [-HealthModelMonitoringPropertyDiscoveryRuleId <String>] [-MonitoringPropertiesIdentityType <String>]
 [-MonitoringPropertiesIdentityUserAssignedIdentity <String>] [-RbacSetupMode <String>]
 [-RecoveryPlanPropertiesIdentityType <String>] [-RecoveryPlanPropertiesIdentityUserAssignedIdentity <String>]
 [-SliMonitoringPropertiesIdentityType <String>]
 [-SliMonitoringPropertiesIdentityUserAssignedIdentity <String>] [-SliMonitoringPropertySli <ISliSelection[]>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityServiceGroup
```
New-AzResilienceDrill -Name <String> -ServiceGroupInputObject <IResilienceIdentity> -Resource <IDrill>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Create
```
New-AzResilienceDrill -Name <String> -ServiceGroupName <String> -Resource <IDrill> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzResilienceDrill -InputObject <IResilienceIdentity> [-ChaosResourceIdentityForFaultType <String>]
 [-ChaosResourceIdentityForFaultUserAssignedIdentity <String>] [-ChaosResourcePropertiesIdentityType <String>]
 [-ChaosResourcePropertiesIdentityUserAssignedIdentity <String>] [-DrillAssetPropertyRegion <String>]
 [-DrillAssetPropertyResourceGroup <String>] [-DrillAssetPropertySubscription <String>] [-DrillType <String>]
 [-EnableSystemAssignedIdentity] [-HealthModelMonitoringPropertiesIdentityType <String>]
 [-HealthModelMonitoringPropertiesIdentityUserAssignedIdentity <String>]
 [-HealthModelMonitoringPropertyDiscoveryRuleId <String>] [-MonitoringPropertiesIdentityType <String>]
 [-MonitoringPropertiesIdentityUserAssignedIdentity <String>] [-RbacSetupMode <String>]
 [-RecoveryPlanPropertiesIdentityType <String>] [-RecoveryPlanPropertiesIdentityUserAssignedIdentity <String>]
 [-SliMonitoringPropertiesIdentityType <String>]
 [-SliMonitoringPropertiesIdentityUserAssignedIdentity <String>] [-SliMonitoringPropertySli <ISliSelection[]>]
 [-UserAssignedIdentity <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentity
```
New-AzResilienceDrill -InputObject <IResilienceIdentity> -Resource <IDrill> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Drill

## EXAMPLES

### Example 1: Create a drill
```powershell
New-AzResilienceDrill `
  -Name 'drill-zonal-payments' `
  -ServiceGroupName 'azcmdlet-testing' `
  -DrillType 'Zonal'
```

Creates a new drill in the specified service group.

## PARAMETERS

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
```

### -ChaosResourceIdentityForFaultType
Identity type linked with the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChaosResourceIdentityForFaultUserAssignedIdentity
User assigned identity id linked with the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChaosResourcePropertiesIdentityType
Identity type linked with the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChaosResourcePropertiesIdentityUserAssignedIdentity
User assigned identity id linked with the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
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

### -DrillAssetPropertyRegion
Region where Drill's internal resources will be created.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DrillAssetPropertyResourceGroup
Resource group where Drill's internal resources will be created.
If not specified, defaults to 'AzureResilienceManagementDrills'.
This value is immutable after drill creation.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DrillAssetPropertySubscription
Subscription where Drill's internal resources will be created.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DrillType
The discriminator for the Drill object hierarchy.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableSystemAssignedIdentity
Determines whether to enable a system-assigned identity for the resource.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthModelMonitoringPropertiesIdentityType
Identity type linked with the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthModelMonitoringPropertiesIdentityUserAssignedIdentity
User assigned identity id linked with the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthModelMonitoringPropertyDiscoveryRuleId
Full ARM Id of the discovery rule inside the Azure Health Model.
The parent Health Model is derived from this Id; it is the only identifier accepted on the wire.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: CreateViaIdentityExpanded, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitoringPropertiesIdentityType
Identity type linked with the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MonitoringPropertiesIdentityUserAssignedIdentity
User assigned identity id linked with the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Drill

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityServiceGroup, Create
Aliases: DrillName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -RbacSetupMode
RBAC setup mode.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryPlanPropertiesIdentityType
Identity type linked with the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryPlanPropertiesIdentityUserAssignedIdentity
User assigned identity id linked with the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
Drill resource

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrill
Parameter Sets: CreateViaIdentityServiceGroup, Create, CreateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity
Parameter Sets: CreateViaIdentityServiceGroupExpanded, CreateViaIdentityServiceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ServiceGroupName
The name of the service group.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath, Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SliMonitoringPropertiesIdentityType
Identity type linked with the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SliMonitoringPropertiesIdentityUserAssignedIdentity
User assigned identity id linked with the resource

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SliMonitoringPropertySli
The SLIs selected for Drill monitoring.
Maximum of two entries: at most one Availability and one Latency.
Duplicate types or duplicate SLI Ids are rejected.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.ISliSelection[]
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded, CreateViaIdentityServiceGroupExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrill

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IResilienceIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resilience.Models.IDrill

## NOTES

## RELATED LINKS
