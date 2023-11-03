### Example 1: Lists all enabled features for a workspace
```powershell
Get-AzMLWorkspaceFeature  -ResourceGroupName ml-rg-test -Name mlworkspace-portal01
```

```output
Description                                                                            DisplayName
-----------                                                                            -----------
Raw feature explanation for AutoML models                                              Model Explanability
Create, edit or delete AutoML experiments in the SDK                                   Create edit experiments SDK
Create, edit or delete HyperDrive experiments in the SDK                               Create edit hyperdrive SDK
Select or upload a dataset to train on from datasets in the SDK                        Dataset integration from SDK
Deploy an AutoML model from the SDK                                                    Deploy model SDK
Auto train a forecasting DNN from SDK                                                  DNN Forecasting SDK
Auto train an NLP DNN from SDK                                                         DNN NLP SDK
Deploy and view explainability dashboard for inference data                            Explainability at Inference time SDK
Create and view explainability dashboard in the SDK                                    Explainability dashboard in SDK at training time
```

Lists all enabled features for a workspace
