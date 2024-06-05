---
external help file:
Module Name: Az.Sphere
online version: https://learn.microsoft.com/powershell/module/az.sphere/get-azspheredeployment
schema: 2.0.0
---

# Get-AzSphereDeployment

## SYNOPSIS
Get a Deployment.
'.default' and '.unassigned' are system defined values and cannot be used for product or device group name.

## SYNTAX

### List (Default)
```
Get-AzSphereDeployment -CatalogName <String> -DeviceGroupName <String> -ProductName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Filter <String>] [-Maxpagesize <Int32>]
 [-Skip <Int32>] [-Top <Int32>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzSphereDeployment -CatalogName <String> -DeviceGroupName <String> -Name <String> -ProductName <String>
 -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSphereDeployment -InputObject <ISphereIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityCatalog
```
Get-AzSphereDeployment -CatalogInputObject <ISphereIdentity> -DeviceGroupName <String> -Name <String>
 -ProductName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityDeviceGroup
```
Get-AzSphereDeployment -DeviceGroupInputObject <ISphereIdentity> -Name <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityProduct
```
Get-AzSphereDeployment -DeviceGroupName <String> -Name <String> -ProductInputObject <ISphereIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a Deployment.
'.default' and '.unassigned' are system defined values and cannot be used for product or device group name.

## EXAMPLES

### Example 1: List by resource group
```powershell
Get-AzSphereDeployment -ResourceGroupName joyer-test -DeviceGroupName testdevicegroup -ProductName product2024 -CatalogName test2024
```

```output
Name                                 SystemDataCreatedAt  SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                 -------------------  ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
009ada36-7515-4ff0-a54c-33b75bfae976 2/28/2024 2:36:04 AM                                             2/28/2024 2:36:04 AM                                                           joyer-test
2e83ddd9-6297-48df-9c2c-2257e6b3cc71 2/28/2024 2:57:56 AM                                             2/28/2024 2:57:56 AM                                                           joyer-test
```

This command lists all deployments for specified device group.

### Example 2: Get specific deployment for device group
```powershell
Get-AzSphereDeployment -ResourceGroupName joyer-test -DeviceGroupName testdevicegroup -ProductName product2024 -CatalogName test2024 -Name 2e83ddd9-6297-48df-9c2c-2257e6b3cc71
```

```output
DateUtc                      : 2/28/2024 2:57:56 AM
DeployedImage                : {{
                                 "id": "/subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/images/a04f0a91-b369-4249-a47d-28c118e2cb3b",
                                 "name": "a04f0a91-b369-4249-a47d-28c118e2cb3b",
                                 "type": "Microsoft.AzureSphere/catalogs/images",
                                 "properties": {
                                   "image": "GPIO_HighLevelApp",
                                   "imageId": "a04f0a91-b369-4249-a47d-28c118e2cb3b",
                                   "regionalDataBoundary": "None",
                                   "uri": "https://as3imgptint003.blob.core.windows.net/7de8a199-bb33-4eda-9600-583103317243/imagesaks/a04f0a91-b369-4249-a47d-28c118e2cb3b?skoid=cc6e
                               3fcf-ab4d-4b0d-b3f9-9769604c1e52\u0026sktid=72f988bf-86f1-41af-91ab-2d7cd011db47\u0026skt=2024-02-28T07%3A31%3A00Z\u0026ske=2024-02-28T08%3A36%3A00Z\u0
                               026sks=b\u0026skv=2021-12-02\u0026sv=2021-12-02\u0026spr=https,http\u0026se=2024-02-28T15%3A36%3A00Z\u0026sr=b\u0026sp=r\u0026sig=MbkzxZH1VQUGft%2BfXbE
                               DhubAVucDykFSEGgvqZVn5yk%3D",
                                   "componentId": "dc7f135c-6074-4d49-aa3a-160e4eed884f",
                                   "imageType": "Applications",
                                   "provisioningState": "Succeeded"
                                 }
                               }}
DeploymentId                 : 2e83ddd9-6297-48df-9c2c-2257e6b3cc71
Id                           : /subscriptions/d1cd48f9-b94b-4645-9632-634b440db393/resourceGroups/joyer-test/providers/Microsoft.AzureSphere/catalogs/test2024/products/product2024/de
                               viceGroups/testdevicegroup/deployments/2e83ddd9-6297-48df-9c2c-2257e6b3cc71
Name                         : 2e83ddd9-6297-48df-9c2c-2257e6b3cc71
ProvisioningState            : Succeeded
ResourceGroupName            : joyer-test
SystemDataCreatedAt          : 2/28/2024 2:57:56 AM
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 2/28/2024 2:57:56 AM
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.AzureSphere/catalogs/products/deviceGroups/deployments
```

This command gets specific deployment in specified device group.

## PARAMETERS

### -CatalogInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentityCatalog
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -CatalogName
Name of catalog

```yaml
Type: System.String
Parameter Sets: Get, List
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

### -DeviceGroupInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentityDeviceGroup
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -DeviceGroupName
Name of device group.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCatalog, GetViaIdentityProduct, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Filter the result list using the given expression

```yaml
Type: System.String
Parameter Sets: List
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
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Maxpagesize
The maximum number of result items per page.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Deployment name.
Use .default for deployment creation and to get the current deployment for the associated device group.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCatalog, GetViaIdentityDeviceGroup, GetViaIdentityProduct
Aliases: DeploymentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProductInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity
Parameter Sets: GetViaIdentityProduct
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ProductName
Name of product.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityCatalog, List
Aliases:

Required: True
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
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
The number of result items to skip.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
The number of result items to return.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.ISphereIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Sphere.Models.IDeployment

## NOTES

## RELATED LINKS

