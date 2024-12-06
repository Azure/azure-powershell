### Example 1: Start a batch of virtual machines immediately
```powershell
Invoke-AzComputeScheduleExecuteStart 
-Location "eastus2euap"
-CorrelationId "d8cae7b7-190f-4574-a793-7bffa7a1b4a8" 
-ResourceId "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-4", "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-5"
-SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4"
-RetryCount 4
-RetryWindowInMinutes 75
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

Above command is starting a batch of virtual machines immediately

