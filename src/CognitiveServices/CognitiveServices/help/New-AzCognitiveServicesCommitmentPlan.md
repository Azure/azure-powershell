---
external help file: Microsoft.Azure.PowerShell.Cmdlets.CognitiveServices.dll-Help.xml
Module Name: Az.CognitiveServices
online version: https://learn.microsoft.com/powershell/module/az.cognitiveservices/new-azcognitiveservicescommitmentplan
schema: 2.0.0
---

# New-AzCognitiveServicesCommitmentPlan

## SYNOPSIS
Create a Cognitive Services Commitment Plan

## SYNTAX

```
New-AzCognitiveServicesCommitmentPlan -ResourceGroupName <String> -Name <String> -Type <String>
 -SkuName <String> -Location <String> [-Tag <Hashtable[]>] -Properties <CommitmentPlanProperties>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Cognitive Services Commitment Plan

## EXAMPLES

### Example 1
```powershell
$properties = New-AzCognitiveServicesObject -Type CommitmentPlanProperties
$properties.HostingModel = "Web"
$properties.AutoRenew = $false
$properties.PlanType = "STT"
$properties.Current.Tier = "T1"
$properties.Next = $null

New-AzCognitiveServicesCommitmentPlan -ResourceGroupName ResourceGroupName -Name CommitmentPlanName -Type SpeechServices -SkuName S0 -Location CentralUS  -Properties $properties;
```

Create a Cognitive Services Commitment Plan for SpeechServices STT T1

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

### -Location
Cognitive Services CommitmentPlan Location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Cognitive Services Account Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
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
Position: Named
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
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkuName
Cognitive Services Account/CommitmentPlan Sku Name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Cognitive Services CommitmentPlan Tags.

```yaml
Type: System.Collections.Hashtable[]
Parameter Sets: (All)
Aliases: Tags

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Cognitive Services Account/CommitmentPlan Type.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Kind

Required: True
Position: Named
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

### Microsoft.Azure.Management.CognitiveServices.Models.CommitmentPlanProperties

## OUTPUTS

### Microsoft.Azure.Commands.Management.CognitiveServices.Models.PSCognitiveServicesAccount

## NOTES

## RELATED LINKS

[Get-AzCognitiveServicesCommitmentPlan](./Get-AzCognitiveServicesCommitmentPlan.md)

[Get-AzCognitiveServicesCommitmentPlanAssociation](./Get-AzCognitiveServicesCommitmentPlanAssociation.md)

[New-AzCognitiveServicesCommitmentPlanAssociation](./New-AzCognitiveServicesCommitmentPlanAssociation.md)

[Remove-AzCognitiveServicesCommitmentPlan](./Remove-AzCognitiveServicesCommitmentPlan.md)

[Remove-AzCognitiveServicesCommitmentPlanAssociation](./Remove-AzCognitiveServicesCommitmentPlanAssociation.md)