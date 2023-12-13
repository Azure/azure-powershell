### Example 1: 
```powershell
Add-AzStackHCIVMAttestation -AddAll
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

Adding all guests on current node

### Example 2: 
```powershell
Invoke-Command -ScriptBlock {Add-AzStackHCIVMAttestation -VMName "bhat2", "ppt7pn0"} -ComputerName "HCINODE2"
```

```output
Name            : bhat2
AttestationHost : HCINODE2
Status          : Connected
PSComputerName  : HCINODE2
RunspaceId      : 1ec3f1f5-832d-47d3-a5db-2a43ef3fdfdf

Name            : ppt7pn0
AttestationHost : HCINODE2
Status          : Connected
PSComputerName  : HCINODE2
RunspaceId      : 1ec3f1f5-832d-47d3-a5db-2a43ef3fdfdf
```

Invoking from the management node/WAC

