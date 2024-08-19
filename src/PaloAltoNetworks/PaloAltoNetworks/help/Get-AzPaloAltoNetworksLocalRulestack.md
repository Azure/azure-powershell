---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/az.paloaltonetworks/get-azpaloaltonetworkslocalrulestack
schema: 2.0.0
---

# Get-AzPaloAltoNetworksLocalRulestack

## SYNOPSIS
Get a LocalRulestackResource

## SYNTAX

### List (Default)
```
Get-AzPaloAltoNetworksLocalRulestack [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPaloAltoNetworksLocalRulestack -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzPaloAltoNetworksLocalRulestack -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPaloAltoNetworksLocalRulestack -InputObject <IPaloAltoNetworksIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a LocalRulestackResource

## EXAMPLES

### Example 1: List LocalRulestackResource by subscription.
```powershell
Get-AzPaloAltoNetworksLocalRulestack
```

```output
Name       Location ProvisioningState ResourceGroupName
----       -------- ----------------- -----------------
azps-panlr eastus   Succeeded         azps_test_group_pan
```

List LocalRulestackResource by subscription.

### Example 2: List LocalRulestackResource by resource group.
```powershell
Get-AzPaloAltoNetworksLocalRulestack -ResourceGroupName azps_test_group_pan
```

```output
Name       Location ProvisioningState ResourceGroupName
----       -------- ----------------- -----------------
azps-panlr eastus   Succeeded         azps_test_group_pan
```

List LocalRulestackResource by resource group.

### Example 3: Get a LocalRulestackResource by name.
```powershell
Get-AzPaloAltoNetworksLocalRulestack -ResourceGroupName azps_test_group_pan -Name azps-panlr
```

```output
Name       Location ProvisioningState ResourceGroupName
----       -------- ----------------- -----------------
azps-panlr eastus   Succeeded         azps_test_group_pan
```

Get a LocalRulestackResource by name.

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
LocalRulestack resource name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: LocalRulestackName

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
Parameter Sets: List, Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.ILocalRulestackResource

## NOTES

## RELATED LINKS
