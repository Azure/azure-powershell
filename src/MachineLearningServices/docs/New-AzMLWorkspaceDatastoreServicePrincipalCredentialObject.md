---
external help file:
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.MachineLearningServices/new-AzMLWorkspaceDatastoreServicePrincipalCredentialObject
schema: 2.0.0
---

# New-AzMLWorkspaceDatastoreServicePrincipalCredentialObject

## SYNOPSIS
Create an in-memory object for ServicePrincipalDatastoreCredentials.

## SYNTAX

```
New-AzMLWorkspaceDatastoreServicePrincipalCredentialObject -ClientId <String> -ClientSecret <String>
 -TenantId <String> [-AuthorityUrl <String>] [-ResourceUrl <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ServicePrincipalDatastoreCredentials.

## EXAMPLES

### Example 1: Create an in-memory object for ServicePrincipalDatastoreCredentials
```powershell
New-AzMLWorkspaceDatastoreServicePrincipalCredentialObject
```

Create an in-memory object for ServicePrincipalDatastoreCredentials

## PARAMETERS

### -AuthorityUrl
Authority URL used for authentication.

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

### -ClientId
[Required] Service principal client ID.

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

### -ClientSecret
[Required] Service principal secret.

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

### -ResourceUrl
Resource the service principal has access to.

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

### -TenantId
[Required] ID of the tenant to which the service principal belongs.

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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20220501.ServicePrincipalDatastoreCredentials

## NOTES

ALIASES

## RELATED LINKS

