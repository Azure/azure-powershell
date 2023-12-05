### Example 1: Update a run-command for a machine
```powershell
Update-AzConnectedMachineRunCommand -ResourceGroupName "az-sdk-test" -RunCommandName "myRunCommand2" -MachineName "testmachine" -SubscriptionId "e6fe6705-4c9c-4b54-81d2-e455780e20b8" -Tag @{Tag1="tag1"; Tag2="tag2"}

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

Update a run-command for a machine