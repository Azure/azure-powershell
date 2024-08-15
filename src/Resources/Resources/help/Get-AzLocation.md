---
external help file: Microsoft.Azure.PowerShell.Cmdlets.ResourceManager.dll-Help.xml
Module Name: Az.Resources
ms.assetid: DC870E11-2129-4906-8357-D9BC1CF2E08E
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azlocation
schema: 2.0.0
---

# Get-AzLocation

## SYNOPSIS
Gets all locations and the supported resource providers for each location.

## SYNTAX

```
Get-AzLocation [-ExtendedLocation <Boolean>] [-ApiVersion <String>] [-Pre]
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzLocation** cmdlet gets all locations and the supported resource providers for each location.

## EXAMPLES

### Example 1: Get all locations and the supported resource providers
```powershell
Get-AzLocation
```

This command gets all locations and the supported resource providers for each location.

### Example 2: Get all locations supporting resource provider Microsoft.AppConfiguration
```powershell
Get-AzLocation | Where-Object {$_.Providers -contains "Microsoft.AppConfiguration"}
```

```output
Location    : eastasia
DisplayName : East Asia
Providers   : {Microsoft.Devices, Microsoft.Cache, Microsoft.AppConfiguration, microsoft.insights…}

Location    : southeastasia
DisplayName : Southeast Asia
Providers   : {Microsoft.Devices, Microsoft.Cache, Microsoft.AppConfiguration, microsoft.insights…}

Location    : centralus
DisplayName : Central US
Providers   : {Microsoft.Devices, Microsoft.Cache, Microsoft.AppConfiguration, microsoft.insights…}
...
```

This example gets all locations which supports resource provider "Microsoft.AppConfiguration".

## PARAMETERS

### -ApiVersion
Specifies the API version that is supported by the resource Provider.
You can specify a different version than the default version.

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

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure

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

### -ExtendedLocation
Whether to include extended locations.

```yaml
Type: System.Nullable`1[System.Boolean]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Pre
Indicates that this cmdlet considers pre-release API versions when it automatically determines which version to use.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.PSResourceProviderLocation

## NOTES

## RELATED LINKS
