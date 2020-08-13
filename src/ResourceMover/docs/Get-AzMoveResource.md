---
external help file:
Module Name: Az.RegionMove
online version: https://docs.microsoft.com/en-us/powershell/module/az.regionmove/get-azmoveresource
schema: 2.0.0
---

# Get-AzMoveResource

## SYNOPSIS


## SYNTAX

### List (Default)
```
Get-AzMoveResource -MoveCollectionName <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMoveResource -MoveCollectionName <String> -Name <String> -ResourceGroupName <String>
 -SubscriptionId <String[]> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMoveResource -InputObject <IRegionMoveIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION


## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -Filter
| Field | Supported operators | Supported functions |
|------------------|------------------------|-----------------------------------|
| id | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |
| firstName | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |
| lastName | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |
| email | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |
| state | eq | N/A |
| registrationDate | ge, le, eq, ne, gt, lt | N/A |
| note | ge, le, eq, ne, gt, lt | substringof, contains, startswith, endswith |

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
Type: Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.IRegionMoveIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MoveCollectionName
.

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

### -Name
.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: MoveResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
.

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
The Subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.IRegionMoveIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.IMoveResource

### Microsoft.Azure.PowerShell.Cmdlets.RegionMove.Models.Api20191001Preview.IMoveResourceCollection

## NOTES

ALIASES

### Add-AzResourceToMoveContext

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IRegionMoveIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[MoveCollectionName <String>]`: 
  - `[MoveResourceName <String>]`: 
  - `[ResourceGroupName <String>]`: 
  - `[SubscriptionId <String>]`: The Subscription ID.

## RELATED LINKS

