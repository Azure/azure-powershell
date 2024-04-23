---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.springcloud/get-azspringcloudapp
schema: 2.0.0
---

# Get-AzSpringCloudApp

## SYNOPSIS
Get an App and its properties.

## SYNTAX

### List (Default)
```
Get-AzSpringCloudApp -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzSpringCloudApp -Name <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-SyncStatus <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringCloudApp -InputObject <ISpringCloudIdentity> [-SyncStatus <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get an App and its properties.

## EXAMPLES

### Example 1: Get all App under the spring service
```powershell
Get-AzSpringCloudApp -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service
```

```output
Name   SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----   ------------------- -------------------     ----------------------- ------------------------ ------------------------
plugin 2022/6/28 9:15:47   *********@microsoft.com User                    2022/6/28 9:15:47        *********@microsoft.com
tools  2022/6/28 8:33:27   *********@microsoft.com User                    2022/6/28 8:33:27        *********@microsoft.com
```

Get all App under the spring service.

### Example 2: Get an App and its properties
```powershell
Get-AzSpringCloudApp -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -Name tools
```

```output
Name  SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----  ------------------- -------------------     ----------------------- ------------------------ ------------------------
tools 2022/6/28 8:33:27   *********@microsoft.com User                    2022/6/28 8:33:27        *********@microsoft.com
```

Get an App and its properties.

### Example 3: Get an App and its properties by pipeline
```powershell
New-AzSpringCloudApp -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-service -Name tools | Get-AzSpringCloudApp
```

```output
Name  SystemDataCreatedAt SystemDataCreatedBy     SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
----  ------------------- -------------------     ----------------------- ------------------------ ------------------------
tools 2022/6/28 8:33:27   *********@microsoft.com User                    2022/6/28 8:33:27        *********@microsoft.com
```

Get an App and its properties by pipeline.

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
The name of the App resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AppName

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

### -SyncStatus
Indicates whether sync status

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.IAppResource

## NOTES

## RELATED LINKS
