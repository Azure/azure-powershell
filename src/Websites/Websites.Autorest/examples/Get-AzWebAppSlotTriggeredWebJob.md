### Example 1: List triggered webs for a deployment slot
```powershell
PS C:\> Get-AzWebAppSlotTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01

Name                                         Kind WebJobType ResourceGroupName
----                                         ---- ---------- -----------------
appService-test01/slot01/slottriggeredjob-03                 webjob-rg-test
appService-test01/slot01/slottriggeredjob-04                 webjob-rg-test
```

This command lists triggered webs for a deployment slot.

### Example 2: Get triggered web for a deployment slot
```powershell
PS C:\> Get-AzWebAppSlotTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03

Name                                         Kind WebJobType ResourceGroupName
----                                         ---- ---------- -----------------
appService-test01/slot01/slottriggeredjob-03                 webjob-rg-test
```

This command gets triggered web for a deployment slot.

### Example 3: Get triggered web for a deployment slot by pipeline
```powershell
PS C:\> $webjob = Get-AzWebAppSlotTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03
PS C:\> Start-AzWebAppSlotTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03
PS C:\> $webjob.Id | Get-AzWebAppSlotTriggeredWebJob

Name                                         Kind WebJobType ResourceGroupName
----                                         ---- ---------- -----------------
appService-test01/slot01/slottriggeredjob-03                 webjob-rg-test
```

This command gets triggered web for a deployment slot by pipeline.