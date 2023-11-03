### Example 1: Delete an AzureFrontDoor security policy within the specified AzureFrontDoor profile
```powershell
Remove-AzFrontDoorCdnSecurityPolicy -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name policy001
```

Delete an AzureFrontDoor security policy within the specified AzureFrontDoor profile


### Example 2: Delete an AzureFrontDoor security policy within the specified AzureFrontDoor profile via identity
```powershell

Get-AzFrontDoorCdnSecurityPolicy -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name policy001 | Remove-AzFrontDoorCdnSecurityPolicy
```

Delete an AzureFrontDoor security policy within the specified AzureFrontDoor profile via identity