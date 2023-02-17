### Example 1: Create an in-memory object for IPRange.
```powershell
New-AzMediaIPRangeObject -Address "0.0.0.0" -Name AllowAll -SubnetPrefixLength 0
```

```output
Address Name     SubnetPrefixLength
------- ----     ------------------
0.0.0.0 AllowAll 0
```

Create an in-memory object for IPRange.