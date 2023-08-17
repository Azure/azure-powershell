### Example 1: List webjobs for a deployment slot
```powershell
Get-AzWebAppSlotWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01
```
```output
Name                                          Kind WebJobType ResourceGroupName
----                                          ---- ---------- -----------------
appService-test01/slot01/slottriggeredjob-03                  webjob-rg-test
appService-test01/slot01/slottriggeredjob-04                  webjob-rg-test
appService-test01/slot01/slotcontinuousjob-03                 webjob-rg-test
appService-test01/slot01/slotcontinuousjob-04                 webjob-rg-test
```

This command lists webjobs for a deployment slot.