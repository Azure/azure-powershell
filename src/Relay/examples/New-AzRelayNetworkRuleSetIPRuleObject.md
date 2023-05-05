### Example 1: Create an in-memory object for NwRuleSetIPRules
```powershell
$rules = @()
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.1"
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.2"
$rules += New-AzRelayNetworkRuleSetIPRuleObject -Action 'Allow' -IPMask "1.1.1.3"
```

```output
```

This cmdlet creates an in-memory object for NwRuleSetIPRules as the value of the `IPRule` parameter in `New-AzRelayNamespaceNetworkRuleSet`.