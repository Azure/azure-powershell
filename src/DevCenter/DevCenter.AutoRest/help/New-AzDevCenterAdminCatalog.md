---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/new-azdevcenteradmincatalog
schema: 2.0.0
---

# New-AzDevCenterAdminCatalog

## SYNOPSIS
Creates or updates a catalog.

## SYNTAX

### CreateExpandedAdo (Default)
```
New-AzDevCenterAdminCatalog -DevCenterName <String> -Name <String> -ResourceGroupName <String>
 -AdoGitSecretIdentifier <String> -AdoGitUri <String> [-SubscriptionId <String>] [-AdoGitBranch <String>]
 [-AdoGitPath <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateExpandedGitHub
```
New-AzDevCenterAdminCatalog -DevCenterName <String> -Name <String> -ResourceGroupName <String>
 -GitHubSecretIdentifier <String> -GitHubUri <String> [-SubscriptionId <String>] [-GitHubBranch <String>]
 [-GitHubPath <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### CreateViaIdentityExpandedAdo
```
New-AzDevCenterAdminCatalog -InputObject <IDevCenterIdentity> -AdoGitSecretIdentifier <String>
 -AdoGitUri <String> [-AdoGitBranch <String>] [-AdoGitPath <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpandedGitHub
```
New-AzDevCenterAdminCatalog -InputObject <IDevCenterIdentity> -GitHubSecretIdentifier <String>
 -GitHubUri <String> [-GitHubBranch <String>] [-GitHubPath <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a catalog.

## EXAMPLES

### Example 1: Create an Azure Dev Ops catalog
```powershell
New-AzDevCenterAdminCatalog -DevCenterName Contoso -Name CentralCatalog -ResourceGroupName testRg -AdoGitBranch main -AdoGitPath "/templates" -AdoGitSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -AdoGitUri "https://contoso@dev.azure.com/contoso/contosoOrg/_git/centralrepo-fakecontoso"
```

Create an Azure Dev Ops catalog named "CentralCatalog" in the dev center "Contoso".

### Example 2: Create a GitHub catalog
```powershell
New-AzDevCenterAdminCatalog -DevCenterName Contoso -Name CentralCatalog -ResourceGroupName testRg -GitHubBranch main -GitHubPath "/templates" -GitHubSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -GitHubUri "https://github.com/Contoso/centralrepo-fake.git"
```

This command creates a GitHub catalog named "CentralCatalog" in the dev center "Contoso".

### Example 3: Create an Azure Dev Ops catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminCatalog -InputObject $catalog -AdoGitBranch main -AdoGitPath "/templates" -AdoGitSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -AdoGitUri "https://contoso@dev.azure.com/contoso/contosoOrg/_git/centralrepo-fakecontoso"
```

This command creates an Azure Dev Ops catalog named "CentralCatalog" in the dev center "Contoso".

### Example 4: Create a Github catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "DevCenterName" = "Contoso"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminCatalog -InputObject $catalog -GitHubBranch main -GitHubPath "/templates" -GitHubSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -GitHubUri "https://github.com/Contoso/centralrepo-fake.git"
```

This command creates a GitHub catalog named "CentralCatalog" in the dev center "Contoso".

## PARAMETERS

### -AdoGitBranch
Git branch.

```yaml
Type: System.String
Parameter Sets: CreateExpandedAdo, CreateViaIdentityExpandedAdo
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdoGitPath
The folder where the catalog items can be found inside the repository.

```yaml
Type: System.String
Parameter Sets: CreateExpandedAdo, CreateViaIdentityExpandedAdo
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdoGitSecretIdentifier
A reference to the Key Vault secret containing a security token to authenticate to a Git repository.

```yaml
Type: System.String
Parameter Sets: CreateExpandedAdo, CreateViaIdentityExpandedAdo
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AdoGitUri
Git URI.

```yaml
Type: System.String
Parameter Sets: CreateExpandedAdo, CreateViaIdentityExpandedAdo
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -DevCenterName
The name of the devcenter.

```yaml
Type: System.String
Parameter Sets: CreateExpandedAdo, CreateExpandedGitHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitHubBranch
Git branch.

```yaml
Type: System.String
Parameter Sets: CreateExpandedGitHub, CreateViaIdentityExpandedGitHub
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitHubPath
The folder where the catalog items can be found inside the repository.

```yaml
Type: System.String
Parameter Sets: CreateExpandedGitHub, CreateViaIdentityExpandedGitHub
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitHubSecretIdentifier
A reference to the Key Vault secret containing a security token to authenticate to a Git repository.

```yaml
Type: System.String
Parameter Sets: CreateExpandedGitHub, CreateViaIdentityExpandedGitHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitHubUri
Git URI.

```yaml
Type: System.String
Parameter Sets: CreateExpandedGitHub, CreateViaIdentityExpandedGitHub
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity
Parameter Sets: CreateViaIdentityExpandedAdo, CreateViaIdentityExpandedGitHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Catalog.

```yaml
Type: System.String
Parameter Sets: CreateExpandedAdo, CreateExpandedGitHub
Aliases: CatalogName

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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: CreateExpandedAdo, CreateExpandedGitHub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpandedAdo, CreateExpandedGitHub
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20231001Preview.ICatalog

## NOTES

## RELATED LINKS

