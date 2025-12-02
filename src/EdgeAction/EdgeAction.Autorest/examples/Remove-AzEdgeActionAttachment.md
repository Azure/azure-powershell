### Example 1: Remove an attachment from an edge action

```powershell
Remove-AzEdgeActionAttachment -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -ProfileName "myProfile" -EndpointName "myEndpoint"
```

Removes the attachment between the edge action and the specified CDN endpoint.

