---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/reset-azvpnsitelinkconnection
schema: 2.0.0
---

# Reset-AzVpnSiteLinkConnection

## SYNOPSIS
Reset a VPN Site Link Connection

## SYNTAX

### ByName (Default)
```
Reset-AzVpnSiteLinkConnection -ResourceGroupName <String> -VpnGatewayName <String> -VpnConnectionName <String>
 -Name <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByInputObject
```
Reset-AzVpnSiteLinkConnection -InputObject <PSVpnSiteLinkConnection> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceId
```
Reset-AzVpnSiteLinkConnection -ResourceId <String> [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Reset-AzVpnSiteLinkConnection** cmdlet resets your VPN Link Connection based on the VPN Site Link Connection Name, VPN Connection Name, VPN Gateway Name and Resource Group Name.

## EXAMPLES

### Example 1
```powershell
Reset-AzVpnSiteLinkConnection -ResourceGroupName test-rg -VpnGatewayName test-gateway -VpnConnectionName test-connection -ResourceName test-linkConnection
```

Resets the VPN Site Link Connection with the name "test-linkConnection" within the resource group "test-rg"

## PARAMETERS

### -AsJob
Run cmdlet in the background.

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

### -InputObject
The Vpn site link connection object.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVpnSiteLinkConnection
Parameter Sets: ByInputObject
Aliases: VpnSiteLinkConnection

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The Vpn site link connection name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: ResourceName, VpnSiteLinkConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The Azure resource ID of the Vpn site link connection which has to be reset.

```yaml
Type: System.String
Parameter Sets: ByResourceId
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VpnConnectionName
The Vpn connection name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: ParentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VpnGatewayName
The Vpn gateway name.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases: GrandParentName

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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### Microsoft.Azure.Commands.Network.Models.PSVpnSiteLinkConnection

### System.String

## OUTPUTS

## NOTES

## RELATED LINKS
