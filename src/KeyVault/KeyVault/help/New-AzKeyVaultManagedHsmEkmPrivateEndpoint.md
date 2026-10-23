---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version:
schema: 2.0.0
---

# New-AzKeyVaultManagedHsmEkmPrivateEndpoint

## SYNOPSIS
Creates an outbound External Key Manager private endpoint on a Managed HSM (preview).

## SYNTAX

### ByHsmName (Default)
```
New-AzKeyVaultManagedHsmEkmPrivateEndpoint -Name <String> -PrivateLinkServiceAlias <String>
 [-RequestMessage <String>] [-NoWait] [-HsmName] <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

### ByHsmId
```
New-AzKeyVaultManagedHsmEkmPrivateEndpoint -Name <String> -PrivateLinkServiceAlias <String>
 [-RequestMessage <String>] [-NoWait] [-HsmId] <String> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

### ByInputObject
```
New-AzKeyVaultManagedHsmEkmPrivateEndpoint -Name <String> -PrivateLinkServiceAlias <String>
 [-RequestMessage <String>] [-NoWait] [-HsmObject] <PSManagedHsm> [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a private endpoint from a Managed HSM to the Private Link Service hosting an External Key Manager (EKM) proxy. This is an outbound EKM endpoint, not an inbound private endpoint for access to the HSM.

Supply the Private Link Service alias, not its Azure resource ID. A Managed HSM supports at most two EKM private endpoints. By default the command waits for the service operation to complete and returns its job ID and status. Provisioning success does not mean the Private Link Service owner has approved the connection. The command does not change the active EKM connection.

This command is in preview. Use `NoWait` to submit the request without polling; this produces no operation output.

## EXAMPLES

### Example 1: Create an outbound endpoint
```powershell
New-AzKeyVaultManagedHsmEkmPrivateEndpoint -HsmName testmhsm -Name pe1 -PrivateLinkServiceAlias 'proxy.identifier.region.azure.privatelinkservice' -RequestMessage 'EKM proxy connection'
```

Creates the endpoint and returns the completed provisioning operation. The Private Link Service owner approves the connection separately.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeReference
The change reference resource ID for this resource operation.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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
Name of the outbound EKM private endpoint, containing 1-24 alphanumeric or hyphen characters.

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

### -NoWait
Return after submitting the operation, without polling or writing an operation result.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PrivateLinkServiceAlias
Alias of the proxy's Private Link Service, not its resource ID.

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

### -RequestMessage
Message sent to the Private Link Service owner with the connection request.

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

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultEkmPrivateEndpointOperation
## NOTES

## RELATED LINKS
