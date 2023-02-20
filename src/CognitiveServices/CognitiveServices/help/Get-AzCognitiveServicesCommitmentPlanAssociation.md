---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CognitiveServices.dll-Help.xml
Module Name: Az.CognitiveServices
online version: https://learn.microsoft.com/powershell/module/az.cognitiveservices/get-azcognitiveservicescommitmentplanassociation
schema: 2.0.0
---

# Get-AzCognitiveServicesCommitmentPlanAssociation

## SYNOPSIS
Get Cognitive Services Commitment Plan Association

## SYNTAX

### DefaultParameterSet (Default)
```
Get-AzCognitiveServicesCommitmentPlanAssociation [[-ResourceGroupName] <String>] [-CommitmentPlanName] <String>
 [[-Name] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameterSet
```
Get-AzCognitiveServicesCommitmentPlanAssociation [-ResourceId] <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get Cognitive Services Commitment Plan Association

## EXAMPLES

### Example 1
```powershell
Get-AzCognitiveServicesCommitmentPlanAssociation -ResourceGroupName ResourceGroupName -CommitmentPlanName CommitmentPlanName -Name AssociationName
```

Get a Cognitive Services Commitment Plan Association

## PARAMETERS

### -CommitmentPlanName
Cognitive Services CommitmentPlan Name.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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
Cognitive Services CommitmentPlan AssociationName Name.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Resource Id.

```yaml
Type: System.String
Parameter Sets: ResourceIdParameterSet
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

[Get-AzCognitiveServicesCommitmentPlan](./Get-AzCognitiveServicesCommitmentPlan.md)

[New-AzCognitiveServicesCommitmentPlan](./New-AzCognitiveServicesCommitmentPlan.md)

[New-AzCognitiveServicesCommitmentPlanAssociation](./New-AzCognitiveServicesCommitmentPlanAssociation.md)

[Remove-AzCognitiveServicesCommitmentPlan](./Remove-AzCognitiveServicesCommitmentPlan.md)

[Remove-AzCognitiveServicesCommitmentPlanAssociation](./Remove-AzCognitiveServicesCommitmentPlanAssociation.md)