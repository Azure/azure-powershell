---
external help file:
Module Name: Az.AppService
online version: https://docs.microsoft.com/en-us/powershell/module/az.appservice/switch-azwebappslot
schema: 2.0.0
---

# Switch-AzWebAppSlot

## SYNOPSIS
Swaps two deployment slots of an app.

## SYNTAX

### SwapExpanded1 (Default)
```
Switch-AzWebAppSlot -Name <String> -ResourceGroupName <String> -SubscriptionId <String> -PreserveVnet
 -TargetSlot <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Swap
```
Switch-AzWebAppSlot -Name <String> -ResourceGroupName <String> -Slot <String> -SubscriptionId <String>
 -SlotSwapEntity <ICsmSlotEntity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### Swap1
```
Switch-AzWebAppSlot -Name <String> -ResourceGroupName <String> -SubscriptionId <String>
 -SlotSwapEntity <ICsmSlotEntity> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### SwapExpanded
```
Switch-AzWebAppSlot -Name <String> -ResourceGroupName <String> -Slot <String> -SubscriptionId <String>
 -PreserveVnet -TargetSlot <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### SwapViaIdentity
```
Switch-AzWebAppSlot -InputObject <IAppServiceIdentity> -SlotSwapEntity <ICsmSlotEntity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SwapViaIdentity1
```
Switch-AzWebAppSlot -InputObject <IAppServiceIdentity> -SlotSwapEntity <ICsmSlotEntity>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SwapViaIdentityExpanded
```
Switch-AzWebAppSlot -InputObject <IAppServiceIdentity> -PreserveVnet -TargetSlot <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SwapViaIdentityExpanded1
```
Switch-AzWebAppSlot -InputObject <IAppServiceIdentity> -PreserveVnet -TargetSlot <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Swaps two deployment slots of an app.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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
Dynamic: False
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
Dynamic: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.IAppServiceIdentity
Parameter Sets: SwapViaIdentity, SwapViaIdentity1, SwapViaIdentityExpanded, SwapViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
Name of the app.

```yaml
Type: System.String
Parameter Sets: Swap, Swap1, SwapExpanded, SwapExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -PreserveVnet
\<code\>true\</code\> to preserve Virtual Network to the slot during swap; otherwise, \<code\>false\</code\>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SwapExpanded, SwapExpanded1, SwapViaIdentityExpanded, SwapViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Swap, Swap1, SwapExpanded, SwapExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Slot
Name of the source slot.
If a slot is not specified, the production slot is used as the source slot.

```yaml
Type: System.String
Parameter Sets: Swap, SwapExpanded
Aliases: SourceSlotName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SlotSwapEntity
Deployment slot parameters.
To construct, see NOTES section for SLOTSWAPENTITY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ICsmSlotEntity
Parameter Sets: Swap, Swap1, SwapViaIdentity, SwapViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Swap, Swap1, SwapExpanded, SwapExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TargetSlot
Destination deployment slot during swap operation.

```yaml
Type: System.String
Parameter Sets: SwapExpanded, SwapExpanded1, SwapViaIdentityExpanded, SwapViaIdentityExpanded1
Aliases: DestinationSlotName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.Api20180201.ICsmSlotEntity

### Microsoft.Azure.PowerShell.Cmdlets.AppService.Models.IAppServiceIdentity

## OUTPUTS

### System.Boolean

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### INPUTOBJECT <IAppServiceIdentity>: Identity Parameter
  - `[AnalysisName <String>]`: Analysis Name
  - `[ApiName <String>]`: The managed API name.
  - `[BackupId <String>]`: ID of the backup.
  - `[BaseAddress <String>]`: Module base address.
  - `[CertificateOrderName <String>]`: Name of the certificate order.
  - `[ConnectionName <String>]`: The connection name.
  - `[DeletedSiteId <String>]`: The numeric ID of the deleted app, e.g. 12345
  - `[DetectorName <String>]`: Detector Resource Name
  - `[DiagnosticCategory <String>]`: Diagnostic Category
  - `[DiagnosticsName <String>]`: Name of the diagnostics item.
  - `[DomainName <String>]`: Name of the domain.
  - `[DomainOwnershipIdentifierName <String>]`: Name of domain ownership identifier.
  - `[EntityName <String>]`: Name of the hybrid connection.
  - `[FunctionName <String>]`: Function name.
  - `[GatewayName <String>]`: Name of the gateway. Only the 'primary' gateway is supported.
  - `[HostName <String>]`: Hostname in the hostname binding.
  - `[HostingEnvironmentName <String>]`: Name of the hosting environment.
  - `[Id <String>]`: Resource identity path
  - `[Instance <String>]`: Name of the instance in the multi-role pool.
  - `[InstanceId <String>]`: ID of web app instance.
  - `[Location <String>]`: 
  - `[Name <String>]`: Name of the certificate.
  - `[NamespaceName <String>]`: Name of the Service Bus namespace.
  - `[OperationId <String>]`: GUID of the operation.
  - `[PremierAddOnName <String>]`: Add-on name.
  - `[ProcessId <String>]`: PID.
  - `[PublicCertificateName <String>]`: Public certificate name.
  - `[RelayName <String>]`: Name of the Service Bus relay.
  - `[ResourceGroupName <String>]`: Name of the resource group to which the resource belongs.
  - `[RouteName <String>]`: Name of the Virtual Network route.
  - `[SiteExtensionId <String>]`: Site extension name.
  - `[SiteName <String>]`: Site Name
  - `[Slot <String>]`: Name of web app slot. If not specified then will default to production slot.
  - `[SnapshotId <String>]`: The ID of the snapshot to read.
  - `[SourceControlType <String>]`: Type of source control
  - `[SubscriptionId <String>]`: Your Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000).
  - `[ThreadId <String>]`: TID.
  - `[View <String>]`: The type of view. This can either be "summary" or "detailed".
  - `[VnetName <String>]`: Name of the Virtual Network.
  - `[WebJobName <String>]`: Name of Web Job.
  - `[WorkerName <String>]`: Name of worker machine, which typically starts with RD.
  - `[WorkerPoolName <String>]`: Name of the worker pool.

#### SLOTSWAPENTITY <ICsmSlotEntity>: Deployment slot parameters.
  - `PreserveVnet <Boolean>`: <code>true</code> to preserve Virtual Network to the slot during swap; otherwise, <code>false</code>.
  - `TargetSlot <String>`: Destination deployment slot during swap operation.

## RELATED LINKS

