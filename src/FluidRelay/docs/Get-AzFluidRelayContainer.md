---
external help file:
Module Name: Az.FluidRelay
online version: https://learn.microsoft.com/powershell/module/az.fluidrelay/get-azfluidrelaycontainer
schema: 2.0.0
---

# Get-AzFluidRelayContainer

## SYNOPSIS
Get a Fluid Relay container.

## SYNTAX

### List (Default)
```
Get-AzFluidRelayContainer -FluidRelayServerName <String> -ResourceGroup <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzFluidRelayContainer -FluidRelayServerName <String> -Name <String> -ResourceGroup <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzFluidRelayContainer -InputObject <IFluidRelayIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a Fluid Relay container.

## EXAMPLES

### Example 1: List Fluid Relay container.
```powershell
Get-AzFluidRelayContainer -FluidRelayServerName azps-fluidrelay -ResourceGroup azpstest-gp
```

```output
Name                                 CreationTime           LastAccessTime         ResourceGroupName
----                                 ------------           --------------         -----------------
eb4dd5f6-531f-44e1-86e3-759d39d1010c 2022-06-16 02:35:16 AM 2022-06-16 02:58:55 AM azpstest-gp
5affba7d-d288-42c9-9ed2-6d50fbf7ec98 2022-06-16 03:22:45 AM                        azpstest-gp
```

List Fluid Relay container.
Read and execute this document [Quickstart: Dice roller](https://learn.microsoft.com/en-us/azure/azure-fluid-relay/quickstarts/quickstart-dice-roll) to complete setup of the environment.

### Example 2:Get a Fluid Relay container.
```powershell
Get-AzFluidRelayContainer -FluidRelayServerName azps-fluidrelay -ResourceGroup azpstest-gp -Name eb4dd5f6-531f-44e1-86e3-759d39d1010c
```

```output
Name                                 CreationTime           LastAccessTime         ResourceGroupName
----                                 ------------           --------------         -----------------
eb4dd5f6-531f-44e1-86e3-759d39d1010c 2022-06-16 02:35:16 AM 2022-06-16 02:58:55 AM azpstest-gp
```

Get a Fluid Relay container.
Read and execute this document [Quickstart: Dice roller](https://learn.microsoft.com/en-us/azure/azure-fluid-relay/quickstarts/quickstart-dice-roll) to complete setup of the environment.

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

### -FluidRelayServerName
The Fluid Relay server resource name.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IFluidRelayIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The Fluid Relay container resource name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: FluidRelayContainerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroup
The resource group containing the resource.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription id (GUID) for this resource.

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IFluidRelayIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.Api20220601.IFluidRelayContainer

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IFluidRelayIdentity>: Identity Parameter
  - `[FluidRelayContainerName <String>]`: The Fluid Relay container resource name.
  - `[FluidRelayServerName <String>]`: The Fluid Relay server resource name.
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroup <String>]`: The resource group containing the resource.
  - `[SubscriptionId <String>]`: The subscription id (GUID) for this resource.

## RELATED LINKS

