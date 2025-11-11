### Example 1: Extract data from bare metal machine
```powershell
$command = @{
    command = "command"
    arguments = "commandArguments"
}

Invoke-AzNetworkCloudBareMetalMachineDataExtract -BareMetalMachineName bmmName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId -Command $command -LimitTimeSecond limitTimeInSeconds -Debug
```

This command runs a provided data extraction command on a bare metal machine. Including the -Debug flag ensures successful output of the storage account URL containing the command's results. This is necessary to retrieve the results of the command on the bare metal machine.
