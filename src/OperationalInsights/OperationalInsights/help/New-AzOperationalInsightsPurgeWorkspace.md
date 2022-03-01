---
external help file: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.dll-Help.xml
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/New-AzOperationalInsightsPurgeWorkspace
schema: 2.0.0
---

# New-AzOperationalInsightsPurgeWorkspace

## SYNOPSIS
Purges data in an Log Analytics workspace by a set of user-defined filters

## SYNTAX

### CreateByNameParameterSet (Default)
```
New-AzOperationalInsightsPurgeWorkspace [-ResourceGroupName] <String> [-WorkspaceName] <String>
 -Column <String> -OperatorProperty <String> [-Value <Object>] [-Key <String>] -Table <String> [-Force]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateByObjectParameterSet
```
New-AzOperationalInsightsPurgeWorkspace [-ResourceGroupName] <String> [-WorkspaceName] <String>
 -PurgeBody <PSWorkspacePurgeBody> [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Purges data in an Log Analytics workspace by a set of user-defined filters

## EXAMPLES

### Example 1
```powershell
New-AzOperationalInsightsPurgeWorkspace -ResourceGroupName dabenham-dev -WorkspaceName dabenham-troubleShootingE2E -Column "Column_Name" -OperatorProperty "Operator" -Value "Value" -key "Key" -Table "Table_Name"
```

Purges data in an Log Analytics workspace's table

## PARAMETERS

### -Column
The column of the table over which the given query should run

```yaml
Type: System.String
Parameter Sets: CreateByNameParameterSet
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
Don't ask for confirmation.

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

### -Key
When filtering over custom dimensions, this key will be used as the name of the custom dimension.

```yaml
Type: System.String
Parameter Sets: CreateByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OperatorProperty
A query operator to evaluate over the provided column and value(s).
Supported operators are ==, =~, in, in~, \>, \>=, \<, \<=, between, and have the same behavior as they would in a KQL query.

```yaml
Type: System.String
Parameter Sets: CreateByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PurgeBody
Specifies the table and filters to be purged.

```yaml
Type: Microsoft.Azure.Commands.OperationalInsights.Models.PSWorkspacePurgeBody
Parameter Sets: CreateByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: CreateByNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: CreateByObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Table
Table name from which to purge data.

```yaml
Type: System.String
Parameter Sets: CreateByNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Value
the value for the operator to function over.
This can be a number (e.g., \> 100), a string (timestamp \>= '2017-09-01') or array of values.

```yaml
Type: System.Object
Parameter Sets: CreateByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace to purge.

```yaml
Type: System.String
Parameter Sets: CreateByNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: CreateByObjectParameterSet
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

### System.String

### System.Object

### Microsoft.Azure.Commands.OperationalInsights.Models.PSWorkspacePurgeBody

## OUTPUTS

### Microsoft.Azure.Commands.OperationalInsights.Models.PSWorkspacePurgeResponse

## NOTES

## RELATED LINKS
