### Example 1: Get all direct peering locations
```powershell
Get-AzPeeringLocation -Kind Direct
```

```output
Get-AzPeeringLocation -Kind Direct

Name             Country AzureRegion         Kind
----             ------- -----------         ----
Amsterdam        NL      West Europe         Direct
Ashburn          US      East US             Direct
Athens           GR      France Central      Direct
Atlanta          US      East US 2           Direct
Auckland         NZ      Australia East      Direct
Barcelona        ES      France Central      Direct
Berlin           DE      West Europe         Direct
...
```

Gets all peering locations for direct peers