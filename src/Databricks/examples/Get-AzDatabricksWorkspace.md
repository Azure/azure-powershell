### Example 1: Get a Databricks workspace with name
```powershell
Get-AzDatabricksWorkspace -Name databricks-test -ResourceGroupName databricks-rg-rqb2yo
```

```output
Name            ResourceGroupName    Location Managed Resource Group ID
----            -----------------    -------- -------------------------
workspace3miaeb databricks-rg-rqb2yo eastus   /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace3miaeb-3c0s2mbgrqv9k
```

This command gets a Databricks workspace in a resource group.

### Example 2: List all Databricks workspaces in a subscription
```powershell
Get-AzDatabricksWorkspace
```

```output
Name                ResourceGroupName    Location       Managed Resource Group ID
----                -----------------    --------       -------------------------
workspace1xfmkv     databricks-rg-13vdtb eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace1xfmkv-s41tghmif7cle
workspace-pwsh01    databricks-rg-13vdtb eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace-pwsh01-sdenr3zv5tyh9
workspacewqpya1     databricks-rg-13vdtb eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspacewqpya1-mhsacdo0pb15e
workspace2b8i61     databricks-rg-1jxsia eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace2b8i61-xmkef5d6j7483
workspace2rzshd     databricks-rg-1jxsia eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace2rzshd-oql04khm89rx3
```

This command lists all Databricks workspaces in a subscription.

### Example 3: List all Databricks workspaces in a resource group
```powershell
Get-AzDatabricksWorkspace -ResourceGroupName databricks-rg-rqb2yo
```

```output
Name            ResourceGroupName    Location       Managed Resource Group ID
----            -----------------    --------       -------------------------
workspace3miaeb databricks-rg-rqb2yo eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace3miaeb-3c0s2mbgrqv9k
workspacefnw9gd databricks-rg-rqb2yo eastus         /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspacefnw9gd-ik7n2yfmzhuxq
workspace3o1d60 databricks-rg-rqb2yo East US 2 EUAP /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/databricks-rg-workspace3o1d60-gancyx6kjmw71
```

This command lists all Databricks workspaces in a resource group.