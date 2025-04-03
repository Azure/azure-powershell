### Example 1: Deallocate a batch of virtual machines at the given deadline
```powershell
Invoke-AzComputeScheduleSubmitDeallocate -Location "eastus2euap" -CorrelationId "abb9b6a2-013a-4ad7-af2c-efd2449e6600" -DeadlineType "InitiateAt" -ResourceId "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85543", "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85762" -SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4" -Deadline 2025-01-10T23:00:00 -RetryCount 2 -RetryWindowInMinutes 30 -Timezone "UTC" | Format-List
```

```output
Description : Deallocate Resource request
Location    : eastus2euap
Result      : {{
                "operation": {
                  "retryPolicy": {
                    "retryCount": 2,
                    "retryWindowInMinutes": 30
                  },
                  "operationId": "7eebe846-f687-463d-aa68-3c7485ce28a3",
                  "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85762",
                  "opType": "Deallocate",
                  "subscriptionId": "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
                  "deadline": "2024-12-25T23:00:00.0000000Z",
                  "deadlineType": "InitiateAt",
                  "state": "Succeeded"
                },
                "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85762"
              }}
Type        : VirtualMachines

Description : Deallocate Resource request
Location    : eastus2euap
Result      : {{
                "operation": {
                  "retryPolicy": {
                    "retryCount": 2,
                    "retryWindowInMinutes": 30
                  },
                  "operationId": "7eebe846-f687-463d-aa68-3c7485ce28a3",
                  "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85543",
                  "opType": "Deallocate",
                  "subscriptionId": "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
                  "deadline": "2024-12-25T23:00:00.0000000Z",
                  "deadlineType": "InitiateAt",
                  "state": "Succeeded"
                },
                "resourceId": "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/pwshtest85543"
              }}
Type        : VirtualMachines
```

The above command is scheduling a deallocate operation on a batch of virtual machines by the given deadline. The list below describes guidance on Deadline and Timezone:
- Computeschedule supports "UTC" timezone currently
- Deadline for a submit type operation can not be more than 5 minutes in the past or greater than 14 days in the future

