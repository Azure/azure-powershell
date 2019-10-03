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
The context is the default target of any cmdlet executed in PowerShell.  It consists of the [`Account`](#account), [`Tenant`](#tenant]), [`eNVIRONMENT`](#ENVIRONMENT),  and [`Subscription`](#subscription) that the user has selected using the `Select-AzContext` or `Select-AzSubscrition` cmdlets.  It also contains a reference to the token cache that is used in Authentication.  For most cmdlets, the subscription or tenant they target for their calls is the subscription in the `Default` Context.

### ContextContainer
A context container is a collection of contexts - it contains a disctionary associating its context with a unique key, and a `Default` context which is the context currently selected.  The user can switch between any contexts in the container without additional login.  The ContextContainer is populated when the user authenticates for the first time.

### Account

### Subscription

### Environment

### Tenant

### Caching

### AuthenticationFactory

## Authentication Scenarios

### User Authentication

#### Overview

#### Interactive Authentication

#### Username/Password Authentication

#### DeviceCode Authentication

### Service Authentication

### MSI Authentication

### Token Authentuication