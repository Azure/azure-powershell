---
external help file:
Module Name: Az.DataBoxEdge
online version: https://docs.microsoft.com/en-us/powershell/module/az.databoxedge/invoke-azdataboxedgeuploaddevicecertificate
schema: 2.0.0
---

# Invoke-AzDataBoxEdgeUploadDeviceCertificate

## SYNOPSIS
Uploads registration certificate for the device.

## SYNTAX

### UploadExpanded (Default)
```
Invoke-AzDataBoxEdgeUploadDeviceCertificate -DeviceName <String> -ResourceGroupName <String>
 -Certificate <String> [-SubscriptionId <String>] [-AuthenticationType <AuthenticationType>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Upload
```
Invoke-AzDataBoxEdgeUploadDeviceCertificate -DeviceName <String> -ResourceGroupName <String>
 -Parameter <IUploadCertificateRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UploadViaIdentity
```
Invoke-AzDataBoxEdgeUploadDeviceCertificate -InputObject <IDataBoxEdgeIdentity>
 -Parameter <IUploadCertificateRequest> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UploadViaIdentityExpanded
```
Invoke-AzDataBoxEdgeUploadDeviceCertificate -InputObject <IDataBoxEdgeIdentity> -Certificate <String>
 [-AuthenticationType <AuthenticationType>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Uploads registration certificate for the device.

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

### -AuthenticationType
The authentication type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Support.AuthenticationType
Parameter Sets: UploadExpanded, UploadViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Certificate
The base64 encoded certificate raw data.

```yaml
Type: System.String
Parameter Sets: UploadExpanded, UploadViaIdentityExpanded
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

### -DeviceName
The device name.

```yaml
Type: System.String
Parameter Sets: Upload, UploadExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.IDataBoxEdgeIdentity
Parameter Sets: UploadViaIdentity, UploadViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Parameter
The upload certificate request.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.Api20220301.IUploadCertificateRequest
Parameter Sets: Upload, UploadViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: System.String
Parameter Sets: Upload, UploadExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The subscription ID.

```yaml
Type: System.String
Parameter Sets: Upload, UploadExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.Api20220301.IUploadCertificateRequest

### Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.IDataBoxEdgeIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBoxEdge.Models.Api20220301.IUploadCertificateResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IDataBoxEdgeIdentity>: Identity Parameter
  - `[AddonName <String>]`: The addon name.
  - `[ContainerName <String>]`: The container Name
  - `[DeviceName <String>]`: The device name.
  - `[Id <String>]`: Resource identity path
  - `[Name <String>]`: The alert name.
  - `[ResourceGroupName <String>]`: The resource group name.
  - `[RoleName <String>]`: The role name.
  - `[StorageAccountName <String>]`: The storage account name.
  - `[SubscriptionId <String>]`: The subscription ID.

PARAMETER <IUploadCertificateRequest>: The upload certificate request.
  - `Certificate <String>`: The base64 encoded certificate raw data.
  - `[AuthenticationType <AuthenticationType?>]`: The authentication type.

## RELATED LINKS

