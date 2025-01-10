---
external help file: Az.Migrate-help.xml
Module Name: Az.Migrate
online version: https://learn.microsoft.com/powershell/module/az.migrate/new-azmigrateserverreplication
schema: 2.0.0
---

# New-AzMigrateServerReplication

## SYNOPSIS
Starts replication for the specified server.

## SYNTAX

### ByIdDefaultUser (Default)
```
New-AzMigrateServerReplication -LicenseType <String> -TargetResourceGroupId <String> -TargetNetworkId <String>
 -TargetSubnetName <String> -TargetVMName <String> -MachineId <String> -DiskType <String> -OSDiskID <String>
 [-SqlServerLicenseType <String>] [-LinuxLicenseType <String>] [-TestNetworkId <String>]
 [-TestSubnetName <String>] [-VMWarerunasaccountID <String>] [-TargetVMSize <String>]
 [-PerformAutoResync <String>] [-TargetAvailabilitySet <String>] [-TargetAvailabilityZone <String>]
 [-VMTag <IVMwareCbtEnableMigrationInputTargetVmtags>] [-NicTag <IVMwareCbtEnableMigrationInputTargetNicTags>]
 [-DiskTag <IVMwareCbtEnableMigrationInputTargetDiskTags>] [-Tag <Hashtable>]
 [-TargetBootDiagnosticsStorageAccount <String>] [-DiskEncryptionSetID <String>] [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByIdPowerUser
```
New-AzMigrateServerReplication -LicenseType <String> -TargetResourceGroupId <String> -TargetNetworkId <String>
 -TargetSubnetName <String> -TargetVMName <String> -MachineId <String> [-SqlServerLicenseType <String>]
 [-LinuxLicenseType <String>] [-TestNetworkId <String>] [-TestSubnetName <String>]
 [-VMWarerunasaccountID <String>] [-TargetVMSize <String>] [-PerformAutoResync <String>]
 [-TargetAvailabilitySet <String>] [-TargetAvailabilityZone <String>]
 [-VMTag <IVMwareCbtEnableMigrationInputTargetVmtags>] [-NicTag <IVMwareCbtEnableMigrationInputTargetNicTags>]
 [-DiskTag <IVMwareCbtEnableMigrationInputTargetDiskTags>] [-Tag <Hashtable>]
 [-TargetBootDiagnosticsStorageAccount <String>] [-SubscriptionId <String>]
 -DiskToInclude <IVMwareCbtDiskInput[]> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ByInputObjectDefaultUser
```
New-AzMigrateServerReplication -LicenseType <String> -TargetResourceGroupId <String> -TargetNetworkId <String>
 -TargetSubnetName <String> -TargetVMName <String> -DiskType <String> -OSDiskID <String>
 [-SqlServerLicenseType <String>] [-LinuxLicenseType <String>] [-TestNetworkId <String>]
 [-TestSubnetName <String>] [-VMWarerunasaccountID <String>] [-TargetVMSize <String>]
 [-PerformAutoResync <String>] [-TargetAvailabilitySet <String>] [-TargetAvailabilityZone <String>]
 [-VMTag <IVMwareCbtEnableMigrationInputTargetVmtags>] [-NicTag <IVMwareCbtEnableMigrationInputTargetNicTags>]
 [-DiskTag <IVMwareCbtEnableMigrationInputTargetDiskTags>] [-Tag <Hashtable>]
 [-TargetBootDiagnosticsStorageAccount <String>] [-DiskEncryptionSetID <String>] [-SubscriptionId <String>]
 -InputObject <IVMwareMachine> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### ByInputObjectPowerUser
```
New-AzMigrateServerReplication -LicenseType <String> -TargetResourceGroupId <String> -TargetNetworkId <String>
 -TargetSubnetName <String> -TargetVMName <String> [-SqlServerLicenseType <String>]
 [-LinuxLicenseType <String>] [-TestNetworkId <String>] [-TestSubnetName <String>]
 [-VMWarerunasaccountID <String>] [-TargetVMSize <String>] [-PerformAutoResync <String>]
 [-TargetAvailabilitySet <String>] [-TargetAvailabilityZone <String>]
 [-VMTag <IVMwareCbtEnableMigrationInputTargetVmtags>] [-NicTag <IVMwareCbtEnableMigrationInputTargetNicTags>]
 [-DiskTag <IVMwareCbtEnableMigrationInputTargetDiskTags>] [-Tag <Hashtable>]
 [-TargetBootDiagnosticsStorageAccount <String>] [-SubscriptionId <String>]
 -DiskToInclude <IVMwareCbtDiskInput[]> -InputObject <IVMwareMachine> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The New-AzMigrateServerReplication cmdlet starts the replication for a particular discovered server in the Azure Migrate project.

## EXAMPLES

### Example 1: When there is only OS disk
```powershell
New-AzMigrateServerReplication -MachineId "/subscriptions/xxx-xxx-xxx4/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.OffAzure/VMwareSites/AzMigratePWSHTc8d1site/machines/bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-e206c9ca4f93_50063baa-9806-d6d6-7e09-c0ae87309b4f" -LicenseType NoLicenseType -TargetResourceGroupId "/subscriptions/xxx-xxx-xxx/resourceGroups/AzMigratePWSHtargetRG" -TargetNetworkId  "/subscriptions/xxx-xxx-xxx/resourceGroups/AzMigratePWSHtargetRG/providers/Microsoft.Network/virtualNetworks/AzMigrateTargetNetwork" -TargetSubnetName default -TargetVMName "prsadhu-TestVM" -DiskType "Standard_LRS" -OSDiskID "6000C299-343d-7bcd-c05e-a94bd63316dd"
```

```output
ActivityId                       : 68af14b4-46ae-48d1-b3e9-cdcffb9e8a93 ActivityId: 74d1a396-1d37-4264-8a5b-b727aaef0171
AllowedAction                    : {}
CustomDetailAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobDetailsAffectedObjectDetails
CustomDetailInstanceType         : AsrJobDetails
EndTime                          : 9/16/20 11:57:33 AM
Error                            : {}
FriendlyName                     : Enable
Id                               : /Subscriptions/xxx-xxx-xxx/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.Recover
                                   yServices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationJobs/997e2a92-5afe-49c7-a81a-89660aec9b7b
Location                         :
Name                             : 997e2a92-5afe-49c7-a81a-89660aec9b7b
ScenarioName                     : Enable
StartTime                        : 9/16/20 11:57:32 AM
State                            : Succeeded
StateDescription                 : Completed
TargetInstanceType               : ProtectionProfile
TargetObjectId                   : 42752b89-5fad-52fd-bf93-679fbdb6fed9
TargetObjectName                 : migrateAzMigratePWSHTc8d1sitepolicy
Task                             : {CloudPairingPrerequisitesCheck, CloudPairingPrepareSite}
Type                             : Microsoft.RecoveryServices/vaults/replicationJobs
```

This is for the scenario, when there is only one single disk that has to be protected.

### Example 2: When there are multiple disks
```powershell
$OSDisk = New-AzMigrateDiskMapping -DiskID '6000C299-343d-7bcd-c05e-a94bd63316dd' -DiskType 'Standard_LRS' -IsOSDisk 'true'
$DataDisk = New-AzMigrateDiskMapping -DiskID '7000C299-343d-7bcd-c05e-a94bd63316dd' -DiskType 'Standard_LRS' -IsOSDisk 'false'
$DisksToInclude = @()
$DisksToInclude += $OSDisk
$DisksToInclude += $DataDisk
New-AzMigrateServerReplication -MachineId "/subscriptions/xxx-xxx-xxx/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.OffAzure/VMwareSites/AzMigratePWSHTc8d1site/machines/bcdr-vcenter-fareast-corp-micro-cfcc5a24-a40e-56b9-a6af-e206c9ca4f93_50063baa-9806-d6d6-7e09-c0ae87309b4f" -LicenseType NoLicenseType -TargetResourceGroupId "/subscriptions/xxx-xxx-xxx/resourceGroups/AzMigratePWSHtargetRG" -TargetNetworkId  "/subscriptions/xxx-xxx-xxx/resourceGroups/AzMigratePWSHtargetRG/providers/Microsoft.Network/virtualNetworks/AzMigrateTargetNetwork" -TargetSubnetName default -TargetVMName "prsadhu-TestVM" -DiskToInclude $DisksToInclude -PerformAutoResync true
```

```output
ActivityId                       : 68af14b4-46ae-48d1-b3e9-cdcffb9e8a93 ActivityId: 74d1a396-1d37-4264-8a5b-b727aaef0171
AllowedAction                    : {}
CustomDetailAffectedObjectDetail : Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api20180110.JobDetailsAffectedObjectDetails
CustomDetailInstanceType         : AsrJobDetails
EndTime                          : 9/16/20 11:57:33 AM
Error                            : {}
FriendlyName                     : Enable
Id                               : /Subscriptions/xxx-xxx-xxx/resourceGroups/azmigratepwshtestasr13072020/providers/Microsoft.Recover
                                   yServices/vaults/AzMigrateTestProjectPWSH02aarsvault/replicationJobs/997e2a92-5afe-49c7-a81a-89660aec9b7b
Location                         :
Name                             : 997e2a92-5afe-49c7-a81a-89660aec9b7b
ScenarioName                     : Enable
StartTime                        : 9/16/20 11:57:32 AM
State                            : Succeeded
StateDescription                 : Completed
TargetInstanceType               : ProtectionProfile
TargetObjectId                   : 42752b89-5fad-52fd-bf93-679fbdb6fed9
TargetObjectName                 : migrateAzMigratePWSHTc8d1sitepolicy
Task                             : {CloudPairingPrerequisitesCheck, CloudPairingPrepareSite}
Type                             : Microsoft.RecoveryServices/vaults/replicationJobs
```

This is for the scenario, when there are multiple disks that has to be protected.

## PARAMETERS

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

### -DiskEncryptionSetID
Specifies the disk encyption set to be used.

```yaml
Type: System.String
Parameter Sets: ByIdDefaultUser, ByInputObjectDefaultUser
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskTag
Specifies the tag to be used for disk creation.
To construct, see NOTES section for DISKTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IVMwareCbtEnableMigrationInputTargetDiskTags
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskToInclude
Specifies the disks on the source server to be included for replication.
To construct, see NOTES section for DISKTOINCLUDE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IVMwareCbtDiskInput[]
Parameter Sets: ByIdPowerUser, ByInputObjectPowerUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskType
Specifies the type of disks to be used for the Azure VM.

```yaml
Type: System.String
Parameter Sets: ByIdDefaultUser, ByInputObjectDefaultUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Specifies the discovered server to be migrated.
The server object can be retrieved using the Get-AzMigrateServer cmdlet.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202001.IVMwareMachine
Parameter Sets: ByInputObjectDefaultUser, ByInputObjectPowerUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LicenseType
Specifies if Azure Hybrid benefit is applicable for the source server to be migrated.

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

### -LinuxLicenseType
Specifies if Azure Hybrid benefit is applicable for the source linux server to be migrated.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineId
Specifies the machine ID of the discovered server to be migrated.

```yaml
Type: System.String
Parameter Sets: ByIdDefaultUser, ByIdPowerUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NicTag
Specifies the tag to be used for NIC creation.
To construct, see NOTES section for NICTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IVMwareCbtEnableMigrationInputTargetNicTags
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSDiskID
Specifies the Operating System disk for the source server to be migrated.

```yaml
Type: System.String
Parameter Sets: ByIdDefaultUser, ByInputObjectDefaultUser
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PerformAutoResync
Specifies if replication be auto-repaired in case change tracking is lost for the source server under replication.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlServerLicenseType
Specifies if Azure Hybrid benefit for SQL Server is applicable for the server to be migrated.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -Tag
Specifies the tag to be used for Resource creation.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetAvailabilitySet
Specifies the Availability Set to be used for VM creationSpecifies the Availability Set to be used for VM creation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetAvailabilityZone
Specifies the Availability Zone to be used for VM creation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetBootDiagnosticsStorageAccount
Specifies the storage account to be used for boot diagnostics.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetNetworkId
Specifies the Virtual Network id within the destination Azure subscription to which the server needs to be migrated.

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

### -TargetResourceGroupId
Specifies the Resource Group id within the destination Azure subscription to which the server needs to be migrated.

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

### -TargetSubnetName
Specifies the Subnet name within the destination Virtual Network to which the server needs to be migrated.

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

### -TargetVMName
Specifies the name of the Azure VM to be created.

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

### -TargetVMSize
Specifies the SKU of the Azure VM to be created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TestNetworkId
Specifies the Virtual Network id within the destination Azure subscription to which the server needs to be test migrated.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TestSubnetName
Specifies the Subnet name within the destination Virtual Network to which the server needs to be test migrated.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMTag
Specifies the tag to be used for VM creation.
To construct, see NOTES section for VMTAG properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IVMwareCbtEnableMigrationInputTargetVmtags
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMWarerunasaccountID
Account id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Migrate.Models.Api202401.IJob

## NOTES

## RELATED LINKS
