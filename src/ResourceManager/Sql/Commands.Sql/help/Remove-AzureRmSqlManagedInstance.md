---
external help file: Microsoft.Azure.Commands.Sql.dll-Help.xml
Module Name: AzureRM.Sql
online version:
schema: 2.0.0
---

# Remove-AzureRmSqlManagedInstance

## SYNOPSIS
Removes an Azure SQL Database Managed instance.

## SYNTAX

### RemoveMManagedInstanceFromInputParameters
```
Remove-AzureRmSqlManagedInstance [-ManagedInstanceName] <String> [-ResourceGroupName] <String> [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RemoveMManagedInstanceFromAzureSqlManagedInstanceModelInstanceDefinition
```
Remove-AzureRmSqlManagedInstance -InputObject <AzureSqlManagedInstanceModel> [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### RemoveMManagedInstanceFromAzureResourceId
```
Remove-AzureRmSqlManagedInstance -ResourceId <String> [-Force] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmSqlManagedInstance** cmdlet removes an Azure SQL Database Managed Instance.

## EXAMPLES

### Example 1: Remove a Managed instance
```
PS C:\>Remove-AzureRmSqlManagedInstance -ResourceGroupName "ResourceGroup01" -ManagedInstanceName "managedInstance1"
```

This command removes the Azure SQL Database Managed instance named managedInstance1.

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
The AzureSqlManagedInstanceModel object to remove

```yaml
Type: AzureSqlManagedInstanceModel
Parameter Sets: RemoveMManagedInstanceFromAzureSqlManagedInstanceModelInstanceDefinition
Aliases: ManagedInstance

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedInstanceName
SQL Managed instance name.

```yaml
Type: String
Parameter Sets: RemoveMManagedInstanceFromInputParameters
Aliases: Name

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: RemoveMManagedInstanceFromInputParameters
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id of Managed instance object to remove

```yaml
Type: String
Parameter Sets: RemoveMManagedInstanceFromAzureResourceId
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

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
System.String


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS
