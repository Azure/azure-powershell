---
external help file:
Module Name: Az.StackHCI
online version: https://learn.microsoft.com/powershell/module/az.stackhci/new-azstackhciextension
schema: 2.0.0
---

# New-AzStackHciExtension

## SYNOPSIS
Create Extension for HCI cluster.

## SYNTAX

```
New-AzStackHciExtension -ArcSettingName <String> -ClusterName <String> -Name <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-ExtensionParameterAutoUpgradeMinorVersion]
 [-ExtensionParameterForceUpdateTag <String>] [-ExtensionParameterProtectedSetting <Hashtable>]
 [-ExtensionParameterPublisher <String>] [-ExtensionParameterSetting <Hashtable>]
 [-ExtensionParameterType <String>] [-ExtensionParameterTypeHandlerVersion <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create Extension for HCI cluster.

## EXAMPLES

### Example 1: 
```powershell
New-AzStackHciExtension -ArcSettingName "default" -ClusterName "myCluster" -Name "MicrosoftMonitoringAgent" -ResourceGroupName test-rg
```

```output
Name                     ResourceGroupName
----                     -----------------
MicrosoftMonitoringAgent test-rg
```

Creates a new arc extension.

### Example 2:
```powershell
$Settings = @{ "commandToExecute" = "powershell.exe -c Get-Process" }
New-AzStackHciExtension -ArcSettingName "default" -ClusterName "myCluster" -Name "MicrosoftMonitoringAgent" -ResourceGroupName test-rg -ExtensionParameterPublisher "Microsoft.Compute" -ExtensionParameterType "MicrosoftMonitoringAgent" -ExtensionParameterProtectedSetting $Settings
```

```output
Name                     ResourceGroupName
----                     -----------------
MicrosoftMonitoringAgent test-rg
```

Creates new arc extension with the given parameters

## PARAMETERS

### -ArcSettingName
The name of the proxy resource holding details of HCI ArcSetting information.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -ClusterName
The name of the cluster.

```yaml
Type: System.String
Parameter Sets: (All)
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

### -ExtensionParameterAutoUpgradeMinorVersion
Indicates whether the extension should use a newer minor version if one is available at deployment time.
Once deployed, however, the extension will not upgrade minor versions unless redeployed, even with this property set to true.

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

### -ExtensionParameterForceUpdateTag
How the extension handler should be forced to update even if the extension configuration has not changed.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionParameterProtectedSetting
Protected settings (may contain secrets).

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionParameterPublisher
The name of the extension handler publisher.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionParameterSetting
Json formatted public settings for the extension.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionParameterType
Specifies the type of the extension; an example is "CustomScriptExtension".

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtensionParameterTypeHandlerVersion
Specifies the version of the script handler.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the machine extension.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ExtensionName

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.StackHCI.Models.Api20220501.IExtension

## NOTES

ALIASES

## RELATED LINKS

