### Example 1: Lists all connection monitor tests
```powershell
 Get-AzPeeringConnectionMonitorTest -ResourceGroupName DemoRG -PeeringServiceName DRTest
```

```output
List of Connection Monitor Tests
```

Lists all connection monitor test objects

### Example 2: Get single connection monitor test
```powershell
 Get-AzPeeringConnectionMonitorTest -ResourceGroupName DemoRG -PeeringServiceName DRTest -Name TestName
```

```output
Connection Monitor Test Object
```

Gets a single connection monitor test

