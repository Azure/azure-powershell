---
external help file: Az.Discovery-help.xml
Module Name: Az.Discovery
online version: https://learn.microsoft.com/powershell/module/az.discovery/get-azdiscoverybookshelfprivateendpointconnection
schema: 2.0.0
---

# Get-AzDiscoveryBookshelfPrivateEndpointConnection

## SYNOPSIS
Gets the specified private endpoint connection associated with the bookshelf.

## SYNTAX

### List (Default)
```
Get-AzDiscoveryBookshelfPrivateEndpointConnection -BookshelfName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDiscoveryBookshelfPrivateEndpointConnection -BookshelfName <String>
 -PrivateEndpointConnectionName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityBookshelf
```
Get-AzDiscoveryBookshelfPrivateEndpointConnection -PrivateEndpointConnectionName <String>
 -BookshelfInputObject <IDiscoveryIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDiscoveryBookshelfPrivateEndpointConnection -InputObject <IDiscoveryIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the specified private endpoint connection associated with the bookshelf.

## EXAMPLES

### Example 1: List private endpoint connections for a bookshelf
```powershell
Get-AzDiscoveryBookshelfPrivateEndpointConnection -ResourceGroupName "my-rg" -BookshelfName "my-bookshelf"
```

```output
Name                    ResourceGroupName    ProvisioningState
----                    -----------------    -----------------
my-pe-connection        my-rg                Succeeded
```

Lists all private endpoint connections for the specified bookshelf.

## PARAMETERS

### -BookshelfInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity
Parameter Sets: GetViaIdentityBookshelf
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -BookshelfName
The name of the Bookshelf

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PrivateEndpointConnectionName
The name of the private endpoint connection associated with the Azure resource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityBookshelf
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IDiscoveryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Discovery.Models.IBookshelfPrivateEndpointConnection

## NOTES

## RELATED LINKS
