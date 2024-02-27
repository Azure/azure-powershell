---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/Get-AzSecuritySecureScore
schema: 2.0.0
---

# Get-AzSecuritySecureScore

## SYNOPSIS
Gets security secure scores and their results on a subscription

## SYNTAX

### SubscriptionScope (Default)
```
Get-AzSecuritySecureScore [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### SubscriptionLevelResource
```
Get-AzSecuritySecureScore -Name <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzSecuritySecureScore comlet gets security secure scores and their results on a subscription.

## EXAMPLES

### Example 1
```powershell
Get-AzSecuritySecureScore
```

```output
Id : /subscriptions/0b1f6471-1bf0-4dda-aec3-cb9272f09590/providers/Microsoft.Security/secureScores/ascScore
Name : ascScore
Type : Microsoft.Security/secureScores
DisplayName : ASC score
CurrentScore : 18.38
MaxScore : 56
Percentage : 0.3282
Weight : 1161
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
Resource name.

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

### Microsoft.Azure.Commands.Security.Models.Assessments.PSSecuritySecureScore

## NOTES

## RELATED LINKS
