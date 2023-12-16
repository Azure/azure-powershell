### Example 1: Get all agents in a Storage mover
```powershell
Get-AzStorageMoverAgent -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover
```

```output
AgentStatus                  : Registering
ArcResourceId                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.HybridCompute/machines/myAgent
ArcVMUuid                    : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
Description                  :
ErrorDetailCode              :
ErrorDetailMessage           :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/microsoft.storagemover/storagemovers/myStorageMover/agents/myAgent
LastStatusUpdate             :
LocalIPAddress               :
MemoryInMb                   :
Name                         : myAgent
NumberOfCores                :
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 7:15:19 AM
SystemDataCreatedBy          : myAccount@xxx.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/2/2022 7:15:19 AM
SystemDataLastModifiedBy     : myAccount@xxx.com
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/agents
UptimeInSeconds              :
Version                      :
```

This command gets all the agents under a Storage mover

### Example 2: Get a specific agent
```powershell
Get-AzStorageMoverAgent -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Name myAgent
```	

```output
AgentStatus                  : Registering
ArcResourceId                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.HybridCompute/machines/myAgent
ArcVMUuid                    : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
Description                  :
ErrorDetailCode              :
ErrorDetailMessage           :
Id                           : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/microsoft.storagemover/storagemovers/myStorageMover/agents/myAgent
LastStatusUpdate             :
LocalIPAddress               :
MemoryInMb                   :
Name                         : myAgent
NumberOfCores                :
ProvisioningState            : Succeeded
SystemDataCreatedAt          : 8/2/2022 7:15:19 AM
SystemDataCreatedBy          : myAccount@xxx.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 8/2/2022 7:15:19 AM
SystemDataLastModifiedBy     : myAccount@xxx.com
SystemDataLastModifiedByType : User
Type                         : microsoft.storagemover/storagemovers/agents
UptimeInSeconds              :
Version                      :
```

This command gets a specific agent.

