---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/new-azcontainerapp
schema: 2.0.0
---

# New-AzContainerApp

## SYNOPSIS
Create a Container App.

## SYNTAX

### CreateExpanded (Default)
```
New-AzContainerApp -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 [-Configuration <IConfiguration>] [-EnvironmentId <String>] [-ExtendedLocationName <String>]
 [-ExtendedLocationType <String>] [-IdentityType <String>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-ManagedBy <String>] [-ManagedEnvironmentId <String>] [-ScaleMaxReplica <Int32>] [-ScaleMinReplica <Int32>]
 [-ScaleRule <IScaleRule[]>] [-Tag <Hashtable>] [-TemplateContainer <IContainer[]>]
 [-TemplateInitContainer <IInitContainer[]>] [-TemplateRevisionSuffix <String>]
 [-TemplateServiceBind <IServiceBind[]>] [-TemplateTerminationGracePeriodSecond <Int64>]
 [-TemplateVolume <IVolume[]>] [-WorkloadProfileName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzContainerApp -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonString <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzContainerApp -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -JsonFilePath <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaIdentityExpanded
```
New-AzContainerApp -InputObject <IAppIdentity> -Location <String> [-Configuration <IConfiguration>]
 [-EnvironmentId <String>] [-ExtendedLocationName <String>] [-ExtendedLocationType <String>]
 [-IdentityType <String>] [-IdentityUserAssignedIdentity <Hashtable>] [-ManagedBy <String>]
 [-ManagedEnvironmentId <String>] [-ScaleMaxReplica <Int32>] [-ScaleMinReplica <Int32>]
 [-ScaleRule <IScaleRule[]>] [-Tag <Hashtable>] [-TemplateContainer <IContainer[]>]
 [-TemplateInitContainer <IInitContainer[]>] [-TemplateRevisionSuffix <String>]
 [-TemplateServiceBind <IServiceBind[]>] [-TemplateTerminationGracePeriodSecond <Int64>]
 [-TemplateVolume <IVolume[]>] [-WorkloadProfileName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Container App.

## EXAMPLES

### Example 1: Create a Container App for Managed Environment.
```powershell
New-AzOperationalInsightsWorkspace -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp -Sku PerGB2018 -Location eastus -PublicNetworkAccessForIngestion "Enabled" -PublicNetworkAccessForQuery "Enabled"

$CustomId = (Get-AzOperationalInsightsWorkspace -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp).CustomerId
$SharedKey = (Get-AzOperationalInsightsWorkspaceSharedKey -ResourceGroupName azps_test_group_app -Name workspace-azpstestgp).PrimarySharedKey
$workloadProfile = New-AzContainerAppWorkloadProfileObject -Name "Consumption" -Type "Consumption"
New-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app -Location eastus -AppLogConfigurationDestination "log-analytics" -LogAnalyticConfigurationCustomerId $CustomId -LogAnalyticConfigurationSharedKey $SharedKey -VnetConfigurationInternal:$false -WorkloadProfile $workloadProfile
$EnvId = (Get-AzContainerAppManagedEnv -ResourceGroupName azps_test_group_app -Name azps-env).Id

New-SelfSignedCertificate -DnsName "www.fabrikam.com", "www.contoso.com" -CertStoreLocation "cert:\LocalMachine\My"
Get-ChildItem -Path cert:\LocalMachine\My
$mypwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
Get-ChildItem -Path cert:\localMachine\my\F61C9A8C53D0500F819463A66C5921AA09E1B787 | Export-PfxCertificate -FilePath C:\mypfx.pfx -Password $mypwd
New-AzContainerAppManagedEnvCert -EnvName azps-env -Name azps-env-cert -ResourceGroupName azps_test_group_app -Location eastus -InputFile "C:\mypfx.pfx" -Password $mypwd

$trafficWeight = New-AzContainerAppTrafficWeightObject -Label "production" -Weight 100 -LatestRevision:$True
$iPSecurityRestrictionRule = New-AzContainerAppIPSecurityRestrictionRuleObject -Action "Allow" -IPAddressRange "192.168.1.1/32" -Name "Allow work IP A subnet"
$secretObject = New-AzContainerAppSecretObject -Name "redis-config" -Value "redis-password"
$customDomain = New-AzContainerAppCustomDomainObject -Name "mycertweb.com" -BindingType Disabled

$configuration = New-AzContainerAppConfigurationObject -IngressCustomDomain $customDomain -IngressIPSecurityRestriction $iPSecurityRestrictionRule -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 80 -IngressClientCertificateMode "accept" -CorPolicyAllowedOrigin "https://a.test.com","https://b.test.com" -CorPolicyAllowedMethod "GET","POST" -CorPolicyAllowedHeader "HEADER1","HEADER2" -CorPolicyExposeHeader "HEADER3","HEADER4" -CorPolicyMaxAge 1234 -CorPolicyAllowCredentials:$True -DaprEnabled:$True -DaprAppPort 3000 -DaprAppProtocol "http" -DaprHttpReadBufferSize 30 -DaprHttpMaxRequestSize 10 -DaprLogLevel "debug" -DaprEnableApiLogging:$True -MaxInactiveRevision 10 -ServiceType "redis" -Secret $secretObject

$serviceBind = New-AzContainerAppServiceBindObject -Name "redisService" -ServiceId "/subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.App/containerApps/azps-containerapp-1"

$probeHttpGetHttpHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"
$probe = New-AzContainerAppProbeObject -Type "Liveness" -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -HttpGetHttpHeader $probeHttpGetHttpHeader
$temp = New-AzContainerAppTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container" -Probe $probe -ResourceCpu 0.25 -ResourceMemory "0.5Gi"
$temp2 = New-AzContainerAppInitContainerTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","echo hello; sleep 10;"

New-AzContainerApp -Name "azps-containerapp-1" -ResourceGroupName "azps_test_group_app" -Location "eastus" -Configuration $configuration -TemplateContainer $temp -TemplateInitContainer $temp2 -TemplateServiceBind $serviceBind -EnvironmentId $EnvId
```

```output
Location Name                ResourceGroupName
-------- ----                -----------------
East US  azps-containerapp-1 azps_test_group_app
```

Create a Container App for Managed Environment.

### Example 2: Create a Container App for Connected Environment.
```powershell
# Here you need to provide the resource "CustomLocation", for more information on how to create a resource CustomLocation, please refer to the help file: https://learn.microsoft.com/en-us/azure/container-apps/azure-arc-enable-cluster?tabs=azure-powershell
New-AzContainerAppConnectedEnv -Name azps-connectedenv -ResourceGroupName azps_test_group_app -Location eastus -ExtendedLocationName "/subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.ExtendedLocation/customLocations/my-custom-location" -ExtendedLocationType CustomLocation
$EnvId = (Get-AzContainerAppConnectedEnv -ResourceGroupName azps_test_group_app -Name azps-connectedenv).Id

New-SelfSignedCertificate -DnsName "www.fabrikam.com", "www.contoso.com" -CertStoreLocation "cert:\LocalMachine\My"
Get-ChildItem -Path cert:\LocalMachine\My
$mypwd = ConvertTo-SecureString -String "****" -AsPlainText -Force
Get-ChildItem -Path cert:\localMachine\my\F61C9A8C53D0500F819463A66C5921AA09E1B787 | Export-PfxCertificate -FilePath C:\mypfx.pfx -Password $mypwd
New-AzContainerAppConnectedEnvCert -Name azps-connectedenvcert -ConnectedEnvironmentName azps-connectedenv -ResourceGroupName azps_test_group_app -Location eastus -InputFile "C:\mypfx.pfx" -Password $mypwd

$trafficWeight = New-AzContainerAppTrafficWeightObject -Label "production" -Weight 100 -LatestRevision:$True
$secretObject = New-AzContainerAppSecretObject -Name "redis-config" -Value "redis-password"
$configuration = New-AzContainerAppConfigurationObject -IngressTraffic $trafficWeight -IngressExternal:$True -IngressTargetPort 80 -Secret $secretObject

$temp = New-AzContainerAppTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container" -ResourceCpu 0.25 -ResourceMemory "0.5Gi"
$temp2 = New-AzContainerAppInitContainerTemplateObject -Image "mcr.microsoft.com/k8se/quickstart-jobs:latest" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","echo hello; sleep 10;"

New-AzContainerApp -Name "azps-containerapp-2" -ResourceGroupName "azps_test_group_app" -Location "eastus" -Configuration $configuration -TemplateContainer $temp -TemplateInitContainer $temp2 -EnvironmentId $EnvId -ExtendedLocationName "/subscriptions/{subId}/resourceGroups/azps_test_group_app/providers/Microsoft.ExtendedLocation/customLocations/my-custom-location" -ExtendedLocationType CustomLocation
```

```output
Location Name                ResourceGroupName
-------- ----                -----------------
East US  azps-containerapp-2 azps_test_group_app
```

Create a Container App for Connected Environment.

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
```

### -Configuration
Non versioned Container App configuration properties.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IConfiguration
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### -EnvironmentId
Resource ID of environment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationName
The name of the extended location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ExtendedLocationType
The type of the extended location.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedBy
The fully qualified resource ID of the resource that manages this resource.
Indicates if this resource is managed by another Azure resource.
If this is present, complete mode deployment will not delete the resource if it is removed from the template since it is managed by another resource.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManagedEnvironmentId
Deprecated.
Resource ID of the Container App's environment.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Container App.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases: ContainerAppName

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
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleMaxReplica
Optional.
Maximum number of container replicas.
Defaults to 10 if not set.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleMinReplica
Optional.
Minimum number of container replicas.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleRule
Scaling rules.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IScaleRule[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaJsonString, CreateViaJsonFilePath
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateContainer
List of container definitions for the Container App.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IContainer[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateInitContainer
List of specialized containers that run before app containers.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IInitContainer[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateRevisionSuffix
User friendly suffix that is appended to the revision name

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateServiceBind
List of container app services bound to the app

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IServiceBind[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateTerminationGracePeriodSecond
Optional duration in seconds the Container App Instance needs to terminate gracefully.
Value must be non-negative integer.
The value zero indicates stop immediately via the kill signal (no opportunity to shut down).
If this value is nil, the default grace period will be used instead.
Set this value longer than the expected cleanup time for your process.
Defaults to 30 seconds.

```yaml
Type: System.Int64
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateVolume
List of volume definitions for the Container App.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IVolume[]
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkloadProfileName
Workload profile name to pin for container app execution.

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IContainerApp

## NOTES

## RELATED LINKS
