---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/test-azdeployment
schema: 2.0.0
---

# Test-AzDeployment

## SYNOPSIS
Validates whether the specified template is syntactically correct and will be accepted by Azure Resource Manager..

## SYNTAX

### ValidateWithTemplateFileParameterFile (Default)
```
Test-AzDeployment -Name <String> -Mode <DeploymentMode> -TemplateFile <String> -TemplateParameterFile <String>
 [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>] [-DeploymentPropertyParameter <Hashtable>]
 [-Location <String>] [-OnErrorDeploymentName <String>] [-OnErrorDeploymentType <OnErrorDeploymentType>]
 [-ParameterLinkContentVersion <String>] [-ParameterLinkUri <String>] [-Template <Hashtable>]
 [-TemplateLinkContentVersion <String>] [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateRGWithTemplateFileParameterFile
```
Test-AzDeployment -Name <String> -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateFile <String>
 -TemplateParameterFile <String> [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>]
 [-DeploymentPropertyParameter <Hashtable>] [-Location <String>] [-OnErrorDeploymentName <String>]
 [-OnErrorDeploymentType <OnErrorDeploymentType>] [-ParameterLinkContentVersion <String>]
 [-ParameterLinkUri <String>] [-Template <Hashtable>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateRGWithTemplateFileParameterJson
```
Test-AzDeployment -Name <String> -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateFile <String>
 -TemplateParameterJson <String> [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>]
 [-DeploymentPropertyParameter <Hashtable>] [-Location <String>] [-OnErrorDeploymentName <String>]
 [-OnErrorDeploymentType <OnErrorDeploymentType>] [-ParameterLinkContentVersion <String>]
 [-ParameterLinkUri <String>] [-Template <Hashtable>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateRGWithTemplateFileParameterObject
```
Test-AzDeployment -Name <String> -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateFile <String>
 -TemplateParameterObject <Hashtable> [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>]
 [-DeploymentPropertyParameter <Hashtable>] [-Location <String>] [-OnErrorDeploymentName <String>]
 [-OnErrorDeploymentType <OnErrorDeploymentType>] [-ParameterLinkContentVersion <String>]
 [-ParameterLinkUri <String>] [-Template <Hashtable>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateRGWithTemplateJsonParameterFile
```
Test-AzDeployment -Name <String> -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateJson <String>
 -TemplateParameterFile <String> [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>]
 [-DeploymentPropertyParameter <Hashtable>] [-Location <String>] [-OnErrorDeploymentName <String>]
 [-OnErrorDeploymentType <OnErrorDeploymentType>] [-ParameterLinkContentVersion <String>]
 [-ParameterLinkUri <String>] [-Template <Hashtable>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateRGWithTemplateJsonParameterJson
```
Test-AzDeployment -Name <String> -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateJson <String>
 -TemplateParameterJson <String> [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>]
 [-DeploymentPropertyParameter <Hashtable>] [-Location <String>] [-OnErrorDeploymentName <String>]
 [-OnErrorDeploymentType <OnErrorDeploymentType>] [-ParameterLinkContentVersion <String>]
 [-ParameterLinkUri <String>] [-Template <Hashtable>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateRGWithTemplateJsonParameterObject
```
Test-AzDeployment -Name <String> -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateJson <String>
 -TemplateParameterObject <Hashtable> [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>]
 [-DeploymentPropertyParameter <Hashtable>] [-Location <String>] [-OnErrorDeploymentName <String>]
 [-OnErrorDeploymentType <OnErrorDeploymentType>] [-ParameterLinkContentVersion <String>]
 [-ParameterLinkUri <String>] [-Template <Hashtable>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateRGWithTemplateObjectParameterFile
```
Test-AzDeployment -Name <String> -ResourceGroupName <String> -Mode <DeploymentMode>
 -TemplateObject <Hashtable> -TemplateParameterFile <String> [-SubscriptionId <String>]
 [-DebugSettingDetailLevel <String>] [-DeploymentPropertyParameter <Hashtable>] [-Location <String>]
 [-OnErrorDeploymentName <String>] [-OnErrorDeploymentType <OnErrorDeploymentType>]
 [-ParameterLinkContentVersion <String>] [-ParameterLinkUri <String>] [-Template <Hashtable>]
 [-TemplateLinkContentVersion <String>] [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateRGWithTemplateObjectParameterJson
```
Test-AzDeployment -Name <String> -ResourceGroupName <String> -Mode <DeploymentMode>
 -TemplateObject <Hashtable> -TemplateParameterJson <String> [-SubscriptionId <String>]
 [-DebugSettingDetailLevel <String>] [-DeploymentPropertyParameter <Hashtable>] [-Location <String>]
 [-OnErrorDeploymentName <String>] [-OnErrorDeploymentType <OnErrorDeploymentType>]
 [-ParameterLinkContentVersion <String>] [-ParameterLinkUri <String>] [-Template <Hashtable>]
 [-TemplateLinkContentVersion <String>] [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateRGWithTemplateObjectParameterObject
```
Test-AzDeployment -Name <String> -ResourceGroupName <String> -Mode <DeploymentMode>
 -TemplateObject <Hashtable> -TemplateParameterObject <Hashtable> [-SubscriptionId <String>]
 [-DebugSettingDetailLevel <String>] [-DeploymentPropertyParameter <Hashtable>] [-Location <String>]
 [-OnErrorDeploymentName <String>] [-OnErrorDeploymentType <OnErrorDeploymentType>]
 [-ParameterLinkContentVersion <String>] [-ParameterLinkUri <String>] [-Template <Hashtable>]
 [-TemplateLinkContentVersion <String>] [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateWithTemplateFileParameterJson
```
Test-AzDeployment -Name <String> -Mode <DeploymentMode> -TemplateFile <String> -TemplateParameterJson <String>
 [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>] [-DeploymentPropertyParameter <Hashtable>]
 [-Location <String>] [-OnErrorDeploymentName <String>] [-OnErrorDeploymentType <OnErrorDeploymentType>]
 [-ParameterLinkContentVersion <String>] [-ParameterLinkUri <String>] [-Template <Hashtable>]
 [-TemplateLinkContentVersion <String>] [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateWithTemplateFileParameterObject
```
Test-AzDeployment -Name <String> -Mode <DeploymentMode> -TemplateFile <String>
 -TemplateParameterObject <Hashtable> [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>]
 [-DeploymentPropertyParameter <Hashtable>] [-Location <String>] [-OnErrorDeploymentName <String>]
 [-OnErrorDeploymentType <OnErrorDeploymentType>] [-ParameterLinkContentVersion <String>]
 [-ParameterLinkUri <String>] [-Template <Hashtable>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateWithTemplateJsonParameterFile
```
Test-AzDeployment -Name <String> -Mode <DeploymentMode> -TemplateJson <String> -TemplateParameterFile <String>
 [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>] [-DeploymentPropertyParameter <Hashtable>]
 [-Location <String>] [-OnErrorDeploymentName <String>] [-OnErrorDeploymentType <OnErrorDeploymentType>]
 [-ParameterLinkContentVersion <String>] [-ParameterLinkUri <String>] [-Template <Hashtable>]
 [-TemplateLinkContentVersion <String>] [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateWithTemplateJsonParameterJson
```
Test-AzDeployment -Name <String> -Mode <DeploymentMode> -TemplateJson <String> -TemplateParameterJson <String>
 [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>] [-DeploymentPropertyParameter <Hashtable>]
 [-Location <String>] [-OnErrorDeploymentName <String>] [-OnErrorDeploymentType <OnErrorDeploymentType>]
 [-ParameterLinkContentVersion <String>] [-ParameterLinkUri <String>] [-Template <Hashtable>]
 [-TemplateLinkContentVersion <String>] [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateWithTemplateJsonParameterObject
```
Test-AzDeployment -Name <String> -Mode <DeploymentMode> -TemplateJson <String>
 -TemplateParameterObject <Hashtable> [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>]
 [-DeploymentPropertyParameter <Hashtable>] [-Location <String>] [-OnErrorDeploymentName <String>]
 [-OnErrorDeploymentType <OnErrorDeploymentType>] [-ParameterLinkContentVersion <String>]
 [-ParameterLinkUri <String>] [-Template <Hashtable>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateWithTemplateObjectParameterFile
```
Test-AzDeployment -Name <String> -Mode <DeploymentMode> -TemplateObject <Hashtable>
 -TemplateParameterFile <String> [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>]
 [-DeploymentPropertyParameter <Hashtable>] [-Location <String>] [-OnErrorDeploymentName <String>]
 [-OnErrorDeploymentType <OnErrorDeploymentType>] [-ParameterLinkContentVersion <String>]
 [-ParameterLinkUri <String>] [-Template <Hashtable>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateWithTemplateObjectParameterJson
```
Test-AzDeployment -Name <String> -Mode <DeploymentMode> -TemplateObject <Hashtable>
 -TemplateParameterJson <String> [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>]
 [-DeploymentPropertyParameter <Hashtable>] [-Location <String>] [-OnErrorDeploymentName <String>]
 [-OnErrorDeploymentType <OnErrorDeploymentType>] [-ParameterLinkContentVersion <String>]
 [-ParameterLinkUri <String>] [-Template <Hashtable>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateWithTemplateObjectParameterObject
```
Test-AzDeployment -Name <String> -Mode <DeploymentMode> -TemplateObject <Hashtable>
 -TemplateParameterObject <Hashtable> [-SubscriptionId <String>] [-DebugSettingDetailLevel <String>]
 [-DeploymentPropertyParameter <Hashtable>] [-Location <String>] [-OnErrorDeploymentName <String>]
 [-OnErrorDeploymentType <OnErrorDeploymentType>] [-ParameterLinkContentVersion <String>]
 [-ParameterLinkUri <String>] [-Template <Hashtable>] [-TemplateLinkContentVersion <String>]
 [-TemplateLinkUri <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validates whether the specified template is syntactically correct and will be accepted by Azure Resource Manager..

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

### -DebugSettingDetailLevel
Specifies the type of information to log for debugging.
The permitted values are none, requestContent, responseContent, or both requestContent and responseContent separated by a comma.
The default is none.
When setting this value, carefully consider the type of information you are passing in during deployment.
By logging information about the request or response, you could potentially expose sensitive data that is retrieved through the deployment operations.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -DeploymentPropertyParameter
Name and value pairs that define the deployment parameters for the template.
You use this element when you want to provide the parameter values directly in the request rather than link to an existing parameter file.
Use either the parametersLink property or the parameters property, but not both.
It can be a JObject or a well formed JSON string.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ParameterLinkContentVersion
If included, must match the ContentVersion in the template.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group the template will be deployed to.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: ValidateRGWithTemplateFileParameterFile, ValidateRGWithTemplateFileParameterJson, ValidateRGWithTemplateFileParameterObject, ValidateRGWithTemplateJsonParameterFile, ValidateRGWithTemplateJsonParameterJson, ValidateRGWithTemplateJsonParameterObject, ValidateRGWithTemplateObjectParameterFile, ValidateRGWithTemplateObjectParameterJson, ValidateRGWithTemplateObjectParameterObject
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

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TemplateFile
Local path to the JSON template file.

```yaml
Type: System.String
Parameter Sets: ValidateRGWithTemplateFileParameterFile, ValidateRGWithTemplateFileParameterJson, ValidateRGWithTemplateFileParameterObject, ValidateWithTemplateFileParameterFile, ValidateWithTemplateFileParameterJson, ValidateWithTemplateFileParameterObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TemplateJson
The string representation of the JSON template.

```yaml
Type: System.String
Parameter Sets: ValidateRGWithTemplateJsonParameterFile, ValidateRGWithTemplateJsonParameterJson, ValidateRGWithTemplateJsonParameterObject, ValidateWithTemplateJsonParameterFile, ValidateWithTemplateJsonParameterJson, ValidateWithTemplateJsonParameterObject
Aliases:

Required: True
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
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TemplateObject
The hashtable representation of the JSON template.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ValidateRGWithTemplateObjectParameterFile, ValidateRGWithTemplateObjectParameterJson, ValidateRGWithTemplateObjectParameterObject, ValidateWithTemplateObjectParameterFile, ValidateWithTemplateObjectParameterJson, ValidateWithTemplateObjectParameterObject
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TemplateParameterFile
Local path to the parameter JSON template file.

```yaml
Type: System.String
Parameter Sets: ValidateRGWithTemplateFileParameterFile, ValidateRGWithTemplateJsonParameterFile, ValidateRGWithTemplateObjectParameterFile, ValidateWithTemplateFileParameterFile, ValidateWithTemplateJsonParameterFile, ValidateWithTemplateObjectParameterFile
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TemplateParameterJson
The string representation of the parameter JSON template.

```yaml
Type: System.String
Parameter Sets: ValidateRGWithTemplateFileParameterJson, ValidateRGWithTemplateJsonParameterJson, ValidateRGWithTemplateObjectParameterJson, ValidateWithTemplateFileParameterJson, ValidateWithTemplateJsonParameterJson, ValidateWithTemplateObjectParameterJson
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TemplateParameterObject
The hashtable representation of the parameter JSON template.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: ValidateRGWithTemplateFileParameterObject, ValidateRGWithTemplateJsonParameterObject, ValidateRGWithTemplateObjectParameterObject, ValidateWithTemplateFileParameterObject, ValidateWithTemplateJsonParameterObject, ValidateWithTemplateObjectParameterObject
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeploymentValidateResult

## ALIASES

### Test-AzResourceGroupDeployment

## NOTES

## RELATED LINKS

