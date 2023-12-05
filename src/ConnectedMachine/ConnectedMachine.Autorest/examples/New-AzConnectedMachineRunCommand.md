### Example 1: Create a run-command for a machine
```powershell
New-AzConnectedMachineRunCommand -ResourceGroupName "az-sdk-test" -Location "eastus2euap" -SourceScript "Write-Host Hello World!" -RunCommandName "myRunCommand3" -MachineName "testmachine" -SubscriptionId "e6fe6705-4c9c-4b54-81d2-e455780e20b8"
```

```output
Location    Name          SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt Syst
                                                                                                                   emDa
                                                                                                                   taLa
                                                                                                                   stMo
                                                                                                                   difi
                                                                                                                   edBy
--------    ----          ------------------- ------------------- ----------------------- ------------------------ ----
eastus2euap myRunCommand3
```

Create a run-command for a machine