### Example 1: Create an in-memory object for IPSecurityRestrictionRule.
```powershell
New-AzContainerAppIPSecurityRestrictionRuleObject -Action "Allow" -IPAddressRange "192.168.1.1/32" -Name "Allow work IP A subnet"
```

```output
Action Description IPAddressRange Name
------ ----------- -------------- ----
Allow              192.168.1.1/32 Allow work IP A subnet
```

Create an in-memory object for IPSecurityRestrictionRule.