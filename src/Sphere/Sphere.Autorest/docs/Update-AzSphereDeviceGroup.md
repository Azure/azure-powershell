---
external help file:
Module Name: Az.Sphere
online version: https://learn.microsoft.com/powershell/module/az.sphere/update-azspheredevicegroup
schema: 2.0.0
---

# Update-AzSphereDeviceGroup

## SYNOPSIS
Update a DeviceGroup.
'.default' and '.unassigned' are system defined values and cannot be used for product or device group name.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSphereDeviceGroup -CatalogName <String> -Name <String> -ProductName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-AllowCrashDumpsCollection <String>]
 [-Description <String>] [-OSFeedType <String>] [-RegionalDataBoundary <String>] [-UpdatePolicy <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityCatalogExpanded
```
Update-AzSphereDeviceGroup -CatalogInputObject <ISphereIdentity> -Name <String> -ProductName <String>
 [-AllowCrashDumpsCollection <String>] [-Description <String>] [-OSFeedType <String>]
 [-RegionalDataBoundary <String>] [-UpdatePolicy <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSphereDeviceGroup -InputObject <ISphereIdentity> [-AllowCrashDumpsCollection <String>]
 [-Description <String>] [-OSFeedType <String>] [-RegionalDataBoundary <String>] [-UpdatePolicy <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityProductExpanded
```
Update-AzSphereDeviceGroup -Name <String> -ProductInputObject <ISphereIdentity>
 [-AllowCrashDumpsCollection <String>] [-Description <String>] [-OSFeedType <String>]
 [-RegionalDataBoundary <String>] [-UpdatePolicy <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzSphereDeviceGroup -CatalogName <String> -Name <String> -ProductName <String>
 -ResourceGroupName <String> -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzSphereDeviceGroup -CatalogName <String> -Name <String> -ProductName <String>
 -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update a DeviceGroup.
'.default' and '.unassigned' are system defined values and cannot be used for product or device group name.

## EXAMPLES

### Example 1: Update device group
```powershell
Update-AzSphereDeviceGroup -ResourceGroupName group-test -CatalogName test2024 -ProductName product2024 -Name testdevicegroup -Description test
```

```output
AllowCrashDumpsCollection    : 
Description                  : test
HasDeployment                : 
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024/deviceGroups/testdevicegroup
Name                         : testdevicegroup
OSFeedType                   : 
ProvisioningState            : Succeeded
RegionalDataBoundary         : 
ResourceGroupName            : group-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups
UpdatePolicy                 : 
```

This command updates device group.

## PARAMETERS

### -AllowCrashDumpsCollection
Flag to define if the user allows for crash dump collection.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityCatalogExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProductExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Description
Description of the device group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityCatalogExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProductExpanded
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

### -OSFeedType
Operating system feed type of the device group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityCatalogExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProductExpanded
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

### -RegionalDataBoundary
Regional data boundary for the device group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityCatalogExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProductExpanded
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

### -UpdatePolicy
Update policy of the device group.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityCatalogExpanded, UpdateViaIdentityExpanded, UpdateViaIdentityProductExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.IDeviceGroup

## NOTES

## RELATED LINKS

