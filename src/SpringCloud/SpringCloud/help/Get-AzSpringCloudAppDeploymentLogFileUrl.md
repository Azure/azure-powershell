---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.springcloud/get-azspringcloudappdeploymentlogfileurl
schema: 2.0.0
---

# Get-AzSpringCloudAppDeploymentLogFileUrl

## SYNOPSIS
Get deployment log file URL

## SYNTAX

### Get (Default)
```
Get-AzSpringCloudAppDeploymentLogFileUrl -AppName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-PassThru]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSpringCloudAppDeploymentLogFileUrl -InputObject <ISpringCloudIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Get deployment log file URL

## EXAMPLES

### Example 1: Get deployment log file URL
```powershell
Get-AzSpringCloudAppDeploymentLogFileUrl -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-01 -AppName tools -Name default
```

```output
url         :"https://xxxxxxxxxxxxxxxxxxxxxxxxxxx.blob.core.windows.net/8a34c541b97d45c591d5749e7ec77913/logs/?sv=2018-03-28&sr=b&sig=yAh3I%2B1P9pfSRknfOy%2BCheeomZNoKM9R1brvzj2OTtw%3D&se=2022-07-13T10%3A15%3A46Z&sp=r"
```

Get deployment log file URL.

### Example 2: Get deployment log file URL by pipeline
```powershell
Get-AzSpringCloudAppDeployment -ResourceGroupName SpringCloud-gp-junxi -ServiceName springcloud-01 -AppName tools -Name default | Get-AzSpringCloudAppDeploymentLogFileUrl
```

```output
url         :"https://xxxxxxxxxxxxxxxxxxxxxxxxxxx.blob.core.windows.net/8a34c541b97d45c591d5749e7ec77913/logs/?sv=2018-03-28&sr=b&sig=yAh3I%2B1P9pfSRknfOy%2BCheeomZNoKM9R1brvzj2OTtw%3D&se=2022-07-13T10%3A15%3A46Z&sp=r"
```

Get deployment log file URL by pipeline.

## PARAMETERS

### -AppName
The name of the App resource.

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
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

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

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

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

### -ServiceName
The name of the Service resource.

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

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String[]
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity

## OUTPUTS

### System.String

## NOTES

## RELATED LINKS
