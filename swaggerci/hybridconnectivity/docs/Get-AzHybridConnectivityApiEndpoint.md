---
external help file:
Module Name: Az.HybridConnectivityApi
online version: https://docs.microsoft.com/en-us/powershell/module/az.hybridconnectivityapi/get-azhybridconnectivityapiendpoint
schema: 2.0.0
---

# Get-AzHybridConnectivityApiEndpoint

## SYNOPSIS
Gets the endpoint to the resource.

## SYNTAX

### List (Default)
```
Get-AzHybridConnectivityApiEndpoint -ResourceUri <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzHybridConnectivityApiEndpoint -Name <String> -ResourceUri <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzHybridConnectivityApiEndpoint -InputObject <IHybridConnectivityApiIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the endpoint to the resource.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.HybridConnectivityApi.Models.IHybridConnectivityApiIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The endpoint name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: EndpointName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource to be connected.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HybridConnectivityApi.Models.IHybridConnectivityApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.HybridConnectivityApi.Models.Api20220501Preview.IEndpointResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IHybridConnectivityApiIdentity>: Identity Parameter
  - `[EndpointName <String>]`: The endpoint name.
  - `[Id <String>]`: Resource identity path
  - `[ResourceUri <String>]`: The fully qualified Azure Resource manager identifier of the resource to be connected.

## RELATED LINKS

