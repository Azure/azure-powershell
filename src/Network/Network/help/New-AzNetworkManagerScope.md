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
New-AzNetworkManagerScope [-ManagementGroup <System.Collections.Generic.List`1[System.String]>]
 [-Subscription <System.Collections.Generic.List`1[System.String]>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerScope** cmdlet creates a network manager scope.

## EXAMPLES

### Example 1
```powershell
PS C:\> [System.Collections.Generic.List[string]]$subgroup  = @()
PS C:\> $subgroup.Add("/subscriptions/00000000-0000-0000-0000-000000000000")
PS C:\> [System.Collections.Generic.List[string]]$mggroup  = @()
PS C:\> $mggroup.Add("/managementGroups/00000000-0000-0000-0000-000000000000")
PS C:\> New-AzNetworkManagerScope -Subscription $subgroup -ManagementGroup $mggroup
```

Create a network manager scope which contains a list of subscriptions and a list of management groups.

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

### -ManagementGroup
Management Group Lists in Network Manager Scope

```yaml
Type: System.Collections.Generic.List`1[System.String]
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
Type: System.Collections.Generic.List`1[System.String]
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

### System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerScopes

## NOTES

## RELATED LINKS

[New-AzNetworkManager](./New-AzNetworkManager.md)

[Get-AzNetworkManager](./Get-AzNetworkManager.md)

[Remove-AzNetworkManager](./Remove-AzNetworkManager.md)

[Set-AzNetworkManager](./Set-AzNetworkManager.md)