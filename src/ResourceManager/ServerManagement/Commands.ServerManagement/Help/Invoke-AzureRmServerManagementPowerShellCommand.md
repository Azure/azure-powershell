---
external help file: Microsoft.Azure.Commands.ServerManagement.dll-Help.xml
ms.assetid: 1EA5F348-5EF4-4056-BA06-7B95E12E329D
online version: 
schema: 2.0.0
---

# Invoke-AzureRmServerManagementPowerShellCommand

## SYNOPSIS
Executes a Windows PowerShell script block on a node.

## SYNTAX

### ByName
```
Invoke-AzureRmServerManagementPowerShellCommand [-ResourceGroupName] <String> [-NodeName] <String>
 [-SessionName] <String> [-Command] <ScriptBlock> [-PowerShellSessionName <String>] [-RawOutput]
 [-InformationAction <ActionPreference>] [-InformationVariable <String>] [<CommonParameters>]
```

### BySession
```
Invoke-AzureRmServerManagementPowerShellCommand [-Session] <Session> [-Command] <ScriptBlock>
 [-PowerShellSessionName <String>] [-RawOutput] [-InformationAction <ActionPreference>]
 [-InformationVariable <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Invoke-AzureRmServerManagementPowerShellCommand** cmdlet executes a Windows PowerShell script block on a node managed by an Azure Server Management Gateway.

## EXAMPLES

### 1:
```

```

## PARAMETERS

### -ResourceGroupName
Specifies the name of the resource group that the node belongs to.

```yaml
Type: String
Parameter Sets: ByName
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NodeName
Specifies the name of the node to run the script block on.

```yaml
Type: String
Parameter Sets: ByName
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SessionName
Specifies the name of the session to manage the node.

```yaml
Type: String
Parameter Sets: ByName
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Command
Specifies the script block to run on the target node.

```yaml
Type: ScriptBlock
Parameter Sets: (All)
Aliases: 

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PowerShellSessionName
Specifies the name of the Windows PowerShell run space on the target node.

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

### -RawOutput
Indicates that the cmdlet returns the complete object that contains the output from the node.

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

### -Session
Specifies the **Session** object that this cmdlet uses to connect to the target node.

This parameter may be specified instead of the *ResourceGroupName*, *NodeName*, *SessionName*, and *PowerShellSessionName* parameters.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

## NOTES

## RELATED LINKS

[Azure Server Management Cmdlets](./AzureRM.ServerManagement.md)


