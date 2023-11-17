### Example 1: Start a continuous web job for a deployment slot
```powershell
Start-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slotcontinuousjob-01

```

This command starts a continuous web job for an app.

### Example 2: Start a continuous web job for a deployment slot by pipeline
```powershell
Get-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slotcontinuousjob-01 | Start-AzWebAppSlotContinuousWebJob

```

This command starts a continuous web job for a deployment slot by pipeline.