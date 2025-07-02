---
external help file: Az.DesktopVirtualization-help.xml
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/update-azwvdappattachpackage
schema: 2.0.0
---

# Update-AzWvdAppAttachPackage

## SYNOPSIS
Update an App Attach Package

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzWvdAppAttachPackage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-CustomData <String>] [-FailHealthCheckOnStagingFailure <String>] [-HostPoolReference <String[]>]
 [-ImageCertificateExpiry <DateTime>] [-ImageCertificateName <String>] [-ImageDisplayName <String>]
 [-ImageIsActive] [-ImageIsPackageTimestamped <String>] [-ImageIsRegularRegistration]
 [-ImageLastUpdated <DateTime>] [-ImagePackageAlias <String>]
 [-ImagePackageApplication <IMsixPackageApplications[]>] [-ImagePackageDependency <IMsixPackageDependencies[]>]
 [-ImagePackageFamilyName <String>] [-ImagePackageFullName <String>] [-ImagePackageName <String>]
 [-ImagePackageRelativePath <String>] [-ImagePath <String>] [-ImageVersion <String>]
 [-PackageLookbackUrl <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ImageObject
```
Update-AzWvdAppAttachPackage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-FailHealthCheckOnStagingFailure <String>] [-HostPoolReference <String[]>] [-ImageDisplayName <String>]
 [-ImageIsActive] [-ImageIsRegularRegistration] [-AppAttachPackage] <AppAttachPackage> [-PassThru]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzWvdAppAttachPackage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzWvdAppAttachPackage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWvdAppAttachPackage -InputObject <IDesktopVirtualizationIdentity> [-CustomData <String>]
 [-FailHealthCheckOnStagingFailure <String>] [-HostPoolReference <String[]>]
 [-ImageCertificateExpiry <DateTime>] [-ImageCertificateName <String>] [-ImageDisplayName <String>]
 [-ImageIsActive] [-ImageIsPackageTimestamped <String>] [-ImageIsRegularRegistration]
 [-ImageLastUpdated <DateTime>] [-ImagePackageAlias <String>]
 [-ImagePackageApplication <IMsixPackageApplications[]>] [-ImagePackageDependency <IMsixPackageDependencies[]>]
 [-ImagePackageFamilyName <String>] [-ImagePackageFullName <String>] [-ImagePackageName <String>]
 [-ImagePackageRelativePath <String>] [-ImagePath <String>] [-ImageVersion <String>]
 [-PackageLookbackUrl <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update an App Attach Package

## EXAMPLES

### Example 1: Update an Azure Virtual Desktop app attach package by name
```powershell
$apps = "<PackagedApplication>"
$deps = "<PackageDependencies>"
Update-AzWvdAppAttachPackage -Name PackageArmObjectName `
                         -ResourceGroupName ResourceGroupName `
                         -SubscriptionId SubscriptionId `
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

```output
Location   Name                 Type
--------   ----                 ----
eastus     PackageArmObjectName Microsoft.DesktopVirtualization/appattachpackages
```

This command updates an Azure Virtual Desktop App attach package in a resource group.

### Example 2: Create an Azure Virtual Desktop app attach package from an appAttachPackage object
```powershell
Update-AzWvdAppAttachPackage -Name PackageArmObjectName `
                         -ResourceGroupName ResourceGroupName `
                         -SubscriptionId SubscriptionId `
                         -DisplayName displayname `
                         -AppAttachPackage imageObject `
                         -IsActive:$false `
                         -IsLogonBlocking:$false `
                         -KeyVaultUrl keyvaultUrl `
                         -FailHealthCheckOnStagingFailure 'Unhealthy' `
                         -HostpoolReference hostpoolReference `
                         -PassThru
```

```output
Location   Name                 Type
--------   ----                 ----
eastus     PackageArmObjectName Microsoft.DesktopVirtualization/appattachpackages
```

This command updates an Azure Virtual Desktop App Attach Package in a resource group using the output of the Import-AzWvdAppAttachPackageInfo command.

## PARAMETERS

### -AppAttachPackage

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.AppAttachPackage
Parameter Sets: ImageObject
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CustomData
Field that can be populated with custom data and filtered on in list GET calls

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -FailHealthCheckOnStagingFailure
Parameter indicating how the health check should behave if this package fails staging

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, ImageObject, UpdateViaIdentityExpanded
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
Type: System.String[]
Parameter Sets: UpdateExpanded, ImageObject, UpdateViaIdentityExpanded
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
Type: System.DateTime
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded, ImageObject, UpdateViaIdentityExpanded
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, ImageObject, UpdateViaIdentityExpanded
Aliases: IsActive

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageIsPackageTimestamped
Is package timestamped so it can ignore the certificate expiry date

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, ImageObject, UpdateViaIdentityExpanded
Aliases: IsRegularRegistration, IsLogonBlocking

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageLastUpdated
Date the package source was last updated, for Msix packages this is found in the appxmanifest.xml.

```yaml
Type: System.DateTime
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePackageApplication
List of package applications.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IMsixPackageApplications[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePackageDependency
List of package dependencies.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IMsixPackageDependencies[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePackageFamilyName
Identifier not including the package version, for Msix packages it is the family name from the appxmanifest.xml.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePackageFullName
Identifier including the package version, for Msix packages it is the full name from the appxmanifest.xml.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImagePath
VHD/CIM/APP-V image path on Network Share.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
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
Type: System.String
Parameter Sets: UpdateExpanded, ImageObject, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases: AppAttachPackageName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageLookbackUrl
Lookback url to third party control plane, should be null for first party packages

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ImageObject
Aliases:

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
Parameter Sets: UpdateExpanded, ImageObject, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, ImageObject, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
tags to be updated

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.AppAttachPackage

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IAppAttachPackage

## NOTES

## RELATED LINKS
