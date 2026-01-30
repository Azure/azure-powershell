---
external help file:
Module Name: Az.PostgreSqlFlexibleServer
online version: https://learn.microsoft.com/powershell/module/az.postgresqlflexibleserver/get-azpostgresqlflexibleservercapabilitiesbyserver
schema: 2.0.0
---

# Get-AzPostgreSqlFlexibleServerCapabilitiesByServer

## SYNOPSIS
Lists the capabilities available for a given server.

## SYNTAX

```
Get-AzPostgreSqlFlexibleServerCapabilitiesByServer -ResourceGroupName <String> -ServerName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Lists the capabilities available for a given server.

## EXAMPLES

### Example 1: Get capabilities for a specific PostgreSQL Flexible Server
```powershell
Get-AzPostgreSqlFlexibleServerCapabilitiesByServer -ResourceGroupName "myResourceGroup" -ServerName "myPostgreSqlServer"
```

```output
ServerName           : myPostgreSqlServer
CurrentVersion       : 13
UpgradeableVersions  : {14, 15}
CurrentSku           : Standard_B1ms
ScalableSkus         : {Standard_B2s, Standard_D2s_v3, Standard_D4s_v3}
CurrentStorageGb     : 32
MaxStorageGb         : 65536
StorageAutoGrow      : True
HASupported          : True
GeoBackupSupported   : True
```

Retrieves the current capabilities and upgrade options for the specified PostgreSQL Flexible Server.

### Example 2: Check capabilities for a production server
```powershell
Get-AzPostgreSqlFlexibleServerCapabilitiesByServer -ResourceGroupName "production-rg" -ServerName "prod-postgresql-01"
```

```output
ServerName           : prod-postgresql-01
CurrentVersion       : 14
UpgradeableVersions  : {15}
CurrentSku           : Standard_D4s_v3
ScalableSkus         : {Standard_D8s_v3, Standard_D16s_v3}
CurrentStorageGb     : 256
MaxStorageGb         : 65536
StorageAutoGrow      : True
HASupported          : True
GeoBackupSupported   : True
```

Retrieves capabilities for a production PostgreSQL Flexible Server showing available scaling options.

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

### -ServerName
The name of the server.

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
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PostgreSqlFlexibleServer.Models.ICapability

## NOTES

## RELATED LINKS

