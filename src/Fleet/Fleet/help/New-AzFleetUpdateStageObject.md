---
external help file: Az.Fleet-help.xml
Module Name: Az.Fleet
online version: https://learn.microsoft.com/powershell/module/Az.Fleet/new-azfleetupdatestageobject
schema: 2.0.0
---

# New-AzFleetUpdateStageObject

## SYNOPSIS
Create an in-memory object for UpdateStage.

## SYNTAX

```
New-AzFleetUpdateStageObject -Name <String> [-AfterGate <IGateConfiguration[]>]
 [-AfterStageWaitInSecond <Int32>] [-BeforeGate <IGateConfiguration[]>] [-Group <IUpdateGroup[]>]
 [-MaxConcurrency <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for UpdateStage.

## EXAMPLES

### Example 1: create fleet update stage object with group string array
```powershell
New-AzFleetUpdateStageObject -Name stag1 -Group @{name='group-a'} -AfterStageWaitInSecond 3600 | Format-List
```

```output
AfterStageWaitInSecond : 3600
Group                  : {{
                           "name": "group-a"
                         }}
Name                   : stag1
```

This command create a fleet update stage object and shows as list.

### Example 2: create fleet update stage object with update group object
```powershell
$a = New-AzFleetUpdateGroupObject -Name 'Group-a'
$b = New-AzFleetUpdateGroupObject -Name 'Group-b'                                                                           
$c = New-AzFleetUpdateGroupObject -Name 'Group-c'                                                                           
New-AzFleetUpdateStageObject -Name stag1 -Group $a,$b,$c -AfterStageWaitInSecond 3600 | Format-List
```

```output
AfterStageWaitInSecond : 3600
Group                  : {{
                           "name": "Group-a"
                         }, {
                           "name": "Group-b"
                         }, {
                           "name": "Group-c"
                         }}
Name                   : stag1
```

This command create a fleet update stage object and shows as list.

## PARAMETERS

### -AfterGate
A list of Gates that will be created after this Stage is executed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IGateConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AfterStageWaitInSecond
The time in seconds to wait at the end of this stage before starting the next one.
Defaults to 0 seconds if unspecified.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BeforeGate
A list of Gates that will be created before this Stage is executed.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IGateConfiguration[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Group
Defines the groups to be executed in parallel in this stage.
Duplicate groups are not allowed.
Min size: 1.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.IUpdateGroup[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxConcurrency
The max number of upgrades that can run concurrently across all groups in this stage.
        Acts as a ceiling (and not a quota) for the number of concurrent upgrades within the stage you want to tolerate at a time.
        Actual concurrency may be lower depending on group-level concurrency limits or individual member conditions.
        Stage maxConcurrency has a min value of "1".
        Accepts either:
            • A fixed count, e.g., "3"
            • A percentage, e.g., "25%" (range 1-100).
Percentage is of the total number of clusters across all groups in the stage.
              Fractional results are rounded down.
A minimum of 1 upgrade is enforced.
        Examples:
            • "3"     --\> up to 3 clusters from this stage upgrade at once (across all groups).
            • "100%"  --\> "all at once"; up to all clusters in this stage upgrade at the same time.
            • "25%"   --\> up to 25% of the stage's total clusters upgrade at the same time.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the stage.
Must be unique within the UpdateRun.

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

### Microsoft.Azure.PowerShell.Cmdlets.Fleet.Models.UpdateStage

## NOTES

## RELATED LINKS
