---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://docs.microsoft.com/powershell/module/az.security/Get-AzSecuritySolutionsReferenceData
schema: 2.0.0
---

# Get-AzSecuritySolution

## SYNOPSIS
Get Security Solutions

## SYNTAX

### SubscriptionScope (Default)
```
Get-AzSecuritySolution [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Get Security Solutions

## EXAMPLES

### Example 1
```powershell
Get-AzSecuritySolution
```

```output
Id                : /subscriptions/67bc604b-54b2-4c78-a7ba-72504920a319/resourceGroups/QualysLICTest/providers/Microsoft.Security/locations/centralus/securitySolutions/QualysTest
Name              : QualysLICTest
provisioningState : Succeeded
template          : qualys.qualysAgent
SecurityFamily    : Va
protectionStatus  : Good

Id                : /subscriptions/67bc604b-54b2-4c78-a7ba-72504920a319/resourceGroups/OfriWafTest/providers/MicrosoftSecurity/locations/centralus/securitySolutions/WafTest
Name              : WafTest
provisioningState : Succeeded
template          : Microsoft.ApplicationGateway-ARM
SecurityFamily    : SaasWaf
protectionStatus  : Good
```

Get all Get Security Solutions in the subscription

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Security.Models.ExternalSecuritySolutions.PSSecurityExternalSecuritySolution

## NOTES

## RELATED LINKS