---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/complete-azsqlinstancedatabasecopy
schema: 2.0.0
---

# Complete-AzSqlInstanceDatabaseCopy

## SYNOPSIS
Complete online copy operation of a managed database.

## SYNTAX

### MoveCopyManagedDatabaseByNameParameterSet (Default)
```
Complete-AzSqlInstanceDatabaseCopy -DatabaseName <String> [-TargetResourceGroupName <String>]
 -TargetInstanceName <String> [-AsJob] [-PassThru] [-InstanceName] <String> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CompleteManagedDatabaseCopyByCopyModelObject
```
Complete-AzSqlInstanceDatabaseCopy -CopyModelObject <MoveCopyManagedDatabaseModel> [-AsJob] [-PassThru]
 [-InstanceName] <String> [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### MoveCopyManagedDatabaseByInstanceObjectParameterSet
```
Complete-AzSqlInstanceDatabaseCopy -DatabaseName <String> -InstanceObject <AzureSqlManagedInstanceModel>
 [-AsJob] [-PassThru] [-InstanceName] <String> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### MoveCopyManagedDatabaseByInputObjectParameterSet
```
Complete-AzSqlInstanceDatabaseCopy [-TargetResourceGroupName <String>] -TargetInstanceName <String>
 -DatabaseObject <AzureSqlManagedDatabaseModel> [-AsJob] [-PassThru] [-InstanceName] <String>
 [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### MoveCopyManagedDatabaseByResourceIdParameterSet
```
Complete-AzSqlInstanceDatabaseCopy [-TargetResourceGroupName <String>] -TargetInstanceName <String>
 -ResourceId <String> [-AsJob] [-PassThru] [-InstanceName] <String> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Complete-AzSqlInstanceDatabaseCopy** cmdlet complete copy operation of a database between two Azure SQL Managed Instances. Destination database will become online and ready for read/write workloads.

## EXAMPLES

### Example 1: Complete copy database to another Managed Instance in the same resource group
```powershell
PS C:\> Complete-AzSqlInstanceDatabaseCopy -ResourceGroupName RG1 -InstanceName MI1 -Name database1 -TargetInstanceName MI2
```

This command complete copy opeartion of database1 on instance MI1 to instance MI2

### Example 2: Complete copy database to another Managed Instance in the different resource group
```powershell
PS C:\> Complete-AzSqlInstanceDatabaseCopy -ResourceGroupName RG1 -InstanceName MI1 -Name database1 -TargetResourceGroupName RG2 -TargetInstanceName MI2
```

This command complete copy opeartion of database1 on instance MI1 in resource group RG1 to instance MI2 in resource group RG2


## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -CopyModelObject
Object that is returned from start copy operation.

```yaml
Type: MoveCopyManagedDatabaseModel
Parameter Sets: CompleteManagedDatabaseCopyByCopyModelObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseName
The name of the instance database.

```yaml
Type: String
Parameter Sets: MoveCopyManagedDatabaseByNameParameterSet
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: MoveCopyManagedDatabaseByInstanceObjectParameterSet
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DatabaseObject
Managed database object, for example output of **Get-AzSqlInstanceDatabase** cmdlet

```yaml
Type: AzureSqlManagedDatabaseModel
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceName
The name of the instance.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InstanceObject
The managed instance object

```yaml
Type: AzureSqlManagedInstanceModel
Parameter Sets: MoveCopyManagedDatabaseByInstanceObjectParameterSet
Aliases: ParentObject

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Signal to receive output from a cmdlet which does not return anything

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

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource id of managed database resource.

```yaml
Type: String
Parameter Sets: MoveCopyManagedDatabaseByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetInstanceName
The name of the target managed instance.

```yaml
Type: String
Parameter Sets: MoveCopyManagedDatabaseByNameParameterSet, MoveCopyManagedDatabaseByInputObjectParameterSet, MoveCopyManagedDatabaseByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceGroupName
The name of the target resource group.

```yaml
Type: String
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlManagedDatabaseModel

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Stop-AzSqlInstanceDatabaseCopy](./Stop-AzSqlInstanceDatabaseCopy.md)

[Get-AzSqlInstanceDatabaseCopyOperation](./Get-AzSqlInstanceDatabaseCopyOperation.md)

[Copy-AzSqlInstanceDatabase](./Copy-AzSqlInstanceDatabase.md)
