### Example 1: Update peering service tags
```powershell
$tags=@{hello='world'}
Update-AzPeeringService -Name DRTestInterCloud -ResourceGroupName DemoRG -Tag $tags
```

```output
Name             ResourceGroupName PeeringServiceLocation Provider   ProvisioningState Location
----             ----------------- ---------------------- --------   ----------------- --------
DRTestInterCloud DemoRG            Ile-de-France          InterCloud Succeeded         UK South
```

Updates the peering service tags