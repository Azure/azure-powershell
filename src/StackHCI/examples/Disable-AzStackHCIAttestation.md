### Example 1: 
```powershell
Disable-AzStackHCIAttestation -RemoveVM
```

Remove all guests from IMDS Attestation before disabling on cluster nodes.

### Example 2: 
```powershell
Disable-AzStackHCIAttestation -ComputerName "host1"
```

Disabling ISMD attestation from Invoking from WAC/Management node 