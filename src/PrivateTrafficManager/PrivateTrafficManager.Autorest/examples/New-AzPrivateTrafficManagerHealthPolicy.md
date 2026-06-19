### Example 1: Create a health policy using a JSON file
```powershell
New-AzPrivateTrafficManagerHealthPolicy -Name "hp1" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -JsonFilePath "./healthpolicy.json"
```

```output
Name  Kind   ProvisioningState
----  ----   -----------------
hp1   Probe  Succeeded
```

This command creates a new health policy from a JSON file that defines the probe configuration including protocol, port, path, and health check intervals.

### Example 2: Create a health policy using a JSON string
```powershell
$jsonString = '{"kind":"Probe","properties":{"name":"https-probe","probeConfig":{"protocol":"HTTPS","port":443,"path":"/health","intervalInSeconds":30,"timeoutInSeconds":10,"toleratedNumberOfFailures":3}}}'
New-AzPrivateTrafficManagerHealthPolicy -Name "https-probe-policy" -PrivateTrafficManagerProfileName "weighted-profile" -ResourceGroupName "demo-rg" -JsonString $jsonString
```

```output
Name                 Kind   ProvisioningState
----                 ----   -----------------
https-probe-policy   Probe  Succeeded
```

This command creates a health policy with an HTTPS probe that checks the /health endpoint every 30 seconds.

