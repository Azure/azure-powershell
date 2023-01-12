### Example 1: Get all received routes for a specific peering
```powershell
Get-AzPeeringReceivedRoute -PeeringName DemoPeering -ResourceGroupName DemoRG
```

```output
AsPath               NextHop       OriginAsValidationState Prefix         ReceivedTimestamp            RpkiValidationState TrustAnchor
------               -------       ----------------------- ------         -----------------            ------------------- -----------
7018 13335           12.90.152.69  Valid                   1.0.0.0/24     2022-12-05T11:51:51.2062620Z Valid               None
7018 13335           12.90.152.69  Valid                   1.1.1.0/24     2022-12-05T11:51:51.2062620Z Valid               None
7018 4837 4808       12.90.152.69  Valid                   1.119.192.0/21 2021-12-07T05:21:11.7043790Z Unknown             None
7018 4837 4808       12.90.152.69  Valid                   1.119.200.0/22 2021-12-07T05:21:11.7043790Z Unknown             None
7018 4837 4808 59034 12.90.152.69  Valid                   1.119.204.0/24 2021-12-07T05:21:13.7045170Z Unknown             None
7018 9680 9680 3462  12.90.152.69  Valid                   1.160.0.0/12   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.160.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.161.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.162.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.163.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 15169 396982    12.90.152.69  Unknown                 1.179.112.0/20 2021-12-07T05:21:16.7056160Z Unknown             None
7018 9680 9680 3462  12.90.152.69  Valid                   1.164.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.165.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.166.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.167.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
...
```

Gets all the received routes for a specific peering

### Example 2: Filter received routes based on optional parameters
```powershell
Get-AzPeeringReceivedRoute -PeeringName DemoPeering -ResourceGroupName DemoRG -AsPath "7018 9680 9680 3462"
```

```output
AsPath                          NextHop       OriginAsValidationState Prefix           ReceivedTimestamp            RpkiValidationState TrustAnchor
------                          -------       ----------------------- ------           -----------------            ------------------- -----------
7018 9680 9680 3462             12.90.152.69  Valid                   1.160.0.0/12     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.160.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.161.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.162.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.163.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.164.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
...
```

Gets all received routes of a peering with a specific AsPath
