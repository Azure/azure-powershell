### Example 1: Attach an edge action to a CDN endpoint

```powershell
Add-AzEdgeActionAttachment -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -ProfileName "myProfile" -EndpointName "myEndpoint"
```

Attaches the edge action to the specified CDN endpoint, enabling the edge action to process requests for that endpoint.

