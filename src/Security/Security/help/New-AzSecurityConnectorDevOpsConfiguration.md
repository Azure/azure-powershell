---
external help file: Az.Security-help.xml
Module Name: Az.security
online version: https://learn.microsoft.com/powershell/module/az.security/new-azsecurityconnectordevopsconfiguration
schema: 2.0.0
---

# New-AzSecurityConnectorDevOpsConfiguration

## SYNOPSIS
Create a DevOps Configuration.

## SYNTAX

```
New-AzSecurityConnectorDevOpsConfiguration -ResourceGroupName <String> -SecurityConnectorName <String>
 [-SubscriptionId <String>] [-AuthorizationCode <String>] [-AutoDiscovery <String>]
 [-TopLevelInventoryList <String[]>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Create a DevOps Configuration.

## EXAMPLES

### EXAMPLE 1
```
New-AzSecurityConnectorDevOpsConfiguration -ResourceGroupName "securityconnectors-pwsh-tmp" -SecurityConnectorName "ado-sdk-pwsh-test03" -AutoDiscovery Disabled -TopLevelInventoryList @("org1", "org2") -AuthorizationCode "myAuthorizationCode"
```

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -AuthorizationCode
Gets or sets one-time OAuth code to exchange for refresh and access tokens.Only used during PUT/PATCH operations.
The secret is cleared during GET.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AutoDiscovery
AutoDiscovery states.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -NoWait
Run the command asynchronously

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
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
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TopLevelInventoryList
List of top-level inventory to select when AutoDiscovery is disabled.This field is ignored when AutoDiscovery is enabled.

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

### Microsoft.Azure.PowerShell.Cmdlets.Security.Models.IDevOpsConfiguration
## NOTES

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.security/new-azsecurityconnectordevopsconfiguration](https://learn.microsoft.com/powershell/module/az.security/new-azsecurityconnectordevopsconfiguration)

