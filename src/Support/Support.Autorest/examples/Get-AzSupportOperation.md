### Example 1: List Azure Support operations
```powershell
Get-AzSupportOperation
```

```output
Name
----
Microsoft.Support/register/action
Microsoft.Support/lookUpResourceId/action
Microsoft.Support/checkNameAvailability/action
Microsoft.Support/services/read
Microsoft.Support/services/problemClassifications/read
Microsoft.Support/supportTickets/read
Microsoft.Support/supportTickets/write
Microsoft.Support/operationresults/read
Microsoft.Support/operationsstatus/read
Microsoft.Support/operations/read
```

Lists all the available Microsoft Support REST API operations.