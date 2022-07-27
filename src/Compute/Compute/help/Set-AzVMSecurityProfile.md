---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://docs.microsoft.com/powershell/module/az.compute/set-azvmsecurityprofile
schema: 2.0.0
---

# Set-AzVMSecurityProfile

## SYNOPSIS
Sets the SecurityType enum for Virtual Machines.

## SYNTAX

```
Set-AzVMSecurityProfile [-VM] <PSVirtualMachine> [-SecurityType <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzVMSecurityProfile** cmdlet sets the Security Type of the VM

## EXAMPLES

### Example 1
```powershell
$VM = Get-AzVM -ResourceGroupName "ResourceGroup11" -VMName "ContosoVM07"
$VM = Set-AzVMSecurityProfile -VM $VM -SecurityType "TrustedLaunch"
```

The first command gets the virtual machine named ContosoVM07 by using **Get-AzVm**.
The command stores it in the $VM variable.
The second command sets the SecurityType enum to "TrustedLaunch". Trusted launch requires the creation of new virtual machines. You can't enable trusted launch on existing virtual machines that were initially created without it.

## PARAMETERS

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

### -SecurityType
Enum that represents the security type (ex: Trusted Launch)

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

### -VM
The virtual machine profile.

```yaml
Type: Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine
Parameter Sets: (All)
Aliases: VMProfile

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

### Microsoft.Azure.Management.Compute.Models.SecurityTypes

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

## NOTES

## RELATED LINKS
