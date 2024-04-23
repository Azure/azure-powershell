---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Synapse.dll-Help.xml
Module Name: Az.Synapse
online version: https://learn.microsoft.com/powershell/module/az.synapse/update-azsynapseworkspace
schema: 2.0.0
---

# Update-AzSynapseWorkspace

## SYNOPSIS
Updates a Synapse Analytics workspace.

## SYNTAX

### SetByNameParameterSet (Default)
```
Update-AzSynapseWorkspace [-ResourceGroupName <String>] -Name <String> [-Tag <Hashtable>]
 [-SqlAdministratorLoginPassword <SecureString>] [-ManagedVirtualNetwork <PSManagedVirtualNetworkSettings>]
 [-EncryptionKeyName <String>] [-UserAssignedIdentityInEncryption <String>]
 [-UseSystemAssignedIdentityInEncryption <Object>] [-GitRepository <PSWorkspaceRepositoryConfiguration>]
 [-UserAssignedIdentityAction <UserAssignedManagedIdentityActionType>]
 [-UserAssignedIdentityId <System.Collections.Generic.List`1[System.String]>]
 [-EnablePublicNetworkAccess <Boolean>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByInputObjectParameterSet
```
Update-AzSynapseWorkspace -InputObject <PSSynapseWorkspace> [-Tag <Hashtable>]
 [-SqlAdministratorLoginPassword <SecureString>] [-ManagedVirtualNetwork <PSManagedVirtualNetworkSettings>]
 [-EncryptionKeyName <String>] [-UserAssignedIdentityInEncryption <String>]
 [-UseSystemAssignedIdentityInEncryption <Object>] [-GitRepository <PSWorkspaceRepositoryConfiguration>]
 [-UserAssignedIdentityAction <UserAssignedManagedIdentityActionType>]
 [-UserAssignedIdentityId <System.Collections.Generic.List`1[System.String]>]
 [-EnablePublicNetworkAccess <Boolean>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByResourceIdParameterSet
```
Update-AzSynapseWorkspace -ResourceId <String> [-Tag <Hashtable>]
 [-SqlAdministratorLoginPassword <SecureString>] [-ManagedVirtualNetwork <PSManagedVirtualNetworkSettings>]
 [-EncryptionKeyName <String>] [-UserAssignedIdentityInEncryption <String>]
 [-UseSystemAssignedIdentityInEncryption <Object>] [-GitRepository <PSWorkspaceRepositoryConfiguration>]
 [-UserAssignedIdentityAction <UserAssignedManagedIdentityActionType>]
 [-UserAssignedIdentityId <System.Collections.Generic.List`1[System.String]>]
 [-EnablePublicNetworkAccess <Boolean>] [-AsJob] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzSynapseWorkspace** cmdlet updates an Azure Synapse Analytics workspace.

## EXAMPLES

### Example 1
```powershell
Update-AzSynapseWorkspace -Name ContosoWorkspace -Tag @{'key'='value'}
```

This commands updates tags for the specififed Azure Synapse Analytics workspace.

### Example 2
```powershell
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Update-AzSynapseWorkspace -Tag @{'key'='value1'}
```

This commands updates tags for the specififed Azure Synapse Analytics workspace through pipeline.

### Example 3
```powershell
Update-AzSynapseWorkspace -ResourceId /subscriptions/21686af7-58ec-4f4d-9c68-f431f4db4edd/resourceGroups/ContosoResourceGroup/providers/Microsoft.Synapse/workspaces/ContosoWorkspace -Tag @{'key'='value2'}
```

This commands updates tags for the specififed Azure Synapse Analytics workspace through pipeline with resource ID.

### Example 4
```powershell
$config = New-AzSynapseGitRepositoryConfig -RepositoryType GitHub -AccountName ContosoAccount -RepositoryName ContosoRepo -CollaborationBranch main
Update-AzSynapseWorkspace -Name ContosoWorkspace -GitRepository $config
```

This commands updates Git repository which workspace is conneceted to for the specififed Azure Synapse Analytics workspace.

### Example 5
```powershell
Update-AzSynapseWorkspace -Name ContosoWorkspace -EnablePublicNetworkAccess $True
```

This commands updates the specififed Azure Synapse Analytics workspace to enable public network access.

### Example 6
```powershell
$uamis = Get-AzUserAssignedIdentity -ResourceGroupName ContosoResourceGroup
$uamilist = New-Object System.Collections.Generic.List[string]
foreach($uami in $uamis){
	$uamilist.Add($uami.Id)
}

Update-AzSynapseWorkspace -Name ContosoWorkspace -UserAssignedIdentityAction Add -UserAssignedIdentityId $uamilist
```

This commands updates workspace to add user assigned managed identites in $uamilist.

### Example 7
```powershell
$uamis = Get-AzUserAssignedIdentity -ResourceGroupName ContosoResourceGroup
$uamilist = New-Object System.Collections.Generic.List[string]
foreach($uami in $uamis){
	$uamilist.Add($uami.Id)
}

Update-AzSynapseWorkspace -Name ContosoWorkspace -UserAssignedIdentityAction Remove -UserAssignedIdentityId $uamilist[0]
```

This commands removes user assigned managed identites $uamilist[0] from workspace.

### Example 8
```powershell
$uamis = Get-AzUserAssignedIdentity -ResourceGroupName ContosoResourceGroup
$uamilist = New-Object System.Collections.Generic.List[string]
foreach($uami in $uamis){
	$uamilist.Add($uami.Id)
}

Update-AzSynapseWorkspace -Name ContosoWorkspace -UserAssignedIdentityAction Set -UserAssignedIdentityId $uamilist
```

This commands updates workspace with user assigned managed identites $uamilist that will cover current identities.

### Example 9
```powershell
##Add a temp key to the workspace
New-AzSynapseWorkspaceKey -ResourceGroupName ContosoResourceGroup -WorkspaceName ContosoWorkspace -Name TempKey -EncryptionKeyIdentifier https://contosoKeyVault.vault.azure.net/keys/TempKey

##Update the workspace and set the temp key as the TDE protector
Update-AzSynapseWorkspace -WorkspaceName ContosoWorkspace -EncryptionKeyName TempKey -UseSystemAssignedIdentityInEncryption $true

##Note, we need to create a new key version for the original encrytion key of the Azure key vault before moving to next steps. 

##Update the workspace and set the encryption key back after we created a new key version. 
Update-AzSynapseWorkspace -WorkspaceName ContosoWorkspace -EncryptionKeyName default -UseSystemAssignedIdentityInEncryption $true

##Remove the temp key
Remove-AzSynapseWorkspaceKey -WorkspaceName ContosoWorkspace -Name TempKey
```

This commands demonstrate how to rotate the encryption key of a Synapse workspace, and it is using System Assigned Managed Identity to access the Azure Key Vault.

### Example 10
```powershell
$uamis = Get-AzUserAssignedIdentity -ResourceGroupName ContosoResourceGroup
$identityId = $uamis[0].Id
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws | Update-AzSynapseWorkspace -UseSystemAssignedIdentityInEncryption $false -UserAssignedIdentityInEncryption $identityId
$ws = Get-AzSynapseWorkspace -Name ContosoWorkspace
$ws.Encryption.CustomerManagedKeyDetails.Key
```

```output
Name    KeyVaultUrl
----    -----------
default https://contosoKeyValut.vault.azure.net/keys/testkey
```

```powershell
$ws = Get-AzSynapseWorkspace -name ContosoWorkspace
$ws.Encryption.CustomerManagedKeyDetails.KekIdentity
```

```output
UserAssignedIdentity                                                                                                                                        UseSystemAssignedIdentity
--------------------                                                                                                                                        -------------------------
/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourcegroups/ContosoResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/uaminame                     False
```

This commands updates workspace Encryption Managed Identity as User Assigned and specify an user assigned identity Id to access your customer-managed key stored in key vault. After updating, we can call `Get-AzSynapseWorkspace` to get Encryption properties of workspace.

## PARAMETERS

### -AsJob
Run cmdlet in the background

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

### -EnablePublicNetworkAccess
Enable or Disable public network access to workspace. Possible values include: 'Enabled', 'Disabled'

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EncryptionKeyName
The workspace encryption key name.

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

### -GitRepository
Git Repository Settings. Connect workspace to the repository for source control and collaboration for work on your workspace pipelines

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSWorkspaceRepositoryConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
workspace input object, usually passed through the pipeline.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace
Parameter Sets: SetByInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ManagedVirtualNetwork
Managed Virtual Network Settings.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.PSManagedVirtualNetworkSettings
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: SetByNameParameterSet
Aliases: WorkspaceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
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

### -ResourceGroupName
Resource group name.

```yaml
Type: System.String
Parameter Sets: SetByNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
Resource identifier of Synapse workspace.

```yaml
Type: System.String
Parameter Sets: SetByResourceIdParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SqlAdministratorLoginPassword
The new SQL administrator password for the workspace.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
A string,string dictionary of tags associated with the resource.

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

### -UserAssignedIdentityAction
Action must be specified when you add/remove/set user assigned managed identities for workspace. 
The supported actions are:
Add
Remove
Set
Add means to add user assigned managed identities for workspace, Remove means to remove user assigned managed identities from workspace, Set can be used when you want to add and remove user assigned managed identities at the same time.

```yaml
Type: Microsoft.Azure.Commands.Synapse.Models.SynapseConstants+UserAssignedManagedIdentityActionType
Parameter Sets: (All)
Aliases:
Accepted values: Add, Remove, Set

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityId
User assigned managed identity Id for workspace.

```yaml
Type: System.Collections.Generic.List`1[System.String]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentityInEncryption
User assigned identity resource Id used in Workspace Encryption

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

### -UseSystemAssignedIdentityInEncryption
specifying whether to use system assigned identity in Workspace Encryption or not

```yaml
Type: System.Object
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

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace

## OUTPUTS

### Microsoft.Azure.Commands.Synapse.Models.PSSynapseWorkspace

## NOTES

## RELATED LINKS
