### Example 1: Invite a Follower to a Cluster database
```powershell
Invoke-AzKustoInviteDatabaseFollower -ClusterName "myCluster" -DatabaseName "myDatabase" -ResourceGroupName "myResourceGroup" -InviteeEmail "user@contoso.com"
```
Invite a user to follow database "myDatabase" in cluster "myCluster" in resource group "myResourceGroup"
