### Example 1: List the resilience items of a service group
```powershell
Get-AzResiliencyUnifiedResilienceItem -ServiceGroupName contoso-sg
```

Lists the unified resilience items of service group `contoso-sg`.

### Example 2: Get a resilience item
```powershell
Get-AzResiliencyUnifiedResilienceItem -ServiceGroupName contoso-sg -Name contoso-resilience-item
```

Gets a single unified resilience item.
