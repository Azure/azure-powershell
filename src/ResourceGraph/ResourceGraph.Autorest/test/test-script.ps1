New-AzResourceGraphQuery -Name “SharedQuery-t01” -ResourceGroupName lucas-rg-test -Location "global" -Description "requesting a subset of resource fields." -Query "project id, name, type, location, tags" 

PS D:\azure-service\ResourceGraph.Autorest\azure-powershell\src\ResourceGraph\ResourceGraph.Autorest [Az.ResourceGraph]> Get-AzResourceGraphQuery

cmdlet Get-AzResourceGraphQuery at command pipeline position 1
Supply values for the following parameters:
ResourceGroupName: lucas-rg-test

ETag Location Name            Type
---- -------- ----            ----
     global   SharedQuery-t01 microsoft.resourcegraph/queries
     global   SharedQuery-t02 microsoft.resourcegraph/queries

PS D:\azure-service\ResourceGraph.Autorest\azure-powershell\src\ResourceGraph\ResourceGraph.Autorest [Az.ResourceGraph]> Get-AzResourceGraphQuery -ResourceGroupName lucas-rg-test -Name SharedQuery-t01

ETag Location Name            Type
---- -------- ----            ----
    global   SharedQuery-t01 microsoft.resourcegraph/queries

PS D:\azure-service\ResourceGraph.Autorest\azure-powershell\src\ResourceGraph\ResourceGraph.Autorest [Az.ResourceGraph]> Get-AzResourceGraphQuery -ResourceGroupName lucas-rg-test -Name SharedQuery-t01 | Get-AzResourceGraphQuery
Exception: The running command stopped because the preference variable "ErrorActionPreference" or common parameter is set to Stop: Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ResourceGraph/queries/{resourceName}'


PS D:\azure-service\ResourceGraph.Autorest\azure-powershell\src\ResourceGraph\ResourceGraph.Autorest [Az.ResourceGraph]> Update-AzResourceGraphQuery -ResourceGroupName lucas-rg-test -Name SharedQuery-t01  -Query "project id, name, type, location"

ETag Location Name            Type
---- -------- ----            ----
     global   SharedQuery-t01 microsoft.resourcegraph/queries

PS D:\azure-service\ResourceGraph.Autorest\azure-powershell\src\ResourceGraph\ResourceGraph.Autorest [Az.ResourceGraph]> Update-AzResourceGraphQuery -InputObject $query -Query "project id, name, type, location, tags"
Update-AzResourceGraphQuery_UpdateViaIdentityExpanded: Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ResourceGraph/queries/{resourceName}'



PS D:\azure-service\ResourceGraph.Autorest\azure-powershell\src\ResourceGraph\ResourceGraph.Autorest [Az.ResourceGraph]> Remove-AzResourceGraphQuery -ResourceGroupName lucas-rg-test -Name SharedQuery-t02
PS D:\azure-service\ResourceGraph.Autorest\azure-powershell\src\ResourceGraph\ResourceGraph.Autorest [Az.ResourceGraph]> Remove-AzResourceGraphQuery  -InputObject $query
Remove-AzResourceGraphQuery_DeleteViaIdentity: Invalid identity for URI '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ResourceGraph/queries/{resourceName}'