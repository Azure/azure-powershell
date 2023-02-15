### Example 1: Run a triggered web job for a deployment slot
```powershell
PS C:\> Start-AzWebAppSlotTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03

```

This command runs a triggered web job for a deployment slot.

### Example 2: Run a triggered web job for a deployment slot by pipeline
```powershell
PS C:\> Get-AzWebAppSlotTriggeredWebJob -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03 | Start-AzWebAppSlotTriggeredWebJob

```

This command runs a triggered web job for a deployment slot by pipeline.