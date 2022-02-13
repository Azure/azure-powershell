---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://docs.microsoft.com/powershell/module/az.security/Get-AzSecuritySecureScoreControlDefinition
schema: 2.0.0
---

# Get-AzSecuritySecureScoreControlDefinition

## SYNOPSIS
Gets security secure score control definitions on a subscription

## SYNTAX

### SubscriptionScope (Default)
```
Get-AzSecuritySecureScoreControlDefinition [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### SubscriptionLevelResource
```
Get-AzSecuritySecureScoreControlDefinition -Name <String> [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The Get-AzSecuritySecureScoreControlDefinition comlet gets security secure score control definitions on a subscription.

## EXAMPLES

### Example 1
```powershell
PS C:\> Get-AzSecuritySecureScoreControlDefinition

Id                    : /providers/Microsoft.Security/secureScoreControlDefinitions/a9909064-42b4-4d34-8143-275477afe18b
Name                  : a9909064-42b4-4d34-8143-275477afe18b
Type                  : Microsoft.Security/secureScoreControlDefinitions
DisplayName           : Protect your applications with Azure advanced networking solutions
Description           : 
MaxScore              : 2
Source                : BuiltIn
AssessmentDefinitions : {/providers/Microsoft.Security/assessmentMetadata/e3de1cc0-f4dd-3b34-e496-8b5381ba2d70, /providers/Microsoft.Security/assessmentMetadata/08e628db-e2ed-4793-bc91-d13e6
                        84401c3, /providers/Microsoft.Security/assessmentMetadata/0642d770-b189-42ef-a2ce-9dcc3ec6c169, /providers/Microsoft.Security/assessmentMetadata/405c9ae6-49f9-46c4-88
                        73-a86690f27818...}
```

Gets all the security secure score control definitions in a subscription

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

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

### Microsoft.Azure.Commands.Security.Models.Assessments.PSSecuritySecureScoreControlDefinition

## NOTES

## RELATED LINKS
