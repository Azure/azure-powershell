### Example 1: Delete a DisconnectedOperation by name and resource group
```powershell
Remove-AzDisconnectedOperationsDisconnectedOperation -Name "Resource-1" -ResourceGroupName "ResourceGroup-1"
```

No output is expected for this command.

### Example 2: Delete a DisconnectedOperation by identity
```powershell
$disconnectedOperations = @{
  "Name" = "disconnected-operation-name";
  "ResourceGroupName" = "my-resource-group";
  "SubscriptionId" = "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxx";
}

Remove-AzDisconnectedOperationsDisconnectedOperation -InputObject $disconnectedOperations
```

No output is expected for this command.