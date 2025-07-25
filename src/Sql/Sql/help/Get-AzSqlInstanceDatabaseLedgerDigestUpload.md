---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/get-azsqlinstancedatabaseledgerdigestupload
schema: 2.0.0
---

# Get-AzSqlInstanceDatabaseLedgerDigestUpload

## SYNOPSIS
Gets the ledger digest upload settings of a database in Azure SQL Managed Instance.

## SYNTAX

### DatabaseParameterSet (Default)
```
Get-AzSqlInstanceDatabaseLedgerDigestUpload [-ResourceGroupName] <String> [-InstanceName] <String>
 [-DatabaseName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### InputObjectParameterSet
```
Get-AzSqlInstanceDatabaseLedgerDigestUpload -InputObject <AzureSqlManagedDatabaseModel>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzSqlInstanceDatabaseLedgerDigestUpload [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzSqlInstanceDatabaseLedgerDigestUpload cmdlet gets the ledger digest upload settings of the specified database in an Azure SQL Managed Instance

## EXAMPLES

### Example 1
```powershell
Get-AzSqlInstanceDatabaseLedgerDigestUpload -ResourceGroupName "ResourceGroup01" -InstanceName "Server01" -DatabaseName "Database01"
```

```output
ResourceGroupName InstanceName DatabaseName State   Endpoint
----------------- ------------ ------------ -----   --------
ResourceGroup01   Server01     Database01   Enabled https://mystorage.blob.core.windows.net
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
The database object to retrieve digest uploads for.

```yaml
Type: Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlManagedDatabaseModel
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
The resource id of the database to retrieve digest uploads for.

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

### -InstanceName
Azure SQL Managed Instance name.

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

### Microsoft.Azure.Commands.Sql.Database.Model.AzureSqlManagedDatabaseModel

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstanceLedgerDigestUploads.Model.AzureSqlInstanceDatabaseLedgerDigestUploadModel

## NOTES

## RELATED LINKS
