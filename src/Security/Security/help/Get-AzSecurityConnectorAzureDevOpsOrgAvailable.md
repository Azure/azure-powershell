---
external help file: Az.Security-help.xml
Module Name: Az.Security
online version: https://learn.microsoft.com/powershell/module/az.security/get-azsecurityconnectorazuredevopsorgavailable
schema: 2.0.0
---

# Get-AzSecurityConnectorAzureDevOpsOrgAvailable

## SYNOPSIS
Returns a list of all Azure DevOps organizations accessible by the user token consumed by the connector.

## SYNTAX

```
Get-AzSecurityConnectorAzureDevOpsOrgAvailable -ResourceGroupName <String> -SecurityConnectorName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Returns a list of all Azure DevOps organizations accessible by the user token consumed by the connector.

## EXAMPLES

### EXAMPLE 1
```
Get-AzSecurityConnectorAzureDevOpsOrgAvailable -ResourceGroupName dfdtest-sdk -SecurityConnectorName dfdsdktests-azdo-01
```

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityConnectorName
The security connector name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Azure subscription ID

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IAzureDevOpsOrgListResponse
## NOTES

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.security/get-azsecurityconnectorazuredevopsorgavailable](https://learn.microsoft.com/powershell/module/az.security/get-azsecurityconnectorazuredevopsorgavailable)

