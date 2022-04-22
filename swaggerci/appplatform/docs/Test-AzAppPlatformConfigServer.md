---
external help file:
Module Name: Az.AppPlatform
online version: https://docs.microsoft.com/en-us/powershell/module/az.appplatform/test-azappplatformconfigserver
schema: 2.0.0
---

# Test-AzAppPlatformConfigServer

## SYNOPSIS
Check if the config server settings are valid.

## SYNTAX

### ValidateExpanded (Default)
```
Test-AzAppPlatformConfigServer -ResourceGroupName <String> -ServiceName <String> [-SubscriptionId <String>]
 [-GitPropertyHostKey <String>] [-GitPropertyHostKeyAlgorithm <String>] [-GitPropertyLabel <String>]
 [-GitPropertyPassword <String>] [-GitPropertyPrivateKey <String>]
 [-GitPropertyRepository <IGitPatternRepository[]>] [-GitPropertySearchPath <String[]>]
 [-GitPropertyStrictHostKeyChecking] [-GitPropertyUri <String>] [-GitPropertyUsername <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Validate
```
Test-AzAppPlatformConfigServer -ResourceGroupName <String> -ServiceName <String>
 -ConfigServerSetting <IConfigServerSettings> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity
```
Test-AzAppPlatformConfigServer -InputObject <IAppPlatformIdentity>
 -ConfigServerSetting <IConfigServerSettings> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentityExpanded
```
Test-AzAppPlatformConfigServer -InputObject <IAppPlatformIdentity> [-GitPropertyHostKey <String>]
 [-GitPropertyHostKeyAlgorithm <String>] [-GitPropertyLabel <String>] [-GitPropertyPassword <String>]
 [-GitPropertyPrivateKey <String>] [-GitPropertyRepository <IGitPatternRepository[]>]
 [-GitPropertySearchPath <String[]>] [-GitPropertyStrictHostKeyChecking] [-GitPropertyUri <String>]
 [-GitPropertyUsername <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Check if the config server settings are valid.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
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
```

### -ConfigServerSetting
The settings of config server.
To construct, see NOTES section for CONFIGSERVERSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.Api20220301Preview.IConfigServerSettings
Parameter Sets: Validate, ValidateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -GitPropertyHostKey
Public sshKey of git repository.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitPropertyHostKeyAlgorithm
SshKey algorithm of git repository.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitPropertyLabel
Label of the repository

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitPropertyPassword
Password of git repository basic auth.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitPropertyPrivateKey
Private sshKey algorithm of git repository.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitPropertyRepository
Repositories of git.
To construct, see NOTES section for GITPROPERTYREPOSITORY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.Api20220301Preview.IGitPatternRepository[]
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitPropertySearchPath
Searching path of the repository

```yaml
Type: System.String[]
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitPropertyStrictHostKeyChecking
Strict host key checking or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitPropertyUri
URI of the repository

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitPropertyUsername
Username of git repository basic auth.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded, ValidateViaIdentityExpanded
Aliases:

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
Type: Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.IAppPlatformIdentity
Parameter Sets: ValidateViaIdentity, ValidateViaIdentityExpanded
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

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: Validate, ValidateExpanded
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
Parameter Sets: Validate, ValidateExpanded
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
Parameter Sets: Validate, ValidateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.Api20220301Preview.IConfigServerSettings

### Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.IAppPlatformIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.Api20220301Preview.IConfigServerSettingsValidateResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CONFIGSERVERSETTING <IConfigServerSettings>: The settings of config server.
  - `[GitPropertyHostKey <String>]`: Public sshKey of git repository.
  - `[GitPropertyHostKeyAlgorithm <String>]`: SshKey algorithm of git repository.
  - `[GitPropertyLabel <String>]`: Label of the repository
  - `[GitPropertyPassword <String>]`: Password of git repository basic auth.
  - `[GitPropertyPrivateKey <String>]`: Private sshKey algorithm of git repository.
  - `[GitPropertyRepository <IGitPatternRepository[]>]`: Repositories of git.
    - `Name <String>`: Name of the repository
    - `Uri <String>`: URI of the repository
    - `[HostKey <String>]`: Public sshKey of git repository.
    - `[HostKeyAlgorithm <String>]`: SshKey algorithm of git repository.
    - `[Label <String>]`: Label of the repository
    - `[Password <String>]`: Password of git repository basic auth.
    - `[Pattern <String[]>]`: Collection of pattern of the repository
    - `[PrivateKey <String>]`: Private sshKey algorithm of git repository.
    - `[SearchPath <String[]>]`: Searching path of the repository
    - `[StrictHostKeyChecking <Boolean?>]`: Strict host key checking or not.
    - `[Username <String>]`: Username of git repository basic auth.
  - `[GitPropertySearchPath <String[]>]`: Searching path of the repository
  - `[GitPropertyStrictHostKeyChecking <Boolean?>]`: Strict host key checking or not.
  - `[GitPropertyUri <String>]`: URI of the repository
  - `[GitPropertyUsername <String>]`: Username of git repository basic auth.

GITPROPERTYREPOSITORY <IGitPatternRepository[]>: Repositories of git.
  - `Name <String>`: Name of the repository
  - `Uri <String>`: URI of the repository
  - `[HostKey <String>]`: Public sshKey of git repository.
  - `[HostKeyAlgorithm <String>]`: SshKey algorithm of git repository.
  - `[Label <String>]`: Label of the repository
  - `[Password <String>]`: Password of git repository basic auth.
  - `[Pattern <String[]>]`: Collection of pattern of the repository
  - `[PrivateKey <String>]`: Private sshKey algorithm of git repository.
  - `[SearchPath <String[]>]`: Searching path of the repository
  - `[StrictHostKeyChecking <Boolean?>]`: Strict host key checking or not.
  - `[Username <String>]`: Username of git repository basic auth.

INPUTOBJECT <IAppPlatformIdentity>: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the build service agent pool resource.
  - `[ApiPortalName <String>]`: The name of API portal.
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
  - `[GatewayName <String>]`: The name of Spring Cloud Gateway.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: the region
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[RouteConfigName <String>]`: The name of the Spring Cloud Gateway route config.
  - `[ServiceName <String>]`: The name of the Service resource.
  - `[ServiceRegistryName <String>]`: The name of Service Registry.
  - `[StackName <String>]`: The name of the stack resource.
  - `[StorageName <String>]`: The name of the storage resource.
  - `[SubscriptionId <String>]`: Gets subscription ID which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

