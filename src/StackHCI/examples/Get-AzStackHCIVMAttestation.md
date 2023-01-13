### Example 1: 
```powershell
Get-AzStackHCIVMAttestation
```

```output 
Name        AttestationHost    Status
----        ---------------    ------
183hcinode1 HCINODE2        Connected
bhat2       HCINODE2        Connected
ppnt3n1     HCINODE2        Connected
ppt3n0      HCINODE2        Connected
ppt5pn0     HCINODE2        Connected
ppt6pn0     HCINODE2        Connected
ppt7pn0     HCINODE2        Connected
```

Get all guests with IMDS Attestation on cluster.

### Example 2: 
```powershell
Get-AzStackHCIVMAttestation -Local
```

```output
Name        AttestationHost    Status
----        ---------------    ------
183hcinode1 HCINODE2        Connected
bhat2       HCINODE2        Connected
ppnt3n1     HCINODE2        Connected
ppt3n0      HCINODE2        Connected
ppt5pn0     HCINODE2        Connected
ppt6pn0     HCINODE2        Connected
ppt7pn0     HCINODE2        Connected
```

Gets guests with Attestation from the node executing the cmdlet.
