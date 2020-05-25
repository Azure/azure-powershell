### Example 1: Regenerate Api keys for a blockchain member
```powershell
PS C:\> $keyPair = Get-AzBlockchainMemberApiKey -BlockchainMemberName myblockchainhlqc92 -ResourceGroupName lucas-bc-rg
PS C:\> New-AzBlockchainMemberApiKey -BlockchainMemberName myblockchainhlqc92 -ResourceGroupName lucas-bc-rg -KeyName $keyPair[0].KeyName

KeyName Value
------- -----
key1    D7wyajHMZcBw4MndMgytqanz
key2    eu9kx94TKH506R0i4JhYBmsx
```

This command regenerates Api keys for a blockchain member.

### Example 1: Regenerate Api keys for a blockchain member

```powershell
PS C:\> $keyPair = Get-AzBlockchainMemberApiKey -BlockchainMemberName myblockchainhlqc92 -ResourceGroupName lucas-bc-rg 
PS C:\> $bcMember = Get-AzBlockchainMember -Name myblockchainhlqc92 -ResourceGroupName lucas-bc-rg 
PS C:\> New-AzBlockchainMemberApiKey -InputObject $bcMember -KeyName $keyPair[0].KeyName

KeyName Value
------- -----
key1    DdsyaaHsdasd46asd8Bw4Mnd
key2    eu9kx94TKH506R0i4JhYBmsx
```

This command regenerates Api keys for a blockchain member.
