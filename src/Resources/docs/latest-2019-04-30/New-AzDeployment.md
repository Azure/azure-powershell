---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/new-azdeployment
schema: 2.0.0
---

# New-AzDeployment

## SYNOPSIS
You can provide the template and parameters directly in the request or link to JSON files.

## SYNTAX

### CreateWithTemplateFileParameterFile (Default)
```
New-AzDeployment -Mode <DeploymentMode> -TemplateFile <String> -TemplateParameterFile <String>
 [-Name <String>] [-SubscriptionId <String>] [-DeploymentDebugLogLevel <String>] [-Location <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateRGWithTemplateFileParameterFile
```
New-AzDeployment -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateFile <String>
 -TemplateParameterFile <String> [-Name <String>] [-SubscriptionId <String>]
 [-DeploymentDebugLogLevel <String>] [-Location <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateRGWithTemplateFileParameterJson
```
New-AzDeployment -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateFile <String>
 -TemplateParameterJson <String> [-Name <String>] [-SubscriptionId <String>]
 [-DeploymentDebugLogLevel <String>] [-Location <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateRGWithTemplateFileParameterObject
```
New-AzDeployment -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateFile <String>
 -TemplateParameterObject <Hashtable> [-Name <String>] [-SubscriptionId <String>]
 [-DeploymentDebugLogLevel <String>] [-Location <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateRGWithTemplateJsonParameterFile
```
New-AzDeployment -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateJson <String>
 -TemplateParameterFile <String> [-Name <String>] [-SubscriptionId <String>]
 [-DeploymentDebugLogLevel <String>] [-Location <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateRGWithTemplateJsonParameterJson
```
New-AzDeployment -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateJson <String>
 -TemplateParameterJson <String> [-Name <String>] [-SubscriptionId <String>]
 [-DeploymentDebugLogLevel <String>] [-Location <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateRGWithTemplateJsonParameterObject
```
New-AzDeployment -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateJson <String>
 -TemplateParameterObject <Hashtable> [-Name <String>] [-SubscriptionId <String>]
 [-DeploymentDebugLogLevel <String>] [-Location <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateRGWithTemplateObjectParameterFile
```
New-AzDeployment -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateObject <Hashtable>
 -TemplateParameterFile <String> [-Name <String>] [-SubscriptionId <String>]
 [-DeploymentDebugLogLevel <String>] [-Location <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateRGWithTemplateObjectParameterJson
```
New-AzDeployment -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateObject <Hashtable>
 -TemplateParameterJson <String> [-Name <String>] [-SubscriptionId <String>]
 [-DeploymentDebugLogLevel <String>] [-Location <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateRGWithTemplateObjectParameterObject
```
New-AzDeployment -ResourceGroupName <String> -Mode <DeploymentMode> -TemplateObject <Hashtable>
 -TemplateParameterObject <Hashtable> [-Name <String>] [-SubscriptionId <String>]
 [-DeploymentDebugLogLevel <String>] [-Location <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateWithTemplateFileParameterJson
```
New-AzDeployment -Mode <DeploymentMode> -TemplateFile <String> -TemplateParameterJson <String>
 [-Name <String>] [-SubscriptionId <String>] [-DeploymentDebugLogLevel <String>] [-Location <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateWithTemplateFileParameterObject
```
New-AzDeployment -Mode <DeploymentMode> -TemplateFile <String> -TemplateParameterObject <Hashtable>
 [-Name <String>] [-SubscriptionId <String>] [-DeploymentDebugLogLevel <String>] [-Location <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateWithTemplateJsonParameterFile
```
New-AzDeployment -Mode <DeploymentMode> -TemplateJson <String> -TemplateParameterFile <String>
 [-Name <String>] [-SubscriptionId <String>] [-DeploymentDebugLogLevel <String>] [-Location <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateWithTemplateJsonParameterJson
```
New-AzDeployment -Mode <DeploymentMode> -TemplateJson <String> -TemplateParameterJson <String>
 [-Name <String>] [-SubscriptionId <String>] [-DeploymentDebugLogLevel <String>] [-Location <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateWithTemplateJsonParameterObject
```
New-AzDeployment -Mode <DeploymentMode> -TemplateJson <String> -TemplateParameterObject <Hashtable>
 [-Name <String>] [-SubscriptionId <String>] [-DeploymentDebugLogLevel <String>] [-Location <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateWithTemplateObjectParameterFile
```
New-AzDeployment -Mode <DeploymentMode> -TemplateObject <Hashtable> -TemplateParameterFile <String>
 [-Name <String>] [-SubscriptionId <String>] [-DeploymentDebugLogLevel <String>] [-Location <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateWithTemplateObjectParameterJson
```
New-AzDeployment -Mode <DeploymentMode> -TemplateObject <Hashtable> -TemplateParameterJson <String>
 [-Name <String>] [-SubscriptionId <String>] [-DeploymentDebugLogLevel <String>] [-Location <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateWithTemplateObjectParameterObject
```
New-AzDeployment -Mode <DeploymentMode> -TemplateObject <Hashtable> -TemplateParameterObject <Hashtable>
 [-Name <String>] [-SubscriptionId <String>] [-DeploymentDebugLogLevel <String>] [-Location <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
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

### -DeploymentDebugLogLevel
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
If not provided, the name of the template file will be used.
If a template file is not used, a random GUID will be used for the name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DeploymentName

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
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
The name of the resource group to deploy the resources to.
The name is case insensitive.
The resource group must already exist.

```yaml
Type: System.String
Parameter Sets: CreateRGWithTemplateFileParameterFile, CreateRGWithTemplateFileParameterJson, CreateRGWithTemplateFileParameterObject, CreateRGWithTemplateJsonParameterFile, CreateRGWithTemplateJsonParameterJson, CreateRGWithTemplateJsonParameterObject, CreateRGWithTemplateObjectParameterFile, CreateRGWithTemplateObjectParameterJson, CreateRGWithTemplateObjectParameterObject
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

### -TemplateFile
Local path to the JSON template file.

```yaml
Type: System.String
Parameter Sets: CreateRGWithTemplateFileParameterFile, CreateRGWithTemplateFileParameterJson, CreateRGWithTemplateFileParameterObject, CreateWithTemplateFileParameterFile, CreateWithTemplateFileParameterJson, CreateWithTemplateFileParameterObject
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
Parameter Sets: CreateRGWithTemplateJsonParameterFile, CreateRGWithTemplateJsonParameterJson, CreateRGWithTemplateJsonParameterObject, CreateWithTemplateJsonParameterFile, CreateWithTemplateJsonParameterJson, CreateWithTemplateJsonParameterObject
Aliases:

Required: True
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
Parameter Sets: CreateRGWithTemplateObjectParameterFile, CreateRGWithTemplateObjectParameterJson, CreateRGWithTemplateObjectParameterObject, CreateWithTemplateObjectParameterFile, CreateWithTemplateObjectParameterJson, CreateWithTemplateObjectParameterObject
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
Parameter Sets: CreateRGWithTemplateFileParameterFile, CreateRGWithTemplateJsonParameterFile, CreateRGWithTemplateObjectParameterFile, CreateWithTemplateFileParameterFile, CreateWithTemplateJsonParameterFile, CreateWithTemplateObjectParameterFile
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
Parameter Sets: CreateRGWithTemplateFileParameterJson, CreateRGWithTemplateJsonParameterJson, CreateRGWithTemplateObjectParameterJson, CreateWithTemplateFileParameterJson, CreateWithTemplateJsonParameterJson, CreateWithTemplateObjectParameterJson
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
Parameter Sets: CreateRGWithTemplateFileParameterObject, CreateRGWithTemplateJsonParameterObject, CreateRGWithTemplateObjectParameterObject, CreateWithTemplateFileParameterObject, CreateWithTemplateJsonParameterObject, CreateWithTemplateObjectParameterObject
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeploymentExtended

## ALIASES

## NOTES

## RELATED LINKS

