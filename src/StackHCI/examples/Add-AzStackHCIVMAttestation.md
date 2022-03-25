### Example 1: 
```powershell
Add-AzStackHCIVMAttestation -AddAll
```

Adding all guests on current node

### Example 2: 
```powershell
Invoke-Command -ScriptBlock {Add-AzStackHCIVMAttestation -VMName "guest1", "guest2"} -ComputerName "node1"
```

Invoking from the management node/WAC

