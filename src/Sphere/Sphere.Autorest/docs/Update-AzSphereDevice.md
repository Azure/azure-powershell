---
external help file:
Module Name: Az.Sphere
online version: https://learn.microsoft.com/powershell/module/az.sphere/update-azspheredevice
schema: 2.0.0
---

# Update-AzSphereDevice

## SYNOPSIS
Update a Device.
Use '.unassigned' or '.default' for the device group and product names to move a device to the catalog level.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSphereDevice -CatalogName <String> -GroupName <String> -Name <String> -ProductName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DeviceGroupId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityCatalogExpanded
```
Update-AzSphereDevice -CatalogInputObject <ISphereIdentity> -GroupName <String> -Name <String>
 -ProductName <String> [-DeviceGroupId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityDeviceGroupExpanded
```
Update-AzSphereDevice -DeviceGroupInputObject <ISphereIdentity> -Name <String> [-DeviceGroupId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSphereDevice -InputObject <ISphereIdentity> [-DeviceGroupId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityProductExpanded
```
Update-AzSphereDevice -GroupName <String> -Name <String> -ProductInputObject <ISphereIdentity>
 [-DeviceGroupId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzSphereDevice -CatalogName <String> -GroupName <String> -Name <String> -ProductName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzSphereDevice -CatalogName <String> -GroupName <String> -Name <String> -ProductName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a Device.
Use '.unassigned' or '.default' for the device group and product names to move a device to the catalog level.

## EXAMPLES

### Example 1: Assign a device to another device group
```powershell
Update-AzSphereDevice -ResourceGroupName joyer-test -CatalogName test2024 -GroupName testdevicegroup -ProductName product2024 -Name DBB0E0CB8BD961A6129096E1E8A1375AC1FA274F030C08161B37AE3BC5A94F443BDB628CF257BC5BC810D8768C03B6F5CA301A35CD0169F56A49624255964560 -DeviceGroupId /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024/deviceGroups/testdevicegroup2
```

```output
ChipSku                      : 
DeviceId                     : 
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/providers/Microsoft.AzureSphere/locations/WESTCENTRALUS/operationStatuses/dc3e0b1a-59ae-4b00-bb84-9 
                               a7ea253f4e8*648856149066E98CE43CF51B8F3FC827768BFF5C8740097AD36EDFC456E7B110
LastAvailableOSVersion       : 
LastInstalledOSVersion       : 
LastOSUpdateUtc              : 
LastUpdateRequestUtc         : 
Name                         : dc3e0b1a-59ae-4b00-bb84-9a7ea253f4e8*648856149066E98CE43CF51B8F3FC827768BFF5C8740097AD36EDFC456E7B110
ProvisioningState            : 
ResourceGroupName            : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : 
```

This command assign a device to another device group.

### Example 2: unassign a device
```powershell
Update-AzSphereDevice -ResourceGroupName joyer-test -CatalogName test2024 -GroupName testdevicegroup -ProductName product2024 -Name DBB0E0CB8BD961A6129096E1E8A1375AC1FA274F030C08161B37AE3BC5A94F443BDB628CF257BC5BC810D8768C03B6F5CA301A35CD0169F56A49624255964560 -DeviceGroupId /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/.default/deviceGroups/.default
```

```output
ChipSku                      : 
DeviceId                     : 
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/providers/Microsoft.AzureSphere/locations/WESTCENTRALUS/operationStatuses/89c583a1-2a79-4f5f-ab4b-7e1cc7fb52e7* 
                               648856149066E98CE43CF51B8F3FC827768BFF5C8740097AD36EDFC456E7B110
LastAvailableOSVersion       : 
LastInstalledOSVersion       : 
LastOSUpdateUtc              : 
LastUpdateRequestUtc         : 
Name                         : 89c583a1-2a79-4f5f-ab4b-7e1cc7fb52e7*648856149066E98CE43CF51B8F3FC827768BFF5C8740097AD36EDFC456E7B110
ProvisioningState            : 
ResourceGroupName            : 
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : 
```

This command unassign a device to catalog.

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

### -CatalogInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: UpdateViaIdentityCatalogExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CatalogName
Name of catalog

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

### -DeviceGroupId
Device group id

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityCatalogExpanded, UpdateViaIdentityDeviceGroupExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProductExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeviceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: UpdateViaIdentityDeviceGroupExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -GroupName
Name of device group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityCatalogExpanded, UpdateViaIdentityProductExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: DeviceGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
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

### -Name
Device name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityCatalogExpanded, UpdateViaIdentityDeviceGroupExpanded, UpdateViaIdentityProductExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases: DeviceName

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

### -ProductInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: UpdateViaIdentityProductExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProductName
Name of product.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityCatalogExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonFilePath, UpdateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.IDevice

## NOTES

## RELATED LINKS

