### Example 1: Hibernate a batch of virtual machines immediately
```powershell
Invoke-AzComputeScheduleExecuteHibernate -Location "eastus2euap" -CorrelationId "d8cae7b7-190f-4574-a793-7bffa7a1b4a8" -ResourceId "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-2", "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-3" -SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4" -RetryCount 2 -RetryWindowInMinutes 30 | Format-List
```

```output
Description : Hibernate Resource request
Location    : eastus2euap
Result      : {{
                "operation": {
                  "retryPolicy": {
                    "retryCount": 2,
                    "retryWindowInMinutes": 30
                  },
                  "operationId": "7eebe846-f687-463d-aa68-3c7485ce28a3",
                  "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85158",
                  "opType": "Hibernate",
                  "subscriptionId": "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
                  "deadline": "2024-12-25T23:00:00.0000000Z",
                  "deadlineType": "InitiateAt",
                  "state": "Succeeded"
                },
                "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85158"
              }}
Type        : VirtualMachines

Description : Hibernate Resource request
Location    : eastus2euap
Result      : {{
                "operation": {
                  "retryPolicy": {
                    "retryCount": 2,
                    "retryWindowInMinutes": 30
                  },
                  "operationId": "7eebe846-f687-463d-aa68-3c7485ce28a3",
                  "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85123",
                  "opType": "Hibernate",
                  "subscriptionId": "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
                  "deadline": "2024-12-25T23:00:00.0000000Z",
                  "deadlineType": "InitiateAt",
                  "state": "Succeeded"
                },
                "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85123"
              }}
Type        : VirtualMachines
```

Above command is hibernating a batch of virtual machines immediately

