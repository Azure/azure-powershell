### Example 1: Add an Edge Action Attachment
```powershell
Add-AzCdnEdgeActionAttachment -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -AttachmentName attachment001 -EndpointName endpoint001
```

```output
AttachmentName ResourceGroupName EdgeActionName EndpointName
-------------- ----------------- -------------- ------------
attachment001  testps-rg-da16jm  edgeaction001  endpoint001
```

Add an Edge Action Attachment to link an edge action with an endpoint