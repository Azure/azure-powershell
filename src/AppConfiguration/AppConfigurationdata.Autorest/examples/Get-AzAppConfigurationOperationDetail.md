### Example 1: Get the status of a snapshot creation operation
```powershell
Get-AzAppConfigurationOperationDetail -Endpoint $endpoint -Snapshot "mySnapshot"
```

```output
Id     : xxxx
Status : Succeeded
```

Get the state of a long running operation for a snapshot creation.

