---
external help file:
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/test-azstorageblobaccesspointconfigurationconnection
schema: 2.0.0
---

# Test-AzStorageBlobAccessPointConfigurationConnection

## SYNOPSIS
Test the connection configured on an existing Blob Access Point configuration.

## SYNTAX

### TestExpanded (Default)
```
Test-AzStorageBlobAccessPointConfigurationConnection -AccountName <String>
 -BlobAccessPointConfigurationName <String> -ResourceGroupName <String> -UniqueId <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Test
```
Test-AzStorageBlobAccessPointConfigurationConnection -AccountName <String>
 -BlobAccessPointConfigurationName <String> -ResourceGroupName <String>
 -Body <IBlobAccessPointConnectionTestRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaIdentity
```
Test-AzStorageBlobAccessPointConfigurationConnection -InputObject <IStorageIdentity>
 -Body <IBlobAccessPointConnectionTestRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### TestViaIdentityExpanded
```
Test-AzStorageBlobAccessPointConfigurationConnection -InputObject <IStorageIdentity> -UniqueId <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaIdentityStorageAccount
```
Test-AzStorageBlobAccessPointConfigurationConnection -BlobAccessPointConfigurationName <String>
 -StorageAccountInputObject <IStorageIdentity> -Body <IBlobAccessPointConnectionTestRequest>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaIdentityStorageAccountExpanded
```
Test-AzStorageBlobAccessPointConfigurationConnection -BlobAccessPointConfigurationName <String>
 -StorageAccountInputObject <IStorageIdentity> -UniqueId <String> [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaJsonFilePath
```
Test-AzStorageBlobAccessPointConfigurationConnection -AccountName <String>
 -BlobAccessPointConfigurationName <String> -ResourceGroupName <String> -JsonFilePath <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### TestViaJsonString
```
Test-AzStorageBlobAccessPointConfigurationConnection -AccountName <String>
 -BlobAccessPointConfigurationName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Test the connection configured on an existing Blob Access Point configuration.

## EXAMPLES

### Example 1: Test a stored configuration
```powershell
$configuration = Get-AzStorageBlobAccessPointConfiguration -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount" -Name "myaccesspoint"
Test-AzStorageBlobAccessPointConfigurationConnection -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount" -BlobAccessPointConfigurationName $configuration.Name -UniqueId $configuration.UniqueId
```

Tests the connection using the stored configuration's current unique ID and returns connection-test details.

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: Test, TestExpanded, TestViaJsonFilePath, TestViaJsonString
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

### -BlobAccessPointConfigurationName
The name of the Blob Access Point configuration.

```yaml
Type: System.String
Parameter Sets: Test, TestExpanded, TestViaIdentityStorageAccount, TestViaIdentityStorageAccountExpanded, TestViaJsonFilePath, TestViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Body
The request used to test an existing Blob Access Point configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IBlobAccessPointConnectionTestRequest
Parameter Sets: Test, TestViaIdentity, TestViaIdentityStorageAccount
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: TestViaIdentity, TestViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Test operation

```yaml
Type: System.String
Parameter Sets: TestViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Test operation

```yaml
Type: System.String
Parameter Sets: TestViaJsonString
Aliases:

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
Parameter Sets: Test, TestExpanded, TestViaJsonFilePath, TestViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StorageAccountInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity
Parameter Sets: TestViaIdentityStorageAccount, TestViaIdentityStorageAccountExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: Test, TestExpanded, TestViaJsonFilePath, TestViaJsonString
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UniqueId
The system-generated unique identifier of the Blob Access Point configuration, as returned by a read operation.
This value must match the configuration named in the request path, and is required so that a configuration which was deleted and recreated under the same name is not tested by mistake.

```yaml
Type: System.String
Parameter Sets: TestExpanded, TestViaIdentityExpanded, TestViaIdentityStorageAccountExpanded
Aliases:

Required: True
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IBlobAccessPointConnectionTestRequest

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IBlobAccessPointConnectionTestResponse

## NOTES

## RELATED LINKS
