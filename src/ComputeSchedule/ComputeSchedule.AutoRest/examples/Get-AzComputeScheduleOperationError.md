### Example 1: Gets the details on the retriable errors that may have occured during the lifetime of an operation requested on a virtual machine
```powershell
Get-AzComputeScheduleOperationError 
-Location "eastus2euap
-OperationId "48d6d537-ecb0-40d5-b54e-fb92eb3eeee5","bf56f36d-edde-43ce-95aa-03f22c3bc286"
-SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4"
```

```output
{
  Results: [
    {
      OperationId: "48d6d537-ecb0-40d5-b54e-fb92eb3eeee5",
      CreationTime: "2024-12-17T23:53:16.1332548+00:00",
      ActivationTime: "2024-12-17T23:53:16.1272618+00:00",
      CompletedAt: "2024-12-17T23:55:10.6632969+00:00",
      OperationErrors: [],
      RequestErrorCode: null,
      RequestErrorDetails: null
    },
    {
      OperationId: "bf56f36d-edde-43ce-95aa-03f22c3bc286",
      CreationTime: "2024-12-17T23:53:16.1332548+00:00",
      ActivationTime: "2024-12-17T23:53:16.1272618+00:00",
      CompletedAt: "2024-12-17T23:55:10.6632969+00:00",
      OperationErrors: [],
      RequestErrorCode: null,
      RequestErrorDetails: null
    },
  ]
}
```

The above command gets the details on the retriable errors that may have occured during the lifetime of an operation requested on a virtual machine

