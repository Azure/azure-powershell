---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/update-aznetworkcloudbaremetalmachine
schema: 2.0.0
---

# Update-AzNetworkCloudBareMetalMachine

## SYNOPSIS
Reimage the provided bare metal machine.

## SYNTAX

### Reimage (Default)
```
Update-AzNetworkCloudBareMetalMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReimageViaIdentity
```
Update-AzNetworkCloudBareMetalMachine -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Replace
```
Update-AzNetworkCloudBareMetalMachine -Name <String> -ResourceGroupName <String>
 -BareMetalMachineReplaceParameter <IBareMetalMachineReplaceParameters> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReplaceExpanded
```
Update-AzNetworkCloudBareMetalMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-BmcCredentialsPassword <String>] [-BmcCredentialsUsername <String>] [-BmcMacAddress <String>]
 [-BootMacAddress <String>] [-MachineName <String>] [-SerialNumber <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReplaceViaIdentity
```
Update-AzNetworkCloudBareMetalMachine -InputObject <INetworkCloudIdentity>
 -BareMetalMachineReplaceParameter <IBareMetalMachineReplaceParameters> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReplaceViaIdentityExpanded
```
Update-AzNetworkCloudBareMetalMachine -InputObject <INetworkCloudIdentity> [-BmcCredentialsPassword <String>]
 [-BmcCredentialsUsername <String>] [-BmcMacAddress <String>] [-BootMacAddress <String>]
 [-MachineName <String>] [-SerialNumber <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzNetworkCloudBareMetalMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-MachineDetail <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkCloudBareMetalMachine -InputObject <INetworkCloudIdentity> [-MachineDetail <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Reimage the provided bare metal machine.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
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
```

### -BareMetalMachineReplaceParameter
BareMetalMachineReplaceParameters represents the body of the request to physically swap a bare metal machine for another.
To construct, see NOTES section for BAREMETALMACHINEREPLACEPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230501Preview.IBareMetalMachineReplaceParameters
Parameter Sets: Replace, ReplaceViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -BmcCredentialsPassword
The password of the administrator of the device used during initialization.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BmcCredentialsUsername
The username of the administrator of the device used during initialization.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BmcMacAddress
The MAC address of the BMC device.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BootMacAddress
The MAC address of a NIC connected to the PXE network.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: False
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: ReimageViaIdentity, ReplaceViaIdentity, ReplaceViaIdentityExpanded, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MachineDetail
The details provided by the customer during the creation of rack manifeststhat allows for custom data to be associated with this machine.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MachineName
The OS-level hostname assigned to this machine.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the bare metal machine.

```yaml
Type: System.String
Parameter Sets: Reimage, Replace, ReplaceExpanded, UpdateExpanded
Aliases: BareMetalMachineName

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

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Reimage, ReimageViaIdentity, Replace, ReplaceExpanded, ReplaceViaIdentity, ReplaceViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: Reimage, Replace, ReplaceExpanded, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SerialNumber
The serial number of the bare metal machine.

```yaml
Type: System.String
Parameter Sets: ReplaceExpanded, ReplaceViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Reimage, Replace, ReplaceExpanded, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The Azure resource tags that will replace the existing ones.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230501Preview.IBareMetalMachineReplaceParameters

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20230501Preview.IBareMetalMachine

### System.Boolean

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`BAREMETALMACHINEREPLACEPARAMETER <IBareMetalMachineReplaceParameters>`: BareMetalMachineReplaceParameters represents the body of the request to physically swap a bare metal machine for another.
  - `[BmcCredentialsPassword <String>]`: The password of the administrator of the device used during initialization.
  - `[BmcCredentialsUsername <String>]`: The username of the administrator of the device used during initialization.
  - `[BmcMacAddress <String>]`: The MAC address of the BMC device.
  - `[BootMacAddress <String>]`: The MAC address of a NIC connected to the PXE network.
  - `[MachineName <String>]`: The OS-level hostname assigned to this machine.
  - `[SerialNumber <String>]`: The serial number of the bare metal machine.

`INPUTOBJECT <INetworkCloudIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the Kubernetes cluster agent pool.
  - `[BareMetalMachineKeySetName <String>]`: The name of the bare metal machine key set.
  - `[BareMetalMachineName <String>]`: The name of the bare metal machine.
  - `[BmcKeySetName <String>]`: The name of the baseboard management controller key set.
  - `[CloudServicesNetworkName <String>]`: The name of the cloud services network.
  - `[ClusterManagerName <String>]`: The name of the cluster manager.
  - `[ClusterName <String>]`: The name of the cluster.
  - `[ConsoleName <String>]`: The name of the virtual machine console.
  - `[Id <String>]`: Resource identity path
  - `[KubernetesClusterName <String>]`: The name of the Kubernetes cluster.
  - `[L2NetworkName <String>]`: The name of the L2 network.
  - `[L3NetworkName <String>]`: The name of the L3 network.
  - `[MetricsConfigurationName <String>]`: The name of the metrics configuration for the cluster.
  - `[RackName <String>]`: The name of the rack.
  - `[RackSkuName <String>]`: The name of the rack SKU.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[StorageApplianceName <String>]`: The name of the storage appliance.
  - `[SubscriptionId <String>]`: The ID of the target subscription. The value must be an UUID.
  - `[TrunkedNetworkName <String>]`: The name of the trunked network.
  - `[VirtualMachineName <String>]`: The name of the virtual machine.
  - `[VolumeName <String>]`: The name of the volume.

## RELATED LINKS

