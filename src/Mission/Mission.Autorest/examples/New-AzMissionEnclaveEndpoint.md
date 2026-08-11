### Example 1: Create an enclave endpoint with a destination rule
```powershell
$rule = @{ destinationType = 'FQDNTag'; destination = 'foo.example.com'; ports = '443'; protocols = @('TCP') }
New-AzMissionEnclaveEndpoint -Name 'contoso-enclave-endpoint' -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg' -Location 'eastus' -RuleCollection $rule -UpdateMode 'Automatic'
```

```output
Name                     Location ResourceGroupName ProvisioningState UpdateMode
----                     -------- ----------------- ----------------- ----------
contoso-enclave-endpoint eastus   mission-rg        Succeeded         Automatic
```

Creates an enclave endpoint named `contoso-enclave-endpoint` in the `contoso-enclave` virtual enclave, allowing HTTPS (port 443/TCP) traffic to `foo.example.com`.
