---
external help file:
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/test-azcdnendpointcustomdomain
schema: 2.0.0
---

# Test-AzCdnEndpointCustomDomain

## SYNOPSIS
Validates the custom domain mapping to ensure it maps to the correct CDN endpoint in DNS.

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzCdnEndpointCustomDomain -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 -HostName <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzCdnEndpointCustomDomain -InputObject <ICdnIdentity> -HostName <String> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityProfile
```
Test-AzCdnEndpointCustomDomain -EndpointName <String> -ProfileInputObject <ICdnIdentity>
 -CustomDomainProperty <IValidateCustomDomainInput> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaIdentityProfileExpanded
```
Test-AzCdnEndpointCustomDomain -EndpointName <String> -ProfileInputObject <ICdnIdentity> -HostName <String>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaJsonFilePath
```
Test-AzCdnEndpointCustomDomain -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaJsonString
```
Test-AzCdnEndpointCustomDomain -EndpointName <String> -ProfileName <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Validates the custom domain mapping to ensure it maps to the correct CDN endpoint in DNS.

## EXAMPLES

### Example 1: Test an AzureCDN custom domain under the AzureCDN endpoint
```powershell
Test-AzCdnEndpointCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -EndpointName endptest001 -HostName 'testcm.dev.cdn.azure.cn'
```

```output
CustomDomainValidated Message Reason
--------------------- ------- ------
True
```

Test an AzureCDN custom domain under the AzureCDN endpoint

### Example 2: Test an AzureCDN custom domain under the AzureCDN endpoint via identity
```powershell
Get-AzCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName cdn001 -Name endptest001 | Test-AzCdnEndpointCustomDomain -HostName 'testcm.dev.cdn.azure.cn'
```

Test an AzureCDN custom domain under the AzureCDN endpoint via identity

## PARAMETERS

### -CustomDomainProperty
Input of the custom domain to be validated for DNS mapping.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IValidateCustomDomainInput
Parameter Sets: ValidateViaIdentityProfile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EndpointName
Name of the endpoint under the profile which is unique globally.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityProfile, ValidateViaIdentityProfileExpanded, ValidateViaJsonFilePath, ValidateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostName
The host name of the custom domain.
Must be a domain name.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded, ValidateViaIdentityProfileExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: ValidateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Validate operation

```yaml
Type: System.String
Parameter Sets: ValidateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Validate operation

```yaml
Type: System.String
Parameter Sets: ValidateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfileInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity
Parameter Sets: ValidateViaIdentityProfile, ValidateViaIdentityProfileExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProfileName
Name of the CDN profile which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaJsonFilePath, ValidateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaJsonFilePath, ValidateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaJsonFilePath, ValidateViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.ICdnIdentity

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IValidateCustomDomainInput

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.IValidateCustomDomainOutput

## NOTES

## RELATED LINKS

