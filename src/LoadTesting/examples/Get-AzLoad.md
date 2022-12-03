### Example 1: Get all Azure Load Testing resources in a subscription
```powershell
Get-AzLoad
```

```output
Name       Resource group Location DataPlane URL
----       -------------- -------- -------------
sampleres  sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
sampleres1 sample-rg      eastus   00000000-0000-0000-0000-000000000001.eastus.cnt-prod.loadtesting.azure.com
```

This command lists all Azure Load Testing resources in the subscription.

### Example 2: Get all Azure Load Testing resources in a resource group
```powershell
Get-AzLoad -ResourceGroupName sample-rg
```

```output
Name       Resource group Location DataPlane URL
----       -------------- -------- -------------
sampleres  sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
sampleres1 sample-rg      eastus   00000000-0000-0000-0000-000000000001.eastus.cnt-prod.loadtesting.azure.com
```

This command lists all Azure Load Testing resources in resource group named sample-rg.

### Example 3: Get the details of an Azure Load Testing resource
```powershell
Get-AzLoad -Name sampleres -ResourceGroupName sample-rg
```

```output
Name       Resource group Location DataPlane URL
----       -------------- -------- -------------
sampleres  sample-rg      eastus   00000000-0000-0000-0000-000000000000.eastus.cnt-prod.loadtesting.azure.com
```

This command gets the details of the Azure Load Testing resource named sampleres in resource group named sample-rg.
