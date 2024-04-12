---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.springcloud/get-azspringcloudbuildpackbinding
schema: 2.0.0
---

# Get-AzSpringCloudBuildpackBinding

## SYNOPSIS
Get a buildpack binding by name.

## SYNTAX

### List (Default)
```
Get-AzSpringCloudBuildpackBinding -BuilderName <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### Get
```
Get-AzSpringCloudBuildpackBinding -BuilderName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringCloudBuildpackBinding -InputObject <ISpringCloudIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get a buildpack binding by name.

## EXAMPLES

### Example 1: List all buildpack binding
```powershell
Get-AzSpringCloudBuildpackBinding -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-01 -BuilderName default
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/13 3:26:33   *********@microsoft.com User                    2022/7/13 3:26:33        *********@microso…
```

List all buildpack binding.

### Example 2: Get a buildpack binding by name
```powershell
Get-AzSpringCloudBuildpackBinding -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-01 -BuilderName default -Name default
```

```output
Name    SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----    ------------------- -------------------     ----------------------- ------------------------ ------------------
default 2022/7/13 3:26:33   *********@microsoft.com User                    2022/7/13 3:26:33        *********@microso…
```

Get a buildpack binding by name.

### Example 2: Get a buildpack binding by pipeline
```powershell
New-AzSpringCloudBuildpackBinding -ResourceGroupName springcloudrg -ServiceName sspring-portal01 -BuilderName default -Name binging01 -BindingType 'AppDynamics' | Get-AzSpringCloudBuildpackBinding
```

```output
Name      SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModi
                                                                                                     fiedBy
----      ------------------- -------------------     ----------------------- ------------------------ ------------------
binging01 2022/7/13 3:26:33   *********@microsoft.com User                    2022/7/13 3:26:33        *********@microso…
```

Get a buildpack binding by pipeline.

## PARAMETERS

### -BuilderName
The name of the builder resource.

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
The name of the Buildpack Binding Name

```yaml
Type: System.String
Parameter Sets: Get
Aliases: BuildpackBindingName

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.IBuildpackBindingResource

## NOTES

## RELATED LINKS
