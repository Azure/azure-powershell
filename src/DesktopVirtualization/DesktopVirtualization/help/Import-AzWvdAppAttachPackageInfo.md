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
 [-PackageArchitecture <AppAttachPackageArchitectures>] [-Path <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Import
```
Import-AzWvdAppAttachPackageInfo -HostPoolName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -ImportPackageInfoRequest <IImportPackageInfoRequest> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ImportViaIdentityExpanded
```
Import-AzWvdAppAttachPackageInfo -InputObject <IDesktopVirtualizationIdentity>
 [-PackageArchitecture <AppAttachPackageArchitectures>] [-Path <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ImportViaIdentity
```
Import-AzWvdAppAttachPackageInfo -InputObject <IDesktopVirtualizationIdentity>
 -ImportPackageInfoRequest <IImportPackageInfoRequest> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Gets information from a package given the path to the package.

## EXAMPLES

### EXAMPLE 1
```
Import-AzWvdAppAttachPackageInfo -HostPoolName HostPoolName `
          -ResourceGroupName resourceGroupName `
          -SubscriptionId SubscriptionId `
          -Path ImagePathURI
```

## PARAMETERS

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

### -HostPoolName
The name of the host pool within the specified resource group

```yaml
Type: String
Parameter Sets: ImportExpanded, Import
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ImportPackageInfoRequest
Information to import app attach package
To construct, see NOTES section for IMPORTPACKAGEINFOREQUEST properties and create a hash table.

```yaml
Type: IImportPackageInfoRequest
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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: IDesktopVirtualizationIdentity
Parameter Sets: ImportViaIdentityExpanded, ImportViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PackageArchitecture
Possible device architectures that an app attach package can be configured for

```yaml
Type: AppAttachPackageArchitectures
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
Type: String
Parameter Sets: ImportExpanded, ImportViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
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
Parameter Sets: ImportExpanded, Import
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
Parameter Sets: ImportExpanded, Import
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231101Preview.IImportPackageInfoRequest
### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.Api20231101Preview.IAppAttachPackage
## NOTES
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties.
For information on hash tables, run Get-Help about_Hash_Tables.

IMPORTPACKAGEINFOREQUEST \<IImportPackageInfoRequest\>: Information to import app attach package
  \[PackageArchitecture \<AppAttachPackageArchitectures?\>\]: Possible device architectures that an app attach package can be configured for
  \[Path \<String\>\]: URI to Image

INPUTOBJECT \<IDesktopVirtualizationIdentity\>: Identity Parameter
  \[AppAttachPackageName \<String\>\]: The name of the App Attach package arm object
  \[ApplicationGroupName \<String\>\]: The name of the application group
  \[ApplicationName \<String\>\]: The name of the application within the specified application group
  \[DesktopName \<String\>\]: The name of the desktop within the specified desktop group
  \[HostPoolName \<String\>\]: The name of the host pool within the specified resource group
  \[Id \<String\>\]: Resource identity path
  \[MsixPackageFullName \<String\>\]: The version specific package full name of the MSIX package within specified hostpool
  \[OperationId \<String\>\]: The Guid of the operation.
  \[PrivateEndpointConnectionName \<String\>\]: The name of the private endpoint connection associated with the Azure resource
  \[ResourceGroupName \<String\>\]: The name of the resource group.
The name is case insensitive.
  \[ScalingPlanName \<String\>\]: The name of the scaling plan.
  \[ScalingPlanScheduleName \<String\>\]: The name of the ScalingPlanSchedule
  \[SessionHostName \<String\>\]: The name of the session host within the specified host pool
  \[SubscriptionId \<String\>\]: The ID of the target subscription.
  \[UserSessionId \<String\>\]: The name of the user session within the specified session host
  \[WorkspaceName \<String\>\]: The name of the workspace

## RELATED LINKS

[https://learn.microsoft.com/powershell/module/az.desktopvirtualization/import-azwvdappattachpackageinfo](https://learn.microsoft.com/powershell/module/az.desktopvirtualization/import-azwvdappattachpackageinfo)

