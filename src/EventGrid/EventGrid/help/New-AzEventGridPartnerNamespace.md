---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# New-AzEventGridPartnerNamespace

## SYNOPSIS
Creates a new Event Grid partner namespace.

## SYNTAX

```
New-AzEventGridPartnerNamespace [-ResourceGroupName] <String> [-Name] <String> [-Location] <String>
 [-Tag <Hashtable>] [-PrivateEndpointConnection <PSPrivateEndpointConnection[]>]
 [-InboundIpRule <PSInboundIpRule[]>] [-PartnerRegistrationFullyQualifiedId <String>] [-Endpoint <String>]
 [-PublicNetworkAccess <String>] [-DisableLocalAuth <Boolean>] [-PartnerTopicRoutingMode <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new Event Grid partner namespace.

## EXAMPLES

### Example 1
```powershell
New-AzEventGridPartnerNamespace -ResourceGroupName MyResourceGroupName -Name PartnerNamespace1 -Location westus2 -PartnerRegistrationFullyQualifiedId 23e0092b-f336-4833-9ab3-9353a15650fc
```

Creates a new Event Grid partner namespace \`PartnerNamespace1\` in resource group \`MyResourceGroupName\`.

## PARAMETERS

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

### -DisableLocalAuth
Switch param to disable local auth.

```yaml
Type: Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Endpoint
Endpoint for the partner namespace

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

### -InboundIpRule
Array of PSInboundIpRule which represents list of inbound IP rules.
Each rule specifies the IP Address in CIDR notation e.g., 10.0.0.0/8 along with the corresponding Action to be performed based on the match or no match of the IpMask.
Possible Action values include Allow only

```yaml
Type: PSInboundIpRule[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Location of the partner namespace.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Event Grid partner namespace name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: PartnerNamespaceName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PartnerRegistrationFullyQualifiedId
Fully qualified ARM Id of the partner registration that should be associated with this partner namespace.
This takes the following format: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.EventGrid/partnerRegistrations/{partnerRegistrationName}.

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

### -PartnerTopicRoutingMode
Determines if events published to this partner namespace should use the source attribute in the event payload or use the channel name in the header when matching to the partner topic.
If none is specified, source attribute routing will be used to match the partner topic.
Possible values include: 'SourceEventAttribute', 'ChannelNameHeader'

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: SourceEventAttribute, ChannelNameHeader

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PrivateEndpointConnection
List of PSPrivateEndointConnection representing information about the private endpoint connections.

```yaml
Type: PSPrivateEndpointConnection[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PublicNetworkAccess
This determines if traffic is allowed over public network.
By default it is enabled.
You can further restrict to specific IPs by configuring InboundIpRule parameters.
Allowed values are disabled and enabled.

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

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ResourceGroup

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Hashtable which represents resource Tags.

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

### System.Collections.Hashtable

### Microsoft.Azure.Commands.EventGrid.Models.PSPrivateEndpointConnection[]

### Microsoft.Azure.Commands.EventGrid.Models.PSInboundIpRule[]

### System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerNamespace

## NOTES

## RELATED LINKS
