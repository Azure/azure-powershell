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