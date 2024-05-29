---
external help file: Az.Cdn-help.xml
Module Name: Az.Cdn
online version: https://learn.microsoft.com/powershell/module/az.cdn/test-azfrontdoorcdnendpointcustomdomain
schema: 2.0.0
---

# Test-AzFrontDoorCdnEndpointCustomDomain

## SYNOPSIS
Validates the custom domain mapping to ensure it maps to the correct Azure Front Door endpoint in DNS.

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzFrontDoorCdnEndpointCustomDomain -EndpointName <String> -ProfileName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -HostName <String> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzFrontDoorCdnEndpointCustomDomain -InputObject <ICdnIdentity> -HostName <String>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Validates the custom domain mapping to ensure it maps to the correct Azure Front Door endpoint in DNS.

## EXAMPLES

### Example 1: Test an AzureFrontDoor domain within the specified AzureFrontDoor endpoint
```powershell
Test-AzFrontDoorCdnEndpointCustomDomain -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 -HostName "pstest001.dev.cdn.azure.cn"
```

```output
CustomDomainValidated Message Reason
--------------------- ------- ------
True
```

Test an AzureFrontDoor domain within the specified AzureFrontDoor endpoint

### Example 2: Test an AzureFrontDoor domain within the specified AzureFrontDoor endpoint via identity
```powershell
Get-AzFrontDoorCdnEndpoint -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -EndpointName end001 | Test-AzFrontDoorCdnEndpointCustomDomain -HostName "pstest001.dev.cdn.azure.cn"
```

```output
CustomDomainValidated Message Reason
--------------------- ------- ------
True
```

Test an AzureFrontDoor domain within the specified AzureFrontDoor endpoint via identity

## PARAMETERS

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
Parameter Sets: ValidateExpanded
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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

### -ProfileName
Name of the Azure Front Door Standard or Azure Front Door Premium profile which is unique within the resource group.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the Resource group within the Azure subscription.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure Subscription ID.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Cdn.Models.Api20240201.IValidateCustomDomainOutput

## NOTES

## RELATED LINKS
