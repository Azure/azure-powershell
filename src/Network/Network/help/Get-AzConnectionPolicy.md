---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/get-azconnectionpolicy
schema: 2.0.0
---

# Get-AzConnectionPolicy

## SYNOPSIS
Retrieves a ConnectionPolicy resource associated with a VirtualHub.

## SYNTAX

### ByVirtualHubName (Default)
```
Get-AzConnectionPolicy -ResourceGroupName <String> -HubName <String> [-Name <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ByVirtualHubObject
```
Get-AzConnectionPolicy -VirtualHub <PSVirtualHub> [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ByVirtualHubResourceId
```
Get-AzConnectionPolicy -ParentResourceId <String> [-Name <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the specified ConnectionPolicy that is associated with the specified VirtualHub. If no name is specified, all ConnectionPolicies under the hub are returned.

## EXAMPLES

### Example 1: Get a specific ConnectionPolicy by name
```powershell
New-AzVirtualWan -ResourceGroupName "testRg" -Name "testWan" -Location "westcentralus" -VirtualWANType "Standard" -AllowVnetToVnetTraffic -AllowBranchToBranchTraffic
$virtualWan = Get-AzVirtualWan -ResourceGroupName "testRg" -Name "testWan"

New-AzVirtualHub -ResourceGroupName "testRg" -Name "testHub" -Location "westcentralus" -AddressPrefix "10.0.0.0/16" -VirtualWan $virtualWan
$virtualHub = Get-AzVirtualHub -ResourceGroupName "testRg" -Name "testHub"

New-AzConnectionPolicy -ResourceGroupName "testRg" -ParentResourceName "testHub" -Name "testPolicy" -EnableInternetSecurity
Get-AzConnectionPolicy -ResourceGroupName "testRg" -HubName "testHub" -Name "testPolicy"
```

```output
ProvisioningState    : Succeeded
EnableInternetSecurity : True
RoutingConfiguration :
AssociatedConnections : {}
Name                 : testPolicy
Etag                 : W/"etag"
Id                   : /subscriptions/testSub/resourceGroups/testRg/providers/Microsoft.Network/virtualHubs/testHub/connectionPolicies/testPolicy
```

### Example 2: List all ConnectionPolicies under a hub
```powershell
Get-AzConnectionPolicy -ResourceGroupName "testRg" -HubName "testHub"
```

This command retrieves all ConnectionPolicy resources associated with the specified VirtualHub.

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

### -HubName
The name of the parent VirtualHub.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubName
Aliases: VirtualHubName, ParentVirtualHubName, ParentResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the ConnectionPolicy resource to retrieve.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName, ConnectionPolicyName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -ParentResourceId
The resource ID of the parent VirtualHub.

```yaml
Type: System.String
Parameter Sets: ByVirtualHubResourceId
Aliases: VirtualHubId, ParentVirtualHubId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -VirtualHub
The parent VirtualHub object.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualHub

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSConnectionPolicy

## NOTES

## RELATED LINKS

[New-AzConnectionPolicy](./New-AzConnectionPolicy.md)

[Set-AzConnectionPolicy](./Set-AzConnectionPolicy.md)

[Remove-AzConnectionPolicy](./Remove-AzConnectionPolicy.md)
