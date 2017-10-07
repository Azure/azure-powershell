---
external help file: Microsoft.Azure.Commands.EventHub.dll-Help.xml
Module Name: AzureRM.EventHub
online version: 
schema: 2.0.0
---

# Get-AzureRmEventHubDRConfigurations

## SYNOPSIS
Retrieves Alias(Disaster Recovery configuration) for primary or secondary namespace

## SYNTAX

```
Get-AzureRmEventHubDRConfigurations [-ResourceGroupName] <String> [-Namespace] <String> [[-Name] <String>]
```

## DESCRIPTION
The **Get-AzureRmEventHubDRConfigurations** Retrieves Alias(Disaster Recovery configuration) for primary or secondary namespace

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmEventHubDRConfigurations -ResourceGroupName "SampleResourceGroup" -Namespace "SampleNamespace_Primary" -Name "SampleDRCongifName"
```

Retrieves alias "SampleDRCongifName" configuration for primary namespace "SampleNamespace_Primary"

### Example 2
```
PS C:\> Get-AzureRmEventHubDRConfigurations -ResourceGroupName "SampleResourceGroup" -Namespace "SampleNamespace_Primary"
```

Retrieves all alias configurations(list) for primary namespace "SampleNamespace_Primary"



## PARAMETERS

### -Name
DR Configuration Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

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
Aliases: 

Required: True
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

## INPUTS

### System.String


## OUTPUTS

Name              : SampleDRCongifName
Id                : /subscriptions/{SubscriptionId}/resourceGroups/SampleResourceGroup/providers/Microsoft.EventHub/namespaces/SampleNamespace_Primary/disasterRecoveryConfigs/SampleDRCongifName
Type              : Microsoft.EventHub/Namespaces/disasterrecoveryconfigs
ProvisioningState : Accepted
PartnerNamespace  : SampleNamespace_Secondary
Role              : Primary

## NOTES

## RELATED LINKS

