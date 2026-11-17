### Example 1: List cluster log files
```powershell
Get-AzHorizonDbLogFile -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, LogType, Pool, Node, SizeInKilobyte, IsMutable
```

```output
Name           : 11111111-1111-1111-1111-111111111111
LogType        : PostgreSqlServer
Pool           : example-pool-01
Node           : node-01
SizeInKilobyte : 2048
IsMutable      : True

Name           : 22222222-2222-2222-2222-222222222222
LogType        : PostgreSqlServer
Pool           : example-pool-01
Node           : node-02
SizeInKilobyte : 1536
IsMutable      : False

Name           : 33333333-3333-3333-3333-333333333333
LogType        : PostgreSqlServer
Pool           : example-pool-01
Node           : node-03
SizeInKilobyte : 1280
IsMutable      : False
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a log file
```powershell
Get-AzHorizonDbLogFile -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -Name '11111111-1111-1111-1111-111111111111' | Format-List -Property Name, LogType, Pool, Node, SizeInKilobyte, IsMutable
```

```output
Name           : 11111111-1111-1111-1111-111111111111
LogType        : PostgreSqlServer
Pool           : example-pool-01
Node           : node-01
SizeInKilobyte : 2048
IsMutable      : True
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
