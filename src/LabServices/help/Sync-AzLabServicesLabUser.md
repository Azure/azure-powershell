---
external help file:
Module Name: Az.LabServices
online version: https://docs.microsoft.com/powershell/module/az.labservices/sync-azlabserviceslabuser
schema: 2.0.0
---

# Sync-AzLabServicesLabUser

## SYNOPSIS
Action used to manually kick off an AAD group sync job.

## SYNTAX

### Sync (Default)
```
Sync-AzLabServicesLabUser -LabName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Lab
```
Sync-AzLabServicesLabUser -Lab <Lab> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [<CommonParameters>]
```

## DESCRIPTION
Action used to manually kick off an AAD group sync job.

## EXAMPLES

### Example 1: Sync the users connected to the lab.
```powershell
Sync-AzLabServicesLabUser -ResourceGroupName "Group Name" -LabName "Lab Name"
```

This cmdlet will sync the connected AD Group to update the users.

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

### -Lab
To construct, see NOTES section for LAB properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.Lab
Parameter Sets: Lab
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LabName
The name of the lab that uniquely identifies it within containing lab account.
Used in resource URIs.

```yaml
Type: System.String
Parameter Sets: Sync
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
Parameter Sets: Sync
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
Parameter Sets: Sync
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.Lab

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IUser

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


LAB `<Lab>`: 
  - `Location <String>`: The geo-location where the resource lives
  - `[AdditionalCapabilityInstallGpuDriver <EnableState?>]`: Flag to pre-install dedicated GPU drivers.
  - `[AdminUserPassword <String>]`: The password for the user. This is required for the TemplateVM createOption.
  - `[AdminUserUsername <String>]`: The username to use when signing in to lab VMs.
  - `[AutoShutdownProfileDisconnectDelay <TimeSpan?>]`: The amount of time a VM will stay running after a user disconnects if this behavior is enabled.
  - `[AutoShutdownProfileIdleDelay <TimeSpan?>]`: The amount of time a VM will idle before it is shutdown if this behavior is enabled.
  - `[AutoShutdownProfileNoConnectDelay <TimeSpan?>]`: The amount of time a VM will stay running before it is shutdown if no connection is made and this behavior is enabled.
  - `[AutoShutdownProfileShutdownOnDisconnect <EnableState?>]`: Whether shutdown on disconnect is enabled
  - `[AutoShutdownProfileShutdownOnIdle <ShutdownOnIdleMode?>]`: Whether a VM will get shutdown when it has idled for a period of time.
  - `[AutoShutdownProfileShutdownWhenNotConnected <EnableState?>]`: Whether a VM will get shutdown when it hasn't been connected to after a period of time.
  - `[ConnectionProfileClientRdpAccess <ConnectionType?>]`: The enabled access level for Client Access over RDP.
  - `[ConnectionProfileClientSshAccess <ConnectionType?>]`: The enabled access level for Client Access over SSH.
  - `[ConnectionProfileWebRdpAccess <ConnectionType?>]`: The enabled access level for Web Access over RDP.
  - `[ConnectionProfileWebSshAccess <ConnectionType?>]`: The enabled access level for Web Access over SSH.
  - `[Description <String>]`: The description of the lab.
  - `[ImageReferenceId <String>]`: Image resource ID
  - `[ImageReferenceOffer <String>]`: The image offer if applicable.
  - `[ImageReferencePublisher <String>]`: The image publisher
  - `[ImageReferenceSku <String>]`: The image SKU
  - `[ImageReferenceVersion <String>]`: The image version specified on creation.
  - `[NetworkProfileLoadBalancerId <String>]`: The external load balancer resource id
  - `[NetworkProfilePublicIPId <String>]`: The external public IP resource id
  - `[NetworkProfileSubnetId <String>]`: The external subnet resource id
  - `[NonAdminUserPassword <String>]`: The password for the user. This is required for the TemplateVM createOption.
  - `[NonAdminUserUsername <String>]`: The username to use when signing in to lab VMs.
  - `[PlanId <String>]`: The ID of the lab plan. Used during resource creation to provide defaults and acts as a permission container when creating a lab via labs.azure.com. Setting a labPlanId on an existing lab provides organization..
  - `[RosterProfileActiveDirectoryGroupId <String>]`: The AAD group ID which this lab roster is populated from. Having this set enables AAD sync mode.
  - `[RosterProfileLmsInstance <String>]`: The base URI identifying the lms instance.
  - `[RosterProfileLtiClientId <String>]`: The unique id of the azure lab services tool in the lms.
  - `[RosterProfileLtiContextId <String>]`: The unique context identifier for the lab in the lms.
  - `[RosterProfileLtiRosterEndpoint <String>]`: The uri of the names and roles service endpoint on the lms for the class attached to this lab.
  - `[SecurityProfileOpenAccess <EnableState?>]`: Whether any user or only specified users can register to a lab.
  - `[SkuCapacity <Int32?>]`: If the SKU supports scale out/in then the capacity integer should be included. If scale out/in is not possible for the resource this may be omitted.
  - `[SkuFamily <String>]`: If the service has different generations of hardware, for the same SKU, then that can be captured here.
  - `[SkuName <String>]`: The name of the SKU. Ex - P3. It is typically a letter+number code
  - `[SkuSize <String>]`: The SKU size. When the name field is the combination of tier and some other value, this would be the standalone code. 
  - `[SkuTier <SkuTier?>]`: This field is required to be implemented by the Resource Provider if the service has more than one tier, but is not required on a PUT.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[Title <String>]`: The title of the lab.
  - `[VirtualMachineProfileCreateOption <CreateOption?>]`: Indicates what lab virtual machines are created from.
  - `[VirtualMachineProfileUsageQuota <TimeSpan?>]`: The initial quota alloted to each lab user. Must be a time span between 0 and 9999 hours.
  - `[VirtualMachineProfileUseSharedPassword <EnableState?>]`: Enabling this option will use the same password for all user VMs.
  - `[Tag <ITrackedResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

