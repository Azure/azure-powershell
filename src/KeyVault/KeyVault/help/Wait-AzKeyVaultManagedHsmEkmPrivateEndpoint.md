---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version:
schema: 2.0.0
---

# Wait-AzKeyVaultManagedHsmEkmPrivateEndpoint

## SYNOPSIS
Waits for an outbound External Key Manager private endpoint condition (preview).

## SYNTAX

### ByHsmName (Default)
```
Wait-AzKeyVaultManagedHsmEkmPrivateEndpoint -Name <String> [-ProvisioningState <String>]
 [-ConnectionStatus <String>] [-Exist] [-Deleted] [-Until <ScriptBlock>] [-Timeout <Int32>] [-Interval <Int32>]
 [-HsmName] <String> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByHsmId
```
Wait-AzKeyVaultManagedHsmEkmPrivateEndpoint -Name <String> [-ProvisioningState <String>]
 [-ConnectionStatus <String>] [-Exist] [-Deleted] [-Until <ScriptBlock>] [-Timeout <Int32>] [-Interval <Int32>]
 [-HsmId] <String> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

### ByInputObject
```
Wait-AzKeyVaultManagedHsmEkmPrivateEndpoint -Name <String> [-ProvisioningState <String>]
 [-ConnectionStatus <String>] [-Exist] [-Deleted] [-Until <ScriptBlock>] [-Timeout <Int32>] [-Interval <Int32>]
 [-HsmObject] <PSManagedHsm> [-DefaultProfile <IAzureContextContainer>] [-ProgressAction <ActionPreference>]
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
Polls an outbound External Key Manager (EKM) private endpoint until the requested condition is met or the timeout expires. By default it waits for provisioning to reach `Succeeded`. Use `ConnectionStatus` to wait separately for provider approval, `Exists` for existence, `Deleted` for a NotFound response, or `Until` for a custom PowerShell condition using the current endpoint as `$_`.

Specify only one condition. Authentication and authorization failures are not treated as deletion. Provisioning failures and rejected or disconnected approval requests stop the corresponding wait. Cancellation interrupts polling. This command is in preview.

## EXAMPLES

### Example 1: Wait for provisioning
```powershell
Wait-AzKeyVaultManagedHsmEkmPrivateEndpoint -HsmName testmhsm -Name pe1 -TimeoutSeconds 600
```

Returns the endpoint after provisioning succeeds; provider approval may still be pending.

### Example 2: Wait for provider approval
```powershell
Wait-AzKeyVaultManagedHsmEkmPrivateEndpoint -HsmName testmhsm -Name pe1 -ConnectionStatus Approved -TimeoutSeconds 600
```

Waits for the Private Link Service owner to approve the connection. The command does not approve it.

### Example 3: Wait for deletion
```powershell
Wait-AzKeyVaultManagedHsmEkmPrivateEndpoint -HsmName testmhsm -Name pe2 -Deleted -TimeoutSeconds 600
```

Returns without output when the endpoint is no longer found.

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

### -ConnectionStatus
Private Link Service connection status to wait for, independently of provisioning.

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: Pending, Approved, Rejected, Disconnected

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

### -Deleted
Wait until retrieving the endpoint returns NotFound.

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

### -Exist
Wait until the endpoint exists, regardless of provisioning or approval state.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: Exists

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

### -Interval
Delay in seconds between polls.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: IntervalSeconds

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the EKM private endpoint to poll.

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

### -ProvisioningState
Provisioning state to wait for.
Defaults to Succeeded; provisioning is distinct from provider approval.

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

### -Timeout
Maximum time in seconds to wait for the requested condition.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: TimeoutSeconds

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Until
Custom condition evaluated with the current endpoint in the pipeline variable.

```yaml
Type: ScriptBlock
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
