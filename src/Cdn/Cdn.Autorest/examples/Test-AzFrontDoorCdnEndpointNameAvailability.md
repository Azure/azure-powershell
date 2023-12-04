### Example 1: Test the availability of a endpoint name under the AzureFrontDoor profile
```powershell
Test-AzFrontDoorCdnEndpointNameAvailability -ResourceGroupName testps-rg-da16jm -Type "Microsoft.Cdn/Profiles/AfdEndpoints" -Name end001
```

```output
AvailableHostname Message            NameAvailable Reason
----------------- -------            ------------- ------
                  Name not available False         Name is already in use
```

Test the availability of a endpoint name under the AzureFrontDoor profile