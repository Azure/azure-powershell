---
external help file:
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/test-azstorageblobaccesspointconnection
schema: 2.0.0
---

# Test-AzStorageBlobAccessPointConnection

## SYNOPSIS
Test a proposed Blob Access Point connection before the configuration is created.
The connection is validated in the context of the storage account in the request path, so no Blob Access Point configuration needs to exist beforehand.

## SYNTAX

### TestExpanded (Default)
```
Test-AzStorageBlobAccessPointConnection -AccountName <String> -ResourceGroupName <String> -SourceType <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### Test
```
Test-AzStorageBlobAccessPointConnection -AccountName <String> -ResourceGroupName <String>
 -Body <IBlobAccessPointProposedConnectionTestRequest> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaIdentity
```
Test-AzStorageBlobAccessPointConnection -InputObject <IStorageIdentity>
 -Body <IBlobAccessPointProposedConnectionTestRequest> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaIdentityExpanded
```
Test-AzStorageBlobAccessPointConnection -InputObject <IStorageIdentity> -SourceType <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### TestViaJsonFilePath
```
Test-AzStorageBlobAccessPointConnection -AccountName <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### TestViaJsonString
```
Test-AzStorageBlobAccessPointConnection -AccountName <String> -ResourceGroupName <String> -JsonString <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Test a proposed Blob Access Point connection before the configuration is created.
The connection is validated in the context of the storage account in the request path, so no Blob Access Point configuration needs to exist beforehand.

## EXAMPLES

### Example 1: Test a proposed source connection
```powershell
Test-AzStorageBlobAccessPointConnection -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount" -JsonFilePath "./proposed-connection.json"
```

Tests a proposed connection without creating a stored configuration.
The JSON file contains a top-level source object with sourceType, connection, and auth properties.
Protect the file if it contains credentials and remove it when no longer needed.

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

### -Body
The request used to test a proposed Blob Access Point configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IBlobAccessPointProposedConnectionTestRequest
Parameter Sets: Test, TestViaIdentity
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

### -SourceType
The source type.
This value determines the remaining shape of the source object.

```yaml
Type: System.String
Parameter Sets: TestExpanded, TestViaIdentityExpanded
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
Parameter Sets: Test, TestExpanded, TestViaJsonFilePath, TestViaJsonString
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IBlobAccessPointProposedConnectionTestRequest

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IStorageIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IBlobAccessPointConnectionTestResponse

## NOTES

## RELATED LINKS
