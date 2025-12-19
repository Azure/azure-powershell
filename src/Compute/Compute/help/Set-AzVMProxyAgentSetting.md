---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/set-azvmproxyagentsetting
schema: 2.0.0
---

# Set-AzVMProxyAgentSetting

## SYNOPSIS
Sets the Proxy Agent settings properties for a PSVirtualMachine object.

## SYNTAX

```
Set-AzVMProxyAgentSetting -VM <PSVirtualMachine> [-EnableProxyAgent <Boolean>] [-WireServerMode <String>]
 [-WireServerProfile <String>] [-ImdsMode <String>] [-ImdsProfile <String>] [-KeyIncarnationId <Int32>]
 [-AddProxyAgentExtension <Boolean>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Sets the Proxy Agent settings properties for a PSVirtualMachine object.

## EXAMPLES

### Example 1
```powershell
$vmconfig = New-AzVMConfig -VMName $vmName -VMSize "Standard_D2s_v3"
Set-AzVMProxyAgentSetting -VM $vmconfig -EnableProxyAgent $true -AddProxyAgentExtension false -WireServerMode "Enforce" -ImdsProfile "/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/galleries/{galleryName}/inVMAccessControlProfiles/{profile}/versions/{version}"
```

This command sets the Proxy Agent settings for a virtual machine configuration object `$vmconfig`. 
It enables the Proxy Agent, sets the Wire Server mode to "Enforce", specifies the IMDS profile.

## PARAMETERS

### -AddProxyAgentExtension
Specifies whether to implicitly install the ProxyAgent Extension. This option is currently applicable only for Linux OS.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableProxyAgent
Specifies whether Metadata Security Protocol(ProxyAgent) feature should be enabled or not.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ImdsMode
Specifies the IMDS endpoint execution mode.
In Audit mode, the system acts as if it is enforcing the access control policy, including emitting access denial entries in the logs but it does not actually deny any requests to host endpoints.
In Enforce mode, the system will enforce the access control and it is the recommended mode of operation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ImdsProfile
Specifies the InVMAccessControlProfileVersion resource id in the IMDS enpoint.
Format of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/galleries/{galleryName}/inVMAccessControlProfiles/{profile}/versions/{version}

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -KeyIncarnationId
Increase the value of this parameter allows users to reset the key used for securing communication channel between guest and host.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VM
PSVirtualMachine object created from New-AzVMConfig.

```yaml
Type: Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine
Parameter Sets: (All)
Aliases: VirtualMachine

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -WireServerMode
Specifies the Wire Server endpoint execution mode while creating the virtual machine or virtual machine scale set.
In Audit mode, the system acts as if it is enforcing the access control policy, including emitting access denial entries in the logs but it does not actually deny any requests to host endpoints.
In Enforce mode, the system will enforce the access control and it is the recommended mode of operation.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -WireServerProfile
Specifies the InVMAccessControlProfileVersion resource id in the Wire Server endpoint.
Format of /subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/galleries/{galleryName}/inVMAccessControlProfiles/{profile}/versions/{version}

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

### System.Management.Automation.SwitchParameter

### System.String

### System.Int32

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

## NOTES

## RELATED LINKS
