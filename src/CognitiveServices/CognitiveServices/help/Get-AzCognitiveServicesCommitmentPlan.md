---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CognitiveServices.dll-Help.xml
Module Name: Az.CognitiveServices
online version: https://learn.microsoft.com/powershell/module/az.cognitiveservices/get-azcognitiveservicescommitmentplan
schema: 2.0.0
---

# Get-AzCognitiveServicesCommitmentPlan

## SYNOPSIS
Get Cognitive Services Commitment Plan

## SYNTAX

### ResourceGroupParameterSet (Default)
```
Get-AzCognitiveServicesCommitmentPlan [[-ResourceGroupName] <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### CommitmentPlanNameParameterSet
```
Get-AzCognitiveServicesCommitmentPlan [-ResourceGroupName] <String> [-Name] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get Cognitive Services Commitment Plan

## EXAMPLES

### Example 1
```powershell
Get-AzCognitiveServicesCommitmentPlan -ResourceGroupName ResourceGroupName -Name CommitmentPlanName
```

```output
SystemData : Microsoft.Azure.Management.CognitiveServices.Models.SystemData
Etag       : "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
Kind       : 
Sku        : 
Tags       : 
Location   : 
Properties : Microsoft.Azure.Management.CognitiveServices.Models.CommitmentPlanProperties
Id         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/cognitive-services-resource-group/providers/Microsoft.CognitiveServices/accounts/resource-name/commitmentplans/plan-name
Name       : plan-name
Type       : Microsoft.CognitiveServices/accounts/commitmentplans
```

Get a Cognitive Services Commitment Plan

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

### -Name
Cognitive Services Commitment Plan Name.

```yaml
Type: System.String
Parameter Sets: CommitmentPlanNameParameterSet
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
Type: System.String
Parameter Sets: ResourceGroupParameterSet
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

```yaml
Type: System.String
Parameter Sets: CommitmentPlanNameParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.CognitiveServices.Models.PSCognitiveServicesAccount

## NOTES

## RELATED LINKS

[Get-AzCognitiveServicesCommitmentPlanAssociation](./Get-AzCognitiveServicesCommitmentPlanAssociation.md)

[New-AzCognitiveServicesCommitmentPlan](./New-AzCognitiveServicesCommitmentPlan.md)

[New-AzCognitiveServicesCommitmentPlanAssociation](./New-AzCognitiveServicesCommitmentPlanAssociation.md)

[Remove-AzCognitiveServicesCommitmentPlan](./Remove-AzCognitiveServicesCommitmentPlan.md)

[Remove-AzCognitiveServicesCommitmentPlanAssociation](./Remove-AzCognitiveServicesCommitmentPlanAssociation.md)
