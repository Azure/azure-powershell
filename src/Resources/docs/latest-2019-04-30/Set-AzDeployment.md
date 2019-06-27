---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/set-azdeployment
schema: 2.0.0
---

# Set-AzDeployment

## SYNOPSIS
You can provide the template and parameters directly in the request or link to JSON files.

## SYNTAX

### Update (Default)
```
Set-AzDeployment -Name <String> -SubscriptionId <String> [-Parameter <IDeployment>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded1
```
Set-AzDeployment -Name <String> -SubscriptionId <String> -ResourceGroupName <String> -Mode <DeploymentMode>
 -ParameterLinkUri <String> -TemplateLinkUri <String> [-Parameter <IDeployment>]
 [-DebugSettingDetailLevel <String>] [-Location <String>] [-OnErrorDeploymentName <String>]
 [-OnErrorDeploymentType <OnErrorDeploymentType>] [-ParameterLinkContentVersion <String>]
 [-Template <IDeploymentPropertiesTemplate>] [-TemplateLinkContentVersion <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update1
```
Set-AzDeployment -Name <String> -SubscriptionId <String> -ResourceGroupName <String>
 [-Parameter <IDeployment>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Set-AzDeployment -Name <String> -SubscriptionId <String> -Mode <DeploymentMode> -ParameterLinkUri <String>
 -TemplateLinkUri <String> [-Parameter <IDeployment>] [-DebugSettingDetailLevel <String>] [-Location <String>]
 [-OnErrorDeploymentName <String>] [-OnErrorDeploymentType <OnErrorDeploymentType>]
 [-ParameterLinkContentVersion <String>] [-Template <IDeploymentPropertiesTemplate>]
 [-TemplateLinkContentVersion <String>] [-DefaultProfile <PSObject>] [-AsJob] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
You can provide the template and parameters directly in the request or link to JSON files.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DebugSettingDetailLevel
Specifies the type of information to log for debugging.
The permitted values are none, requestContent, responseContent, or both requestContent and responseContent separated by a comma.
The default is none.
When setting this value, carefully consider the type of information you are passing in during deployment.
By logging information about the request or response, you could potentially expose sensitive data that is retrieved through the deployment operations.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
The location to store the deployment data.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Mode
The mode that is used to deploy resources.
This value can be either Incremental or Complete.
In Incremental mode, resources are deployed without deleting existing resources that are not included in the template.
In Complete mode, resources are deployed and existing resources in the resource group that are not included in the template are deleted.
Be careful when using Complete mode as you may unintentionally delete resources.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.DeploymentMode
Parameter Sets: UpdateExpanded1, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the deployment.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DeploymentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OnErrorDeploymentName
The deployment to be used on error case.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -OnErrorDeploymentType
The deployment on error behavior type.
Possible values are LastSuccessful and SpecificDeployment.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.OnErrorDeploymentType
Parameter Sets: UpdateExpanded1, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Deployment operation parameters.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeployment
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ParameterLinkContentVersion
If included, must match the ContentVersion in the template.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ParameterLinkUri
The URI of the parameters file.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group to deploy the resources to.
The name is case insensitive.
The resource group must already exist.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, Update1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Template
The template content.
You use this element when you want to pass the template syntax directly in the request rather than link to an existing template.
It can be a JObject or well-formed JSON string.
Use either the templateLink property or the template property, but not both.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeploymentPropertiesTemplate
Parameter Sets: UpdateExpanded1, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TemplateLinkContentVersion
If included, must match the ContentVersion in the template.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TemplateLinkUri
The URI of the template to deploy.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeployment

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeploymentExtended

## ALIASES

### Set-AzResourceGroupDeployment

## RELATED LINKS

