---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/get-azgalleryinvmaccesscontrolprofile
schema: 2.0.0
---

# Get-AzGalleryInVMAccessControlProfile

## SYNOPSIS
Gets the specified gallery inVMAccessControlProfile or a list of gallery inVMAccessControlProfiles from the specified gallery.

## SYNTAX

### DefaultParameter (Default)
```
Get-AzGalleryInVMAccessControlProfile -ResourceGroupName <String> -GalleryName <String>
 [-GalleryInVMAccessControlProfileName <String>] [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

### ResourceIdParameter
```
Get-AzGalleryInVMAccessControlProfile [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzGalleryInVMAccessControlProfile** cmdlet retrieves the specified gallery inVMAccessControlProfile when optional parameter GalleryInVMAccessControlProfileName is provided. Otherwise it returns a list of gallery inVMAccessControlProfiles from the specified gallery.

## EXAMPLES

### Example 1
```powershell
Get-AzGalleryInVMAccessControlProfile -ResourceGroupName "myResourceGroup" -GalleryName "myGallery" -GalleryInVMAccessControlProfileName "myProfile"
```

Gets the specified gallery inVMAccessControlProfile named "myProfile" from the gallery "myGallery" in the resource group "myResourceGroup".

### Example 2
```powershell
Get-AzGalleryInVMAccessControlProfile -ResourceGroupName "myResourceGroup" -GalleryName "myGallery"
```

Gets the list of all gallery inVMAccessControlProfiles from the gallery "myGallery" in the resource group "myResourceGroup".

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

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfile

## NOTES

## RELATED LINKS
