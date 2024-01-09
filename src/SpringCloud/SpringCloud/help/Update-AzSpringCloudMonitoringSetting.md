---
external help file: Az.SpringCloud-help.xml
Module Name: Az.SpringCloud
online version: https://learn.microsoft.com/powershell/module/az.springcloud/update-azspringcloudmonitoringsetting
schema: 2.0.0
---

# Update-AzSpringCloudMonitoringSetting

## SYNOPSIS
Update the Monitoring Setting.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSpringCloudMonitoringSetting -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AppInsightsInstrumentationKey <String>] [-AppInsightsSamplingRate <Double>] [-Code <String>]
 [-Message <String>] [-TraceEnabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSpringCloudMonitoringSetting -InputObject <ISpringCloudIdentity>
 [-AppInsightsInstrumentationKey <String>] [-AppInsightsSamplingRate <Double>] [-Code <String>]
 [-Message <String>] [-TraceEnabled] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update the Monitoring Setting.

## EXAMPLES

### Example 1: Update the Monitoring Setting
```powershell
Update-AzSpringCloudMonitoringSetting -ResourceGroupName SpringCloud-gp-junxi -Name springcloud-service -AppInsightsInstrumentationKey "InstrumentationKey=xxxxxxxxxxxxxxxxxxx;IngestionEndpoint=https://xxxxxx.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/" -TraceEnabled
```

```output
Name    ResourceGroupName ProvisioningState TraceEnabled
----    ----------------- ----------------- ------------
default azurespringrg     Succeeded         True
```

Update the Monitoring Setting.

### Example 2: Update the Monitoring Setting by pipeline
```powershell
Get-AzSpringCloudMonitoringSetting -ResourceGroupName SpringCloud-gp-junxi -Name springcloud-service | Update-AzSpringCloudMonitoringSetting -AppInsightsInstrumentationKey "InstrumentationKey=xxxxxxxxxxxxxxxxxxx;IngestionEndpoint=https://xxxxxx.in.applicationinsights.azure.com/;LiveEndpoint=https://eastus.livediagnostics.monitor.azure.com/" -TraceEnabled
```

```output
Name    ResourceGroupName ProvisioningState TraceEnabled
----    ----------------- ----------------- ------------
default azurespringrg     Succeeded         True
```

Update the Monitoring Setting by pipeline.

## PARAMETERS

### -AppInsightsInstrumentationKey
Target application insight instrumentation key, null or whitespace include empty will disable monitoringSettings

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

### -AppInsightsSamplingRate
Indicates the sampling rate of application insight agent, should be in range [0.0, 100.0]

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
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

### -Code
The code of error.

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
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Message
The message of error.

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
The name of the Service resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TraceEnabled
Indicates whether enable the trace functionality, which will be deprecated since api version 2020-11-01-preview.
Please leverage appInsightsInstrumentationKey to indicate if monitoringSettings enabled or not

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

### Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.IMonitoringSettingResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <ISpringCloudIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the build service agent pool resource.
  - `[AppName <String>]`: The name of the App resource.
  - `[BindingName <String>]`: The name of the Binding resource.
  - `[BuildName <String>]`: The name of the build resource.
  - `[BuildResultName <String>]`: The name of the build result resource.
  - `[BuildServiceName <String>]`: The name of the build service resource.
  - `[BuilderName <String>]`: The name of the builder resource.
  - `[BuildpackBindingName <String>]`: The name of the Buildpack Binding Name
  - `[BuildpackName <String>]`: The name of the buildpack resource.
  - `[CertificateName <String>]`: The name of the certificate resource.
  - `[ConfigurationServiceName <String>]`: The name of Application Configuration Service.
  - `[DeploymentName <String>]`: The name of the Deployment resource.
  - `[DomainName <String>]`: The name of the custom domain resource.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: the region
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[ServiceName <String>]`: The name of the Service resource.
  - `[ServiceRegistryName <String>]`: The name of Service Registry.
  - `[StackName <String>]`: The name of the stack resource.
  - `[SubscriptionId <String>]`: Gets subscription ID which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS
