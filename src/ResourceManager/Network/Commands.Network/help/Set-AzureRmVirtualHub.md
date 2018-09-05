---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/set-azurermvirtualhub
schema: 2.0.0
---

# Set-AzureRmVirtualHub

## SYNOPSIS
Updates a Virtual Hub to an intended goal state.

## SYNTAX

### ByVirtualHubName (Default)
```
Set-AzureRmVirtualHub -Name <String> -ResourceGroupName <String> [-VirtualWan <PSVirtualWan>]
 [-VirtualWanId <String>] [-AddressPrefix <String>]
 [-HubVnetConnection <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection]>]
 [-Tag <Hashtable>] [-AsJob] [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByVirtualHubResourceId
```
Set-AzureRmVirtualHub -ResourceId <String> [-VirtualWan <PSVirtualWan>] [-VirtualWanId <String>]
 [-AddressPrefix <String>]
 [-HubVnetConnection <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection]>]
 [-Tag <Hashtable>] [-AsJob] [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByVirtualHubObject
```
Set-AzureRmVirtualHub -InputObject <PSVirtualHub> [-VirtualWan <PSVirtualWan>] [-VirtualWanId <String>]
 [-AddressPrefix <String>]
 [-HubVnetConnection <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection]>]
 [-Tag <Hashtable>] [-AsJob] [-Force] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Updates a Virtual Hub to an intended goal state.

## EXAMPLES

### Example 1
```powershell
```powershell
PS C:\> New-AzureRmResourceGroup -Location "West US" -Name "testRG"
PS C:\> $virtualWan = New-AzureRmVirtualWan -ResourceGroupName "testRG" -Name "myVirtualWAN" -Location "West US"
PS C:\> New-AzureRmVirtualHub -VirtualWan $virtualWan -ResourceGroupName "testRG" -Name “westushub” -AddressPrefix "10.0.1.0/24"
PS C:\> Set-AzureRmVirtualHub -VirtualWan $virtualWan -ResourceGroupName "testRG" -Name “westushub” -AddressPrefix "10.0.1.0/24"
```

The above will create a resource group "testRG", a Virtual WAN and a Virtual Hub in West US in that resource group in Azure. The virtual hub will have the address space "10.0.1.0/24".

It then updates the virtual

## PARAMETERS

### -AddressPrefix
The address space string for this virtual hub.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation if you want to overrite a resource

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HubVnetConnection
The hub virtual network connections associated with this Virtual Hub.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
The Virtual hub object to be modified.

```yaml
Type: PSVirtualHub
Parameter Sets: ByVirtualHubObject
Aliases: VirtualHub

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: ByVirtualHubName
Aliases: ResourceName, VirtualHubName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: ByVirtualHubName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource id of the Virtual hub to be modified.

```yaml
Type: String
Parameter Sets: ByVirtualHubResourceId
Aliases: VirtualHubId

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
A hashtable which represents resource tags.

```yaml
Type: Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualWan
The virtual wan object this hub is linked to.

```yaml
Type: PSVirtualWan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualWanId
The id of virtual wan object this hub is linked to.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Network.Models.PSVirtualHub

### Microsoft.Azure.Commands.Network.Models.PSVirtualWan

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.PSHubVirtualNetworkConnection, Microsoft.Azure.Commands.Network, Version=6.3.0.0, Culture=neutral, PublicKeyToken=null]]

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualHub

## NOTES

## RELATED LINKS
