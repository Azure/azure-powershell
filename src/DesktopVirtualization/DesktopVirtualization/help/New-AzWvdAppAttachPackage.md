---
external help file: Az.DesktopVirtualization-help.xml
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/new-azwvdappattachpackage
schema: 2.0.0
---

# New-AzWvdAppAttachPackage

## SYNOPSIS
Create or update an App Attach package.

## SYNTAX

### CreateExpanded (Default)
```
New-AzWvdAppAttachPackage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-FailHealthCheckOnStagingFailure <FailHealthCheckOnStagingFailure>]
 [-HostPoolReference <String[]>] [-ImageCertificateExpiry <DateTime>] [-ImageCertificateName <String>]
 [-ImageDisplayName <String>] [-ImageIsActive] [-ImageIsPackageTimestamped <PackageTimestamped>]
 [-ImageIsRegularRegistration] [-ImageLastUpdated <DateTime>] [-ImagePackageAlias <String>]
 [-ImagePackageApplication <IMsixPackageApplications[]>] [-ImagePackageDependency <IMsixPackageDependencies[]>]
 [-ImagePackageFamilyName <String>] [-ImagePackageFullName <String>] [-ImagePackageName <String>]
 [-ImagePackageRelativePath <String>] [-ImagePath <String>] [-ImageVersion <String>] [-KeyVaultUrl <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ImageObject
```
New-AzWvdAppAttachPackage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Location <String> [-FailHealthCheckOnStagingFailure <FailHealthCheckOnStagingFailure>]
 [-HostPoolReference <String[]>] [-ImageDisplayName <String>] [-ImageIsActive] [-ImageIsRegularRegistration]
 [-KeyVaultUrl <String>] [-AppAttachPackage] <AppAttachPackage> [-PassThru] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create or update an App Attach package.

## EXAMPLES

### EXAMPLE 1
```
"
$deps = "<PackageDependencies>"
New-AzWvdAppAttachPackage -Name PackageArmObjectName `
                         -ResourceGroupName ResourceGroupName `
                         -SubscriptionId SubscriptionId `
                         -Location location `
                         -ImageDisplayName displayname `
                         -ImagePath imageURI `
                         -ImageIsActive:$false `
                         -ImageIsRegularRegistration:$false `
                         -ImageLastUpdated datelastupdated `
                         -ImagePackageApplication $apps `
                         -ImagePackageDependency $deps `
                         -ImagePackageFamilyName packagefamilyname `
                         -ImagePackageName packagename `
                         -ImagePackageFullName packagefullname `
                         -ImagePackageRelativePath packagerelativepath `
                         -ImageVersion packageversion `
                         -ImageCertificateExpiry certificateExpiry `
                         -ImageCertificateName certificateName `
                         -KeyVaultUrl keyvaultUrl `
                         -FailHealthCheckOnStagingFailure 'Unhealthy'
```

### EXAMPLE 2
```
New-AzWvdAppAttachPackage -Name PackageArmObjectName `
                         -ResourceGroupName ResourceGroupName `
                         -SubscriptionId SubscriptionId `
                         -Location location `
                         -DisplayName displayname `
                         -AppAttachPackage imageObject `
                         -IsActive:$false `
                         -IsLogonBlocking:$false `
                         -KeyVaultUrl keyvaultUrl `
                         -FailHealthCheckOnStagingFailure 'Unhealthy' `
                         -HostpoolReference hostpoolReference `
                         -PassThru
```

## PARAMETERS

### -AppAttachPackage
To construct, see NOTES section for APPATTACHPACKAGE properties and create a hash table.

```yaml
Type: AppAttachPackage
Parameter Sets: ImageObject
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FailHealthCheckOnStagingFailure
Parameter indicating how the health check should behave if this package fails staging

```yaml
Type: FailHealthCheckOnStagingFailure
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostPoolReference
List of Hostpool resource Ids.

```yaml
Type: String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageCertificateExpiry
Date certificate expires, found in the appxmanifest.xml.

```yaml
Type: DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageCertificateName
Certificate name found in the appxmanifest.xml.

```yaml
Type: String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageDisplayName
User friendly Name to be displayed in the portal.

```yaml
Type: String
Parameter Sets: (All)
Aliases: DisplayName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageIsActive
Make this version of the package the active one across the hostpool.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: IsActive

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageIsPackageTimestamped
Is package timestamped so it can ignore the certificate expiry date

```yaml
Type: PackageTimestamped
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageIsRegularRegistration
Specifies how to register Package in feed.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: IsRegularRegistration, IsLogonBlocking

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageLastUpdated
Date Package was last updated, found in the appxmanifest.xml.

```yaml
Type: DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePackageAlias
Alias of App Attach Package.
Assigned at import time

```yaml
Type: String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePackageApplication
List of package applications.

To construct, see NOTES section for IMAGEPACKAGEAPPLICATION properties and create a hash table.

```yaml
Type: IMsixPackageApplications[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePackageDependency
List of package dependencies.

To construct, see NOTES section for IMAGEPACKAGEDEPENDENCY properties and create a hash table.

```yaml
Type: IMsixPackageDependencies[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePackageFamilyName
Package Family Name from appxmanifest.xml.
Contains Package Name and Publisher name.

```yaml
Type: String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePackageFullName
Package Full Name from appxmanifest.xml.

```yaml
Type: String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePackageName
Package Name from appxmanifest.xml.

```yaml
Type: String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePackageRelativePath
Relative Path to the package inside the image.

```yaml
Type: String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePath
VHD/CIM image path on Network Share.

```yaml
Type: String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageVersion
Package Version found in the appxmanifest.xml.

```yaml
Type: String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultUrl
URL of keyvault location to store certificate

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the App Attach package arm object

```yaml
Type: String
Parameter Sets: (All)
Aliases: AppAttachPackageName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
{{ Fill PassThru Description }}

```yaml
Type: SwitchParameter
Parameter Sets: ImageObject
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
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
The name is case insensitive.

```yaml
Type: String
Parameter Sets: (All)
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
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: Hashtable
Parameter Sets: CreateExpanded
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
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231101Preview.AppAttachPackage
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231101Preview.IAppAttachPackage
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

APPATTACHPACKAGE \<AppAttachPackage\>: 
  Location \<String\>: The geo-location where the resource lives
  \[FailHealthCheckOnStagingFailure \<FailHealthCheckOnStagingFailure?\>\]: Parameter indicating how the health check should behave if this package fails staging
  \[HostPoolReference \<String\[\]\>\]: List of Hostpool resource Ids.
  \[ImageCertificateExpiry \<DateTime?\>\]: Date certificate expires, found in the appxmanifest.xml. 
  \[ImageCertificateName \<String\>\]: Certificate name found in the appxmanifest.xml. 
  \[ImageDisplayName \<String\>\]: User friendly Name to be displayed in the portal. 
  \[ImageIsActive \<Boolean?\>\]: Make this version of the package the active one across the hostpool. 
  \[ImageIsPackageTimestamped \<PackageTimestamped?\>\]: Is package timestamped so it can ignore the certificate expiry date
  \[ImageIsRegularRegistration \<Boolean?\>\]: Specifies how to register Package in feed.
  \[ImageLastUpdated \<DateTime?\>\]: Date Package was last updated, found in the appxmanifest.xml. 
  \[ImagePackageAlias \<String\>\]: Alias of App Attach Package.
Assigned at import time
  \[ImagePackageApplication \<IMsixPackageApplications\[\]\>\]: List of package applications. 
    \[AppId \<String\>\]: Package Application Id, found in appxmanifest.xml.
    \[AppUserModelId \<String\>\]: Used to activate Package Application.
Consists of Package Name and ApplicationID.
Found in appxmanifest.xml.
    \[Description \<String\>\]: Description of Package Application.
    \[FriendlyName \<String\>\]: User friendly name.
    \[IconImageName \<String\>\]: User friendly name.
    \[RawIcon \<Byte\[\]\>\]: the icon a 64 bit string as a byte array.
    \[RawPng \<Byte\[\]\>\]: the icon a 64 bit string as a byte array.
  \[ImagePackageDependency \<IMsixPackageDependencies\[\]\>\]: List of package dependencies. 
    \[DependencyName \<String\>\]: Name of package dependency.
    \[MinVersion \<String\>\]: Dependency version required.
    \[Publisher \<String\>\]: Name of dependency publisher.
  \[ImagePackageFamilyName \<String\>\]: Package Family Name from appxmanifest.xml.
Contains Package Name and Publisher name. 
  \[ImagePackageFullName \<String\>\]: Package Full Name from appxmanifest.xml. 
  \[ImagePackageName \<String\>\]: Package Name from appxmanifest.xml. 
  \[ImagePackageRelativePath \<String\>\]: Relative Path to the package inside the image. 
  \[ImagePath \<String\>\]: VHD/CIM image path on Network Share.
  \[ImageVersion \<String\>\]: Package Version found in the appxmanifest.xml. 
  \[KeyVaultUrl \<String\>\]: URL of keyvault location to store certificate
  \[SystemDataCreatedAt \<DateTime?\>\]: The timestamp of resource creation (UTC).
  \[SystemDataCreatedBy \<String\>\]: The identity that created the resource.
  \[SystemDataCreatedByType \<CreatedByType?\>\]: The type of identity that created the resource.
  \[SystemDataLastModifiedAt \<DateTime?\>\]: The timestamp of resource last modification (UTC)
  \[SystemDataLastModifiedBy \<String\>\]: The identity that last modified the resource.
  \[SystemDataLastModifiedByType \<CreatedByType?\>\]: The type of identity that last modified the resource.
  \[Tag \<ITrackedResourceTags\>\]: Resource tags.
    \[(Any) \<String\>\]: This indicates any property can be added to this object.

IMAGEPACKAGEAPPLICATION \<IMsixPackageApplications\[\]\>: List of package applications. 
  \[AppId \<String\>\]: Package Application Id, found in appxmanifest.xml.
  \[AppUserModelId \<String\>\]: Used to activate Package Application.
Consists of Package Name and ApplicationID.
Found in appxmanifest.xml.
  \[Description \<String\>\]: Description of Package Application.
  \[FriendlyName \<String\>\]: User friendly name.
  \[IconImageName \<String\>\]: User friendly name.
  \[RawIcon \<Byte\[\]\>\]: the icon a 64 bit string as a byte array.
  \[RawPng \<Byte\[\]\>\]: the icon a 64 bit string as a byte array.

IMAGEPACKAGEDEPENDENCY \<IMsixPackageDependencies\[\]\>: List of package dependencies. 
  \[DependencyName \<String\>\]: Name of package dependency.
  \[MinVersion \<String\>\]: Dependency version required.
  \[Publisher \<String\>\]: Name of dependency publisher.

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.desktopvirtualization/new-azwvdappattachpackage](https://learn.microsoft.com/powershell/module/az.desktopvirtualization/new-azwvdappattachpackage)

