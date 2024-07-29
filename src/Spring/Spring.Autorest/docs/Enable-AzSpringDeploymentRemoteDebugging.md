---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/az.springapps/enable-azspringdeploymentremotedebugging
schema: 2.0.0
---

# Enable-AzSpringDeploymentRemoteDebugging

## SYNOPSIS
Enable remote debugging.

## SYNTAX

### EnableExpanded (Default)
```
Enable-AzSpringDeploymentRemoteDebugging -AppName <String> -DeploymentName <String>
 -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String>] [-Port <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Enable
```
Enable-AzSpringDeploymentRemoteDebugging -AppName <String> -DeploymentName <String>
 -ResourceGroupName <String> -ServiceName <String> -RemoteDebuggingPayload <IRemoteDebuggingPayload>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### EnableViaIdentity
```
Enable-AzSpringDeploymentRemoteDebugging -InputObject <ISpringAppsIdentity>
 -RemoteDebuggingPayload <IRemoteDebuggingPayload> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### EnableViaIdentityApp
```
Enable-AzSpringDeploymentRemoteDebugging -AppInputObject <ISpringAppsIdentity> -DeploymentName <String>
 -RemoteDebuggingPayload <IRemoteDebuggingPayload> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### EnableViaIdentityAppExpanded
```
Enable-AzSpringDeploymentRemoteDebugging -AppInputObject <ISpringAppsIdentity> -DeploymentName <String>
 [-Port <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EnableViaIdentityExpanded
```
Enable-AzSpringDeploymentRemoteDebugging -InputObject <ISpringAppsIdentity> [-Port <Int32>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EnableViaIdentitySpring
```
Enable-AzSpringDeploymentRemoteDebugging -AppName <String> -DeploymentName <String>
 -SpringInputObject <ISpringAppsIdentity> -RemoteDebuggingPayload <IRemoteDebuggingPayload>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EnableViaIdentitySpringExpanded
```
Enable-AzSpringDeploymentRemoteDebugging -AppName <String> -DeploymentName <String>
 -SpringInputObject <ISpringAppsIdentity> [-Port <Int32>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EnableViaJsonFilePath
```
Enable-AzSpringDeploymentRemoteDebugging -AppName <String> -DeploymentName <String>
 -ResourceGroupName <String> -ServiceName <String> -JsonFilePath <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### EnableViaJsonString
```
Enable-AzSpringDeploymentRemoteDebugging -AppName <String> -DeploymentName <String>
 -ResourceGroupName <String> -ServiceName <String> -JsonString <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Enable remote debugging.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -AppInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: EnableViaIdentityApp, EnableViaIdentityAppExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -AppName
The name of the App resource.

```yaml
Type: System.String
Parameter Sets: Enable, EnableExpanded, EnableViaIdentitySpring, EnableViaIdentitySpringExpanded, EnableViaJsonFilePath, EnableViaJsonString
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

### -DeploymentName
The name of the Deployment resource.

```yaml
Type: System.String
Parameter Sets: Enable, EnableExpanded, EnableViaIdentityApp, EnableViaIdentityAppExpanded, EnableViaIdentitySpring, EnableViaIdentitySpringExpanded, EnableViaJsonFilePath, EnableViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: EnableViaIdentity, EnableViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Enable operation

```yaml
Type: System.String
Parameter Sets: EnableViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Enable operation

```yaml
Type: System.String
Parameter Sets: EnableViaJsonString
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

### -Port
Application debugging port.

```yaml
Type: System.Int32
Parameter Sets: EnableExpanded, EnableViaIdentityAppExpanded, EnableViaIdentityExpanded, EnableViaIdentitySpringExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RemoteDebuggingPayload
Remote debugging payload.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IRemoteDebuggingPayload
Parameter Sets: Enable, EnableViaIdentity, EnableViaIdentityApp, EnableViaIdentitySpring
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: Enable, EnableExpanded, EnableViaJsonFilePath, EnableViaJsonString
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
Parameter Sets: Enable, EnableExpanded, EnableViaJsonFilePath, EnableViaJsonString
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
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity
Parameter Sets: EnableViaIdentitySpring, EnableViaIdentitySpringExpanded
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
Parameter Sets: Enable, EnableExpanded, EnableViaJsonFilePath, EnableViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IRemoteDebuggingPayload

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ISpringAppsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IRemoteDebugging

## NOTES

## RELATED LINKS

