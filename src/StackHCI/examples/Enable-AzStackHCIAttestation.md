### Example 1: 
```powershell
Enable-AzStackHCIAttestation -AddVM
```

Invoking on one of the cluster node.

### Example 2:
```powershell
Enable-AzStackHCIAttestation -ComputerName "host1" -AddVM
```

Invoking from WAC/Management node and adding all existing VMs cluster-wide

