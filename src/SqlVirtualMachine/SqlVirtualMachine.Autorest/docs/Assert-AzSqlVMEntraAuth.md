---
external help file:
Module Name: Az.SqlVirtualMachine
online version: https://learn.microsoft.com/powershell/module/az.sqlvirtualmachine/Assert-AzSqlVMEntraAuth
schema: 2.0.0
---

# Assert-AzSqlVMEntraAuth

## SYNOPSIS
Validates a SQL virtual machine Entra Authentication.

## SYNTAX

### AssertExpanded (Default)
```
Assert-AzSqlVMEntraAuth -Name <String> -ResourceGroupName <String> -IdentityType <String>
 [-SubscriptionId <String>] [-ManagedIdentityClientId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### AssertViaIdentity
```
Assert-AzSqlVMEntraAuth -InputObject <ISqlVirtualMachineIdentity> -IdentityType <String>
 [-ManagedIdentityClientId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Validates a SQL virtual machine Entra Authentication.

## EXAMPLES

### Example 1:
```powershell
Assert-AzSqlVMEntraAuth -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -IdentityType 'SystemAssigned'
```

```output
Sql virtual machine veppala-sqlvm1 is valid for Azure AD authentication.
```

Validates system assigned managed identity for enabling Entra authentication on Sql VM

### Example 2:
```powershell
Assert-AzSqlVMEntraAuth -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -IdentityType 'UserAssigned' -ManagedIdentityClientId '11111111-2222-3333-4444-555555555555'
```

```output
Sql virtual machine veppala-sqlvm1 is valid for Azure AD authentication.
```

validates user assigned managed identity for enabling Entra authentication on Sql VM

### Example 3:
```powershell
$sqlVM = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
$sqlVM | Assert-AzSqlVMEntraAuth -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -IdentityType 'SystemAssigned'
```

```output
Sql virtual machine veppala-sqlvm1 is valid for Azure AD authentication.
```

Validates system assigned managed identity for enabling Entra authentication on Sql VM

### Example 4:
```powershell
$sqlVM = Get-AzSqlVM -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1'
$sqlVM | Assert-AzSqlVMEntraAuth -ResourceGroupName 'ResourceGroup01' -Name 'sqlvm1' -IdentityType 'UserAssigned' -ManagedIdentityClientId '11111111-2222-3333-4444-555555555555'
```

```output
Sql virtual machine veppala-sqlvm1 is valid for Azure AD authentication.
```

validates user assigned managed identity for enabling Entra authentication on Sql VM

## PARAMETERS

### -AsJob
Run the command as a job

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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.ISqlVirtualMachineIdentity
Parameter Sets: AssertViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedIdentityClientId
The client Id of the Managed Identity to query Microsoft Graph API.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the SQL virtual machine.

```yaml
Type: System.String
Parameter Sets: AssertExpanded
Aliases: SqlVirtualMachineName, SqlVMName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -ResourceGroupName
Name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: AssertExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription ID that identifies an Azure subscription.

```yaml
Type: System.String
Parameter Sets: AssertExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.ISqlVirtualMachineIdentity

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS

