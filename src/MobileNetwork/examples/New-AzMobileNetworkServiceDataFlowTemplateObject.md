### Example 1: Create an in-memory object for ServiceDataFlowTemplate.
```powershell
New-AzMobileNetworkServiceDataFlowTemplateObject -Direction "Bidirectional" -Protocol "255" -RemoteIPList "any" -TemplateName azps-mn-flow-template
```

```output
Direction     Port Protocol RemoteIPList TemplateName
---------     ---- -------- ------------ ------------
Bidirectional      {255}    {any}        azps-mn-flow-template
```

Create an in-memory object for ServiceDataFlowTemplate.