---
external help file:
Module Name: Az.App
online version: https://docs.microsoft.com/powershell/module/az.app/get-azcontainerappmanagedenvcert
schema: 2.0.0
---

# Get-AzContainerAppManagedEnvCert

## SYNOPSIS
Get the specified Certificate.

## SYNTAX

### List (Default)
```
Get-AzContainerAppManagedEnvCert -EnvName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerAppManagedEnvCert -EnvName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerAppManagedEnvCert -InputObject <IAppIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the specified Certificate.

## EXAMPLES

### Example 1: List the specified Certificate.
```powershell
Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azpstest_gp
```

```output
Name             Location      Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----             --------      ------              ----------------- -----------         ----------                               -----------------
azps-env-cert    canadacentral CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com 684DFA8457230B8A04675FBCB7251FA88AE10D80 azpstest_gp
azps-env-cert-02 canadacentral CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com 684DFA8457230B8A04675FBCB7251FA88AE10D80 azpstest_gp
```

List the specified Certificate.

### Example 2: Get the specified Certificate.
```powershell
Get-AzContainerAppManagedEnvCert -EnvName azps-env -ResourceGroupName azpstest_gp -Name azps-env-cert
```

```output
Name          Location      Issuer              ProvisioningState SubjectName         Thumbprint                               ResourceGroupName
----          --------      ------              ----------------- -----------         ----------                               -----------------
azps-env-cert canadacentral CN=www.fabrikam.com Succeeded         CN=www.fabrikam.com 684DFA8457230B8A04675FBCB7251FA88AE10D80 azpstest_gp
```

Get the specified Certificate.

## PARAMETERS

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

### -EnvName
Name of the Managed Environment.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

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

### -Name
Name of the Certificate.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: CertificateName

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.ICertificate

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IAppIdentity>: Identity Parameter
  - `[AuthConfigName <String>]`: Name of the Container App AuthConfig.
  - `[CertificateName <String>]`: Name of the Certificate.
  - `[ComponentName <String>]`: Name of the Dapr Component.
  - `[ContainerAppName <String>]`: Name of the Container App.
  - `[EnvironmentName <String>]`: Name of the Managed Environment.
  - `[Id <String>]`: Resource identity path
  - `[ReplicaName <String>]`: Name of the Container App Revision Replica.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RevisionName <String>]`: Name of the Container App Revision.
  - `[SourceControlName <String>]`: Name of the Container App SourceControl.
  - `[StorageName <String>]`: Name of the storage.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

## RELATED LINKS

