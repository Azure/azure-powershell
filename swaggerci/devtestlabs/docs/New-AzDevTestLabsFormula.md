---
external help file:
Module Name: Az.DevTestLabs
online version: https://docs.microsoft.com/en-us/powershell/module/az.devtestlabs/new-azdevtestlabsformula
schema: 2.0.0
---

# New-AzDevTestLabsFormula

## SYNOPSIS
Create or replace an existing formula.
This operation can take a while to complete.

## SYNTAX

```
New-AzDevTestLabsFormula -LabName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Description <String>] [-FormulaContent <ILabVirtualMachineCreationParameter>]
 [-Location <String>] [-OSType <String>] [-Tag <Hashtable>] [-VMLabVmid <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or replace an existing formula.
This operation can take a while to complete.

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

### -Description
The description of the formula.

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

### -FormulaContent
The content of the formula.
To construct, see NOTES section for FORMULACONTENT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.ILabVirtualMachineCreationParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LabName
The name of the lab.

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

### -Location
The location of the resource.

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

### -Name
The name of the formula.

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

### -OSType
The OS type of the formula.

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

### -ResourceGroupName
The name of the resource group.

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

### -SubscriptionId
The subscription ID.

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
The tags of the resource.

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

### -VMLabVmid
The identifier of the VM from which a formula is to be created.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevTestLabs.Models.Api20180915.IFormula

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


FORMULACONTENT <ILabVirtualMachineCreationParameter>: The content of the formula.
  - `[AllowClaim <Boolean?>]`: Indicates whether another user can take ownership of the virtual machine
  - `[Artifact <IArtifactInstallProperties[]>]`: The artifacts to be installed on the virtual machine.
    - `[ArtifactId <String>]`: The artifact's identifier.
    - `[ArtifactTitle <String>]`: The artifact's title.
    - `[DeploymentStatusMessage <String>]`: The status message from the deployment.
    - `[InstallTime <DateTime?>]`: The time that the artifact starts to install on the virtual machine.
    - `[Parameter <IArtifactParameterProperties[]>]`: The parameters of the artifact.
      - `[Name <String>]`: The name of the artifact parameter.
      - `[Value <String>]`: The value of the artifact parameter.
    - `[Status <String>]`: The status of the artifact.
    - `[VMExtensionStatusMessage <String>]`: The status message from the virtual machine extension.
  - `[BulkCreationParameterInstanceCount <Int32?>]`: The number of virtual machine instances to create.
  - `[CreatedDate <DateTime?>]`: The creation date of the virtual machine.
  - `[CustomImageId <String>]`: The custom image identifier of the virtual machine.
  - `[DataDiskParameter <IDataDiskProperties[]>]`: New or existing data disks to attach to the virtual machine after creation
    - `[AttachNewDataDiskOptionDiskName <String>]`: The name of the disk to be attached.
    - `[AttachNewDataDiskOptionDiskSizeGiB <Int32?>]`: Size of the disk to be attached in Gibibytes.
    - `[AttachNewDataDiskOptionDiskType <StorageType?>]`: The storage type for the disk (i.e. Standard, Premium).
    - `[ExistingLabDiskId <String>]`: Specifies the existing lab disk id to attach to virtual machine.
    - `[HostCaching <HostCachingOptions?>]`: Caching option for a data disk (i.e. None, ReadOnly, ReadWrite).
  - `[DisallowPublicIPAddress <Boolean?>]`: Indicates whether the virtual machine is to be created without a public IP address.
  - `[EnvironmentId <String>]`: The resource ID of the environment that contains this virtual machine, if any.
  - `[ExpirationDate <DateTime?>]`: The expiration date for VM.
  - `[GalleryImageReferenceOSType <String>]`: The OS type of the gallery image.
  - `[GalleryImageReferenceOffer <String>]`: The offer of the gallery image.
  - `[GalleryImageReferencePublisher <String>]`: The publisher of the gallery image.
  - `[GalleryImageReferenceSku <String>]`: The SKU of the gallery image.
  - `[GalleryImageReferenceVersion <String>]`: The version of the gallery image.
  - `[IsAuthenticationWithSshKey <Boolean?>]`: Indicates whether this virtual machine uses an SSH key for authentication.
  - `[LabSubnetName <String>]`: The lab subnet name of the virtual machine.
  - `[LabVirtualNetworkId <String>]`: The lab virtual network identifier of the virtual machine.
  - `[Location <String>]`: The location of the new virtual machine or environment
  - `[Name <String>]`: The name of the virtual machine or environment
  - `[NetworkInterfaceDnsName <String>]`: The DNS name.
  - `[NetworkInterfacePrivateIPAddress <String>]`: The private IP address.
  - `[NetworkInterfacePublicIPAddress <String>]`: The public IP address.
  - `[NetworkInterfacePublicIPAddressId <String>]`: The resource ID of the public IP address.
  - `[NetworkInterfaceRdpAuthority <String>]`: The RdpAuthority property is a server DNS host name or IP address followed by the service port number for RDP (Remote Desktop Protocol).
  - `[NetworkInterfaceSshAuthority <String>]`: The SshAuthority property is a server DNS host name or IP address followed by the service port number for SSH.
  - `[NetworkInterfaceSubnetId <String>]`: The resource ID of the sub net.
  - `[NetworkInterfaceVirtualNetworkId <String>]`: The resource ID of the virtual network.
  - `[Note <String>]`: The notes of the virtual machine.
  - `[OwnerObjectId <String>]`: The object identifier of the owner of the virtual machine.
  - `[OwnerUserPrincipalName <String>]`: The user principal name of the virtual machine owner.
  - `[Password <String>]`: The password of the virtual machine administrator.
  - `[PlanId <String>]`: The id of the plan associated with the virtual machine image
  - `[ScheduleParameter <IScheduleCreationParameter[]>]`: Virtual Machine schedules to be created
    - `[DailyRecurrenceTime <String>]`: The time of day the schedule will occur.
    - `[HourlyRecurrenceMinute <Int32?>]`: Minutes of the hour the schedule will run.
    - `[Name <String>]`: The name of the virtual machine or environment
    - `[NotificationSettingEmailRecipient <String>]`: The email recipient to send notifications to (can be a list of semi-colon separated email addresses).
    - `[NotificationSettingNotificationLocale <String>]`: The locale to use when sending a notification (fallback for unsupported languages is EN).
    - `[NotificationSettingStatus <EnableStatus?>]`: If notifications are enabled for this schedule (i.e. Enabled, Disabled).
    - `[NotificationSettingTimeInMinute <Int32?>]`: Time in minutes before event at which notification will be sent.
    - `[NotificationSettingWebhookUrl <String>]`: The webhook URL to which the notification will be sent.
    - `[Status <EnableStatus?>]`: The status of the schedule (i.e. Enabled, Disabled)
    - `[Tag <IScheduleCreationParameterTags>]`: The tags of the resource.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[TargetResourceId <String>]`: The resource ID to which the schedule belongs
    - `[TaskType <String>]`: The task type of the schedule (e.g. LabVmsShutdownTask, LabVmAutoStart).
    - `[TimeZoneId <String>]`: The time zone ID (e.g. Pacific Standard time).
    - `[WeeklyRecurrenceTime <String>]`: The time of the day the schedule will occur.
    - `[WeeklyRecurrenceWeekday <String[]>]`: The days of the week for which the schedule is set (e.g. Sunday, Monday, Tuesday, etc.).
  - `[SharedPublicIPAddressConfigurationInboundNatRule <IInboundNatRule[]>]`: The incoming NAT rules
    - `[BackendPort <Int32?>]`: The port to which the external traffic will be redirected.
    - `[FrontendPort <Int32?>]`: The external endpoint port of the inbound connection. Possible values range between 1 and 65535, inclusive. If unspecified, a value will be allocated automatically.
    - `[TransportProtocol <TransportProtocol?>]`: The transport protocol for the endpoint.
  - `[Size <String>]`: The size of the virtual machine.
  - `[SshKey <String>]`: The SSH key of the virtual machine administrator.
  - `[StorageType <String>]`: Storage type to use for virtual machine (i.e. Standard, Premium).
  - `[Tag <ILabVirtualMachineCreationParameterTags>]`: The tags of the resource.
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[UserName <String>]`: The user name of the virtual machine.

## RELATED LINKS

