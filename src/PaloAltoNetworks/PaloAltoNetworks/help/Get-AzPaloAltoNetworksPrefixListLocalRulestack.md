---
external help file:
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/get-azpaloaltonetworksprefixlistlocalrulestack
schema: 2.0.0
---

# Get-AzPaloAltoNetworksPrefixListLocalRulestack

## SYNOPSIS
Get a PrefixListResource

## SYNTAX

### List (Default)
```
Get-AzPaloAltoNetworksPrefixListLocalRulestack -LocalRulestackName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPaloAltoNetworksPrefixListLocalRulestack -LocalRulestackName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPaloAltoNetworksPrefixListLocalRulestack -InputObject <IPaloAltoNetworksIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a PrefixListResource

## EXAMPLES

### Example 1: List PrefixListResource by LocalRulestackName.
```powershell
Get-AzPaloAltoNetworksPrefixListLocalRulestack -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr
```

```output
Name         ProvisioningState ResourceGroupName
----         ----------------- -----------------
azps-panpflr Succeeded         azps_test_group_pan
```

List PrefixListResource by LocalRulestackName.

### Example 2: Get a PrefixListResource by name.
```powershell
Get-AzPaloAltoNetworksPrefixListLocalRulestack -ResourceGroupName azps_test_group_pan -LocalRulestackName azps-panlr -Name azps-panpflr
```

```output
Name         ProvisioningState ResourceGroupName
----         ----------------- -----------------
azps-panpflr Succeeded         azps_test_group_pan
```

Get a PrefixListResource by name.

## PARAMETERS

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocalRulestackName
LocalRulestack resource name

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Local Rule priority

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
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
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.Api20220829.IPrefixListResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IPaloAltoNetworksIdentity>`: Identity Parameter
  - `[FirewallName <String>]`: Firewall resource name
  - `[GlobalRulestackName <String>]`: GlobalRulestack resource name
  - `[Id <String>]`: Resource identity path
  - `[LocalRulestackName <String>]`: LocalRulestack resource name
  - `[Name <String>]`: certificate name
  - `[Priority <String>]`: Post Rule priority
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

