# Context
Due to the gaps between exposed API by Azure.Identity and urgent requirements from service, we have forked Azure.Identity code to this folder. 

# Changelog
[2024-1-16, Lei Jin] Replace the client assertion related codes by the forks from Azure.Identity 1.10.3 and Azure.Core 1.35.0
* The codes with namespace `Microsoft.Azure.PowerShell.Authenticators.Identity` is from Azure.Identity and with namespace `Microsoft.Azure.PowerShell.Authenticators.Identity.Core` is from Azure.Core
* Modify codes whose syntax requires C# 8 support.
* Add interface `ISupportsTokenCachePersistenceOptions` to the new version `ClientAssertionCredentialOptions`.

[2022-11-28, Yeming Liu] To support token cache of client assertion, I made `ClientAssertionCredentialOptions` implement `ITokenCacheOptions` interface.
* ClientAssertionCredentialOptions.cs
  * Implement `ITokenCacheOptions` and added `TokenCachePersistenceOptions` property.

[2022-11-23, dixue] To support token cache of client assertion, it forks client assertion related code from Azure.Identity 1.6.1
* MsalClientBase.cs
  * Modify using clause because its syntax requires C# 8 support.
  * Remove all log related method because Azure.Core and Azure.Identity do not expose those API to external.
