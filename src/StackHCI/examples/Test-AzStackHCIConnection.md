### Example 1: 
```powershell
Test-AzStackHCIConnection
```

```output
Test: Connect to Azure Stack HCI Service
EndpointTested: https://azurestackhci-df.azurefd.net/health
IsRequired: True
Result: Succeeded
```

Invoking on one of the cluster node. Success case.

### Example 2:
```powershell
Test-AzStackHCIConnection
```

```output
Test: Connect to Azure Stack HCI Service
EndpointTested: https://azurestackhci-df.azurefd.net/health
IsRequired: True
Result: Failed
FailedNodes: Node1inClus2, Node2inClus3
```

Invoking on one of the cluster node. Failed case.

