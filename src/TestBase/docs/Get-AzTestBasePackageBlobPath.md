---
external help file:
Module Name: Az.TestBase
online version: https://docs.microsoft.com/powershell/module/az.testbase/get-aztestbasepackageblobpath
schema: 2.0.0
---

# Get-AzTestBasePackageBlobPath

## SYNOPSIS
Gets the file upload URL of a Test Base Account.

## SYNTAX

### GetExpanded (Default)
```
Get-AzTestBasePackageBlobPath -AccountName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-BlobName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Get
```
Get-AzTestBasePackageBlobPath -AccountName <String> -ResourceGroupName <String>
 -Parameter <IGetFileUploadUrlParameters> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzTestBasePackageBlobPath -InputObject <ITestBaseIdentity> -Parameter <IGetFileUploadUrlParameters>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### GetViaIdentityExpanded
```
Get-AzTestBasePackageBlobPath -InputObject <ITestBaseIdentity> [-BlobName <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Gets the file upload URL of a Test Base Account.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AccountName
The resource name of the Test Base Account.

```yaml
Type: System.String
Parameter Sets: Get, GetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobName
The custom file name of the uploaded blob.

```yaml
Type: System.String
Parameter Sets: GetExpanded, GetViaIdentityExpanded
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
Type: Microsoft.Azure.PowerShell.Cmdlets.TestBase.Models.ITestBaseIdentity
Parameter Sets: GetViaIdentity, GetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Parameter
The parameters supplied to the Test Base Account GetFileUploadURL action.
To construct, see NOTES section for PARAMETER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.TestBase.Models.Api20201216Preview.IGetFileUploadUrlParameters
Parameter Sets: Get, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.

```yaml
Type: System.String
Parameter Sets: Get, GetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.
This is a GUID-formatted string.

```yaml
Type: System.String[]
Parameter Sets: Get, GetExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.TestBase.Models.Api20201216Preview.IGetFileUploadUrlParameters

### Microsoft.Azure.PowerShell.Cmdlets.TestBase.Models.ITestBaseIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.TestBase.Models.Api20201216Preview.IFileUploadUrlResponse

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <ITestBaseIdentity>: Identity Parameter
  - `[AnalysisResultName <AnalysisResultName?>]`: The name of the Analysis Result of a Test Result.
  - `[AvailableOSResourceName <String>]`: The resource name of an Available OS.
  - `[CustomerEventName <String>]`: The resource name of the Test Base Customer event.
  - `[EmailEventResourceName <String>]`: The resource name of an email event.
  - `[FavoriteProcessResourceName <String>]`: The resource name of a favorite process in a package. If the process name contains characters that are not allowed in Azure Resource Name, we use 'actualProcessName' in request body to submit the name.
  - `[FlightingRingResourceName <String>]`: The resource name of a flighting ring.
  - `[Id <String>]`: Resource identity path
  - `[OSUpdateResourceName <String>]`: The resource name of an OS Update.
  - `[PackageName <String>]`: The resource name of the Test Base Package.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource.
  - `[SubscriptionId <String>]`: The Azure subscription ID. This is a GUID-formatted string.
  - `[TestBaseAccountName <String>]`: The resource name of the Test Base Account.
  - `[TestResultName <String>]`: The Test Result Name. It equals to {osName}-{TestResultId} string.
  - `[TestSummaryName <String>]`: The name of the Test Summary.
  - `[TestTypeResourceName <String>]`: The resource name of a test type.

PARAMETER <IGetFileUploadUrlParameters>: The parameters supplied to the Test Base Account GetFileUploadURL action.
  - `[BlobName <String>]`: The custom file name of the uploaded blob.

## RELATED LINKS

