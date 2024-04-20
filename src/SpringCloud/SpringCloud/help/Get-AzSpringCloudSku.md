---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.springcloud/get-azspringcloudsku
schema: 2.0.0
---

# Get-AzSpringCloudSku

## SYNOPSIS
Lists all of the available skus of the Microsoft.AppPlatform provider.

## SYNTAX

```
Get-AzSpringCloudSku [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Lists all of the available skus of the Microsoft.AppPlatform provider.

## EXAMPLES

### Example 1: Lists all of the available skus of the Microsoft.AppPlatform provider
```powershell
Get-AzSpringCloudSku
```

```output
Location             Name ResourceType            Tier
--------             ---- ------------            ----
{australiaeast}      B0   Spring                  Basic
{brazilsouth}        B0   Spring                  Basic
{canadacentral}      B0   Spring                  Basic
{centralindia}       B0   Spring                  Basic
{centralus}          B0   Spring                  Basic
{eastasia}           B0   Spring                  Basic
{eastasia}           B0   Spring                  Basic
{eastus}             B0   Spring                  Basic
{eastus}             B0   Spring                  Basic
{eastus2}            B0   Spring                  Basic
{eastus2euap}        B0   Spring                  Basic
{francecentral}      B0   Spring                  Basic
{germanywestcentral} B0   Spring                  Basic
{japaneast}          B0   Spring                  Basic
{koreacentral}       B0   Spring                  Basic
{northcentralus}     B0   Spring                  Basic
{northeurope}        B0   Spring                  Basic
{southafricanorth}   B0   Spring                  Basic
{southcentralus}     B0   Spring                  Basic
{southeastasia}      B0   Spring                  Basic
{switzerlandnorth}   B0   Spring                  Basic
{switzerlandwest}    B0   Spring                  Basic
{uaenorth}           B0   Spring                  Basic
{uksouth}            B0   Spring                  Basic
{westcentralus}      B0   Spring                  Basic
{westeurope}         B0   Spring                  Basic
{westus}             B0   Spring                  Basic
{westus2}            B0   Spring                  Basic
{westus3}            B0   Spring                  Basic
{australiaeast}      E0   Spring                  Enterprise
{brazilsouth}        E0   Spring                  Enterprise
{canadacentral}      E0   Spring                  Enterprise
{centralindia}       E0   Spring                  Enterprise
{centralus}          E0   Spring                  Enterprise
{eastasia}           E0   Spring                  Enterprise
{eastus}             E0   Spring                  Enterprise
{eastus2}            E0   Spring                  Enterprise
{eastus2euap}        E0   Spring                  Enterprise
{francecentral}      E0   Spring                  Enterprise
{germanywestcentral} E0   Spring                  Enterprise
{koreacentral}       E0   Spring                  Enterprise
{northcentralus}     E0   Spring                  Enterprise
{northeurope}        E0   Spring                  Enterprise
{southafricanorth}   E0   Spring                  Enterprise
{southcentralus}     E0   Spring                  Enterprise
{southeastasia}      E0   Spring                  Enterprise
{switzerlandnorth}   E0   Spring                  Enterprise
{switzerlandwest}    E0   Spring                  Enterprise
{uaenorth}           E0   Spring                  Enterprise
{uksouth}            E0   Spring                  Enterprise
{westeurope}         E0   Spring                  Enterprise
{westus}             E0   Spring                  Enterprise
{westus2}            E0   Spring                  Enterprise
{westus3}            E0   Spring                  Enterprise
{australiaeast}      S0   Spring                  Standard
{brazilsouth}        S0   Spring                  Standard
{canadacentral}      S0   Spring                  Standard
{centralindia}       S0   Spring                  Standard
{centralus}          S0   Spring                  Standard
{eastasia}           S0   Spring                  Standard
{eastasia}           S0   Spring                  Standard
{eastus}             S0   Spring                  Standard
{eastus}             S0   Spring                  Standard
{eastus2}            S0   Spring                  Standard
{eastus2euap}        S0   Spring                  Standard
{francecentral}      S0   Spring                  Standard
{germanywestcentral} S0   Spring                  Standard
{japaneast}          S0   Spring                  Standard
{koreacentral}       S0   Spring                  Standard
{northcentralus}     S0   Spring                  Standard
{northeurope}        S0   Spring                  Standard
{southafricanorth}   S0   Spring                  Standard
{southcentralus}     S0   Spring                  Standard
{southeastasia}      S0   Spring                  Standard
{switzerlandnorth}   S0   Spring                  Standard
{switzerlandwest}    S0   Spring                  Standard
{uaenorth}           S0   Spring                  Standard
{uksouth}            S0   Spring                  Standard
{westcentralus}      S0   Spring                  Standard
{westeurope}         S0   Spring                  Standard
{westus}             S0   Spring                  Standard
{westus2}            S0   Spring                  Standard
{westus3}            S0   Spring                  Standard
{australiaeast}      B0   Spring/apps/deployments Basic
{brazilsouth}        B0   Spring/apps/deployments Basic
{canadacentral}      B0   Spring/apps/deployments Basic
{centralindia}       B0   Spring/apps/deployments Basic
{centralus}          B0   Spring/apps/deployments Basic
{eastasia}           B0   Spring/apps/deployments Basic
{eastasia}           B0   Spring/apps/deployments Basic
{eastus}             B0   Spring/apps/deployments Basic
{eastus}             B0   Spring/apps/deployments Basic
{eastus2}            B0   Spring/apps/deployments Basic
{eastus2euap}        B0   Spring/apps/deployments Basic
{francecentral}      B0   Spring/apps/deployments Basic
{germanywestcentral} B0   Spring/apps/deployments Basic
{japaneast}          B0   Spring/apps/deployments Basic
{koreacentral}       B0   Spring/apps/deployments Basic
{northcentralus}     B0   Spring/apps/deployments Basic
{northeurope}        B0   Spring/apps/deployments Basic
{southafricanorth}   B0   Spring/apps/deployments Basic
{southcentralus}     B0   Spring/apps/deployments Basic
{southeastasia}      B0   Spring/apps/deployments Basic
{switzerlandnorth}   B0   Spring/apps/deployments Basic
{switzerlandwest}    B0   Spring/apps/deployments Basic
{uaenorth}           B0   Spring/apps/deployments Basic
{uksouth}            B0   Spring/apps/deployments Basic
{westcentralus}      B0   Spring/apps/deployments Basic
{westeurope}         B0   Spring/apps/deployments Basic
{westus}             B0   Spring/apps/deployments Basic
{westus2}            B0   Spring/apps/deployments Basic
{westus3}            B0   Spring/apps/deployments Basic
{australiaeast}      E0   Spring/apps/deployments Enterprise
{brazilsouth}        E0   Spring/apps/deployments Enterprise
{canadacentral}      E0   Spring/apps/deployments Enterprise
{centralindia}       E0   Spring/apps/deployments Enterprise
{centralus}          E0   Spring/apps/deployments Enterprise
{eastasia}           E0   Spring/apps/deployments Enterprise
{eastus}             E0   Spring/apps/deployments Enterprise
{eastus2}            E0   Spring/apps/deployments Enterprise
{eastus2euap}        E0   Spring/apps/deployments Enterprise
{francecentral}      E0   Spring/apps/deployments Enterprise
{germanywestcentral} E0   Spring/apps/deployments Enterprise
{koreacentral}       E0   Spring/apps/deployments Enterprise
{northcentralus}     E0   Spring/apps/deployments Enterprise
{northeurope}        E0   Spring/apps/deployments Enterprise
{southafricanorth}   E0   Spring/apps/deployments Enterprise
{southcentralus}     E0   Spring/apps/deployments Enterprise
{southeastasia}      E0   Spring/apps/deployments Enterprise
{switzerlandnorth}   E0   Spring/apps/deployments Enterprise
{switzerlandwest}    E0   Spring/apps/deployments Enterprise
{uaenorth}           E0   Spring/apps/deployments Enterprise
{uksouth}            E0   Spring/apps/deployments Enterprise
{westeurope}         E0   Spring/apps/deployments Enterprise
{westus}             E0   Spring/apps/deployments Enterprise
{westus2}            E0   Spring/apps/deployments Enterprise
{westus3}            E0   Spring/apps/deployments Enterprise
{australiaeast}      S0   Spring/apps/deployments Standard
{brazilsouth}        S0   Spring/apps/deployments Standard
{canadacentral}      S0   Spring/apps/deployments Standard
{centralindia}       S0   Spring/apps/deployments Standard
{centralus}          S0   Spring/apps/deployments Standard
{eastasia}           S0   Spring/apps/deployments Standard
{eastasia}           S0   Spring/apps/deployments Standard
{eastus}             S0   Spring/apps/deployments Standard
{eastus}             S0   Spring/apps/deployments Standard
{eastus2}            S0   Spring/apps/deployments Standard
{eastus2euap}        S0   Spring/apps/deployments Standard
{francecentral}      S0   Spring/apps/deployments Standard
{germanywestcentral} S0   Spring/apps/deployments Standard
{japaneast}          S0   Spring/apps/deployments Standard
{koreacentral}       S0   Spring/apps/deployments Standard
{northcentralus}     S0   Spring/apps/deployments Standard
{northeurope}        S0   Spring/apps/deployments Standard
{southafricanorth}   S0   Spring/apps/deployments Standard
{southcentralus}     S0   Spring/apps/deployments Standard
{southeastasia}      S0   Spring/apps/deployments Standard
{switzerlandnorth}   S0   Spring/apps/deployments Standard
{switzerlandwest}    S0   Spring/apps/deployments Standard
{uaenorth}           S0   Spring/apps/deployments Standard
{uksouth}            S0   Spring/apps/deployments Standard
{westcentralus}      S0   Spring/apps/deployments Standard
{westeurope}         S0   Spring/apps/deployments Standard
{westus}             S0   Spring/apps/deployments Standard
{westus2}            S0   Spring/apps/deployments Standard
{westus3}            S0   Spring/apps/deployments Standard
```

Lists all of the available skus of the Microsoft.AppPlatform provider.

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

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.IResourceSku

## NOTES

## RELATED LINKS

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

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
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

## OUTPUTS

## NOTES

## RELATED LINKS
