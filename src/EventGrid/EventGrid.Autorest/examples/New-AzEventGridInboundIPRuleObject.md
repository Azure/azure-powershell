### Example 1: Create an in-memory object for InboundIPRule.
```powershell
New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
```

```output
Action IPMask
------ ------
Allow  12.18.176.1
```

Create an in-memory object for InboundIPRule.