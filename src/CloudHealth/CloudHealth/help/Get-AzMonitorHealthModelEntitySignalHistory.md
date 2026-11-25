---
external help file: Az.CloudHealth-help.xml
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/az.cloudhealth/get-azmonitorhealthmodelentitysignalhistory
schema: 2.0.0
---

# Get-AzMonitorHealthModelEntitySignalHistory

## SYNOPSIS
Retrieve the time series history for a signal on an entity

## SYNTAX

### GetExpanded (Default)
```
Get-AzMonitorHealthModelEntitySignalHistory -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] -SignalName <String> [-EndAt <DateTime>]
 [-NextMarker <String>] [-StartAt <DateTime>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaJsonString
```
Get-AzMonitorHealthModelEntitySignalHistory -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] -JsonString <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaJsonFilePath
```
Get-AzMonitorHealthModelEntitySignalHistory -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityHealthmodelExpanded
```
Get-AzMonitorHealthModelEntitySignalHistory -EntityName <String> -HealthmodelInputObject <ICloudHealthIdentity>
 -SignalName <String> [-EndAt <DateTime>] [-NextMarker <String>] [-StartAt <DateTime>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityHealthmodel
```
Get-AzMonitorHealthModelEntitySignalHistory -EntityName <String> -HealthmodelInputObject <ICloudHealthIdentity>
 -Body <ISignalHistoryRequest> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzMonitorHealthModelEntitySignalHistory -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] -Body <ISignalHistoryRequest>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzMonitorHealthModelEntitySignalHistory -InputObject <ICloudHealthIdentity> -SignalName <String>
 [-EndAt <DateTime>] [-NextMarker <String>] [-StartAt <DateTime>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMonitorHealthModelEntitySignalHistory -InputObject <ICloudHealthIdentity> -Body <ISignalHistoryRequest>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Retrieve the time series history for a signal on an entity

## EXAMPLES

### Example 1: Get the history of one signal on an entity
```powershell
# Retrieve the recorded values of the signal checkout-latency on the entity frontend-service
Get-AzMonitorHealthModelEntitySignalHistory -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service -SignalName checkout-latency
```

Returns the recorded values for a single signal.
SignalName is required.

## PARAMETERS

### -Body
Request body for getting signal history

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalHistoryRequest
Parameter Sets: GetViaIdentityHealthmodel, Get, GetViaIdentity
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
Parameter Sets: GetExpanded, GetViaIdentityHealthmodelExpanded, GetViaIdentityExpanded
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
Parameter Sets: GetExpanded, GetViaJsonString, GetViaJsonFilePath, GetViaIdentityHealthmodelExpanded, GetViaIdentityHealthmodel, Get
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
Parameter Sets: GetViaIdentityHealthmodelExpanded, GetViaIdentityHealthmodel
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
Parameter Sets: GetExpanded, GetViaJsonString, GetViaJsonFilePath, Get
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
Parameter Sets: GetViaIdentityExpanded, GetViaIdentity
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
Parameter Sets: GetExpanded, GetViaIdentityHealthmodelExpanded, GetViaIdentityExpanded
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
Parameter Sets: GetExpanded, GetViaJsonString, GetViaJsonFilePath, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SignalName
Name of the signal to get history for

```yaml
Type: System.String
Parameter Sets: GetExpanded, GetViaIdentityHealthmodelExpanded, GetViaIdentityExpanded
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
Parameter Sets: GetExpanded, GetViaIdentityHealthmodelExpanded, GetViaIdentityExpanded
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
Parameter Sets: GetExpanded, GetViaJsonString, GetViaJsonFilePath, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Maximum number of data points to return per page.
Defaults to 1000.

```yaml
Type: System.Int32
Parameter Sets: GetExpanded, GetViaIdentityHealthmodelExpanded, GetViaIdentityExpanded
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalHistoryRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ISignalHistoryResponse

## NOTES

## RELATED LINKS
