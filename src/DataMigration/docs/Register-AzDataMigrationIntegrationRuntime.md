---
external help file:
Module Name: Az.DataMigration
online version: https://docs.microsoft.com/powershell/module/az.datamigration/register-azdatamigrationintegrationruntime
schema: 2.0.0
---

# Register-AzDataMigrationIntegrationRuntime

## SYNOPSIS
Registers Sql Migration Service on Integration Runtime

## SYNTAX

```
Register-AzDataMigrationIntegrationRuntime -AuthKey <String> [-IntegrationRuntimePath <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Registers Sql Migration Service on Integration Runtime

## EXAMPLES

### Example 1: Register Sql Migration Service on Self Hosted Integration Runtime
```powershell
PS C:\> $authKeys = Get-AzDataMigrationSqlMigrationServiceAuthKey -ResourceGroupName "MyRG" -SqlMigrationServiceName "MySqlMS"
PS C:\> Register-AzDataMigrationIntegrationRuntime -AuthKey $authKeys.AuthKey1

Start to register IR with key: IR@tyi97c5-gdby456-4673svs-yeh4@mysqlms@eastus@xp6/x892=
Integration Runtime registration is successful!
```

This command registers Sql Migration Service on Self Hosted Integration Runtime.

### Example 2: Install Integration Runtime and register a Sql Migration Service on it
```powershell
PS C:\> $authKeys = Get-AzDataMigrationSqlMigrationServiceAuthKey -ResourceGroupName "MyRG" -SqlMigrationServiceName "MySqlMS"
PS C:\> Register-AzDataMigrationIntegrationRuntime -AuthKey $authKeys.AuthKey1 -IntegrationRuntimePath "C:\Users\user\Downloads\IntegrationRuntime.msi"

Start Gateway installation
Succeed to install gateway
Start to register IR with key: IR@tyi97c5-gdby456-4673svs-yeh4@mysqlms@eastus@xp6/x892=
Integration Runtime registration is successful!
```

This command installs Integration Runtime and registers a Sql Migration Service on it.

## PARAMETERS

### -AuthKey
AuthKey of Sql Migration Service

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

### -IntegrationRuntimePath
Path of SHIR msi

```yaml
Type: System.String
Parameter Sets: (All)
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

## OUTPUTS

### System.Object

## NOTES

ALIASES

## RELATED LINKS

