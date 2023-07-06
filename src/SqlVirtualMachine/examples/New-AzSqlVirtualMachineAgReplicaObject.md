### Example 1: Create an in-memory object for availability group replica configuration
```powershell
$AgReplica = New-AzSqlVirtualMachineAgReplicaObject -Commit 'SYNCHRONOUS_COMMIT' -Failover 'MANUAL' -ReadableSecondary 'NO' -Role 'PRIMARY' -SqlVirtualMachineInstanceId $sqlvmResourceId1
$AgReplica
```

```output
Commit             Failover ReadableSecondary Role    SqlVirtualMachineInstanceId
------             -------- ----------------- ----    ---------------------------
SYNCHRONOUS_COMMIT MANUAL   NO                PRIMARY 
```

*New-AzSqlVirtualMachineAgReplicaObject* creates an in-memory object of type *AgReplica*. This object represents an availability group replica configuration and will be used for parameter *AvailabilityGroupConfigurationReplica* in cmdlet *New-AzAvailabilityGroupListener*.

