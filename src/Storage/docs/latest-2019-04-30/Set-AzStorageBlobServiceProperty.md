---
external help file:
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/set-azstorageblobserviceproperty
schema: 2.0.0
---

# Set-AzStorageBlobServiceProperty

## SYNOPSIS
Sets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.

## SYNTAX

### SetExpanded (Default)
```
Set-AzStorageBlobServiceProperty -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-AutomaticSnapshotPolicyEnabled] [-ChangeFeedEnabled] [-CorCorsRule <ICorsRule[]>]
 [-DefaultServiceVersion <String>] [-DeleteRetentionPolicyDay <Int32>] [-DeleteRetentionPolicyEnabled]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Set
```
Set-AzStorageBlobServiceProperty -AccountName <String> -ResourceGroupName <String>
 -Parameter <IBlobServiceProperties> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Sets the properties of a storage account’s Blob service, including properties for Storage Analytics and CORS (Cross-Origin Resource Sharing) rules.

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

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -AutomaticSnapshotPolicyEnabled
Automatic Snapshot is enabled if set to true.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ChangeFeedEnabled
Indicates whether change feed event logging is enabled for the Blob service.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -CorCorsRule
The List of CORS rules.
You can include up to five CorsRule elements in the request.

To construct, see NOTES section for CORCORSRULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180701.ICorsRule[]
Parameter Sets: SetExpanded
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

### -DefaultServiceVersion
DefaultServiceVersion indicates the default version to use for requests to the Blob service if an incoming request’s version is not specified.
Possible values include version 2008-10-27 and all more recent versions.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DeleteRetentionPolicyDay
Indicates the number of days that the deleted blob should be retained.
The minimum specified value can be 1 and the maximum value can be 365.

```yaml
Type: System.Int32
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -DeleteRetentionPolicyEnabled
Indicates whether DeleteRetentionPolicy is enabled for the Blob service.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Parameter
The properties of a storage account’s Blob service.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20190401.IBlobServiceProperties
Parameter Sets: Set
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The name of the resource group within the user's subscription.
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
Dynamic: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20190401.IBlobServiceProperties

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20190401.IBlobServiceProperties

## ALIASES

## NOTES

### COMPLEX PARAMETER PROPERTIES
To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

#### CORCORSRULE <ICorsRule[]>: The List of CORS rules. You can include up to five CorsRule elements in the request. 
  - `AllowedHeader <String[]>`: Required if CorsRule element is present. A list of headers allowed to be part of the cross-origin request.
  - `AllowedMethod <String[]>`: Required if CorsRule element is present. A list of HTTP methods that are allowed to be executed by the origin.
  - `AllowedOrigin <String[]>`: Required if CorsRule element is present. A list of origin domains that will be allowed via CORS, or "*" to allow all domains
  - `ExposedHeader <String[]>`: Required if CorsRule element is present. A list of response headers to expose to CORS clients.
  - `MaxAgeInSecond <Int32>`: Required if CorsRule element is present. The number of seconds that the client/browser should cache a preflight response.

#### PARAMETER <IBlobServiceProperties>: The properties of a storage account’s Blob service.
  - `[AutomaticSnapshotPolicyEnabled <Boolean?>]`: Automatic Snapshot is enabled if set to true.
  - `[ChangeFeedEnabled <Boolean?>]`: Indicates whether change feed event logging is enabled for the Blob service.
  - `[CorCorsRule <ICorsRule[]>]`: The List of CORS rules. You can include up to five CorsRule elements in the request. 
    - `AllowedHeader <String[]>`: Required if CorsRule element is present. A list of headers allowed to be part of the cross-origin request.
    - `AllowedMethod <String[]>`: Required if CorsRule element is present. A list of HTTP methods that are allowed to be executed by the origin.
    - `AllowedOrigin <String[]>`: Required if CorsRule element is present. A list of origin domains that will be allowed via CORS, or "*" to allow all domains
    - `ExposedHeader <String[]>`: Required if CorsRule element is present. A list of response headers to expose to CORS clients.
    - `MaxAgeInSecond <Int32>`: Required if CorsRule element is present. The number of seconds that the client/browser should cache a preflight response.
  - `[DefaultServiceVersion <String>]`: DefaultServiceVersion indicates the default version to use for requests to the Blob service if an incoming request’s version is not specified. Possible values include version 2008-10-27 and all more recent versions.
  - `[DeleteRetentionPolicyDay <Int32?>]`: Indicates the number of days that the deleted blob should be retained. The minimum specified value can be 1 and the maximum value can be 365.
  - `[DeleteRetentionPolicyEnabled <Boolean?>]`: Indicates whether DeleteRetentionPolicy is enabled for the Blob service.

## RELATED LINKS

