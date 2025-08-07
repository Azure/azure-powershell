---
external help file: Az.ServiceFabric-help.xml
Module Name: Az.ServiceFabric
online version: https://learn.microsoft.com/powershell/module/az.servicefabric/resume-azservicefabricmanagedclusterapplicationupgrade
schema: 2.0.0
---

# Resume-AzServiceFabricManagedClusterApplicationUpgrade

## SYNOPSIS
Send a request to resume the current application upgrade.
This will resume the application upgrade from where it was paused.

## SYNTAX

### ResumeExpanded (Default)
```
Resume-AzServiceFabricManagedClusterApplicationUpgrade -ApplicationName <String> -ClusterName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-UpgradeDomainName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResumeViaJsonString
```
Resume-AzServiceFabricManagedClusterApplicationUpgrade -ApplicationName <String> -ClusterName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResumeViaJsonFilePath
```
Resume-AzServiceFabricManagedClusterApplicationUpgrade -ApplicationName <String> -ClusterName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResumeViaIdentityManagedClusterExpanded
```
Resume-AzServiceFabricManagedClusterApplicationUpgrade -ApplicationName <String>
 -ManagedClusterInputObject <IServiceFabricIdentity> [-UpgradeDomainName <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResumeViaIdentityManagedCluster
```
Resume-AzServiceFabricManagedClusterApplicationUpgrade -ApplicationName <String>
 -ManagedClusterInputObject <IServiceFabricIdentity> -Parameter <IRuntimeResumeApplicationUpgradeParameters>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Resume
```
Resume-AzServiceFabricManagedClusterApplicationUpgrade -ApplicationName <String> -ClusterName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] -Parameter <IRuntimeResumeApplicationUpgradeParameters>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResumeViaIdentityExpanded
```
Resume-AzServiceFabricManagedClusterApplicationUpgrade -InputObject <IServiceFabricIdentity>
 [-UpgradeDomainName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ResumeViaIdentity
```
Resume-AzServiceFabricManagedClusterApplicationUpgrade -InputObject <IServiceFabricIdentity>
 -Parameter <IRuntimeResumeApplicationUpgradeParameters> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-PassThru] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Send a request to resume the current application upgrade.
This will resume the application upgrade from where it was paused.

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

### -ApplicationName
The name of the application resource.

```yaml
Type: System.String
Parameter Sets: ResumeExpanded, ResumeViaJsonString, ResumeViaJsonFilePath, ResumeViaIdentityManagedClusterExpanded, ResumeViaIdentityManagedCluster, Resume
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
The name of the cluster resource.

```yaml
Type: System.String
Parameter Sets: ResumeExpanded, ResumeViaJsonString, ResumeViaJsonFilePath, Resume
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity
Parameter Sets: ResumeViaIdentityExpanded, ResumeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Resume operation

```yaml
Type: System.String
Parameter Sets: ResumeViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Resume operation

```yaml
Type: System.String
Parameter Sets: ResumeViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedClusterInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity
Parameter Sets: ResumeViaIdentityManagedClusterExpanded, ResumeViaIdentityManagedCluster
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -Parameter
Parameters for Resume Upgrade action.
The upgrade domain name must be specified.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IRuntimeResumeApplicationUpgradeParameters
Parameter Sets: ResumeViaIdentityManagedCluster, Resume, ResumeViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: ResumeExpanded, ResumeViaJsonString, ResumeViaJsonFilePath, Resume
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
Parameter Sets: ResumeExpanded, ResumeViaJsonString, ResumeViaJsonFilePath, Resume
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UpgradeDomainName
The upgrade domain name.
Expected to be the next upgrade domain if the application is upgrading.

```yaml
Type: System.String
Parameter Sets: ResumeExpanded, ResumeViaIdentityManagedClusterExpanded, ResumeViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IRuntimeResumeApplicationUpgradeParameters

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabric.Models.IServiceFabricIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
