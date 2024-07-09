---
external help file:
Module Name: Az.OracleDatabase
online version: https://learn.microsoft.com/powershell/module/az.oracledatabase/new-azoracledatabaseautonomousdatabasewallet
schema: 2.0.0
---

# New-AzOracleDatabaseAutonomousDatabaseWallet

## SYNOPSIS
Generate wallet action on Autonomous Database

## SYNTAX

### GenerateViaIdentity (Default)
```
New-AzOracleDatabaseAutonomousDatabaseWallet -InputObject <IOracleDatabaseIdentity>
 -Body <IGenerateAutonomousDatabaseWalletDetails> [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Generate
```
New-AzOracleDatabaseAutonomousDatabaseWallet -Autonomousdatabasename <String> -ResourceGroupName <String>
 -Body <IGenerateAutonomousDatabaseWalletDetails> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GenerateExpanded
```
New-AzOracleDatabaseAutonomousDatabaseWallet -Autonomousdatabasename <String> -ResourceGroupName <String>
 -Password <SecureString> [-SubscriptionId <String>] [-GenerateType <String>] [-IsRegional]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GenerateViaIdentityExpanded
```
New-AzOracleDatabaseAutonomousDatabaseWallet -InputObject <IOracleDatabaseIdentity> -Password <SecureString>
 [-GenerateType <String>] [-IsRegional] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GenerateViaJsonFilePath
```
New-AzOracleDatabaseAutonomousDatabaseWallet -Autonomousdatabasename <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### GenerateViaJsonString
```
New-AzOracleDatabaseAutonomousDatabaseWallet -Autonomousdatabasename <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Generate wallet action on Autonomous Database

## EXAMPLES

### Example 1: Generates wallet on an Autonomous Database resource
```powershell
[SecureString]$password = ConvertTo-SecureString -String "PowerShellTestPass123" -AsPlainText -Force

New-AzOracleDatabaseAutonomousDatabaseWallet -Autonomousdatabasename "OFakePowerShellTestAdbs" -ResourceGroupName "PowerShellTestRg" -Password $password -GenerateType "walletType" -IsRegional $true
```

Generates wallet on an Autonomous Database resource.
For more information, execute `Get-Help New-AzOracleDatabaseAutonomousDatabaseWallet`

## PARAMETERS

### -Autonomousdatabasename
The database name.

```yaml
Type: System.String
Parameter Sets: Generate, GenerateExpanded, GenerateViaJsonFilePath, GenerateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
Autonomous Database Generate Wallet resource model.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IGenerateAutonomousDatabaseWalletDetails
Parameter Sets: Generate, GenerateViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

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

### -GenerateType
The type of wallet to generate.

```yaml
Type: System.String
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity
Parameter Sets: GenerateViaIdentity, GenerateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -IsRegional
True when requesting regional connection strings in PDB connect info, applicable to cross-region DG only.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Generate operation

```yaml
Type: System.String
Parameter Sets: GenerateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Generate operation

```yaml
Type: System.String
Parameter Sets: GenerateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Password
The password to encrypt the keys inside the wallet

```yaml
Type: System.Security.SecureString
Parameter Sets: GenerateExpanded, GenerateViaIdentityExpanded
Aliases:

Required: True
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
Parameter Sets: Generate, GenerateExpanded, GenerateViaJsonFilePath, GenerateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Generate, GenerateExpanded, GenerateViaJsonFilePath, GenerateViaJsonString
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

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IGenerateAutonomousDatabaseWalletDetails

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IOracleDatabaseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.IAutonomousDatabaseWalletFile

## NOTES

## RELATED LINKS

