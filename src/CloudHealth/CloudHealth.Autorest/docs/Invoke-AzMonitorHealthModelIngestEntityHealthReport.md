---
external help file:
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/az.cloudhealth/invoke-azmonitorhealthmodelingestentityhealthreport
schema: 2.0.0
---

# Invoke-AzMonitorHealthModelIngestEntityHealthReport

## SYNOPSIS
Ingest a health report for a specific signal on an entity (the entity must already exist)

## SYNTAX

### IngestExpanded (Default)
```
Invoke-AzMonitorHealthModelIngestEntityHealthReport -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> -HealthState <String> -SignalName <String> [-SubscriptionId <String>]
 [-AdditionalContext <String>] [-EvaluationRuleDegradedRule <IThresholdRuleV2>]
 [-EvaluationRuleUnhealthyRule <IThresholdRuleV2>] [-ExpiresInMinute <Int32>] [-Value <Double>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Ingest
```
Invoke-AzMonitorHealthModelIngestEntityHealthReport -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> -Body <IHealthReportRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### IngestViaIdentity
```
Invoke-AzMonitorHealthModelIngestEntityHealthReport -InputObject <ICloudHealthIdentity>
 -Body <IHealthReportRequest> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### IngestViaIdentityExpanded
```
Invoke-AzMonitorHealthModelIngestEntityHealthReport -InputObject <ICloudHealthIdentity> -HealthState <String>
 -SignalName <String> [-AdditionalContext <String>] [-EvaluationRuleDegradedRule <IThresholdRuleV2>]
 [-EvaluationRuleUnhealthyRule <IThresholdRuleV2>] [-ExpiresInMinute <Int32>] [-Value <Double>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### IngestViaIdentityHealthmodel
```
Invoke-AzMonitorHealthModelIngestEntityHealthReport -EntityName <String>
 -HealthmodelInputObject <ICloudHealthIdentity> -Body <IHealthReportRequest> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### IngestViaIdentityHealthmodelExpanded
```
Invoke-AzMonitorHealthModelIngestEntityHealthReport -EntityName <String>
 -HealthmodelInputObject <ICloudHealthIdentity> -HealthState <String> -SignalName <String>
 [-AdditionalContext <String>] [-EvaluationRuleDegradedRule <IThresholdRuleV2>]
 [-EvaluationRuleUnhealthyRule <IThresholdRuleV2>] [-ExpiresInMinute <Int32>] [-Value <Double>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### IngestViaJsonFilePath
```
Invoke-AzMonitorHealthModelIngestEntityHealthReport -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### IngestViaJsonString
```
Invoke-AzMonitorHealthModelIngestEntityHealthReport -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Ingest a health report for a specific signal on an entity (the entity must already exist)

## EXAMPLES

### Example 1: Report a health state for an entity
```powershell
Invoke-AzMonitorHealthModelIngestEntityHealthReport -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service -SignalName checkout-latency -HealthState Degraded -Value 142.5 -ExpiresInMinute 60
```

Pushes an external health signal into the model.
The report expires after 60 minutes unless it is sent again.

## PARAMETERS

### -AdditionalContext
Optional additional context or description for the health report

```yaml
Type: System.String
Parameter Sets: IngestExpanded, IngestViaIdentityExpanded, IngestViaIdentityHealthmodelExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Health report that's submitted for a specific signal

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IHealthReportRequest
Parameter Sets: Ingest, IngestViaIdentity, IngestViaIdentityHealthmodel
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -EntityName
Name of the entity.
Must be unique within a health model.

```yaml
Type: System.String
Parameter Sets: Ingest, IngestExpanded, IngestViaIdentityHealthmodel, IngestViaIdentityHealthmodelExpanded, IngestViaJsonFilePath, IngestViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EvaluationRuleDegradedRule
Degraded rule with static threshold.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IThresholdRuleV2
Parameter Sets: IngestExpanded, IngestViaIdentityExpanded, IngestViaIdentityHealthmodelExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EvaluationRuleUnhealthyRule
Unhealthy rule with static threshold.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IThresholdRuleV2
Parameter Sets: IngestExpanded, IngestViaIdentityExpanded, IngestViaIdentityHealthmodelExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExpiresInMinute
Number of minutes until the health report expires.
Defaults to 60 (1 hour) if not specified.

```yaml
Type: System.Int32
Parameter Sets: IngestExpanded, IngestViaIdentityExpanded, IngestViaIdentityHealthmodelExpanded
Aliases:

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
Parameter Sets: IngestViaIdentityHealthmodel, IngestViaIdentityHealthmodelExpanded
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
Parameter Sets: Ingest, IngestExpanded, IngestViaJsonFilePath, IngestViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthState
Health state to report for the signal

```yaml
Type: System.String
Parameter Sets: IngestExpanded, IngestViaIdentityExpanded, IngestViaIdentityHealthmodelExpanded
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
Parameter Sets: IngestViaIdentity, IngestViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Ingest operation

```yaml
Type: System.String
Parameter Sets: IngestViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Ingest operation

```yaml
Type: System.String
Parameter Sets: IngestViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Ingest, IngestExpanded, IngestViaJsonFilePath, IngestViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SignalName
Name of the entity signal to report health for

```yaml
Type: System.String
Parameter Sets: IngestExpanded, IngestViaIdentityExpanded, IngestViaIdentityHealthmodelExpanded
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
Parameter Sets: Ingest, IngestExpanded, IngestViaJsonFilePath, IngestViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Value
Reported value of the signal

```yaml
Type: System.Double
Parameter Sets: IngestExpanded, IngestViaIdentityExpanded, IngestViaIdentityHealthmodelExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IHealthReportRequest

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

