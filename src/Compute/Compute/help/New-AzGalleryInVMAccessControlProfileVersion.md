---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version:
schema: 2.0.0
---

# New-AzGalleryInVMAccessControlProfileVersion

## SYNOPSIS
Creates a new version of a gallery inVMAccessControlProfile.

## SYNTAX

```
New-AzGalleryInVMAccessControlProfileVersion -ResourceGroupName <String> -GalleryName <String>
 -GalleryInVMAccessControlProfileName <String>
 -GalleryInVmAccessControlProfileVersion <PSGalleryInVMAccessControlProfileVersion>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzGalleryInVMAccessControlProfileVersion** cmdlet creates a new version of a gallery inVMAccessControlProfile in Azure. <br>
This cmdlet takes in PSGalleryInVMAccessControlProfileVersion object created from [New-AzGalleryInVMAccessControlProfileVersionConfig](https://learn.microsoft.com/en-us/powershell/module/az.compute/new-AzGalleryInVMAccessControlProfileVersionConfig) as input. <br>

[Add-AzGalleryInVMAccessControlVersionRulesIdentity](https://learn.microsoft.com/en-us/powershell/module/az.compute/Add-AzGalleryInVMAccessControlVersionRulesIdentity), [Add-AzGalleryInVMAccessControlVersionRulesPrivilege](https://learn.microsoft.com/en-us/powershell/module/az.compute/add-AzGalleryInVMAccessControlVersionRulesPrivilege), [Add-AzGalleryInVMAccessControlVersionRulesRole](https://learn.microsoft.com/en-us/powershell/module/az.compute/Add-AzGalleryInVMAccessControlVersionRulesRole), and [Add-AzGalleryInVMAccessControlVersionRulesRoleAssignment](https://learn.microsoft.com/en-us/powershell/module/az.compute/Add-AzGalleryInVMAccessControlVersionRulesRoleAssignment) cmdlets can also be used to add rules to the PSGalleryInVmAccessControlProfileVersion object.

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
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GalleryInVMAccessControlProfileName
The name of the Gallery In VM Access Control Profile.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -GalleryInVmAccessControlProfileVersion
PSGalleryInVmAccessControlProfileVersion object created from New-AzGalleryInVMAccessControlProfileVersionConfig.

```yaml
Type: PSGalleryInVMAccessControlProfileVersion
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -GalleryName
The name of the gallery.

```yaml
Type: String
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
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
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

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion

## NOTES

## RELATED LINKS
