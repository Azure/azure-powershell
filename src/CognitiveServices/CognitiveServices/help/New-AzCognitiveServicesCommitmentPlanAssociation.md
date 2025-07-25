---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CognitiveServices.dll-Help.xml
Module Name: Az.CognitiveServices
online version: https://learn.microsoft.com/powershell/module/az.cognitiveservices/new-azcognitiveservicescommitmentplanassociation
schema: 2.0.0
---

# New-AzCognitiveServicesCommitmentPlanAssociation

## SYNOPSIS
Create a Cognitive Services Commitment Plan Association

## SYNTAX

```
New-AzCognitiveServicesCommitmentPlanAssociation [-ResourceGroupName] <String> [-CommitmentPlanName] <String>
 [-Name] <String> [-AccountId] <String> [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a Cognitive Services Commitment Plan Association

## EXAMPLES

### Example 1
```powershell
New-AzCognitiveServicesCommitmentPlanAssociation -ResourceGroupName ResourceGroupName -CommitmentPlanName CommitmentPlanName -Name AssociationName -AccountId AccountId;
```

Create a Cognitive Services Commitment Plan Association between a commitment plan and an account

## PARAMETERS

### -AccountId
Cognitive Services Account Resource ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -CommitmentPlanName
Cognitive Services CommitmentPlan Name.

```yaml
Type: System.String
Parameter Sets: (All)
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
Cognitive Services CommitmentPlan Association Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Management.CognitiveServices.Models.PSCognitiveServicesAccount

## NOTES

## RELATED LINKS

[Get-AzCognitiveServicesCommitmentPlan](./Get-AzCognitiveServicesCommitmentPlan.md)

[Get-AzCognitiveServicesCommitmentPlanAssociation](./Get-AzCognitiveServicesCommitmentPlanAssociation.md)

[New-AzCognitiveServicesCommitmentPlan](./New-AzCognitiveServicesCommitmentPlan.md)

[Remove-AzCognitiveServicesCommitmentPlan](./Remove-AzCognitiveServicesCommitmentPlan.md)

[Remove-AzCognitiveServicesCommitmentPlanAssociation](./Remove-AzCognitiveServicesCommitmentPlanAssociation.md)