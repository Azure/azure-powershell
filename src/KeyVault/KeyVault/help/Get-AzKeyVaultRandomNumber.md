---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://learn.microsoft.com/powershell/module/az.keyvault/get-azkeyvaultrandomnumber
schema: 2.0.0
---

# Get-AzKeyVaultRandomNumber

## SYNOPSIS
Get the requested number of bytes containing random values from a managed HSM.

## SYNTAX

### GetByHsmName (Default)
```
Get-AzKeyVaultRandomNumber [-DefaultProfile <IAzureContextContainer>] [-HsmName] <String> -Count <Int32>
 [-AsBase64String] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByHsmResourceId
```
Get-AzKeyVaultRandomNumber [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>] -Count <Int32>
 [-AsBase64String] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetByHsmInputObject
```
Get-AzKeyVaultRandomNumber [-DefaultProfile <IAzureContextContainer>] [-InputObject] <PSManagedHsm>
 -Count <Int32> [-AsBase64String] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get the requested number of bytes containing random values from a managed HSM.

## EXAMPLES

### Example 1: Get requested number of random bytes by managed HSM name
```powershell
Get-AzKeyVaultRandomNumber -HsmName testmhsm -Count 10
```

```output
158
171
96
142
109
28
1
85
178
201
```

This command gets 10 random bytes from managed HSM "testmhsm" 

### Example 2: Get random number as base64 string by piping
```powershell
Get-AzKeyVaultManagedHsm -HsmName bezmhsm2022 | Get-AzKeyVaultRandomNumber -Count 10 -AsBase64String
```

```output
G1CsEqa9yUp/EA==
```

This command gets 10 random bytes as base-64 string from managed HSM "testmhsm" 

### Example 3: Get random number by resource id
```powershell
Get-AzKeyVaultRandomNumber -ResourceId /subscriptions/0b1fxxxx-xxxx-xxxx-aec3-xxxx72f09590/resourceGroups/test-rg/provders/Microsoft.KeyVault/managedHSMs/testhsm -Count 10
```

```output
158
171
96
142
109
28
1
85
178
201
```

This command gets 10 random bytes from managed HSM with specified resource id

## PARAMETERS

### -AsBase64String
If specified, return random number as base-64 digit.
By default, this command retruns random number as byte array.

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

### -Count
The requested number of random bytes.

```yaml
Type: System.Int32
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
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmName
HSM name. Cmdlet constructs the FQDN of a managed HSM based on the name and currently selected environment.

```yaml
Type: System.String
Parameter Sets: GetByHsmName
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
HSM object.

```yaml
Type: Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm
Parameter Sets: GetByHsmInputObject
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### -ResourceId
HSM resource id.

```yaml
Type: System.String
Parameter Sets: GetByHsmResourceId
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm

## OUTPUTS

### System.String

### System.Byte

## NOTES

## RELATED LINKS
