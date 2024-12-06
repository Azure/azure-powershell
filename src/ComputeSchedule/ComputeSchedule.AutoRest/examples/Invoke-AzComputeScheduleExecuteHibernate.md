### Example 1: Hibernate a batch of virtual machines immediately
```powershell
Invoke-AzComputeScheduleExecuteHibernate 
-Location "eastus2euap"
-CorrelationId "d8cae7b7-190f-4574-a793-7bffa7a1b4a8" 
-ResourceId "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-2", "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-3"
-SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4"
-RetryCount 2
-RetryWindowInMinutes 60
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

Above command is hibernating a batch of virtual machines immediately

