### Example 1: Attach to the output of a specific container instance
```powershell
$response = Add-AzContainerInstanceOutput -GroupName test-cg -Name test-container -ResourceGroupName test-rg
$response
```

```output
Password                         WebSocketUri
--------                         ------------
****************** wss://********.eastus.atlas.cloudapp.azure.com:19390/logstream/sessionId/00000000-0000-0000-0000-000000000000?api-version=1.0
```

This command attaches to the output stream of a specific container instance in a specified resource group and container group. Please send `Password` as an Authorization header value when connecting to the `WebSocketUri`.
