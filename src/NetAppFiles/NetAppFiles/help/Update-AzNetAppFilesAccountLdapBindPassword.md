---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/update-aznetappfilesaccountldapbindpassword
schema: 2.0.0
---

# Update-AzNetAppFilesAccountLdapBindPassword

## SYNOPSIS
Refreshes an Azure NetApp Files account's LDAP bind password from Azure Key Vault.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Update-AzNetAppFilesAccountLdapBindPassword -ResourceGroupName <String> -Name <String>
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Update-AzNetAppFilesAccountLdapBindPassword -ResourceId <String>
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Update-AzNetAppFilesAccountLdapBindPassword -InputObject <PSNetAppFilesAccount>
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Fetches the latest LDAP bind password from the Azure Key Vault secret configured in the account's LdapConfiguration.BindPasswordAkvConfig. Use this command after rotating that secret. The command does not accept or return the password, and waits for the refresh operation to complete.

When ResourceId or InputObject is supplied, the command targets the subscription in the account's resource ID without changing the active Az context. With ResourceGroupName and Name, it uses the subscription from the selected context.

## EXAMPLES

### Example 1: Refresh a bind password after rotating its Key Vault secret
```powershell
Update-AzNetAppFilesAccountLdapBindPassword -ResourceGroupName "MyRG" -Name "MyAnfAccount" -PassThru
```

Returns True after the account successfully refreshes its LDAP bind password.

### Example 2: Refresh a bind password using an account object
```powershell
Get-AzNetAppFilesAccount -ResourceGroupName "MyRG" -Name "MyAnfAccount" |
    Update-AzNetAppFilesAccountLdapBindPassword
```

Refreshes the LDAP bind password for the account received from the pipeline.

### Example 3: Refresh an account in a different subscription
```powershell
$accountId = "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/MyRG/providers/Microsoft.NetApp/netAppAccounts/MyAnfAccount"
Update-AzNetAppFilesAccountLdapBindPassword -ResourceId $accountId -PassThru
```

Targets the subscription specified in the resource ID, even when it differs from the active context. The selected profile must have access to that subscription.

## PARAMETERS

### -ResourceGroupName
Name of the resource group containing the account.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the Azure NetApp Files account configured to use a Key Vault secret for LDAP bind authentication.

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases: AccountName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Full Azure resource ID of the account. The subscription in this ID is used for the refresh request.

```yaml
Type: System.String
Parameter Sets: ByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
Account object whose LDAP bind password is refreshed. The subscription in the object's Id is used for the refresh request.

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesAccount
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -PassThru
Returns True after a successful refresh. By default, the command returns no output.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.
For ResourceId and InputObject, the subscription in the account's resource ID overrides the profile's subscription for this request only.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the command runs. The command is not run.

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

### -Confirm
Prompts for confirmation before running the command.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutBuffer, -OutVariable, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters.

## INPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesAccount

### System.String

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

[Get-AzNetAppFilesAccount](Get-AzNetAppFilesAccount.md)
[Update-AzNetAppFilesAccount](Update-AzNetAppFilesAccount.md)
