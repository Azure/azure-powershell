### Example 1: List all run-commands for a machine
```powershell
Get-AzConnectedMachineRunCommand -ResourceGroupName "az-sdk-test" -MachineName "testmachine"
```

```output
Location    Name          SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt Syst
                                                                                                                   emDa
                                                                                                                   taLa
                                                                                                                   stMo
                                                                                                                   difi
                                                                                                                   edBy
--------    ----          ------------------- ------------------- ----------------------- ------------------------ ----
eastus2euap myRunCommand
eastus2euap myRunCommand2
```

Lists all run-commands for a specific machine.

### Example 2: List a specific run-command for a machine
```powershell
Get-AzConnectedMachineRunCommand -ResourceGroupName "az-sdk-test" -RunCommandName "myRunCommand" -MachineName "testmachine"
```

```output
Location    Name         SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt Syste
                                                                                                                  mData
                                                                                                                  LastM
                                                                                                                  odifi
                                                                                                                  edBy
--------    ----         ------------------- ------------------- ----------------------- ------------------------ -----
eastus2euap myRunCommand
```

List a specific run-command for a machine