---
external help file:
Module Name: Az.VMwareCloudSimple
online version: https://docs.microsoft.com/en-us/powershell/module/az.vmwarecloudsimple/get-azvmwarecloudsimpleprivatecloud
schema: 2.0.0
---

# Get-AzVMwareCloudSimplePrivateCloud

## SYNOPSIS
Returns private cloud by its name

## SYNTAX

### List (Default)
```
Get-AzVMwareCloudSimplePrivateCloud -RegionId <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzVMwareCloudSimplePrivateCloud -PcName <String> -RegionId <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzVMwareCloudSimplePrivateCloud -InputObject <IVMwareCloudSimpleIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Returns private cloud by its name

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
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PcName
The private cloud name

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RegionId
The region Id (westus, eastus)

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
The subscription ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple.Models.IVMwareCloudSimpleIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple.Models.Api20190401.IPrivateCloud

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

