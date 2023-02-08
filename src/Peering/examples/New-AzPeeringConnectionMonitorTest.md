### Example 1: Create a new connection monitor test
```powershell
New-AzPeeringConnectionMonitorTest -Name TestName -PeeringServiceName DRTest -ResourceGroupName DemoRG
```

```output
SourceAgent Destination DestinationPort TestFrequency Sucessful ProvisioningState
----------- ----------- --------------- ------------- --------- -----------------
Agent 1     1.1.1.1     80              30            True      Succeeded
```

Creates a connection monitor test for the peering service

