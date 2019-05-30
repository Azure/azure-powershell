---
external help file:
Module Name: Az.WebSite
online version: https://docs.microsoft.com/en-us/powershell/module/az.website/test-azwebsite
schema: 2.0.0
---

# Test-AzWebSite

## SYNOPSIS
Validate if a resource can be created.

## SYNTAX

### Validate1 (Default)
```
Test-AzWebSite -ResourceGroupName <String> -SubscriptionId <String> [-ValidateRequest <IValidateRequest>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateExpanded1
```
Test-AzWebSite -ResourceGroupName <String> -SubscriptionId <String> -Location <String> -Name <String>
 -Type <ValidateResourceTypes> [-Capacity <Int32>] [-HostingEnvironment <String>] [-IsSpot] [-NeedLinuxWorker]
 [-ServerFarmId <String>] [-SkuName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### ValidateViaIdentityExpanded1
```
Test-AzWebSite -InputObject <IWebSiteIdentity> -Location <String> -Name <String> -Type <ValidateResourceTypes>
 [-Capacity <Int32>] [-HostingEnvironment <String>] [-IsSpot] [-NeedLinuxWorker] [-ServerFarmId <String>]
 [-SkuName <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### ValidateViaIdentity1
```
Test-AzWebSite -InputObject <IWebSiteIdentity> [-ValidateRequest <IValidateRequest>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Validate if a resource can be created.

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

### -Capacity
Target capacity of the App Service plan (number of VMs).

```yaml
Type: System.Int32
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
```

### -HostingEnvironment
Name of App Service Environment where app or App Service plan should be created.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity
Parameter Sets: ValidateViaIdentityExpanded1, ValidateViaIdentity1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -IsSpot
<code>true</code> if App Service plan is for Spot instances; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Location
Expected location of the resource.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Name
Resource name to verify.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -NeedLinuxWorker
<code>true</code> if App Service plan is for Linux workers; otherwise, <code>false</code>.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
Name of the resource group to which the resource belongs.

```yaml
Type: System.String
Parameter Sets: Validate1, ValidateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ServerFarmId
ARM resource ID of an App Service plan that would host the app.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SkuName
Name of the target SKU for the App Service plan.

```yaml
Type: System.String
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
Your Azure subscription ID.
This is a GUID-formatted string (e.g.
00000000-0000-0000-0000-000000000000).

```yaml
Type: System.String
Parameter Sets: Validate1, ValidateExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Type
Resource type used for verification.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Support.ValidateResourceTypes
Parameter Sets: ValidateExpanded1, ValidateViaIdentityExpanded1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ValidateRequest
Resource validation request content.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160301.IValidateRequest
Parameter Sets: Validate1, ValidateViaIdentity1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
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
Dynamic: False
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
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160301.IValidateRequest

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.IWebSiteIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.WebSite.Models.Api20160301.IValidateResponse

## ALIASES

## RELATED LINKS

