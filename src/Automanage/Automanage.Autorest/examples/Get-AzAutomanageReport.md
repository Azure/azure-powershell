### Example 1: List all information about a report associated with a configuration profile assignment run
```powershell
Get-AzAutomanageReport -ResourceGroupName automangerg -VMName aglinuxvm
```

```output
Name                                         ResourceGroupName
----                                         -----------------
default/a261e96e-90bd-4feb-bed6-c9e1fb436d51 automangerg
default/787969f2-d8b2-4f33-afb3-f3636880884e automangerg
default/638cc61a-70d9-4a88-9ffc-f5a49e981dd7 automangerg
default/8cbcf4be-6f16-480b-85ac-4c0392ff0476 automangerg
default/20640074-b8fd-4e27-abc3-7c9440ea40db automangerg
default/0a9e1d06-6903-4580-8876-84ab7be07239 automangerg
default/6ae85795-33c1-45e9-8823-3124e53378ab automangerg
default/ec6183de-759e-4db2-ae94-142d0d65c33a automangerg
```

This command lists all information about a report associated with a configuration profile assignment run.

### Example 2: Get information about a report associated with a configuration profile assignment run
```powershell
Get-AzAutomanageReport -ResourceGroupName automangerg -VMName aglinuxvm -Name cb998749-f7da-4899-8273-d0fde617f49e
```

```output
Name                                         ResourceGroupName
----                                         -----------------
default/cb998749-f7da-4899-8273-d0fde617f49e automangerg
```

This command gets information about a report associated with a configuration profile assignment run.