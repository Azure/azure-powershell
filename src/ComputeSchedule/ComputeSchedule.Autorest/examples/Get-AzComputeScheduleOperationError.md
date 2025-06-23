### Example 1: Gets the details on the retriable errors that may have occured during the lifetime of an operation requested on a virtual machine
```powershell
Get-AzComputeScheduleOperationError -Location "eastus2euap" -OperationId "1fd870d3-d2b7-44c8-8ccb-bec05bbbf36f","5018cb59-bc54-42c3-a6c0-a9a4b0cf3f1b" -SubscriptionId "ed5d2ee7-ede1-44bd-97a2-369489bbefe4" | Format-List
```

```output
ActivationTime     : 12/18/2024 5:08:36 AM
CompletedAt        : 12/18/2024 5:09:20 AM
CreationTime       : 12/18/2024 5:08:36 AM
OperationError     : {}
OperationId        : 1fd870d3-d2b7-44c8-8ccb-bec05bbbf36f
RequestErrorCode   :
RequestErrorDetail :

ActivationTime     : 12/18/2024 5:03:15 AM
CompletedAt        : 12/18/2024 5:04:18 AM
CreationTime       : 12/18/2024 5:03:15 AM
OperationError     : {}
OperationId        : 75018cb59-bc54-42c3-a6c0-a9a4b0cf3f1b
RequestErrorCode   :
RequestErrorDetail :
```

The above command gets the details on the retriable errors that may have occured during the lifetime of an operation requested on a virtual machine

