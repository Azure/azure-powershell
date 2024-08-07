---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Security.dll-Help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/Get-AzSecuritySolutionsReferenceData
schema: 2.0.0
---

# Get-AzSecuritySolutionsReferenceData

## SYNOPSIS
Get Security Solutions Reference Data

## SYNTAX

### SubscriptionScope (Default)
```
Get-AzSecuritySolutionsReferenceData [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### SubscriptionLevelResource
```
Get-AzSecuritySolutionsReferenceData -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ResourceId
```
Get-AzSecuritySolutionsReferenceData -ResourceId <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get Security Solutions Reference Data

## EXAMPLES

### Example 1
```powershell
Get-AzSecuritySolutionsReferenceData
```

```output
Id                   : /subscriptions/67bc604b-54b2-4c78-a7ba-72504920a319/providers/Microsoft.Security/locations/centr
                       alus/securitySolutionsReferenceData/qualys.qualysAgent
Name                 : qualys.qualysAgent
SecurityFamily       : Va
alertVendorName      :
packageInfoUrl       :
productName          :
publisher            :
publisherDisplayName :
template             : qualys/qualysAgent

Id                   : /subscriptions/67bc604b-54b2-4c78-a7ba-72504920a319/providers/Microsoft.Security/locations/centr
                       alus/securitySolutionsReferenceData/microsoft.ApplicationGateway-ARM
Name                 : microsoft.ApplicationGateway-ARM
SecurityFamily       : SaasWaf
alertVendorName      :
packageInfoUrl       :
productName          :
publisher            :
publisherDisplayName :
template             : microsoft/ApplicationGateway-ARM
```

Get all Get Security Solutions Reference Data in the subscription

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

### -ResourceId
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

```yaml
Type: System.String
Parameter Sets: ResourceId
Aliases:

Required: True
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
