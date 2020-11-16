using System;
---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Websites.dll-Help.xml
Module Name: Az.Websites
online version: https://docs.microsoft.com/en-us/powershell/module/az.websites/set-azwebapp
schema: 2.0.0
---

# Import-AzKeyVaultCertificate

## SYNOPSIS
Import an SSL certificate to a web app from Key Vault. 

## SYNTAX

```
Import-AzKeyCaultCertificate [-ResourceGroupName] <String> [-WebAppName] <String> [[-Slot] <String>]
[-KeyVaultName] <String> [-CertName] <String> 
[-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]

## DESCRIPTION
The **Import-AzKeyCaultCertificate** cmdlet imports an SSL certificate to a web app from Key Vault.

## EXAMPLES

### Example 1
```powershell
PS C:\> Import-AzKeyCaultCertificate -ResourceGroupName "Default-Web-WestUS" -Name "ContosoWebApp" -KeyVaultName "ContosoKeyVault" -CertName "ContosoCertname"
```

This command imports an SSL certificate to a web app from Key Vault.

### Example 2
```powershell
PS C:\> Import-AzKeyCaultCertificate -ResourceGroupName "Default-Web-WestUS" -Name "ContosoWebApp" 
-KeyVaultName  '/subscriptions/[sub id]/resourceGroups/[rg]/providers/Microsoft.KeyVault/vaults/[vault name]' -CertName "ContosoCertname"
```

This command Import an SSL certificate to a web app from Key Vault using resource id (typically if Key Vault is in another subscription).

### -KeyVaultName
Keyvault Name

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```
### -CertName
Keyvault Certificate Name

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Slot
WebApp Slot Name

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WebApp
WebApp Name

```yaml
Type: Microsoft.Azure.Commands.WebApps.Models.PSSite
Parameter Sets: (All)
Aliases:

Required: True
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.WebApps.Models.WebApp.PSCertificate

## NOTES

## RELATED LINKS
