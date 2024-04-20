---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.springcloud/get-azspringcloudbuildservicesupportedbuildpack
schema: 2.0.0
---

# Get-AzSpringCloudBuildServiceSupportedBuildpack

## SYNOPSIS
Get the supported buildpack resource.

## SYNTAX

### List (Default)
```
Get-AzSpringCloudBuildServiceSupportedBuildpack -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzSpringCloudBuildServiceSupportedBuildpack -Name <String> -ResourceGroupName <String>
 -ServiceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringCloudBuildServiceSupportedBuildpack -InputObject <ISpringCloudIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get the supported buildpack resource.

## EXAMPLES

### Example 1: Get all supported buildpack resource.
```powershell
Get-AzSpringCloudBuildServiceSupportedBuildpack -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-01
```

```output
Name                         ResourceGroupName BuildpackId
----                         ----------------- -----------
tanzu-buildpacks-java-azure  springcloudrg     tanzu-buildpacks/java-azure
tanzu-buildpacks-dotnet-core springcloudrg     tanzu-buildpacks/dotnet-core
tanzu-buildpacks-go          springcloudrg     tanzu-buildpacks/go
tanzu-buildpacks-nodejs      springcloudrg     tanzu-buildpacks/nodejs
tanzu-buildpacks-python      springcloudrg     tanzu-buildpacks/python
```

Get all supported buildpack resource.

### Example 2: Get the supported buildpack resource by name
```powershell
Get-AzSpringCloudBuildServiceSupportedBuildpack -ResourceGroupName springcloudrg -ServiceName sspring-portal01 -Name tanzu-buildpacks-python
```

```output
Name                    ResourceGroupName BuildpackId
----                    ----------------- -----------
tanzu-buildpacks-python springcloudrg     tanzu-buildpacks/python
```

Get the supported buildpack resource by name.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the buildpack resource.

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
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

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

### -ServiceName
The name of the Service resource.

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
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.ISupportedBuildpackResource

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.ISupportedBuildpacksCollection

## NOTES

## RELATED LINKS
