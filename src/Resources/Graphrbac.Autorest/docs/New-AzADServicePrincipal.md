---
external help file:
Module Name: Az.AD
online version: https://docs.microsoft.com/en-us/powershell/module/az.ad/new-azadserviceprincipal
schema: 2.0.0
---

# New-AzADServicePrincipal

## SYNOPSIS
Creates a service principal in the directory.

## SYNTAX

```
New-AzADServicePrincipal -TenantId <String> -AppId <String> [-AccountEnabled] [-AppRoleAssignmentRequired]
 [-KeyCredentials <IKeyCredential[]>] [-PasswordCredentials <IPasswordCredential[]>]
 [-ServicePrincipalType <String>] [-Tag <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a service principal in the directory.

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppId
The application ID.

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

### -AppRoleAssignmentRequired
Specifies whether an AppRoleAssignment to a user or group is required before Azure AD will issue a user or access token to the application.

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

### -KeyCredentials
The collection of key credentials associated with the service principal.
To construct, see NOTES section for KEYCREDENTIALS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IKeyCredential[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PasswordCredentials
The collection of password credentials associated with the service principal.
To construct, see NOTES section for PASSWORDCREDENTIALS properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IPasswordCredential[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePrincipalType
the type of the service principal

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

### -Tag
Optional list of tags that you can apply to your service principals.
Not nullable.

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

### -TenantId
The tenant ID.

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

### Microsoft.Azure.PowerShell.Cmdlets.AD.Models.Api16.IServicePrincipal

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


KEYCREDENTIALS <IKeyCredential[]>: The collection of key credentials associated with the service principal.
  - `[CustomKeyIdentifier <String>]`: Custom Key Identifier
  - `[EndDate <DateTime?>]`: End date.
  - `[KeyId <String>]`: Key ID.
  - `[StartDate <DateTime?>]`: Start date.
  - `[Type <String>]`: Type. Acceptable values are 'AsymmetricX509Cert' and 'Symmetric'.
  - `[Usage <String>]`: Usage. Acceptable values are 'Verify' and 'Sign'.
  - `[Value <String>]`: Key value.

PASSWORDCREDENTIALS <IPasswordCredential[]>: The collection of password credentials associated with the service principal.
  - `[CustomKeyIdentifier <Byte[]>]`: Custom Key Identifier
  - `[EndDate <DateTime?>]`: End date.
  - `[KeyId <String>]`: Key ID.
  - `[StartDate <DateTime?>]`: Start date.
  - `[Value <String>]`: Key value.

## RELATED LINKS

