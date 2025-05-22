### Example 1: Update a new connection monitor test
```powershell
Update-AzPeeringConnectionMonitorTest -Name TestName -PeeringServiceName DRTest -ResourceGroupName DemoRG -Destination Test
```

```output
SourceAgent Destination DestinationPort TestFrequency Sucessful ProvisioningState
----------- ----------- --------------- ------------- --------- -----------------
Agent 1     1.1.1.1     80              30            True      Succeeded
```

Updates a connection monitor test for the peering service

