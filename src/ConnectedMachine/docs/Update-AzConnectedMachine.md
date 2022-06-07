---
external help file:
Module Name: Az.ConnectedMachine
online version: https://docs.microsoft.com/powershell/module/az.connectedmachine/update-azconnectedmachine
schema: 2.0.0
---

# Update-AzConnectedMachine

## SYNOPSIS
The operation to update a hybrid machine.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzConnectedMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IdentityType <ResourceIdentityType>] [-LinuxConfigurationPatchSettingsAssessmentMode <AssessmentModeTypes>]
 [-LinuxConfigurationPatchSettingsPatchMode <PatchModeTypes>] [-LocationDataCity <String>]
 [-LocationDataCountryOrRegion <String>] [-LocationDataDistrict <String>] [-LocationDataName <String>]
 [-ParentClusterResourceId <String>] [-PrivateLinkScopeResourceId <String>] [-Tag <Hashtable>]
 [-WindowsConfigurationPatchSettingsAssessmentMode <AssessmentModeTypes>]
 [-WindowsConfigurationPatchSettingsPatchMode <PatchModeTypes>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzConnectedMachine -Name <String> -ResourceGroupName <String> -Parameter <IMachineUpdate>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzConnectedMachine -InputObject <IConnectedMachineIdentity> -Parameter <IMachineUpdate>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzConnectedMachine -InputObject <IConnectedMachineIdentity> [-IdentityType <ResourceIdentityType>]
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

### Example 1: Update a machine using parameters
```powershell
Update-AzConnectedMachine -Name surface -ResourceGroupName rg -PrivateLinkScopeResourceId privateLinkScopeId -WindowsConfigurationPatchSettingsAssessmentMode AutomaticByOS -Tag @{"key"="value"}
```

```output
ResourceGroupName Name    Location    OSType  Status    ProvisioningState
----------------- ----    --------    ------  ------    -----------------
rg               surface    eastus2euap windows Connected Updating
```

Update a machine

### Example 2: Update a machine - cleaning a field
```powershell
Update-AzConnectedMachine -Name surface -ResourceGroupName rg -PrivateLinkScopeResourceId $null
```

```output
ResourceGroupName Name    Location    OSType  Status    ProvisioningState
----------------- ----    --------    ------  ------    -----------------
rg               surface eastus2euap windows Connected Updating
```

Update a machine to clean a field

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

### -IdentityType
The identity type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.ResourceIdentityType
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LinuxConfigurationPatchSettingsAssessmentMode
Specifies the assessment mode.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.AssessmentModeTypes
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchModeTypes
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded
Aliases: MachineName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Describes a hybrid machine Update.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IMachineUpdate
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ParentClusterResourceId
The resource id of the parent cluster (Azure HCI) this machine is assigned to, if any.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: Update, UpdateExpanded
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.AssessmentModeTypes
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Support.PatchModeTypes
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IMachineUpdate

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.Api20220310.IMachine

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IConnectedMachineIdentity>: Identity Parameter
  - `[ExtensionName <String>]`: The name of the machine extension.
  - `[GroupName <String>]`: The name of the private link resource.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: The location of the target resource.
  - `[MachineName <String>]`: The name of the hybrid machine.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[PrivateLinkScopeId <String>]`: The id (Guid) of the Azure Arc PrivateLinkScope resource.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[ScopeName <String>]`: The name of the Azure Arc PrivateLinkScope resource.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

PARAMETER <IMachineUpdate>: Describes a hybrid machine Update.
  - `[Tag <IResourceUpdateTags>]`: Resource tags
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[IdentityType <ResourceIdentityType?>]`: The identity type.
  - `[LinuxConfigurationPatchSettingsAssessmentMode <AssessmentModeTypes?>]`: Specifies the assessment mode.
  - `[LinuxConfigurationPatchSettingsPatchMode <PatchModeTypes?>]`: Specifies the patch mode.
  - `[LocationDataCity <String>]`: The city or locality where the resource is located.
  - `[LocationDataCountryOrRegion <String>]`: The country or region where the resource is located
  - `[LocationDataDistrict <String>]`: The district, state, or province where the resource is located.
  - `[LocationDataName <String>]`: A canonical name for the geographic or physical location.
  - `[ParentClusterResourceId <String>]`: The resource id of the parent cluster (Azure HCI) this machine is assigned to, if any.
  - `[PrivateLinkScopeResourceId <String>]`: The resource id of the private link scope this machine is assigned to, if any.
  - `[WindowsConfigurationPatchSettingsAssessmentMode <AssessmentModeTypes?>]`: Specifies the assessment mode.
  - `[WindowsConfigurationPatchSettingsPatchMode <PatchModeTypes?>]`: Specifies the patch mode.

## RELATED LINKS

