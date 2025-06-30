---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version:
schema: 2.0.0
---

# Update-AzGalleryInVMAccessControlProfileVersion

## SYNOPSIS
Updates a specific version of a gallery inVMAccessControlProfile.

## SYNTAX

```
Update-AzGalleryInVMAccessControlProfileVersion
 -GalleryInVmAccessControlProfileVersion <PSGalleryInVMAccessControlProfileVersion> [-TargetRegion <String[]>]
 [-ExcludeFromLatest <Boolean>] [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzGalleryInVMAccessControlProfileVersion** cmdlet updates a specific version of a gallery inVMAccessControlProfile. <br>
The gallery inVMAccessControlVersion to be updated can be passed by providing the PSGalleryInVMAccessControlProfileVersion object retrieved from the [Get-AzGalleryInVMAccessControlProfileVersion](https://learn.microsoft.com/en-us/powershell/module/az.compute/Get-AzGalleryInVMAccessControlProfileVersion) cmdlet.


## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TargetRegion
The names of the target regions where the Resource Profile version is going to be replicated to.
This property is updatable.

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
