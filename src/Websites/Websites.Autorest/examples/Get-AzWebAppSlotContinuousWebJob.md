### Example 1: List continuous webs for a deployment slot
```powershell
Get-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01
```
```output
Name                                          Kind WebJobType ResourceGroupName
----                                          ---- ---------- -----------------
appService-test01/slot01/slotcontinuousjob-03                 webjob-rg-test
appService-test01/slot01/slotcontinuousjob-04                 webjob-rg-test
```

This command lists continuous webs for a deployment slot.

### Example 2: Get continuous web for a deployment slot
```powershell
Get-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slotcontinuousjob-03
```
```output
Name                                          Kind WebJobType ResourceGroupName
----                                          ---- ---------- -----------------
appService-test01/slot01/slotcontinuousjob-03                 webjob-rg-test
```

This command gets continuous web for a deployment slot.

### Example 3: Get continuous web for a deployment slot by pipeline
```powershell
$webjob = Get-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slotcontinuousjob-03
Start-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slotcontinuousjob-03
$webjob.Id | Get-AzWebAppSlotContinuousWebJob
```
```output
Name                                          Kind WebJobType ResourceGroupName
----                                          ---- ---------- -----------------
appService-test01/slot01/slotcontinuousjob-03                 webjob-rg-test
```

This command gets continuous web for a deployment slot by pipeline.