---
external help file:
Module Name: Az.Stack
online version: https://docs.microsoft.com/en-us/powershell/module/az.stack/get-azstackcloudmanifestfile
schema: 2.0.0
---

# Get-AzStackCloudManifestFile

## SYNOPSIS
Returns a cloud specific manifest JSON file.

## SYNTAX

### List (Default)
```
Get-AzStackCloudManifestFile [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzStackCloudManifestFile -VerificationVersion <String> [-VersionCreationDate <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzStackCloudManifestFile -InputObject <IStackIdentity> [-VersionCreationDate <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Returns a cloud specific manifest JSON file.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Stack.Models.IStackIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -VerificationVersion
Signing verification key version.

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

### -VersionCreationDate
Signing verification key version creation date.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Stack.Models.IStackIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Stack.Models.Api20200601Preview.ICloudManifestFileResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IStackIdentity>: Identity Parameter
  - `[CustomerSubscriptionName <String>]`: Name of the product.
  - `[Id <String>]`: Resource identity path
  - `[LinkedSubscriptionName <String>]`: Name of the Linked Subscription resource.
  - `[ProductName <String>]`: Name of the product.
  - `[RegistrationName <String>]`: Name of the Azure Stack registration.
  - `[ResourceGroup <String>]`: Name of the resource group.
  - `[SubscriptionId <String>]`: Subscription credentials that uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
  - `[VerificationVersion <String>]`: Signing verification key version.

## RELATED LINKS

