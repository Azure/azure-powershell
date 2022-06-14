---
external help file:
Module Name: Az.VMwareCloudSimple
online version: https://docs.microsoft.com/en-us/powershell/module/az.vmwarecloudsimple/new-azvmwarecloudsimplevirtualmachine
schema: 2.0.0
---

# New-AzVMwareCloudSimpleVirtualMachine

## SYNOPSIS
Create Or Update Virtual Machine

## SYNTAX

```
New-AzVMwareCloudSimpleVirtualMachine -Name <String> -ResourceGroupName <String> -Referer <String>
 -Location <String> [-SubscriptionId <String>] [-AmountOfRam <Int32>] [-CustomizationDnsServer <String[]>]
 [-CustomizationHostName <String>] [-CustomizationPassword <String>] [-CustomizationPolicyId <String>]
 [-CustomizationUsername <String>] [-Disk <IVirtualDisk[]>] [-ExposeToGuestVM] [-Nic <IVirtualNic[]>]
 [-NumberOfCore <Int32>] [-Password <String>] [-PrivateCloudId <String>] [-ResourcePoolId <String>]
 [-Tag <Hashtable>] [-TemplateId <String>] [-Username <String>] [-VSphereNetwork <String[]>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create Or Update Virtual Machine

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

### -AmountOfRam
The amount of memory

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -CustomizationDnsServer
List of dns servers to use

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

### -CustomizationHostName
Virtual Machine hostname

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

### -CustomizationPassword
Password for login

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

### -CustomizationPolicyId
id of customization policy

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

### -CustomizationUsername
Username for login

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

### -Disk
The list of Virtual Disks
To construct, see NOTES section for DISK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple.Models.Api20190401.IVirtualDisk[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExposeToGuestVM
Expose Guest OS or not

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

### -Location
Azure region

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

### -Name
virtual machine name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: VirtualMachineName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Nic
The list of Virtual NICs
To construct, see NOTES section for NIC properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple.Models.Api20190401.IVirtualNic[]
Parameter Sets: (All)
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

### -NumberOfCore
The number of CPU cores

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Password
Password for login.
Deprecated - use customization property

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

### -PrivateCloudId
Private Cloud Id

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

### -Referer
referer url

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
The name of the resource group

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

### -ResourcePoolId
resource pool id (privateCloudId:vsphereId)

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

### -SubscriptionId
The subscription ID.

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

### -Tag
The list of tags

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

### -TemplateId
Virtual Machine Template Id

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

### -Username
Username for login.
Deprecated - use customization property

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

### -VSphereNetwork
The list of Virtual VSphere Networks

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.VMwareCloudSimple.Models.Api20190401.IVirtualMachine

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DISK <IVirtualDisk[]>: The list of Virtual Disks
  - `ControllerId <String>`: Disk's Controller id
  - `IndependenceMode <DiskIndependenceMode>`: Disk's independence mode type
  - `TotalSize <Int32>`: Disk's total size
  - `[Id <String>]`: Disk's id

NIC <IVirtualNic[]>: The list of Virtual NICs
  - `NetworkId <String>`: virtual network id (privateCloudId:vsphereId)
  - `NicType <NicType>`: NIC type
  - `[CustomizationAllocation <String>]`: IP address allocation method
  - `[CustomizationDnsServer <String[]>]`: List of dns servers to use
  - `[CustomizationGateway <String[]>]`: Gateway addresses assigned to nic
  - `[CustomizationIPAddress <String>]`: Static ip address for nic
  - `[CustomizationMask <String>]`: Network mask for nic
  - `[CustomizationPrimaryWinsServer <String>]`: primary WINS server for Windows
  - `[CustomizationSecondaryWinsServer <String>]`: secondary WINS server for Windows
  - `[IPAddress <String[]>]`: NIC ip address
  - `[Id <String>]`: NIC id
  - `[MacAddress <String>]`: NIC MAC address
  - `[PowerOnBoot <Boolean?>]`: Is NIC powered on/off on boot

## RELATED LINKS

