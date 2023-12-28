### Example 1: Update fleet member with specified member name and fleet name
```powershell
Update-AzFleetMember -FleetName testfleet01 -ResourceGroupName K8sFleet-Test -Name testmember -Group 'group-a'
```

```output
ClusterResourceId            : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/microsoft.containerservice/managedClusters/TestCluster01
ETag                         : "ca06635b-0000-0100-0000-655c797d0000"
Group                        : group-a
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01/members/testmember
Name                         : testmember
ProvisioningState            : Succeeded
ResourceGroupName            : K8sFleet-Test
SystemDataCreatedAt          : 11/21/2023 9:33:48 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/21/2023 9:33:48 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.ContainerService/fleets/members
```

This command updates fleet member with specified member name and fleet name.

### Example 2: Update fleet member with specified fleet object and member name
```powershell
$member = Get-AzFleetMember -FleetName testfleet01 -ResourceGroupName K8sFleet-Test -Name testmember
Update-AzFleetMember -InputObject $member -Group 'group-a'
```

```output
ClusterResourceId            : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/microsoft.containerservice/managedClusters/TestCluster01
ETag                         : "ca06266c-0000-0100-0000-655c79fa0000"
Group                        : group-a
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/K8sFleet-Test/providers/Microsoft.ContainerService/fleets/testfleet01/members/testmember
Name                         : testmember
ProvisioningState            : Succeeded
ResourceGroupName            : K8sFleet-Test
SystemDataCreatedAt          : 11/21/2023 9:35:54 AM
SystemDataCreatedBy          : user1@example.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 11/21/2023 9:35:54 AM
SystemDataLastModifiedBy     : user1@example.com
SystemDataLastModifiedByType : User
Type                         : Microsoft.ContainerService/fleets/members
```

The first command get a fleet. The second command updates fleet member with specified fleet object and member name.

