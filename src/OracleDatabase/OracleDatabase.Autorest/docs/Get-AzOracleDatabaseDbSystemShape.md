---
external help file:
Module Name: Az.OracleDatabase
online version: https://learn.microsoft.com/powershell/module/az.oracledatabase/get-azoracledatabasedbsystemshape
schema: 2.0.0
---

# Get-AzOracleDatabaseDbSystemShape

## SYNOPSIS
Get a DbSystemShape

## SYNTAX

### List (Default)
```
Get-AzOracleDatabaseDbSystemShape -Location <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzOracleDatabaseDbSystemShape -Location <String> -Name <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzOracleDatabaseDbSystemShape -InputObject <IOracleDatabaseIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityLocation
```
Get-AzOracleDatabaseDbSystemShape -LocationInputObject <IOracleDatabaseIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a DbSystemShape

## EXAMPLES

### Example 1: Gets a list of the Database System Shapes by location
```powershell
Get-AzOracleDatabaseDbSystemShape -Location "eastus"
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
Id                                : /subscriptions/dcb0912a-9b6f-46e3-a11b-5296913d89b5/providers/Oracle.Database/locations/eastus/dbSystemShapes/Exadata.X9M
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

Gets a list of the Database System Shapes by location.
For more information, execute `Get-Help Get-AzOracleDatabaseDbSystemShape`

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
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
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

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IDbSystemShape

## NOTES

## RELATED LINKS

