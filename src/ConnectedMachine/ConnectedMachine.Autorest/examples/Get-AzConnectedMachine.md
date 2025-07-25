### Example 1: List all connected machines in a subscription
```powershell
Get-AzConnectedMachine -SubscriptionId ********-****-****-****-**********
```

```output
Name           Location OSName   Status     ProvisioningState
----           -------- ------   ------     -----------------
winwestus2_1   westus2  windows  Connected  Succeeded
linwestus2_1   westus2  linux    Connected  Succeeded
winwestus2_2   westus2  windows  Connected  Succeeded
winwestus2_3   westus2  windows  Connected  Succeeded

```

Lists all connected machines in a subscription. If subscription isn't specified, it will use the subscription from your current Azure PowerShell context.

### Example 2: List all connected machines in a resource group
```powershell
Get-AzConnectedMachine -ResourceGroupName contoso-connected-machines
```

```output
Name           Location OSName   Status     ProvisioningState
----           -------- ------   ------     -----------------
winwestus2_2   westus2  windows  Connected  Succeeded
winwestus2_3   westus2  windows  Connected  Succeeded
```

List all connected machines in a resource group.

### Example 3: Get a connected machine in a resource group by name
```powershell
Get-AzConnectedMachine -ResourceGroupName contoso-connected-machines -Name winwestus2_1
```

```output
Name           Location OSName   Status     ProvisioningState
----           -------- ------   ------     -----------------
winwestus2_1   westus2  windows  Connected  Succeeded
```

Get a connected machine in a resource group by name.
