### Example 1: Remove a run-command for a machine
```powershell
Remove-AzConnectedMachineRunCommand -ResourceGroupName "az-sdk-test" -RunCommandName "myRunCommand" -MachineName "testmachine"
```

```output
Location    Name          SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt Syst
                                                                                                                   emDa
                                                                                                                   taLa
                                                                                                                   stMo
                                                                                                                   difi
                                                                                                                   edBy
--------    ----          ------------------- ------------------- ----------------------- ------------------------ ----
eastus2euap myRunCommand2
```

Remove a run-command for a machine