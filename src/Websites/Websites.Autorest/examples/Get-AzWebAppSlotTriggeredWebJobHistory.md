### Example 1: List triggered web job's history for a deployment slot
```powershell
PS C:\> Get-AzWebAppSlotTriggeredWebJobHistory -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03

Kind Name                                                            ResourceGroupName
---- ----                                                            -----------------
     appService-test01/slot01/slottriggeredjob-03/202201040202032401 webjob-rg-test
```

This command list triggered web job's history for a deployment slot.

### Example 2: Get triggered web job's history for a deployment slot
```powershell
PS C:\> Get-AzWebAppSlotTriggeredWebJobHistory -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03 -Id 202201040202032401

Kind Name                                                            ResourceGroupName
---- ----                                                            -----------------
     appService-test01/slot01/slottriggeredjob-03/202201040202032401 webjob-rg-test
```

This command get triggered web job's history for a deployment slot.

### Example 3: Get triggered web job's history for a deployment slot by pipeline
```powershell
PS C:\> $jobs = Get-AzWebAppSlotTriggeredWebJobHistory -ResourceGroupName webjob-rg-test -AppName appService-test01 -SlotName slot01 -Name slottriggeredjob-03
PS C:\> $jobs[0].Id | Get-AzWebAppSlotTriggeredWebJobHistory 

Kind Name                                                            ResourceGroupName
---- ----                                                            -----------------
     appService-test01/slot01/slottriggeredjob-03/202201040202032401 webjob-rg-test
```

This command get triggered web job's history for a deployment slot by pipeline.