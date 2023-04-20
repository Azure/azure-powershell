### Example 1: Gets a container registry webhook.
```powershell
Get-AzContainerRegistryWebhook  -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -Name "webhook001"
```

```output
Name       Location Status  Scope ProvisioningState
----       -------- ------  ----- -----------------
webhook001 eastus2  enabled       Succeeded
```

Gets a container registry webhook.

### Example 2: Get all the webhooks of a container registry
```powershell
Get-AzContainerRegistryWebhook  -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample"

```

```output
Name       Location Status  Scope ProvisioningState
----       -------- ------  ----- -----------------
webhook001 eastus2  enabled       Succeeded
webhook002 eastus2  enabled       Succeeded
webhook003 eastus   enabled foo:* Succeeded
```

Get all the webhooks of a container registry

