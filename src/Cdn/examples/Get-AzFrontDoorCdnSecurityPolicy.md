### Example 1: List AzureFrontDoor security policies within the specified AzureFrontDoor profile
```powershell
Get-AzFrontDoorCdnSecurityPolicy -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6
```

```output
Name      ResourceGroupName
----      -----------------
policy001 testps-rg-da16jm
```

List AzureFrontDoor security policies within the specified AzureFrontDoor profile



### Example 2: Get an AzureFrontDoor security policy within the specified AzureFrontDoor profile
```powershell
Get-AzFrontDoorCdnSecurityPolicy -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -Name policy001
```

```output
Name      ResourceGroupName
----      -----------------
policy001 testps-rg-da16jm
```

Get an AzureFrontDoor security policy within the specified AzureFrontDoor profile

