---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/remove-azvirtualhubbgpconnection
schema: 2.0.0
---

# Remove-AzVirtualHubBgpConnection

## SYNOPSIS
The Remove-AzVirtualHubBgpConnection cmdlet removes a HubBgpConnection resource that peers the Azure Virtual WAN Hub Router with a BGP-enabled peer in a virtual network connected to the Virtual WAN Hub.

## SYNTAX

### ByVirtualHubName (Default)
```
Remove-AzVirtualHubBgpConnection -ResourceGroupName <String> -VirtualHubName <String> -Name <String> [-AsJob]
 [-Force] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByVirtualHubObject
```
Remove-AzVirtualHubBgpConnection -Name <String> -VirtualHub <PSVirtualHub> [-AsJob] [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByHubBgpConnectionObject
```
Remove-AzVirtualHubBgpConnection -InputObject <PSBgpConnection> [-AsJob] [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByHubBgpConnectionResourceId
```
Remove-AzVirtualHubBgpConnection -ResourceId <String> [-AsJob] [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The Remove-AzVirtualHubBgpConnection cmdlet removes a HubBgpConnection resource that peers Azure Virtual WAN Hub Router with a BGP-enabled peer in virtual network connected to the Virtual WAN Hub.

## EXAMPLES

### Example 1
```powershell
Remove-AzVirtualHubBgpConnection -ResourceGroupName "testRG" -VirtualHubName "testHub" -Name "testBgpConnection"
```

The above will remove a Virtual WAN Hub BGP Connection using its resource group name, the Virtual WAN Hub name and the Connection name.

### Example 2
```powershell
Get-AzVirtualHubBgpConnection -ResourceGroupName "testRG" -VirtualHubName "testHub" -Name "testBgpConnection" | Remove-AzVirtualHubBgpConnection
```

The above will remove a Virtual WAN Hub BGP Connection using powershell piping on the output from Get-AzVirtualHubBgpConnection.

### Example 3
```powershell
$bgpConnectionId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.Network/virtualHubs/{virtualHubName}/bgpConnections/{bgpConnectionName}"
Remove-AzVirtualHubBgpConnection -ResourceId $bgpConnectionId
```

The above will remove a Virtual WAN Hub BGP Connection using the BGP Connection resource id.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Force
Do not ask for confirmation if you want to overwrite a resource

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The virtual hub bgp connection resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSBgpConnection
Parameter Sets: ByHubBgpConnectionObject
Aliases: VirtualHubBgpConnection

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubName, ByVirtualHubObject
Aliases: ResourceName, BgpConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns an object representing the item on which this operation is being performed.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: System.String
Parameter Sets: ByHubBgpConnectionResourceId
Aliases: BgpConnectionId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualHub
The virtual hub resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualHub
Parameter Sets: ByVirtualHubObject
Aliases: ParentObject, ParentVirtualHub

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VirtualHubName
The virtual hub name.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubName
Aliases: ParentResourceName, ParentVirtualHubName

Required: True
Position: Named
Default value: None
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

### Microsoft.Azure.Commands.Network.Models.PSVirtualHub

### Microsoft.Azure.Commands.Network.Models.PSBgpConnection

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzVirtualHubBgpConnection](./Get-AzVirtualHubBgpConnection.md)

[New-AzVirtualHubBgpConnection](./Remove-AzVirtualHubBgpConnection.md)

[Update-AzVirtualHubBgpConnection](./Update-AzVirtualHubBgpConnection.md)