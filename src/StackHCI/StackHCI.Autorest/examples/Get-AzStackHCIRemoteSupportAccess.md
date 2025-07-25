### Example 1: 
```powershell
Get-AzStackHCIRemoteSupportAccess -Cluster
```

```output
Microsoft.AzureStack.Deployment.RemoteSupport is loaded already ...
Getting RemoteSupport Access on this node
Retrieving Remote Support access. IncludeExpired is set to 'False'


State         : Active
CreatedAt     : 3/29/2022 10:30:55 AM +00:00
UpdatedAt     : 3/29/2022 10:30:55 AM +00:00
TargetService : PowerShell
AccessLevel   : Diagnostics
ExpiresAt     : 3/30/2022 10:30:55 AM +00:00
SasCredential :
```

Get remote access across a cluster

### Example 2: 
```powershell
Get-AzStackHCIRemoteSupportAccess -Cluster -IncludeExpired
```

```output
Microsoft.AzureStack.Deployment.RemoteSupport is loaded already ...
Getting RemoteSupport Access on this node
Retrieving Remote Support access. IncludeExpired is set to 'True'


State         : Active
CreatedAt     : 3/29/2022 10:30:55 AM +00:00
UpdatedAt     : 3/29/2022 10:30:55 AM +00:00
TargetService : PowerShell
AccessLevel   : Diagnostics
ExpiresAt     : 3/30/2022 10:30:55 AM +00:00
SasCredential :
```

Get remote access across a cluster with expired entries 
