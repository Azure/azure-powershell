---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/update-azdevcenteradmindevcenter
schema: 2.0.0
---

# Update-AzDevCenterAdminDevCenter

## SYNOPSIS
Partially updates a devcenter.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDevCenterAdminDevCenter -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DevBoxProvisioningSettingInstallAzureMonitorAgentEnableStatus <InstallAzureMonitorAgentEnableStatus>]
 [-DisplayName <String>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>]
 [-NetworkSettingMicrosoftHostedNetworkEnableStatus <MicrosoftHostedNetworkEnableStatus>] [-PlanId <String>]
 [-ProjectCatalogSettingCatalogItemSyncEnableStatus <CatalogItemSyncEnableStatus>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDevCenterAdminDevCenter -InputObject <IDevCenterIdentity>
 [-DevBoxProvisioningSettingInstallAzureMonitorAgentEnableStatus <InstallAzureMonitorAgentEnableStatus>]
 [-DisplayName <String>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>]
 [-NetworkSettingMicrosoftHostedNetworkEnableStatus <MicrosoftHostedNetworkEnableStatus>] [-PlanId <String>]
 [-ProjectCatalogSettingCatalogItemSyncEnableStatus <CatalogItemSyncEnableStatus>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Partially updates a devcenter.

## EXAMPLES

### Example 1: Update a dev center
```powershell
Update-AzDevCenterAdminDevCenter -Name Contoso -ResourceGroupName testRg -IdentityType "SystemAssigned"
```

This command updates a dev center named "Contoso" in the resource group "testRg".

### Example 2: Update a dev center using InputObject
```powershell
$devCenterInput = Get-AzDevCenterAdminDevCenter -Name Contoso -ResourceGroupName testRg

Update-AzDevCenterAdminDevCenter -InputObject $devCenterInput -IdentityType "SystemAssigned"
```

This command updates a dev center named "Contoso" in the resource group "testRg".

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

### -DevBoxProvisioningSettingInstallAzureMonitorAgentEnableStatus
Whether project catalogs associated with projects in this dev center can be configured to sync catalog items.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.InstallAzureMonitorAgentEnableStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
The display name of the devcenter.

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
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the devcenter.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: DevCenterName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSettingMicrosoftHostedNetworkEnableStatus
Indicates whether pools in this Dev Center can use Microsoft Hosted Networks.
Defaults to Enabled if not set.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.MicrosoftHostedNetworkEnableStatus
Parameter Sets: (All)
Aliases:

Required: False
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

### -PlanId
Resource Id of an associated Plan

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

### -ProjectCatalogSettingCatalogItemSyncEnableStatus
Whether project catalogs associated with projects in this dev center can be configured to sync catalog items.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.CatalogItemSyncEnableStatus
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.IDevCenter

## NOTES

## RELATED LINKS

