---
external help file: Az.PaloAltoNetworks-help.xml
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
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzPaloAltoNetworksPrefixListLocalRulestack -LocalRulestackName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentityLocalRulestack
```
Get-AzPaloAltoNetworksPrefixListLocalRulestack -Name <String>
 -LocalRulestackInputObject <IPaloAltoNetworksIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPaloAltoNetworksPrefixListLocalRulestack -InputObject <IPaloAltoNetworksIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
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

### -LocalRulestackInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPaloAltoNetworksIdentity
Parameter Sets: GetViaIdentityLocalRulestack
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
Parameter Sets: List, Get
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
Parameter Sets: Get, GetViaIdentityLocalRulestack
Aliases:

Required: True
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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IPrefixListResource

## NOTES

## RELATED LINKS
