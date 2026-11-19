### Example 1: Delete a parameter group
```powershell
Remove-AzHorizonDbParameterGroup -ResourceGroupName 'example-resource-group' -Name 'production-parameters' -Confirm
```

Deletes the production-parameters parameter group after confirmation. Review its pool connections before deleting it.

The HTTP 202 response has no body. This command produces no output unless PassThru is specified.
