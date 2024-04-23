---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.springcloud/get-azspringcloudappdeployment
schema: 2.0.0
---

# Get-AzSpringCloudAppDeployment

## SYNOPSIS
Get a Deployment and its properties.

## SYNTAX

### List1 (Default)
```
Get-AzSpringCloudAppDeployment -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String[]>]
 [-Version <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List
```
Get-AzSpringCloudAppDeployment -AppName <String> -ResourceGroupName <String> -ServiceName <String>
 [-SubscriptionId <String[]>] [-Version <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzSpringCloudAppDeployment -AppName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringCloudAppDeployment -InputObject <ISpringCloudIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get a Deployment and its properties.

## EXAMPLES

### Example 1: Get Spring Cloud App Deploymeng by name
```powershell
Get-AzSpringCloudAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default
```

```output
Name    SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----    -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
jardemo 7/25/2022 9:29:46 AM v-diya@microsoft.com User                    7/25/2022 9:38:28 AM     v-diya@microsoft.com     User                         springcloudrg
```

Get Spring Cloud App Deploymeng by name.

### Example 2: List all the deployment under a given spring cloud app
```powershell
Get-AzSpringCloudAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway
```

```output
Name    SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----    -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
jardemo 7/25/2022 9:29:46 AM v-diya@microsoft.com User                    7/25/2022 9:38:28 AM     v-diya@microsoft.com     User                         springcloudrg
```

List all the deployment under a given spring cloud app.

### Example 3: List all the deployment under a given subscription
```powershell
Get-AzSpringCloudAppDeployment -ResourceGroupName 'springcloudrg' -ServiceName 'standardspring-demo'
```

```output
Name    SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----    -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
jardemo 7/25/2022 9:29:46 AM v-diya@microsoft.com User                    7/25/2022 9:38:28 AM     v-diya@microsoft.com     User                         springcloudrg
```

List all the deployment under a given subscription.

## PARAMETERS

### -AppName
The name of the App resource.

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
The name of the Deployment resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DeploymentName

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
Parameter Sets: List1, List, Get
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
Parameter Sets: List1, List, Get
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
Parameter Sets: List1, List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Version
Version of the deployments to be listed

```yaml
Type: System.String[]
Parameter Sets: List1, List
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.IDeploymentResource

## NOTES

## RELATED LINKS
