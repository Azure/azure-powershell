---
external help file: Az.ConnectedMachine-help.xml
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/update-azconnectedmachine
schema: 2.0.0
---

# Update-AzConnectedMachine

## SYNOPSIS
The operation to update a hybrid machine.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzConnectedMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AgentUpgradeCorrelationId <String>] [-AgentUpgradeDesiredVersion <String>] [-AgentUpgradeEnableAutomatic]
 [-IdentityType <String>] [-Kind <String>] [-LinuxConfigurationPatchSettingsAssessmentMode <String>]
 [-LinuxConfigurationPatchSettingsPatchMode <String>] [-LocationDataCity <String>]
 [-LocationDataCountryOrRegion <String>] [-LocationDataDistrict <String>] [-LocationDataName <String>]
 [-ParentClusterResourceId <String>] [-PrivateLinkScopeResourceId <String>] [-Tag <Hashtable>]
 [-WindowsConfigurationPatchSettingsAssessmentMode <String>]
 [-WindowsConfigurationPatchSettingsPatchMode <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzConnectedMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzConnectedMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Update
```
Update-AzConnectedMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Parameter <IMachineUpdate> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzConnectedMachine -InputObject <IConnectedMachineIdentity> [-AgentUpgradeCorrelationId <String>]
 [-AgentUpgradeDesiredVersion <String>] [-AgentUpgradeEnableAutomatic] [-IdentityType <String>]
 [-Kind <String>] [-LinuxConfigurationPatchSettingsAssessmentMode <String>]
 [-LinuxConfigurationPatchSettingsPatchMode <String>] [-LocationDataCity <String>]
 [-LocationDataCountryOrRegion <String>] [-LocationDataDistrict <String>] [-LocationDataName <String>]
 [-ParentClusterResourceId <String>] [-PrivateLinkScopeResourceId <String>] [-Tag <Hashtable>]
 [-WindowsConfigurationPatchSettingsAssessmentMode <String>]
 [-WindowsConfigurationPatchSettingsPatchMode <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzConnectedMachine -InputObject <IConnectedMachineIdentity> -Parameter <IMachineUpdate>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
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

### -AgentUpgradeCorrelationId
The correlation ID passed in from RSM per upgrade.

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

### -AgentUpgradeDesiredVersion
Specifies the version info w.r.t AgentUpgrade for the machine.

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

### -AgentUpgradeEnableAutomatic
Specifies if RSM should try to upgrade this machine

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### -IdentityType
The identity type.

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity
Parameter Sets: UpdateViaIdentityExpanded, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: System.String
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, Update
Aliases: MachineName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Describes a hybrid machine Update.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IMachineUpdate
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, Update
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, Update
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
Type: System.String
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
Type: System.String
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IConnectedMachineIdentity

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IMachineUpdate

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IMachine

## NOTES

## RELATED LINKS
