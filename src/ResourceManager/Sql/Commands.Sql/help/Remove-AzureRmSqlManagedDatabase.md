---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.sql/remove-azurermsqlmanageddatabase
schema: 2.0.0
---

# Remove-AzureRmSqlManagedDatabase

## SYNOPSIS
Removes an Azure SQL Managed database.

## SYNTAX

### RemoveManagedDatabaseFromInputParameters
```
Remove-AzureRmSqlManagedDatabase [-ManagedDatabaseName] <String> [-ManagedInstanceName] <String>
 [-ResourceGroupName] <String> [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RemoveManagedDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition
```
Remove-AzureRmSqlManagedDatabase -InputObject <AzureSqlManagedDatabaseModel> [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RemoveManagedDatabaseFromAzureResourceId
```
Remove-AzureRmSqlManagedDatabase -ResourceId <String> [-Force] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmSqlManagedDatabase** cmdlet removes an Azure SQL Managed database.

## EXAMPLES

### Example 1: Remove a database from an Azure SQL Managed instance
```
PS C:\>Remove-AzureRmSqlManagedDatabase -ResourceGroupName "ResourceGroup01" -ManagedInstanceName "managedInstance1" -ManagedDatabaseName "Database01"
```

This command removes the managed database named Database01 from managed instance managedInstance1.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Skip confirmation message for performing the action

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The Managed Database object to remove

```yaml
Type: AzureSqlManagedDatabaseModel
Parameter Sets: RemoveManagedDatabaseFromAzureSqlManagedDatabaseModelInstanceDefinition
Aliases: ManagedDatabase

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedDatabaseName
The name of the Azure SQL Managed Database to remove.

```yaml
Type: String
Parameter Sets: RemoveManagedDatabaseFromInputParameters
Aliases: Name

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedInstanceName
The Azure Sql Managed Instance name.

```yaml
Type: String
Parameter Sets: RemoveManagedDatabaseFromInputParameters
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: RemoveManagedDatabaseFromInputParameters
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of Managed Database object to remove

```yaml
Type: String
Parameter Sets: RemoveManagedDatabaseFromAzureResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlManagedDatabaseModel
System.String


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
