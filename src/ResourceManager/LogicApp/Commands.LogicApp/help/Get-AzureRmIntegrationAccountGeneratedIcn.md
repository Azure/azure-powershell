---
external help file: Microsoft.Azure.Commands.LogicApp.dll-Help.xml
online version: 
schema: 2.0.0
---

# Get-AzureRmIntegrationAccountGeneratedIcn

## SYNOPSIS
This cmdlet retrieves the current value of the generated X12 interchange control number per agreement.

## SYNTAX

```
Get-AzureRmIntegrationAccountGeneratedIcn -ResourceGroupName <String> -Name <String> [-AgreementName <String>]
 [<CommonParameters>]
```

## DESCRIPTION
This cmdlet is meant to be used in disaster recovery scenarios to retrieve the current value of the generated X12 interchange control number so to write back an increased value with Set-AzureRmIntegrationAccountGeneratedIcn.
The interchange control number should be increased to avoid duplicate interchange control numbers for the numbers that could not yet be replicated to the passive region when the disaster happened in the active region.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmIntegrationAccountGeneratedIcn -ResourceGroupName "ResourceGroup1" -Name "IntegrationAccount1" -AgreementName "IntegrationAccountAgreement1"
ControlNumber            : 1000
ControlNumberChangedTime : 2/15/2017 12:36:00 AM
IsMessageProcessingFailed:
```

This command gets the integration account generated interchange control number by agreement name.

### Example 2
```
PS C:\> Get-AzureRmIntegrationAccountGeneratedIcn -ResourceGroupName "ResourceGroup1" -Name "IntegrationAccount1"
ControlNumber            : 1000
ControlNumberChangedTime : 2/22/2017 8:05:41 PM
AgreementName            : onesdk4351
IsMessageProcessingFailed:

ControlNumber            : 1000
ControlNumberChangedTime : 2/22/2017 8:05:41 PM
AgreementName            : onesdk4619
IsMessageProcessingFailed:

ControlNumber            : No generated control number was found for this agreement.
ControlNumberChangedTime : 1/1/0001 12:00:00 AM
AgreementName            : onesdk6720
IsMessageProcessingFailed:
```

This command gets all the generated interchange control numbers by integration account name.

## PARAMETERS

### -AgreementName
The integration account agreement name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.LogicApp.Utilities.IntegrationAccountClient+IntegrationAccountControlNumber

## NOTES

## RELATED LINKS

[Set-AzureRmIntegrationAccountGeneratedIcn](./Set-AzureRmIntegrationAccountGeneratedIcn.md)

