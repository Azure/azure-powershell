### Example 1: Run restricted data extraction on a bare metal machine
```powershell
$command = @{
    command = "command"
    arguments = "commandArguments"
}
Invoke-AzNetworkCloudBareMetalMachineDataExtractRestricted -BareMetalMachineName bmmName -ResourceGroupName resourcceGroupName -SubscriptionId subscriptionId -Command $command -LimitTimeSecond 60
```

This example runs a restricted data extraction command on the specified bare metal machine with a 60-second timeout.

