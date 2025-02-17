---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/update-aznetworkcloudvirtualmachine
schema: 2.0.0
---

# Update-AzNetworkCloudVirtualMachine

## SYNOPSIS
Patch the properties of the provided virtual machine, or update the tags associated with the virtual machine.
Properties and tag updates can be done independently.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzNetworkCloudVirtualMachine -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-VMImageRepositoryCredentialsPassword <SecureString>]
 [-VMImageRepositoryCredentialsRegistryUrl <String>] [-VMImageRepositoryCredentialsUsername <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzNetworkCloudVirtualMachine -InputObject <INetworkCloudIdentity> [-Tag <Hashtable>]
 [-VMImageRepositoryCredentialsPassword <SecureString>] [-VMImageRepositoryCredentialsRegistryUrl <String>]
 [-VMImageRepositoryCredentialsUsername <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Patch the properties of the provided virtual machine, or update the tags associated with the virtual machine.
Properties and tag updates can be done independently.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IVirtualMachine

## NOTES

## RELATED LINKS

