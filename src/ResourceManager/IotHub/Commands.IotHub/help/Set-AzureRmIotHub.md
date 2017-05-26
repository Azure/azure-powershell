---
external help file: Microsoft.Azure.Commands.IotHub.dll-Help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmIotHub

## SYNOPSIS
Updates the properties of an IotHub.

## SYNTAX

### UpdateSku (Default)
```
Set-AzureRmIotHub [-ResourceGroupName] <String> [-Name] <String> -SkuName <PSIotHubSku> [-Units <Int64>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateEventHubEndpointProperties
```
Set-AzureRmIotHub [-ResourceGroupName] <String> [-Name] <String> -EventHubRetentionTimeInDays <Int64> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateFileUploadProperties
```
Set-AzureRmIotHub [-ResourceGroupName] <String> [-Name] <String> [-FileUploadStorageConnectionString <String>]
 [-FileUploadContainerName <String>] [-FileUploadSasUriTtl <TimeSpan>] [-FileUploadNotificationTtl <TimeSpan>]
 [-FileUploadNotificationMaxDeliveryCount <Int32>] -EnableFileUploadNotifications <Boolean> [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateCloudToDeviceProperties
```
Set-AzureRmIotHub [-ResourceGroupName] <String> [-Name] <String> -CloudToDevice <PSCloudToDeviceProperties>
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateOperationsMonitoringProperties
```
Set-AzureRmIotHub [-ResourceGroupName] <String> [-Name] <String>
 -OperationsMonitoringProperties <PSOperationsMonitoringProperties> [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateRoutingProperties
```
Set-AzureRmIotHub [-ResourceGroupName] <String> [-Name] <String> [-RoutingProperties <PSRoutingProperties>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateRouteProperties
```
Set-AzureRmIotHub [-ResourceGroupName] <String> [-Name] <String>
 [-Routes <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Management.IotHub.Models.PSRouteMetadata]>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateFallbackRouteProperty
```
Set-AzureRmIotHub [-ResourceGroupName] <String> [-Name] <String> [-FallbackRoute <PSFallbackRouteMetadata>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the properties of an IotHub.

## EXAMPLES

### Example 1 Update the sku
```
PS C:\> Set-AzureRmIotHub -ResourceGroupName "myresourcegroup" -Name "myiothub" -SkuName S1 -Units 5
```

Update the sku to S1 and units to 5 for the IotHub named "myiothub"

### Example 2 Update the eventhub properties
```
PS C:\> Set-AzureRmIotHub -ResourceGroupName "myresourcegroup" -Name "myiothub" -EventHubRetentionTimeInDays 4
```

Update the retention time in days to 4 for both the telemetry and operationsmonitoringevents events for the IotHub named "myiothub"

## PARAMETERS

### -CloudToDevice
CloudToDevice

```yaml
Type: PSCloudToDeviceProperties
Parameter Sets: UpdateCloudToDeviceProperties
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableFileUploadNotifications
EnableFileUploadNotifications

```yaml
Type: Boolean
Parameter Sets: UpdateFileUploadProperties
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventHubRetentionTimeInDays
EventHubRetentionTimeInDays

```yaml
Type: Int64
Parameter Sets: UpdateEventHubEndpointProperties
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FallbackRoute
Fallback Routes

```yaml
Type: PSFallbackRouteMetadata
Parameter Sets: UpdateFallbackRouteProperty
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileUploadContainerName
FileUploadContainerName

```yaml
Type: String
Parameter Sets: UpdateFileUploadProperties
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileUploadNotificationMaxDeliveryCount
fileUploadNotificationMaxDeliveryCount

```yaml
Type: Int32
Parameter Sets: UpdateFileUploadProperties
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileUploadNotificationTtl
FileUploadNotificationTtl

```yaml
Type: TimeSpan
Parameter Sets: UpdateFileUploadProperties
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileUploadSasUriTtl
FileUploadSasUriTtl

```yaml
Type: TimeSpan
Parameter Sets: UpdateFileUploadProperties
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FileUploadStorageConnectionString
FileUploadStorageConnectionString

```yaml
Type: String
Parameter Sets: UpdateFileUploadProperties
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OperationsMonitoringProperties
OperationsMonitoringProperties

```yaml
Type: PSOperationsMonitoringProperties
Parameter Sets: UpdateOperationsMonitoringProperties
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Routes
Routes

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Management.IotHub.Models.PSRouteMetadata]
Parameter Sets: UpdateRouteProperties
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RoutingProperties
RoutingProperties

```yaml
Type: PSRoutingProperties
Parameter Sets: UpdateRoutingProperties
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuName
SkuName

```yaml
Type: PSIotHubSku
Parameter Sets: UpdateSku
Aliases: 
Accepted values: F1, S1, S2, S3

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Units
Units

```yaml
Type: Int64
Parameter Sets: UpdateSku
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
Microsoft.Azure.Commands.Management.IotHub.Models.PSCloudToDeviceProperties Microsoft.Azure.Commands.Management.IotHub.Models.PSOperationsMonitoringProperties

## OUTPUTS

### Microsoft.Azure.Commands.Management.IotHub.Models.PSIotHub

## NOTES

## RELATED LINKS

