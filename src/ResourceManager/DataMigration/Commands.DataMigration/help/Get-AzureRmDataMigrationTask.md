---
external help file: Commands.DataMigration.dll-Help.xml
Module Name: AzureRM.DataMigration
online version: 
schema: 2.0.0
---

# Get-AzureRmDataMigrationTask

## SYNOPSIS
Retrieves the PSProjectTask object associated with an Azure Database Migration Service migration task.

## SYNTAX
### ComponentNameParameterSet (Default)
```
Get-AzureRmDataMigrationTask -ResourceGroupName <String> -ServiceName <String> -ProjectName <String>
 [-DefaultProfile <IAzureContextContainer>]
```

### ComponentObjectParameterSet
```
Get-AzureRmDataMigrationTask [-InputObject] <PSProject> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>]
```

### ResourceIdParameterSet
```
Get-AzureRmDataMigrationTask [-ResourceId] <String> [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
```

### TaskSet
```
Get-AzureRmDataMigrationTask -ResourceGroupName <String> -ServiceName <String> -ProjectName <String>
 [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
```

### ExpandTaskSet
```
Get-AzureRmDataMigrationTask -ResourceGroupName <String> -ServiceName <String> -ProjectName <String>
 -Name <String> [-Expand] [-DefaultProfile <IAzureContextContainer>]
```

### ExpandTaskResultTypeSet
```
Get-AzureRmDataMigrationTask -ResourceGroupName <String> -ServiceName <String> -ProjectName <String>
 -Name <String> [-Expand] -ResultType <ResultTypeEnum> [-DefaultProfile <IAzureContextContainer>]
```

### TaskTypeSet
```
Get-AzureRmDataMigrationTask -ResourceGroupName <String> -ServiceName <String> -ProjectName <String>
 [-TaskType <TaskTypeEnum>] [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The Get-AzureRmDataMigrationTask cmdlet retrieves the properties associated with an Azure Database Migration Service migration task.

## EXAMPLES

### Example 1
```
PS C:\> Get -AzureRmDataMigrationTask –TaskName myTestTask -ServiceName myTestService -ProjectName MyTestProject -ResourceGroupName MyResourceGroup -Expand


```

The above example illustrates the use of Get-AzureRmDataMigrationTask cmdlet to retrieve the properties associated with an Azure Database Migration Service migration task based on task name passed in as input parameter

## Example 2
```
PS C:\> Get -AzureRmDataMigrationTask –Project $myProject


```

The above example illustrates the use of Get-AzureRmDataMigrationTask cmdlet to retrieve all of the migration tasks associated with PSProject object passed in as input parameter

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -Expand
Expand output

```yaml
Type: SwitchParameter
Parameter Sets: ExpandTaskSet, ExpandTaskResultTypeSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
PSProject Object.

```yaml
Type: PSProject
Parameter Sets: ComponentObjectParameterSet
Aliases: Project

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the task.

```yaml
Type: String
Parameter Sets: ComponentObjectParameterSet, ResourceIdParameterSet, TaskSet
Aliases: TaskName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: ExpandTaskSet, ExpandTaskResultTypeSet
Aliases: TaskName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
The name of the project.

```yaml
Type: String
Parameter Sets: ComponentNameParameterSet, TaskSet, ExpandTaskSet, ExpandTaskResultTypeSet, TaskTypeSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: ComponentNameParameterSet, TaskSet, ExpandTaskSet, ExpandTaskResultTypeSet, TaskTypeSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Project Resource Id.

```yaml
Type: String
Parameter Sets: ResourceIdParameterSet
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResultType
Expand output of given result type.

```yaml
Type: ResultTypeEnum
Parameter Sets: ExpandTaskResultTypeSet
Aliases: 
Accepted values: MigrationLevelOutput, DatabaseLevelOutput, TableLevelOutput, MigrationValidationOutput, MigrationValidationDatabaseLevelOutput

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
Data Migration Service Name.

```yaml
Type: String
Parameter Sets: ComponentNameParameterSet, TaskSet, ExpandTaskSet, ExpandTaskResultTypeSet, TaskTypeSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TaskType
Filter by TaskType.

```yaml
Type: TaskTypeEnum
Parameter Sets: TaskTypeSet
Aliases: 
Accepted values: MigrateSqlServerSqlDb, ConnectToSourceSqlServer, ConnectToTargetSqlDb, GetUserTablesSql

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

## INPUTS

### Microsoft.Azure.Commands.DataMigration.Models.PSProject
System.String


## OUTPUTS

### System.Collections.Generic.IList`1[[Microsoft.Azure.Commands.DataMigration.Models.PSProjectTask, Microsoft.Azure.Commands.DataMigration, Version=0.1.0.0, Culture=neutral, PublicKeyToken=null]]


## NOTES

## RELATED LINKS

