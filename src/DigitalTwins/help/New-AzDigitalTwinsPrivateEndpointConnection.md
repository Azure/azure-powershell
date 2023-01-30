---
external help file:
Module Name: Az.DigitalTwins
online version: https://learn.microsoft.com/powershell/module/az.digitaltwins/new-azdigitaltwinsprivateendpointconnection
schema: 2.0.0
---

# New-AzDigitalTwinsPrivateEndpointConnection

## SYNOPSIS
Update the status of a private endpoint connection with the given name.

## SYNTAX

### CreateExpanded (Default)
```
New-AzDigitalTwinsPrivateEndpointConnection -Name <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-GroupId <String[]>] [-PrivateLinkServiceConnectionStateActionsRequired <String>]
 [-PrivateLinkServiceConnectionStateDescription <String>]
 [-PrivateLinkServiceConnectionStateStatus <PrivateLinkServiceConnectionStatus>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzDigitalTwinsPrivateEndpointConnection -InputObject <IDigitalTwinsIdentity> [-GroupId <String[]>]
 [-PrivateLinkServiceConnectionStateActionsRequired <String>]
 [-PrivateLinkServiceConnectionStateDescription <String>]
 [-PrivateLinkServiceConnectionStateStatus <PrivateLinkServiceConnectionStatus>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update the status of a private endpoint connection with the given name.

## EXAMPLES

### Example 1: Update the status of a private endpoint connection with the given name.
```powershell
New-AzDigitalTwinsPrivateEndpointConnection -Name "11c903a5-7b8a-4b86-812d-03f007dca6df" -ResourceGroupName azps_test_group -ResourceName azps-digitaltwins-instance -PrivateLinkServiceConnectionStateStatus 'Approved' -PrivateLinkServiceConnectionStateDescription "Approved by johndoe@company.com."
```

```output
Name                                 GroupId PrivateLinkServiceConnectionStateStatus ResourceGroupName
----                                 ------- --------------------------------------- -----------------
11c903a5-7b8a-4b86-812d-03f007dca6df {API}   Approved                                azps_test_group
```

Update the status of a private endpoint connection with the given name.
Please Create a Private Endpoint in `Azure Digital Twins` -\> `Networking` -\> `Private endpoint connections`.

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -GroupId
The list of group ids for the private endpoint connection.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

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
Parameter Sets: CreateViaIdentityExpanded
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
Parameter Sets: CreateExpanded
Aliases: PrivateEndpointConnectionName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkServiceConnectionStateActionsRequired
Actions required for a private endpoint connection.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkServiceConnectionStateDescription
The description for the current state of a private endpoint connection.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkServiceConnectionStateStatus
The status of a private endpoint connection.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Support.PrivateLinkServiceConnectionStatus
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the DigitalTwinsInstance.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded
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
Type: System.String
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.IDigitalTwinsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DigitalTwins.Models.Api20220531.IPrivateEndpointConnection

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IDigitalTwinsIdentity>`: Identity Parameter
  - `[EndpointName <String>]`: Name of Endpoint Resource.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: Location of DigitalTwinsInstance.
  - `[PrivateEndpointConnectionName <String>]`: The name of the private endpoint connection.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the DigitalTwinsInstance.
  - `[ResourceId <String>]`: The name of the private link resource.
  - `[ResourceName <String>]`: The name of the DigitalTwinsInstance.
  - `[SubscriptionId <String>]`: The subscription identifier.
  - `[TimeSeriesDatabaseConnectionName <String>]`: Name of time series database connection.

## RELATED LINKS

