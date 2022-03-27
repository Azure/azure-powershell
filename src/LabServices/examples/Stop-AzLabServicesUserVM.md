### Example 1: Stop user assigned VM in the lab.
```powershell
Stop-AzLabServicesUserVM -ResourceGroupName "Group Name" -LabName "Lab Name" -Email "user@contoso.com"
```

This stops the VM assigned to the user with the specific email. If there isn't a VM assigned to the user a null is returned.
