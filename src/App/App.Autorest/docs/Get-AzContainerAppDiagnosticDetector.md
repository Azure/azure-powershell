---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/get-azcontainerappdiagnosticdetector
schema: 2.0.0
---

# Get-AzContainerAppDiagnosticDetector

## SYNOPSIS
Get a diagnostics result of a Container App.

## SYNTAX

### List (Default)
```
Get-AzContainerAppDiagnosticDetector -ContainerAppName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerAppDiagnosticDetector -ContainerAppName <String> -DetectorName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerAppDiagnosticDetector -InputObject <IAppIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityContainerApp
```
Get-AzContainerAppDiagnosticDetector -ContainerAppInputObject <IAppIdentity> -DetectorName <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a diagnostics result of a Container App.

## EXAMPLES

### Example 1: Get a diagnostics result of a Container App.
```powershell
Get-AzContainerAppDiagnosticDetector -ContainerAppName azps-containerapp-1 -ResourceGroupName azps_test_group_app
```

```output
Name                                 ResourceGroupName
----                                 -----------------
AutoScalingErrors                    azps_test_group_app
clustersubnet                        azps_test_group_app
cappconfigandmanagement              azps_test_group_app
cappContainerAppAvailabilityDetector azps_test_group_app
cappcontainerappcpu                  azps_test_group_app
cappContainerAppAvailabilityMetrics  azps_test_group_app
cappcontainerappclustercreation      azps_test_group_app
cappcontainerappmemory               azps_test_group_app
cappcontainerappnetworkusage         azps_test_group_app
ContainerAppsRevisionComparsion      azps_test_group_app
ContainerAppEnvironmentEvents        azps_test_group_app
containerenvinsights                 azps_test_group_app
DaprInsights                         azps_test_group_app
cappdeploymentFailures               azps_test_group_app
EasyAuthConfigurationErrors          azps_test_group_app
cappcontainerapprevisions            azps_test_group_app
snatusage                            azps_test_group_app
cappcertificates                     azps_test_group_app
```

Get a diagnostics result of a Container App.

## PARAMETERS

### -ContainerAppInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: GetViaIdentityContainerApp
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ContainerAppName
Name of the Container App.

```yaml
Type: System.String
Parameter Sets: Get, List
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

### -DetectorName
Name of the Container App Detector.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityContainerApp
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
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
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
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IDiagnostics

## NOTES

## RELATED LINKS

