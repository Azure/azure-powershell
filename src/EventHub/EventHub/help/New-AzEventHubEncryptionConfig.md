---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventHub.dll-Help.xml
Module Name: Az.EventHub
online version:
schema: 2.0.0
---

# New-AzEventHubEncryptionConfig

## SYNOPSIS
Creates an in memory object instance of PSEncryptionConfigAttributes which can then be given as input to New-AzEventHubNamespace and Set-AzEventHubNamespace to enable encryption 

## SYNTAX

```
New-AzEventHubEncryptionConfig [-KeyName] <String> [-KeyVaultUri] <String> [-KeyVersion <String>]
 [-UserAssignedIdentity <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzEventHubEncryptionConfig** creates an in memory object. This command does not make any call or changes to the server. 

## EXAMPLES

### Example 1
```powershell
New-AzEventHubEncryptionConfig -KeyName key1 -KeyVaultUri https://myvaultname.vault.azure.net -UserAssignedIdentity '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName2'
```

Refer the doc for New-AzEventHubNamespace and Set-AzEventHubNamespace on how to use this further

## PARAMETERS

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

### -KeyName
Key Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -KeyVaultUri
Key Vault Uri

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -KeyVersion
Key Version

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -UserAssignedIdentity
User Assigned Identity

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Commands.EventHub.Models.PSEncryptionConfigAttributes

## NOTES

## RELATED LINKS
