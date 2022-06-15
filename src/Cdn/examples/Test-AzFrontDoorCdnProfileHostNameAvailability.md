### Example 1: Test the availability of a host name under the AzureFrontDoor profile
```powershell
Test-AzFrontDoorCdnProfileHostNameAvailability -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -HostName hello1.dev.cdn.azure.cn
```

```output
Message NameAvailable Reason
------- ------------- ------
        True
```


