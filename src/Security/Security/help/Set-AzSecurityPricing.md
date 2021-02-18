---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
<<<<<<< HEAD
online version: https://docs.microsoft.com/en-us/powershell/module/az.security/Set-AzSecurityPricing
=======
online version: https://docs.microsoft.com/powershell/module/az.security/Set-AzSecurityPricing
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
schema: 2.0.0
---

# Set-AzSecurityPricing

## SYNOPSIS
<<<<<<< HEAD
Sets the pricing of Azure Security Center tier for a scope.
=======

Enables or disables Azure Defender plans for a subscription in Azure Security Center.
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## SYNTAX

### SubscriptionLevelResource (Default)
<<<<<<< HEAD
```
=======

```powershell
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Set-AzSecurityPricing -Name <String> -PricingTier <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### InputObject
<<<<<<< HEAD
```
=======

```powershell
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Set-AzSecurityPricing -InputObject <PSSecurityPricing> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
<<<<<<< HEAD
Sets the pricing of Azure Security Center tier for a scope.
=======

Enable or disable any of the Azure Defender plans for a subscription.

For details about Azure Defender and the available plans, see [Introduction to Azure Defender](https://docs.microsoft.com/azure/security-center/azure-defender).
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## EXAMPLES

### Example 1
<<<<<<< HEAD
```powershell
PS C:\> Set-AzSecurityPricing -Name "default" -PricingTier "Standard"
Id                                                                                                 Name    PricingTier
--                                                                                                 ----    -----------
/subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/providers/Microsoft.Security/pricings/default default Standard
```

Sets the subscription Azure Security Center pricing tier to "Standard"

### Example 2
```powershell
PS C:\> Set-AzSecurityPricing -Name "myService1" -ResourceGroupName "myService1" -PricingTier "Standard"

Id                                                                                                                     
--                                                                                                                     
/subscriptions/487bb485-b5b0-471e-9c0d-10717612f869/resourceGroups/myService1/providers/Microsoft.Security/pricings/...
```

Sets the "myService1" resource group Azure Security Center pricing tier to "Standard"
=======

```powershell
PS C:\> Set-AzSecurityPricing -Name "virtualmachines" -PricingTier "Standard"
```

Enables **Azure Defender for servers** for the subscription.

"Standard" refers to the "On" state for an Azure Defender plan as shown in Azure Security Center's pricing and settings area of the Azure portal.

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## PARAMETERS

### -DefaultProfile
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Input Object.

```yaml
Type: Microsoft.Azure.Commands.Security.Models.Pricings.PSSecurityPricing
Parameter Sets: InputObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Resource name.

```yaml
Type: System.String
Parameter Sets: SubscriptionLevelResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PricingTier
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Pricing Tier.

```yaml
Type: System.String
Parameter Sets: SubscriptionLevelResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
<<<<<<< HEAD
=======

>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
<<<<<<< HEAD
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).
=======

This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).
>>>>>>> d78b04a5306127f583235b13752c48d4f7d1289a

## INPUTS

### Microsoft.Azure.Commands.Security.Models.Pricings.PSSecurityPricing

## OUTPUTS

### Microsoft.Azure.Commands.Security.Models.Pricings.PSSecurityPricing

## NOTES

## RELATED LINKS
