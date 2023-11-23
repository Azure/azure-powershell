### Example 1: List all unbilled prefixes for a peering
```powershell
Get-AzPeeringRpUnbilledPrefix -PeeringName DemoPeering -ResourceGroupName DemoRG
```

```output
Prefix      AzureRegion PeerASN
------      ----------- -------
2.16.0.0/13 West US 2   65010
23.0.0.0/12 West US 2   65010
...
```

Lists all the unbilled prefixes for a peering

