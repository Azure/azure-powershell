---
external help file: Microsoft.Azure.Commands.LogicApp.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmIntegrationAccountReceivedEdifactIcn

## SYNOPSIS
This cmdlet retrieves a specific received Edifact interchange control number (interchange control reference) per agreement and control number value.

## SYNTAX

```
Get-AzureRmIntegrationAccountReceivedEdifactIcn -ResourceGroupName <String> -Name <String>
 -AgreementName <String> -ControlNumberValue <String>
```

## DESCRIPTION
This cmdlet is meant to be used in disaster recovery scenarios to validate the presence of a received Edifact interchange control number (reference) and optionally to remove that entity with Remove-AzureRmIntegrationAccountReceivedEdifactIcn.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmIntegrationAccountReceivedEdifactIcn -ResourceGroupName "groupName" -Name "accountName" -AgreementName "EdifactAgreementName" -ControlNumberValue "000000641"
ControlNumber            : 000000641
ControlNumberChangedTime : 2/15/2017 12:36:00 AM
IsMessageProcessingFailed: False
```

This command gets the integration account received interchange control number (reference) by agreement name and control number value.

## PARAMETERS

### -AgreementName
The integration account agreement name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ControlNumberValue
The integration account control number value.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The integration account name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The integration account resource group name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.LogicApp.Utilities.IntegrationAccountControlNumber

## NOTES

## RELATED LINKS

[Set-AzureRmIntegrationAccountReceivedEdifactIcn]()

[Remove-AzureRmIntegrationAccountReceivedEdifactIcn]()
