---
external help file:
Module Name: Az.LabServices
online version: https://docs.microsoft.com/powershell/module/az.labservices/get-azlabservicesplanimage
schema: 2.0.0
---

# Get-AzLabServicesPlanImage

## SYNOPSIS
Gets an image resource.

## SYNTAX

### ResourceId (Default)
```
Get-AzLabServicesPlanImage -ResourceId <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzLabServicesPlanImage -LabPlanName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### LabPlan
```
Get-AzLabServicesPlanImage -LabPlan <LabPlan> [-Name <String>] [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzLabServicesPlanImage -LabPlanName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListByDisplayName
```
Get-AzLabServicesPlanImage -DisplayName <String> -LabPlanName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets an image resource.

## EXAMPLES

### Example 1: Get all image in the lab plan.
```powershell
Get-AzLabServicesPlanImage -LabPlanName "Plan Name" -ResourceGroupName "Group Name"
```

```output
Name
----
128technology.128t_networking_platform.128t_networking_platform
128technology.128technology_conductor_hourly.128technology_conductor_hourly_427
128technology.128technology_conductor_hourly.128technology_conductor_hourly_452
```

Gets all the available images, this is usually a long list of images.

### Example 2: Get specific image in the lab plan.
```powershell
Get-AzLabServicesPlanImage -LabPlanName "Plan Name"  -ResourceGroupName "Group Name" -Name 'canonical.0001-com-ubuntu-server-focal.20_04-lts'
```

```output
Name
----
canonical.0001-com-ubuntu-server-focal.20_04-lts
```

Returns the specific image.

### Example 3: Get specific image using display name.
```powershell
Get-AzLabServicesPlanImage -LabPlanName "Plan Name" -ResourceGroupName "Group Name" -DisplayName 'Ubuntu Server 20.04 LTS'
```

```output
Name
----
canonical.0001-com-ubuntu-server-focal.20_04-lts
```

Returns the specific image with the display name.

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

### -DisplayName


```yaml
Type: System.String
Parameter Sets: ListByDisplayName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
The filter to apply to the operation.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
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
Parameter Sets: Get, List, ListByDisplayName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The image name.

```yaml
Type: System.String
Parameter Sets: Get, LabPlan
Aliases: ImageName

Required: True
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
Parameter Sets: Get, List, ListByDisplayName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Type: System.String[]
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

### Microsoft.Azure.PowerShell.Cmdlets.LabServices.Models.Api20211001Preview.LabPlan

### System.String

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

