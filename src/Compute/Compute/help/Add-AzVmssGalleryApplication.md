---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://docs.microsoft.com/powershell/module/az.compute/add-azvmssgalleryapplication
schema: 2.0.0
---

# Add-AzVmssGalleryApplication

## SYNOPSIS
Add a GalleryApplication object to the PSVirtualMachineProfile object.

## SYNTAX

```
Add-AzVmssGalleryApplication -VirtualMachineScaleSetVM <PSVirtualMachineScaleSetVMProfile>
 -GalleryApplication <PSVMGalleryApplication> [-TreatFailureAsDeploymentFailure] [-Order <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Adds a GalleryApplication object to the PSVirtualMachineProfile object.

## EXAMPLES

### Example 1
```powershell
$vmss = Get-AzVmss -ResourceGroupName $rgName -Name $vmssName
$vmGal = New-AzVmssGalleryApplication -PackageReferenceId $packageRefId -ConfigReferenceId $configRefId
Add-AzVmssGalleryApplication -VirtualMachineScaleSetVM $vmss.VirtualMachineProfile -GalleryApplication $vmGal -Order 1
```

This example creates a local VMGalleryApplication object and adds it to a PSVirtualMachineScaleSetVM object.

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

### -GalleryApplication
VM Gallery Application Object.

```yaml
Type: PSVMGalleryApplication
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Order
Order in which the application will be install in.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TreatFailureAsDeploymentFailure
If true, any failure for any operation in the VmApplication will fail the deployment. Defaults to false if not specified.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VirtualMachineScaleSetVM
The PSVirtualMachineScaleSetVMProfile object to add a Gallery Application Reference ID.

```yaml
Type: PSVirtualMachineScaleSetVMProfile
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: SwitchParameter
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSVirtualMachineScaleSetVMProfile

## NOTES

## RELATED LINKS
