---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/complete-azsqlinstancedatabasemove
schema: 2.0.0
---

# Complete-AzSqlInstanceDatabaseMove

## SYNOPSIS
Complete online move operation of a managed database.

## SYNTAX

### MoveCopyManagedDatabaseByNameParameterSet (Default)
```
Complete-AzSqlInstanceDatabaseMove [-Force] -DatabaseName <String> -InstanceName <String>
 -ResourceGroupName <String> [-TargetSubscriptionId <String>] [-TargetResourceGroupName <String>]
 -TargetInstanceName <String> [-AsJob] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CompleteManagedDatabaseMoveByMoveModelObject
```
Complete-AzSqlInstanceDatabaseMove [-Force] -MoveModelObject <MoveCopyManagedDatabaseModel> [-AsJob]
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveCopyManagedDatabaseByOperationObjectParameterSet
```
Complete-AzSqlInstanceDatabaseMove [-Force] [-DatabaseName <String>] [-InstanceName <String>]
 [-ResourceGroupName <String>] -MoveCopyOperationObject <ManagedDatabaseMoveCopyOperation> [-AsJob] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveCopyManagedDatabaseByInputObjectParameterSet
```
Complete-AzSqlInstanceDatabaseMove [-Force] -InstanceName <String> -ResourceGroupName <String>
 [-TargetSubscriptionId <String>] [-TargetResourceGroupName <String>] -TargetInstanceName <String>
 -DatabaseObject <AzureSqlManagedDatabaseModel> [-AsJob] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveCopyManagedDatabaseByResourceIdParameterSet
```
Complete-AzSqlInstanceDatabaseMove [-Force] -InstanceName <String> -ResourceGroupName <String>
 [-TargetSubscriptionId <String>] [-TargetResourceGroupName <String>] -TargetInstanceName <String>
 -ResourceId <String> [-AsJob] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Complete-AzSqlInstanceDatabaseMove** cmdlet complete move operation of a database between two Azure SQL Managed Instances. Destination database will become online and ready for read/write workloads and source database will be dropped.

## EXAMPLES

### Example 1: Complete move database to another Managed Instance in the same resource group
```powershell
Complete-AzSqlInstanceDatabaseMove -ResourceGroupName RG1 -InstanceName MI1 -Name database1 -TargetInstanceName MI2
```

This command completes move operation of database1 on instance MI1 to instance MI2

### Example 2: Complete move database to another Managed Instance in the different resource group
```powershell
Complete-AzSqlInstanceDatabaseMove -ResourceGroupName RG1 -InstanceName MI1 -Name database1 -TargetResourceGroupName RG2 -TargetInstanceName MI2
```

This command completes move operation of database1 on instance MI1 in resource group RG1 to instance MI2 in resource group RG2

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

### -Force
Do not ask for confirmation

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

### -MoveModelObject
Object that is returned from start move operation.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.MoveCopyManagedDatabaseModel
Parameter Sets: CompleteManagedDatabaseMoveByMoveModelObject
Aliases:

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

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.MoveCopyManagedDatabaseModel

### System.String

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlManagedDatabaseModel

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.ManagedDatabaseMoveCopyOperation

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Stop-AzSqlInstanceDatabaseMove](./Stop-AzSqlInstanceDatabaseMove.md)

[Get-AzSqlInstanceDatabaseMoveOperation](./Get-AzSqlInstanceDatabaseMoveOperation.md)

[Move-AzSqlInstanceDatabase](./Move-AzSqlInstanceDatabase.md)
