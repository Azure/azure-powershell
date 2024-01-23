### Example 1: Create the Neighbor Group Resource
```powershell
$destination = @{
    Ipv4Address = @(
        "10.10.10.10"
    )
    Ipv6Address = @(
        "2F::/100"
    )
}

New-AzNetworkFabricNeighborGroup -Name $name -ResourceGroupName $resourceGroupName -Location $location -Destination $destination
```

```output
Annotation Destination     Id
---------- -----------     --
                           /subscriptions/<identity>/resourc…
```

This command creates the Neighbor Group resource.

