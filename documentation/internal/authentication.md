# Authentication
## Overview

All authentication in PowerShell follows the same basic method. All requests are authenticated with a token, that is provided by a token service.  The token identifies the principal, and the services (also called resources) that the user wants to access (and the STS can verify that the user is registered to access).  Services use this token to identify the principal, and associate the user with the appropriate authorization level.  Authorization is managed separately, by each service, and is not part of thsi discussion.

This document braks down PowerShell Authentication ino the following sections
- Abstractions - Discusses the Concepts used in authenticating a user
- Authentication Scenarios - Discusses the various authentication methods that can be used by eqach kind of principal
  - User Authentication
  - Service Authentication
  - MSI Authentication
  - Token Authentication
- MSAL Authentication - Discusses how these scenarios differ in MSAL

## Abstractions

### Context
The context is the default target of any cmdlet executed in PowerShell.  It consists of the [`Account`](#account), [`Tenant`](#tenant]), [`Environment`](#environment),  and [`Subscription`](#subscription) that the user has selected using the `Select-AzContext` or `Select-AzSubscrition` cmdlets.  It also contains a reference to the token cache that is used in Authentication.  For most cmdlets, the subscription or tenant they target for their calls is the subscription in the `Default` Context.

### ContextContainer
A context container is a collection of contexts - it contains a disctionary associating its context with a unique key, and a `Default` context which is the context currently selected.  The user can switch between any contexts in the container without additional login.  The ContextContainer is populated when the user authenticates for the first time.

### Account
An account is the representation of the principal used for authentication.  This can be a User Account, a Service Principal, a Managed Service Identity, or a raw token.  The primary key for Account is a nsmae.

### Subscription
A subscription represents a subscription in Azure, it has properties indicating ID, Name, and State. The default subscription will be the target of all clients

### Environment
An Environment is a particular Azure cloud that is targeted for commands.  'AzureCloud' is the default environment if none is selected.  Built-in clouds anlso include 'AzureChinaCloud', 'AzureGermanCloud', and 'AzureUSGovernment' cloud.  Eaach environment contains the endpoints for services on that cloud, the 'resourceId' that is required when authenticating for that service, and a set of domain suffixes that can be used to determine data plane service endpoints (for example, the StorageEndpointSuffix can be appeneded to a storage account name to get the default domain name of the endpoints for that storage account).

### Tenant
A Tenant represents an Active Directory tenant that may contain one or more subscriptions.  When authenticating, a user may have access to multiple tenants, and the default ContextContainer will contain all of the tenants (and associated subscriptions) the user has access to.

### Caching
Each context contains a reference to the currently active TokenCache - this allows common Authentication methods to retrieve tokens for the given context when it is passed in to common methods.

### AuthenticationFactory

The Authentication Factory is a central abstraction used by all modules to acquire authentication tokens for their calls to Azure services.  This abstract factory is used by Az.Accounts to do initial login and context acquisition, and by service modules to acquire tokens using the currently selected context for their Azure requests (management and data plane).  Generally, a client needs to pass in the current context and an indication of what service is being authenticated to get back authentication tokens.

Generally, the types returned by the Authentication Factory encapsulate the actual tokens, so that tokens can be automatically renewed as requests are made without additional explicit calls from the service module.

## Authentication Scenarios

### User Authentication

#### Overview

#### Interactive Authentication

#### Username/Password Authentication

#### DeviceCode Authentication

### Service Authentication

### MSI Authentication

### Token Authentuication
