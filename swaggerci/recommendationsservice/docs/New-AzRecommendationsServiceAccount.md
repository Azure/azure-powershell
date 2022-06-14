---
external help file:
Module Name: Az.RecommendationsService
online version: https://docs.microsoft.com/en-us/powershell/module/az.recommendationsservice/new-azrecommendationsserviceaccount
schema: 2.0.0
---

# New-AzRecommendationsServiceAccount

## SYNOPSIS
Creates or updates RecommendationsService Account resource.

## SYNTAX

```
New-AzRecommendationsServiceAccount -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-Configuration <AccountConfiguration>] [-Cor <ICorsRule[]>]
 [-EndpointAuthentication <IEndpointAuthentication[]>] [-ReportsConnectionString <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates RecommendationsService Account resource.

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

### -Configuration
Account configuration.
This can only be set at RecommendationsService Account creation.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecommendationsService.Support.AccountConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Cor
The list of CORS details.
To construct, see NOTES section for COR properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecommendationsService.Models.Api20220201.ICorsRule[]
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

### -EndpointAuthentication
The list of service endpoints authentication details.
To construct, see NOTES section for ENDPOINTAUTHENTICATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.RecommendationsService.Models.Api20220201.IEndpointAuthentication[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

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

### -Name
The name of the RecommendationsService Account resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AccountName

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

### -ReportsConnectionString
Connection string to write Accounts reports to.

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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

### -SubscriptionId
The ID of the target subscription.

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

### -Tag
Resource tags.

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

### Microsoft.Azure.PowerShell.Cmdlets.RecommendationsService.Models.Api20220201.IAccountResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


COR <ICorsRule[]>: The list of CORS details.
  - `AllowedOrigin <String[]>`: The origin domains that are permitted to make a request against the service via CORS.
  - `[AllowedHeader <String[]>]`: The request headers that the origin domain may specify on the CORS request.
  - `[AllowedMethod <String[]>]`: The methods (HTTP request verbs) that the origin domain may use for a CORS request.
  - `[ExposedHeader <String[]>]`: The response headers to expose to CORS clients.
  - `[MaxAgeInSecond <Int32?>]`: The number of seconds that the client/browser should cache a preflight response.

ENDPOINTAUTHENTICATION <IEndpointAuthentication[]>: The list of service endpoints authentication details.
  - `[AadTenantId <String>]`: AAD tenant ID.
  - `[PrincipalId <String>]`: AAD principal ID.
  - `[PrincipalType <PrincipalType?>]`: AAD principal type.

## RELATED LINKS

