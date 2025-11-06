---
external help file: Az.Portal-help.xml
Module Name: Az.Portal
online version: https://learn.microsoft.com/powershell/module/az.portal/new-azportaldashboard
schema: 2.0.0
---

# New-AzPortalDashboard

## SYNOPSIS
create a Dashboard.

## SYNTAX

### CreateExpanded (Default)
```
New-AzPortalDashboard -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] -Location <String>
 [-Lens <IDashboardLens[]>] [-Metadata <Hashtable>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### Create
```
New-AzPortalDashboard -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -Resource <IDashboard> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzPortalDashboard -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonFilePath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzPortalDashboard -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -JsonString <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### CreateByFile
```
New-AzPortalDashboard -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -DashboardPath <String> [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
create a Dashboard.

## EXAMPLES

### Example 1: Create a dashboard using a dashboard template file
```powershell
New-AzPortalDashboard -DashboardPath .\resources\dash1.json -ResourceGroupName mydash-rg -DashboardName my-dashboard03
```

```output
Location Name           Type
-------- ----           ----
eastasia my-dashboard03 Microsoft.Portal/dashboards
```

Create a new dashboard using the provided dashboard template file.

### Example 2: Workaround for dashboard creation issues using Invoke-AzRestMethod
```powershell
$SubscriptionId = (Get-AzContext).Subscription.Id
$ResourceGroupName = 'mydash-rg'
$DashboardName = 'my-dashboard03'
$DashboardPath = ".\resources\dash1.json"
$Location = "East US"
$ApiVersion = "2022-12-01-preview"
$Dashboard = Get-Content -Path $DashboardPath -Raw | ConvertFrom-Json
$Payload = @{
    properties = $Dashboard.properties
    location = $Location
} | ConvertTo-Json -Depth 10
Invoke-AzRestMethod -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName -ResourceProviderName "Microsoft.Portal" -ResourceType "dashboards" -Name $DashboardName -ApiVersion $ApiVersion -Method PUT -Payload $Payload
```

```output
StatusCode        : 200
Content           : {"id":"/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/mydash-rg/providers/Microsoft.Portal/dashboards/my-dashboard03","name":"my-dashboard03","type":"Microsoft.Portal/dashboards","location":"East US","properties":{...}}
Headers           : {[Content-Length, 1234], [Content-Type, application/json; charset=utf-8], [Date, Wed, 01 Jan 2025 00:00:00 GMT]}
```

Use this workaround when `New-AzPortalDashboard` succeeds but the dashboard fails to render with "Dashboard not found" error. This issue is with the underlying REST API and this method provides a reliable alternative.

## PARAMETERS

### -DashboardPath
The Path to an existing dashboard template.
Dashboard templates may be downloaded from the portal.

```yaml
Type: System.String
Parameter Sets: CreateByFile
Aliases:

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

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Lens
The dashboard lenses.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.IDashboardLens[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Metadata
The dashboard metadata.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the dashboard.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: DashboardName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
The shared dashboard resource definition.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.IDashboard
Parameter Sets: Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.IDashboard

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Portal.Models.IDashboard

## NOTES

## RELATED LINKS
