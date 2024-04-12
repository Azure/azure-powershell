---
external help file: Az.ManagedServices-help.xml
Module Name: Az.ManagedServices
online version: https://learn.microsoft.com/powershell/module/az.ManagedServices/new-AzManagedServicesEligibleAuthorizationObject
schema: 2.0.0
---

# New-AzManagedServicesEligibleAuthorizationObject

## SYNOPSIS
Create a in-memory object for EligibleAuthorization

## SYNTAX

```
New-AzManagedServicesEligibleAuthorizationObject -PrincipalId <String> -RoleDefinitionId <String>
 [-JustInTimeAccessPolicyManagedByTenantApprover <IEligibleApprover[]>]
 [-JustInTimeAccessPolicyMaximumActivationDuration <TimeSpan>]
 [-JustInTimeAccessPolicyMultiFactorAuthProvider <MultiFactorAuthProvider>] [-PrincipalIdDisplayName <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for EligibleAuthorization

## EXAMPLES

### Example 1: Creates new Azure Lighthouse eligible authorization object to use with Registration definition
```powershell
New-AzManagedServicesEligibleAuthorizationObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Test user" -RoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
```

```output
PrincipalId                          PrincipalIdDisplayName RoleDefinitionId
-----------                          ---------------------- ----------------
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Test user              xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

Creates new Azure Lighthouse eligible authorization object to use with Registration definition.

### Example 2: Create new Azure Lighthouse eligible authorization with JustInTime settings
```powershell
$approver = New-AzManagedServicesEligibleApproverObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Approver group"

$eligibleAuth = New-AzManagedServicesEligibleAuthorizationObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Test user" -RoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -JustInTimeAccessPolicyManagedByTenantApprover $approver -JustInTimeAccessPolicyMultiFactorAuthProvider Azure -JustInTimeAccessPolicyMaximumActivationDuration 0:30

$eligibleAuth | Format-List -Property PrinciPalId, PrincipalIdDisplayName, RoleDefinitionId, JustInTimeAccessPolicyManagedByTenantApprover, JustInTimeAccessPolicyMultiFactorAuthProvider, JustInTimeAccessPolicyMaximumActivationDuration
```

```output
PrincipalId                                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
PrincipalIdDisplayName                          : Test user
RoleDefinitionId                                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
JustInTimeAccessPolicyManagedByTenantApprover   : {Approver group}
JustInTimeAccessPolicyMultiFactorAuthProvider   : Azure
JustInTimeAccessPolicyMaximumActivationDuration : 00:30:00
```

Creates new Azure Lighthouse eligible authorization object with JustInTime (JIT) settings.

## PARAMETERS

### -JustInTimeAccessPolicyManagedByTenantApprover
The list of managedByTenant approvers for the eligible authorization.
To construct, see NOTES section for JUSTINTIMEACCESSPOLICYMANAGEDBYTENANTAPPROVER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.IEligibleApprover[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JustInTimeAccessPolicyMaximumActivationDuration
The maximum access duration in ISO 8601 format for just-in-time access requests.

```yaml
Type: System.TimeSpan
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JustInTimeAccessPolicyMultiFactorAuthProvider
The multi-factor authorization provider to be used for just-in-time access requests.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Support.MultiFactorAuthProvider
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalId
The identifier of the Azure Active Directory principal.

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

### -PrincipalIdDisplayName
The display name of the Azure Active Directory principal.

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

### -RoleDefinitionId
The identifier of the Azure built-in role that defines the permissions that the Azure Active Directory principal will have on the projected scope.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.EligibleAuthorization

## NOTES

## RELATED LINKS
