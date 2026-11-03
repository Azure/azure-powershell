---
external help file:
Module Name: Az.CloudHealth
online version: https://learn.microsoft.com/powershell/module/az.cloudhealth/get-azmonitorhealthmodelentitydataannotation
schema: 2.0.0
---

# Get-AzMonitorHealthModelEntityDataAnnotation

## SYNOPSIS
Retrieve data annotations for an entity

## SYNTAX

### GetExpanded (Default)
```
Get-AzMonitorHealthModelEntityDataAnnotation -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-EndAt <DateTime>] [-NextMarker <String>]
 [-StartAt <DateTime>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMonitorHealthModelEntityDataAnnotation -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> -Body <IGetDataAnnotationsRequest> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMonitorHealthModelEntityDataAnnotation -InputObject <ICloudHealthIdentity>
 -Body <IGetDataAnnotationsRequest> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzMonitorHealthModelEntityDataAnnotation -InputObject <ICloudHealthIdentity> [-EndAt <DateTime>]
 [-NextMarker <String>] [-StartAt <DateTime>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityHealthmodel
```
Get-AzMonitorHealthModelEntityDataAnnotation -EntityName <String>
 -HealthmodelInputObject <ICloudHealthIdentity> -Body <IGetDataAnnotationsRequest>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityHealthmodelExpanded
```
Get-AzMonitorHealthModelEntityDataAnnotation -EntityName <String>
 -HealthmodelInputObject <ICloudHealthIdentity> [-EndAt <DateTime>] [-NextMarker <String>]
 [-StartAt <DateTime>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaJsonFilePath
```
Get-AzMonitorHealthModelEntityDataAnnotation -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaJsonString
```
Get-AzMonitorHealthModelEntityDataAnnotation -EntityName <String> -HealthModelName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieve data annotations for an entity

## EXAMPLES

### Example 1: List the annotations on an entity
```powershell
# Retrieve all data annotations on the entity frontend-service
Get-AzMonitorHealthModelEntityDataAnnotation -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -EntityName frontend-service
```

Returns the data annotations recorded against the entity.

## PARAMETERS

### -Body
Request body for querying data annotations

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IGetDataAnnotationsRequest
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
End of UTC time range.
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
Start of UTC time range.
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
Maximum number of annotations to return per page.
Defaults to 100.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.ICloudHealthIdentity

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IGetDataAnnotationsRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudHealth.Models.IGetDataAnnotationsResponse

## NOTES

## RELATED LINKS

