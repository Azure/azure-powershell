---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/move-azsqlinstancedatabase
schema: 2.0.0
---

# Move-AzSqlInstanceDatabase

## SYNOPSIS
Move managed database to another managed instance.

## SYNTAX

### MoveCopyManagedDatabaseByNameParameterSet (Default)
```
Move-AzSqlInstanceDatabase -DatabaseName <String> -InstanceName <String> -ResourceGroupName <String>
 [-TargetSubscriptionId <String>] [-TargetResourceGroupName <String>] -TargetInstanceName <String> [-AsJob]
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveCopyManagedDatabaseByOperationObjectParameterSet
```
Move-AzSqlInstanceDatabase [-DatabaseName <String>] [-InstanceName <String>] [-ResourceGroupName <String>]
 -MoveCopyOperationObject <ManagedDatabaseMoveCopyOperation> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveCopyManagedDatabaseByInputObjectParameterSet
```
Move-AzSqlInstanceDatabase -InstanceName <String> -ResourceGroupName <String> [-TargetSubscriptionId <String>]
 [-TargetResourceGroupName <String>] -TargetInstanceName <String>
 -DatabaseObject <AzureSqlManagedDatabaseModel> [-AsJob] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveCopyManagedDatabaseByResourceIdParameterSet
```
Move-AzSqlInstanceDatabase -InstanceName <String> -ResourceGroupName <String> [-TargetSubscriptionId <String>]
 [-TargetResourceGroupName <String>] -TargetInstanceName <String> -ResourceId <String> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Move-AzSqlInstanceDatabase** cmdlet start online move operation of a database across managed instances by using Always On availability group technology. [Learn more](https://learn.microsoft.com/en-us/azure/azure-sql/managed-instance/database-copy-move-how-to?view=azuresql)

## EXAMPLES

### Example 1: Move database to another Managed Instance in the same resource group
```powershell
Move-AzSqlInstanceDatabase -ResourceGroupName RG1 -InstanceName MI1 -Name database1 -TargetInstanceName MI2
```

This command moves database1 from instance MI1 to MI2

### Example 2: Move database to another Managed Instance in the different resource group
```powershell
Move-AzSqlInstanceDatabase -ResourceGroupName RG1 -InstanceName MI1 -Name database1 -TargetResourceGroupName RG2 -TargetInstanceName MI2
```

This command moves database1 from instance MI1 in resource group RG1 to MI2 in resource group RG2

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -DatabaseName
Name of the instance database.

```yaml
Type: System.String
Parameter Sets: MoveCopyManagedDatabaseByNameParameterSet
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: MoveCopyManagedDatabaseByOperationObjectParameterSet
Aliases: Name

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DatabaseObject
Managed database object.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlManagedDatabaseModel
Parameter Sets: MoveCopyManagedDatabaseByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -InstanceName
Name of the source instance.

```yaml
Type: System.String
Parameter Sets: MoveCopyManagedDatabaseByNameParameterSet, MoveCopyManagedDatabaseByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: MoveCopyManagedDatabaseByOperationObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: MoveCopyManagedDatabaseByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MoveCopyOperationObject
Managed database move or copy operation object.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.ManagedDatabaseMoveCopyOperation
Parameter Sets: MoveCopyManagedDatabaseByOperationObjectParameterSet
Aliases: Operation

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Signal to receive output from a cmdlet which does not return anything

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

### -ResourceGroupName
Name of the source resource group.

```yaml
Type: System.String
Parameter Sets: MoveCopyManagedDatabaseByNameParameterSet, MoveCopyManagedDatabaseByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: MoveCopyManagedDatabaseByOperationObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: MoveCopyManagedDatabaseByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource id of managed database.

```yaml
Type: System.String
Parameter Sets: MoveCopyManagedDatabaseByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetInstanceName
Name of the target Azure SQL Managed Instance.

```yaml
Type: System.String
Parameter Sets: MoveCopyManagedDatabaseByNameParameterSet, MoveCopyManagedDatabaseByInputObjectParameterSet, MoveCopyManagedDatabaseByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceGroupName
Name of the target resource group.

```yaml
Type: System.String
Parameter Sets: MoveCopyManagedDatabaseByNameParameterSet, MoveCopyManagedDatabaseByInputObjectParameterSet, MoveCopyManagedDatabaseByResourceIdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetSubscriptionId
Id of the target subscription.

```yaml
Type: System.String
Parameter Sets: MoveCopyManagedDatabaseByNameParameterSet, MoveCopyManagedDatabaseByInputObjectParameterSet, MoveCopyManagedDatabaseByResourceIdParameterSet
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.String

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlManagedDatabaseModel

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.ManagedDatabaseMoveCopyOperation

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.MoveCopyManagedDatabaseModel

## NOTES

## RELATED LINKS

[Complete-AzSqlInstanceDatabaseMove](./Complete-AzSqlInstanceDatabaseMove.md)

[Stop-AzSqlInstanceDatabaseMove](./Stop-AzSqlInstanceDatabaseMove.md)

[Get-AzSqlInstanceDatabaseMoveOperation](./Get-AzSqlInstanceDatabaseMoveOperation.md)

[Copy-AzSqlInstanceDatabase](./Copy-AzSqlInstanceDatabase.md)
