---
external help file:
Module Name: Az.RecoveryServices
online version: https://docs.microsoft.com/powershell/module/az.recoveryservices/update-azrecoveryservicesreplicationprotecteditem
schema: 2.0.0
---

# Update-AzRecoveryServicesReplicationProtectedItem

## SYNOPSIS
The operation to update the recovery settings of an ASR replication protected item.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzRecoveryServicesReplicationProtectedItem -FabricName <String> -ProtectionContainerName <String>
 -ReplicatedProtectedItemName <String> -ResourceGroupName <String> -ResourceName <String>
 [-SubscriptionId <String>] [-EnableRdpOnTargetOption <String>] [-LicenseType <LicenseType>]
 [-ProviderSpecificDetailInstanceType <String>] [-RecoveryAvailabilitySetId <String>]
 [-RecoveryAzureVMName <String>] [-RecoveryAzureVMSize <String>] [-SelectedRecoveryAzureNetworkId <String>]
 [-SelectedSourceNicId <String>] [-SelectedTfoAzureNetworkId <String>] [-VMNic <IVMNicInputDetails[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzRecoveryServicesReplicationProtectedItem -FabricName <String> -ProtectionContainerName <String>
 -ReplicatedProtectedItemName <String> -ResourceGroupName <String> -ResourceName <String>
 -UpdateProtectionInput <IUpdateReplicationProtectedItemInput> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
The operation to update the recovery settings of an ASR replication protected item.

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

### -EnableRdpOnTargetOption
The selected option to enable RDP\SSH on target vm after failover.
String value of SrsDataContract.EnableRDPOnTargetOption enum.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricName
Fabric name.

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

### -LicenseType
License type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Support.LicenseType
Parameter Sets: UpdateExpanded
Aliases:

Required: False
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

### -ProtectionContainerName
Protection container name.

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

### -ProviderSpecificDetailInstanceType
The class type.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryAvailabilitySetId
The target availability set Id.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryAzureVMName
Target Azure VM name given by the user.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RecoveryAzureVMSize
Target Azure VM size.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReplicatedProtectedItemName
Replication protected item name.

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

### -ResourceGroupName
The name of the resource group where the recovery services vault is present.

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

### -ResourceName
The name of the recovery services vault.

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

### -SelectedRecoveryAzureNetworkId
Target Azure Network Id.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelectedSourceNicId
The selected source nic Id which will be used as the primary nic during failover.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SelectedTfoAzureNetworkId
The Azure Network Id for test failover.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription Id.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpdateProtectionInput
Update replication protected item input.
To construct, see NOTES section for UPDATEPROTECTIONINPUT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IUpdateReplicationProtectedItemInput
Parameter Sets: Update
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VMNic
The list of VM nic details.
To construct, see NOTES section for VMNIC properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IVMNicInputDetails[]
Parameter Sets: UpdateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IUpdateReplicationProtectedItemInput

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.RecoveryServices.Models.Api20230201.IReplicationProtectedItem

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`UPDATEPROTECTIONINPUT <IUpdateReplicationProtectedItemInput>`: Update replication protected item input.
  - `[EnableRdpOnTargetOption <String>]`: The selected option to enable RDP\SSH on target vm after failover. String value of SrsDataContract.EnableRDPOnTargetOption enum.
  - `[LicenseType <LicenseType?>]`: License type.
  - `[ProviderSpecificDetailInstanceType <String>]`: The class type.
  - `[RecoveryAvailabilitySetId <String>]`: The target availability set Id.
  - `[RecoveryAzureVMName <String>]`: Target Azure VM name given by the user.
  - `[RecoveryAzureVMSize <String>]`: Target Azure VM size.
  - `[SelectedRecoveryAzureNetworkId <String>]`: Target Azure Network Id.
  - `[SelectedSourceNicId <String>]`: The selected source nic Id which will be used as the primary nic during failover.
  - `[SelectedTfoAzureNetworkId <String>]`: The Azure Network Id for test failover.
  - `[VMNic <IVMNicInputDetails[]>]`: The list of VM nic details.
    - `[EnableAcceleratedNetworkingOnRecovery <Boolean?>]`: Whether the NIC has accelerated networking enabled.
    - `[EnableAcceleratedNetworkingOnTfo <Boolean?>]`: Whether the test NIC has accelerated networking enabled.
    - `[IPConfig <IIPConfigInputDetails[]>]`: The IP configurations to be used by NIC during test failover and failover.
      - `[IPConfigName <String>]`: 
      - `[IsPrimary <Boolean?>]`: 
      - `[IsSeletedForFailover <Boolean?>]`: 
      - `[RecoveryLbBackendAddressPoolId <String[]>]`: 
      - `[RecoveryPublicIPAddressId <String>]`: 
      - `[RecoveryStaticIPAddress <String>]`: 
      - `[RecoverySubnetName <String>]`: 
      - `[TfoLbBackendAddressPoolId <String[]>]`: 
      - `[TfoPublicIPAddressId <String>]`: 
      - `[TfoStaticIPAddress <String>]`: 
      - `[TfoSubnetName <String>]`: 
    - `[NicId <String>]`: The nic Id.
    - `[RecoveryNetworkSecurityGroupId <String>]`: The id of the NSG associated with the NIC.
    - `[RecoveryNicName <String>]`: The name of the NIC to be used when creating target NICs.
    - `[RecoveryNicResourceGroupName <String>]`: The resource group of the NIC to be used when creating target NICs.
    - `[ReuseExistingNic <Boolean?>]`: A value indicating whether an existing NIC is allowed to be reused during failover subject to availability.
    - `[SelectionType <String>]`: Selection type for failover.
    - `[TargetNicName <String>]`: Target NIC name.
    - `[TfoNetworkSecurityGroupId <String>]`: The NSG to be used by NIC during test failover.
    - `[TfoNicName <String>]`: The name of the NIC to be used when creating target NICs in TFO.
    - `[TfoNicResourceGroupName <String>]`: The resource group of the NIC to be used when creating target NICs in TFO.
    - `[TfoReuseExistingNic <Boolean?>]`: A value indicating whether an existing NIC is allowed to be reused during test failover subject to availability.

`VMNIC <IVMNicInputDetails[]>`: The list of VM nic details.
  - `[EnableAcceleratedNetworkingOnRecovery <Boolean?>]`: Whether the NIC has accelerated networking enabled.
  - `[EnableAcceleratedNetworkingOnTfo <Boolean?>]`: Whether the test NIC has accelerated networking enabled.
  - `[IPConfig <IIPConfigInputDetails[]>]`: The IP configurations to be used by NIC during test failover and failover.
    - `[IPConfigName <String>]`: 
    - `[IsPrimary <Boolean?>]`: 
    - `[IsSeletedForFailover <Boolean?>]`: 
    - `[RecoveryLbBackendAddressPoolId <String[]>]`: 
    - `[RecoveryPublicIPAddressId <String>]`: 
    - `[RecoveryStaticIPAddress <String>]`: 
    - `[RecoverySubnetName <String>]`: 
    - `[TfoLbBackendAddressPoolId <String[]>]`: 
    - `[TfoPublicIPAddressId <String>]`: 
    - `[TfoStaticIPAddress <String>]`: 
    - `[TfoSubnetName <String>]`: 
  - `[NicId <String>]`: The nic Id.
  - `[RecoveryNetworkSecurityGroupId <String>]`: The id of the NSG associated with the NIC.
  - `[RecoveryNicName <String>]`: The name of the NIC to be used when creating target NICs.
  - `[RecoveryNicResourceGroupName <String>]`: The resource group of the NIC to be used when creating target NICs.
  - `[ReuseExistingNic <Boolean?>]`: A value indicating whether an existing NIC is allowed to be reused during failover subject to availability.
  - `[SelectionType <String>]`: Selection type for failover.
  - `[TargetNicName <String>]`: Target NIC name.
  - `[TfoNetworkSecurityGroupId <String>]`: The NSG to be used by NIC during test failover.
  - `[TfoNicName <String>]`: The name of the NIC to be used when creating target NICs in TFO.
  - `[TfoNicResourceGroupName <String>]`: The resource group of the NIC to be used when creating target NICs in TFO.
  - `[TfoReuseExistingNic <Boolean?>]`: A value indicating whether an existing NIC is allowed to be reused during test failover subject to availability.

## RELATED LINKS

