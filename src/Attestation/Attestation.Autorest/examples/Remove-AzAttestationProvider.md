### Example 1: Remove a specific Attestation Provider.
 
```powershell
Remove-AzAttestationProvider -Name testprovider -ResourceGroupName test-rg -PassThru
```

```output
True
```

This command removes a specific Attestation Provider.

### Example 2: Remove a specific Attestation Provider by piping

```powershell
Get-AzAttestationProvider -Name testprovider -ResourceGroupName test-rg | Remove-AzAttestationProvider -PassThru

```

```output
True
```

These commands remove a specific Attestation Provider by piping.

