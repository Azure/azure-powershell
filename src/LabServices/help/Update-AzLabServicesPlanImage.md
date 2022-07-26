---
external help file:
Module Name: Az.LabServices
online version: https://docs.microsoft.com/powershell/module/az.labservices/update-azlabservicesplanimage
schema: 2.0.0
---

# Update-AzLabServicesPlanImage

## SYNOPSIS
Updates an image resource.

## SYNTAX

### ResourceId (Default)
```
Update-AzLabServicesPlanImage -EnabledState <EnableState> -ResourceId <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [<CommonParameters>]
```

### LabPlan
```
Update-AzLabServicesPlanImage -LabPlan <LabPlan> -Name <String> -EnabledState <EnableState>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzLabServicesPlanImage -LabPlanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-EnabledState <EnableState>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Updates an image resource.

## EXAMPLES

### Example 1: Update a lab plan image.
```powershell
Update-AzLabServicesPlanImage -ResourceGroupName "Group Name" -LabPlanName "LabPlan Name" -Name "Image Name" -EnabledState "Enabled"
```

```output
Name
----
Image Name
```

This example enables the image for use in labs.

## PARAMETERS

### -AsJob


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ResourceId
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

### -EnabledState
Is the image enabled

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Support.EnableState
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LabPlan
To construct, see NOTES section for LABPLAN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.LabPlan
Parameter Sets: LabPlan
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LabPlanName
The name of the lab plan that uniquely identifies it within containing resource group.
Used in resource URIs and in UI.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The image name.

```yaml
Type: System.String
Parameter Sets: LabPlan, UpdateExpanded
Aliases: ImageName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait


```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ResourceId
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId


```yaml
Type: System.String
Parameter Sets: ResourceId
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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.LabPlan

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.IImage

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


LABPLAN `<LabPlan>`: 
  - `Location <String>`: The geo-location where the resource lives
  - `[AllowedRegion <String[]>]`: The allowed regions for the lab creator to use when creating labs using this lab plan.
  - `[DefaultAutoShutdownProfileDisconnectDelay <TimeSpan?>]`: The amount of time a VM will stay running after a user disconnects if this behavior is enabled.
  - `[DefaultAutoShutdownProfileIdleDelay <TimeSpan?>]`: The amount of time a VM will idle before it is shutdown if this behavior is enabled.
  - `[DefaultAutoShutdownProfileNoConnectDelay <TimeSpan?>]`: The amount of time a VM will stay running before it is shutdown if no connection is made and this behavior is enabled.
  - `[DefaultAutoShutdownProfileShutdownOnDisconnect <EnableState?>]`: Whether shutdown on disconnect is enabled
  - `[DefaultAutoShutdownProfileShutdownOnIdle <ShutdownOnIdleMode?>]`: Whether a VM will get shutdown when it has idled for a period of time.
  - `[DefaultAutoShutdownProfileShutdownWhenNotConnected <EnableState?>]`: Whether a VM will get shutdown when it hasn't been connected to after a period of time.
  - `[DefaultConnectionProfileClientRdpAccess <ConnectionType?>]`: The enabled access level for Client Access over RDP.
  - `[DefaultConnectionProfileClientSshAccess <ConnectionType?>]`: The enabled access level for Client Access over SSH.
  - `[DefaultConnectionProfileWebRdpAccess <ConnectionType?>]`: The enabled access level for Web Access over RDP.
  - `[DefaultConnectionProfileWebSshAccess <ConnectionType?>]`: The enabled access level for Web Access over SSH.
  - `[DefaultNetworkProfileSubnetId <String>]`: The external subnet resource id
  - `[LinkedLmsInstance <String>]`: Base Url of the lms instance this lab plan can link lab rosters against.
  - `[SharedGalleryId <String>]`: Resource ID of the Shared Image Gallery attached to this lab plan. When saving a lab template virtual machine image it will be persisted in this gallery. Shared images from the gallery can be made available to use when creating new labs.
  - `[SupportInfoEmail <String>]`: Support contact email address.
  - `[SupportInfoInstruction <String>]`: Support instructions.
  - `[SupportInfoPhone <String>]`: Support contact phone number.
  - `[SupportInfoUrl <String>]`: Support web address.
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[Tag <ITrackedResourceTags>]`: Resource tags.
    - `[(Any) <String>]`: This indicates any property can be added to this object.

## RELATED LINKS

