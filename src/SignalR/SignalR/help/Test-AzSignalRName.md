---
external help file: Microsoft.Azure.PowerShell.Cmdlets.SignalR.dll-Help.xml
Module Name: Az.SignalR
online version:
schema: 2.0.0
---

# Test-AzSignalRName

## SYNOPSIS
Check the availability of a name.

## SYNTAX

```
Test-AzSignalRName [-Name] <String> [-Location] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Check the availability of a name.

## EXAMPLES

### Check a existed name.
```powershell
PS D:\azure-powershell\artifacts\Debug\Az.SignalR> Test-AzSignalRName -Name existedsignalr -Location eastus

NameAvailable Reason        Message
------------- ------        -------
        False AlreadyExists The name is already taken. Please try a different name.
```

### Check a unexisted name.
```powershell
PS C:\> Test-AzSignalRName unexistedsignalr eastus

NameAvailable Reason Message
------------- ------ -------
         True
```

## PARAMETERS

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

### -Location
The SignalR service location.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The SignalR service name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.SignalR.Models.PSNameAvailability

## NOTES

## RELATED LINKS
