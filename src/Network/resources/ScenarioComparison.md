## Get-AzVirtualWan
Generated:
```powershell
PS C:\Code\azps-generation\src\Network [Az.Network]> Get-AzVirtualWan -Name vw2my -ResourceGroupName rgmy
Get-AzVirtualWan : The server responded with a Request Error, Status: NotFound
At line:1 char:1
+ Get-AzVirtualWan -Name vw2my -ResourceGroupName rgmy
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
+ CategoryInfo          : InvalidOperation: ({ ResourceGroup...stem.String[] }:<>f__AnonymousType7`3) [Get-AzVirtualWan_Get], RestException`1
+ FullyQualifiedErrorId : NotFound,Microsoft.Azure.PowerShell.Cmdlets.Network.Cmdlets.GetAzVirtualWan_Get
```

Current:
```powershell
PS C:\Code\azure-powershell-pr\tools\miyanni\powershell> Get-AzVirtualWan -Name vw2my -ResourceGroupName rgmy
Get-AzVirtualWan : Operation returned an invalid status code 'NotFound'
StatusCode: 404
ReasonPhrase: Not Found
ErrorCode: ResourceNotFound
ErrorMessage: The Resource 'Microsoft.Network/virtualWans/vw2my' under resource group 'rgmy' was not found.
At line:1 char:1
+ Get-AzVirtualWan -Name vw2my -ResourceGroupName rgmy
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : CloseError: (:) [Get-AzVirtualWan], NetworkCloudException
    + FullyQualifiedErrorId : Microsoft.Azure.Commands.Network.GetAzureRmVirtualWanCommand
```

```powershell
PS C:\Code\azure-powershell-pr\tools\miyanni\powershell> $error[0].Exception.Message
Operation returned an invalid status code 'NotFound'
StatusCode: 404
ReasonPhrase: Not Found
ErrorCode: ResourceNotFound
ErrorMessage: The Resource 'Microsoft.Network/virtualWans/vw2my' under resource group 'rgmy' was not found.

PS C:\Code\azure-powershell-pr\tools\miyanni\powershell> $error[0].Exception.InnerException.Message
Operation returned an invalid status code 'NotFound'
```

## Get-AzVirtualHub
Generated:
```powershell
PS C:\Code\azps-generation\src\Network [Az.Network]> Get-AzVirtualHub -Name vhmy -ResourceGroupName rgmy
Get-AzVirtualHub : The server responded with a Request Error, Status: NotFound
At line:1 char:1
+ Get-AzVirtualHub -Name vhmy -ResourceGroupName rgmy
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
+ CategoryInfo          : InvalidOperation: ({ SubscriptionI..., Name = vhmy }:<>f__AnonymousType24`3) [Get-AzVirtualHub_Get], RestException`1
+ FullyQualifiedErrorId : NotFound,Microsoft.Azure.PowerShell.Cmdlets.Network.Cmdlets.GetAzVirtualHub_Get
```

Current:
```powershell
PS C:\Code\azure-powershell-pr\tools\miyanni\powershell> Get-AzVirtualHub -Name vhmy -ResourceGroupName rgmy
PS C:\Code\azure-powershell-pr\tools\miyanni\powershell>
```

## Get-AzExpressRouteGateway
Generated:
```powershell
Get-AzExpressRouteGateway -Name ergmy -ResourceGroupName rgmy
Get-AzExpressRouteGateway : The server responded with a Request Error, Status: NotFound
At line:1 char:1
+ Get-AzExpressRouteGateway -Name ergmy -ResourceGroupName rgmy
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
+ CategoryInfo          : InvalidOperation: ({ ResourceGroup...stem.String[] }:<>f__AnonymousType7`3) [Get-AzExpressRouteGateway_Get], UndeclaredResponseException
+ FullyQualifiedErrorId : NotFound,Microsoft.Azure.PowerShell.Cmdlets.Network.Cmdlets.GetAzExpressRouteGateway_Get
```

Current:
```powershell
PS C:\Code\azure-powershell-pr\tools\miyanni\powershell> Get-AzExpressRouteGateway -Name ergmy -ResourceGroupName rgmy
Get-AzExpressRouteGateway : The Resource 'Microsoft.Network/expressRouteGateways/ergmy' under resource group 'rgmy'
was not found.
StatusCode: 404
ReasonPhrase: Not Found
ErrorCode: ResourceNotFound
ErrorMessage: The Resource 'Microsoft.Network/expressRouteGateways/ergmy' under resource group 'rgmy' was not found.
OperationID : 5076b88b-8690-46ae-a650-63765c6cf5a8
At line:1 char:1
+ Get-AzExpressRouteGateway -Name ergmy -ResourceGroupName rgmy
+ ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    + CategoryInfo          : CloseError: (:) [Get-AzExpressRouteGateway], NetworkCloudException
    + FullyQualifiedErrorId : Microsoft.Azure.Commands.Network.GetAzureRmExpressRouteGatewayCommand
```

```powershell
PS C:\Code\azure-powershell-pr\tools\miyanni\powershell> $thing1.Exception.InnerException.Response.StatusCode
NotFound
```