---
external help file: Az.DigitalTwins-help.xml
Module Name: Az.DigitalTwins
online version: https://learn.microsoft.com/powershell/module/az.digitaltwins/get-azdigitaltwinsprivateendpointconnection
schema: 2.0.0
---

# Get-AzDigitalTwinsPrivateEndpointConnection

## SYNOPSIS
Get private endpoint connection properties for the given private endpoint.

## SYNTAX

### List (Default)
```
Get-AzDigitalTwinsPrivateEndpointConnection -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDigitalTwinsPrivateEndpointConnection -Name <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDigitalTwinsPrivateEndpointConnection -InputObject <IDigitalTwinsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get private endpoint connection properties for the given private endpoint.

## EXAMPLES

### Example 1: List private endpoint connection properties for the digital twins instance.
```powershell
Get-AzDigitalTwinsPrivateEndpointConnection -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance
```

```output
Name                                 GroupId PrivateLinkServiceConnectionStateStatus ResourceGroupName
----                                 ------- --------------------------------------- -----------------
11c903a5-7b8a-4b86-812d-03f007dca6df {API}   Approved                                azps_test_group
```

List private endpoint connection properties for the digital twins instance.

### Example 2: Get private endpoint connection properties for the given private endpoint.
```powershell
Get-AzDigitalTwinsPrivateEndpointConnection -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -Name "11c903a5-7b8a-4b86-812d-03f007dca6df"
```

```output
Name                                 GroupId PrivateLinkServiceConnectionStateStatus ResourceGroupName
----                                 ------- --------------------------------------- -----------------
11c903a5-7b8a-4b86-812d-03f007dca6df {API}   Approved                                azps_test_group
```

Get private endpoint connection properties for the given private endpoint.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the private endpoint connection.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PrivateEndpointConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the DigitalTwinsInstance.

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

### -ResourceName
The name of the DigitalTwinsInstance.

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
The subscription identifier.

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

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20220531.IPrivateEndpointConnection

## NOTES

## RELATED LINKS
