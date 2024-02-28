---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/Set-AzSecurityPricing
schema: 2.0.0
---

# Set-AzSecurityPricing

## SYNOPSIS

Enables or disables Microsoft Defender plans for a subscription in Microsoft Defender for Cloud.

> [!NOTE]
> For CloudPosture (Defender Cloud Security Posture Management), [the agentless extensions](https://techcommunity.microsoft.com/t5/microsoft-defender-for-cloud/enhanced-cloud-security-value-added-with-defender-cspm-s/ba-p/3880746) will not be enabled when using this command. To enable extensions, please use the Azure Policy definition or scripts in the [Microsoft Defender for Cloud Community Repository](https://github.com/Azure/Microsoft-Defender-for-Cloud/tree/main/Policy/Configure-DCSPM-Extensions).

## SYNTAX

### SubscriptionLevelResource (Default)
```
Set-AzSecurityPricing -Name <String> -PricingTier <String> [-SubPlan <String>] [-Extension <String>]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### InputObject
```
Set-AzSecurityPricing -InputObject <PSSecurityPricing> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION

Enable or disable any of the Azure Defender plans for a subscription.

For details about Azure Defender and the available plans, see [Introduction to Azure Defender](https://learn.microsoft.com/azure/security-center/azure-defender).

## EXAMPLES

### Example 1

```powershell
Set-AzSecurityPricing -Name "AppServices" -PricingTier "Standard"
```

### Example 2

```powershell
Set-AzSecurityPricing -Name "VirtualMachines" -PricingTier "Standard" -SubPlan P2
```

### Example 3

```powershell
Set-AzSecurityPricing -Name "CloudPosture" -PricingTier "Standard" -Extension '[{"name":"SensitiveDataDiscovery","isEnabled":"True","additionalExtensionProperties":null},{"name":"ContainerRegistriesVulnerabilityAssessments","isEnabled":"True","additionalExtensionProperties":null},{"name":"AgentlessDiscoveryForKubernetes","isEnabled":"True","additionalExtensionProperties":null},{"name":"AgentlessVmScanning","isEnabled":"True","additionalExtensionProperties":{"ExclusionTags":"[{\"key\":\"Microsoft\",\"value\":\"Defender\"},{\"key\":\"For\",\"value\":\"Cloud\"}]"}}]'
```

Enables **Azure Defender for servers** for the subscription.

"Standard" refers to the "On" state for an Azure Defender plan as shown in Azure Security Center's pricing and settings area of the Azure portal.

## PARAMETERS

### -DefaultProfile

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

### -Extension
The extensions offered under the plan

```yaml
Type: System.String
Parameter Sets: SubscriptionLevelResource
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject

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

### -SubPlan

Sub Plan.

```yaml
Type: System.String
Parameter Sets: SubscriptionLevelResource
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Security.Models.Pricings.PSSecurityPricing
## OUTPUTS

### Microsoft.Azure.Commands.Security.Models.Pricings.PSSecurityPricing
## NOTES

## RELATED LINKS
