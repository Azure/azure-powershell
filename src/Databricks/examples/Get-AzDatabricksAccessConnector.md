### Example 1: List all access connectors under a subscription
```powershell
Get-AzDatabricksAccessConnector
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   databricks-ac databricks-rg-xyv4k5
```

This command lists all access connectors under a subscription.

### Example 2: List all access connectors under a resource group
```powershell
Get-AzDatabricksAccessConnector -ResourceGroupName databricks-rg-xyv4k5
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   databricks-ac databricks-rg-xyv4k5
```

This command lists all access connectors under a resource group.

### Example 3: Get a access connectors by name
```powershell
Get-AzDatabricksAccessConnector -ResourceGroupName databricks-rg-xyv4k5 -Name databricks-ac
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   databricks-ac databricks-rg-xyv4k5
```

This command gets a access connectors by name.

### Example 4: Get a access connectors by pipeline
```powershell
New-AzDatabricksAccessConnector -ResourceGroupName databricks-rg-xyv4k5 -Name databricks-ac -Location eastus | Get-AzDatabricksAccessConnector
```

```output
Location Name          ResourceGroupName
-------- ----          -----------------
eastus   databricks-ac databricks-rg-xyv4k5
```

This command gets a access connectors by pipeline.