---
external help file:
Module Name: Az.DataMigration
online version: https://learn.microsoft.com/powershell/module/az.datamigration/new-azdatamigrationtdecertificatemigration
schema: 2.0.0
---

# New-AzDataMigrationTdeCertificateMigration

## SYNOPSIS
Migrate TDE certificate(s) from source SQL Server to the target Azure SQL Server.

## SYNTAX

```
New-AzDataMigrationTdeCertificateMigration -DatabaseName <String[]> -NetworkShareDomain <String>
 -NetworkSharePath <String> -SourceSqlConnectionString <SecureString> -TargetManagedInstanceName <String>
 -TargetResourceGroupName <String> -TargetSubscriptionId <String> [-NetworkSharePassword <SecureString>]
 [-NetworkShareUserName <String>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Migrate TDE certificate(s) from source SQL Server to the target Azure SQL Server.

## EXAMPLES

### Example 1: Run TDE certificate migration from a source SQL Server to a target Azure SQL Server.
```powershell
New-AzDataMigrationTdeCertificateMigration -SourceSqlConnectionString "data source=servername;user id=userid;password=;initial catalog=master;TrustServerCertificate=True" -TargetSubscriptionId "00000000-0000-0000-0000-000000000000" -TargetResourceGroupName "ResourceGroupName" -TargetManagedInstanceName "TargetManagedInstanceName" -NetworkSharePath "\\NetworkShare\Folder" -NetworkShareDomain "NetworkShare" -NetworkShareUserName "NetworkShareUserName" -NetworkSharePassword "NetworkSharePassword" -DatabaseName "TdeDb_0", "TdeDb_1", "TdeDb_2"
```

```output
Beginning TDE certificate migration
TdeDb_0: TDE certificate migrated successfully.
TdeDb_1: TDE certificate migrated successfully.
TdeDb_2: TDE certificate migrated successfully.
Certificate migration completed
```

This command runs TDE certificate migration from a source SQL Server to a target Azure SQL Server.

## PARAMETERS

### -DatabaseName
Source database name.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkShareDomain
Network share domain.

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

### -NetworkSharePassword
Network share password.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSharePath
Network share path.

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

### -NetworkShareUserName
Network share user name.

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

### -SourceSqlConnectionString
Required.
Connection string for the source SQL instance, using the formal connection string format.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetManagedInstanceName
Name of the Azure SQL Server.

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

### -TargetResourceGroupName
Resource group name of the target Azure SQL server.

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

### -TargetSubscriptionId
Subscription Id of the target Azure SQL server.

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

ALIASES

## RELATED LINKS

