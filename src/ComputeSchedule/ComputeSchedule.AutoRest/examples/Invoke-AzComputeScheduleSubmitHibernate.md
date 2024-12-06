### Example 1: Hibernate a batch of virtual machines at the given deadline
```powershell
Invoke-AzComputeScheduleSubmitHibernate 
-Location "eastus2euap" 
-CorrelationId [guid]::NewGuid().ToString() 
-DeadlineType "InitiateAt"
-ResourceId "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-4", "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-5"
-SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4"
-Deadline 2025-01-10T23:00:00
-RetryCount 4
-RetryWindowInMinutes 65
-Timezone "UTC"
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

The above command is scheduling a hibernate operation on a batch of virtual machines by the given deadline. The list below describes guidance on Deadline and Timezone:
- Computeschedule supports "UTC" timezone currently
- Deadline for a submit type operation can not be more than 5 minutes in the past or greater than 14 days in the future

