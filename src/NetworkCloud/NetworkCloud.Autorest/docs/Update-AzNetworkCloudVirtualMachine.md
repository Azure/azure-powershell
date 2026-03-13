---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/update-aznetworkcloudvirtualmachine
schema: 2.0.0
---

# Update-AzNetworkCloudVirtualMachine

## SYNOPSIS
Reimage the provided virtual machine.

## SYNTAX

### Reimage1 (Default)
```
Update-AzNetworkCloudVirtualMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ReimageViaIdentity1
```
Update-AzNetworkCloudVirtualMachine -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded
```
Update-AzNetworkCloudVirtualMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-Tag <Hashtable>]
 [-VMImageRepositoryCredentialsPassword <SecureString>] [-VMImageRepositoryCredentialsRegistryUrl <String>]
 [-VMImageRepositoryCredentialsUsername <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateExpanded1
```
Update-AzNetworkCloudVirtualMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-IfMatch <String>] [-IfNoneMatch <String>] [-IdentityType <String>] [-Tag <Hashtable>]
 [-UserAssignedIdentity <String[]>] [-VMImageRepositoryCredentialsPassword <SecureString>]
 [-VMImageRepositoryCredentialsRegistryUrl <String>] [-VMImageRepositoryCredentialsUsername <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkCloudVirtualMachine -InputObject <INetworkCloudIdentity> [-IfMatch <String>]
 [-IfNoneMatch <String>] [-Tag <Hashtable>] [-VMImageRepositoryCredentialsPassword <SecureString>]
 [-VMImageRepositoryCredentialsRegistryUrl <String>] [-VMImageRepositoryCredentialsUsername <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded1
```
Update-AzNetworkCloudVirtualMachine -InputObject <INetworkCloudIdentity> [-IfMatch <String>]
 [-IfNoneMatch <String>] [-IdentityType <String>] [-Tag <Hashtable>] [-UserAssignedIdentity <String[]>]
 [-VMImageRepositoryCredentialsPassword <SecureString>] [-VMImageRepositoryCredentialsRegistryUrl <String>]
 [-VMImageRepositoryCredentialsUsername <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzNetworkCloudVirtualMachine -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonFilePath1
```
Update-AzNetworkCloudVirtualMachine -Name <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzNetworkCloudVirtualMachine -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaJsonString1
```
Update-AzNetworkCloudVirtualMachine -Name <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-IfMatch <String>] [-IfNoneMatch <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Reimage the provided virtual machine.

## EXAMPLES

### Example 1: Update virtual machine
```powershell
$tagUpdatedHash = @{
    tag1 = "tag1"
    tag2 = "tag1Update"
}
$registryPassword = ConvertTo-SecureString "password" -asplaintext -force

Update-AzNetworkCloudVirtualMachine -Name vmName -ResourceGroupName resourceGroup -Tag $tagUpdatedHash -VMImageRepositoryCredentialsRegistryUrl registryUrl -VMImageRepositoryCredentialsUsername registryUsername -VMImageRepositoryCredentialsPassword $registryPassword
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataL
                                                                                                                                                  astModified
                                                                                                                                                  ByType
-------- ----    ------------------- -------------------    ----------------------- ------------------------ ------------------------             -----------
eastus   default 07/07/2023 21:29:03 <user>                 User                    07/07/2023 21:32:41      <identity>                           Application
```

This command updates properties of a virtual machine.

## PARAMETERS

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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: System.String
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfMatch
The ETag of the transformation.
Omit this value to always overwrite the current resource.
Specify the last-seen ETag value to prevent accidentally overwriting concurrent changes.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1, UpdateViaJsonFilePath, UpdateViaJsonFilePath1, UpdateViaJsonString, UpdateViaJsonString1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IfNoneMatch
Set to '*' to allow a new record set to be created, but to prevent updating an existing resource.
Other values will result in error from server as they are not supported.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1, UpdateViaJsonFilePath, UpdateViaJsonFilePath1, UpdateViaJsonString, UpdateViaJsonString1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: ReimageViaIdentity1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath, UpdateViaJsonFilePath1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString, UpdateViaJsonString1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: Reimage1, UpdateExpanded, UpdateExpanded1, UpdateViaJsonFilePath, UpdateViaJsonFilePath1, UpdateViaJsonString, UpdateViaJsonString1
Aliases: VirtualMachineName

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

### -PassThru
Returns true when the command succeeds

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Reimage1, ReimageViaIdentity1
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
Parameter Sets: Reimage1, UpdateExpanded, UpdateExpanded1, UpdateViaJsonFilePath, UpdateViaJsonFilePath1, UpdateViaJsonString, UpdateViaJsonString1
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
Type: System.String
Parameter Sets: Reimage1, UpdateExpanded, UpdateExpanded1, UpdateViaJsonFilePath, UpdateViaJsonFilePath1, UpdateViaJsonString, UpdateViaJsonString1
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
The Azure resource tags that will replace the existing ones.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserAssignedIdentity
The array of user assigned identities associated with the resource.
The elements in array will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.'

```yaml
Type: System.String[]
Parameter Sets: UpdateExpanded1, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMImageRepositoryCredentialsPassword
The password or token used to access an image in the target repository.

```yaml
Type: System.Security.SecureString
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMImageRepositoryCredentialsRegistryUrl
The URL of the authentication server used to validate the repository credentials.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VMImageRepositoryCredentialsUsername
The username used to access an image in the target repository.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateExpanded1, UpdateViaIdentityExpanded, UpdateViaIdentityExpanded1
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IVirtualMachine

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IVirtualMachineAutoGenerated

### System.Boolean

## NOTES

## RELATED LINKS

