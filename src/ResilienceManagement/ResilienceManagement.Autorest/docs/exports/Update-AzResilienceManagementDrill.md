---
external help file:
Module Name: Az.ResilienceManagement
online version: https://learn.microsoft.com/powershell/module/az.resiliencemanagement/update-azresiliencemanagementdrill
schema: 2.0.0
---

# Update-AzResilienceManagementDrill

## SYNOPSIS
Update a Drill

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzResilienceManagementDrill -Name <String> -ServiceGroupName <String>
 [-ChaosResourceIdentityForFaultType <String>] [-ChaosResourceIdentityForFaultUserAssignedIdentity <String>]
 [-ChaosResourcePropertiesIdentityType <String>]
 [-ChaosResourcePropertiesIdentityUserAssignedIdentity <String>] [-DrillAssetPropertyRegion <String>]
 [-DrillAssetPropertySubscription <String>] [-HealthModelMonitoringPropertiesIdentityType <String>]
 [-HealthModelMonitoringPropertiesIdentityUserAssignedIdentity <String>]
 [-HealthModelMonitoringPropertyDiscoveryRuleId <String>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-MonitoringPropertiesIdentityType <String>]
 [-MonitoringPropertiesIdentityUserAssignedIdentity <String>] [-RbacSetupMode <String>]
 [-RecoveryPlanPropertiesIdentityType <String>] [-RecoveryPlanPropertiesIdentityUserAssignedIdentity <String>]
 [-SliMonitoringPropertiesIdentityType <String>]
 [-SliMonitoringPropertiesIdentityUserAssignedIdentity <String>] [-SliMonitoringPropertySli <ISliSelection[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzResilienceManagementDrill -InputObject <IResilienceManagementIdentity>
 [-ChaosResourceIdentityForFaultType <String>] [-ChaosResourceIdentityForFaultUserAssignedIdentity <String>]
 [-ChaosResourcePropertiesIdentityType <String>]
 [-ChaosResourcePropertiesIdentityUserAssignedIdentity <String>] [-DrillAssetPropertyRegion <String>]
 [-DrillAssetPropertySubscription <String>] [-HealthModelMonitoringPropertiesIdentityType <String>]
 [-HealthModelMonitoringPropertiesIdentityUserAssignedIdentity <String>]
 [-HealthModelMonitoringPropertyDiscoveryRuleId <String>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-MonitoringPropertiesIdentityType <String>]
 [-MonitoringPropertiesIdentityUserAssignedIdentity <String>] [-RbacSetupMode <String>]
 [-RecoveryPlanPropertiesIdentityType <String>] [-RecoveryPlanPropertiesIdentityUserAssignedIdentity <String>]
 [-SliMonitoringPropertiesIdentityType <String>]
 [-SliMonitoringPropertiesIdentityUserAssignedIdentity <String>] [-SliMonitoringPropertySli <ISliSelection[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityServiceGroupExpanded
```
Update-AzResilienceManagementDrill -Name <String> -ServiceGroupInputObject <IResilienceManagementIdentity>
 [-ChaosResourceIdentityForFaultType <String>] [-ChaosResourceIdentityForFaultUserAssignedIdentity <String>]
 [-ChaosResourcePropertiesIdentityType <String>]
 [-ChaosResourcePropertiesIdentityUserAssignedIdentity <String>] [-DrillAssetPropertyRegion <String>]
 [-DrillAssetPropertySubscription <String>] [-HealthModelMonitoringPropertiesIdentityType <String>]
 [-HealthModelMonitoringPropertiesIdentityUserAssignedIdentity <String>]
 [-HealthModelMonitoringPropertyDiscoveryRuleId <String>] [-IdentityType <String>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-MonitoringPropertiesIdentityType <String>]
 [-MonitoringPropertiesIdentityUserAssignedIdentity <String>] [-RbacSetupMode <String>]
 [-RecoveryPlanPropertiesIdentityType <String>] [-RecoveryPlanPropertiesIdentityUserAssignedIdentity <String>]
 [-SliMonitoringPropertiesIdentityType <String>]
 [-SliMonitoringPropertiesIdentityUserAssignedIdentity <String>] [-SliMonitoringPropertySli <ISliSelection[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzResilienceManagementDrill -Name <String> -ServiceGroupName <String> -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzResilienceManagementDrill -Name <String> -ServiceGroupName <String> -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a Drill

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
{{ Add code here }}
```



### -------------------------- EXAMPLE 2 --------------------------
```powershell
{{ Add code here }}
```



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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
The type of managed identity assigned to this resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The identities assigned to this resource by the user.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityServiceGroupExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceGroupInputObject
Identity Parameter
To construct, see NOTES section for SERVICEGROUPINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity
Parameter Sets: UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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
To construct, see NOTES section for SLIMONITORINGPROPERTYSLI properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.ISliSelection[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityServiceGroupExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IResilienceManagementIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ResilienceManagement.Models.IDrill

## NOTES

## RELATED LINKS

