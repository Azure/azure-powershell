---
external help file: Microsoft.Azure.Commands.Relay.dll-Help.xml
online version: 
schema: 2.0.0
---

# New-AzureRmRelayHybridConnection

## SYNOPSIS
Creates a HybridConnection in the specified Relay namespace.

## SYNTAX

```
New-AzureRmRelayHybridConnection [-ResourceGroupName] <String> [-NamespaceName] <String>
 [-HybridConnectionsName] <String> [-HybridConnectionsObj <HybridConnectionAttibutes>]
 [-RequiresClientAuthorization <Boolean>] [-UserMetadata <String>] [-WhatIf] [-Confirm]
```

## DESCRIPTION
The **New-AzureRmRelayHybridConnection** cmdlet creates a HybridConnection in the specified Relay namespace.

## EXAMPLES

### Example 1
```
PS C:\> New-AzureRmRelayHybridConnection -ResourceGroup Default-ServiceBus-WestUS -NamespaceName TestNameSpace-Relay1 -HybridConnectionsName TestHybridConnection -RequiresClientAuthorization $True -UserMetadata "User Meta data"
```

Creates a new HybridConnection `TestHybridConnection` in the specified Relay namespace `TestNameSpace-Relay1`.

## PARAMETERS

### -HybridConnectionsName
HybridConnections Name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -HybridConnectionsObj
HybridConnections object.

```yaml
Type: HybridConnectionAttibutes
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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
true if client authorization is needed for this HybridConnections; otherwise, false

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

### -HybridConnectionsName
	System.String

### -RequiresClientAuthorization
	System.Boolean

### -UserMetadata
	System.String

## OUTPUTS
### Microsoft.Azure.Commands.Relay.Models.HybridConnectionAttibutes

CreatedAt                   : 4/12/2017 3:17:02 AM
UpdatedAt                   : 4/12/2017 3:17:02 AM
ListenerCount               :
RequiresClientAuthorization : True
UserMetadata                : User Meta data
Id                          : /subscriptions/854d368f-1828-428f-8f3c-f2affa9b2f7d/resourceGroups/Default-ServiceBus-WestUS/providers/Microsoft.Relay/namespaces/TestNameSpace-Relay1/H
                              ybridConnections/TestHybridConnection
Name                        : TestHybridConnection
Type                        : Microsoft.Relay/HybridConnections

## NOTES

## RELATED LINKS

