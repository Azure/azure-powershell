---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/update-azkeyvaultmanagedhsmnetworkruleset
schema: 2.0.0
---

# Update-AzKeyVaultManagedHsmNetworkRuleSet

## SYNOPSIS
Replace or modify the Managed HSM network rule set (DefaultAction, Bypass, and/or full IP rule list).

## SYNTAX

### ByName (Default)
```
Update-AzKeyVaultManagedHsmNetworkRuleSet [-Name] <String> [[-ResourceGroupName] <String>]
 [-DefaultAction <PSManagedHsmNetworkRuleDefaultActionEnum>] [-Bypass <PSManagedHsmNetworkRuleBypassEnum>]
 [-IpAddressRange <String[]>] [-VirtualNetworkResourceId <String[]>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### ByInputObject
```
Update-AzKeyVaultManagedHsmNetworkRuleSet [-InputObject] <PSManagedHsm>
 [-DefaultAction <PSManagedHsmNetworkRuleDefaultActionEnum>] [-Bypass <PSManagedHsmNetworkRuleBypassEnum>]
 [-IpAddressRange <String[]>] [-VirtualNetworkResourceId <String[]>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### ByResourceId
```
Update-AzKeyVaultManagedHsmNetworkRuleSet [-ResourceId] <String>
 [-DefaultAction <PSManagedHsmNetworkRuleDefaultActionEnum>] [-Bypass <PSManagedHsmNetworkRuleBypassEnum>]
 [-IpAddressRange <String[]>] [-VirtualNetworkResourceId <String[]>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Updates the Managed HSM network ACL configuration. This cmdlet REPLACES the IP rule list when
`-IpAddressRange` is supplied; omit the parameter to retain the existing list. Virtual network rules
are not currently supported for Managed HSM. If you specify any IP rules (either existing retained
or newly provided) you must keep / set `DefaultAction` = `Deny`; attempting to apply IP rules with
`DefaultAction Allow` results in an error.

Typical scenarios:
* Add or remove IP ranges in bulk by supplying a complete new list via `-IpAddressRange`.
* Clear all IP rules by passing an empty array: `-IpAddressRange @()` then (optionally) switch to Allow.
* Change only DefaultAction or Bypass while leaving IP rules untouched by omitting `-IpAddressRange`.

## EXAMPLES

### Example 1: Switch from Allow to Deny (enabling firewall) with an initial rule
```powershell
Update-AzKeyVaultManagedHsmNetworkRuleSet -Name myHsm -ResourceGroupName myRg -DefaultAction Deny -IpAddressRange 203.0.113.0/24
```

```output
Name           Resource Group Name Location SKU        ProvisioningState Security Domain ActivationStatus
----           ------------------- -------- ---        ----------------- --------------------------------
mhsm1814428918 kv-mhsm-rg          eastus   StandardB1 Succeeded         NotActivated


$h.OriginalManagedHsm.Properties.NetworkAcls
Bypass              : AzureServices
DefaultAction       : Deny
IPRules             : {203.0.113.0/24}
ServiceTags         : {}
VirtualNetworkRules : {}
```

Enables the firewall and sets a single permitted CIDR.

### Example 2: Append rules using Add cmdlet then view (assuming -DefaultAction is set to Deny)
```powershell
Add-AzKeyVaultManagedHsmNetworkRule -Name myHsm -ResourceGroupName myRg -IpAddressRange 198.51.100.10/32
Update-AzKeyVaultManagedHsmNetworkRuleSet -Name myHsm -ResourceGroupName myRg -Bypass AzureServices -PassThru
```

```output
(No output but the IP was added to the list)


Name           Resource Group Name Location SKU        ProvisioningState Security Domain ActivationStatus
----           ------------------- -------- ---        ----------------- --------------------------------
mhsm1814428918 kv-mhsm-rg          eastus   StandardB1 Succeeded         NotActivated

$h.OriginalManagedHsm.Properties.NetworkAcls
Bypass              : AzureServices
DefaultAction       : Deny
IPRules             : {198.51.100.10/32}
ServiceTags         : {}
VirtualNetworkRules : {}
```

Leaves existing IP list intact (no -IpAddressRange provided) and changes only the Bypass setting.

### Example 3: Replace the entire IP rule list
```powershell
Update-AzKeyVaultManagedHsmNetworkRuleSet -Name myHsm -ResourceGroupName myRg -IpAddressRange 203.0.113.0/24,198.51.100.0/25 -DefaultAction Deny
```

```output
Name           Resource Group Name Location SKU        ProvisioningState Security Domain ActivationStatus
----           ------------------- -------- ---        ----------------- --------------------------------
mhsm1814428918 kv-mhsm-rg          eastus   StandardB1 Succeeded         NotActivated


$h.OriginalManagedHsm.Properties.NetworkAcls
Bypass              : AzureServices
DefaultAction       : Deny
IPRules             : {203.0.113.0/24, 198.51.100.0/25}
ServiceTags         : {}
VirtualNetworkRules : {}
```

Overwrites current IP rules with exactly two CIDR ranges.

### Example 4: Clear all IP rules then open access
```powershell
Update-AzKeyVaultManagedHsmNetworkRuleSet -Name myHsm -ResourceGroupName myRg -IpAddressRange @() -DefaultAction Deny
Update-AzKeyVaultManagedHsmNetworkRuleSet -Name myHsm -ResourceGroupName myRg -DefaultAction Allow
```

```output
Name           Resource Group Name Location SKU        ProvisioningState Security Domain ActivationStatus
----           ------------------- -------- ---        ----------------- --------------------------------
mhsm1814428918 kv-mhsm-rg          eastus   StandardB1 Succeeded         NotActivated


$h.OriginalManagedHsm.Properties.NetworkAcls
Bypass              : AzureServices
DefaultAction       : Deny
IPRules             : {}
ServiceTags         : {}
VirtualNetworkRules : {}




Name           Resource Group Name Location SKU        ProvisioningState Security Domain ActivationStatus
----           ------------------- -------- ---        ----------------- --------------------------------
mhsm1814428918 kv-mhsm-rg          eastus   StandardB1 Succeeded         NotActivated


$h.OriginalManagedHsm.Properties.NetworkAcls
Bypass              : AzureServices
DefaultAction       : Allow
IPRules             : {}
ServiceTags         : {}
VirtualNetworkRules : {}

```

Two-step pattern: clear rules while still Deny, then switch to Allow once list is empty.

## PARAMETERS

### -Bypass
Specifies bypass of network rule.

```yaml
Type: PSManagedHsmNetworkRuleBypassEnum
Parameter Sets: (All)
Aliases:
Accepted values: None, AzureServices

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultAction
Specifies default action of network rule.

```yaml
Type: PSManagedHsmNetworkRuleDefaultActionEnum
Parameter Sets: (All)
Aliases:
Accepted values: Allow, Deny

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Managed HSM object.

```yaml
Type: PSManagedHsm
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IpAddressRange
Complete replacement list of CIDR IP ranges. Omit parameter to keep existing list. Pass `@()` (empty
array) to clear all IP rules.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Specifies the name of a Managed HSM whose network rule set is being modified.

```yaml
Type: String
Parameter Sets: ByName
Aliases: HsmName

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
This Cmdlet does not return an object by default.
If this switch is specified, it returns the updated managed HSM object.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the resource group name of the Managed HSM whose network rule set is being modified.

```yaml
Type: String
Parameter Sets: ByName
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Managed HSM resource Id.

```yaml
Type: String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the subscription.

By default, cmdlets are executed in the subscription that is set in the current context.
If the user specifies another subscription, the current cmdlet is executed in the subscription specified by the user.

Overriding subscriptions only take effect during the lifecycle of the current cmdlet.
It does not change the subscription in the context, and does not affect subsequent cmdlets.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkResourceId
(Not supported) Virtual network rules are not currently supported for Managed HSM.

```yaml
Type: String[]
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
Type: SwitchParameter
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
Type: SwitchParameter
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

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm
### System.String
### System.Nullable`1[[Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsmNetworkRuleDefaultActionEnum, Microsoft.Azure.PowerShell.Cmdlets.KeyVault, Version=6.3.2.0, Culture=neutral, PublicKeyToken=null]]
### System.Nullable`1[[Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsmNetworkRuleBypassEnum, Microsoft.Azure.PowerShell.Cmdlets.KeyVault, Version=6.3.2.0, Culture=neutral, PublicKeyToken=null]]
## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm
## NOTES

## RELATED LINKS
