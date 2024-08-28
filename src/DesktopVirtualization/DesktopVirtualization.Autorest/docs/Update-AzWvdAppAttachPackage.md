---
external help file:
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
 [-FailHealthCheckOnStagingFailure <FailHealthCheckOnStagingFailure>] [-HostPoolReference <String[]>]
 [-ImageCertificateExpiry <DateTime>] [-ImageCertificateName <String>] [-ImageDisplayName <String>]
 [-ImageIsActive] [-ImageIsPackageTimestamped <PackageTimestamped>] [-ImageIsRegularRegistration]
 [-ImageLastUpdated <DateTime>] [-ImagePackageAlias <String>]
 [-ImagePackageApplication <IMsixPackageApplications[]>]
 [-ImagePackageDependency <IMsixPackageDependencies[]>] [-ImagePackageFamilyName <String>]
 [-ImagePackageFullName <String>] [-ImagePackageName <String>] [-ImagePackageRelativePath <String>]
 [-ImagePath <String>] [-ImageVersion <String>] [-KeyVaultUrl <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzWvdAppAttachPackage -InputObject <IDesktopVirtualizationIdentity>
 [-FailHealthCheckOnStagingFailure <FailHealthCheckOnStagingFailure>] [-HostPoolReference <String[]>]
 [-ImageCertificateExpiry <DateTime>] [-ImageCertificateName <String>] [-ImageDisplayName <String>]
 [-ImageIsActive] [-ImageIsPackageTimestamped <PackageTimestamped>] [-ImageIsRegularRegistration]
 [-ImageLastUpdated <DateTime>] [-ImagePackageAlias <String>]
 [-ImagePackageApplication <IMsixPackageApplications[]>]
 [-ImagePackageDependency <IMsixPackageDependencies[]>] [-ImagePackageFamilyName <String>]
 [-ImagePackageFullName <String>] [-ImagePackageName <String>] [-ImagePackageRelativePath <String>]
 [-ImagePath <String>] [-ImageVersion <String>] [-KeyVaultUrl <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Update an App Attach Package

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

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

### -FailHealthCheckOnStagingFailure
Parameter indicating how the health check should behave if this package fails staging

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.FailHealthCheckOnStagingFailure
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
Type: System.String[]
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
Type: System.DateTime
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageIsPackageTimestamped
Is package timestamped so it can ignore the certificate expiry date

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Support.PackageTimestamped
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageLastUpdated
Date Package was last updated, found in the appxmanifest.xml.

```yaml
Type: System.DateTime
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20240403.IMsixPackageApplications[]
Parameter Sets: (All)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20240403.IMsixPackageDependencies[]
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImageVersion
Package version found in the appxmanifest.xml.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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

### -KeyVaultUrl
URL path to certificate name located in keyVault

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the App Attach package

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: AppAttachPackageName

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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20240403.IAppAttachPackage

## NOTES

## RELATED LINKS

