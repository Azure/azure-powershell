---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-aznetworkmanagersecurityuserrule
schema: 2.0.0
---

# New-AzNetworkManagerSecurityUserRule

## SYNOPSIS
Creates a security user rule.

## SYNTAX

### Custom (Default)
```
New-AzNetworkManagerSecurityUserRule -Name <String> -RuleCollectionName <String>
 -SecurityUserConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-DisplayName <String>] [-Description <String>] -Protocol <String> -Direction <String>
 [-Source <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem]>]
 [-Destination <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem]>]
 [-SourcePortRange <System.Collections.Generic.List`1[System.String]>]
 [-DestinationPortRange <System.Collections.Generic.List`1[System.String]>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Default
```
New-AzNetworkManagerSecurityUserRule -Name <String> -RuleCollectionName <String>
 -SecurityUserConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-Flag <String>] [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerSecurityUserRule** cmdlet creates a security user rule.

## EXAMPLES

### Example 1: Create Custom Security User Rule
```powershell
PS C:\> $sourceAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "Internet" -AddressPrefixType "ServiceTag"
PS C:\> $destinationAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "10.0.0.1" -AddressPrefixType "IPPrefix" 
PS C:\> [System.Collections.Generic.List[string]]$sourcePortList = @()
PS C:\> $sourcePortList.Add("100")
PS C:\> [System.Collections.Generic.List[String]]$destinationPortList = @()
PS C:\> $destinationPortList.Add("99");
PS C:\> New-AzNetworkManagerSecurityUserRule -ResourceGroupName TestRGName -NetworkManagerName TestNMName -ConfigName TestAdminConfigName  -RuleCollectionName TestRuleCollectionName -Name TestRuleName -DisplayName "TestDisplayName" -Description "TestDescription" -Protocol  "TCP" -Direction "Inbound" -SourcePortRange $sourcePortList -DestinationPortRange $destinationPortList -Source $sourceAddressPrefix -Destination $destinationAddressPrefix 

```

### Example 2: Create Default Security User Rule
```powershell
PS C:\> New-AzNetworkManagerSecurityUserRule -ResourceGroupName TestRGName -NetworkManagerName TestNMName -ConfigName TestAdminConfigName  -RuleCollectionName TestRuleCollectionName -Name TestRuleName -Flag "TestFlag"

```


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

### -Description
Description.

```yaml
Type: System.String
Parameter Sets: Custom
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Destination
Destination Address Prefixes.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem]
Parameter Sets: Custom
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DestinationPortRange
Destination Port Ranges.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: Custom
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Direction
Direction of Rule.

```yaml
Type: System.String
Parameter Sets: Custom
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DisplayName
DisplayName.

```yaml
Type: System.String
Parameter Sets: Custom
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Flag
Default Flag Type.

```yaml
Type: System.String
Parameter Sets: Default
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -Name
The resource name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NetworkManagerName
The network manager name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Protocol
Protocol of Rule.

```yaml
Type: System.String
Parameter Sets: Custom
Aliases:

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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RuleCollectionName
The network manager security user rule collection name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SecurityUserConfigurationName
The network manager security user configuration name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ConfigName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Source
Source Address Prefixes.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem]
Parameter Sets: Custom
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SourcePortRange
Source Port Ranges.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: Custom
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

### System.String

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem, Microsoft.Azure.PowerShell.Cmdlets.Network, Version=4.11.0.0, Culture=neutral, PublicKeyToken=null]]

### System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityBaseUserRule

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerSecurityUserRule](./Get-AzNetworkManagerSecurityUserRule.md)

[Remove-AzNetworkManagerSecurityUserRule](./Remove-AzNetworkManagerSecurityUserRule.md)

[Set-AzNetworkManagerSecurityUserRule](./Set-AzNetworkManagerSecurityUserRule.md)