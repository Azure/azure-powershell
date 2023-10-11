### Example 1: Run read command on bare metal machine
```powershell
$command = @{
    Command = "command"
    Argument = "commandArguments"
}

Invoke-AzNetworkCloudBareMetalMachineRunReadCommand -BareMetalMachineName bmmName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId -Command $command -LimitTimeSecond limitTimeInSeconds -Debug
```

This command runs a read-only command on a bare metal machine. Including the -Debug flag ensures successful output of the storage account URL containing the command's results. This is necessary to retrieve the results of the command on the bare metal machine.
