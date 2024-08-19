---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/Get-AzSecuritySecureScoreControl
schema: 2.0.0
---

# Get-AzSecuritySecureScoreControl

## SYNOPSIS
Gets security secure score controls and their results on a subscription

## SYNTAX

### SubscriptionScope (Default)
```
Get-AzSecuritySecureScoreControl [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### SubscriptionLevelResource
```
Get-AzSecuritySecureScoreControl -Name <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzSecuritySecureScoreControl comlet gets security secure score controls and their results on a subscription.

## EXAMPLES

### Example 1
```powershell
Get-AzSecuritySecureScoreControl
```

```output
Id : /subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/providers/Microsoft.Security/secureSco
res/ascScore/secureScoreControls/8fd574ec-43cf-426e-a439-a67cbaf2d564
Name : 8fd574ec-43cf-426e-a439-a67cbaf2d564
Type : Microsoft.Security/secureScores/secureScoreControls
DisplayName : Enable encryption at rest
CurrentScore : 0
MaxScore : 4
Percentage : 0
Weight : 6
HealthyResourceCount : 0
UnhealthyResourceCount : 6
NotApplicableResourceCount : 0
```

Gets all the security secure scores in a subscription

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
Secure score name.

```yaml
Type: System.String
Parameter Sets: SubscriptionLevelResource
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### Microsoft.Azure.Commands.Security.Models.Assessments.PSSecuritySecureScoreControl

## NOTES

## RELATED LINKS
