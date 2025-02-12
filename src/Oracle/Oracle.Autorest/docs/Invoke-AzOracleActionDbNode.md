---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/az.oracle/invoke-azoracleactiondbnode
schema: 2.0.0
---

# Invoke-AzOracleActionDbNode

## SYNOPSIS
VM actions on DbNode of VM Cluster by the provided filter

## SYNTAX

### ActionExpanded (Default)
```
Invoke-AzOracleActionDbNode -Cloudvmclustername <String> -Dbnodeocid <String> -ResourceGroupName <String>
 -Action <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ActionViaIdentityCloudVMClusterExpanded
```
Invoke-AzOracleActionDbNode -CloudVMClusterInputObject <IOracleIdentity> -Dbnodeocid <String> -Action <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActionViaIdentityExpanded
```
Invoke-AzOracleActionDbNode -InputObject <IOracleIdentity> -Action <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ActionViaJsonFilePath
```
Invoke-AzOracleActionDbNode -Cloudvmclustername <String> -Dbnodeocid <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ActionViaJsonString
```
Invoke-AzOracleActionDbNode -Cloudvmclustername <String> -Dbnodeocid <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
VM actions on DbNode of VM Cluster by the provided filter

## EXAMPLES

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

## PARAMETERS

### -Action
Db action

```yaml
Type: System.String
Parameter Sets: ActionExpanded, ActionViaIdentityCloudVMClusterExpanded, ActionViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloudVMClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: ActionViaIdentityCloudVMClusterExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Cloudvmclustername
CloudVmCluster name

```yaml
Type: System.String
Parameter Sets: ActionExpanded, ActionViaJsonFilePath, ActionViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Dbnodeocid
DbNode OCID.

```yaml
Type: System.String
Parameter Sets: ActionExpanded, ActionViaIdentityCloudVMClusterExpanded, ActionViaJsonFilePath, ActionViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity
Parameter Sets: ActionViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Action operation

```yaml
Type: System.String
Parameter Sets: ActionViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Action operation

```yaml
Type: System.String
Parameter Sets: ActionViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: ActionExpanded, ActionViaJsonFilePath, ActionViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: ActionExpanded, ActionViaJsonFilePath, ActionViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IOracleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.IDbNode

## NOTES

## RELATED LINKS

