---
external help file: Microsoft.Azure.PowerShell.Cmdlets.NetAppFiles.dll-Help.xml
Module Name: Az.NetAppFiles
online version: https://learn.microsoft.com/powershell/module/az.netappfiles/invoke-aznetappfilesaccountchangekeyvault
schema: 2.0.0
---

# Invoke-AzNetAppFilesAccountChangeKeyVault

## SYNOPSIS
Change Key Vault/Managed HSM that is used for encryption of volumes under NetApp account

## SYNTAX

### ByFieldsParameterSet (Default)
```
Invoke-AzNetAppFilesAccountChangeKeyVault -ResourceGroupName <String> [-Location <String>] -Name <String>
 [-KeyVaultUri <String>] [-KeyVaultKeyName <String>] [-KeyVaultResourceId <String>]
 [-KeyVaultPrivateEndpoint <System.Collections.Generic.List`1[Microsoft.Azure.Commands.NetAppFiles.Models.PSANFKeyVaultPrivateEndpoint]>]
 [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ByResourceIdParameterSet
```
Invoke-AzNetAppFilesAccountChangeKeyVault -ResourceGroupName <String> [-Location <String>] -Name <String>
 -ResourceId <String> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByObjectParameterSet
```
Invoke-AzNetAppFilesAccountChangeKeyVault -ResourceGroupName <String> [-Location <String>] -Name <String>
 -InputObject <PSNetAppFilesAccount> [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Affects existing volumes that are encrypted with Key Vault/Managed HSM, and new volumes. Supports HSM to Key Vault, Key Vault to HSM, HSM to HSM and Key Vault to Key Vault

## EXAMPLES

### Example 1
```powershell
$vnet = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRG/providers/Microsoft.Network/virtualNetworks/myvnet"
$privateEndpoint = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/ps2501/providers/Microsoft.Network/privateEndpoints/private-endpoint"
$keyVaultUri = "https://myakv.vault.azure.net/"
$keyVaultResourceId = "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myRG/providers/Microsoft.KeyVault/vaults/vaults/myakv"
$keyVaultPrivateEndpoint = @{
    VirtualNetworkId = $vnet.Id
    PrivateEndpointId = $privateEndpoint.Id
}
Invoke-AzNetAppFilesAccountChangeKeyVault -ResourceGroupName "MyRG" -AccountName "MyAccount" -KeyVaultUri $keyVaultUri -KeyVaultKeyName  "MyKeyName" -KeyVaultResourceId $keyVaultResourceId -KeyVaultPrivateEndpoint $keyVaultPrivateEndpoint
```

Changes what Key Vault/Managed HSM is used for Volumes in NetAppAccount "MyAccount"

## PARAMETERS

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

### -InputObject
The account object to invoke ChangeKeyVaultconvert on

```yaml
Type: PSNetAppFilesAccount
Parameter Sets: ByObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -KeyVaultKeyName
The name of KeyVault key

```yaml
Type: String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultPrivateEndpoint
Pairs of virtual network ID and private endpoint ID.
Every virtual network that has volumes encrypted with customer-managed keys needs its own key vault private endpoint.

```yaml
Type: System.Collections.Generic.List`1[Microsoft.Azure.Commands.NetAppFiles.Models.PSANFKeyVaultPrivateEndpoint]
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultResourceId
The resource ID of KeyVault.

```yaml
Type: String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -KeyVaultUri
The Uri of KeyVault.

```yaml
Type: String
Parameter Sets: ByFieldsParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the resource

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

### -Name
The name of the ANF account

```yaml
Type: String
Parameter Sets: (All)
Aliases: AccountName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Return whether the specified NetApp Accounts KeyVault was successfully changed

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

### -ResourceGroupName
The resource group of the ANF account

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

### -ResourceId
The resource id of the ANF account

```yaml
Type: String
Parameter Sets: ByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesAccount

## OUTPUTS

### Microsoft.Azure.Commands.NetAppFiles.Models.PSNetAppFilesAccount

## NOTES

## RELATED LINKS
