### Example 1: Remove an authentication policy
```powershell
Remove-AzFrontDoorCdnAuthPolicy -ResourceGroupName "myResourceGroup" -ProfileName "myProfile" -Name "myAuthPolicy" -Confirm:$false
```

Removes the specified authentication policy without prompting for confirmation.
