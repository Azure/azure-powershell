### Example 1: List triggered webs for a deployment slot
```powershell
Get-AzWebAppSlotTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01
```
```output
Name                                         Kind WebJobType ResourceGroupName
----                                         ---- ---------- -----------------
appService-test01/slot01/slottriggeredjob-03                 webjob-rg-test
appService-test01/slot01/slottriggeredjob-04                 webjob-rg-test
```

This command lists triggered webs for a deployment slot.

### Example 2: Get triggered web for a deployment slot
```powershell
Get-AzWebAppSlotTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03
```
```output
Name                                         Kind WebJobType ResourceGroupName
----                                         ---- ---------- -----------------
appService-test01/slot01/slottriggeredjob-03                 webjob-rg-test
```

This command gets triggered web for a deployment slot.

### Example 3: Get triggered web for a deployment slot by pipeline
```powershell
$webjob = Get-AzWebAppSlotTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03
Start-AzWebAppSlotTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03
$webjob.Id | Get-AzWebAppSlotTriggeredWebJob
```
```output
Name                                         Kind WebJobType ResourceGroupName
----                                         ---- ---------- -----------------
appService-test01/slot01/slottriggeredjob-03                 webjob-rg-test
```

This command gets triggered web for a deployment slot by pipeline.