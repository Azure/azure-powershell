---
external help file:
Module Name: Az.Maps
online version: https://docs.microsoft.com/en-us/powershell/module/az.maps/get-azmapsaccountsas
schema: 2.0.0
---

# Get-AzMapsAccountSas

## SYNOPSIS
Create and list an account shared access signature token.
Use this SAS token for authentication to Azure Maps REST APIs through various Azure Maps SDKs.
As prerequisite to create a SAS Token.
\n\nPrerequisites:\n1.
Create or have an existing User Assigned Managed Identity in the same Azure region as the account.
\n2.
Create or update an Azure Map account with the same Azure region as the User Assigned Managed Identity is placed.

## SYNTAX

### ListExpanded (Default)
```
Get-AzMapsAccountSas -AccountName <String> -ResourceGroupName <String> -Expiry <String>
 -MaxRatePerSecond <Int32> -PrincipalId <String> -SigningKey <SigningKey> -Start <String>
 [-SubscriptionId <String[]>] [-Region <String[]>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### List
```
Get-AzMapsAccountSas -AccountName <String> -ResourceGroupName <String>
 -MapsAccountSasParameter <IAccountSasParameters> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create and list an account shared access signature token.
Use this SAS token for authentication to Azure Maps REST APIs through various Azure Maps SDKs.
As prerequisite to create a SAS Token.
\n\nPrerequisites:\n1.
Create or have an existing User Assigned Managed Identity in the same Azure region as the account.
\n2.
Create or update an Azure Map account with the same Azure region as the User Assigned Managed Identity is placed.

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

### -AccountName
The name of the Maps Account.

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

### -Expiry
The date time offset of when the token validity expires.
For example "2017-05-24T10:42:03.1567373Z"

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MapsAccountSasParameter
Parameters used to create an account Shared Access Signature (SAS) token.
The REST API access control is provided by Azure Maps Role Based Access (RBAC) identity and access.
To construct, see NOTES section for MAPSACCOUNTSASPARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20211201Preview.IAccountSasParameters
Parameter Sets: List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -MaxRatePerSecond
Required parameter which represents the desired maximum request per second to allowed for the given SAS token.
This does not guarantee perfect accuracy in measurements but provides application safe guards of abuse with eventual enforcement.

```yaml
Type: System.Int32
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrincipalId
The principal Id also known as the object Id of a User Assigned Managed Identity currently assigned to the Map Account.
To assign a Managed Identity of the account, use operation Create or Update an assign a User Assigned Identity resource Id.

```yaml
Type: System.String
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Region
Optional, allows control of which region locations are permitted access to Azure Maps REST APIs with the SAS token.
Example: "eastus", "westus2".
Omitting this parameter will allow all region locations to be accessible.

```yaml
Type: System.String[]
Parameter Sets: ListExpanded
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

### -SigningKey
The Map account key to use for signing.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Maps.Support.SigningKey
Parameter Sets: ListExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Start
The date time offset of when the token validity begins.
For example "2017-05-24T10:42:03.1567373Z".

```yaml
Type: System.String
Parameter Sets: ListExpanded
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
Type: System.String[]
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.Maps.Models.Api20211201Preview.IAccountSasParameters

## OUTPUTS

### System.String

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


MAPSACCOUNTSASPARAMETER <IAccountSasParameters>: Parameters used to create an account Shared Access Signature (SAS) token. The REST API access control is provided by Azure Maps Role Based Access (RBAC) identity and access.
  - `Expiry <String>`: The date time offset of when the token validity expires. For example "2017-05-24T10:42:03.1567373Z"
  - `MaxRatePerSecond <Int32>`: Required parameter which represents the desired maximum request per second to allowed for the given SAS token. This does not guarantee perfect accuracy in measurements but provides application safe guards of abuse with eventual enforcement.
  - `PrincipalId <String>`: The principal Id also known as the object Id of a User Assigned Managed Identity currently assigned to the Map Account. To assign a Managed Identity of the account, use operation Create or Update an assign a User Assigned Identity resource Id.
  - `SigningKey <SigningKey>`: The Map account key to use for signing.
  - `Start <String>`: The date time offset of when the token validity begins. For example "2017-05-24T10:42:03.1567373Z".
  - `[Region <String[]>]`: Optional, allows control of which region locations are permitted access to Azure Maps REST APIs with the SAS token. Example: "eastus", "westus2". Omitting this parameter will allow all region locations to be accessible.

## RELATED LINKS

