---
external help file:
Module Name: Az.ManagementGroupsApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.managementgroupsapi/get-azmanagementgroupsapimanagementgroupsubscription
schema: 2.0.0
---

# Get-AzManagementGroupsApiManagementGroupSubscription

## SYNOPSIS
Retrieves details about given subscription which is associated with the management group.\n

## SYNTAX

### Get (Default)
```
Get-AzManagementGroupsApiManagementGroupSubscription -GroupId <String> [-SubscriptionId <String[]>]
 [-CacheControl <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzManagementGroupsApiManagementGroupSubscription -InputObject <IManagementGroupsApiIdentity>
 [-CacheControl <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves details about given subscription which is associated with the management group.\n

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

### -CacheControl
Indicates whether the request should utilize any caches.
Populate the header with 'no-cache' value to bypass existing caches.

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

### -GroupId
Management Group ID.

```yaml
Type: System.String
Parameter Sets: Get
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagementGroupsApi.Models.IManagementGroupsApiIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
Subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagementGroupsApi.Models.IManagementGroupsApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagementGroupsApi.Models.Api20210401.ISubscriptionUnderManagementGroup

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IManagementGroupsApiIdentity>: Identity Parameter
  - `[GroupId <String>]`: Management Group ID.
  - `[Id <String>]`: Resource identity path
  - `[SubscriptionId <String>]`: Subscription ID.

## RELATED LINKS

