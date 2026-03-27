---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/new-azvmgalleryapplication
schema: 2.0.0
---

# New-AzVmGalleryApplication

## SYNOPSIS
Create a local PSVMGalleryApplication object.

## SYNTAX

```
New-AzVmGalleryApplication -PackageReferenceId <String> [-ConfigReferenceId <String>]
 [-EnableAutomaticUpgrade <Bool>] [-TreatFailureAsDeploymentFailure <Bool>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a local PSVMGalleryApplication object.

## EXAMPLES

### Example 1
```powershell
$vm = Get-AzVM -ResourceGroupName $rgName -Name $vmName
$vmGal = New-AzVmGalleryApplication -PackageReferenceId $packageRefId -ConfigReferenceId $configRefId -EnableAutomaticUpgrade $true -TreatFailureAsDeploymentFailure $true
Add-AzVmGalleryApplication -VM $vm -GalleryApplication $vmGal -Order 1
```

This example creates a local VMGalleryApplication object and adds it to a PSVirtualMachine object.

## PARAMETERS

### -ConfigReferenceId
Configuration Reference Id of the Gallery Application.

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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageReferenceId
Package Reference Id of the Gallery Application.

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

### -EnableAutomaticUpgrade
Specifies whether the underlying VM (Virtual Machine) should automatically update when a new version of the Gallery Application becomes available in the Public Image Repository (PIR) or Shared Image Gallery (SIG).

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TreatFailureAsDeploymentFailure
Determines whether a failure encountered during the application process should be treated as a deployment failure.

```yaml
Type: System.Boolean
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
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSVMGalleryApplication

## NOTES

## RELATED LINKS
