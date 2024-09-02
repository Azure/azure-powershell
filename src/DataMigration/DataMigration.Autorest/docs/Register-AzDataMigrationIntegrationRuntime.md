---
external help file:
Module Name: Az.DataMigration
online version: https://learn.microsoft.com/powershell/module/az.datamigration/register-azdatamigrationintegrationruntime
schema: 2.0.0
---

# Register-AzDataMigrationIntegrationRuntime

## SYNOPSIS
Registers Sql Migration Service on Integration Runtime

## SYNTAX

```
Register-AzDataMigrationIntegrationRuntime -AuthKey <String> [-IntegrationRuntimePath <String>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Registers Sql Migration Service on Integration Runtime

## EXAMPLES

### Example 1: Register Sql Migration Service on Self Hosted Integration Runtime
```powershell
$authKeys = Get-AzDataMigrationSqlServiceAuthKey -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService"
Register-AzDataMigrationIntegrationRuntime -AuthKey $authKeys.AuthKey1
```

```output
Start to register IR with key: IR*********************yz6=
Integration Runtime registration is successful!
```

This command registers Sql Migration Service on Self Hosted Integration Runtime.

### Example 2: Install Integration Runtime and register a Sql Migration Service on it
```powershell
$authKeys = Get-AzDataMigrationSqlServiceAuthKey -ResourceGroupName "MyResourceGroup" -SqlMigrationServiceName "MySqlMigrationService"
Register-AzDataMigrationIntegrationRuntime -AuthKey $authKeys.AuthKey1 -IntegrationRuntimePath "C:\Users\user\Downloads\IntegrationRuntime.msi"
```

```output
Start Gateway installation
Succeed to install gateway
Start to register IR with key: IR*********************yz6=
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

### -PassThru


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

### System.Boolean

## NOTES

## RELATED LINKS

