### Example 1: List all Web PubSub resources in a subscription
```powershell
Get-AzWebPubSub -SubscriptionId ef72249e-9785-4799-a76b-7cdd80e1b1d0
```

```output
Name                Location      SkuName
----                --------      -------
demo1               eastus        Standard_S1
demo2               eastus        Free_F1
```



### Example 2: List all Web PubSub resources in a resource group
```powershell
Get-AzWebPubSub -ResourceGroupName psdemo
```

```output
Name       Location SkuName
----       -------- -------
psdemo-wps eastus   Standard_S1
```



### Example 3: Get a specific Web PubSub resource
```powershell
Get-AzWebPubSub -ResourceGroupName psdemo -Name psdemo-wps
```

```output
Name       Location SkuName
----       -------- -------
psdemo-wps eastus   Standard_S1
```

### Example 4: Get a specific Web PubSub resource via identity object
```powershell
$identity = @{ ResourceGroupName = 'psdemo'
ResourceName = 'psdemo-wps'
SubscriptionId = $(Get-AzContext).Subscription.Id }

$identity | Get-AzWebPubSub
```

```output
Name       Location SkuName
----       -------- -------
psdemo-wps eastus   Standard_S1
```

