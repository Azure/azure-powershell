---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version:
schema: 2.0.0
---

# Get-AzKeyVaultManagedHsmEkmPrivateEndpointOperation

## SYNOPSIS
Gets an External Key Manager private endpoint operation's status (preview).

## SYNTAX

### ByHsmName (Default)
```
Get-AzKeyVaultManagedHsmEkmPrivateEndpointOperation -JobId <String> [-HsmName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByHsmId
```
Get-AzKeyVaultManagedHsmEkmPrivateEndpointOperation -JobId <String> [-HsmId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByInputObject
```
Get-AzKeyVaultManagedHsmEkmPrivateEndpointOperation -JobId <String> [-HsmObject] <PSManagedHsm>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets the status of an outbound External Key Manager (EKM) private endpoint operation by its job ID. Output includes the endpoint name, operation type, status, timestamps, and service error details when present. This is distinct from the endpoint's Private Link Service approval state. This command is in preview.

## EXAMPLES

### Example 1: Get operation status
```powershell
Get-AzKeyVaultManagedHsmEkmPrivateEndpointOperation -HsmName testmhsm -JobId '00000000-0000-0000-0000-000000000001'
```

Gets the operation identified by the job ID returned in a private endpoint operation result.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmId
Resource Id of the HSM.

```yaml
Type: String
Parameter Sets: ByHsmId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmName
Name of the HSM.

```yaml
Type: String
Parameter Sets: ByHsmName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmObject
HSM object.

```yaml
Type: PSManagedHsm
Parameter Sets: ByInputObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JobId
Job ID returned by an EKM private endpoint operation.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm
## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultEkmPrivateEndpointOperation
## NOTES

## RELATED LINKS
