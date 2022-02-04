---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CognitiveServices.dll-Help.xml
Module Name: Az.CognitiveServices
online version: https://docs.microsoft.com/powershell/module/az.cognitiveservices/new-azcognitiveservicesaccountcommitmentplan
schema: 2.0.0
---

# New-AzCognitiveServicesAccountCommitmentPlan

## SYNOPSIS
Create a CommitmentPlan for a Cognitive Services account

## SYNTAX

```
New-AzCognitiveServicesAccountCommitmentPlan [-ResourceGroupName] <String> [-AccountName] <String>
 [-Name] <String> [-Properties] <CommitmentPlanProperties> [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a CommitmentPlan for a Cognitive Services account

## EXAMPLES

### Example 1
```powershell
New-AzCognitiveServicesAccountDeployment -ResourceGroupName cognitive-services-resource-group -AccountName resource-name -Name "plan" -Properties $properties
```

Create a CommitmentPlan for a Cognitive Services account
You can use `New-AzCognitiveServicesObject` to create a CommitmentPlanProperties object

## PARAMETERS

### -AccountName
Cognitive Services Account Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: CognitiveServicesAccountName

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
Cognitive Services Account Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Properties
Cognitive Services CommitmentPlan Properties.

```yaml
Type: Microsoft.Azure.Management.CognitiveServices.Models.CommitmentPlanProperties
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

### Microsoft.Azure.Management.CognitiveServices.Models.CommitmentPlan

## NOTES

## RELATED LINKS
