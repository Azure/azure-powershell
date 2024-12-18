### Example 1: Cancel a batch of operations scheduled on virtual machines using the operation id from a previous Start/Deallocate/Hibernate operation
```powershell
Stop-AzComputeScheduleScheduledAction 
-Location "eastus2euap"
-Correlationid [guid]::NewGuid().ToString() 
-OperationId "d099fda7-4fdb-4db0-98e5-53fab1821267","333f8f97-32d0-4a88-9bf0-75e65da2052c"
-SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4"
```

```output
{
  Results: [
    {
      ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/virtualMachineOne",
      ErrorCode: null,
      ErrorDetails: null,
      Operation: {
        OperationId: "d099fda7-4fdb-4db0-98e5-53fab1821267",
        ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/virtualMachineOne",
        OpType: "Start",
        SubscriptionId: "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
        Deadline: "2024-12-18T07:45:50+00:00",
        DeadlineType: "InitiateAt",
        State: "Cancelled",
        TimeZone: "",
        ResourceOperationError: {
          ErrorCode: "OperationCancelledByUser",
          ErrorDetails: "Operation: d099fda7-4fdb-4db0-98e5-53fab1821267 was cancelled by the user."
        },
        CompletedAt: "2024-12-17T23:45:50.5374717+00:00",
        RetryWindowInMinutes: null,
        RetryPolicy: {
          RetryCount: 2,
          RetryWindowInMinutes: 60
        }
      }
    },
    {
      ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/virtualMachineTwo",
      ErrorCode: null,
      ErrorDetails: null,
      Operation: {
        OperationId: "333f8f97-32d0-4a88-9bf0-75e65da2052c",
        ResourceId: "/subscriptions/ed5d2ee7-ede1-44bd-97a2-369489bbefe4/resourceGroups/test-resource-group/providers/Microsoft.Compute/virtualMachines/virtualMachineTwo",
        OpType: "Start",
        SubscriptionId: "ed5d2ee7-ede1-44bd-97a2-369489bbefe4",
        Deadline: "2024-12-18T07:45:50+00:00",
        DeadlineType: "InitiateAt",
        State: "Cancelled",
        TimeZone: "",
        ResourceOperationError: {
          ErrorCode: "OperationCancelledByUser",
          ErrorDetails: "Operation: 333f8f97-32d0-4a88-9bf0-75e65da2052c was cancelled by the user."
        },
        CompletedAt: "2024-12-17T23:45:50.5374717+00:00",
        RetryWindowInMinutes: null,
        RetryPolicy: {
          RetryCount: 2,
          RetryWindowInMinutes: 60
        }
      }
    }
    ]}
```

The above command cancels scheduled operations (Start/Deallocate/Hibernate) on virtual machines using the operationids gotten from previous Execute/Submit type API calls

