### Example 1: Start user assigned VM in the lab.
```powershell
Start-AzLabServicesUserVM -ResourceGroupName "Group Name" -LabName "Lab Name" -Email "user@contoso.com"
```

This starts the VM assigned to the user with the specific email. If there isn't a VM assigned to the user a null is returned.
