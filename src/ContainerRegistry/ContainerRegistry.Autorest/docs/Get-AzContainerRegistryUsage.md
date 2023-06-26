---
external help file:
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.containerregistry/get-azcontainerregistryusage
schema: 2.0.0
---

# Get-AzContainerRegistryUsage

## SYNOPSIS
Gets the quota usages for the specified container registry.

## SYNTAX

```
Get-AzContainerRegistryUsage -RegistryName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the quota usages for the specified container registry.

## EXAMPLES

### Example 1: Get Usage of an azure container registry.
```powershell
Get-AzContainerRegistryUsage -ResourceGroupName "MyResourceGroup" -RegistryName "RegistryExample"
```

```output
CurrentValue Limit        Name                       Unit
------------ -----        ----                       ----
0            536870912000 Size                       Bytes
0            500          Webhooks                   Count
2            -1           Geo-replications           Count
0            100          IPRules                    Count
0            100          VNetRules                  Count
0            200          PrivateEndpointConnections Count
0            50000        ScopeMaps                  Count
0            50000        Tokens                     Count
```

Get Usage of an azure container registry.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -RegistryName
The name of the container registry.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

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
Parameter Sets: (All)
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
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IRegistryUsage

## NOTES

ALIASES

## RELATED LINKS

