### Example 1: Hibernate a batch of virtual machines at the given deadline
```powershell
Invoke-AzComputeScheduleSubmitHibernate -Location "eastus2euap" -CorrelationId "baa8dd07-e59e-4f97-be6a-76ad8d4584ae" -DeadlineType "InitiateAt" -ResourceId "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85150", "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85151" -SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4" -Deadline 2025-01-10T23:00:00 -RetryCount 2 -RetryWindowInMinutes 30 -Timezone "UTC" | Format-List
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
                  "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/rg-nneka-computeschedule-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85150",
                  "opType": "Hibernate",
                  "subscriptionId": "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
                  "deadline": "2024-12-25T23:00:00.0000000Z",
                  "deadlineType": "InitiateAt",
                  "state": "Succeeded"
                },
                "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/rg-nneka-computeschedule-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85150"
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
                  "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/rg-nneka-computeschedule-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85151",
                  "opType": "Hibernate",
                  "subscriptionId": "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
                  "deadline": "2024-12-25T23:00:00.0000000Z",
                  "deadlineType": "InitiateAt",
                  "state": "Succeeded"
                },
                "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/rg-nneka-computeschedule-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85151"
              }}
Type        : VirtualMachines
```

The above command is scheduling a hibernate operation on a batch of virtual machines by the given deadline. The list below describes guidance on Deadline and Timezone:
- Computeschedule supports "UTC" timezone currently
- Deadline for a submit type operation can not be more than 5 minutes in the past or greater than 14 days in the future

