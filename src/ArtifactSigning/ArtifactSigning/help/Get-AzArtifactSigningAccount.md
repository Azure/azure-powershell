---
external help file: Az.ArtifactSigning-help.xml
Module Name: Az.ArtifactSigning
online version: https://learn.microsoft.com/powershell/module/az.artifactsigning/get-azartifactsigningaccount
schema: 2.0.0
---

# Get-AzArtifactSigningAccount

## SYNOPSIS
Get a artifact signing Account.

## SYNTAX

### List (Default)
```
Get-AzArtifactSigningAccount [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzArtifactSigningAccount -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzArtifactSigningAccount -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzArtifactSigningAccount -InputObject <IArtifactSigningIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a artifact signing Account.

## EXAMPLES

### Example 1: Get A Artifact signing Account By Name
```powershell
Get-AzArtifactSigningAccount -AccountName test -ResourceGroupName rg-test
```

```output
AccountUri                         Id                                                                                                                                     Location Name    ProvisioningState ResourceGroupName RetryAfter SkuName SystemDataCreatedAt  SystemDataCreatedBy
----------                         --                                                                                                                                     -------- ----    ----------------- ----------------- ---------- ------- -------------------  -------------------
https://eus.codesigning.azure.net/ /subscriptions/66dc869d-771b-4f60-84c1-4964b5f4f5f2/resourceGroups/rg-test/providers/Microsoft.CodeSigning/codeSigningAccounts/test    eastus   test    Succeeded         rg-test                      Basic   1/24/2025 9:58:19 PM test@example.com
```

This command get a artifact signing account by name.

### Example 2: List Artifact signing Accounts In A Resource Group
```powershell
Get-AzArtifactSigningAccount -ResourceGroupName rg-test
```

```output
AccountUri                         Id                                                                                                                                     Location Name    ProvisioningState ResourceGroupName RetryAfter SkuName SystemDataCreatedAt  SystemDataCreatedBy
----------                         --                                                                                                                                     -------- ----    ----------------- ----------------- ---------- ------- -------------------  -------------------
https://eus.codesigning.azure.net/ /subscriptions/66dc869d-771b-4f60-84c1-4964b5f4f5f2/resourceGroups/rg-test/providers/Microsoft.CodeSigning/codeSigningAccounts/test    eastus   test    Succeeded         rg-test                      Basic   1/24/2025 9:58:19 PM test@example.com
https://eus.codesigning.azure.net/ /subscriptions/66dc869d-771b-4f60-84c1-4964b5f4f5f2/resourceGroups/rg-test/providers/Microsoft.CodeSigning/codeSigningAccounts/test2   eastus   test2   Succeeded         rg-test                      Basic   1/24/2025 9:58:19 PM test2@example.com
```

This command lists artifact signing accounts in a resource group

## PARAMETERS

### -AccountName
Artifact signing account name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ArtifactSigning.Models.IArtifactSigningIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List1
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
Type: System.String[]
Parameter Sets: List, Get, List1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ArtifactSigning.Models.IArtifactSigningIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ArtifactSigning.Models.ICodeSigningAccount

## NOTES

## RELATED LINKS
