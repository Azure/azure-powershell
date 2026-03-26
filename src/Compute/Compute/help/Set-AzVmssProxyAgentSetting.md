---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/set-azvmssproxyagentsetting
schema: 2.0.0
---

# Set-AzVmssProxyAgentSetting

## SYNOPSIS
Sets the Proxy Agent settings properties for a PSVirtualMachineScaleSet object.

## SYNTAX

```
Set-AzVmssProxyAgentSetting -VirtualMachineScaleSet <PSVirtualMachineScaleSet> [-EnableProxyAgent <Boolean>]
 [-WireServerMode <String>] [-WireServerProfile <String>] [-ImdsMode <String>] [-ImdsProfile <String>]
 [-AddProxyAgentExtension <Boolean>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
Sets the Proxy Agent settings properties for a PSVirtualMachineScaleSet object.

## EXAMPLES

### Example 1
```powershell
$vmssConfig = New-AzVmssConfig -Location 'EastUS2' -SkuName 'Standard_D4s_v3'
Set-AzVmssProxyAgentSetting -VirtualMachineScaleSet $vmssConfig -EnableProxyAgent $true -AddProxyAgentExtension false -WireServerProfile '/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/galleries/{galleryName}/inVMAccessControlProfiles/{profile}/versions/{version}' -ImdsProfile '/subscriptions/{SubscriptionId}/resourceGroups/{ResourceGroupName}/providers/Microsoft.Compute/galleries/{galleryName}/inVMAccessControlProfiles/{profile}/versions/{version}'
```

This command sets the Proxy Agent settings for a virtual machine scale set configuration object `$vmssConfig`. 
It enables the Proxy Agent, specifies the Wire Server profile, and specifies the IMDS profile.

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

### -VirtualMachineScaleSet
PSVirtualMachineScaleSet object created from New-AzVMSSConfig.

```yaml
Type: Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSet
Parameter Sets: (All)
Aliases: Vmss

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

### Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSet

### System.Management.Automation.SwitchParameter

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSet

## NOTES

## RELATED LINKS
