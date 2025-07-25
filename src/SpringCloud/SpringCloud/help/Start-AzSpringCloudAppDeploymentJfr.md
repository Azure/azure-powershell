---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.springcloud/start-azspringcloudappdeploymentjfr
schema: 2.0.0
---

# Start-AzSpringCloudAppDeploymentJfr

## SYNOPSIS
Start JFR

## SYNTAX

### StartExpanded (Default)
```
Start-AzSpringCloudAppDeploymentJfr -AppName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> [-SubscriptionId <String>] [-AppInstance <String>] [-Duration <String>]
 [-FilePath <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StartViaJsonString
```
Start-AzSpringCloudAppDeploymentJfr -AppName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StartViaJsonFilePath
```
Start-AzSpringCloudAppDeploymentJfr -AppName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StartViaIdentitySpringExpanded
```
Start-AzSpringCloudAppDeploymentJfr -AppName <String> -Name <String> -SpringInputObject <ISpringCloudIdentity>
 [-AppInstance <String>] [-Duration <String>] [-FilePath <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StartViaIdentitySpring
```
Start-AzSpringCloudAppDeploymentJfr -AppName <String> -Name <String> -SpringInputObject <ISpringCloudIdentity>
 -DiagnosticParameter <IDiagnosticParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StartViaIdentityAppExpanded
```
Start-AzSpringCloudAppDeploymentJfr -Name <String> -AppInputObject <ISpringCloudIdentity>
 [-AppInstance <String>] [-Duration <String>] [-FilePath <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StartViaIdentityApp
```
Start-AzSpringCloudAppDeploymentJfr -Name <String> -AppInputObject <ISpringCloudIdentity>
 -DiagnosticParameter <IDiagnosticParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StartViaIdentityExpanded
```
Start-AzSpringCloudAppDeploymentJfr -InputObject <ISpringCloudIdentity> [-AppInstance <String>]
 [-Duration <String>] [-FilePath <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### StartViaIdentity
```
Start-AzSpringCloudAppDeploymentJfr -InputObject <ISpringCloudIdentity>
 -DiagnosticParameter <IDiagnosticParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Start JFR

## EXAMPLES

### Example 1: Start Spring Cloud Service by name
```powershell
Start-AzSpringCloudAppDeploymentJfr -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -Name default
```

Start Spring Cloud Service by name.

### Example 2: Start Spring Cloud Service by pipeline
```powershell
Get-AzSpringCloudAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -Name default | Start-AzSpringCloudAppDeployment
```

Start Spring Cloud Service by pipeline.

## PARAMETERS

### -AppInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity
Parameter Sets: StartViaIdentityAppExpanded, StartViaIdentityApp
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AppInstance
App instance name

```yaml
Type: System.String
Parameter Sets: StartExpanded, StartViaIdentitySpringExpanded, StartViaIdentityAppExpanded, StartViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppName
The name of the App resource.

```yaml
Type: System.String
Parameter Sets: StartExpanded, StartViaJsonString, StartViaJsonFilePath, StartViaIdentitySpringExpanded, StartViaIdentitySpring
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DiagnosticParameter
Diagnostic parameters of diagnostic operations

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.IDiagnosticParameters
Parameter Sets: StartViaIdentitySpring, StartViaIdentityApp, StartViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Duration
Duration of your JFR.
1 min can be represented by 1m or 60s.

```yaml
Type: System.String
Parameter Sets: StartExpanded, StartViaIdentitySpringExpanded, StartViaIdentityAppExpanded, StartViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FilePath
Your target file path in your own BYOS

```yaml
Type: System.String
Parameter Sets: StartExpanded, StartViaIdentitySpringExpanded, StartViaIdentityAppExpanded, StartViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity
Parameter Sets: StartViaIdentityExpanded, StartViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Start operation

```yaml
Type: System.String
Parameter Sets: StartViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Start operation

```yaml
Type: System.String
Parameter Sets: StartViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Deployment resource.

```yaml
Type: System.String
Parameter Sets: StartExpanded, StartViaJsonString, StartViaJsonFilePath, StartViaIdentitySpringExpanded, StartViaIdentitySpring, StartViaIdentityAppExpanded, StartViaIdentityApp
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: StartExpanded, StartViaJsonString, StartViaJsonFilePath
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
Parameter Sets: StartExpanded, StartViaJsonString, StartViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SpringInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity
Parameter Sets: StartViaIdentitySpringExpanded, StartViaIdentitySpring
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: StartExpanded, StartViaJsonString, StartViaJsonFilePath
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.IDiagnosticParameters

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
