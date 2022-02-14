---
external help file:
Module Name: Az.OperationalInsights
online version: https://docs.microsoft.com/powershell/module/az.operationalinsights/remove-azoperationalinsightstable
schema: 2.0.0
---

# Remove-AzOperationalInsightsTable

## SYNOPSIS
Delete a Log Analytics workspace table.

## SYNTAX

### Delete (Default)
```powershell

```

Remove-AzOperationalInsightsTable -Name \<String\> -ResourceGroupName \<String\> -WorkspaceName \<String\>
 [-SubscriptionId \<String\>] [-DefaultProfile \<PSObject\>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [\<CommonParameters\>]
```

### DeleteViaIdentity
```powershell

```

Remove-AzOperationalInsightsTable -InputObject \<IOperationalInsightsIdentity\> [-DefaultProfile \<PSObject\>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [\<CommonParameters\>]
```

## DESCRIPTION
Delete a Log Analytics workspace table.

## EXAMPLES

### Example 1: Remove a table
```powershell
PS C:\> Remove-AzOperationalInsightsTable -ResourceGroupName {RG-name} -Name {Table-name} -WorkspaceName {WS-name}

--no output--
```



### Example 2: Remove a default 'Heartbeat' table - fail
```powershell
PS C:\> Remove-AzOperationalInsightsTable -ResourceGroupName dabenham-dev -Name Heartbeat -WorkspaceName dabenham-PSH2

Remove-AzOperationalInsightsTable_Delete: No actual change was detected, for table - Heartbeat, both schema and metadata information modifications seems to be missing.
```

Deletion of default tables is not possible
After performing an update to a default table using 'New-AzOperationalInsightsTable' or 'Update-AzOperationalInsightsTable' cmdlets, performing delete will revert the default table to it's original values'

PS C:\\> $tempTable = Update-AzOperationalInsightsTable -ResourceGroupName dabenham-dev -WorkspaceName dabenham-PSH2 -Name Heartbeat -RetentionInDay 55
PS C:\\> $tempTable.RetentionInDay
55

PS C:\\> Remove-AzOperationalInsightsTable -ResourceGroupName dabenham-dev -WorkspaceName dabenham-PSH2 -Name Heartbeat
PS C:\\> $tempTable = Get-AzOperationalInsightsTable -ResourceGroupName dabenham-dev -WorkspaceName dabenham-PSH2 -Name Heartbeat
PS C:\\> $tempTable.RetentionInDay
30
## PARAMETERS

### -AsJob
```powershell

```

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
```powershell

```

Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
```powershell

```

Type: Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.IOperationalInsightsIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
```powershell

```

Type: System.String
Parameter Sets: Delete
Aliases: TableName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
```powershell

```

Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
```powershell

```

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
```powershell

```

Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
```powershell

```

Type: System.String
Parameter Sets: Delete
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
```powershell

```

Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
```powershell

```

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
```powershell

```

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
```powershell

```

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OperationalInsights.Models.IOperationalInsightsIdentity
```powershell

```

## OUTPUTS

### System.Boolean
```powershell

```

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT \<IOperationalInsightsIdentity\>: Identity Parameter
  - `[Id \<String\>]`: Resource identity path
  - `[ResourceGroupName \<String\>]`: The name of the resource group.
The name is case insensitive.
  - `[SubscriptionId \<String\>]`: The ID of the target subscription.
  - `[TableName \<String\>]`: The name of the table.
  - `[WorkspaceName \<String\>]`: The name of the workspace.

## RELATED LINKS
