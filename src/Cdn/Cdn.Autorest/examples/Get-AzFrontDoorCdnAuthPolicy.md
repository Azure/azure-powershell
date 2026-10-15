### Example 1: List authentication policies in a profile
```powershell
Get-AzFrontDoorCdnAuthPolicy -ResourceGroupName "myResourceGroup" -ProfileName "myProfile"
```

Lists the authentication policies in the specified Azure Front Door profile.

### Example 2: Get an authentication policy
```powershell
Get-AzFrontDoorCdnAuthPolicy -ResourceGroupName "myResourceGroup" -ProfileName "myProfile" -Name "myAuthPolicy"
```

Gets the specified authentication policy.
