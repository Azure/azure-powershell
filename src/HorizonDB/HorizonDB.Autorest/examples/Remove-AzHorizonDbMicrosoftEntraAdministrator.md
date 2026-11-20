### Example 1: Delete a Microsoft Entra administrator
```powershell
Remove-AzHorizonDbMicrosoftEntraAdministrator -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -ObjectId '11111111-1111-1111-1111-111111111111' -Confirm
```

Deletes the administrator identified by its Microsoft Entra object ID after confirmation.

The HTTP 202 response has no body. This command produces no output unless PassThru is specified.
