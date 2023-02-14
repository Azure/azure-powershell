### Example 1: Stop user assigned VM in the lab.
```powershell
<<<<<<< HEAD
Stop-AzLabServicesUserVM -ResourceGroupName "Group Name" -LabName "Lab Name" -Email "user@contoso.com"
=======
PS C:\> Stop-AzLabServicesUserVM -ResourceGroupName "Group Name" -LabName "Lab Name" -Email "user@contoso.com"

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This stops the VM assigned to the user with the specific email. If there isn't a VM assigned to the user a null is returned.
