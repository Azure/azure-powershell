---
external help file: Az.ConnectedMachine-help.xml
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/get-azconnectedextensionmetadatav2
schema: 2.0.0
---

# Get-AzConnectedExtensionMetadataV2

## SYNOPSIS
Gets an Extension Metadata based on location, publisher, extensionType and version

## SYNTAX

### List (Default)
```
Get-AzConnectedExtensionMetadataV2 -ExtensionType <String> -Location <String> -Publisher <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzConnectedExtensionMetadataV2 -ExtensionType <String> -Location <String> -Publisher <String>
 -Version <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets an Extension Metadata based on location, publisher, extensionType and version

## EXAMPLES

### Example 1: Get a list of extension metadata
```powershell
Get-AzConnectedExtensionMetadataV2 -ExtensionType 'NetworkWatcherAgentWindows' -Location 'eastus' -Publisher 'Microsoft.Azure.NetworkWatcher'
```

```output
Name
----
```

Gets all versions of extension metadata for the specified extension type and publisher.

### Example 2: Get a specific extension metadata version
```powershell
Get-AzConnectedExtensionMetadataV2 -ExtensionType 'NetworkWatcherAgentWindows' -Location 'eastus' -Publisher 'Microsoft.Azure.NetworkWatcher' -Version '1.4.2798.3'
```

```output
Name
----
```

Gets extension metadata for a specific version.

{{ Add description here }}

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionType
The extensionType of the Extension being received.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the Extension being received.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Publisher
The publisher of the Extension being received.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
The version of the Extension being received.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IExtensionValueV2

## NOTES

## RELATED LINKS
