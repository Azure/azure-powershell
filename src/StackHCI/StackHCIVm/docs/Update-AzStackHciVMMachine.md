---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/update-azstackhcivmmachine
schema: 2.0.0
---

# Update-AzStackHciVMMachine

## SYNOPSIS
The operation to update a hybrid machine.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzStackHciVMMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AgentUpgradeCorrelationId <String>] [-AgentUpgradeDesiredVersion <String>]
 [-AgentUpgradeEnableAutomaticUpgrade] [-IdentityType <ResourceIdentityType>] [-Kind <PrivateCloudKind>]
 [-LinuxConfigurationPatchSettingsAssessmentMode <AssessmentModeTypes>]
 [-LinuxConfigurationPatchSettingsPatchMode <PatchModeTypes>] [-LocationDataCity <String>]
 [-LocationDataCountryOrRegion <String>] [-LocationDataDistrict <String>] [-LocationDataName <String>]
 [-ParentClusterResourceId <String>] [-PrivateLinkScopeResourceId <String>] [-Tag <Hashtable>]
 [-WindowsConfigurationPatchSettingsAssessmentMode <AssessmentModeTypes>]
 [-WindowsConfigurationPatchSettingsPatchMode <PatchModeTypes>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzStackHciVMMachine -InputObject <IStackHciVMIdentity> [-AgentUpgradeCorrelationId <String>]
 [-AgentUpgradeDesiredVersion <String>] [-AgentUpgradeEnableAutomaticUpgrade]
 [-IdentityType <ResourceIdentityType>] [-Kind <PrivateCloudKind>]
 [-LinuxConfigurationPatchSettingsAssessmentMode <AssessmentModeTypes>]
 [-LinuxConfigurationPatchSettingsPatchMode <PatchModeTypes>] [-LocationDataCity <String>]
 [-LocationDataCountryOrRegion <String>] [-LocationDataDistrict <String>] [-LocationDataName <String>]
 [-ParentClusterResourceId <String>] [-PrivateLinkScopeResourceId <String>] [-Tag <Hashtable>]
 [-WindowsConfigurationPatchSettingsAssessmentMode <AssessmentModeTypes>]
 [-WindowsConfigurationPatchSettingsPatchMode <PatchModeTypes>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to update a hybrid machine.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AgentUpgradeCorrelationId
The correlation ID passed in from RSM per upgrade.

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

### -AgentUpgradeDesiredVersion
Specifies the version info w.r.t AgentUpgrade for the machine.

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

### -AgentUpgradeEnableAutomaticUpgrade
Specifies if RSM should try to upgrade this machine

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

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.ResourceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.IStackHciVMIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Kind
Indicates which kind of VM fabric the instance is an instance of, such as HCI or SCVMM etc.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PrivateCloudKind
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxConfigurationPatchSettingsAssessmentMode
Specifies the assessment mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.AssessmentModeTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LinuxConfigurationPatchSettingsPatchMode
Specifies the patch mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PatchModeTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LocationDataCity
The city or locality where the resource is located.

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

### -LocationDataCountryOrRegion
The country or region where the resource is located

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

### -LocationDataDistrict
The district, state, or province where the resource is located.

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

### -LocationDataName
A canonical name for the geographic or physical location.

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
The name of the hybrid machine.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: MachineName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ParentClusterResourceId
The resource id of the parent cluster (Azure HCI) this machine is assigned to, if any.

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

### -PrivateLinkScopeResourceId
The resource id of the private link scope this machine is assigned to, if any.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags

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

### -WindowsConfigurationPatchSettingsAssessmentMode
Specifies the assessment mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.AssessmentModeTypes
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WindowsConfigurationPatchSettingsPatchMode
Specifies the patch mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.PatchModeTypes
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

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.IStackHciVMIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230315Preview.IMachine

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IStackHciVMIdentity>: Identity Parameter
  - `[ExtensionName <String>]`: The name of the machine extension.
  - `[ExtensionType <String>]`: The extensionType of the Extension being received.
  - `[GalleryImageName <String>]`: Name of the gallery image
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The location of the Extension being received.
  - `[LogicalNetworkName <String>]`: Name of the logical network
  - `[MachineName <String>]`: The name of the hybrid machine.
  - `[MarketplaceGalleryImageName <String>]`: Name of the marketplace gallery image
  - `[MetadataName <String>]`: Name of the HybridIdentityMetadata.
  - `[NetworkInterfaceName <String>]`: Name of the network interface
  - `[OSType <String>]`: Defines the os type.
  - `[Publisher <String>]`: The publisher of the Extension being received.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ResourceUri <String>]`: The fully qualified Azure Resource manager identifier of the Hybrid Compute machine resource to be extended.
  - `[StorageContainerName <String>]`: Name of the storage container
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[Version <String>]`: The version of the Extension being received.
  - `[VirtualHardDiskName <String>]`: Name of the virtual hard disk

## RELATED LINKS

