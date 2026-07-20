---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/remove-azkeyvaultmanagedhsmnetworkrule
schema: 2.0.0
---

# Remove-AzKeyVaultManagedHsmNetworkRule

## SYNOPSIS
Remove one or more IP network rules from a Managed HSM firewall configuration.

## SYNTAX

### ByName (Default)
```
Remove-AzKeyVaultManagedHsmNetworkRule [-Name] <String> [[-ResourceGroupName] <String>]
 [-IpAddressRange <String[]>] [-VirtualNetworkResourceId <String[]>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### ByInputObject
```
Remove-AzKeyVaultManagedHsmNetworkRule [-InputObject] <PSManagedHsm> [-IpAddressRange <String[]>]
 [-VirtualNetworkResourceId <String[]>] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-SubscriptionId <String>] [<CommonParameters>]
```

### ByResourceId
```
Remove-AzKeyVaultManagedHsmNetworkRule [-ResourceId] <String> [-IpAddressRange <String[]>]
 [-VirtualNetworkResourceId <String[]>] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Removes the specified CIDR ranges from the Managed HSM IP rule list. Ranges that are not currently
present are ignored (no error). The firewall remains in its prior DefaultAction state; removing all
IP rules does not automatically change `DefaultAction`.

To subsequently open the firewall, run `Update-AzKeyVaultManagedHsmNetworkRuleSet -DefaultAction Allow`
AFTER ensuring there are no remaining IP rules.

## EXAMPLES

### Example 1: Remove a single IP range
```powershell
Remove-AzKeyVaultManagedHsmNetworkRule -Name myHsm -ResourceGroupName myRg -IpAddressRange 203.0.113.0/24
```

```output
(No output but the IP "203.0.113.0/24" is removed from the list of strings)
```

Removes one IP rule if it exists.

### Example 2: Remove multiple ranges and return the updated object
```powershell
Remove-AzKeyVaultManagedHsmNetworkRule -Name myHsm -ResourceGroupName myRg -IpAddressRange 203.0.113.0/24,198.51.100.10/32 -PassThru
```

```output
(The two IPs are removed from the list in IPRules)

Name           Resource Group Name Location SKU        ProvisioningState Security Domain ActivationStatus
----           ------------------- -------- ---        ----------------- --------------------------------
mhsm1814428918 kv-mhsm-rg          eastus   StandardB1 Succeeded         NotActivated


$hsm.OriginalManagedHsm.Properties.NetworkAcls
Bypass              : AzureServices
DefaultAction       : Deny
IPRules             : {100.0.100.0/24}
ServiceTags         : {}
VirtualNetworkRules : {}
```

Removes both ranges (ignoring any that are missing) and outputs the Managed HSM.

### Example 3: Remove the last rule then allow all traffic
```powershell
Remove-AzKeyVaultManagedHsmNetworkRule -Name myHsm -ResourceGroupName myRg -IpAddressRange 198.51.100.0/24
Update-AzKeyVaultManagedHsmNetworkRuleSet -Name myHsm -ResourceGroupName myRg -DefaultAction Allow
```

```output
(No Output but "198.51.100.0/24" was removed from the list)


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

First clears the final IP rule; then switches the firewall to Allow.

## PARAMETERS

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
One or more CIDR ranges to remove. Must match existing entries exactly (case-insensitive). Required.

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
## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm
## NOTES

## RELATED LINKS
