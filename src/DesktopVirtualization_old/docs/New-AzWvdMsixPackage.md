---
external help file:
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/new-azwvdmsixpackage
schema: 2.0.0
---

# New-AzWvdMsixPackage

## SYNOPSIS
Create or update a MSIX package.

## SYNTAX

### CreateExpanded (Default)
```
New-AzWvdMsixPackage -FullName <String> -HostPoolName <String> -ResourceGroupName <String>
 [-DisplayName <String>] [-ImagePath <String>] [-IsActive] [-IsRegularRegistration] [-SubscriptionId <String>]
 [-LastUpdated <DateTime>] [-PackageApplication <IMsixPackageApplications[]>]
 [-PackageDependency <IMsixPackageDependencies[]>] [-PackageFamilyName <String>] [-PackageName <String>]
 [-PackageRelativePath <String>] [-Version <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### PackageAlias
```
New-AzWvdMsixPackage -HostPoolName <String> -PackageAlias <String> -ResourceGroupName <String>
 [-DisplayName <String>] [-ImagePath <String>] [-IsActive] [-IsRegularRegistration] [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Create or update a MSIX package.

## EXAMPLES

### Example 1: Creates New MSIX Package in the HostPool via Package Alias
```powershell
New-AzWvdMsixPackage -HostPoolName HostPoolName `
                     -ResourceGroupName resourceGroupName `
                     -SubscriptionId SubscriptionId `
                     -PackageAlias packagealias `
                     -ImagePath ImagePathURI
```

This command adds MSIX package from specified image path to HostPool

### Example 2: Creates New MSIX Package in the HostPool
```powershell
$apps = "<PackagedApplication>"
$deps = "<PackageDependencies>"
New-AzWvdMsixPackage -FullName PackageFullName `
                     -HostPoolName HostPoolName `
                     -ResourceGroupName ResourceGroupName `
                     -SubscriptionId SubscriptionId `
                     -DisplayName displayname `
                     -ImagePath imageURI `
                     -IsActive:$false `
                     -IsRegularRegistration:$false `
                     -LastUpdated datelastupdated `
                     -PackageApplication $apps `
                     -PackageDependency $deps `
                     -PackageFamilyName packagefamilyname `
                     -PackageName packagename `
                     -PackageRelativePath packagerelativepath `
                     -Version packageversion
```

```output
Name                              Type
----                              ----
HotPoolName/PackageFullName       Microsoft.DesktopVirtualization/hostpools/msixpackages

```

This command adds MSIX Package in the specified HostPool

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

### -DisplayName
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

### -FullName
The version specific package full name of the MSIX package within specified hostpool

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases: MsixPackageFullName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HostPoolName
The name of the host pool within the specified resource group

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
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

### -IsActive
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

### -IsRegularRegistration
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

### -LastUpdated
Date Package was last updated, found in the appxmanifest.xml.

```yaml
Type: System.DateTime
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageAlias
Package Alias from extract MSIX Image

```yaml
Type: System.String
Parameter Sets: PackageAlias
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageApplication
List of package applications.

To construct, see NOTES section for PACKAGEAPPLICATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IMsixPackageApplications[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageDependency
List of package dependencies.

To construct, see NOTES section for PACKAGEDEPENDENCY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IMsixPackageDependencies[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageFamilyName
Package Family Name from appxmanifest.xml.
Contains Package Name and Publisher name.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageName
Package Name from appxmanifest.xml.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageRelativePath
Relative Path to the package inside the image.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Package Version found in the appxmanifest.xml.

```yaml
Type: System.String
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api202209.IMsixPackage

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`PACKAGEAPPLICATION <IMsixPackageApplications[]>`: List of package applications. 
  - `[AppId <String>]`: Package Application Id, found in appxmanifest.xml.
  - `[AppUserModelId <String>]`: Used to activate Package Application. Consists of Package Name and ApplicationID. Found in appxmanifest.xml.
  - `[Description <String>]`: Description of Package Application.
  - `[FriendlyName <String>]`: User friendly name.
  - `[IconImageName <String>]`: User friendly name.
  - `[RawIcon <Byte[]>]`: the icon a 64 bit string as a byte array.
  - `[RawPng <Byte[]>]`: the icon a 64 bit string as a byte array.

`PACKAGEDEPENDENCY <IMsixPackageDependencies[]>`: List of package dependencies. 
  - `[DependencyName <String>]`: Name of package dependency.
  - `[MinVersion <String>]`: Dependency version required.
  - `[Publisher <String>]`: Name of dependency publisher.

## RELATED LINKS

