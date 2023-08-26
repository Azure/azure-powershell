---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/get-azsqlinstancedatabasecopyoperation
schema: 2.0.0
---

# Get-AzSqlInstanceDatabaseCopyOperation

## SYNOPSIS
Get managed database copy operation details

## SYNTAX

### GetMoveCopyManagedDatabaseOperationsByNameParameterSet (Default)
```
Get-AzSqlInstanceDatabaseCopyOperation [-DatabaseName <String>] [-TargetResourceGroupName <String>]
 [-TargetInstanceName <String>] [-OnlyLatestPerDatabase] [-InstanceName] <String> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### GetMoveCopyManagedDatabaseOperationsByInputObjectParameterSet
```
Get-AzSqlInstanceDatabaseCopyOperation [-DatabaseName <String>] [-TargetResourceGroupName <String>]
 [-TargetInstanceName <String>] -DatabaseObject <AzureSqlManagedDatabaseModel> [-OnlyLatestPerDatabase]
 [-InstanceName] <String> [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetMoveCopyManagedDatabaseOperationsByMoveCopyObjectParameterSet
```
Get-AzSqlInstanceDatabaseCopyOperation [-DatabaseName <String>] [-TargetResourceGroupName <String>]
 [-TargetInstanceName <String>] -ModelObject <MoveCopyManagedDatabaseModel> [-OnlyLatestPerDatabase]
 [-InstanceName] <String> [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### GetMoveCopyManagedDatabaseOperationsByResourceIdParameterSet
```
Get-AzSqlInstanceDatabaseCopyOperation [-TargetResourceGroupName <String>] [-TargetInstanceName <String>]
 -ResourceId <String> [-OnlyLatestPerDatabase] [-InstanceName] <String> [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzSqlInstanceDatabaseCopyOperation** cmdlet get copy managed database operation details.

## EXAMPLES

### Example 1: Get all copy operation on single Azure SQL Managed Instance
```powershell
Get-AzSqlInstanceDatabaseCopyOperation -ResourceGroupName RG1 -InstanceName instance1
```

```output
Name                      : 11111111-1111-1111-1111-111111111111
Id                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microso
                            ft.Sql/locations/westcentralus/managedDatabaseMoveOperationResults/11111111-1111-1111-1111-111111111111
Operation                 : StartCrossManagedInstanceDatabaseMovement
OperationFriendlyName     : Start Azure SQL Managed Instance database copy
StartTime                 : 5/30/2023 10:11:21 AM
State                     : Succeeded
OperationMode             : Copy
SourceManagedInstanceName : instance1
TargetManagedInstanceName : instance2
SourceManagedInstanceId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microso
                            ft.Sql/managedInstances/instance1
TargetManagedInstanceId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microsoft.Sql/managedInstances/instance2
SourceDatabaseName        : db1
TargetDatabaseName        : db1
IsCancellable             : True
ErrorCode                 :
ErrorDescription          :
ErrorSeverity             :
IsUserError               :

Name                      : 22222222-2222-2222-2222-222222222222
Id                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microso
                            ft.Sql/locations/westcentralus/managedDatabaseMoveOperationResults/22222222-2222-2222-2222-222222222222
Operation                 : StartCrossManagedInstanceDatabaseMovement
OperationFriendlyName     : Start Azure SQL Managed Instance database copy
StartTime                 : 5/30/2023 10:11:21 AM
State                     : Succeeded
OperationMode             : Copy
SourceManagedInstanceName : instance1
TargetManagedInstanceName : instance3
SourceManagedInstanceId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microso
                            ft.Sql/managedInstances/instance1
TargetManagedInstanceId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microsoft.Sql/managedInstances/instance3
SourceDatabaseName        : db2
TargetDatabaseName        : db2
IsCancellable             : True
ErrorCode                 :
ErrorDescription          :
ErrorSeverity             :
IsUserError               :

Name                      : 33333333-3333-3333-3333-333333333333
Id                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microso
                            ft.Sql/locations/westcentralus/managedDatabaseMoveOperationResults/33333333-3333-3333-3333-333333333333
Operation                 : CancelCrossManagedInstanceDatabaseMovement
OperationFriendlyName     : Cancel Azure SQL Managed Instance database copy
StartTime                 : 5/30/2023 11:11:21 AM
State                     : Succeeded
OperationMode             : Copy
SourceManagedInstanceName : instance1
TargetManagedInstanceName : instance3
SourceManagedInstanceId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microso
                            ft.Sql/managedInstances/instance1
TargetManagedInstanceId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microsoft.Sql/managedInstances/instance3
SourceDatabaseName        : db2
TargetDatabaseName        : db2
IsCancellable             : False
ErrorCode                 :
ErrorDescription          :
ErrorSeverity             :
IsUserError               :
```

This command will return all copy operations for instance instance1 in resource group RG1.

### Example 2: Get all copy operations on Azure SQL Managed Instance for one database

```powershell
Get-AzSqlInstanceDatabaseCopyOperation -ResourceGroupName RG1 -InstanceName instance1 -DatabaseName db2
```

```output
Name                      : 22222222-2222-2222-2222-222222222222
Id                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microso
                            ft.Sql/locations/westcentralus/managedDatabaseMoveOperationResults/22222222-2222-2222-2222-222222222222
Operation                 : StartCrossManagedInstanceDatabaseMovement
OperationFriendlyName     : Start Azure SQL Managed Instance database copy
StartTime                 : 5/30/2023 10:11:21 AM
State                     : Succeeded
OperationMode             : Copy
SourceManagedInstanceName : instance1
TargetManagedInstanceName : instance3
SourceManagedInstanceId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microso
                            ft.Sql/managedInstances/instance1
TargetManagedInstanceId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microsoft.Sql/managedInstances/instance3
SourceDatabaseName        : db2
TargetDatabaseName        : db2
IsCancellable             : True
ErrorCode                 :
ErrorDescription          :
ErrorSeverity             :
IsUserError               :


Name                      : 33333333-3333-3333-3333-333333333333
Id                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microso
                            ft.Sql/locations/westcentralus/managedDatabaseMoveOperationResults/33333333-3333-3333-3333-333333333333
Operation                 : CancelCrossManagedInstanceDatabaseMovement
OperationFriendlyName     : Cancel Azure SQL Managed Instance database copy
StartTime                 : 5/30/2023 11:11:21 AM
State                     : Succeeded
OperationMode             : Copy
SourceManagedInstanceName : instance1
TargetManagedInstanceName : instance3
SourceManagedInstanceId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microso
                            ft.Sql/managedInstances/instance1
TargetManagedInstanceId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microsoft.Sql/managedInstances/instance3
SourceDatabaseName        : db2
TargetDatabaseName        : db2
IsCancellable             : False
ErrorCode                 :
ErrorDescription          :
ErrorSeverity             :
IsUserError               :
```

This command will return all copy operations for database db2 on instance instance1 in resource group RG1.

### Example 3: Get only latest copy operation on Azure SQL Managed Instance for one database

```powershell
Get-AzSqlInstanceDatabaseCopyOperation -ResourceGroupName RG1 -InstanceName instance1 -DatabaseName db2 -OnlyLatestPerDatabase
```

```output
Name                      : 33333333-3333-3333-3333-333333333333
Id                        : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microso
                            ft.Sql/locations/westcentralus/managedDatabaseMoveOperationResults/33333333-3333-3333-3333-333333333333
Operation                 : CancelCrossManagedInstanceDatabaseMovement
OperationFriendlyName     : Cancel Azure SQL Managed Instance database copy
StartTime                 : 5/30/2023 11:11:21 AM
State                     : Succeeded
OperationMode             : Copy
SourceManagedInstanceName : instance1
TargetManagedInstanceName : instance3
SourceManagedInstanceId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microso
                            ft.Sql/managedInstances/instance1
TargetManagedInstanceId   : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/RG1/providers/Microsoft.Sql/managedInstances/instance3
SourceDatabaseName        : db2
TargetDatabaseName        : db2
IsCancellable             : False
ErrorCode                 :
ErrorDescription          :
ErrorSeverity             :
IsUserError               :
```

This command will return latest copy operation for database db2 on instance instance1 in resource group RG1.

## PARAMETERS

### -DatabaseName
Name of a database on Azure SQL Managed Instance.

```yaml
Type: System.String
Parameter Sets: GetMoveCopyManagedDatabaseOperationsByNameParameterSet
Aliases: Name

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: GetMoveCopyManagedDatabaseOperationsByInputObjectParameterSet, GetMoveCopyManagedDatabaseOperationsByMoveCopyObjectParameterSet
Aliases: Name

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DatabaseObject
Managed database object.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.AzureSqlManagedDatabaseModel
Parameter Sets: GetMoveCopyManagedDatabaseOperationsByInputObjectParameterSet
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
The name of the instance.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ModelObject
Object that is returned from start move or copy operation using -PassThru parameter.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.MoveCopyManagedDatabaseModel
Parameter Sets: GetMoveCopyManagedDatabaseOperationsByMoveCopyObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OnlyLatestPerDatabase
Return only latest opereation per managed database

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
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Resource id of managed database.

```yaml
Type: System.String
Parameter Sets: GetMoveCopyManagedDatabaseOperationsByResourceIdParameterSet
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
Parameter Sets: GetMoveCopyManagedDatabaseOperationsByNameParameterSet, GetMoveCopyManagedDatabaseOperationsByInputObjectParameterSet, GetMoveCopyManagedDatabaseOperationsByResourceIdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: GetMoveCopyManagedDatabaseOperationsByMoveCopyObjectParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetResourceGroupName
Name of the target resource group.

```yaml
Type: System.String
Parameter Sets: GetMoveCopyManagedDatabaseOperationsByNameParameterSet, GetMoveCopyManagedDatabaseOperationsByInputObjectParameterSet, GetMoveCopyManagedDatabaseOperationsByResourceIdParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: GetMoveCopyManagedDatabaseOperationsByMoveCopyObjectParameterSet
Aliases:

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

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.MoveCopyManagedDatabaseModel

## OUTPUTS

### Microsoft.Azure.Commands.Sql.ManagedDatabase.Model.ManagedDatabaseMoveCopyOperation

## NOTES

## RELATED LINKS

[Complete-AzSqlInstanceDatabaseCopy](./Complete-AzSqlInstanceDatabaseCopy.md)

[Stop-AzSqlInstanceDatabaseCopy](./Stop-AzSqlInstanceDatabaseCopy.md)

[Copy-AzSqlInstanceDatabase](./Copy-AzSqlInstanceDatabase.md)

[Get-AzSqlInstanceDatabaseMoveOperation](./Get-AzSqlInstanceDatabaseMoveOperation.md)
