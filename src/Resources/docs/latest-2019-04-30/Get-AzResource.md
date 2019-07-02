---
external help file:
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azresource
schema: 2.0.0
---

# Get-AzResource

## SYNOPSIS
Gets a resource.

## SYNTAX

### Get1 (Default)
```
Get-AzResource -ResourceId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzResource -Name <String> -ParentResourcePath <String> -ProviderNamespace <String> -ResourceType <String>
 -SubscriptionId <String[]> [-ResourceGroupName <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByTagNameAndValue
```
Get-AzResource -SubscriptionId <String[]> -TagName <String> [-ResourceGroupName <String>] [-Expand <String>]
 [-Top <Int32>] [-TagValue <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetByTag
```
Get-AzResource -SubscriptionId <String[]> -Tag <Hashtable> [-ResourceGroupName <String>] [-Expand <String>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzResource -SubscriptionId <String[]> [-ResourceGroupName <String>] [-Expand <String>] [-Filter <String>]
 [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzResource -SubscriptionId <String[]> [-Expand <String>] [-Filter <String>] [-Top <Int32>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity1
```
Get-AzResource -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzResource -InputObject <IResourcesIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a resource.

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

### -Expand
The $expand query parameter.
You can expand createdTime and changedTime.
For example, to expand both properties, use $expand=changedTime,createdTime

```yaml
Type: System.String
Parameter Sets: GetByTagNameAndValue, GetByTag, List, List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Filter
The filter to apply on the operation.
The properties you can use for eq (equals) or ne (not equals) are: location, resourceType, name, resourceGroup, identity, identity/principalId, plan, plan/publisher, plan/product, plan/name, plan/version, and plan/promotionCode.
For example, to filter by a resource type, use: $filter=resourceType eq 'Microsoft.Network/virtualNetworks'  You can use substringof(value, property) in the filter.
The properties you can use for substring are: name and resourceGroup.
For example, to get all resources with 'demo' anywhere in the name, use: $filter=substringof('demo', name)  You can link more than one substringof together by adding and/or operators.
You can filter by tag names and values.
For example, to filter for a tag name and value, use $filter=tagName eq 'tag1' and tagValue eq 'Value1'  You can use some properties together when filtering.
The combinations you can use are: substringof and/or resourceType, plan and plan/publisher and plan/name, identity and identity/principalId.

```yaml
Type: System.String
Parameter Sets: List, List1
Aliases: ODataQuery

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity
Parameter Sets: GetViaIdentity1, GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
Dynamic: False
```

### -Name
The name of the resource to get.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ParentResourcePath
The parent resource identity.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ProviderNamespace
The namespace of the resource provider.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ResourceProviderNamespace

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceGroupName
The resource group with the resources to get.

```yaml
Type: System.String
Parameter Sets: Get, GetByTagNameAndValue, GetByTag, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceId
The fully qualified ID of the resource, including the resource name and resource type.
Use the format, /subscriptions/{guid}/resourceGroups/{resource-group-name}/{resource-provider-namespace}/{resource-type}/{resource-name}

```yaml
Type: System.String
Parameter Sets: Get1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -ResourceType
The resource type of the resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, GetByTagNameAndValue, GetByTag, List, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Tag
The tag hashtable to filter resources by.
The single key-value pair should be the tag name and value, respectively, to filter by.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: GetByTag
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TagName
The tag name to filter resources by.

```yaml
Type: System.String
Parameter Sets: GetByTagNameAndValue
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -TagValue
The tag value to filter resources by.

```yaml
Type: System.String
Parameter Sets: GetByTagNameAndValue
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### -Top
The number of results to return.
If null is passed, returns all resources.

```yaml
Type: System.Int32
Parameter Sets: GetByTagNameAndValue, GetByTag, List, List1
Aliases:

Required: False
Position: Named
Default value: 0
Accept pipeline input: False
Accept wildcard characters: False
Dynamic: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.IResourcesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IGenericResource

## ALIASES

## RELATED LINKS

