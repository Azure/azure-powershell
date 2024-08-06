---
external help file:
Module Name: Az.Sphere
online version: https://learn.microsoft.com/powershell/module/az.sphere/get-azspheredevice
schema: 2.0.0
---

# Get-AzSphereDevice

## SYNOPSIS
Get a Device.
Use '.unassigned' or '.default' for the device group and product names when a device does not belong to a device group and product.

## SYNTAX

### List (Default)
```
Get-AzSphereDevice -CatalogName <String> -GroupName <String> -ProductName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSphereDevice -CatalogName <String> -GroupName <String> -Name <String> -ProductName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSphereDevice -InputObject <ISphereIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityCatalog
```
Get-AzSphereDevice -CatalogInputObject <ISphereIdentity> -GroupName <String> -Name <String>
 -ProductName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityDeviceGroup
```
Get-AzSphereDevice -DeviceGroupInputObject <ISphereIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityProduct
```
Get-AzSphereDevice -GroupName <String> -Name <String> -ProductInputObject <ISphereIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a Device.
Use '.unassigned' or '.default' for the device group and product names when a device does not belong to a device group and product.

## EXAMPLES

### Example 1: List by resource group
```powershell
Get-AzSphereDevice -CatalogName test2024 -ResourceGroupName "group-test" -GroupName testdevicegroup -ProductName product2024
```

```output
Name                                                                                                                             SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy System 
                                                                                                                                                                                                                                                   DataLa 
                                                                                                                                                                                                                                                   stModi 
                                                                                                                                                                                                                                                   fiedBy 
                                                                                                                                                                                                                                                   Type   
----                                                                                                                             ------------------- ------------------- ----------------------- ------------------------ ------------------------ ------ 
device1b8bd961a6129096e1e8a1375ac1fa274f030c08161b37ae3bc5a94f443bdb628cf257bc5bc810d8768c03b6f5ca301a35cd0169f56a49624255964560
device203ba55fb52b00fec8549fdaa46b7fb6ba35694bc8943131ccb4b302846d224580a27880a2996b9fd4f1b2699400b1627059b6a90d67dd29e2984ee147
device3cf76a5853832122d9b0e2410daa1438e3c1cde005162a837a7535c08973cc819a50cf8eb724ffc88dada06b40bee6010e82a8f84d2fef0fc263061d67
```

This command gets list of device resources by resource group.

### Example 2: Get specific resource with specified resource group
```powershell
Get-AzSphereDevice -CatalogName test2024 -ResourceGroupName "group-test" -GroupName testdevicegroup -ProductName product2024 -Name device1b8bd961a6129096e1e8a1375ac1fa274f030c08161b37ae3bc5a94f443bdb628cf257bc5bc810d8768c03b6f5ca301a35cd0169f56a49624255964560
```

```output
ChipSku                      : MT3620AN
DeviceId                     : dbb0e0cb8bd961a6129096e1e8a1375ac1fa274f030c08161b37ae3bc5a94f443bdb628cf257bc5bc810d8768c03b6f5ca301a35cd0169f56a49624255964560
Id                           : /subscriptions/11111111-2222-3333-4444-123456789103/resourceGroups/group-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024/deviceGroups/testdevicegroup/devices/device1b8bd961a6129096e1e8a1375ac1fa274f030c08161b37ae3bc5a94f443bdb628cf257bc5bc810d8768c03b6f5ca301a35cd0169f56a49624255964560
LastAvailableOSVersion       : 
LastInstalledOSVersion       : 
LastOSUpdateUtc              : 
LastUpdateRequestUtc         : 
Name                         : device1b8bd961a6129096e1e8a1375ac1fa274f030c08161b37ae3bc5a94f443bdb628cf257bc5bc810d8768c03b6f5ca301a35cd0169f56a49624255964560
ProvisioningState            : Succeeded
ResourceGroupName            : group-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups/devices
```

This command gets specific device resource with specified resource group.

## PARAMETERS

### -CatalogInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentityCatalog
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
Parameter Sets: Get, List
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

### -DeviceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentityDeviceGroup
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
Parameter Sets: Get, GetViaIdentityCatalog, GetViaIdentityProduct, List
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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Device name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCatalog, GetViaIdentityDeviceGroup, GetViaIdentityProduct
Aliases: DeviceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProductInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentityProduct
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
Parameter Sets: Get, GetViaIdentityCatalog, List
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

