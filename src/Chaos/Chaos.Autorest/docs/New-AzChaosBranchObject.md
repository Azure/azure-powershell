---
external help file:
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/Az.Chaos/new-azchaosbranchobject
schema: 2.0.0
---

# New-AzChaosBranchObject

## SYNOPSIS
Create an in-memory object for Branch.

## SYNTAX

```
New-AzChaosBranchObject -Action <IAction[]> -Name <String> [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Branch.

## EXAMPLES

### Example 1: Create an in-memory object for Branch.
```powershell
$actionObj = New-AzChaosActionObject -Name "urn:csci:microsoft:virtualMachine:shutdown/1.0" -Type "continuous"
New-AzChaosBranchObject -Action $actionObj -Name "branch1"
```

```output
Action Name
------ ----
{{…    branch1
```

Create an in-memory object for Branch.

## PARAMETERS

### -Action
List of actions.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IAction[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
String of the branch name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.Branch

## NOTES

## RELATED LINKS

