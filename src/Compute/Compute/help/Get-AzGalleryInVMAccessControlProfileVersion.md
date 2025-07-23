---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/get-azgalleryinvmaccesscontrolprofileversion
schema: 2.0.0
---

# Get-AzGalleryInVMAccessControlProfileVersion

## SYNOPSIS
Gets the specified version of a gallery inVMAccessControlProfile or a list of versions from the specified gallery inVMAccessControlProfile.

## SYNTAX

### DefaultParameter (Default)
```
Get-AzGalleryInVMAccessControlProfileVersion -ResourceGroupName <String> -GalleryName <String>
 -GalleryInVMAccessControlProfileName <String> [-GalleryInVMAccessControlProfileVersionName <String>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdParameter
```
Get-AzGalleryInVMAccessControlProfileVersion [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzGalleryInVMAccessControlProfileVersion** cmdlet retrieves the specified version of a gallery inVMAccessControlProfile when the optional parameter GalleryInVMAccessControlProfileVersionName is provided. Otherwise, it returns a list of versions from the specified gallery inVMAccessControlProfile.

## EXAMPLES

### Example 1
```powershell
Get-AzGalleryInVMAccessControlProfileVersion -ResourceGroupName "myResourceGroup" -GalleryName "myGallery" -GalleryInVMAccessControlProfileName "myProfile" -GalleryInVMAccessControlProfileVersionName "myProfileVersion"
```

Gets the specified version of the gallery inVMAccessControlProfile named "myProfileVersion" from the gallery "myGallery" in the resource group "myResourceGroup".

### Example 2
```powershell
Get-AzGalleryInVMAccessControlProfileVersion -ResourceGroupName "myResourceGroup" -GalleryName "myGallery" -GalleryInVMAccessControlProfileName "myProfile"
```

Gets the list of all versions of the gallery inVMAccessControlProfile from the gallery "myGallery" in the resource group "myResourceGroup".

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

### -GalleryInVMAccessControlProfileName
The name of the Gallery In VM Access Control Profile.

```yaml
Type: System.String
Parameter Sets: DefaultParameter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -GalleryInVMAccessControlProfileVersionName
The name of the Gallery In VM Access Control Profile Version.

```yaml
Type: System.String
Parameter Sets: DefaultParameter
Aliases: Name

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -GalleryName
The name of the gallery.

```yaml
Type: System.String
Parameter Sets: DefaultParameter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: DefaultParameter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
{{ Fill ResourceId Description }}

```yaml
Type: System.String
Parameter Sets: ResourceIdParameter
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfileVersion

## NOTES

## RELATED LINKS
