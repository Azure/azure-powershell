### Example 1: Poll the status of operations performed on a batch of virtual machines using the operation id from a previous Start/Deallocate/Hibernate operation
```powershell
Get-AzComputeScheduleOperationStatus
-Location "eastus2euap"
-Correlationid [guid]::NewGuid().ToString() 
-OperationId "d099fda7-4fdb-4db0-98e5-53fab1821267","333f8f97-32d0-4a88-9bf0-75e65da2052c"
-SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4"
```

```output
{
    Results: [
    {
      ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/testResourceGroup/providers/Microsoft.Compute/virtualMachines/testVirtualMachine",
      ErrorCode: null,
      ErrorDetails: null,
      Operation: {
        OperationId: "d099fda7-4fdb-4db0-98e5-53fab1821267",
        ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/testResourceGroup/providers/Microsoft.Compute/virtualMachines/testVirtualMachine",
        OpType: "Start",
        SubscriptionId: "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
        Deadline: "2024-12-17T22:25:02.0426307+00:00",
        DeadlineType: "InitiateAt",
        State: "Succeeded",
        TimeZone: "",
        ResourceOperationError: null,
        CompletedAt: null,
        RetryWindowInMinutes: null,
        RetryPolicy: {
          RetryCount: 7,
          RetryWindowInMinutes: 45
        }
      }
    },
    {
      ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/testResourceGroup/providers/Microsoft.Compute/virtualMachines/testVirtualMachine-1",
      ErrorCode: null,
      ErrorDetails: null,
      Operation: {
        OperationId: "333f8f97-32d0-4a88-9bf0-75e65da2052c",
        ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/testResourceGroup/providers/Microsoft.Compute/virtualMachines/testVirtualMachine-1",
        OpType: "Start",
        SubscriptionId: "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
        Deadline: "2024-12-17T22:25:02.0426307+00:00",
        DeadlineType: "InitiateAt",
        State: "Succeeded",
        TimeZone: "",
        ResourceOperationError: null,
        CompletedAt: null,
        RetryWindowInMinutes: null,
        RetryPolicy: {
          RetryCount: 7,
          RetryWindowInMinutes: 45
        }
      }
    },
  ]}
```

The above command cancels scheduled operations (Start/Deallocate/Hibernate) on virtual machines using the operationids gotten from previous Execute/Submit type API calls

