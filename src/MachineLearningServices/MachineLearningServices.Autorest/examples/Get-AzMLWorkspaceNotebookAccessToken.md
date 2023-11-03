### Example 1: return notebook access token and refresh token
```powershell
Get-AzMLWorkspaceNotebookAccessToken -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01
```

```output
AccessToken ExpiresIn HostName               NotebookResourceId               PublicDns RefreshToken Scope         TokenType
----------- --------- --------               ------------------               --------- ------------ -----         ---------
                      Azure Machine Learning 770262087db047c88de12c933e679b88                        aznb_identity
```

return notebook access token and refresh token
