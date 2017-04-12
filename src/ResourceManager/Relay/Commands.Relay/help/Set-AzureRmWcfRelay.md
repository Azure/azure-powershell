---
external help file: Microsoft.Azure.Commands.Relay.dll-Help.xml
online version: 
schema: 2.0.0
---

# Set-AzureRmWcfRelay

## SYNOPSIS
Updates the description of a WcfRelay in the specified Relay namespace.

## SYNTAX

```
Set-AzureRmWcfRelay [-ResourceGroupName] <String> [-NamespaceName] <String> [-WcfRelayName] <String>
 [-WcfRelayObj <WcfRelayAttributes>] [-WcfRelayType <String>] [-RequiresClientAuthorization <Boolean>]
 [-RequiresTransportSecurity <Boolean>] [-UserMetadata <String>] [-WhatIf] [-Confirm]
```

## DESCRIPTION
The **Set-AzureRmWcfRelay** cmdlet updates the description for the WcfRelay in the specified Relay namespace.

## EXAMPLES

### Example 1
```
PS C:\>
PS C:\> $getWcfRelay = Get-AzureRmWcfRelay -ResourceGroup Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -WcfRelayName TestWCFRelay
PS C:\> $getWcfRelay.UserMetadata = "usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store  desc
riptive data, such as list of teams and their contact information also user-defined configuration settings can be stored."
PS C:\> Set-AzureRmWcfRelay -ResourceGroup Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -WcfRelayName TestWCFRelay1 -WcfRelayObj $getWcfRelay
```

Updates the specified WcfRelay with a new description in the specified namespace. This example updates the **UserMetadata** property with new value.

## PARAMETERS

### -NamespaceName
Namespace Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RequiresClientAuthorization
true if client authorization is needed for this relay; otherwise, false

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

### -RequiresTransportSecurity
true if transport security is needed for this relay; otherwise, false

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

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UserMetadata
Gets or sets usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g.
it can be used to store  descriptive data, such as list of teams and their contact information also user-defined configuration settings can be stored.

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

### -WcfRelayName
WcfRelay Name.

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

### -WcfRelayObj
WcfRelay object.

```yaml
Type: WcfRelayAttributes
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WcfRelayType
WcfRelay Type.
Possible values include: 'NetTcp' or 'Http'

```yaml
Type: String
Parameter Sets: (All)
Aliases: 
Accepted values: NetTcp, Http

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

### -ResourceGroup
 System.String
 

### -NamespaceName
 System.String
 

### -WcfRelayName
 System.String 
 
### -WcfRelayObj
 Microsoft.Azure.Commands.Relay.Models.WcfRelayAttributes

## OUTPUTS
### Microsoft.Azure.Commands.Relay.Models.WcfRelayAttributes

RelayType                   : NetTcp
CreatedAt                   :
UpdatedAt                   :
ListenerCount               :
RequiresClientAuthorization : True
RequiresTransportSecurity   : True
IsDynamic                   :
UserMetadata                : usermetadata is a placeholder to store user-defined string data for the HybridConnection endpoint.e.g. it can be used to store  descriptive data, such
                              as list of teams and their contact information also user-defined configuration settings can be stored.
Id                          : /subscriptions/854d368f-1828-428f-8f3c-f2affa9b2f7d/resourceGroups/Default-ServiceBus-WestUS/providers/Microsoft.Relay/namespaces/TestNameSpace-Relay1/W
                              cfRelays/TestWCFRelay1
Name                        : TestWCFRelay1
Type                        : Microsoft.Relay/WcfRelays

## NOTES

## RELATED LINKS

