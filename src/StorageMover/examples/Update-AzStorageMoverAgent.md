### Example 1: Update an agent.
```powershell
Update-AzStorageMoverAgent -ResourceGroupName myResourceGroup -StorageMoverName myStorageMover -Name myAgent -Description "Update description"
```

```output
AgentStatus                  : Registering
ArcResourceId                : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup/providers/Microsoft.HybridCompute/machines/myAgent
ArcVMUuid                    : aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa
Description                  : Update description
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

This command updates the description of a Storage mover agent. 


