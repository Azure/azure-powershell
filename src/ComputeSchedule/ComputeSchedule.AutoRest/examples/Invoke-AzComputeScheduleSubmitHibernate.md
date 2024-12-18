### Example 1: Hibernate a batch of virtual machines at the given deadline
```powershell
Invoke-AzComputeScheduleSubmitHibernate 
-Location "eastus2euap" 
-CorrelationId [guid]::NewGuid().ToString() 
-DeadlineType "InitiateAt"
-ResourceId "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-7", "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-9"
-SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4"
-Deadline 2025-01-10T23:00:00
-RetryCount 4
-RetryWindowInMinutes 65
-Timezone "UTC"
```

```output
{
  Description: "Hibernate Resource request",
  Type: "VirtualMachines",
  Location: "eastus2euap",
  Results: [
    {
      ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-7",
      ErrorCode: null,
      ErrorDetails: null,
      Operation: {
        OperationId: "37346960-9d1d-4b61-87be-898054870a31",
        ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-7",
        OpType: "Hibernate",
        SubscriptionId: "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
        Deadline: "2025-01-10T23:00:00+00:00",
        DeadlineType: "InitiateAt",
        State": "Succeeded",
        TimeZone: "UTC",
        ResourceOperationError: null,
        CompletedAt": null,
        RetryWindowInMinutes: null,
        RetryPolicy: {
          RetryCount: 4,
          RetryWindowInMinutes: 65
        }
      }
    },
    {
      ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-9",
      ErrorCode: null,
      ErrorDetails: null,
      Operation: {
        OperationId: "45346960-9d1d-4b61-87be-898054870a31",
        ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-rg/providers/Microsoft.Compute/virtualMachines/test-vm-9",
        OpType: "Hibernate",
        SubscriptionId: "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
        Deadline: "2025-01-10T23:00:00+00:00",
        DeadlineType: "InitiateAt",
        State: "Succeeded",
        TimeZone: "UTC",
        ResourceOperationError: null,
        CompletedAt: null,
        RetryWindowInMinutes: null,
        RetryPolicy: {
          RetryCount: 4,
          RetryWindowInMinutes: 65
        }
      }
    }
  ]
}
```

The above command is scheduling a hibernate operation on a batch of virtual machines by the given deadline. The list below describes guidance on Deadline and Timezone:
- Computeschedule supports "UTC" timezone currently
- Deadline for a submit type operation can not be more than 5 minutes in the past or greater than 14 days in the future

