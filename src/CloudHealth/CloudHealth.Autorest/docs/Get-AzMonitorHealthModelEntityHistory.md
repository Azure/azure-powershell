---
external help file:
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/az.cloudhealth/get-azmonitorhealthmodelentityhistory
schema: 2.0.0
---

# Get-AzMonitorHealthModelEntityHistory

## SYNOPSIS
Retrieve the health state transition history for an entity

## SYNTAX

### GetExpanded (Default)
```
Get-AzMonitorHealthModelEntityHistory -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-EndAt <DateTime>] [-NextMarker <String>]
 [-StartAt <DateTime>] [-Top <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Get
```
Get-AzMonitorHealthModelEntityHistory -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> -Body <IEntityHistoryRequest> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMonitorHealthModelEntityHistory -InputObject <ICloudHealthIdentity> -Body <IEntityHistoryRequest>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzMonitorHealthModelEntityHistory -InputObject <ICloudHealthIdentity> [-EndAt <DateTime>]
 [-NextMarker <String>] [-StartAt <DateTime>] [-Top <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GetViaIdentityHealthmodel
```
Get-AzMonitorHealthModelEntityHistory -EntityName <String> -HealthmodelInputObject <ICloudHealthIdentity>
 -Body <IEntityHistoryRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityHealthmodelExpanded
```
Get-AzMonitorHealthModelEntityHistory -EntityName <String> -HealthmodelInputObject <ICloudHealthIdentity>
 [-EndAt <DateTime>] [-NextMarker <String>] [-StartAt <DateTime>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaJsonFilePath
```
Get-AzMonitorHealthModelEntityHistory -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaJsonString
```
Get-AzMonitorHealthModelEntityHistory -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Retrieve the health state transition history for an entity

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -Body
Request body for getting entity health history

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IEntityHistoryRequest
Parameter Sets: Get, GetViaIdentity, GetViaIdentityHealthmodel
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

### -EndAt
End time for the history query.
Defaults to now if not specified.

```yaml
Type: System.DateTime
Parameter Sets: GetExpanded, GetViaIdentityExpanded, GetViaIdentityHealthmodelExpanded
Aliases:

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
Parameter Sets: Get, GetExpanded, GetViaIdentityHealthmodel, GetViaIdentityHealthmodelExpanded, GetViaJsonFilePath, GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HealthmodelInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity
Parameter Sets: GetViaIdentityHealthmodel, GetViaIdentityHealthmodelExpanded
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
Parameter Sets: Get, GetExpanded, GetViaJsonFilePath, GetViaJsonString
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
Parameter Sets: GetViaIdentity, GetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Get operation

```yaml
Type: System.String
Parameter Sets: GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NextMarker
An opaque string value that identifies the portion of the result set to be returned with the next operation.
Must not be combined with startAt or endAt.

```yaml
Type: System.String
Parameter Sets: GetExpanded, GetViaIdentityExpanded, GetViaIdentityHealthmodelExpanded
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
Parameter Sets: Get, GetExpanded, GetViaJsonFilePath, GetViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartAt
Start time for the history query.
Defaults to 24 hours ago if not specified.

```yaml
Type: System.DateTime
Parameter Sets: GetExpanded, GetViaIdentityExpanded, GetViaIdentityHealthmodelExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: Get, GetExpanded, GetViaJsonFilePath, GetViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Maximum number of health state transitions to return per page.
Defaults to 1000.

```yaml
Type: System.Int32
Parameter Sets: GetExpanded, GetViaIdentityExpanded, GetViaIdentityHealthmodelExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IEntityHistoryRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IEntityHistoryResponse

## NOTES

## RELATED LINKS

