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

### List1 (Default)
```
Get-AzDevCenterAdminImageVersion -ImageName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -ProjectName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzDevCenterAdminImageVersion -DevCenterName <String> -GalleryName <String> -ImageName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzDevCenterAdminImageVersion -DevCenterName <String> -GalleryName <String> -ImageName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] -VersionName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityDevcenter
```
Get-AzDevCenterAdminImageVersion -GalleryName <String> -ImageName <String> -VersionName <String>
 -DevcenterInputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityProject
```
Get-AzDevCenterAdminImageVersion -ImageName <String> -VersionName <String>
 -ProjectInputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityGallery
```
Get-AzDevCenterAdminImageVersion -ImageName <String> -VersionName <String>
 -GalleryInputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get1
```
Get-AzDevCenterAdminImageVersion -ImageName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -VersionName <String> -ProjectName <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityImage1
```
Get-AzDevCenterAdminImageVersion -VersionName <String> -Image1InputObject <IDevCenterIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityImage
```
Get-AzDevCenterAdminImageVersion -VersionName <String> -ImageInputObject <IDevCenterIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzDevCenterAdminImageVersion -InputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzDevCenterAdminImageVersion -InputObject <IDevCenterIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an image version.

## EXAMPLES

### Example 1: List image versions for an image
```powershell
Get-AzDevCenterAdminImageVersion -ResourceGroupName testRg -DevCenterName Contoso -ImageName ContosoBaseImage -GalleryName StandardGallery
```

This command lists the image versions for the image "ContosoBaseImage" under the gallery "StandardGallery".

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

### -DevcenterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: GetViaIdentityDevcenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -GalleryInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: GetViaIdentityGallery
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -GalleryName
The name of the gallery.

```yaml
Type: System.String
Parameter Sets: List, Get, GetViaIdentityDevcenter
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Image1InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: GetViaIdentityImage1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ImageInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: GetViaIdentityImage
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ImageName
The name of the image.

```yaml
Type: System.String
Parameter Sets: List1, List, Get, GetViaIdentityDevcenter, GetViaIdentityProject, GetViaIdentityGallery, Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: GetViaIdentity1, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProjectInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: GetViaIdentityProject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProjectName
The name of the project.

```yaml
Type: System.String
Parameter Sets: List1, Get1
Aliases:

Required: True
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
Parameter Sets: List1, List, Get, Get1
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
Parameter Sets: List1, List, Get, Get1
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
Parameter Sets: Get, GetViaIdentityDevcenter, GetViaIdentityProject, GetViaIdentityGallery, Get1, GetViaIdentityImage1, GetViaIdentityImage
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IImageVersion

## NOTES

## RELATED LINKS
