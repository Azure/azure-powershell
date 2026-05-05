---
external help file: Az.Migrate-help.xml
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/get-azmigrateservermigrationstatus
schema: 2.0.0
---

# Get-AzMigrateServerMigrationStatus

## SYNOPSIS
Retrieves the details of the replicating server status.

## SYNTAX

### ListByName (Default)
```
Get-AzMigrateServerMigrationStatus -ResourceGroupName <String> -ProjectName <String> [-SubscriptionId <String>]
 [-Filter <String>] [-SkipToken <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByMachineName
```
Get-AzMigrateServerMigrationStatus -ResourceGroupName <String> -ProjectName <String> [-SubscriptionId <String>]
 -MachineName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetHealthByMachineName
```
Get-AzMigrateServerMigrationStatus -ResourceGroupName <String> -ProjectName <String> [-SubscriptionId <String>]
 -MachineName <String> [-Health] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByPrioritiseServer
```
Get-AzMigrateServerMigrationStatus -ResourceGroupName <String> -ProjectName <String> [-SubscriptionId <String>]
 -MachineName <String> [-Expedite] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetByApplianceName
```
Get-AzMigrateServerMigrationStatus -ResourceGroupName <String> -ProjectName <String> [-SubscriptionId <String>]
 -ApplianceName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzMigrateServerMigrationStatus cmdlet retrieves the replication status for the replicating server.

## EXAMPLES

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

## PARAMETERS

### -ApplianceName
Specifies the name of the appliance.

```yaml
Type: System.String
Parameter Sets: GetByApplianceName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Expedite
Specifies whether to expedite the operation of a replicating server.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetByPrioritiseServer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
OData filter options.

```yaml
Type: System.String
Parameter Sets: ListByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Health
Specifies whether the health issues to show for replicating server.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetHealthByMachineName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineName
Specifies the display name of the replicating machine.

```yaml
Type: System.String
Parameter Sets: GetByMachineName, GetHealthByMachineName, GetByPrioritiseServer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProjectName
Specifies the Azure Migrate project  in the current subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the Resource Group of the Azure Migrate Project in the current subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
The pagination token.

```yaml
Type: System.String
Parameter Sets: ListByName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### System.Management.Automation.PSObject[]

## NOTES

## RELATED LINKS
