---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.dll-Help.xml
Module Name: Az.ServiceFabric
online version: https://learn.microsoft.com/powershell/module/az.servicefabric/add-azservicefabricmanagedclusternetworksecurityrule
schema: 2.0.0
---

# Add-AzServiceFabricManagedClusterNetworkSecurityRule

## SYNOPSIS
Add network security rule to cluster resource.

## SYNTAX

### ByObj (Default)
```
Add-AzServiceFabricManagedClusterNetworkSecurityRule [-InputObject] <PSManagedCluster>
 -Access <NetworkSecurityAccess> [-Description <String>] -DestinationAddressPrefix <String[]>
 -DestinationPortRange <String[]> -Direction <NetworkSecurityDirection> -Name <String> -Priority <Int32>
 -Protocol <NetworkSecurityProtocol> -SourceAddressPrefix <String[]> -SourcePortRange <String[]> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByName
```
Add-AzServiceFabricManagedClusterNetworkSecurityRule [-ResourceGroupName] <String> [-ClusterName] <String>
 -Access <NetworkSecurityAccess> [-Description <String>] -DestinationAddressPrefix <String[]>
 -DestinationPortRange <String[]> -Direction <NetworkSecurityDirection> -Name <String> -Priority <Int32>
 -Protocol <NetworkSecurityProtocol> -SourceAddressPrefix <String[]> -SourcePortRange <String[]> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Add network security rule to cluster resource. This will add network security rule with specified properties

## EXAMPLES

### Example 1
```powershell
$resourceGroupName = "sfmcps-test-rg"
$clusterName = "sfmcps-test-cluster"
$NSRName = "testSecRule1"
$sourcePortRanges = "1-1000"
$destinationPortRanges = "1-65535"
$destinationAddressPrefixes = "194.69.104.0/25", "194.69.119.64/26", "167.220.249.128/26", "255.255.255.255/32"
$sourceAddressPrefixes = "167.220.242.0/27", "167.220.0.0/23", "131.107.132.16/28", "167.220.81.128/26"

$cluster = Add-AzServiceFabricManagedClusterNetworkSecurityRule -ResourceGroupName $resourceGroupName -ClusterName $clusterName `
        -Name $NSRName -Access Allow -Direction Outbound -Protocol tcp -Priority 1200 -SourcePortRange $sourcePortRange -DestinationPortRange $destinationPortRanges -DestinationAddressPrefix $destinationAddressPrefixes -SourceAddressPrefix $sourceAddressPrefixes -Verbose
```

This command will add network security rule with properties above.

### Example 2
```powershell
$resourceGroupName = "sfmcps-test-rg"
$clusterName = "sfmcps-test-cluster"
$NSRName = "testSecRule2"
$sourcePortRanges = "1-1000"
$destinationPortRanges = "1-65535"
$destinationAddressPrefixes = "194.69.104.0/25", "194.69.119.64/26", "167.220.249.128/26", "255.255.255.255/32"
$sourceAddressPrefixes = "167.220.242.0/27", "167.220.0.0/23", "131.107.132.16/28", "167.220.81.128/26"

$cluster = Add-AzServiceFabricManagedClusterNetworkSecurityRule -ResourceGroupName $resourceGroupName -ClusterName $clusterName `
        -Name $NSRName -Access Deny -Direction Outbound -Protocol udp -Priority 1300 -SourcePortRange $sourcePortRange -DestinationPortRange $destinationPortRanges -DestinationAddressPrefix $destinationAddressPrefixes -SourceAddressPrefix $sourceAddressPrefixes -Verbose
```

Similar to Example1 with different properties.

### Example 3
```powershell
$resourceGroupName = "sfmcps-test-rg"
$clusterName = "sfmcps-test-cluster"
$NSRName = "testSecRule3"
$description = "test network security rule"
$sourcePortRanges = "1-1000"
$destinationPortRanges = "1-65535"
$destinationAddressPrefixes = "194.69.104.0/25", "194.69.119.64/26", "167.220.249.128/26", "255.255.255.255/32"
$sourceAddressPrefixes = "167.220.242.0/27", "167.220.0.0/23", "131.107.132.16/28", "167.220.81.128/26"

$cluster = $clusterFromGet | Add-AzServiceFabricManagedClusterNetworkSecurityRule `
        -Name $NSRName -Access Allow -Description $description -Direction Outbound -Protocol tcp -Priority 1400 -SourcePortRange $sourcePortRanges -DestinationPortRange $destinationPortRanges -DestinationAddressPrefix $destinationAddressPrefixes -SourceAddressPrefix $sourceAddressPrefixes -Verbose
```

This command will add a network security rule using cluster object with piping.

## PARAMETERS

### -Access
Gets or sets the network traffic is allowed or denied. Possible values include: Allow, Deny

```yaml
Type: Microsoft.Azure.Commands.ServiceFabric.Models.NetworkSecurityAccess
Parameter Sets: (All)
Aliases:
Accepted values: Allow, Deny

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background and return a Job to track progress

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

### -ClusterName
Specify the name of the cluster.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
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
Gets or sets network security rule description

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationAddressPrefix
Gets or sets the destination address prefixes. CIDR or destination IP ranges

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationPortRange
Gets or sets the destination port ranges

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Direction
Gets or sets network security rule direction. Possible values include: Inbound, Outbound

```yaml
Type: Microsoft.Azure.Commands.ServiceFabric.Models.NetworkSecurityDirection
Parameter Sets: (All)
Aliases:
Accepted values: Inbound, Outbound

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Managed cluster resource

```yaml
Type: Microsoft.Azure.Commands.ServiceFabric.Models.PSManagedCluster
Parameter Sets: ByObj
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Network Security Rule name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: NetworkSecurityRuleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Priority
Gets or sets the priority of the rule. The value can be in the range 1000 to 3000. Values outside this range are reserved for Service Fabric ManagerCluster Resource Provider. The priority number must be unique for each rule in the collection. The lower the priority number, the higher the priority of the rule

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Protocol
Gets or sets network protocol this rule applies to. Possible values include: http, https, tcp, udp, icmp, ah, esp, any

```yaml
Type: Microsoft.Azure.Commands.ServiceFabric.Models.NetworkSecurityProtocol
Parameter Sets: (All)
Aliases:
Accepted values: https, http, udp, tcp, esp, icmp, ah, any

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Specify the name of the resource group.

```yaml
Type: System.String
Parameter Sets: ByName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SourceAddressPrefix
Gets or sets the CIDR or source IP ranges

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourcePortRange
Run cmdlet in the background and return a Job to track progress

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

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

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.ServiceFabric.Models.PSManagedCluster

## NOTES

## RELATED LINKS
