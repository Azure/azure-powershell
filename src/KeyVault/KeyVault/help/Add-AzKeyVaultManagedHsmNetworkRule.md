---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/add-azkeyvaultmanagedhsmnetworkrule
schema: 2.0.0
---

# Add-AzKeyVaultManagedHsmNetworkRule

## SYNOPSIS
Add one or more IP network rules to a Managed HSM that already has its firewall (DefaultAction Deny) enabled.

## SYNTAX

### ByName (Default)
```
Add-AzKeyVaultManagedHsmNetworkRule [-Name] <String> [[-ResourceGroupName] <String>]
 [-IpAddressRange <String[]>] [-VirtualNetworkResourceId <String[]>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### ByInputObject
```
Add-AzKeyVaultManagedHsmNetworkRule [-InputObject] <PSManagedHsm> [-IpAddressRange <String[]>]
 [-VirtualNetworkResourceId <String[]>] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-SubscriptionId <String>] [<CommonParameters>]
```

### ByResourceId
```
Add-AzKeyVaultManagedHsmNetworkRule [-ResourceId] <String> [-IpAddressRange <String[]>]
 [-VirtualNetworkResourceId <String[]>] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Adds one or more CIDR IP address ranges to the Managed HSM network ACL list. This cmdlet performs a
merge (it keeps existing IP rules and appends the new ones, ignoring duplicates case-insensitively).
Virtual network rules are not currently supported for Managed HSM; any attempt to supply
`-VirtualNetworkResourceId` results in an error. The Managed HSM service requires `DefaultAction` to
be `Deny` when IP rules are present; if the current firewall is open (`Allow`) this cmdlet throws
and instructs you to first run `Update-AzKeyVaultManagedHsmNetworkRuleSet -DefaultAction Deny`.

Typical workflow:
1. Enable firewall by setting DefaultAction Deny (optionally adding the first IP) using
	`New-AzKeyVaultManagedHsm` with `-NetworkRuleSet` or `Update-AzKeyVaultManagedHsmNetworkRuleSet`.
2. Add additional IP ranges with this cmdlet.

## EXAMPLES

### Example 1: Add a single IP range (assuming -DefaultAction is set to Deny)
```powershell
Add-AzKeyVaultManagedHsmNetworkRule -Name $myHsm -ResourceGroupName $myRg -IpAddressRange 203.0.113.0/24
```

```output
(No Output but the IPRules are updated)
```

Adds one CIDR range; existing rules are preserved.

### Example 2: Add multiple ranges and return the updated object (assuming -DefaultAction is set to Deny)
```powershell
Add-AzKeyVaultManagedHsmNetworkRule -Name $myHsm -ResourceGroupName $myRg -IpAddressRange 203.0.113.0/24,198.51.100.10/32 -PassThru
```

```output
Name           Resource Group Name Location SKU        ProvisioningState Security Domain ActivationStatus
----           ------------------- -------- ---        ----------------- --------------------------------
mhsm1814428918 kv-mhsm-rg          eastus   StandardB1 Succeeded         NotActivated


$hsm.OriginalManagedHsm.Properties.NetworkAcls
Bypass              : AzureServices
DefaultAction       : Deny
IPRules             : {203.0.113.0/24, 198.51.100.10/32}
ServiceTags         : {}
VirtualNetworkRules : {}
```

Appends two ranges then outputs the Managed HSM object because `-PassThru` is specified.

### Example 3: Pipe a Managed HSM object
```powershell
Get-AzKeyVaultManagedHsm -Name $myHsm -ResourceGroupName $myRg | Add-AzKeyVaultManagedHsmNetworkRule -IpAddressRange 198.51.100.0/25
```

```output
(No Output but the IPRules are updated)
```

Uses the pipeline form (`-InputObject`).

### Example 4: Attempt when DefaultAction is Allow (will fail)
```powershell
# First open firewall (for illustration – not recommended long term)
Update-AzKeyVaultManagedHsmNetworkRuleSet -Name $myHsm -ResourceGroupName $myRg -DefaultAction Allow

# This next command will throw until you set DefaultAction back to Deny
Add-AzKeyVaultManagedHsmNetworkRule -Name myHsm -ResourceGroupName myRg -IpAddressRange 192.0.2.0/24
```

```output
Name           Resource Group Name Location SKU        ProvisioningState Security Domain ActivationStatus
----           ------------------- -------- ---        ----------------- --------------------------------
mhsm1814428918 kv-mhsm-rg          eastus   StandardB1 Succeeded         NotActivated

$h.OriginalManagedHsm.Properties.NetworkAcls
Bypass              : AzureServices
DefaultAction       : Allow
IPRules             : {}
ServiceTags         : {}
VirtualNetworkRules : {}


Add-AzKeyVaultManagedHsmNetworkRule: Cannot add IP network rules while DefaultAction is Allow. Run Update-AzKeyVaultManagedHsmNetworkRuleSet -Name <name> -DefaultAction Deny first, then add IP rules.
```

Demonstrates the validation that prevents adding IP rules while DefaultAction is Allow.

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
One or more CIDR IP ranges to add (e.g. `198.51.100.0/24`). Duplicates (case-insensitive match on the
`Value` sent to the service) are ignored. Private RFC1918 ranges may be rejected by the service.

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
Name of the managed HSM.

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
Resource group name.

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
