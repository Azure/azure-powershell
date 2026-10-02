---
external help file:
Module Name: Az.ConnectedMachine
online version: https://learn.microsoft.com/powershell/module/az.connectedmachine/get-azconnectedextensionpublisher
schema: 2.0.0
---

# Get-AzConnectedExtensionPublisher

## SYNOPSIS
Gets all Extension publishers based on the location

## SYNTAX

```
Get-AzConnectedExtensionPublisher -Location <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets all Extension publishers based on the location

## EXAMPLES

### Example 1: Get all extension publishers for a location
```powershell
Get-AzConnectedExtensionPublisher -Location 'eastus'
```

```output
Name
----
Microsoft.Azure.NetworkWatcher
Microsoft.HybridCompute
Microsoft.Azure.Monitor
```

Gets all extension publishers available in the specified Azure region.

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

### -Location
The name of the Azure region.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ConnectedMachine.Models.IExtensionPublisher

## NOTES

## RELATED LINKS

