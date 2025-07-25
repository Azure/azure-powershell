### Example 1: Run script on bare metal machine
```powershell
Invoke-AzNetworkCloudBareMetalMachineRunCommand -BareMetalMachineName bmmName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId -LimitTimeSecond limitTimeInSeconds -Script "bHM=" -Argument "-l" -Debug
```

This command runs the provided script on a bare metal machine. Including the -Debug flag ensures successful output of the storage account URL containing the command's results. This is necessary to retrieve the results of the command on the bare metal machine.
