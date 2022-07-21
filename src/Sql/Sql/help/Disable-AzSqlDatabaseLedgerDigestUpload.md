---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://docs.microsoft.com/powershell/module/az.sql/disable-azsqldatabaseledgerdigestupload
schema: 2.0.0
---

# Disable-AzSqlDatabaseLedgerDigestUpload

## SYNOPSIS
Disables uploading ledger digests to Azure Blob storage or to Azure Confidential Ledger.

## SYNTAX

### DatabaseParameterSet (Default)
```
Disable-AzSqlDatabaseLedgerDigestUpload [-ResourceGroupName] <String> [-ServerName] <String>
 [-DatabaseName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectParameterSet
```
Disable-AzSqlDatabaseLedgerDigestUpload -InputObject <AzureSqlDatabaseModel>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Disable-AzSqlDatabaseLedgerDigestUpload [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Disable-AzSqlDatabaseLedgerDigestUpload cmdlet disables uploading ledger digests to Azure Blob storage or Azure Confidental Ledger. To use the cmdlet, identify the database.

## EXAMPLES

### Example 1
```powershell
Disable-AzSqlDatabaseLedgerDigestUpload -ResourceGroupName "ResourceGroup01" -ServerName "Server01" -DatabaseName "Database01"
```

```output
ResourceGroupName ServerName DatabaseName State    Endpoint
----------------- ---------- ------------ -----    --------
ResourceGroup01   Server01   Database01   Disabled
```

## PARAMETERS

### -DatabaseName
SQL Database name.

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The database object to disable digest uploads for.

```yaml
Type: Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel
Parameter Sets: InputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of the database to disable digest uploads for.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ServerName
SQL server name.

```yaml
Type: System.String
Parameter Sets: DatabaseParameterSet
Aliases:

Required: True
Position: 1
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

### Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlDatabaseModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.LedgerDigestUploads.Model.AzureSqlDatabaseLedgerDigestLocationModel

## NOTES

## RELATED LINKS
