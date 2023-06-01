### Example 1: The New-AzContainerRegistryWebhook cmdlet creates a container registry webhook.
```powershell
New-AzContainerRegistryWebhook -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample" -Name "webhook001" -Uri http://www.bing.com -Action Delete,Push -Header @{SpecialHeader='headerVal'} -Tag @{Key="val"} -Location "east us" -Status Enabled -Scope "foo:*"
```

```output
Name       Location Status  Scope ProvisioningState
----       -------- ------  ----- -----------------
webhook001 eastus   enabled foo:* Succeeded
```

Create a container registry webhook.
Please notice that some parameters are required in this cmdlets but not marked as required in syntax, we would change it later.


