### Example 1: Get a specified pipeline
```powershell
$pipeline01 = Get-AzDataTransferPipeline -ResourceGroupName ResourceGroup01 -Name Pipeline01
```

```output
Name              : Pipeline01
ResourceGroupName : ResourceGroup01
Status            : Active
```

This example retrieves a specific pipeline named `Pipeline01` within the resource group `ResourceGroup01`.

---

### Example 2: Get a list of pipelines in a resource group
```powershell
$pipelinesInResourceGroup = Get-AzDataTransferPipeline -ResourceGroupName ResourceGroup01
```

```output
Name              : Pipeline01
ResourceGroupName : ResourceGroup01
Status            : Active

Name              : Pipeline02
ResourceGroupName : ResourceGroup01
Status            : Inactive
```

This example retrieves all pipelines in the resource group `ResourceGroup01`.

---

### Example 3: Get a list of pipelines in a subscription
```powershell
$pipelinesInSubscription = Get-AzDataTransferPipeline -SubscriptionId "00000000-0000-0000-0000-000000000000"
```

```output
Name              : Pipeline01
ResourceGroupName : ResourceGroup01
Status            : Active

Name              : Pipeline02
ResourceGroupName : ResourceGroup02
Status            : Inactive
```

This example retrieves all pipelines in the subscription with the ID `00000000-0000-0000-0000-000000000000`.

---
