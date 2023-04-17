### Example 1: Test the availability of a host name under the AzureFrontDoor profile
```powershell
Test-AzFrontDoorCdnProfileHostNameAvailability -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -HostName hello1.dev.cdn.azure.cn
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Test the availability of a host name under the AzureFrontDoor profile


### Example 2: Test the availability of a host name under the AzureFrontDoor profile via identity
```powershell
Get-AzFrontDoorCdnProfile -ResourceGroupName testps-rg-da16jm -Name fdp-v542q6 | Test-AzFrontDoorCdnProfileHostNameAvailability -HostName hello1.dev.cdn.azure.cn
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```

Test the availability of a host name under the AzureFrontDoor profile via identity
