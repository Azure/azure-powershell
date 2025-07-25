---
external help file: Az.ConnectedMachine-help.xml
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/get-azconnectednetworksecurityperimeterconfiguration
schema: 2.0.0
---

# Get-AzConnectedNetworkSecurityPerimeterConfiguration

## SYNOPSIS
Gets the network security perimeter configuration for a private link scope.

## SYNTAX

### List (Default)
```
Get-AzConnectedNetworkSecurityPerimeterConfiguration -ResourceGroupName <String> -ScopeName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzConnectedNetworkSecurityPerimeterConfiguration -ResourceGroupName <String> -ScopeName <String>
 -PerimeterName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the network security perimeter configuration for a private link scope.

## EXAMPLES

### Example 1: Get network security perimeter of a private link scope
```powershell
Get-AzConnectedNetworkSecurityPerimeterConfiguration -ResourceGroupName $env.ResourceGroupNameNSP -ScopeName $env.PrivateLinkScopeNameNSP
```

```output
Id                               : /subscriptions/********-****-****-****-**********/resourceGroups/adrie
                                   lk_test/providers/Microsoft.HybridCompute/privateLinkScopes/adrielScope/
                                   networkSecurityPerimeterConfigurations/********-****-****-****-**********
                                   .adrielScope-********-****-****-****-**********
Name                             : ********-****-****-****-**********
                                   .adrielScope-********-****-****-****-**********
NetworkSecurityPerimeterGuid     : ********-****-****-****-**********
NetworkSecurityPerimeterId       : /subscriptions********-****-****-****-**********/resourceGroups/adrie
                                   lk_test/providers/Microsoft.Network/networkSecurityPerimeters/adrielNsp
NetworkSecurityPerimeterLocation : centraluseuap
ProfileAccessRule                : {}
ProfileAccessRulesVersion        : 0
ProfileDiagnosticSettingsVersion : 0
ProfileEnabledLogCategory        : {NspPublicInboundPerimeterRulesAllowed,
                                   NspPublicInboundPerimeterRulesDenied,
                                   NspPublicOutboundPerimeterRulesAllowed,
                                   NspPublicOutboundPerimeterRulesDenied…}
ProfileName                      : defaultProfile
ProvisioningIssue                : {}
ProvisioningState                : Succeeded
ResourceAssociationAccessMode    : Learning
ResourceAssociationName          : adrielScope-********-****-****-****-**********
ResourceGroupName                : adrielk_test
Type                             : Microsoft.HybridCompute/privateLinkScopes/networkSecurityPerimeterConfig
                                   urations
```

Get network security perimeter of a private link scope

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

### -PerimeterName
The name, in the format {perimeterGuid}.{associationName}, of the Network Security Perimeter resource.

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScopeName
The name of the Azure Arc PrivateLinkScope resource.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.INetworkSecurityPerimeterConfiguration

## NOTES

## RELATED LINKS
