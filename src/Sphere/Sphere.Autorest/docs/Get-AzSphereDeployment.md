---
external help file:
Module Name: Az.Sphere
online version: https://learn.microsoft.com/powershell/module/az.sphere/get-azspheredeployment
schema: 2.0.0
---

# Get-AzSphereDeployment

## SYNOPSIS
Get a Deployment.
'.default' and '.unassigned' are system defined values and cannot be used for product or device group name.

## SYNTAX

### List (Default)
```
Get-AzSphereDeployment -CatalogName <String> -DeviceGroupName <String> -ProductName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Filter <String>] [-Maxpagesize <Int32>]
 [-Skip <Int32>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSphereDeployment -CatalogName <String> -DeviceGroupName <String> -Name <String> -ProductName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSphereDeployment -InputObject <ISphereIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityCatalog
```
Get-AzSphereDeployment -CatalogInputObject <ISphereIdentity> -DeviceGroupName <String> -Name <String>
 -ProductName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityDeviceGroup
```
Get-AzSphereDeployment -DeviceGroupInputObject <ISphereIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityProduct
```
Get-AzSphereDeployment -DeviceGroupName <String> -Name <String> -ProductInputObject <ISphereIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a Deployment.
'.default' and '.unassigned' are system defined values and cannot be used for product or device group name.

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
To construct, see NOTES section for DEVICEGROUPINPUTOBJECT properties and create a hash table.

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

### -DeviceGroupName
Name of device group.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCatalog, GetViaIdentityProduct, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Filter the result list using the given expression

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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

### -Maxpagesize
The maximum number of result items per page.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Deployment name.
Use .default for deployment creation and to get the current deployment for the associated device group.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCatalog, GetViaIdentityDeviceGroup, GetViaIdentityProduct
Aliases: DeploymentName

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

### -Skip
The number of result items to skip.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
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

### -Top
The number of result items to return.

```yaml
Type: System.Int32
Parameter Sets: List
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

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.IDeployment

## NOTES

## RELATED LINKS

