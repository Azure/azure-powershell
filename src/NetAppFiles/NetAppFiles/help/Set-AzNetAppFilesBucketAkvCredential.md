---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/set-aznetappfilesbucketakvcredential
schema: 2.0.0
---

# Set-AzNetAppFilesBucketAkvCredential

## SYNOPSIS
Generates an Azure NetApp Files (ANF) Bucket Access Key / Secret Key pair and stores it in Azure Key Vault.

## SYNTAX

### ByFieldsParameterSet (Default)
```
Set-AzNetAppFilesBucketAkvCredential -ResourceGroupName <String> -AccountName <String> -PoolName <String>
 -VolumeName <String> -Name <String> [-KeyPairExpiryDay <Int32>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Set-AzNetAppFilesBucketAkvCredential -ResourceId <String> [-KeyPairExpiryDay <Int32>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByObjectParameterSet
```
Set-AzNetAppFilesBucketAkvCredential -InputObject <PSNetAppFilesBucket> [-KeyPairExpiryDay <Int32>] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzNetAppFilesBucketAkvCredential** cmdlet generates the Access Key and Secret Key pair used to access an ANF Bucket and stores the key pair as a secret in the Azure Key Vault configured on the Bucket (via **CredentialsKeyVaultUri** / **CredentialsSecretName** on **New-AzNetAppFilesBucket** or **Update-AzNetAppFilesBucket**). The generated key pair expires after **KeyPairExpiryDay** days.
Unlike **New-AzNetAppFilesBucketCredential**, this cmdlet does not return the credentials to the caller - consumers should retrieve them from Azure Key Vault. Use **-PassThru** to receive a boolean indicating whether the operation succeeded.

## EXAMPLES

### Example 1: Store bucket credentials in Azure Key Vault
```powershell
Set-AzNetAppFilesBucketAkvCredential -ResourceGroupName "MyRG" -AccountName "MyAnfAccount" -PoolName "MyAnfPool" -VolumeName "MyAnfVolume" -Name "MyAnfBucket" -KeyPairExpiryDay 30 -PassThru
```

Generates a new Access Key / Secret Key pair valid for 30 days and writes the pair as a secret into the Azure Key Vault configured on the Bucket.

## PARAMETERS

### -AccountName
The name of the ANF account

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

### -InputObject
The bucket object for which AKV-stored credentials should be generated

```yaml
Type: Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBucket
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyPairExpiryDay
Number of days from now until the newly generated Access and Secret key pair will expire.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the ANF bucket

```yaml
Type: System.String
Parameter Sets: ByFieldsParameterSet
Aliases: BucketName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Return whether the operation completed successfully

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

### -PoolName
The name of the ANF capacity pool

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

### -ResourceGroupName
The resource group of the ANF account

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

### -ResourceId
The resource id of the ANF bucket

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

### -VolumeName
The name of the ANF volume

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

### System.String

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesBucket

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
