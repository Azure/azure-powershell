---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: A3D60CF1-2E66-4EE5-9C68-932DD8DF80BD
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/new-azurermsecuregateway
schema: 2.0.0
---

# New-AzureRmSecureGateway

## SYNOPSIS
Creates a Secure Gateway

## SYNTAX

```
New-AzureRmSecureGateway -Name <String> -ResourceGroupName <String> -Location <String>
 [-VirtualNetworkName <String>]
 [-ApplicationRuleCollection <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSSecureGatewayApplicationRuleCollection]>]
 [-WorkspaceId <String> -WorkspacePrimaryKey <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzureRmSecureGateway** cmdlet creates an Azure secure gateway.

## EXAMPLES

### 1:  Create a secure gateway attached to a virtual network
```
New-AzureRmSecureGateway -Name "SecGw" -ResourceGroupName "rg" -Location centralus -VirtualNetworkName "vnet"
```

This example creates a secure gateway attached to virtual network "vnet" in the same resource group as the gateway.
Since no rules were specified, gateway will block all traffic (default behavior).

### 2:  Create a secure gateway which allows all HTTPS traffic and is not attached to a virtual network
```
$rule = New-AzureRmSecureGatewayApplicationRule -Name Rule1 -Priority 100 -Protocol HTTPS -TargetFqdn "*" -ActionType Allow
$ruleCollection = New-AzureRmSecureGatewayApplicationRuleCollection -Name RC -Priority 1000 -Rule $rule
New-AzureRmSecureGateway -Name "SecGw" -ResourceGroupName "rg" -Location centralus -ApplicationRuleCollection $ruleCollection
```

This example creates a secure gateway which allows all HTTPS traffic. This gateway is not attached to a particular virtual network, so no traffic can be sent to it.

### 3:  Create a secure gateway which allows HTTP(S) traffic to all .com addresses, uses Azure logging and is attached to a virtual network
```
$LoggingWorkspaceId = "00112233-0011-0011-0011-001122334455"
$LoggingPrimaryKey = "abcdefghijklm+nopqrstuvw/xyz+123=="
$rule = New-AzureRmSecureGatewayApplicationRule -Name Rule1 -Priority 100 -Protocol HTTP,HTTPS -TargetFqdn "*.com" -ActionType Allow
$ruleCollection = New-AzureRmSecureGatewayApplicationRuleCollection -Name RC -Priority 1000 -Rule $rule
New-AzureRmSecureGateway -Name "SecGw" -ResourceGroupName "rg" -Location centralus -ApplicationRuleCollection $ruleCollection -VirtualNetworkName vnetName -WorkspaceId $LoggingWorkspaceId -WorkspacePrimaryKey $LoggingPrimaryKey
```

This example creates a secure gateway attached to virtual network "vnet" in the same resource group as the gateway. It allows HTTP and HTTPS traffic to all .com domains. Gateway logs will be available for the specified workspace id.

## PARAMETERS

### -Name
Specifies the name of the secure gateway that this cmdlet creates.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of a resource group to contain the secure gateway.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Specifies the region for the secure gateway.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualNetworkName
Specifies the name of the virtual network for which secure gateway will be deployed. Virtual network and secure gateway must belong to the same resource group.

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

### -ApplicationRuleCollection
Specifies the collections of rules for the new secure gateway.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.PSSecureGatewayApplicationRuleCollection]
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceId
Specifies the workspace identifier for Azure logging. Workspace primary key must also be specified when this parameter is used.

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

### -WorkspacePrimaryKey
Specifies the primary key for Azure logging.

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
The credentials, account, tenant, and subscription used for communication with azure.

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
Forces the command to run without asking for user confirmation.

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

### -Tag
Key-value pairs in the form of a hash table. For example:

@{key0="value0";key1=$null;key2="value2"}

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
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
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
This cmdlet does not accept any input.

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSSecureGateway

## NOTES

## RELATED LINKS

[Get-AzureRmSecureGateway](./Get-AzureRmSecureGateway.md)

[Remove-AzureRmSecureGateway](./Remove-AzureRmSecureGateway.md)

[Set-AzureRmSecureGateway](./Set-AzureRmSecureGateway.md)
