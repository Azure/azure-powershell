---
external help file: Az.ConnectedMachine-help.xml
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/get-azconnectedextensionmetadata
schema: 2.0.0
---

# Get-AzConnectedExtensionMetadata

## SYNOPSIS
Gets an Extension Metadata based on location, publisher, extensionType and version

## SYNTAX

### List (Default)
```
Get-AzConnectedExtensionMetadata -ExtensionType <String> -Location <String> -Publisher <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzConnectedExtensionMetadata -ExtensionType <String> -Location <String> -Publisher <String>
 [-SubscriptionId <String[]>] -Version <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets an Extension Metadata based on location, publisher, extensionType and version

## EXAMPLES

### Example 1: Get a list of machine extension metadata
```powershell
Get-AzConnectedExtensionMetadata -ExtensionType 'CustomScriptExtension' -Location 'eastus2euap' -Publisher 'Microsoft.HybridCompute'
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifi
                                                                                              edBy
---- ------------------- ------------------- ----------------------- ------------------------ --------------------
```

Get a list of machine extension metadata

### Example 2: Get a specific machine extension metadata
```powershell
Get-AzConnectedExtensionMetadata -ExtensionType 'CustomScriptExtension' -Location 'eastus2euap' -Publisher 'Microsoft.HybridCompute' -Version '1.10.10'
```

```output
Name SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifi
                                                                                              edBy
---- ------------------- ------------------- ----------------------- ------------------------ --------------------
```

Get a specific machine extension metadata

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IExtensionValue

## NOTES

## RELATED LINKS
