---
external help file:
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/get-aznetworkinterface
schema: 2.0.0
---

# Get-AzNetworkInterface

## SYNOPSIS
Gets information about the specified network interface.

## SYNTAX

### List (Default)
```
Get-AzNetworkInterface -SubscriptionId <String[]> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetVmss
```
Get-AzNetworkInterface -Name <String> -ResourceGroupName <String> -SubscriptionId <String[]> -VMIndex <String>
 -VmssName <String> [-Expand <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkInterface -Name <String> -ResourceGroupName <String> -SubscriptionId <String[]>
 [-Expand <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListVmssVM
```
Get-AzNetworkInterface -ResourceGroupName <String> -SubscriptionId <String[]> -VMIndex <String>
 -VmssName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### ListVmss
```
Get-AzNetworkInterface -ResourceGroupName <String> -SubscriptionId <String[]> -VmssName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzNetworkInterface -ResourceGroupName <String> -SubscriptionId <String[]> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkInterface -InputObject <INetworkIdentity> [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets information about the specified network interface.

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

### -Expand
Expands referenced resources.

```yaml
Type: System.String
Parameter Sets: GetVmss, Get, GetViaIdentity
Aliases: ExpandResource

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the network interface.

```yaml
Type: System.String
Parameter Sets: GetVmss, Get
Aliases: NetworkInterfaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: GetVmss, Get, ListVmssVM, ListVmss, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The subscription credentials which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: List, GetVmss, Get, ListVmssVM, ListVmss, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VMIndex
The virtual machine index.

```yaml
Type: System.String
Parameter Sets: GetVmss, ListVmssVM
Aliases: VirtualMachineIndex

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -VmssName
The name of the virtual machine scale set.

```yaml
Type: System.String
Parameter Sets: GetVmss, ListVmssVM, ListVmss
Aliases: VirtualMachineScaleSetName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.INetworkIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20190201.INetworkInterface

## ALIASES

### Get-AzNetworkInterfaceVirtualMachineScaleSetNetworkInterface

### Get-AzNetworkInterfaceVirtualMachineScaleSetVMNetworkInterface

## NOTES

## RELATED LINKS

