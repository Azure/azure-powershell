---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/get-azcontainerappmanagedenvcert
schema: 2.0.0
---

# Get-AzContainerAppManagedEnvCert

## SYNOPSIS
Get the specified Certificate.

## SYNTAX

### List (Default)
```
Get-AzContainerAppManagedEnvCert -EnvName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzContainerAppManagedEnvCert -EnvName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentityManagedEnvironment
```
Get-AzContainerAppManagedEnvCert -Name <String> -ManagedEnvironmentInputObject <IAppIdentity>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerAppManagedEnvCert -InputObject <IAppIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get the specified Certificate.

## EXAMPLES

### Example 1: List the specified Certificate by env name.
```powershell
Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azps_test_group_app
```

```output
Name          Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          -------- ------              ----------------- -----------         ----------                               -----------------
azps-env-cert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com F61C9A8C53D0500F819463A66C5921AA09E1B787 azps_test_group_app
```

List the specified Certificate by env name.

### Example 2: Get the specified Certificate by name.
```powershell
Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azps_test_group_app -Name azps-env-cert
```

```output
Name          Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          -------- ------              ----------------- -----------         ----------                               -----------------
azps-env-cert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com F61C9A8C53D0500F819463A66C5921AA09E1B787 azps_test_group_app
```

Get the specified Certificate by name.

### Example 3: Get the specified Certificate.
```powershell
$managedenv = Get-AzContainerAppManagedEnv -Name azps-env -ResourceGroupName azps_test_group_app
Get-AzContainerAppManagGet-AzContainerAppManagedEnvCert -ManagedEnvironmentInputObject $managedenv -Name azps-env-cert
```

```output
Name          Location Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          -------- ------              ----------------- -----------         ----------                               -----------------
azps-env-cert eastus   CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com F61C9A8C53D0500F819463A66C5921AA09E1B787 azps_test_group_app
```

Get the specified Certificate.

## PARAMETERS

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

### -EnvName
Name of the Managed Environment.

```yaml
Type: System.String
Parameter Sets: List, Get
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

### -ManagedEnvironmentInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
Parameter Sets: GetViaIdentityManagedEnvironment
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Certificate.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityManagedEnvironment
Aliases: CertificateName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.ICertificate

## NOTES

## RELATED LINKS
