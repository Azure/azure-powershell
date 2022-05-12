### Example 1: Delete a triggered web job for a deployment slot
```powershell
PS C:\> Remove-AzWebAppSlotTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03

```

This command deletes a triggered web job for a deployment slot.

### Example 2: Delete a triggered web job for a deployment slot by pipeline
```powershell
PS C:\> Get-AzWebAppSlotTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-04 | Remove-AzWebAppSlotTriggeredWebJob

```

This command deletes a triggered web job for a deployment slot by pipeline.