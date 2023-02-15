### Example 1: Delete a continuous web job for a deployment slot
```powershell
PS C:\> Remove-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slotcontinuousjob-03

```

This command deletes a continuous web job for a deployment slot.

### Example 2: Delete a continuous web job for a deployment slot by pipeline
```powershell
PS C:\> Get-AzWebAppSlotContinuousWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slotcontinuousjob-04 | Remove-AzWebAppSlotContinuousWebJob

```

This command deletes a continuous web job for a deployment slot by pipeline.