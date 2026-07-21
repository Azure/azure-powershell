### Example 1: Exclude a resource type from a scenario configuration
```powershell
New-AzChaosConfigurationExclusionsObject -Type 'Microsoft.Compute/virtualMachines'
```

```output
Type
----
{Microsoft.Compute/virtualMachines}
```

Creates an in-memory exclusion that removes every virtual machine from the blast radius. Pass the result to `New-AzChaosScenarioConfiguration`.

### Example 2: Exclude specific resources and tags
```powershell
$excludeTag = New-AzChaosKeyValuePairObject -Key 'protected' -Value 'true'
New-AzChaosConfigurationExclusionsObject -Resource '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm' -Tag $excludeTag
```

```output
Resource                                                                                                                              Tag
--------                                                                                                                              ---
{/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm} {protected=true}
```

Creates an exclusion that removes a specific virtual machine and any resource tagged `protected=true` from the blast radius.
