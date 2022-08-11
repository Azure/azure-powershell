---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-aznetworkmanagerscope
schema: 2.0.0
---

# New-AzNetworkManagerScope

## SYNOPSIS
Creates a network manager scope.

## SYNTAX

```
New-AzNetworkManagerScope [-ManagementGroup <String[]>]
 [-Subscription <String[]>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerScope** cmdlet creates a network manager scope.

## EXAMPLES

### Example 1
```powershell
$subgroup  = @("/subscriptions/00000000-0000-0000-0000-000000000000")
$mggroup  = @("/providers/Microsoft.Management/managementGroups/PowerShellTest")
New-AzNetworkManagerScope -Subscription $subgroup -ManagementGroup $mggroup
```
```output
ManagementGroups                                                  Subscriptions                                         
----------------                                                  -------------                                         
{/providers/Microsoft.Management/managementGroups/PowerShellTest} {/subscriptions/00000000-0000-0000-0000-000000000000}
```
Creates a network manager scope with management group and subscription.

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

### -ManagementGroup
Management Group Lists in Network Manager Scope

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Subscription
Subscription Lists in Network Manager Scope

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String[]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopes

## NOTES

## RELATED LINKS
[New-AzNetworkManager](./New-AzNetworkManager.md)

[Get-AzNetworkManager](./Get-AzNetworkManager.md)

[Remove-AzNetworkManager](./Remove-AzNetworkManager.md)

[Set-AzNetworkManager](./Set-AzNetworkManager.md)