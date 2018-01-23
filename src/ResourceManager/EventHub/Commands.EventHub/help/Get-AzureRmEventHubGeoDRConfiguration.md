---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
Module Name: AzureRM.EventHub
online version: 
schema: 2.0.0
---

# Get-AzureRmEventHubDRConfiguration

## SYNOPSIS
Retrieves Alias(Disaster Recovery configuration) for primary or secondary namespace

## SYNTAX

```
Get-AzureRmEventHubDRConfiguration [-ResourceGroupName] <String> [[-Namespace] <String>] [[-Name] <String>]
 [-DefaultProfile <IAzureContextContainer>]
```

## DESCRIPTION
The **Get-AzureRmEventHubDRConfiguration** Retrieves Alias(Disaster Recovery configuration) for primary or secondary namespace

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmEventHubDRConfiguration -ResourceGroupName "SampleResourceGroup" -Namespace "SampleNamespace_Primary" -Name "SampleDRCongifName"

Name              : SampleDRCongifName
Id                : /subscriptions/{SubscriptionId}/resourceGroups/SampleResourceGroup/providers/Microsoft.EventHub/namespaces/SampleNamespace_Primary/disasterRecoveryConfigs/SampleDRCongifName
Type              : Microsoft.EventHub/Namespaces/disasterrecoveryconfigs
ProvisioningState : Accepted
PartnerNamespace  : SampleNamespace_Secondary
Role              : Primary
```

Retrieves alias "SampleDRCongifName" configuration for primary namespace "SampleNamespace_Primary"

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -Name
DR Configuration Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: Alias

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Namespace
Namespace Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: NamespaceName

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable.
For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String


## OUTPUTS

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.EventHub.Models.PSEventHubDRConfigurationAttributes, Microsoft.Azure.Commands.EventHub, Version=0.4.6.0, Culture=neutral, PublicKeyToken=null]]


## NOTES

## RELATED LINKS

