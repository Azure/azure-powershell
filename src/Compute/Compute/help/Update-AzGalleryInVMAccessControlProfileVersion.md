---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/update-azgalleryinvmaccesscontrolprofileversion
schema: 2.0.0
---

# Update-AzGalleryInVMAccessControlProfileVersion

## SYNOPSIS
Updates a specific version of a gallery inVMAccessControlProfile.

## SYNTAX

```
Update-AzGalleryInVMAccessControlProfileVersion
 -GalleryInVmAccessControlProfileVersion <PSGalleryInVMAccessControlProfileVersion>
 [-TargetLocation <String[]>] [-ExcludeFromLatest <Boolean>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzGalleryInVMAccessControlProfileVersion** cmdlet updates a specific version of a gallery inVMAccessControlProfile. <br>
The gallery inVMAccessControlVersion to be updated can be passed by providing the PSGalleryInVMAccessControlProfileVersion object retrieved from the [Get-AzGalleryInVMAccessControlProfileVersion](https://learn.microsoft.com/powershell/module/az.compute/Get-AzGalleryInVMAccessControlProfileVersion) cmdlet.

## EXAMPLES

### Example 1
```powershell
$CPversion = Get-AzGalleryInVMAccessControlProfileVersion -ResourceGroupName "myResourceGroup" -GalleryName "myGallery" -GalleryInVMAccessControlProfileName "myProfile" -GalleryInVMAccessControlProfileVersionName "myProfileVersion"
Update-AzGalleryInVMAccessControlProfileVersion -GalleryInVmAccessControlProfileVersion $CPversion -TargetLocation @("West US 2", "West US") -ExcludeFromLatest $true
```

This example first uses Get-AzGalleryInVMAccessControlProfileVersion to retrieves the specified version of the gallery inVMAccessControlProfile that needs to be updated.
Then it uses Update-AzGalleryInVMAccessControlProfileVersion to update its TargetLocation and excludeFromLatest property. 

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

### -ExcludeFromLatest
If set to true, Virtual Machines deployed from the latest version of the Resource Profile won't use this Profile version.

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

### -GalleryInVmAccessControlProfileVersion
PSGalleryInVmAccessControlProfileVersion object created from New-AzGalleryInVMAccessControlProfileVersionConfig.

```yaml
Type: Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TargetLocation
The names of the target regions where the Resource Profile version is going to be replicated to. This property is updatable.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### System.String

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion

### System.String[]

### System.Nullable`1[[System.Boolean, System.Private.CoreLib, Version=9.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion

## NOTES

## RELATED LINKS
