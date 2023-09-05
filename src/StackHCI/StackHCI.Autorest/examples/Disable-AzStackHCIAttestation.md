### Example 1: 
```powershell
Disable-AzStackHCIAttestation -RemoveVM
```

```output
ComputerName   Status Expiration
------------   ------ ----------
HCINODE2     Inactive
```

Remove all guests from IMDS Attestation before disabling on cluster nodes.