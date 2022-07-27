---
external help file:
Module Name: Az.SignalR
online version: https://docs.microsoft.com/powershell/module/az.signalr/get-azwebpubsubkey
schema: 2.0.0
---

# Get-AzWebPubSubKey

## SYNOPSIS
Get the access keys of the resource.

## SYNTAX

### List (Default)
```
Get-AzWebPubSubKey -ResourceGroupName <String> -ResourceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ListViaIdentity
```
Get-AzWebPubSubKey -InputObject <IWebPubSubIdentity> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Get the access keys of the resource.

## EXAMPLES

### Example 1: Get the access keys of a Web PubSub resource
```powershell
Get-AzWebPubSubKey -ResourceGroupName psdemo -ResourceName psdemo-wps  | Format-List
```

```output
PrimaryConnectionString   : Endpoint=https://psdemo-wps.webpubsub.azure.com;AccessKey=********;Version=1.0;
PrimaryKey                : ********
SecondaryConnectionString : Endpoint=https://psdemo-wps.webpubsub.azure.com;AccessKey=********;Version=1.0;
SecondaryKey              : ********
```

The example gets the access keys of the Web PubSub resource and then pipes the result to `Format-List` to see all the property values of the result.

### Example 2: Get the access keys of a Web PubSub resource via identity
```powershell
$wps = Get-AzWebPubSub -ResourceGroupName psdemo -ResourceName psdemo-wps
$wps | Get-AzWebPubSubKey | Format-List
```

```output
PrimaryConnectionString   : Endpoint=https://psdemo-wps.webpubsub.azure.com;AccessKey=********;Version=1.0;
PrimaryKey                : ********
SecondaryConnectionString : Endpoint=https://psdemo-wps.webpubsub.azure.com;AccessKey=********;Version=1.0;
SecondaryKey              : ********
```

The example gets the access keys of the Web PubSub resource and then pipes the result to `Format-List` to see all the property values of the result.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.IWebPubSubIdentity
Parameter Sets: ListViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceName
The name of the resource.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription Id which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.IWebPubSubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebPubSub.Models.Api20211001.IWebPubSubKeys

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IWebPubSubIdentity>`: Identity Parameter
  - `[HubName <String>]`: The hub name.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: the region
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[ResourceName <String>]`: The name of the resource.
  - `[SharedPrivateLinkResourceName <String>]`: The name of the shared private link resource
  - `[SubscriptionId <String>]`: Gets subscription Id which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

