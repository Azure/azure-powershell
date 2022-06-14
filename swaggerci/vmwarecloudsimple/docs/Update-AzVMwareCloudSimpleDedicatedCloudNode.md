---
external help file:
Module Name: Az.VMwareCloudSimple
online version: https://docs.microsoft.com/en-us/powershell/module/az.vmwarecloudsimple/update-azvmwarecloudsimplededicatedcloudnode
schema: 2.0.0
---

# Update-AzVMwareCloudSimpleDedicatedCloudNode

## SYNOPSIS
Patches dedicated node properties

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzVMwareCloudSimpleDedicatedCloudNode -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzVMwareCloudSimpleDedicatedCloudNode -InputObject <IVMwareCloudSimpleIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Patches dedicated node properties

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
Type: Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple.Models.IVMwareCloudSimpleIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
dedicated cloud node name

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: DedicatedCloudNodeName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The tags key:value pairs

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple.Models.IVMwareCloudSimpleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple.Models.Api20190401.IDedicatedCloudNode

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IVMwareCloudSimpleIdentity>: Identity Parameter
  - `[CustomizationPolicyName <String>]`: customization policy name
  - `[DedicatedCloudNodeName <String>]`: dedicated cloud node name
  - `[DedicatedCloudServiceName <String>]`: dedicated cloud Service name
  - `[Id <String>]`: Resource identity path
  - `[OperationId <String>]`: operation id
  - `[PcName <String>]`: The private cloud name
  - `[RegionId <String>]`: The region Id (westus, eastus)
  - `[ResourceGroupName <String>]`: The name of the resource group
  - `[ResourcePoolName <String>]`: resource pool id (vsphereId)
  - `[SubscriptionId <String>]`: The subscription ID.
  - `[VirtualMachineName <String>]`: virtual machine name
  - `[VirtualMachineTemplateName <String>]`: virtual machine template id (vsphereId)
  - `[VirtualNetworkName <String>]`: virtual network id (vsphereId)

## RELATED LINKS

