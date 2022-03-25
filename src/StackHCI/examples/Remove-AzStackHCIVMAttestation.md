### Example 1: 
```powershell
Remove-AzStackHCIVMAttestation -RemoveAll
```

Removing all guests on current node

### Example 2: 
```powershell
Invoke-Command -ScriptBlock {Remove-AzStackHCIVMAttestation -VMName "guest1", "guest2"} -ComputerName "node1"
```

Invoking from the management node/WAC

