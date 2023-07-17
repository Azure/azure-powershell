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

### ListViaIdentityCatalog
```
Get-AzSphereDevice -CatalogInputObject <ISphereIdentity> -GroupName <String> -ProductName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListViaIdentityDeviceGroup
```
Get-AzSphereDevice -DeviceGroupInputObject <ISphereIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListViaIdentityProduct
```
Get-AzSphereDevice -GroupName <String> -ProductInputObject <ISphereIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Device.
Use '.unassigned' or '.default' for the device group and product names when a device does not belong to a device group and product.

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

### -CatalogInputObject
Identity Parameter
To construct, see NOTES section for CATALOGINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentityCatalog, ListViaIdentityCatalog
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
To construct, see NOTES section for DEVICEGROUPINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentityDeviceGroup, ListViaIdentityDeviceGroup
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
Parameter Sets: Get, GetViaIdentityCatalog, GetViaIdentityProduct, List, ListViaIdentityCatalog, ListViaIdentityProduct
Aliases: DeviceGroupName

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
To construct, see NOTES section for PRODUCTINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentityProduct, ListViaIdentityProduct
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
Parameter Sets: Get, GetViaIdentityCatalog, List, ListViaIdentityCatalog
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

