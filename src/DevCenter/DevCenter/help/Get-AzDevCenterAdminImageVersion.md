---
external help file: Az.DevCenter-help.xml
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/get-azdevcenteradminimageversion
schema: 2.0.0
---

# Get-AzDevCenterAdminImageVersion

## SYNOPSIS
Gets an image version.

## SYNTAX

### List (Default)
```
Get-AzDevCenterAdminImageVersion -DevCenterName <String> -GalleryName <String> -ImageName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzDevCenterAdminImageVersion -DevCenterName <String> -GalleryName <String> -ImageName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] -VersionName <String> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterAdminImageVersion -InputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets an image version.

## EXAMPLES

### Example 1: List image versions for an image
```powershell
Get-AzDevCenterAdminImageVersion -ResourceGroupName testRg -DevCenterName Contoso -ImageName ContosoBaseImage -GalleryName StandardGallery
```

This command lists the image verions for the image "ContosoBaseImage" under the gallery "StandardGallery".

### Example 2: Get an image version
```powershell
Get-AzDevCenterAdminImageVersion -ResourceGroupName testRg -DevCenterName Contoso -ImageName ContosoBaseImage -VersionName 1.0.0 -GalleryName StandardGallery
```

This command gets the image version "1.0.0" for the image "ContosoBaseImage" in the gallery "StandardGallery".

### Example 3: Get an image version using InputObject
```powershell
$imageVersion =  @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "GalleryName" = "StandardGallery"; "ImageName" = "ContosoBaseImage"; "VersionName" = "1.0.0"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
Get-AzDevCenterAdminImageVersion -InputObject $imageVersion
```

This command gets the image version "1.0.0" for the image "ContosoBaseImage" in the gallery "StandardGallery".

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DevCenterName
The name of the devcenter.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GalleryName
The name of the gallery.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageName
The name of the image.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VersionName
The version of the image.

```yaml
Type: System.String
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.IImageVersion

## NOTES

## RELATED LINKS
