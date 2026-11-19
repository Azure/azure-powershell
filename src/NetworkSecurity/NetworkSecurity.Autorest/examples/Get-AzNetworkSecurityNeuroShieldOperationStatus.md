### Example 1: Get asynchronous operation status
```powershell
Get-AzNetworkSecurityNeuroShieldOperationStatus -Location '<operation-region>' -OperationId '<operation-id>'
```

Gets status using the location and operation ID from an asynchronous operation's polling URL.
