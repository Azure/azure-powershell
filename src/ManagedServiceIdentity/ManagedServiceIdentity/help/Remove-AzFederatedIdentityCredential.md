---
external help file: Az.ManagedServiceIdentity-help.xml
Module Name: Az.ManagedServiceIdentity
online version: https://learn.microsoft.com/powershell/module/az.managedserviceidentity/remove-azfederatedidentitycredential
schema: 2.0.0
---

# Remove-AzFederatedIdentityCredential

## SYNOPSIS
Deletes the federated identity credential.

## SYNTAX

### Delete (Default)
```
Remove-AzFederatedIdentityCredential -IdentityName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-ProgressAction <ActionPreference>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### DeleteViaIdentity
```
Remove-AzFederatedIdentityCredential -InputObject <IManagedServiceIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Deletes the federated identity credential.

## EXAMPLES

### Example 1: Delete federated identity credential
```powershell
Remove-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 -Name fic-pwsh01
```

This command deletes a federated identity credential.

### Example 2: Delete federated identity credential by pipeline
```powershell
Get-AzFederatedIdentityCredential -ResourceGroupName azure-rg-test -IdentityName uai-pwsh01 -Name fic-pwsh01 | Remove-AzFederatedIdentityCredential
```

This command deletes a federated identity credential by pipeline.

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

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

### -IdentityName
The name of the identity resource.

```yaml
Type: System.String
Parameter Sets: Delete
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IManagedServiceIdentity
Parameter Sets: DeleteViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the federated identity credential resource.

```yaml
Type: System.String
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
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
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: Delete
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Id of the Subscription to which the identity belongs.

```yaml
Type: System.String
Parameter Sets: Delete
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedServiceIdentity.Models.IManagedServiceIdentity

## OUTPUTS

### System.Boolean

## NOTES

ALIASES

Remove-AzFederatedIdentityCredentials

## RELATED LINKS
