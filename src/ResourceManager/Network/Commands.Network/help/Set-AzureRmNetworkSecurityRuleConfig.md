---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
ms.assetid: 7EFFFF43-501E-4955-A4EE-2C09B8863B30
online version: 
schema: 2.0.0
---

# Set-AzureRmNetworkSecurityRuleConfig

## SYNOPSIS
Sets the goal state for a network security rule configuration.

## SYNTAX

```
Set-AzureRmNetworkSecurityRuleConfig -Name <String> -NetworkSecurityGroup <PSNetworkSecurityGroup>
 [-Description <String>] [-Protocol <String>] [-SourcePortRange <String>] [-DestinationPortRange <String>]
 [-SourceAddressPrefix <String>] [-DestinationAddressPrefix <String>] [-Access <String>] [-Priority <Int32>]
 [-Direction <String>] [-InformationAction <ActionPreference>] [-InformationVariable <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmNetworkSecurityRuleConfig** cmdlet sets the goal state for an Azure network security rule configuration.

## EXAMPLES

### Example 1: Change the access configuration in a network security rule
```
PS C:\>$nsg = Get-AzureRmNetworkSecurityGroup -Name "NSG-FrontEnd" -ResourceGroupName "TestRG"
PS C:\> $nsg | Get-AzureRmNetworkSecurityRuleConfig -Name "rdp-rule"
PS C:\> Set-AzureRmNetworkSecurityRuleConfig -Name "rdp-rule" -NetworkSecurityGroup $nsg -Access "Deny"
```

The first command gets the network security group named NSG-FrontEnd, and then stores it in the variable $nsg.

The second command uses the pipeline operator to pass the security group in $nsg to Get-AzureRmNetworkSecurityRuleConfig, which gets the security rule configuration named rdp-rule.

The third command changes the access configuration of rdp-rule to Deny.

## PARAMETERS

### -Name
Specifies the name of the network security rule configuration that this cmdlet sets.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkSecurityGroup
Specifies the **NetworkSecurityGroup** object that contains the network security rule configuration to set.

```yaml
Type: PSNetworkSecurityGroup
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Description
Specifies a description for a rule configuration.
The maximum size is 140 characters.

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

### -Protocol
Specifies the network protocol that a rule configuration applies to.
The acceptable values for this parameter are:

 --Tcp
- Udp
- A wildcard character (*) to match both

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

### -SourcePortRange
Specifies the source port or range.
The acceptable values for this parameter are:

- An integer
- A range of integers between 0 and 65535
- A wildcard character (*) to match any port

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

### -DestinationPortRange
Specifies a destination port or range.
The acceptable values for this parameter are:

- An integer 
- A range of integers between 0 and 65535
- A wildcard character (*) to match any port

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

### -SourceAddressPrefix
Specifies a source address prefix.
The acceptable values for this parameter are:

- A CIDR
- A source IP range
- A wildcard character (*) to match any IP address

You can also use tags such as VirtualNetwork, AzureLoadBalancer and Internet.

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

### -DestinationAddressPrefix
Specifies a destination address prefix.
The acceptable values for this parameter are:

- A Classless Interdomain Routing (CIDR) address 
- A destination IP address range 
- A wildcard character (*) to match any IP address

You can use tags such as VirtualNetwork, AzureLoadBalancer, and Internet.

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

### -Access
Specifies whether network traffic is allowed or denied. 
The acceptable values for this parameter are: Allow and Deny.

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

### -Priority
Specifies the priority of a rule configuration.
The acceptable values for this parameter are:An integer between 100 and 4096.

The priority number must be unique for each rule in the collection.
The lower the priority number, the higher the priority of the rule.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Direction
Specifies whether a rule is evaluated for incoming or outgoing traffic.
The acceptable values for this parameter are: Inbound and Outbound.

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

### -InformationAction
Specifies how this cmdlet responds to an information event.

The acceptable values for this parameter are:

- Continue
- Ignore
- Inquire
- SilentlyContinue
- Stop
- Suspend

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: infa

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InformationVariable
Specifies an information variable.

```yaml
Type: String
Parameter Sets: (All)
Aliases: iv

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Add-AzureRmNetworkSecurityRuleConfig](./Add-AzureRmNetworkSecurityRuleConfig.md)

[Get-AzureRmNetworkSecurityRuleConfig](./Get-AzureRmNetworkSecurityRuleConfig.md)

[New-AzureRmNetworkSecurityRuleConfig](./New-AzureRmNetworkSecurityRuleConfig.md)

[Remove-AzureRmNetworkSecurityRuleConfig](./Remove-AzureRmNetworkSecurityRuleConfig.md)


