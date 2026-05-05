### Example 1: List status by project name.
```powershell
Get-AzMigrateServerMigrationStatus -ProjectName "cbt-resync-gql" -ResourceGroupName "ankitbaluni-resync-rg"
```

```output

Appliance     Server          State                         Progress TimeElapsed TimeRemaining UploadSpeed Health LastSync             Datastore        ESXiHost
---------     ------          -----                         -------- ----------- ------------- ----------- ------ --------             ---------        --------
nosbm-test-ds el41-r5w12r1-3  InitialReplication InProgress 48 %     3 hr 48 min 12 hr 37 min  1230 Mbps   Normal -                    IDCLAB-T100_10TB idclab-vcen65.corp.microsoft.com_10.150.84.28
nosbm-test-ds el41-r5w2k8r2-1 DeltaReplication Completed    -        -           -             -           Normal 9/4/2025, 3:04:45 PM IDCLAB-T100_10TB idclab-vcen65.corp.microsoft.com_10.150.84.28
nosbm-test-ds dsinha-cbt-test DeltaReplication Completed    -        -           -             -           Normal 9/4/2025, 2:58:21 PM IDCLAB-T100_10TB idclab-vcen65.corp.microsoft.com_10.150.84.28




To resolve the health issue use the command
Get-AzMigrateServerMigrationStatus -ProjectName <String> -ResourceGroupName <String> -MachineName <String> -Health
```

Get by project name.

### Example 2: List status by machine name.
```powershell
Get-AzMigrateServerMigrationStatus -ProjectName "cbt-resync-gql" -ResourceGroupName "ankitbaluni-resync-rg" -MachineName "Rhel8-Vm"
```

```output
Server Rhel8-Vm is currently healthy.

Appliance    Server   State                      Progress TimeElapsed TimeRemaining UploadSpeed LastSync              ESXiHost                                               Datastore
---------    ------   -----                      -------- ----------- ------------- ----------- --------              --------                                               ---------
cbtresyncgql Rhel8-Vm DeltaReplication Completed -        -           -             -           7/14/2025, 9:51:05 PM idclab-vcen8.fareast.corp.microsoft.com_10.150.102.181 IDCLAB-B161-3TB



Disk Level Operation Status:

Disk     State                      Progress TimeElapsed TimeRemaining UploadSpeed Datastore
----     -----                      -------- ----------- ------------- ----------- ---------
Rhel8-Vm DeltaReplication Completed -        -           -             -           IDCLAB-B161-3TB
```

Get by machine name.

### Example 3: List status by appliance name.
```powershell
Get-AzMigrateServerMigrationStatus -ProjectName "cbt-resync-gql" -ResourceGroupName "ankitbaluni-resync-rg" -ApplianceName "cbtresyncgql"
```

```output
Server          State                         Progress TimeElapsed TimeRemaining UploadSpeed Health LastSync             Datastore        ESXiHost
------          -----                         -------- ----------- ------------- ----------- ------ --------             ---------        --------
el41-r5w12r1-3  InitialReplication InProgress 48 %     3 hr 48 min 12 hr 37 min  1230 Mbps   Normal -                    IDCLAB-T100_10TB idclab-vcen65.corp.microsoft.com_10.150.84.28
el41-r5w2k8r2-1 DeltaReplication Completed    -        -           -             -           Normal 9/4/2025, 3:04:45 PM IDCLAB-T100_10TB idclab-vcen65.corp.microsoft.com_10.150.84.28
dsinha-cbt-test DeltaReplication Completed    -        -           -             -           Normal 9/4/2025, 2:58:21 PM IDCLAB-T100_10TB idclab-vcen65.corp.microsoft.com_10.150.84.28


To check expedite the operation of a server use the command
Get-AzMigrateServerMigrationStatus  -ProjectName <String> -ResourceGroupName <String> -MachineName <String> -Expedite

To resolve the health issue use the command
Get-AzMigrateServerMigrationStatus -ProjectName <String> -ResourceGroupName <String> -MachineName <String> -Health
```

Get by appliance name.

### Example 4: Expedite replication for a server.
```powershell
Get-AzMigrateServerMigrationStatus -ProjectName "cbt-resync-gql" -ResourceGroupName "ankitbaluni-resync-rg" -MachineName "Rhel8-Vm" -Expedite
```

```output
Server Information:

Appliance    Server   State                      Progress TimeElapsed TimeRemaining UploadSpeed LastSync              ESXiHost                                               Datastore
---------    ------   -----                      -------- ----------- ------------- ----------- --------              --------                                               ---------
cbtresyncgql Rhel8-Vm DeltaReplication Completed -        -           -             -           7/14/2025, 9:51:05 PM idclab-vcen8.fareast.corp.microsoft.com_10.150.102.181 IDCLAB-B161-3TB



Disk Level Operation Status:

Disk     State                      Progress TimeElapsed TimeRemaining UploadSpeed Datastore
----     -----                      -------- ----------- ------------- ----------- ---------
Rhel8-Vm DeltaReplication Completed -        -           -             -           IDCLAB-B161-3TB


Resource Sharing:

The following VMs share at least one resource (Appliance, ESXi Host, or Datastore) with VM 'Rhel8-Vm'. The 'SharedResourceType' and 'SharedResourceName' columns indicate which resource is shared.

Appliance    Server                          SharedResourceType             State                      TimeRemaining ESXiHost                                               Datastore
---------    ------                          ------------------             -----                      ------------- --------                                               ---------
cbtresyncgql wave-selfhost-vm8               Appliance                      DeltaReplication Completed -             idclab-vcen8.fareast.corp.microsoft.com_10.150.102.191 Shared_1TB
cbtresyncgql el41-r5w12r2-1                  Appliance                      DeltaReplication Completed -             idclab-vcen65.corp.microsoft.com_10.150.84.28          IDCLAB-T100_10TB
cbtresyncgql el41-r5w2k8r2-1                 Appliance                      DeltaReplication Completed -             idclab-vcen65.corp.microsoft.com_10.150.84.28          IDCLAB-T100_10TB
cbtresyncgql el41-r5w12r1-2                  Appliance                      DeltaReplication Completed -             idclab-vcen65.corp.microsoft.com_10.150.84.28          IDCLAB-T100_10TB
cbtresyncgql ubuntu22-liverserver-bios-nolvm Appliance, ESXiHost, Datastore DeltaReplication Completed -             idclab-vcen8.fareast.corp.microsoft.com_10.150.102.181 IDCLAB-B161-3TB


Resource utilization information for migration operations:

Resource                                                         Capacity  Utilization for server migrations Total utilization Status
--------                                                         --------  --------------------------------- ----------------- ------
Appliance RAM Sum : Primary and scale out appliances             32768 MB  1808 MB                           7014 MB           Underutilized
Appliance CPU Sum : Primary and scale out appliances             4 Cores   -                                 99%               At capacity
Network bandwidth Sum : Primary and scale out appliances         1192 MBps -                                 -                 Underutilized
ESXi host NFC buffer                                             32 MB     8 MB                              -                 Underutilized
Parallel Disks Replicated Sum : Primary and scale out appliances 58        3                                 -                 Underutilized
Datastore 'IDCLAB-B161-3TB' Snapshot Count                       15        2                                 -                 Underutilized


Based on the resource utilization seen above, here are suggestions to expedite server Rhel8-Vm migration:

1. CPU is At capacity. Pause or stop other migrations under this appliance, or increase CPU resources if possible.
```

Expedite replication for a specific server.
