### Example 1: Replace an enclave endpoint's rule collection (PUT)
```powershell
$rule = @{ destinationType = 'FQDNTag'; destination = 'api.contoso.com'; ports = '443'; protocols = @('TCP') }
Set-AzMissionEnclaveEndpoint -Name 'contoso-enclave-endpoint' -VirtualEnclaveName 'contoso-enclave' -ResourceGroupName 'mission-rg' -Location 'eastus' -RuleCollection $rule -UpdateMode 'Manual'
```

```output
Name                     Location ResourceGroupName ProvisioningState UpdateMode
----                     -------- ----------------- ----------------- ----------
contoso-enclave-endpoint eastus   mission-rg        Succeeded         Manual
```

Replaces the full definition of the `contoso-enclave-endpoint` enclave endpoint, swapping in a new rule permitting HTTPS traffic to `api.contoso.com` and switching to manual update mode.
