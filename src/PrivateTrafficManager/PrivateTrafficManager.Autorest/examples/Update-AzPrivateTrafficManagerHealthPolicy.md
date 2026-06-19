### Example 1: Update a health policy using a JSON string
```powershell
$jsonString = '{"kind":"Probe","properties":{"name":"hp1","probeConfig":{"protocol":"HTTPS","port":443,"path":"/health","intervalInSeconds":60,"timeoutInSeconds":15,"toleratedNumberOfFailures":5}}}'
Update-AzPrivateTrafficManagerHealthPolicy -Name "hp1" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -JsonString $jsonString
```

```output
Name  Kind   ProvisioningState
----  ----   -----------------
hp1   Probe  Succeeded
```

This command updates the health policy to increase the probe interval to 60 seconds and tolerated failures to 5.

### Example 2: Update a health policy using a JSON file
```powershell
Update-AzPrivateTrafficManagerHealthPolicy -Name "hp1" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -JsonFilePath "./updated-healthpolicy.json"
```

```output
Name  Kind   ProvisioningState
----  ----   -----------------
hp1   Probe  Succeeded
```

This command updates the health policy configuration from a JSON file.

