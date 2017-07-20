---
external help file: Microsoft.Azure.Commands.ServerManagement.dll-Help.xml
ms.assetid: 8942D757-B204-49CE-BCDE-68C3722913B3
online version: 
schema: 2.0.0
---

# Get-AzureRmServerManagementSession

## SYNOPSIS
Gets a Server Management session.

## SYNTAX

### ByNodeName
```
Get-AzureRmServerManagementSession [-ResourceGroupName] <String> [-NodeName] <String> [-SessionName] <String>
 [<CommonParameters>]
```

### BySession
```
Get-AzureRmServerManagementSession [[-SessionName] <String>] [-Session] <Session> [<CommonParameters>]
```

### ByNode
```
Get-AzureRmServerManagementSession [-Node] <Node> [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzureRmServerManagementSession** cmdlet gets a single Azure Server Management session.

## EXAMPLES

### 1:
```

```

## PARAMETERS

### -Node
Specifies an existing **Node** object that is used to get the *ResourceGroupName* and the *NodeName* parameters.
You must also specify a value for the *SessionName* parameter.

```yaml
Type: Node
Parameter Sets: ByNode
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NodeName
Specifies the name of the node where the session is located.

```yaml
Type: String
Parameter Sets: ByNodeName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group for which this cmdlet gets the retrieve the session.

```yaml
Type: String
Parameter Sets: ByNodeName
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Session
Specifies an existing **Session** object that is used to get the *ResourceGroupName*, the *NodeName*, and the *SessionName* parameters.

```yaml
Type: Session
Parameter Sets: BySession
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SessionName
Specifies the name of the session in which this cmdlet gets.

```yaml
Type: String
Parameter Sets: ByNodeName
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

```yaml
Type: String
Parameter Sets: BySession
Aliases: 

Required: False
Position: 2
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

[Azure Server Management Cmdlets](./AzureRM.ServerManagement.md)


