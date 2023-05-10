---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CognitiveServices.dll-Help.xml
Module Name: Az.CognitiveServices
online version: https://learn.microsoft.com/powershell/module/az.cognitiveservices/remove-azcognitiveservicescommitmentplanassociation
schema: 2.0.0
---

# Remove-AzCognitiveServicesCommitmentPlanAssociation

## SYNOPSIS
Remove a Cognitive Services Commitment Plan Association

## SYNTAX

```
Remove-AzCognitiveServicesCommitmentPlanAssociation [-ResourceGroupName] <String>
 [-CommitmentPlanName] <String> [-Name] <String> [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Remove a Cognitive Services Commitment Plan Association

## EXAMPLES

### Example 1
```powershell
Remove-AzCognitiveServicesCommitmentPlanAssociation -ResourceGroupName ResourceGroupName -CommitmentPlanName CommitmentPlanName -Name AssociationName
```

Remove a Cognitive Services Commitment Plan Association

## PARAMETERS

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

### -Force
Don't ask for confirmation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

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

### -PassThru
This Cmdlet does not return an object by default. If this switch is specified, it returns true if successful.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### System.Void

## NOTES

## RELATED LINKS

[Get-AzCognitiveServicesCommitmentPlan](./Get-AzCognitiveServicesCommitmentPlan.md)

[Get-AzCognitiveServicesCommitmentPlanAssociation](./Get-AzCognitiveServicesCommitmentPlanAssociation.md)

[New-AzCognitiveServicesCommitmentPlan](./New-AzCognitiveServicesCommitmentPlan.md)

[New-AzCognitiveServicesCommitmentPlanAssociation](./New-AzCognitiveServicesCommitmentPlanAssociation.md)

[Remove-AzCognitiveServicesCommitmentPlan](./Remove-AzCognitiveServicesCommitmentPlan.md)