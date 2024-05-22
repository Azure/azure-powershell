---
external help file: Az.Chaos-help.xml
Module Name: Az.Chaos
online version: https://learn.microsoft.com/powershell/module/Az.Chaos/new-azchaosstepobject
schema: 2.0.0
---

# New-AzChaosStepObject

## SYNOPSIS
Create an in-memory object for Step.

## SYNTAX

```
New-AzChaosStepObject -Branch <IBranch[]> -Name <String>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Step.

## EXAMPLES

### Example 1: Create an in-memory object for Step.
```powershell
$actionObj = New-AzChaosActionObject -Name "urn:csci:microsoft:virtualMachine:shutdown/1.0" -Type "continuous"
$branchObj = New-AzChaosBranchObject -Action $actionObj -Name "branch1"
New-AzChaosStepObject -Branch $branchObj -Name "step1"
```

```output
Branch Name
------ ----
{{…    step1
```

Create an in-memory object for Step.

## PARAMETERS

### -Branch
List of branches.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.IBranch[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
String of the step name.

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

### Microsoft.Azure.PowerShell.Cmdlets.Chaos.Models.Step

## NOTES

## RELATED LINKS
