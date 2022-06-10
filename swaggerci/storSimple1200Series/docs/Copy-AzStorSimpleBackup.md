---
external help file:
Module Name: Az.StorSimple
online version: https://docs.microsoft.com/en-us/powershell/module/az.storsimple/copy-azstorsimplebackup
schema: 2.0.0
---

# Copy-AzStorSimpleBackup

## SYNOPSIS
Clones the given backup element to a new disk or share with given details.

## SYNTAX

### CloneExpanded (Default)
```
Copy-AzStorSimpleBackup -DeviceName <String> -ElementName <String> -ManagerName <String> -Name <String>
 -ResourceGroupName <String> -NewEndpointName <String> -TargetAccessPointId <String> -TargetDeviceId <String>
 [-SubscriptionId <String>] [-AccessControlRecord <String[]>] [-AdminUser <String>]
 [-DiskPropertiesDataPolicy <DataPolicy>] [-DiskPropertiesDescription <String>]
 [-DiskPropertiesMonitoringStatus <MonitoringStatus>] [-DiskPropertiesProvisionedCapacityInByte <Int64>]
 [-DiskStatus <DiskStatus>] [-SharePropertiesDataPolicy <DataPolicy>] [-SharePropertiesDescription <String>]
 [-SharePropertiesMonitoringStatus <MonitoringStatus>] [-SharePropertiesProvisionedCapacityInByte <Int64>]
 [-ShareStatus <ShareStatus>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Clone
```
Copy-AzStorSimpleBackup -DeviceName <String> -ElementName <String> -ManagerName <String> -Name <String>
 -ResourceGroupName <String> -CloneRequest <ICloneRequest> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CloneViaIdentity
```
Copy-AzStorSimpleBackup -InputObject <IStorSimpleIdentity> -CloneRequest <ICloneRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CloneViaIdentityExpanded
```
Copy-AzStorSimpleBackup -InputObject <IStorSimpleIdentity> -NewEndpointName <String>
 -TargetAccessPointId <String> -TargetDeviceId <String> [-AccessControlRecord <String[]>]
 [-AdminUser <String>] [-DiskPropertiesDataPolicy <DataPolicy>] [-DiskPropertiesDescription <String>]
 [-DiskPropertiesMonitoringStatus <MonitoringStatus>] [-DiskPropertiesProvisionedCapacityInByte <Int64>]
 [-DiskStatus <DiskStatus>] [-SharePropertiesDataPolicy <DataPolicy>] [-SharePropertiesDescription <String>]
 [-SharePropertiesMonitoringStatus <MonitoringStatus>] [-SharePropertiesProvisionedCapacityInByte <Int64>]
 [-ShareStatus <ShareStatus>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Clones the given backup element to a new disk or share with given details.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AccessControlRecord
The access control records.

```yaml
Type: System.String[]
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdminUser
The user/group who will have full permission in this share.
Active directory email address.
Example: xyz@contoso.com or Contoso\xyz.

```yaml
Type: System.String
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: False
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

### -CloneRequest
Clone Job Request Model.
To construct, see NOTES section for CLONEREQUEST properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Models.Api20161001.ICloneRequest
Parameter Sets: Clone, CloneViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -DeviceName
The device name.

```yaml
Type: System.String
Parameter Sets: Clone, CloneExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskPropertiesDataPolicy
The data policy.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Support.DataPolicy
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskPropertiesDescription
The description.

```yaml
Type: System.String
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskPropertiesMonitoringStatus
The monitoring.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Support.MonitoringStatus
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskPropertiesProvisionedCapacityInByte
The provisioned capacity in bytes.

```yaml
Type: System.Int64
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiskStatus
The disk status.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Support.DiskStatus
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ElementName
The backup element name.

```yaml
Type: System.String
Parameter Sets: Clone, CloneExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Models.IStorSimpleIdentity
Parameter Sets: CloneViaIdentity, CloneViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagerName
The manager name

```yaml
Type: System.String
Parameter Sets: Clone, CloneExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The backup name.

```yaml
Type: System.String
Parameter Sets: Clone, CloneExpanded
Aliases: BackupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NewEndpointName
Name of new endpoint which will created as part of clone job.

```yaml
Type: System.String
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
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

### -PassThru
Returns true when the command succeeds

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
The resource group name

```yaml
Type: System.String
Parameter Sets: Clone, CloneExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharePropertiesDataPolicy
The data policy

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Support.DataPolicy
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharePropertiesDescription
Description for file share

```yaml
Type: System.String
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharePropertiesMonitoringStatus
The monitoring status

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Support.MonitoringStatus
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SharePropertiesProvisionedCapacityInByte
The total provisioned capacity in Bytes

```yaml
Type: System.Int64
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ShareStatus
The Share Status

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Support.ShareStatus
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription id

```yaml
Type: System.String
Parameter Sets: Clone, CloneExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetAccessPointId
Access point Id on which clone job will performed.

```yaml
Type: System.String
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetDeviceId
DeviceId of the device which will act as the Clone target

```yaml
Type: System.String
Parameter Sets: CloneExpanded, CloneViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Models.Api20161001.ICloneRequest

### Microsoft.Azure.PowerShell.Cmdlets.StorSimple.Models.IStorSimpleIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CLONEREQUEST <ICloneRequest>: Clone Job Request Model.
  - `NewEndpointName <String>`: Name of new endpoint which will created as part of clone job.
  - `TargetAccessPointId <String>`: Access point Id on which clone job will performed.
  - `TargetDeviceId <String>`: DeviceId of the device which will act as the Clone target
  - `[AccessControlRecord <String[]>]`: The access control records.
  - `[AdminUser <String>]`: The user/group who will have full permission in this share. Active directory email address. Example: xyz@contoso.com or Contoso\xyz.
  - `[DiskPropertiesDataPolicy <DataPolicy?>]`: The data policy.
  - `[DiskPropertiesDescription <String>]`: The description.
  - `[DiskPropertiesMonitoringStatus <MonitoringStatus?>]`: The monitoring.
  - `[DiskPropertiesProvisionedCapacityInByte <Int64?>]`: The provisioned capacity in bytes.
  - `[DiskStatus <DiskStatus?>]`: The disk status.
  - `[SharePropertiesDataPolicy <DataPolicy?>]`: The data policy
  - `[SharePropertiesDescription <String>]`: Description for file share
  - `[SharePropertiesMonitoringStatus <MonitoringStatus?>]`: The monitoring status
  - `[SharePropertiesProvisionedCapacityInByte <Int64?>]`: The total provisioned capacity in Bytes
  - `[ShareStatus <ShareStatus?>]`: The Share Status

INPUTOBJECT <IStorSimpleIdentity>: Identity Parameter
  - `[AccessControlRecordName <String>]`: Name of access control record to be fetched.
  - `[BackupName <String>]`: The backup name.
  - `[CertificateName <String>]`: Certificate Name
  - `[ChapUserName <String>]`: The user name of chap to be fetched.
  - `[CredentialName <String>]`: The name of storage account credential to be fetched.
  - `[DeviceName <String>]`: The device name.
  - `[DiskName <String>]`: The disk name.
  - `[ElementName <String>]`: The backup element name.
  - `[FileServerName <String>]`: The file server name.
  - `[Id <String>]`: Resource identity path
  - `[IscsiServerName <String>]`: The iSCSI server name.
  - `[JobName <String>]`: The job name.
  - `[ManagerName <String>]`: The manager name
  - `[ResourceGroupName <String>]`: The resource group name
  - `[ScheduleGroupName <String>]`: The name of the schedule group.
  - `[ShareName <String>]`: The file share name.
  - `[StorageDomainName <String>]`: The storage domain name.
  - `[SubscriptionId <String>]`: The subscription id

## RELATED LINKS

