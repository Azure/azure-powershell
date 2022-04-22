---
external help file:
Module Name: Az.Batch
online version: https://docs.microsoft.com/en-us/powershell/module/az.batch/test-azbatchlocationnameavailability
schema: 2.0.0
---

# Test-AzBatchLocationNameAvailability

## SYNOPSIS
Checks whether the Batch account name is available in the specified region.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzBatchLocationNameAvailability -LocationName <String> -Name <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Check
```
Test-AzBatchLocationNameAvailability -LocationName <String> -Parameter <ICheckNameAvailabilityParameters>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzBatchLocationNameAvailability -InputObject <IBatchIdentity>
 -Parameter <ICheckNameAvailabilityParameters> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzBatchLocationNameAvailability -InputObject <IBatchIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Checks whether the Batch account name is available in the specified region.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity
Parameter Sets: CheckViaIdentity, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -LocationName
The desired region for the name check.

```yaml
Type: System.String
Parameter Sets: Check, CheckExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name to check for availability

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Parameters for a check name availability request.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.ICheckNameAvailabilityParameters
Parameter Sets: Check, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000)

```yaml
Type: System.String
Parameter Sets: Check, CheckExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.ICheckNameAvailabilityParameters

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.IBatchIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Batch.Models.Api202201.ICheckNameAvailabilityResult

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IBatchIdentity>: Identity Parameter
  - `[AccountName <String>]`: A name for the Batch account which must be unique within the region. Batch account names must be between 3 and 24 characters in length and must use only numbers and lowercase letters. This name is used as part of the DNS name that is used to access the Batch service in the region in which the account is created. For example: http://accountname.region.batch.azure.com/.
  - `[ApplicationName <String>]`: The name of the application. This must be unique within the account.
  - `[CertificateName <String>]`: The identifier for the certificate. This must be made up of algorithm and thumbprint separated by a dash, and must match the certificate data in the request. For example SHA1-a3d1c5.
  - `[DetectorId <String>]`: The name of the detector.
  - `[Id <String>]`: Resource identity path
  - `[LocationName <String>]`: The region for which to retrieve Batch service quotas.
  - `[PoolName <String>]`: The pool name. This must be unique within the account.
  - `[PrivateEndpointConnectionName <String>]`: The private endpoint connection name. This must be unique within the account.
  - `[PrivateLinkResourceName <String>]`: The private link resource name. This must be unique within the account.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the Batch account.
  - `[SubscriptionId <String>]`: The Azure subscription ID. This is a GUID-formatted string (e.g. 00000000-0000-0000-0000-000000000000)
  - `[VersionName <String>]`: The version of the application.

PARAMETER <ICheckNameAvailabilityParameters>: Parameters for a check name availability request.
  - `Name <String>`: The name to check for availability

## RELATED LINKS

