### Example 1: Create a IP network rule.
```powershell
 New-AzContainerRegistryIPRuleObject -IPAddressOrRange 0.0.0.0 -Action 'Allow'
```

```output
Action IPAddressOrRange
------ ----------------
Allow  0.0.0.0
```

Create a IP network rule.



