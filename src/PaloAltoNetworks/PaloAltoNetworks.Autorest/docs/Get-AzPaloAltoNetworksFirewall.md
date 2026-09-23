---
external help file:
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/get-azpaloaltonetworksfirewall
schema: 2.0.0
---

# Get-AzPaloAltoNetworksFirewall

## SYNOPSIS
Get a FirewallResource

## SYNTAX

### List (Default)
```
Get-AzPaloAltoNetworksFirewall [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPaloAltoNetworksFirewall -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPaloAltoNetworksFirewall -InputObject <IPaloAltoNetworksIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List1
```
Get-AzPaloAltoNetworksFirewall -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a FirewallResource

## EXAMPLES

### Example 1: List FirewallResource by subscription.
```powershell
Get-AzPaloAltoNetworksFirewall
```

```output
Location           Name           MarketplaceDetailPublisherId ProvisioningState ResourceGroupName
--------           ----           ---------------------------- ----------------- -----------------
australiasoutheast azps-firewall  paloaltonetworks             Succeeded         azps_test_group_pan
```

List FirewallResource by subscription.

### Example 2: Get a FirewallResource by ResourceGroupName.
```powershell
Get-AzPaloAltoNetworksFirewall -ResourceGroupName azps_test_group_pan
```

```output
Location           Name           MarketplaceDetailPublisherId ProvisioningState ResourceGroupName
--------           ----           ---------------------------- ----------------- -----------------
australiasoutheast azps-firewall  paloaltonetworks             Succeeded         azps_test_group_pan
```

Get a FirewallResource by ResourceGroupName.

### Example 3: Get a FirewallResource by name.
```powershell
Get-AzPaloAltoNetworksFirewall -ResourceGroupName azps_test_group_pan -Name azps-firewall
```

```output
Location           Name           MarketplaceDetailPublisherId ProvisioningState ResourceGroupName
--------           ----           ---------------------------- ----------------- -----------------
australiasoutheast azps-firewall  paloaltonetworks             Succeeded         azps_test_group_pan
```

Get a FirewallResource by name.

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

### -Name
Firewall resource name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: FirewallName

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
Parameter Sets: Get, List1
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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IFirewallResource

## NOTES

## RELATED LINKS

