---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzNetworkManagerSecurityAdminRule

## SYNOPSIS
Creates a security admin rule.

## SYNTAX

### Custom (Default)
```
New-AzNetworkManagerSecurityAdminRule -Name <String> -RuleCollectionName <String>
 -SecurityAdminConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 [-Description <String>] -Protocol <String> -Direction <String> -Access <String>
 [-Source <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem]>]
 [-Destination <System.Collections.Generic.List`1[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem]>]
 [-SourcePortRange <System.Collections.Generic.List`1[System.String]>]
 [-DestinationPortRange <System.Collections.Generic.List`1[System.String]>] -Priority <Int32> [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Default
```
New-AzNetworkManagerSecurityAdminRule -Name <String> -RuleCollectionName <String>
 -SecurityAdminConfigurationName <String> -NetworkManagerName <String> -ResourceGroupName <String>
 -Flag <String> [-Force] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzNetworkManagerSecurityAdminRule** cmdlet creates a security admin rule.

## EXAMPLES


### Example 1: Create Custom Security Admin Rule
```powershell
PS C:\> $sourceAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "Internet" -AddressPrefixType "ServiceTag"
PS C:\> $destinationAddressPrefix = New-AzNetworkManagerAddressPrefixItem -AddressPrefix "10.0.0.1" -AddressPrefixType "IPPrefix" 
PS C:\> [System.Collections.Generic.List[string]]$sourcePortList = @()
PS C:\> $sourcePortList.Add("100")
PS C:\> [System.Collections.Generic.List[String]]$destinationPortList = @()
PS C:\> $destinationPortList.Add("99");
PS C:\> New-AzNetworkManagerSecurityAdminRule -ResourceGroupName TestRGName -NetworkManagerName TestNMName -ConfigName TestAdminConfigName  -RuleCollectionName TestRuleCollectionName -Name TestRuleName -Description "TestDescription" -Protocol  "TCP" -Direction "Inbound" -Access "Allow" -Priority 100 -SourcePortRange $sourcePortList -DestinationPortRange $destinationPortList -Source $sourceAddressPrefix -Destination $destinationAddressPrefix 

```

### Example 2: Create Default Security Admin Rule
```powershell
PS C:\> New-AzNetworkManagerSecurityAdminRule -ResourceGroupName TestRGName -NetworkManagerName TestNMName -ConfigName TestAdminConfigName  -RuleCollectionName TestRuleCollectionName -Name TestRuleName -Flag "TestFlag"

```

## PARAMETERS

### -Access
Access of Rule.

```yaml
Type: String
Parameter Sets: Custom
Aliases:

Required: True
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
Type: String
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
Type: String
Parameter Sets: Custom
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Flag
Default Flag Type.

```yaml
Type: String
Parameter Sets: Default
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
Do not ask for confirmation if you want to overwrite a resource

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

### -Name
The resource name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -NetworkManagerName
The network manager name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -Priority
Priority of Rule.

```yaml
Type: Int32
Parameter Sets: Custom
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
Type: String
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
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RuleCollectionName
The network manager security admin rule collection name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -SecurityAdminConfigurationName
The network manager security admin configuration name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ConfigName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
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

### System.String

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerAddressPrefixItem, Microsoft.Azure.PowerShell.Cmdlets.Network, Version=4.16.1.0, Culture=neutral, PublicKeyToken=null]]

### System.Collections.Generic.List`1[[System.String, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.Int32

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.NetworkManager.PSNetworkManagerSecurityBaseAdminRule

## NOTES

## RELATED LINKS

[Get-AzNetworkManagerSecurityAdminRule](./Get-AzNetworkManagerSecurityAdminRule.md)

[Remove-AzNetworkManagerSecurityAdminRule](./Remove-AzNetworkManagerSecurityAdminRule.md)

[Set-AzNetworkManagerSecurityAdminRule](./Set-AzNetworkManagerSecurityAdminRule.md)