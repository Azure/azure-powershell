### Example 1: Stop a VM in a Cloud VM Cluster resource
```powershell
$vmClusterName = "OFake_PowerShellTestVmCluster"
$resourceGroup = "PowerShellTestRg"
$stopActionName = "Stop"
            
$dbNodeList = Get-AzOracleDbNode -Cloudvmclustername $vmClusterName -ResourceGroupName $resourceGroup
$dbNodeOcid1 = $dbNodeList[0].Name
            
Invoke-AzOracleActionDbNode -Cloudvmclustername $vmClusterName -Dbnodeocid $dbNodeOcid1 -ResourceGroupName $resourceGroup -Action $stopActionName
```

```output
AdditionalDetail             : 
BackupIPId                   : ocid1.privateIp.fake.2.1
BackupVnic2Id                : ocid1.vnic.fake.2.1
BackupVnicId                 : 
CpuCoreCount                 : 2
DbServerId                   : ocid1.dbserver.oc1.iad.anuwcljrowjpydqar5ljy52di4siacvp4h4hzwp6jcz7yrmkiaglyi7nfwdq
DbSystemId                   : ocid1.cloudvmcluster.oc1.iad.anuwcljrnirvylqanh37nglmlhotsnvzwivsfnomoa6lc7t6l5gwwocoovcq
FaultDomain                  : 
HostIPId                     : ocid1.privateIp.fake.1.1
Hostname                     : host-wq5t62
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/cloudVmClusters/OFake_PowerShellTestVmCluster/dbNodes/ocid1.dbnode.oc1.iad.anuwcljrnirvylqapfxspunpsxyaehha5wwz
                               22lazevdaoiye7bh4iy2nwfa
LifecycleDetail              : 
LifecycleState               : 
MaintenanceType              : 
MemorySizeInGb               : 45
Name                         : ocid1.dbnode.oc1.iad.anuwcljrnirvylqapfxspunpsxyaehha5wwz22lazevdaoiye7bh4iy2nwfa
Ocid                         : ocid1.dbnode.oc1.iad.anuwcljrnirvylqapfxspunpsxyaehha5wwz22lazevdaoiye7bh4iy2nwfa
ProvisioningState            : Stopping
ResourceGroupName            : PowerShellTestRg
SoftwareStorageSizeInGb      : 
StorageSizeInGb              : 90
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
TimeCreated                  : 04/07/2024 16:09:39
TimeMaintenanceWindowEnd     : 
TimeMaintenanceWindowStart   : 
Type                         : Oracle.Database/cloudVmClusters/dbNodes
Vnic2Id                      : ocid1.vnic.fake.1.1
VnicId                       : 
```

Stop a VM in a Cloud VM Cluster resource.
For more information, execute `Get-Help Invoke-AzOracleActionDbNode`.

### Example 2: Start a VM in a Cloud VM Cluster resource
```powershell
$vmClusterName = "OFake_PowerShellTestVmCluster"
$resourceGroup = "PowerShellTestRg"
$startActionName = "Start"
            
$dbNodeList = Get-AzOracleDbNode -Cloudvmclustername $vmClusterName -ResourceGroupName $resourceGroup
$dbNodeOcid1 = $dbNodeList[0].Name
            
Invoke-AzOracleActionDbNode -Cloudvmclustername $vmClusterName -Dbnodeocid $dbNodeOcid1 -ResourceGroupName $resourceGroup -Action $startActionName
```

```output
AdditionalDetail             : 
BackupIPId                   : ocid1.privateIp.fake.2.1
BackupVnic2Id                : ocid1.vnic.fake.2.1
BackupVnicId                 : 
CpuCoreCount                 : 2
DbServerId                   : ocid1.dbserver.oc1.iad.anuwcljrowjpydqar5ljy52di4siacvp4h4hzwp6jcz7yrmkiaglyi7nfwdq
DbSystemId                   : ocid1.cloudvmcluster.oc1.iad.anuwcljrnirvylqanh37nglmlhotsnvzwivsfnomoa6lc7t6l5gwwocoovcq
FaultDomain                  : 
HostIPId                     : ocid1.privateIp.fake.1.1
Hostname                     : host-wq5t62
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/PowerShellTestRg/providers/Oracle.Database/cloudVmClusters/OFake_PowerShellTestVmCluster/dbNodes/ocid1.dbnode.oc1.iad.anuwcljrnirvylqapfxspunpsxyaehha5wwz
                               22lazevdaoiye7bh4iy2nwfa
LifecycleDetail              : 
LifecycleState               : 
MaintenanceType              : 
MemorySizeInGb               : 45
Name                         : ocid1.dbnode.oc1.iad.anuwcljrnirvylqapfxspunpsxyaehha5wwz22lazevdaoiye7bh4iy2nwfa
Ocid                         : ocid1.dbnode.oc1.iad.anuwcljrnirvylqapfxspunpsxyaehha5wwz22lazevdaoiye7bh4iy2nwfa
ProvisioningState            : Starting
ResourceGroupName            : PowerShellTestRg
SoftwareStorageSizeInGb      : 
StorageSizeInGb              : 90
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
TimeCreated                  : 04/07/2024 16:09:39
TimeMaintenanceWindowEnd     : 
TimeMaintenanceWindowStart   : 
Type                         : Oracle.Database/cloudVmClusters/dbNodes
Vnic2Id                      : ocid1.vnic.fake.1.1
VnicId                       : 
```

Start a VM in a Cloud VM Cluster resource.
For more information, execute `Get-Help Invoke-AzOracleActionDbNode`.