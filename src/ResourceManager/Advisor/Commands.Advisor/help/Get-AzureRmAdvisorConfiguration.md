---
external help file: Microsoft.Azure.Commands.Advisor.dll-Help.xml
Module Name: Az.Advisor
online version:
schema: 2.0.0
---

# Get-AzureRmAdvisorConfiguration

## SYNOPSIS
Get the Azure Advisor configurations for the given subscription or resource group.

## SYNTAX

```
Get-AzureRmAdvisorConfiguration [-ResourceGroupName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Configuration associated with a subscription are of two typoes,

Subscription level configuration: There can be only one configration for this type for each subscription, lowCpuThreshold and exclude properties are taken into effect for configuration.
ResourceGroup level configuration: There can be only one configration for each ResourceGroup in a subscription, only exclude property is taken into effect for configuration.

## EXAMPLES

### Example 1
```powershell
PS C:\>$data = Get-AzureRmAdvisorConfiguration
Id         : /subscriptions/658c8950-e79d-4704-a903-1df66ba90258/providers/Microsoft.Advisor/configurations/658c8950-e79d-4704-a903-1df66ba90258
Name       : 658c8950-e79d-4704-a903-1df66ba90258
Properties : Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationProperties
Type       : Microsoft.Advisor/Configurations

PS C:\>$data[0].Properties
AdditionalProperties :
Exclude              : False
LowCpuThreshold      : 20

```
Retrieves a list of Azure Advisor Configration.
## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group name for the configuration

```yaml
Type: String
Parameter Sets: (All)
Aliases: Rg

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData

## NOTES

## RELATED LINKS
