---
external help file:
Module Name: Az.DevCenter
online version: https://learn.microsoft.com/powershell/module/az.devcenter/new-azdevcenteradminprojectcatalog
schema: 2.0.0
---

# New-AzDevCenterAdminProjectCatalog

## SYNOPSIS
Creates or updates a project catalog.

## SYNTAX

### CreateExpandedAdo (Default)
```
New-AzDevCenterAdminProjectCatalog -CatalogName <String> -ProjectName <String> -ResourceGroupName <String>
 -AdoGitSecretIdentifier <String> -AdoGitUri <String> [-SubscriptionId <String>] [-AdoGitBranch <String>]
 [-AdoGitPath <String>] [-SyncType <CatalogSyncType>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateExpandedGitHub
```
New-AzDevCenterAdminProjectCatalog -CatalogName <String> -ProjectName <String> -ResourceGroupName <String>
 -GitHubSecretIdentifier <String> -GitHubUri <String> [-SubscriptionId <String>] [-GitHubBranch <String>]
 [-GitHubPath <String>] [-SyncType <CatalogSyncType>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpandedAdo
```
New-AzDevCenterAdminProjectCatalog -InputObject <IDevCenterIdentity> -AdoGitSecretIdentifier <String>
 -AdoGitUri <String> [-AdoGitBranch <String>] [-AdoGitPath <String>] [-SyncType <CatalogSyncType>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaIdentityExpandedGitHub
```
New-AzDevCenterAdminProjectCatalog -InputObject <IDevCenterIdentity> -GitHubSecretIdentifier <String>
 -GitHubUri <String> [-GitHubBranch <String>] [-GitHubPath <String>] [-SyncType <CatalogSyncType>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates a project catalog.

## EXAMPLES

### Example 1: Create an Azure Dev Ops project catalog
```powershell
New-AzDevCenterAdminProjectCatalog -ProjectName DevProject -Name CentralCatalog -ResourceGroupName testRg -AdoGitBranch main -AdoGitPath "/templates" -AdoGitSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -AdoGitUri "https://contoso@dev.azure.com/contoso/contosoOrg/_git/centralrepo-fakecontoso"
```

Create an Azure Dev Ops project catalog named "CentralCatalog" in the project "DevProject".

### Example 2: Create a GitHub project catalog
```powershell
New-AzDevCenterAdminProjectCatalog -ProjectName DevProject -Name CentralCatalog -ResourceGroupName testRg -GitHubBranch main -GitHubPath "/templates" -GitHubSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -GitHubUri "https://github.com/DevProject/centralrepo-fake.git"
```

This command creates a GitHub project catalog named "CentralCatalog" in the project "DevProject".

### Example 3: Create an Azure Dev Ops project catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminProjectCatalog -InputObject $catalog -AdoGitBranch main -AdoGitPath "/templates" -AdoGitSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -AdoGitUri "https://contoso@dev.azure.com/contoso/contosoOrg/_git/centralrepo-fakecontoso"
```

This command creates an Azure Dev Ops project catalog named "CentralCatalog" in the project "DevProject".

### Example 4: Create a Github project catalog using InputObject
```powershell
$catalog = @{"ResourceGroupName" = "testRg"; "ProjectName" = "DevProject"; "CatalogName" = "CentralCatalog"; "SubscriptionId" = "0ac520ee-14c0-480f-b6c9-0a90c58ffff"}
New-AzDevCenterAdminProjectCatalog -InputObject $catalog -GitHubBranch main -GitHubPath "/templates" -GitHubSecretIdentifier "https://contosokv.vault.azure.net/secrets/CentralRepoPat" -GitHubUri "https://github.com/DevProject/centralrepo-fake.git"
```

This command creates a GitHub project catalog named "CentralCatalog" in the project "DevProject".

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

### -CatalogName
The name of the Catalog.

```yaml
Type: System.String
Parameter Sets: CreateExpandedAdo, CreateExpandedGitHub
Aliases: Name

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

### -ProjectName
The name of the project.

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

### -SyncType
Indicates the type of sync that is configured for the catalog.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Support.CatalogSyncType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.IDevCenterIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DevCenter.Models.Api20240501Preview.ICatalog

## NOTES

## RELATED LINKS

