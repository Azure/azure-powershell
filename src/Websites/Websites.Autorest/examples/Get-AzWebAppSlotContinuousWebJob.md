### Example 1: List continuous webs for a deployment slot
```powershell
PS C:\> Get-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01

Name                                          Kind WebJobType ResourceGroupName
----                                          ---- ---------- -----------------
appService-test01/slot01/slotcontinuousjob-03                 webjob-rg-test
appService-test01/slot01/slotcontinuousjob-04                 webjob-rg-test
```

This command lists continuous webs for a deployment slot.

### Example 2: Get continuous web for a deployment slot
```powershell
PS C:\> Get-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slotcontinuousjob-03

Name                                          Kind WebJobType ResourceGroupName
----                                          ---- ---------- -----------------
appService-test01/slot01/slotcontinuousjob-03                 webjob-rg-test
```

This command gets continuous web for a deployment slot.

### Example 3: Get continuous web for a deployment slot by pipeline
```powershell
PS C:\> $webjob = Get-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slotcontinuousjob-03
PS C:\> Start-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slotcontinuousjob-03
PS C:\> $webjob.Id | Get-AzWebAppSlotContinuousWebJob

Name                                          Kind WebJobType ResourceGroupName
----                                          ---- ---------- -----------------
appService-test01/slot01/slotcontinuousjob-03                 webjob-rg-test
```

This command gets continuous web for a deployment slot by pipeline.