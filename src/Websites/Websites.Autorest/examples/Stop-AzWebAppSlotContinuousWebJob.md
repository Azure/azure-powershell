### Example 1: Stop a continuous web job for a deployment slot
```powershell
PS C:\> Stop-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slotcontinuousjob-01

```

This command stops a continuous web job for an app.

### Example 2: Stop a continuous web job for a deployment slot by pipeline
```powershell
PS C:\> Get-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slotcontinuousjob-01 | Stop-AzWebAppSlotContinuousWebJob

```

This command stops a continuous web job for a deployment slot by pipeline.