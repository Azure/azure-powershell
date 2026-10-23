---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version:
schema: 2.0.0
---

# Get-AzKeyVaultManagedHsmEkmPrivateEndpoint

## SYNOPSIS
Gets or lists outbound External Key Manager private endpoints on a Managed HSM (preview).

## SYNTAX

### ByHsmName (Default)
```
Get-AzKeyVaultManagedHsmEkmPrivateEndpoint [-Name <String>] [-HsmName] <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByHsmId
```
Get-AzKeyVaultManagedHsmEkmPrivateEndpoint [-Name <String>] [-HsmId] <String>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### ByInputObject
```
Get-AzKeyVaultManagedHsmEkmPrivateEndpoint [-Name <String>] [-HsmObject] <PSManagedHsm>
 [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets the named outbound External Key Manager (EKM) private endpoint, or lists all EKM private endpoints when `Name` is omitted. Output includes provisioning state and the separate Private Link Service connection approval state. This command is in preview and does not modify the HSM or request provider approval.

## EXAMPLES

### Example 1: List EKM private endpoints
```powershell
Get-AzKeyVaultManagedHsmEkmPrivateEndpoint -HsmName testmhsm
```

Lists outbound EKM endpoints configured on the HSM.

### Example 2: Inspect one endpoint
```powershell
Get-AzKeyVaultManagedHsmEkmPrivateEndpoint -HsmName testmhsm -Name pe1
```

Gets the endpoint's provisioning and provider approval states.

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

### -Name
Name of one EKM private endpoint.
Omit to list all endpoints on the HSM.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultEkmPrivateEndpoint
## NOTES

## RELATED LINKS
