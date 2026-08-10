---
external help file: Az.DesktopVirtualization-help.xml
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/import-azwvdappattachpackageinfo
schema: 2.0.0
---

# Import-AzWvdAppAttachPackageInfo

## SYNOPSIS
Gets information from a package given the path to the package.

## SYNTAX

### ImportExpanded (Default)
```
Import-AzWvdAppAttachPackageInfo -HostPoolName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-PackageArchitecture <String>] [-Path <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ImportViaJsonString
```
Import-AzWvdAppAttachPackageInfo -HostPoolName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ImportViaJsonFilePath
```
Import-AzWvdAppAttachPackageInfo -HostPoolName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Import
```
Import-AzWvdAppAttachPackageInfo -HostPoolName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -ImportPackageInfoRequest <IImportPackageInfoRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ImportViaIdentityExpanded
```
Import-AzWvdAppAttachPackageInfo -InputObject <IDesktopVirtualizationIdentity> [-PackageArchitecture <String>]
 [-Path <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ImportViaIdentity
```
Import-AzWvdAppAttachPackageInfo -InputObject <IDesktopVirtualizationIdentity>
 -ImportPackageInfoRequest <IImportPackageInfoRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Gets information from a package given the path to the package.

## EXAMPLES

### Example 1: Creates an AppAttachPackage object from Package metadata found in AppxManifest.xml
```powershell
Import-AzWvdAppAttachPackageInfo -HostPoolName HostPoolName `
          -ResourceGroupName resourceGroupName `
          -SubscriptionId SubscriptionId `
          -Path ImagePathURI
```

```output
Name                       Type
----                       ----
importappattachpackageinfo Microsoft.DesktopVirtualization/appattachpackages
```

This command returns Metadata of MSIX Package found in the given Image Path.

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

### -HostPoolName
The name of the host pool within the specified resource group

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaJsonString, ImportViaJsonFilePath, Import
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImportPackageInfoRequest
Information to import app attach package

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IImportPackageInfoRequest
Parameter Sets: Import, ImportViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
Parameter Sets: ImportViaIdentityExpanded, ImportViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Import operation

```yaml
Type: System.String
Parameter Sets: ImportViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Import operation

```yaml
Type: System.String
Parameter Sets: ImportViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PackageArchitecture
Possible device architectures that an app attach package can be configured for

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
URI to Image

```yaml
Type: System.String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
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
Parameter Sets: ImportExpanded, ImportViaJsonString, ImportViaJsonFilePath, Import
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
Parameter Sets: ImportExpanded, ImportViaJsonString, ImportViaJsonFilePath, Import
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IImportPackageInfoRequest

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IAppAttachPackage

## NOTES

## RELATED LINKS
