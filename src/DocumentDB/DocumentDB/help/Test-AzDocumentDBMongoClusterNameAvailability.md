---
external help file: Az.DocumentDB-help.xml
Module Name: Az.DocumentDB
online version: https://learn.microsoft.com/powershell/module/az.documentdb/test-azdocumentdbmongoclusternameavailability
schema: 2.0.0
---

# Test-AzDocumentDBMongoClusterNameAvailability

## SYNOPSIS
Check if mongo cluster name is available for use.

## SYNTAX

### CheckExpanded (Default)
```
Test-AzDocumentDBMongoClusterNameAvailability -Location <String> [-SubscriptionId <String>] [-Name <String>]
 [-Type <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CheckViaJsonString
```
Test-AzDocumentDBMongoClusterNameAvailability -Location <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CheckViaJsonFilePath
```
Test-AzDocumentDBMongoClusterNameAvailability -Location <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### Check
```
Test-AzDocumentDBMongoClusterNameAvailability -Location <String> [-SubscriptionId <String>]
 -Body <ICheckNameAvailabilityRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CheckViaIdentityExpanded
```
Test-AzDocumentDBMongoClusterNameAvailability -InputObject <IDocumentDbIdentity> [-Name <String>]
 [-Type <String>] [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CheckViaIdentity
```
Test-AzDocumentDBMongoClusterNameAvailability -InputObject <IDocumentDbIdentity>
 -Body <ICheckNameAvailabilityRequest> [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Check if mongo cluster name is available for use.

## EXAMPLES

### Example 1: Check the availability of a mongo cluster name
```powershell
Test-AzDocumentDBMongoClusterNameAvailability -Name myCluster -Location eastus2 -Type 'Microsoft.DocumentDB/mongoClusters'
```

```output
NameAvailable Reason Message
------------- ------ -------
         True
```

Check whether a mongo cluster name is available in a location before creating the
cluster.

## PARAMETERS

### -Body
The check availability request body.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICheckNameAvailabilityRequest
Parameter Sets: Check, CheckViaIdentity
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
Type: Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDocumentDbIdentity
Parameter Sets: CheckViaIdentityExpanded, CheckViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Check operation

```yaml
Type: System.String
Parameter Sets: CheckViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The name of the Azure region.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaJsonString, CheckViaJsonFilePath, Check
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the resource for which availability needs to be checked.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
Aliases:

Required: False
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
Parameter Sets: CheckExpanded, CheckViaJsonString, CheckViaJsonFilePath, Check
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
The resource type.

```yaml
Type: System.String
Parameter Sets: CheckExpanded, CheckViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICheckNameAvailabilityRequest

### Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IDocumentDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.ICheckNameAvailabilityResponse

## NOTES

## RELATED LINKS
