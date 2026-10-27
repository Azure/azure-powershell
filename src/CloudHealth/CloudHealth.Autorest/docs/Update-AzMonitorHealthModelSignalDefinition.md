---
external help file:
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/az.cloudhealth/update-azmonitorhealthmodelsignaldefinition
schema: 2.0.0
---

# Update-AzMonitorHealthModelSignalDefinition

## SYNOPSIS
Update a SignalDefinition

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzMonitorHealthModelSignalDefinition -HealthModelName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-Property <ISignalDefinitionProperties>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzMonitorHealthModelSignalDefinition -HealthModelName <String> -Name <String>
 -ResourceGroupName <String> -Resource <ISignalDefinition> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzMonitorHealthModelSignalDefinition -InputObject <ICloudHealthIdentity> -Resource <ISignalDefinition>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzMonitorHealthModelSignalDefinition -InputObject <ICloudHealthIdentity>
 [-Property <ISignalDefinitionProperties>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityHealthmodel
```
Update-AzMonitorHealthModelSignalDefinition -HealthmodelInputObject <ICloudHealthIdentity> -Name <String>
 -Resource <ISignalDefinition> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityHealthmodelExpanded
```
Update-AzMonitorHealthModelSignalDefinition -HealthmodelInputObject <ICloudHealthIdentity> -Name <String>
 [-Property <ISignalDefinitionProperties>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a SignalDefinition

## EXAMPLES

### Example 1: Raise the thresholds on a signal definition
```powershell
# Update the thresholds on the signal definition cpu-utilization
$degraded = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 75
$unhealthy = New-AzMonitorHealthModelThresholdRuleV2Object -Operator GreaterThan -Threshold 95
$rules = New-AzMonitorHealthModelEvaluationRuleObject -DegradedRule $degraded -UnhealthyRule $unhealthy
$property = New-AzMonitorHealthModelResourceMetricSignalDefinitionPropertiesObject -MetricNamespace 'Microsoft.Compute/virtualMachines' -MetricName 'Percentage CPU' -TimeGrain PT5M -AggregationType Average -EvaluationRule $rules -DisplayName 'CPU Utilization'
Update-AzMonitorHealthModelSignalDefinition -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name cpu-utilization -Property $property
```

Updates the degraded threshold to 75 and the unhealthy threshold to 95.

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

### -HealthmodelInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity
Parameter Sets: UpdateViaIdentityHealthmodel, UpdateViaIdentityHealthmodelExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -HealthModelName
Name of health model resource

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the signal definition.
Must be unique within a health model.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded, UpdateViaIdentityHealthmodel, UpdateViaIdentityHealthmodelExpanded
Aliases: SignalDefinitionName

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

### -Property
The resource-specific properties for this resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalDefinitionProperties
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityHealthmodelExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
A signal definition in a health model

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalDefinition
Parameter Sets: Update, UpdateViaIdentity, UpdateViaIdentityHealthmodel
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalDefinition

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalDefinition

## NOTES

## RELATED LINKS

