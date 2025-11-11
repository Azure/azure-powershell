---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/new-azkeyvaultmanagedhsmnetworkrulesetobject
schema: 2.0.0
---

# New-AzKeyVaultManagedHsmNetworkRuleSetObject

## SYNOPSIS
Create an in‑memory Managed HSM network rule set object for use with New/Update cmdlets.

## SYNTAX

```
New-AzKeyVaultManagedHsmNetworkRuleSetObject [-DefaultAction <PSManagedHsmNetworkRuleDefaultActionEnum>]
 [-Bypass <PSManagedHsmNetworkRuleBypassEnum>] [-IpAddressRange <String[]>]
 [-VirtualNetworkResourceId <String[]>] [-DefaultProfile <IAzureContextContainer>]
 [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Builds a `PSManagedHsmNetworkRuleSet` object that can be passed to `New-AzKeyVaultManagedHsm` via the
`-NetworkRuleSet` parameter to configure the firewall at creation time. You can also supply the object
to update cmdlets (or inspect it before applying). Virtual network rules are presently not supported
for Managed HSM; supplying `-VirtualNetworkResourceId` has no effect and may be ignored in future.

If you specify any IP ranges you should set `-DefaultAction Deny`; the Managed HSM service will reject
an Allow + IP combination.

## EXAMPLES

### Example 1: Create a rule set object with Deny and one IP
```powershell
$ruleSet = New-AzKeyVaultManagedHsmNetworkRuleSetObject -DefaultAction Deny -IpAddressRange 203.0.113.0/24
New-AzKeyVaultManagedHsm -Name myHsm -ResourceGroupName myRg -Location eastus -Administrator $adminIds -SoftDeleteRetentionInDays 7 -NetworkRuleSet $ruleSet
```

```output
$ruleset

DefaultAction        Bypass IpAddressRanges  VirtualNetworkResourceIds
-------------        ------ ---------------  -------------------------
         Deny AzureServices {203.0.113.0/24}


Name           Resource Group Name Location SKU        ProvisioningState Security Domain ActivationStatus
----           ------------------- -------- ---        ----------------- --------------------------------
mhsm1814428918 kv-mhsm-rg          eastus   StandardB1 Succeeded         NotActivated


$hsm.OriginalManagedHsm.Properties.NetworkAcls
Bypass              : AzureServices
DefaultAction       : Deny
IPRules             : {203.0.113.0/24}
ServiceTags         : {}
VirtualNetworkRules : {}
```

Creates a Managed HSM with firewall enabled and one allowed CIDR.

### Example 2: Create an allow-all rule set (no IP rules)
```powershell
$open = New-AzKeyVaultManagedHsmNetworkRuleSetObject -DefaultAction Allow
New-AzKeyVaultManagedHsm -Name myOpenHsm -ResourceGroupName myRg -Location eastus -Administrator $adminIds -SoftDeleteRetentionInDays 7 -NetworkRuleSet $open
```

```output
DefaultAction        Bypass IpAddressRanges VirtualNetworkResourceIds
-------------        ------ --------------- -------------------------
        Allow AzureServices



Name           Resource Group Name Location SKU        ProvisioningState Security Domain ActivationStatus
----           ------------------- -------- ---        ----------------- --------------------------------
mhsm1814428918 kv-mhsm-rg          eastus   StandardB1 Succeeded         NotActivated


$hsm.OriginalManagedHsm.Properties.NetworkAcls
Bypass              : AzureServices
DefaultAction       : Allow
IPRules             : {}
ServiceTags         : {}
VirtualNetworkRules : {}
```

Creates an HSM with firewall open to public networks (subject to other settings like Private Endpoints or PublicNetworkAccess).

### Example 3: Use AzureServices bypass while restricting IPs
```powershell
$restricted = New-AzKeyVaultManagedHsmNetworkRuleSetObject -DefaultAction Deny -Bypass AzureServices -IpAddressRange 198.51.100.0/25,203.0.113.10/32
New-AzKeyVaultManagedHsm -Name mySecureHsm -ResourceGroupName myRg -Location eastus -Administrator $adminIds -SoftDeleteRetentionInDays 7 -NetworkRuleSet $restricted
```

```output
DefaultAction        Bypass IpAddressRanges                    VirtualNetworkResourceIds
-------------        ------ ---------------                    -------------------------
         Deny AzureServices {198.51.100.0/25, 203.0.113.10/32}



Name           Resource Group Name Location SKU        ProvisioningState Security Domain ActivationStatus
----           ------------------- -------- ---        ----------------- --------------------------------
mhsm1814428918 kv-mhsm-rg          eastus   StandardB1 Succeeded         NotActivated


$hsm.OriginalManagedHsm.Properties.NetworkAcls
Bypass              : AzureServices
DefaultAction       : Deny
IPRules             : {198.51.100.0/25, 203.0.113.10/32}
ServiceTags         : {}
VirtualNetworkRules : {}
```

Allows only the listed IPs plus trusted Azure services.

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
Accept pipeline input: False
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
Accept pipeline input: False
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

### -IpAddressRange
Optional array of CIDR IP ranges. When provided you should also set `-DefaultAction Deny`.

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
Specifies allowed virtual network resource identifier of network rule.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsmNetworkRuleSet
## NOTES

## RELATED LINKS
