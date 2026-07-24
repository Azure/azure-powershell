### Example 1: Create configuration filters for a region and zone
```powershell
New-AzChaosConfigurationFiltersObject -Location 'eastus' -Zone '1'
```

```output
Location Zone
-------- ----
{eastus} {1}
```

Creates an in-memory configuration filter that limits a scenario configuration to `eastus` availability zone `1`. Pass the result to `New-AzChaosScenarioConfiguration`.

### Example 2: Create configuration filters spanning multiple zones
```powershell
New-AzChaosConfigurationFiltersObject -Location 'eastus','westus2' -Zone '1','2','3'
```

```output
Location           Zone
--------           ----
{eastus, westus2}  {1, 2, 3}
```

Creates a configuration filter that spans two regions and three availability zones.
