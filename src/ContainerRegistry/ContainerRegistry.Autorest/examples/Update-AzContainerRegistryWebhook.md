### Example 1: Update an existing container registry webhook.
```powershell
Update-AzContainerRegistryWebhook -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -Name "webhook001" -Uri http://www.bing.com -Action Delete,Push -Header @{SpecialHeader='headerVal'} -Tag @{Key='val'} -Status Enabled -Scope 'foo:*'
```

```output
Name       Location Status  Scope ProvisioningState
----       -------- ------  ----- -----------------
webhook001 eastus2  enabled foo:* Succeeded
```

Update an existing container registry webhook.
