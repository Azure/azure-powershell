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
New-AzFleetUpdateStageObject -Name <String> [-AfterStageWaitInSecond <Int32>] [-Group <IUpdateGroup[]>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
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
