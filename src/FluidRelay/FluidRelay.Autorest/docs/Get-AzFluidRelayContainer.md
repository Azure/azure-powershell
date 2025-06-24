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

### GetViaIdentityFluidRelayServer
```
Get-AzFluidRelayContainer -FluidRelayServerInputObject <IFluidRelayIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityResourceGroup
```
Get-AzFluidRelayContainer -FluidRelayServerName <String> -Name <String>
 -ResourceGroupInputObject <IFluidRelayIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
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

### -FluidRelayServerInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IFluidRelayIdentity
Parameter Sets: GetViaIdentityFluidRelayServer
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -FluidRelayServerName
The Fluid Relay server resource name.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityResourceGroup, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

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
Parameter Sets: Get, GetViaIdentityFluidRelayServer, GetViaIdentityResourceGroup
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

### -ResourceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IFluidRelayIdentity
Parameter Sets: GetViaIdentityResourceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### Microsoft.Azure.PowerShell.Cmdlets.FluidRelay.Models.IFluidRelayContainer

## NOTES

## RELATED LINKS

