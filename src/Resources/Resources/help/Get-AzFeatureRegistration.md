---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/powershell/module/az.resources/get-azfeatureregistration
schema: 2.0.0
---

# Get-AzFeatureRegistration

## SYNOPSIS
Gets a feature registration in your account.

## SYNTAX

```
Get-AzFeatureRegistration [-Name <String>] -ProviderNamespace <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzFeatureRegistration** cmdlet gets a feature registration in your account.

## EXAMPLES

### Example 1
```powershell
PS C:\>Get-AzFeatureRegistration -FeatureName AllowApplicationSecurityGroups -ProviderNamespace Microsoft.Network
```

This gets the AllowApplicationSecurityGroups feature for Microsoft.Network in your account.

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
The feature name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: FeatureName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ProviderNamespace
The resource provider namespace.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Management.ResourceManager.Models.SubscriptionFeatureRegistration

## NOTES

## RELATED LINKS

[New-AzFeatureRegistration](./New-AzFeatureRegistration.md)

[Remove-AzFeatureRegistration](./Remove-AzFeatureRegistration.md)
