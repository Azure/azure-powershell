---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
online version: https://learn.microsoft.com/powershell/module/az.compute/update-azgalleryinvmaccesscontrolprofile
schema: 2.0.0
---

# Update-AzGalleryInVMAccessControlProfile

## SYNOPSIS
Updates a gallery inVMAccessControlProfile.

## SYNTAX

```
Update-AzGalleryInVMAccessControlProfile -ResourceGroupName <String> -GalleryName <String>
 -GalleryInVMAccessControlProfileName <String> -Location <String> [-ApplicableHostEndPoint <String>]
 [-Description <String>] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzGalleryInVMAccessControlProfile** cmdlet updates a gallery inVMAccessControlProfile.

## EXAMPLES

### Example 1
```powershell
Update-AzGalleryInVMAccessControlProfile -ResourceGroupName "myResourceGroup" -GalleryName "myGallery" -GalleryInVMAccessControlProfileName "myProfile" -Location "West US 2" -Description "New description."
```

Updates the gallery inVMAccessControlProfile named "myProfile" in the gallery "myGallery" located in the resource group "myResourceGroup" with a new description.

## PARAMETERS

### -ApplicableHostEndPoint
This property allows you to specify the Endpoint type for which this profile is defining the access control for.

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

### -Description
The description of this gallery inVMAccessControlProfile resource.
This property is updatable.

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

### -GalleryInVMAccessControlProfileName
The name of the Gallery In VM Access Control Profile.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -GalleryName
The name of the gallery.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
The location of the Gallery In VM Access Control Profile.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: True
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

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Automation.Models.PSGalleryInVMAccessControlProfile

## NOTES

## RELATED LINKS
