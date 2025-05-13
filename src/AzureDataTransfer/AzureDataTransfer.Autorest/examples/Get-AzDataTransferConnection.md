### Example 1: Get a specified connection
```powershell
$connection01 = Get-AzDataTransferConnection -ResourceGroupName ResourceGroup01 -Name Connection01
```

```output
Name              : Connection01
ResourceGroupName : ResourceGroup01
Status            : Active
```

This example retrieves a specific connection named `Connection01` within the resource group `ResourceGroup01`.

---

### Example 2: Get a list of connections in a resource group
```powershell
$connectionsInResourceGroup = Get-AzDataTransferConnection -ResourceGroupName ResourceGroup01
```

```output
Location Name                    SystemDataCreatedAt   SystemDataCreatedBy       SystemDataCreatedByType   
-------- ----                    -------------------   -------------------       ----- 
eastus   connection_1            2/23/2024 7:20:04 PM  example@example.com       User  
westus   connection_2            2/23/2024 7:31:55 PM  example@example.com       User  
```

This example retrieves all connections in the resource group `ResourceGroup01`.

---

### Example 3: Get a list of connections in a subscription
```powershell
$connectionsInSubscription = Get-AzDataTransferConnection -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Name              : Connection01
ResourceGroupName : ResourceGroup01
Status            : Active

Name              : Connection02
ResourceGroupName : ResourceGroup02
Status            : Inactive
```

This example retrieves all connections in the subscription with the ID `00000000-0000-0000-0000-000000000000`.

---