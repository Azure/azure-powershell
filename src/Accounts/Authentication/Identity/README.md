# Context
Due to the gaps between exposed API by Azure.Identity and urgent requirements from service, we have forked Azure.Identity code to this folder. 

# Changelog
[2022-11-28, Yeming Liu] To support token cache of client assertion, I made `ClientAssertionCredentialOptions` implement `ITokenCacheOptions` interface.
* ClientAssertionCredentialOptions.cs
  * Implement `ITokenCacheOptions` and added `TokenCachePersistenceOptions` property.

[2022-11-23, dixue] To support token cache of client assertion, it forks client assertion related code from Azure.Identity 1.6.1
* MsalClientBase.cs
  * Modify using clause because its syntax requires C# 8 support.
  * Remove all log related method because Azure.Core and Azure.Identity do not expose those API to external.
