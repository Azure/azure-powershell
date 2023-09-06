---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Sql.dll-Help.xml
Module Name: Az.Sql
online version: https://learn.microsoft.com/powershell/module/az.sql/start-azsqlinstance
schema: 2.0.0
---

# Start-AzSqlInstance

## SYNOPSIS
Starts Azure SQL Managed Instance

## SYNTAX

### StartInstanceFromInputParameters (Default)
```
Start-AzSqlInstance [-Name] <String> [-Force] [-AsJob] [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StartInstanceFromAzureSqlManagedInstanceModelInstanceDefinition
```
Start-AzSqlInstance [-InputObject] <AzureSqlManagedInstanceModel> [-Force] [-AsJob]
 [-ResourceGroupName] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### StartInstanceFromAzureResourceId
```
Start-AzSqlInstance [-ResourceId] <String> [-Force] [-AsJob] [-ResourceGroupName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Starts Azure SQL Managed Instance

## EXAMPLES

### Example 1
```powershell
Start-AzSqlInstance -Name instance-name -ResourceGroupName rg-name
```

Starts Azure SQL Managed Instance

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
The instance object to Start

```yaml
Type: AzureSqlManagedInstanceModel
Parameter Sets: StartInstanceFromAzureSqlManagedInstanceModelInstanceDefinition
Aliases: SqlInstance

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the instance.

```yaml
Type: String
Parameter Sets: StartInstanceFromInputParameters
Aliases: InstanceName

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
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource id of instance object to Start

```yaml
Type: String
Parameter Sets: StartInstanceFromAzureResourceId
Aliases:

Required: True
Position: 0
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Sql.ManagedInstance.Model.AzureSqlManagedInstanceModel

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
[Get-AzSqlInstanceStartStopSchedule](./Get-AzSqlInstanceStartStopSchedule.md)

[New-AzSqlInstanceStartStopSchedule](./New-AzSqlInstanceStartStopSchedule.md)

[Remove-AzSqlInstanceStartStopSchedule](./Remove-AzSqlInstanceStartStopSchedule.md)

[Stop-AzSqlInstance](./Stop-AzSqlInstance.md)
