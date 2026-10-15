### Example 1: Change the authentication failure action
```powershell
Update-AzFrontDoorCdnAuthPolicy -ResourceGroupName "myResourceGroup" -ProfileName "myProfile" -Name "myAuthPolicy" -Action Log -ForwardTokenToOrigin:$false
```

Updates the policy to log authentication failures instead of blocking requests and disables token forwarding to the origin. Omitted properties are not included in the update request.
