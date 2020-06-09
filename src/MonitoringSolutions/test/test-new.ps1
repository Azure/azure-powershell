$Name = 'Containers(yeminglog)'
$PlanName = 'Containers(yeminglog)'
$Location = 'westus2'
$ResourceGroupName = 'yemingwestus2'
$PlanProduct = "OMSGallery/Containers"
$PlanPublisher = 'Microsoft'
$WorkspaceResourceId = '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/yemingwestus2/providers/microsoft.operationalinsights/workspaces/yeminglog'
New-AzMonitorLogAnalyticsSolution -Name $Name -Location $Location -ResourceGroupName $ResourceGroupName -PlanName $PlanName -PlanProduct $PlanProduct -PlanPublisher $PlanPublisher -PlanPromotionCode "" -WorkspaceResourceId $WorkspaceResourceId

New-AzMonitorLogAnalyticsSolution -WorkspaceName yemingmonitor -Type Containers -ResourceGroupName yemingmonitor -Location westus2 -WorkspaceId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/yemingmonitor/providers/microsoft.operationalinsights/workspaces/yemingmonitor