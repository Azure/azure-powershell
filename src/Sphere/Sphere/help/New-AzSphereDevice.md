---
external help file: Az.Sphere-help.xml
Module Name: Az.Sphere
online version: https://learn.microsoft.com/powershell/module/az.sphere/new-azspheredevice
schema: 2.0.0
---

# New-AzSphereDevice

## SYNOPSIS
Create a Device.
Use '.unassigned' or '.default' for the device group and product names to claim a device to the catalog only.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSphereDevice -CatalogName <String> -GroupName <String> -Name <String> -ProductName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-DeviceId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzSphereDevice -CatalogName <String> -GroupName <String> -Name <String> -ProductName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzSphereDevice -CatalogName <String> -GroupName <String> -Name <String> -ProductName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Device.
Use '.unassigned' or '.default' for the device group and product names to claim a device to the catalog only.

## EXAMPLES

### Example 1: Create a device
```powershell
New-AzSphereDevice -CatalogName "anotherNewOne" -GroupName ".default" -Name "45ffd2afe82d77b2b70f1daed2054abc64853a27395c6112d9adaf01047bae5a0caa72219f93db02e1a93f2c159ba2090a783077138e7fa542459621e6091e4c" -ProductName ".default" -ResourceGroupName "goyedokun"
```

```output
ChipSku                      : MT3620AN
DeviceId                     : fc9085337153e47eca0d42dcae83819f18ae90d916ae3b87d0206fef6acb9ca44f9e21b93c01311e83168393d112841decc5ef6d48c3d1d07be6b0bf8fec6e2b
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/goyedokun/providers/Microsoft.AzureSphere/catalogs/anotherNewOne/products/.default/deviceGroups/.default/devices/FC9085337153E47ECA0D42DCAE83819F18AE90D916AE3B87D0206FEF6ACB9CA44F9E21B93C01311E83168393D112841DECC5EF6D48C3D1D07BE6B0BF8FEC6E2B
LastAvailableOSVersion       :
LastInstalledOSVersion       :
LastOSUpdateUtc              :
LastUpdateRequestUtc         :
Name                         : fc9085337153e47eca0d42dcae83819f18ae90d916ae3b87d0206fef6acb9ca44f9e21b93c01311e83168393d112841decc5ef6d48c3d1d07be6b0bf8fec6e2b
ProvisioningState            : Succeeded
ResourceGroupName            : goyedokun
RetryAfter                   :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups/devices
```

This command creates a device.

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

### -CatalogName
Name of catalog

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

### -DeviceId
Device ID

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

### -GroupName
Name of device group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DeviceGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -Name
Device name

```yaml
Type: System.String
Parameter Sets: (All)
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

### -ProductName
Name of product.

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

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.IDevice

## NOTES

## RELATED LINKS
