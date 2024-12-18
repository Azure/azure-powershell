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
          RetryCount: 2,
          RetryWindowInMinutes: 60
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
          RetryCount: 2,
          RetryWindowInMinutes: 60
        }
      }
    }
  ]
}
```

Above command is hibernating a batch of virtual machines immediately

