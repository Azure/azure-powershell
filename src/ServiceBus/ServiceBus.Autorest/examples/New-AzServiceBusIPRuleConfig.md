### Example 1: Constructs an INwRuleSetIPRules object 
```powershell
New-AzServiceBusIPRuleConfig -IPMask 3.3.3.3 -Action Allow
```

```output
Action IPMask
------ ------
Allow  1.1.1.1
```

Please refer examples for Set-AzServiceBusNetworkRuleSet to know more.
