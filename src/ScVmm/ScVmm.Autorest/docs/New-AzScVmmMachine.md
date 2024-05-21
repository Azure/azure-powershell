---
external help file:
Module Name: Az.ScVmm
online version: https://learn.microsoft.com/powershell/module/az.scvmm/new-azscvmmmachine
schema: 2.0.0
---

# New-AzScVmmMachine

## SYNOPSIS
The operation to Create a hybrid machine.
Please note some properties can be set only during machine creation.

## SYNTAX

### CreateExpanded (Default)
```
New-AzScVmmMachine -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-Expand <String>] [-AgentUpgradeCorrelationId <String>] [-AgentUpgradeDesiredVersion <String>]
 [-AgentUpgradeEnableAutomaticUpgrade] [-ClientPublicKey <String>] [-EsuProfileAssignedLicense <ILicense>]
 [-EsuProfileLicenseAssignmentState <String>] [-Extension <IMachineExtensionInstanceView[]>]
 [-ExtensionServiceStartupType <String>] [-ExtensionServiceStatus <String>]
 [-GuestConfigurationServiceStartupType <String>] [-GuestConfigurationServiceStatus <String>]
 [-IdentityType <String>] [-Kind <String>] [-LinuxConfigurationPatchSettingsAssessmentMode <String>]
 [-LinuxConfigurationPatchSettingsPatchMode <String>] [-LocationDataCity <String>]
 [-LocationDataCountryOrRegion <String>] [-LocationDataDistrict <String>] [-LocationDataName <String>]
 [-MssqlDiscovered <String>] [-OSType <String>] [-ParentClusterResourceId <String>]
 [-PrivateLinkScopeResourceId <String>] [-Tag <Hashtable>] [-VMId <String>]
 [-WindowsConfigurationPatchSettingsAssessmentMode <String>]
 [-WindowsConfigurationPatchSettingsPatchMode <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzScVmmMachine -InputObject <IScVmmIdentity> -Location <String> [-Expand <String>]
 [-AgentUpgradeCorrelationId <String>] [-AgentUpgradeDesiredVersion <String>]
 [-AgentUpgradeEnableAutomaticUpgrade] [-ClientPublicKey <String>] [-EsuProfileAssignedLicense <ILicense>]
 [-EsuProfileLicenseAssignmentState <String>] [-Extension <IMachineExtensionInstanceView[]>]
 [-ExtensionServiceStartupType <String>] [-ExtensionServiceStatus <String>]
 [-GuestConfigurationServiceStartupType <String>] [-GuestConfigurationServiceStatus <String>]
 [-IdentityType <String>] [-Kind <String>] [-LinuxConfigurationPatchSettingsAssessmentMode <String>]
 [-LinuxConfigurationPatchSettingsPatchMode <String>] [-LocationDataCity <String>]
 [-LocationDataCountryOrRegion <String>] [-LocationDataDistrict <String>] [-LocationDataName <String>]
 [-MssqlDiscovered <String>] [-OSType <String>] [-ParentClusterResourceId <String>]
 [-PrivateLinkScopeResourceId <String>] [-Tag <Hashtable>] [-VMId <String>]
 [-WindowsConfigurationPatchSettingsAssessmentMode <String>]
 [-WindowsConfigurationPatchSettingsPatchMode <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzScVmmMachine -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-Expand <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzScVmmMachine -Name <String> -ResourceGroupName <String> -JsonString <String> [-SubscriptionId <String>]
 [-Expand <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to Create a hybrid machine.
Please note some properties can be set only during machine creation.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AgentUpgradeCorrelationId
The correlation ID passed in from RSM per upgrade.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
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

### -EsuProfileAssignedLicense
The assigned license resource.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.ILicense
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EsuProfileLicenseAssignmentState
Describes the license assignment state (Assigned or NotAssigned).

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Expand
Expands referenced resources.

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

### -Extension
Machine Extensions information (deprecated field)

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IMachineExtensionInstanceView[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
Indicates which kind of Arc machine placement on-premises, such as HCI, SCVMM or VMware etc.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
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
Parameter Sets: CreateExpanded, CreateViaJsonFilePath, CreateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IScVmmIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.IMachine

## NOTES

## RELATED LINKS

