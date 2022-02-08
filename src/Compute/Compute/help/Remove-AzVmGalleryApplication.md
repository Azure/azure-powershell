---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version:https://docs.microsoft.com/powershell/module/az.compute/remove-azvmgalleryapplication
schema: 2.0.0
---

# Remove-AzVmGalleryApplication

## SYNOPSIS
Remove a VMGalleryApplication object from the PSVirtualMachine object.

## SYNTAX

```
Remove-AzVmGalleryApplication -VM <PSVirtualMachine> -GalleryApplicationsReferenceId <String>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Removes a VMGalleryApplication object from the PSVirtualMachine object.

## EXAMPLES

### Example 1
```powershell
$vm = Get-AzVm -ResourceGroupName $rgname -Name $vmName
Remove-AzVmGalleryApplication -VM $vm -GalleryApplicationReferenceId $refId
```

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

### -GalleryApplicationsReferenceId
Package Reference Id of the Gallery Application to delete.

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

### -VM
The PSVirtualMachine object to delete a Gallery Application Reference ID from.

```yaml
Type: Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine
Parameter Sets: (All)
Aliases:

Required: True
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

### Microsoft.Azure.Commands.Compute.Models.PSVirtualMachine

## NOTES

## RELATED LINKS
