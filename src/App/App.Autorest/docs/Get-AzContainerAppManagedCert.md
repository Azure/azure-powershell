---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/get-azcontainerappmanagedcert
schema: 2.0.0
---

# Get-AzContainerAppManagedCert

## SYNOPSIS
Get the specified Managed Certificate.

## SYNTAX

### List (Default)
```
Get-AzContainerAppManagedCert -EnvName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzContainerAppManagedCert -EnvName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzContainerAppManagedCert -InputObject <IAppIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityManagedEnvironment
```
Get-AzContainerAppManagedCert -ManagedEnvironmentInputObject <IAppIdentity> -Name <String>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get the specified Managed Certificate.

## EXAMPLES

### Example 1: Get the specified Managed Certificate.
```powershell
Get-AzContainerAppManagedCert -EnvName azps-env -Name azps-managedcert -ResourceGroupName azps_test_group_app
```

```output
Name             SubjectName   Location ResourceGroupName   DomainControlValidation
----             -----------   -------- -----------------   -----------------------
azps-managedcert mycertweb.com East US  azps_test_group_app TXT
```

Get the specified Managed Certificate.

### Example 2: Get the specified Managed Certificate.
```powershell
Get-AzContainerAppManagedCert -EnvName azps-env -ResourceGroupName azps_test_group_app
```

```output
Name             SubjectName   Location ResourceGroupName   DomainControlValidation
----             -----------   -------- -----------------   -----------------------
azps-managedcert mycertweb.com East US  azps_test_group_app TXT
```

Get the specified Managed Certificate.

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
Name of the Managed Certificate.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityManagedEnvironment
Aliases: ManagedCertificateName

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IManagedCertificate

## NOTES

## RELATED LINKS

