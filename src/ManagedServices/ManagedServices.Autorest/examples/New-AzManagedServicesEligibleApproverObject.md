### Example 1: Creates Azure Lighthouse eligible authorization approver object
```powershell
New-AzManagedServicesEligibleApproverObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Approvers group"
```

```output
PrincipalId                          PrincipalIdDisplayName
-----------                          ----------------------
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Approvers group
```

Creates Azure Lighthouse eligible authorization approver object.