---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version:
schema: 2.0.0
---

# Move-AzSqlInstanceDnsAlias

## SYNOPSIS
Modifies the managed instance to which Azure SQL Managed Instance DNS Alias is pointing.

## SYNTAX

### AcquireByNameAndSourceResourceIdParameterSet (Default)
```
Move-AzSqlInstanceDnsAlias [-ResourceGroupName] <String> [-InstanceName] <String> [-SourceResourceId] <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AcquireByNamesParameterSet
```
Move-AzSqlInstanceDnsAlias [-ResourceGroupName] <String> [-InstanceName] <String>
 [-SourceResourceGroupName] <String> [-SourceInstanceName] <String> [-SourceName] <String> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AcquireByNameAndSourceParentObjectParameterSet
```
Move-AzSqlInstanceDnsAlias [-ResourceGroupName] <String> [-InstanceName] <String> [-SourceName] <String>
 [-SourceInstanceObject] <AzureSqlManagedInstanceModel> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AcquireByNameAndSourceInputObjectParameterSet
```
Move-AzSqlInstanceDnsAlias [-ResourceGroupName] <String> [-InstanceName] <String>
 [-SourceInputObject] <AzureSqlManagedInstanceDnsAliasModel> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AcquireByParentObjectAndSourceNameParameterSet
```
Move-AzSqlInstanceDnsAlias [-InstanceObject] <AzureSqlManagedInstanceModel> [-SourceResourceGroupName] <String>
 [-SourceInstanceName] <String> [-SourceName] <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AcquireByParentObjectsParameterSet
```
Move-AzSqlInstanceDnsAlias [-InstanceObject] <AzureSqlManagedInstanceModel> [-SourceName] <String>
 [-SourceInstanceObject] <AzureSqlManagedInstanceModel> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AcquireByParentObjectAndSourceInputObjectParameterSet
```
Move-AzSqlInstanceDnsAlias [-InstanceObject] <AzureSqlManagedInstanceModel>
 [-SourceInputObject] <AzureSqlManagedInstanceDnsAliasModel> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### AcquireByParentObjectAndSourceResourceIdParameterSet
```
Move-AzSqlInstanceDnsAlias [-InstanceObject] <AzureSqlManagedInstanceModel> [-SourceResourceId] <String>
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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
Name of the target managed instance.

```yaml
Type: System.String
Parameter Sets: AcquireByNameAndSourceResourceIdParameterSet, AcquireByNamesParameterSet, AcquireByNameAndSourceParentObjectParameterSet, AcquireByNameAndSourceInputObjectParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InstanceObject
Input object of the target managed instance.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
Parameter Sets: AcquireByParentObjectAndSourceNameParameterSet, AcquireByParentObjectsParameterSet, AcquireByParentObjectAndSourceInputObjectParameterSet, AcquireByParentObjectAndSourceResourceIdParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the target resource group.

```yaml
Type: System.String
Parameter Sets: AcquireByNameAndSourceResourceIdParameterSet, AcquireByNamesParameterSet, AcquireByNameAndSourceParentObjectParameterSet, AcquireByNameAndSourceInputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceInputObject
Input object of the source managed instance DNS alias.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model.AzureSqlManagedInstanceDnsAliasModel
Parameter Sets: AcquireByNameAndSourceInputObjectParameterSet
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model.AzureSqlManagedInstanceDnsAliasModel
Parameter Sets: AcquireByParentObjectAndSourceInputObjectParameterSet
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SourceInstanceName
Name of the source managed instance.

```yaml
Type: System.String
Parameter Sets: AcquireByNamesParameterSet, AcquireByParentObjectAndSourceNameParameterSet
Aliases:

Required: True
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceInstanceObject
Input object of the source managed instance.

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
Parameter Sets: AcquireByNameAndSourceParentObjectParameterSet
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

```yaml
Type: Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel
Parameter Sets: AcquireByParentObjectsParameterSet
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SourceName
Name of the source DNS alias.

```yaml
Type: System.String
Parameter Sets: AcquireByNamesParameterSet, AcquireByNameAndSourceParentObjectParameterSet, AcquireByParentObjectAndSourceNameParameterSet, AcquireByParentObjectsParameterSet
Aliases: SourceDnsAliasName

Required: True
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -SourceResourceGroupName
Name of the source resource group.

```yaml
Type: System.String
Parameter Sets: AcquireByNamesParameterSet, AcquireByParentObjectAndSourceNameParameterSet
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceResourceId
Resource ID of the source managed instance DNS alias.

```yaml
Type: System.String
Parameter Sets: AcquireByNameAndSourceResourceIdParameterSet, AcquireByParentObjectAndSourceResourceIdParameterSet
Aliases: Id

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

### Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model.AzureSqlManagedInstanceDnsAliasModel

### System.String

## OUTPUTS

### System.Object
## NOTES

## RELATED LINKS
