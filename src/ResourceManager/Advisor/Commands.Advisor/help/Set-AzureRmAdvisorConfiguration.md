---
external help file: Microsoft.Azure.Commands.Advisor.dll-Help.xml
Module Name: AzureRM.Advisor
online version:
schema: 2.0.0
---

# Set-AzureRmAdvisorConfiguration

## SYNOPSIS
Updates or creates the Aure Advisor Configration.

## SYNTAX

### LowCpuAndExcludeParameterSet (Default)
```
Set-AzureRmAdvisorConfiguration [-Exclude] -LowCpuThreshold <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### RgAndExcludeParameterSet
```
Set-AzureRmAdvisorConfiguration [-Exclude] -ResourceGroupName <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### InputObjectLowCpuExcludeParameterSet
```
Set-AzureRmAdvisorConfiguration [-Exclude] -LowCpuThreshold <String>
 -InputObject <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### InputObjectRgExcludeParameterSet
```
Set-AzureRmAdvisorConfiguration [-Exclude] [-ResourceGroupName <String>]
 -InputObject <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Used to update the configuration of the advisors. Two types of configration are present Subscription level configuration and ResourceGroup level configuration. 

Subscription level configuration: There can be only one configration for this type, lowCpuThreshold and exclude properties can be updated using cmdlet.
ResourceGroup level configuration: There can be only one configration for each ResourceGroup, only exclude property could be updated using cmdlet.

## EXAMPLES

 Example 1
```powershell
PS C:\> Set-AzureRMAdvisorConfiguration -LowCpuThreshold 10
Id         : /subscriptions/{user_subscription}/resourceGroups/resourceGroupName1/providers/Microsoft.Advisor/configurations/{user_subscription}
Name       : {user_subscription}
Properties : additionalProperties : null
             exclude :  False
             lowCpuThreshold : 10

Type       : Microsoft.Advisor/Configurations
```

Updates the configuration(lowCpuThreshold) for subscription level configration.

### Example 2
```powershell
PS C:\> Set-AzureRMAdvisorConfiguration -LowCpuThreshold 15 -E 
Id         : /subscriptions/{user_subscription}/resourceGroups/resourceGroupName1/providers/Microsoft.Advisor/configurations/{user_subscription}
Name       : {user_subscription}
Properties : additionalProperties : null
             exclude :  True
             lowCpuThreshold : 15

Type       : Microsoft.Advisor/Configurations
```

Updates the configuration(lowCpuThreshold, exclude) for subscription level configration and excludes from the recommendation generation.

### Example 3
```powershell
PS C:\> Set-AzureRMAdvisorConfiguration -ResourceGroupName resourceGroupName1 -E

Id         : /subscriptions/{user_subscription}/resourceGroups/resourceGroupName1/providers/Microsoft.Advisor/configurations/{user_subscription}-resourceGroupName1
Name       : {user_subscription}-resourceGroupName1
Properties : additionalProperties : null
             exclude :  True
             lowCpuThreshold : null

Type       : Microsoft.Advisor/Configurations
```

Updates the configuration(exclude) for resourceGroupName1 to be excluded in the recommendation generation.

### Example 5
```powershell
PS C:\> Set-AzureRMAdvisorConfiguration -ResourceGroupName resourceGroupName1 -Exclude true

Id         : /subscriptions/{user_subscription}/resourceGroups/resourceGroupName1/providers/Microsoft.Advisor/configurations/{user_subscription}-resourceGroupName1
Name       : {user_subscription}-resourceGroupName1
Properties : additionalProperties : null
             exclude :  False
             lowCpuThreshold : null

Type       : Microsoft.Advisor/Configurations
```

Updates the configuration(exclude) for resourceGroupName1 to be included in the recommendation generation.

{{ Add example description here }}

### Example 6
```powershell
PS C:\> Get-AzureRMAdvisorConfiguration | Set-AzureRMAdvisorConfiguration
Id         : /subscriptions/{user_subscription}/resourceGroups/resourceGroupName1/providers/Microsoft.Advisor/configurations/{user_subscription}-resourceGroupName1
Name       : {user_subscription}-resourceGroupName1
Properties : additionalProperties : null
             exclude :  False
             lowCpuThreshold : null

Type       : Microsoft.Advisor/Configurations
Id         : /subscriptions/{user_subscription}/resourceGroups/resourceGroupName1/providers/Microsoft.Advisor/configurations/{user_subscription}-resourceGroupName2
Name       : {user_subscription}-resourceGroupName2
Properties : additionalProperties : null
             exclude :  False
             lowCpuThreshold : null

Type       : Microsoft.Advisor/Configurations
```

Makes all the resource-level configuration that are already updates by the user to be included in the recommendation generation. This will take into effect only if the user has updated in the exclude property of resourceGroup in the past, if not by default it will be included in the recommendation generation.

### Example 7
```powershell
PS C:\> Get-AzureRMAdvisorConfiguration | Set-AzureRMAdvisorConfiguration -L 20
Id         : /subscriptions/{user_subscription}/resourceGroups/resourceGroupName1/providers/Microsoft.Advisor/configurations/{user_subscription}
Name       : {user_subscription}
Properties : additionalProperties : null
             exclude :  False
             lowCpuThreshold : 20

Type       : Microsoft.Advisor/Configurations

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

### -Exclude
Exclude from the recommendation generation. If this swtichParameter is specified, the exclude porperty will be set to true which excludes from the recommendation generation.
By default, if not set by the user the exclude property assoicated with will be set to false and will be included in the recommendation generation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: E

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
{{Fill InputObject Description}}

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData]
Parameter Sets: InputObjectLowCpuExcludeParameterSet, InputObjectRgExcludeParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LowCpuThreshold
Value for Low Cpu threshold.

```yaml
Type: String
Parameter Sets: LowCpuAndExcludeParameterSet, InputObjectLowCpuExcludeParameterSet
Aliases: L, LowCpu

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group name for the configuration.

```yaml
Type: String
Parameter Sets: RgAndExcludeParameterSet
Aliases: Rg, ResoureGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: InputObjectRgExcludeParameterSet
Aliases: Rg, ResoureGroup

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

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData, Microsoft.Azure.Commands.Advisor, Version=0.1.1.0, Culture=neutral, PublicKeyToken=null]]

## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Advisor.Cmdlets.Models.PsAzureAdvisorConfigurationData, Microsoft.Azure.Commands.Advisor, Version=0.1.1.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
