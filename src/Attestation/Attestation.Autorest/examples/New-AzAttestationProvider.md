### Example 1: Create a new Attestation Provider
```powershell
New-AzAttestationProvider -Name testprovider1 -ResourceGroupName test-rg -Location "eastus"
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
eastus  testprovider1 test-rg
```

This command creates a new Attestation Provider named `testprovider1` in resource group `test-rg`.

### Example 2: Create a new Attestation Provider with trusted signing keys
```powershell
New-AzAttestationProvider -Name testprovider2 -ResourceGroupName test-rg -Location "eastus" -PolicySigningCertificateKeyPath .\cert1.pem
```

```output
Location Name        ResourceGroupName
-------- ----        -----------------
eastus  testprovider2 test-rg
```

This command creates a new Attestation Provider named `testprovider2` with trusted signing keys in resource group `test-rg`.