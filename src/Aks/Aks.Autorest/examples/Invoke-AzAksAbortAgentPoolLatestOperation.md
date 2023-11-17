### Example 1: Abort the currently running operation on the agent pool
```powershell
Invoke-AzAksAbortAgentPoolLatestOperation -ResourceGroupName mygroup -ResourceName mycluster -AgentPoolName 'pool1'
```

Abort the currently running operation on the agent pool "pool1". The Agent Pool will be moved to a Canceling state and eventually to a Canceled state when cancellation finishes. If the operation completes before cancellation can take place, a 409 error code is returned.


