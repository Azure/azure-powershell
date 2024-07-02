### Example 1: Update the Neighbor Group
```powershell
$destination = @{
                Ipv4Address = @(
                    "10.11.10.11"
                )
                Ipv6Address = @(
                    "2FF::/101"
                )
            }

Update-AzNetworkFabricNeighborGroup -Name $name -ResourceGroupName $resourceGroupName -Destination $destination
```

```output
Annotation Destination     Id
---------- -----------     --
                           /subscriptions/<identity>/resour…
```

This command updates the properties of the given Neighbor Group.


