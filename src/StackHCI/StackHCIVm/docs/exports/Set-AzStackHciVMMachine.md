---
external help file:
Module Name: Az.StackHCIVm
online version: https://learn.microsoft.com/powershell/module/az.stackhcivm/set-azstackhcivmmachine
schema: 2.0.0
---

# Set-AzStackHciVMMachine

## SYNOPSIS
The operation to create or update a hybrid machine.
Please note some properties can be set only during machine creation.

## SYNTAX

```
Set-AzStackHciVMMachine -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-AgentUpgradeCorrelationId <String>] [-AgentUpgradeDesiredVersion <String>]
 [-AgentUpgradeEnableAutomaticUpgrade] [-ClientPublicKey <String>]
 [-Extension <IMachineExtensionInstanceView[]>] [-ExtensionServiceStartupType <String>]
 [-ExtensionServiceStatus <String>] [-GuestConfigurationServiceStartupType <String>]
 [-GuestConfigurationServiceStatus <String>] [-IdentityType <ResourceIdentityType>] [-Kind <PrivateCloudKind>]
 [-LinuxConfigurationPatchSettingsAssessmentMode <AssessmentModeTypes>]
 [-LinuxConfigurationPatchSettingsPatchMode <PatchModeTypes>] [-LocationDataCity <String>]
 [-LocationDataCountryOrRegion <String>] [-LocationDataDistrict <String>] [-LocationDataName <String>]
 [-MssqlDiscovered <String>] [-OSType <String>] [-ParentClusterResourceId <String>]
 [-PrivateLinkScopeResourceId <String>] [-SystemDataCreatedAt <DateTime>] [-SystemDataCreatedBy <String>]
 [-SystemDataCreatedByType <CreatedByType>] [-SystemDataLastModifiedAt <DateTime>]
 [-SystemDataLastModifiedBy <String>] [-SystemDataLastModifiedByType <CreatedByType>] [-Tag <Hashtable>]
 [-VMId <String>] [-WindowsConfigurationPatchSettingsAssessmentMode <AssessmentModeTypes>]
 [-WindowsConfigurationPatchSettingsPatchMode <PatchModeTypes>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to create or update a hybrid machine.
Please note some properties can be set only during machine creation.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```powershell
{{ Add code here }}
```

{{ Add output here }}

### -------------------------- EXAMPLE 2 --------------------------
```powershell
{{ Add code here }}
```

{{ Add output here }}

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

### -ClientPublicKey
Public Key that the client provides to be used during initial resource onboarding

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

### -Extension
Machine Extensions information (deprecated field)
To construct, see NOTES section for EXTENSION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230315Preview.IMachineExtensionInstanceView[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionServiceStartupType
The behavior of the service when the Arc-enabled machine starts up.

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

### -ExtensionServiceStatus
The current status of the service.

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

### -GuestConfigurationServiceStartupType
The behavior of the service when the Arc-enabled machine starts up.

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

### -GuestConfigurationServiceStatus
The current status of the service.

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

### -Location
The geo-location where the resource lives

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

### -MssqlDiscovered
Specifies whether any MS SQL instance is discovered on the machine.

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
Parameter Sets: (All)
Aliases: MachineName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OSType
The type of Operating System (windows/linux).

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
Parameter Sets: (All)
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

### -SystemDataCreatedAt
The timestamp of resource creation (UTC).

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemDataCreatedBy
The identity that created the resource.

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

### -SystemDataCreatedByType
The type of identity that created the resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemDataLastModifiedAt
The timestamp of resource last modification (UTC)

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemDataLastModifiedBy
The identity that last modified the resource.

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

### -SystemDataLastModifiedByType
The type of identity that last modified the resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Support.CreatedByType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

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

### -VMId
Specifies the hybrid machine unique ID.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCIVm.Models.Api20230315Preview.IMachine

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


EXTENSION <IMachineExtensionInstanceView[]>: Machine Extensions information (deprecated field)
  - `[Name <String>]`: The machine extension name.
  - `[StatusCode <String>]`: The status code.
  - `[StatusDisplayStatus <String>]`: The short localizable label for the status.
  - `[StatusLevel <StatusLevelTypes?>]`: The level code.
  - `[StatusMessage <String>]`: The detailed status message, including for alerts and error messages.
  - `[StatusTime <DateTime?>]`: The time of the status.
  - `[Type <String>]`: Specifies the type of the extension; an example is "CustomScriptExtension".
  - `[TypeHandlerVersion <String>]`: Specifies the version of the script handler.

## RELATED LINKS

