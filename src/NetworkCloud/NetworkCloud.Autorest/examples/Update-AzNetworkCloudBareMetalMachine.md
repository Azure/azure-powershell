### Example 1: Update bare metal machine
```powershell
Update-AzNetworkCloudBareMetalMachine -Name bmmName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId -Tag @{tags = "tag1"} -MachineDetail machineDetailInfo
```

```output
Location  Name                    SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                         -------------------                -------------------                  -----------------------                   ------------------------                 ------------
westus3  rack1compute03 07/28/2023 03:00:25   <identity>                         User                                          07/19/2023 15:46:45           <identity>
```

This command updates properties of an existing bare metal machine.
