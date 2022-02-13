---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://docs.microsoft.com/powershell/module/az.compute/set-azvmsssecurityprofile
schema: 2.0.0
---

# Set-AzVmssSecurityProfile

## SYNOPSIS
This cmdlet allows users to set the SecurityType enum for Virtual Machines scale sets.

## SYNTAX

```
Set-AzVmssSecurityProfile [-VirtualMachineScaleSet] <PSVirtualMachineScaleSet> [[-SecurityType] <SecurityTypes>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Sets the Security Type of the VMSS

## EXAMPLES

### Example 1
```powershell
$VMSS = Get-AzVmss -ResourceGroupName "ResourceGroup11" -VMScaleSetName "ContosoVM07"
$VMSS = Set-AzVmssSecurityProfile -VirtualMachineScaleSet $VMSS -SecurityType "TrustedLaunch"
```

The first command gets the virtual machine scale set named ContosoVM07 by using **Get-AzVmss**.
The command stores it in the $VMSS variable.
The second command sets the SecurityType enum to "TrustedLaunch"

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityType
Enum that represents the security type (ex: Trusted Launch)

```yaml
Type: SecurityTypes
Parameter Sets: (All)
Aliases:
Accepted values: TrustedLaunch

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualMachineScaleSet
The virtual machine scale set profile.

```yaml
Type: PSVirtualMachineScaleSet
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSet

### Microsoft.Azure.Management.Compute.Models.SecurityTypes

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSet

## NOTES

## RELATED LINKS
