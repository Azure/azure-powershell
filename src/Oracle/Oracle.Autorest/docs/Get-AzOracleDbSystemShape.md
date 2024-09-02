---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/get-azoracledbsystemshape
schema: 2.0.0
---

# Get-AzOracleDbSystemShape

## SYNOPSIS
Get a DbSystemShape

## SYNTAX

### List (Default)
```
Get-AzOracleDbSystemShape -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzOracleDbSystemShape -Location <String> -Name <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleDbSystemShape -InputObject <IOracleIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzOracleDbSystemShape -LocationInputObject <IOracleIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a DbSystemShape

## EXAMPLES

### Example 1: Get a list of the Database System Shapes by location
```powershell
Get-AzOracleDbSystemShape -Location "eastus"
```

```output
AvailableCoreCount                : 0
AvailableCoreCountPerNode         : 126
AvailableDataStorageInTb          : 63
AvailableDataStoragePerServerInTb : 
AvailableDbNodePerNodeInGb        : 2243
AvailableDbNodeStorageInGb        : 
AvailableMemoryInGb               : 
AvailableMemoryPerNodeInGb        : 1390
CoreCountIncrement                : 
Id                                : /subscriptions/00000000-0000-0000-0000-000000000000/providers/Oracle.Database/locations/eastus/dbSystemShapes/Exadata.X9M
MaxStorageCount                   : 
MaximumNodeCount                  : 32
MinCoreCountPerNode               : 0
MinDataStorageInTb                : 2
MinDbNodeStoragePerNodeInGb       : 60
MinMemoryPerNodeInGb              : 30
MinStorageCount                   : 
MinimumCoreCount                  : 0
MinimumNodeCount                  : 2
Name                              : Exadata.X9M
ResourceGroupName                 : 
RuntimeMinimumCoreCount           : 
ShapeFamily                       : EXADATA
SystemDataCreatedAt               : 
SystemDataCreatedBy               : 
SystemDataCreatedByType           : 
SystemDataLastModifiedAt          : 
SystemDataLastModifiedBy          : 
SystemDataLastModifiedByType      : 
Type                              : Oracle.Database/Locations/dbSystemShapes
```

Get a list of the Database System Shapes by location.
For more information, execute `Get-Help Get-AzOracleDbSystemShape`.

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

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

### -LocationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: GetViaIdentityLocation
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
DbSystemShape name

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityLocation
Aliases: Dbsystemshapename

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDbSystemShape

## NOTES

## RELATED LINKS

