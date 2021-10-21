### Example 1: Remove forwarding rule by name
```powershell
PS C:\> Remove-AzDnsResolverForwardingRule -DnsForwardingRulesetName sampleForwardingRuleset -Name sampleForwardingRule -ResourceGroupName powershell-test-rg
```

This command removes forwarding rule by name

### Example 2: Remove forwarding rule via identity
```powershell
PS C:\> $inputobject = Get-AzDnsResolverForwardingRule -DnsForwardingRulesetName DnsResolverName -ResourceGroupName sampleRG -Name forwardingRule

PS C:\>  Remove-AzDnsResolverForwardingRule -InputObject $inputObject
```

This command removes forwarding rule via identity
<<<<<<< HEAD
=======

>>>>>>> 2935e5fc9cb77a0d10c6bd977239c21938094193
