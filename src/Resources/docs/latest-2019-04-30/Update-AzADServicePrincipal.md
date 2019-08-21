---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/update-azadserviceprincipal
schema: 2.0.0
---

# Update-AzADServicePrincipal

## SYNOPSIS
Updates a service principal in the directory.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzADServicePrincipal -ObjectId <String> -TenantId <String> [-AccountEnabled]
 [-AppRoleAssignmentRequired] [-KeyCredentials <IKeyCredential[]>]
 [-PasswordCredentials <IPasswordCredential[]>] [-ServicePrincipalType <String>] [-Tag <String[]>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Update
```
Update-AzADServicePrincipal -ObjectId <String> -TenantId <String>
 -Parameter <IServicePrincipalUpdateParameters> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentity
```
Update-AzADServicePrincipal -InputObject <IResourcesIdentity> -Parameter <IServicePrincipalUpdateParameters>
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzADServicePrincipal -InputObject <IResourcesIdentity> [-AccountEnabled] [-AppRoleAssignmentRequired]
 [-KeyCredentials <IKeyCredential[]>] [-PasswordCredentials <IPasswordCredential[]>]
 [-ServicePrincipalType <String>] [-Tag <String[]>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Updates a service principal in the directory.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AccountEnabled
whether or not the service principal account is enabled

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AppRoleAssignmentRequired
Specifies whether an AppRoleAssignment to a user or group is required before Azure AD will issue a user or access token to the application.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: UpdateViaIdentity, UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -KeyCredentials
The collection of key credentials associated with the service principal.
To construct, see NOTES section for KEYCREDENTIALS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IKeyCredential[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ObjectId
The object ID of the service principal to delete.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
Request parameters for update an existing service principal.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IServicePrincipalUpdateParameters
Parameter Sets: Update, UpdateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -PasswordCredentials
The collection of password credentials associated with the service principal.
To construct, see NOTES section for PASSWORDCREDENTIALS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IPasswordCredential[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServicePrincipalType
the type of the service principal

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
Optional list of tags that you can apply to your service principals.
Not nullable.

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TenantId
The tenant ID.

```yaml
Type: System.String
Parameter Sets: Update, UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api16.IServicePrincipalUpdateParameters

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### System.Boolean

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### KEYCREDENTIALS <IKeyCredential[]>: The collection of key credentials associated with the service principal.
  - `[CustomKeyIdentifier <String>]`: Custom Key Identifier
  - `[EndDate <DateTime?>]`: End date.
  - `[KeyId <String>]`: Key ID.
  - `[StartDate <DateTime?>]`: Start date.
  - `[Type <String>]`: Type. Acceptable values are 'AsymmetricX509Cert' and 'Symmetric'.
  - `[Usage <String>]`: Usage. Acceptable values are 'Verify' and 'Sign'.
  - `[Value <String>]`: Key value.

#### PARAMETER <IServicePrincipalUpdateParameters>: Request parameters for update an existing service principal.
  - `[AccountEnabled <Boolean?>]`: whether or not the service principal account is enabled
  - `[AppRoleAssignmentRequired <Boolean?>]`: Specifies whether an AppRoleAssignment to a user or group is required before Azure AD will issue a user or access token to the application.
  - `[KeyCredentials <IKeyCredential[]>]`: The collection of key credentials associated with the service principal.
    - `[CustomKeyIdentifier <String>]`: Custom Key Identifier
    - `[EndDate <DateTime?>]`: End date.
    - `[KeyId <String>]`: Key ID.
    - `[StartDate <DateTime?>]`: Start date.
    - `[Type <String>]`: Type. Acceptable values are 'AsymmetricX509Cert' and 'Symmetric'.
    - `[Usage <String>]`: Usage. Acceptable values are 'Verify' and 'Sign'.
    - `[Value <String>]`: Key value.
  - `[PasswordCredentials <IPasswordCredential[]>]`: The collection of password credentials associated with the service principal.
    - `[CustomKeyIdentifier <Byte[]>]`: Custom Key Identifier
    - `[EndDate <DateTime?>]`: End date.
    - `[KeyId <String>]`: Key ID.
    - `[StartDate <DateTime?>]`: Start date.
    - `[Value <String>]`: Key value.
  - `[ServicePrincipalType <String>]`: the type of the service principal
  - `[Tag <String[]>]`: Optional list of tags that you can apply to your service principals. Not nullable.

#### PASSWORDCREDENTIALS <IPasswordCredential[]>: The collection of password credentials associated with the service principal.
  - `[CustomKeyIdentifier <Byte[]>]`: Custom Key Identifier
  - `[EndDate <DateTime?>]`: End date.
  - `[KeyId <String>]`: Key ID.
  - `[StartDate <DateTime?>]`: Start date.
  - `[Value <String>]`: Key value.

## RELATED LINKS

