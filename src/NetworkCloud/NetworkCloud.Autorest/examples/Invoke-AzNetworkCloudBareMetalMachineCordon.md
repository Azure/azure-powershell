### Example 1: Cordon bare metal machine
```powershell
Invoke-AzNetworkCloudBareMetalMachineCordon -BareMetalMachineName bmmName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId -Evacuate "False"
```

This command cordons a bare metal machine.
