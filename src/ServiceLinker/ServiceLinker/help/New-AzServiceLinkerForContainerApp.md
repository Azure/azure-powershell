---
external help file: Az.ServiceLinker-help.xml
Module Name: Az.ServiceLinker
online version: https://learn.microsoft.com/powershell/module/az.servicelinker/new-azservicelinkerforcontainerapp
schema: 2.0.0
---

# New-AzServiceLinkerForContainerApp

## SYNOPSIS
Create or update linker resource in container app.

## SYNTAX

```
New-AzServiceLinkerForContainerApp [-ResourceUri <String>] [-Name <String>] -AuthInfo <IAuthInfoBase>
 -TargetService <ITargetServiceBase> [-ClientType <ClientType>] [-ConfigurationInfoAction <ActionType>]
 [-ConfigurationInfoAdditionalConfiguration <Hashtable>] [-ConfigurationInfoCustomizedKey <Hashtable>]
 [-FirewallRuleAzureService <AllowType>] [-FirewallRuleCallerClientIP <AllowType>]
 [-FirewallRuleIPRange <String[]>] [-PublicNetworkSolutionAction <ActionType>] [-Scope <String>]
 [-SecretStoreKeyVaultId <String>] [-SecretStoreKeyVaultSecretName <String>]
 [-VNetSolutionType <VNetSolutionType>] [-DefaultProfile <PSObject>] -ResourceGroupName <String>
 -ContainerApp <String> [-SubscriptionId <String>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create or update linker resource in container app.

## EXAMPLES

### Example 1: Create service linker between container app and postgresql
```powershell
$target=New-AzServiceLinkerAzureResourceObject -Id /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/servicelinker-test-group/providers/Microsoft.DBforPostgreSQL/servers/servicelinker-postgresql/databases/test

$authInfo=New-AzServiceLinkerSecretAuthInfoObject -Name testUser -SecretValue ***  

New-AzServiceLinkerForContainerApp -TargetService $target -AuthInfo $auth -ClientType dotnet -LinkerName testLinker -ContainerApp servicelinker-app -ResourceGroupName servicelinker-test-linux-group -Scope 'simple-hello-world-container'
```

```output
Name
----
testLinker
```

Create service linker between Container AppName and postgresql

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

### -AuthInfo
The authentication type.
To construct, see NOTES section for AUTHINFO properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20221101Preview.IAuthInfoBase
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClientType
The application client type

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Support.ClientType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: "none"
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationInfoAction
Optional, indicate whether to apply configurations on source application.
If enable, generate configurations and applied to the source application.
Default is enable.
If optOut, no configuration change will be made on source.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Support.ActionType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationInfoAdditionalConfiguration
A dictionary of additional configurations to be added.
Service will auto generate a set of basic configurations and this property is to full fill more customized configurations

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

### -ConfigurationInfoCustomizedKey
Optional.
A dictionary of default key name and customized key name mapping.
If not specified, default key name will be used for generate configurations

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

### -ContainerApp
The Name of container app of the resource to be connected.

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

### -FirewallRuleAzureService
Allow Azure services to access the target service if true.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Support.AllowType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FirewallRuleCallerClientIP
Allow caller client IP to access the target service if true.
the property is used when connecting local application to target service.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Support.AllowType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FirewallRuleIPRange
This value specifies the set of IP addresses or IP address ranges in CIDR form to be included as the allowed list of client IPs for a given database account.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name Linker resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: LinkerName

Required: False
Position: Named
Default value: "connect_"+(-join ((65..90) + (97..122) | Get-Random -Count 5 | % {[char]$_}))
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

### -PublicNetworkSolutionAction
Optional.
Indicates public network solution.
If enable, enable public network access of target service with best try.
Default is enable.
If optOut, opt out public network access configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Support.ActionType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
[ResourceGroupCompleter]
The resource group of the resource to be connected.

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

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource to be connected.

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

### -Scope
connection scope in source service.

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

### -SecretStoreKeyVaultId
The key vault id to store secret

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

### -SecretStoreKeyVaultSecretName
The key vault secret name to store secret, only valid when storing one secret

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

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

### -TargetService
The target service properties
To construct, see NOTES section for TARGETSERVICE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20221101Preview.ITargetServiceBase
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VNetSolutionType
Type of VNet solution.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Support.VNetSolutionType
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20221101Preview.ILinkerResource

## NOTES

## RELATED LINKS
