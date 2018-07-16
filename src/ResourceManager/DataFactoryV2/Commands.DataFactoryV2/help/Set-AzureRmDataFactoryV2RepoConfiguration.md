---
external help file: Microsoft.Azure.Commands.DataFactoryV2.dll-Help.xml
Module Name: AzureRM.DataFactoryV2
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.datafactories/set-AzureRmDataFactoryV2RepoConfiguration
schema: 2.0.0
---

# Set-AzureRmDataFactoryV2RepoConfiguration

## SYNOPSIS
Sets the repository configuration for a data factory.

## SYNTAX

### ByFactoryNameByVSTS (Default)
```
Set-AzureRmDataFactoryV2RepoConfiguration -ResourceGroupName <String> -DataFactoryName <String>
 -Location <String> [-Force] -RepositoryAccountName <String> -RepositoryName <String>
 -RepositoryCollaborationBranch <String> -RepositoryRootFolder <String> [-RepositoryLastCommitId <String>]
 -VSTSProjectName <String> [-VSTSTenantId <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### ByFactoryNameByGitHub
```
Set-AzureRmDataFactoryV2RepoConfiguration -ResourceGroupName <String> -DataFactoryName <String>
 -Location <String> [-Force] -RepositoryAccountName <String> -RepositoryName <String>
 -RepositoryCollaborationBranch <String> -RepositoryRootFolder <String> [-RepositoryLastCommitId <String>]
 [-GitHubConfig] [-GitHubHostName <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ByResourceIdByVSTS
```
Set-AzureRmDataFactoryV2RepoConfiguration -Location <String> -ResourceId <String> [-Force]
 -RepositoryAccountName <String> -RepositoryName <String> -RepositoryCollaborationBranch <String>
 -RepositoryRootFolder <String> [-RepositoryLastCommitId <String>] -VSTSProjectName <String>
 [-VSTSTenantId <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByResourceIdByGitHub
```
Set-AzureRmDataFactoryV2RepoConfiguration -Location <String> -ResourceId <String> [-Force]
 -RepositoryAccountName <String> -RepositoryName <String> -RepositoryCollaborationBranch <String>
 -RepositoryRootFolder <String> [-RepositoryLastCommitId <String>] [-GitHubConfig] [-GitHubHostName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByFactoryObjectByVSTS
```
Set-AzureRmDataFactoryV2RepoConfiguration -InputObject <PSDataFactory> [-Force] -RepositoryAccountName <String>
 -RepositoryName <String> -RepositoryCollaborationBranch <String> -RepositoryRootFolder <String>
 [-RepositoryLastCommitId <String>] -VSTSProjectName <String> [-VSTSTenantId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ByFactoryObjectByGitHub
```
Set-AzureRmDataFactoryV2RepoConfiguration -InputObject <PSDataFactory> [-Force] -RepositoryAccountName <String>
 -RepositoryName <String> -RepositoryCollaborationBranch <String> -RepositoryRootFolder <String>
 [-RepositoryLastCommitId <String>] [-GitHubConfig] [-GitHubHostName <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmDataFactoryV2RepoConfiguration** cmdlet sets the repository configuration for a data factory with the specified parameters. This cmdlet requires for the user to have a permission to perform 'Microsoft.DataFactory/locations/configureFactoryRepo' operation.

## EXAMPLES

### Example 1: Set a GitHub repository on a factory
```
PS C:\> Set-AzureRmDataFactoryV2RepoConfiguration -ResourceId "/subscriptions/3e8e61b5-9a7d-4952-bfae-545ab997b9ea/resourceGroups/adf/providers/Microsoft.DataFactory/factories/wikiadf"
        -Location "EastUS" -RepositoryName "MyRepo" -RepositoryCollaborationBranch "MyBranch" -RepositoryRootFolder "MyRootFolder" 
        -RepositoryLastCommitId "123456abcd" -GitHubConfig

    DataFactoryName   : WikiADF
    DataFactoryId     : /subscriptions/3e8e61b5-9a7d-4952-bfae-545ab997b9ea/resourceGroups/adf/providers/Microsoft.DataFactory/factories/wikiadf
    ResourceGroupName : ADF
    Location          : EastUS
    Tags              : {}
    Identity          : Microsoft.Azure.Management.DataFactory.Models.FactoryIdentity
    ProvisioningState : Succeeded
    RepoConfiguration : Microsoft.Azure.Management.DataFactory.Models.FactoryRepoConfiguration
```

This command sets the repository of the WikiADF factory using specified properties pointing to github.com.

### Example 2: Set a VSTS repository on a factory
```
PS C:\> Set-AzureRmDataFactoryV2RepoConfiguration -ResourceId "/subscriptions/3e8e61b5-9a7d-4952-bfae-545ab997b9ea/resourceGroups/adf/providers/Microsoft.DataFactory/factories/wikiadf"
        -Location "WestUS"  -RepositoryAccountName "MyRepoAccount" 
        -RepositoryName "MyRepo" -RepositoryCollaborationBranch "MyBranch" -RepositoryRootFolder "MyRootFolder" 
        -RepositoryLastCommitId "123456abcd" -VSTSProjectName "MyProject"

    DataFactoryName   : WikiADF
    DataFactoryId     : /subscriptions/3e8e61b5-9a7d-4952-bfae-545ab997b9ea/resourceGroups/adf/providers/Microsoft.DataFactory/factories/wikiadf
    ResourceGroupName : ADF
    Location          : EastUS
    Tags              : {}
    Identity          : Microsoft.Azure.Management.DataFactory.Models.FactoryIdentity
    ProvisioningState : Succeeded
    RepoConfiguration : Microsoft.Azure.Management.DataFactory.Models.FactoryRepoConfiguration
```

This command sets the repository of the WikiADF factory using specified properties pointing to VSTS.

## PARAMETERS

### -DataFactoryName
The data factory name.

```yaml
Type: String
Parameter Sets: ByFactoryNameByVSTS, ByFactoryNameByGitHub
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Runs the cmdlet without prompting for confirmation.

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

### -GitHubConfig
The repo configuration is for GitHub.

```yaml
Type: SwitchParameter
Parameter Sets: ByFactoryNameByGitHub, ByResourceIdByGitHub, ByFactoryObjectByGitHub
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GitHubHostName
GitHub repo host name.

```yaml
Type: String
Parameter Sets: ByFactoryNameByGitHub, ByResourceIdByGitHub, ByFactoryObjectByGitHub
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
The data factory object.

```yaml
Type: PSDataFactory
Parameter Sets: ByFactoryObjectByVSTS, ByFactoryObjectByGitHub
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
The geographic region of the data factory.

```yaml
Type: String
Parameter Sets: ByFactoryNameByVSTS, ByFactoryNameByGitHub, ByResourceIdByVSTS, ByResourceIdByGitHub
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -RepositoryAccountName
The account name associated with the repository.

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

### -RepositoryCollaborationBranch
The collaboration branch on the repository.

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

### -RepositoryLastCommitId
The ID of the last commit.

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

### -RepositoryName
The name of the repository.

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

### -RepositoryRootFolder
The root folder of the repository.

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

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: ByFactoryNameByVSTS, ByFactoryNameByGitHub
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The geographic region of the data factory.

```yaml
Type: String
Parameter Sets: ByResourceIdByVSTS, ByResourceIdByGitHub
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -VSTSProjectName
VSTS project name.

```yaml
Type: String
Parameter Sets: ByFactoryNameByVSTS, ByResourceIdByVSTS, ByFactoryObjectByVSTS
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VSTSTenantId
VSTS tenant ID.

```yaml
Type: String
Parameter Sets: ByFactoryNameByVSTS, ByResourceIdByVSTS, ByFactoryObjectByVSTS
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
Shows what happens if the cmdlet runs, but doesn't run the cmdlet.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String
System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.DataFactoryV2.Models.PSDataFactory

## NOTES
Keywords: azure, azurerm, arm, resource, management, manager, data, factories

## RELATED LINKS

[Get-AzureRmDataFactoryV2]()

[Set-AzureRmDataFactoryV2]()
