---
external help file: Az.NetworkSecurityPerimeter.psm1-help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-aznetworksecurityperimeterservicetag
schema: 2.0.0
---

# Get-AzNetworkSecurityPerimeterServiceTag

## SYNOPSIS
Gets the list of service tags supported by NSP.
These service tags can be used to list access rules in NSP.

## SYNTAX

```
Get-AzNetworkSecurityPerimeterServiceTag -Location <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the list of service tags supported by NSP.
These service tags can be used to list access rules in NSP.

## EXAMPLES

### Example 1: List NetworkSecurityPerimeter ServiceTags
```powershell
Get-AzNetworkSecurityPerimeterServiceTag -Location eastus2euap
```

```output
ServiceTags
----
ActionGroup
ApiManagement
ApiManagement.AustraliaCentral
ApiManagement.AustraliaCentral2
```

List NetworkSecurityPerimeter ServiceTags

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

### -Location
The location of network security perimeter.

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
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkSecurityPerimeter.Models.INspServiceTagsResource

## NOTES

## RELATED LINKS
