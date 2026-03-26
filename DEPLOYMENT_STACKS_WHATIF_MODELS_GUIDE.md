# Deployment Stacks What-If Generated Models Guide

## Overview
This guide documents the 38+ generated models available in `Resources.Management.Sdk` for implementing Deployment Stacks What-If functionality. These models are auto-generated from the Azure REST API specifications.

---

## Core What-If Models (19 models)

### 1. **DeploymentStacksWhatIfResult** - Main Result Container
**Purpose**: Top-level result object returned from What-If operations  
**Key Properties**:
- `Properties`: `DeploymentStacksWhatIfResultProperties` - Contains all what-if data
- `Location`: `string` - Geo-location of the stack
- `Tags`: `IDictionary<string, string>` - Resource tags
- `Id`, `Name`, `Type`, `SystemData`: Inherited from `ProxyResource`

**Usage**: This is returned from SDK operations and should be wrapped in a PS model.

---

### 2. **DeploymentStacksWhatIfResultProperties** - What-If Details
**Purpose**: Contains all the detailed what-if results and parameters  
**Key Properties**:

#### Input/Configuration Properties:
- `Template`: `IDictionary<string, object>` - Template content
- `TemplateLink`: `DeploymentStacksTemplateLink` - Template URI
- `Parameters`: `IDictionary<string, DeploymentParameter>` - Parameter values
- `ParametersLink`: `DeploymentStacksParametersLink` - Parameters URI
- `ActionOnUnmanage`: `ActionOnUnmanage` - What to do with unmanaged resources
- `DenySettings`: `DenySettings` - Lock settings
- `DeploymentScope`: `string` - Scope for initial deployment
- `Description`: `string` - Stack description (max 4096 chars)
- `DebugSetting`: `DeploymentStacksDebugSetting` - Debug configuration

#### What-If Result Properties:
- `Changes`: `DeploymentStacksWhatIfChange` - **THE MAIN CHANGES OBJECT** (READ-ONLY)
- `Diagnostics`: `IList<DeploymentStacksDiagnostic>` - Warnings/errors (READ-ONLY)
- `Error`: `ErrorDetail` - Error details if operation failed

#### Comparison Context Properties:
- `DeploymentStackResourceId`: `string` - ID of existing stack to compare against
- `DeploymentStackLastModified`: `DateTime?` - When the comparison stack was last modified (READ-ONLY)
- `RetentionInterval`: `TimeSpan` - How long to persist the result (ISO 8601 format)
- `ProvisioningState`: `string` - State of the stack (READ-ONLY)
- `CorrelationId`: `string` - Correlation ID for tracing (READ-ONLY)
- `ValidationLevel`: `string` - Validation level ('Template', 'Provider', 'ProviderNoRbac')

**Usage**: Extract `Changes` property for formatting and display to user.

---

### 3. **DeploymentStacksWhatIfChange** - Changes Container
**Purpose**: Contains all predicted changes from the what-if operation  
**Key Properties**:
- `ResourceChanges`: `IList<DeploymentStacksWhatIfResourceChange>` - **REQUIRED** - List of individual resource changes
- `DenySettingsChange`: `DeploymentStacksWhatIfChangeDenySettingsChange` - **REQUIRED** - Changes to deny settings
- `DeploymentScopeChange`: `DeploymentStacksWhatIfChangeDeploymentScopeChange` - Changes to deployment scope (optional)

**Usage**: 
```csharp
// Main iteration point for displaying what-if results
var changes = result.Properties.Changes;
foreach (var resourceChange in changes.ResourceChanges) 
{
    // Display each resource change
}
// Display deny settings changes
DisplayDenySettingsChange(changes.DenySettingsChange);
// Display deployment scope changes if present
if (changes.DeploymentScopeChange != null) 
{
    DisplayDeploymentScopeChange(changes.DeploymentScopeChange);
}
```

---

### 4. **DeploymentStacksWhatIfResourceChange** - Individual Resource Change
**Purpose**: Represents a predicted change to a single resource  
**Key Properties**:

#### Resource Identity:
- `Id`: `string` - ARM Resource ID (READ-ONLY)
- `Type`: `string` - Resource type (e.g., "Microsoft.Storage/storageAccounts") (READ-ONLY)
- `ApiVersion`: `string` - API version used (READ-ONLY)
- `SymbolicName`: `string` - Symbolic name from template
- `Identifiers`: `IDictionary<string, object>` - Extensible identifiers (READ-ONLY)
- `Extension`: `DeploymentExtension` - Extension used for deployment (READ-ONLY)
- `DeploymentId`: `string` - Deployment resource ID

#### Change Information:
- `ChangeType`: `string` - **REQUIRED** - Type of change ('create', 'delete', 'detach', 'modify', 'noChange', 'unsupported')
- `ChangeCertainty`: `string` - **REQUIRED** - Confidence level ('definite', 'potential')
- `UnsupportedReason`: `string` - Explanation if unsupported

#### Stack-Specific Changes:
- `ManagementStatusChange`: `DeploymentStacksWhatIfResourceChangeManagementStatusChange` - Changes to managed/unmanaged status
- `DenyStatusChange`: `DeploymentStacksWhatIfResourceChangeDenyStatusChange` - Changes to deny assignments
- `ResourceConfigurationChanges`: `DeploymentStacksWhatIfResourceChangeResourceConfigurationChanges` - Property-level changes

**Usage**:
```csharp
var resourceChange = changes.ResourceChanges[0];
string changeType = resourceChange.ChangeType; // "create", "modify", etc.
string certainty = resourceChange.ChangeCertainty; // "definite" or "potential"

// Check if resource configuration changed
if (resourceChange.ResourceConfigurationChanges != null)
{
    var propertyChanges = resourceChange.ResourceConfigurationChanges.Delta;
    // Display property-level changes
}

// Check management status changes (managed/unmanaged)
if (resourceChange.ManagementStatusChange != null)
{
    var before = resourceChange.ManagementStatusChange.Before; // "managed", "unmanaged", "unknown"
    var after = resourceChange.ManagementStatusChange.After;
}

// Check deny status changes (lock changes)
if (resourceChange.DenyStatusChange != null)
{
    var before = resourceChange.DenyStatusChange.Before; // "denyDelete", "denyWriteAndDelete", etc.
    var after = resourceChange.DenyStatusChange.After;
}
```

---

### 5. **DeploymentStacksWhatIfResourceChangeResourceConfigurationChanges** - Property Changes
**Purpose**: Contains before/after snapshots and property-level changes  
**Key Properties**:
- `Before`: `IDictionary<string, object>` - Full resource state before
- `After`: `IDictionary<string, object>` - Full resource state after
- `Delta`: `IList<DeploymentStacksWhatIfPropertyChange>` - Individual property changes

**Usage**: Iterate through `Delta` to display property-by-property changes.

---

### 6. **DeploymentStacksWhatIfPropertyChange** - Individual Property Change
**Purpose**: Represents a single property change (can be nested)  
**Key Properties**:
- `Path`: `string` - **REQUIRED** - JSON path to the property (e.g., "properties.ipAddress")
- `ChangeType`: `string` - **REQUIRED** - Change type ('create', 'delete', 'modify', 'noEffect', 'array')
- `Before`: `object` - Value before change
- `After`: `object` - Value after change
- `Children`: `IList<DeploymentStacksWhatIfPropertyChange>` - Nested property changes

**Usage**:
```csharp
void DisplayPropertyChange(DeploymentStacksWhatIfPropertyChange change, int indent = 0)
{
    WriteLine($"{new string(' ', indent)}{change.Path}: {change.ChangeType}");
    WriteLine($"{new string(' ', indent)}  Before: {change.Before}");
    WriteLine($"{new string(' ', indent)}  After: {change.After}");
    
    // Handle nested changes recursively
    if (change.Children != null)
    {
        foreach (var child in change.Children)
        {
            DisplayPropertyChange(child, indent + 2);
        }
    }
}
```

---

### 7. **DeploymentStacksWhatIfChangeDenySettingsChange** - Deny Settings Changes
**Purpose**: Predicts changes to the deployment stack's deny/lock settings  
**Key Properties**:
- `Before`: `DenySettings` - Current deny settings
- `After`: `DenySettings` - Predicted deny settings after operation
- `Delta`: `IList<DeploymentStacksWhatIfPropertyChange>` - Property-level changes

**Usage**: Display changes to stack-level lock configuration (denyDelete, denyWriteAndDelete, etc.)

---

### 8. **DeploymentStacksWhatIfChangeDeploymentScopeChange** - Scope Changes
**Purpose**: Predicts changes to the deployment scope  
**Key Properties**:
- `Before`: `string` - Current deployment scope
- `After`: `string` - Predicted deployment scope after operation

**Usage**: Display if the deployment scope is changing (e.g., from subscription to resource group)

---

### 9. **DeploymentStacksWhatIfResourceChangeManagementStatusChange** - Management Status Changes
**Purpose**: Predicts if a resource will become managed/unmanaged  
**Key Properties**:
- `Before`: `string` - Current status ('managed', 'unmanaged', 'unknown')
- `After`: `string` - Predicted status ('managed', 'unmanaged', 'unknown')

**Usage**: Show if resource is being added to or removed from stack management.

---

### 10. **DeploymentStacksWhatIfResourceChangeDenyStatusChange** - Deny Status Changes
**Purpose**: Predicts changes to resource-level deny assignments (locks)  
**Key Properties**:
- `Before`: `string` - Current deny status
- `After`: `string` - Predicted deny status

**Possible Values**:
- `denyDelete` - Read and modify allowed, delete blocked
- `denyWriteAndDelete` - Only read allowed
- `notSupported` - Resource type doesn't support deny assignments
- `inapplicable` - Resource outside stack scope
- `removedBySystem` - Removed by Azure (e.g., after management group move)
- `none` - No deny assignments
- `unknown` - Status unknown

**Usage**: Display resource-level lock changes.

---

### 11. **DeploymentStacksDiagnostic** - Warnings and Errors
**Purpose**: Contains diagnostic messages from the what-if operation  
**Key Properties**:
- `Level`: `string` - **REQUIRED** - Severity ('info', 'warning', 'error')
- `Code`: `string` - **REQUIRED** - Error/warning code
- `Message`: `string` - **REQUIRED** - Human-readable message
- `Target`: `string` - What the diagnostic applies to
- `AdditionalInfo`: `IList<ErrorAdditionalInfo>` - Extra context

**Usage**: Display warnings and errors to user, grouped by severity.

---

## Enum Models (6 models)

### 12. **DeploymentStacksWhatIfChangeType** - Resource Change Types
**Purpose**: Defines the type of change for a resource  
**Values**:
- `Create` = "create" - Resource will be created
- `Delete` = "delete" - Resource will be deleted
- `Detach` = "detach" - Resource will be detached (removed from stack but kept in Azure)
- `Modify` = "modify" - Resource will be modified
- `NoChange` = "noChange" - Resource will be redeployed but properties won't change
- `Unsupported` = "unsupported" - Resource type not supported by What-If

**Usage**: Use constants for comparison and color coding in output.

---

### 13. **DeploymentStacksWhatIfPropertyChangeType** - Property Change Types
**Purpose**: Defines the type of change for a property  
**Values**:
- `Array` = "array" - Property is an array with nested changes
- `Create` = "create" - Property will be created
- `Delete` = "delete" - Property will be deleted
- `Modify` = "modify" - Property will be modified
- `NoEffect` = "noEffect" - Property will not change

**Usage**: Use for property-level change display and formatting.

---

### 14. **DeploymentStacksWhatIfChangeCertainty** - Change Confidence Level
**Purpose**: Indicates confidence in the predicted change  
**Values**:
- `Definite` = "definite" - Change will definitely occur
- `Potential` = "potential" - Change may occur based on runtime conditions

**Usage**: Display uncertainty to users (e.g., with "~" prefix for potential changes).

---

### 15. **DeploymentStacksManagementStatus** - Management State
**Purpose**: Indicates if resource is managed by stack  
**Values**:
- `Managed` = "managed" - Resource is managed by deployment stack
- `Unmanaged` = "unmanaged" - Resource is not managed
- `Unknown` = "unknown" - Management state unknown

**Usage**: Use when displaying management status changes.

---

### 16. **DenyStatusMode** - Deny Assignment Status
**Purpose**: Defines the lock/deny assignment status of a resource  
**Values**:
- `DenyDelete` = "denyDelete" - Can read/modify, cannot delete
- `DenyWriteAndDelete` = "denyWriteAndDelete" - Can only read
- `NotSupported` = "notSupported" - Resource type doesn't support locks
- `Inapplicable` = "inapplicable" - Resource outside stack scope
- `RemovedBySystem` = "removedBySystem" - Lock removed by Azure
- `None` = "none" - No locks applied
- `Unknown` = "unknown" - Status unknown

**Usage**: Display resource lock status changes.

---

### 17. **DeploymentStacksDiagnosticLevel** - Diagnostic Severity
**Purpose**: Severity level for diagnostics  
**Values**:
- `Info` = "info"
- `Warning` = "warning"
- `Error` = "error"

**Usage**: Color code diagnostics by severity.

---

## Supporting Models (13+ models)

### 18. **ActionOnUnmanage** - Unmanaged Resource Behavior
**Key Properties**:
- `Resources`: Action for resources ('delete', 'detach')
- `ResourceGroups`: Action for resource groups ('delete', 'detach')
- `ManagementGroups`: Action for management groups ('delete', 'detach')

**Usage**: Passed as input parameter; affects what happens to resources removed from template.

---

### 19. **DenySettings** - Lock Configuration
**Key Properties**:
- `Mode`: `string` - Lock mode ('denyDelete', 'denyWriteAndDelete', 'none')
- `ExcludedPrincipals`: `IList<string>` - Principal IDs exempt from locks
- `ExcludedActions`: `IList<string>` - Actions exempt from locks
- `ApplyToChildScopes`: `bool` - Whether locks apply to child scopes

**Usage**: Configure stack-level locking; compare before/after in deny settings changes.

---

### 20. **DeploymentParameter** - Template Parameter
**Key Properties**:
- `Value`: `object` - Parameter value
- `Reference`: `KeyVaultParameterReference` - Key Vault reference

**Usage**: Pass template parameters for what-if evaluation.

---

### 21. **DeploymentStacksTemplateLink** - Template URI Reference
**Key Properties**:
- `Uri`: `string` - Template file URI
- `Id`: `string` - Resource ID if using linked template
- `ContentVersion`: `string` - Template version
- `QueryString`: `string` - SAS token or query string

**Usage**: Reference external template file instead of inline template.

---

### 22. **DeploymentStacksParametersLink** - Parameters URI Reference
**Key Properties**:
- `Uri`: `string` - Parameters file URI
- `ContentVersion`: `string` - Parameters file version

**Usage**: Reference external parameters file.

---

### 23. **DeploymentStacksDebugSetting** - Debug Configuration
**Key Properties**:
- `DetailLevel`: `string` - Debug level

**Usage**: Control debugging output during deployment.

---

### 24. **DeploymentExtension** - Extension Information
**Key Properties**:
- `Alias`: `string` - Extension alias
- `ResourceId`: `string` - Extension resource ID

**Usage**: Identifies which extension deployed a resource (READ-ONLY in results).

---

### 25. **ErrorDetail** - Error Information
**Key Properties**:
- `Code`: `string` - Error code
- `Message`: `string` - Error message
- `Target`: `string` - Error target
- `Details`: `IList<ErrorDetail>` - Nested errors
- `AdditionalInfo`: `IList<ErrorAdditionalInfo>` - Additional context

**Usage**: Display errors from failed what-if operations.

---

### 26. **SystemData** - Metadata
**Key Properties**:
- `CreatedBy`: `string` - Who created the resource
- `CreatedAt`: `DateTime?` - When created
- `LastModifiedBy`: `string` - Who last modified
- `LastModifiedAt`: `DateTime?` - When last modified

**Usage**: Display creation/modification metadata.

---

## HTTP Header Models (6 models)
These are used internally by the SDK for async operations:

- `DeploymentStacksWhatIfResultsAtManagementGroupCreateOrUpdateHeaders`
- `DeploymentStacksWhatIfResultsAtManagementGroupWhatIfHeaders`
- `DeploymentStacksWhatIfResultsAtResourceGroupCreateOrUpdateHeaders`
- `DeploymentStacksWhatIfResultsAtResourceGroupWhatIfHeaders`
- `DeploymentStacksWhatIfResultsAtSubscriptionCreateOrUpdateHeaders`
- `DeploymentStacksWhatIfResultsAtSubscriptionWhatIfHeaders`

**Usage**: SDK internal - contain headers like `Location`, `Retry-After`, `Azure-AsyncOperation`.

---

## Models NOT Used for What-If (but related to Deployment Stacks)

### Other Deployment Stack Models:
- `DeploymentStack` - Actual deployment stack resource (not what-if)
- `DeploymentStackProperties` - Stack properties (not what-if)
- `DeploymentStackProvisioningState` - Stack state enum
- `DeploymentStacksDeleteDetachEnum` - Delete operation modes
- `DeploymentStacksResourcesWithoutDeleteSupportEnum` - Resources that can't be deleted
- `DeploymentStacksError` / `DeploymentStacksErrorException` - Error handling

---

## Implementation Pattern for What-If Cmdlets

### Step 1: Prepare Request Parameters
```csharp
var parameters = new PSDeploymentStackWhatIfParameters
{
    Template = templateContent,
    TemplateLink = templateLink,
    Parameters = parameters,
    ActionOnUnmanage = actionOnUnmanage,
    DenySettings = denySettings,
    DeploymentStackResourceId = existingStackId,
    RetentionInterval = TimeSpan.FromHours(2)
};
```

### Step 2: Call SDK What-If Operation
```csharp
// In DeploymentStacksSdkClient
var result = DeploymentStacksWhatIfResultsAtResourceGroupOperations
    .BeginWhatIfAsync(resourceGroupName, stackName, deploymentStacksWhatIf, cancellationToken)
    .GetAwaiter().GetResult();
```

### Step 3: Process the Result
```csharp
// Extract changes from result
var changes = result.Properties.Changes;

// 3a. Process resource changes
foreach (var resourceChange in changes.ResourceChanges)
{
    switch (resourceChange.ChangeType)
    {
        case DeploymentStacksWhatIfChangeType.Create:
            // Display create operation with Green color
            break;
        case DeploymentStacksWhatIfChangeType.Delete:
            // Display delete operation with Orange/Red color
            break;
        case DeploymentStacksWhatIfChangeType.Modify:
            // Display modify operation with Orange color
            // Show property changes from resourceChange.ResourceConfigurationChanges.Delta
            break;
        case DeploymentStacksWhatIfChangeType.Detach:
            // Display detach operation (resource kept but unmanaged)
            break;
        case DeploymentStacksWhatIfChangeType.NoChange:
            // Display no change operation (Gray color)
            break;
        case DeploymentStacksWhatIfChangeType.Unsupported:
            // Display unsupported with reason
            break;
    }
    
    // 3b. Display management status changes
    if (resourceChange.ManagementStatusChange != null)
    {
        // Show: "Management Status: unmanaged -> managed"
    }
    
    // 3c. Display deny status changes
    if (resourceChange.DenyStatusChange != null)
    {
        // Show: "Deny Status: none -> denyDelete"
    }
}

// 3d. Display deny settings changes (stack level)
if (changes.DenySettingsChange != null)
{
    // Show stack-level lock configuration changes
}

// 3e. Display deployment scope changes
if (changes.DeploymentScopeChange != null)
{
    // Show: "Deployment Scope: old -> new"
}
```

### Step 4: Display Diagnostics
```csharp
if (result.Properties.Diagnostics != null)
{
    foreach (var diagnostic in result.Properties.Diagnostics)
    {
        switch (diagnostic.Level)
        {
            case "error":
                // Display in Red
                break;
            case "warning":
                // Display in Yellow
                break;
            case "info":
                // Display normally
                break;
        }
    }
}
```

### Step 5: Handle Errors
```csharp
if (result.Properties.Error != null)
{
    // Display error details
    var error = result.Properties.Error;
    WriteError($"Error {error.Code}: {error.Message}");
    // Recurse through error.Details if present
}
```

---

## Color Coding Recommendations (Based on Existing Formatter)

Use the `Color` enum from `ResourceManager.Formatters` for consistent formatting:

| Change Type | Color | Symbol |
|-------------|-------|--------|
| Create | Green | + |
| Modify | Orange | ~ |
| Delete | Orange/Red | - |
| Detach | Yellow | x |
| NoChange | Grey | = |
| Unsupported | Purple | * |
| Definite | (normal) | |
| Potential | (lighter/italic) | ~ prefix |

---

## Key Differences from Regular Deployment What-If

Deployment Stacks What-If has **additional concepts** beyond regular deployment what-if:

1. **Management Status**: Whether resources are managed/unmanaged by the stack
2. **Deny Status**: Resource-level lock status (inherited from stack deny settings)
3. **Detach Operation**: Resources can be detached (removed from stack but kept in Azure)
4. **Stack-Level Changes**: Deny settings and deployment scope are stack-level configurations
5. **ActionOnUnmanage**: Defines behavior for resources removed from template

---

## Complete List of All 38 Generated Models

### What-If Core (19):
1. ? DeploymentStacksWhatIfResult
2. ? DeploymentStacksWhatIfResultProperties
3. ? DeploymentStacksWhatIfChange
4. ? DeploymentStacksWhatIfResourceChange
5. ? DeploymentStacksWhatIfResourceChangeResourceConfigurationChanges
6. ? DeploymentStacksWhatIfPropertyChange
7. ? DeploymentStacksWhatIfChangeDenySettingsChange
8. ? DeploymentStacksWhatIfChangeDeploymentScopeChange
9. ? DeploymentStacksWhatIfResourceChangeManagementStatusChange
10. ? DeploymentStacksWhatIfResourceChangeDenyStatusChange
11. ? DeploymentStacksWhatIfChangeType (enum)
12. ? DeploymentStacksWhatIfPropertyChangeType (enum)
13. ? DeploymentStacksWhatIfChangeCertainty (enum)
14. ? DeploymentStacksDiagnostic
15. ? DeploymentStacksDiagnosticLevel (enum)
16. ? DeploymentStacksWhatIfResultsAtManagementGroupCreateOrUpdateHeaders
17. ? DeploymentStacksWhatIfResultsAtManagementGroupWhatIfHeaders
18. ? DeploymentStacksWhatIfResultsAtResourceGroupCreateOrUpdateHeaders
19. ? DeploymentStacksWhatIfResultsAtResourceGroupWhatIfHeaders
20. ? DeploymentStacksWhatIfResultsAtSubscriptionCreateOrUpdateHeaders
21. ? DeploymentStacksWhatIfResultsAtSubscriptionWhatIfHeaders

### Stack Management (17):
22. DeploymentStack
23. DeploymentStackProperties
24. DeploymentStackProvisioningState (enum)
25. DeploymentStacksTemplateLink
26. DeploymentStacksParametersLink
27. DeploymentStacksDebugSetting
28. DeploymentStacksCreateOrUpdateAtManagementGroupHeaders
29. DeploymentStacksCreateOrUpdateAtResourceGroupHeaders
30. DeploymentStacksCreateOrUpdateAtSubscriptionHeaders
31. DeploymentStacksDeleteAtManagementGroupHeaders
32. DeploymentStacksDeleteAtResourceGroupHeaders
33. DeploymentStacksDeleteAtSubscriptionHeaders
34. DeploymentStacksDeleteDetachEnum (enum)
35. DeploymentStacksResourcesWithoutDeleteSupportEnum (enum)
36. DeploymentStacksValidateStackAtManagementGroupHeaders
37. DeploymentStacksValidateStackAtResourceGroupHeaders
38. DeploymentStacksValidateStackAtSubscriptionHeaders

### Supporting Models (shared):
- DeploymentStacksManagementStatus (enum)
- DenyStatusMode (enum)
- DeploymentStacksError
- DeploymentStacksErrorException

---

## Quick Reference: Most Important Models for What-If Implementation

### Must Use:
1. **DeploymentStacksWhatIfResult** - Top-level result
2. **DeploymentStacksWhatIfResultProperties** - Contains `.Changes` and `.Diagnostics`
3. **DeploymentStacksWhatIfChange** - Contains `.ResourceChanges`, `.DenySettingsChange`, `.DeploymentScopeChange`
4. **DeploymentStacksWhatIfResourceChange** - Individual resource change with changeType, certainty, and nested changes

### For Display Logic:
5. **DeploymentStacksWhatIfChangeType** - Use constants for change type comparison
6. **DeploymentStacksWhatIfChangeCertainty** - Display definite vs potential changes differently
7. **DeploymentStacksWhatIfPropertyChange** - Recursive property changes with Before/After

### For Stack-Specific Features:
8. **DeploymentStacksWhatIfResourceChangeManagementStatusChange** - Show managed/unmanaged status
9. **DeploymentStacksWhatIfResourceChangeDenyStatusChange** - Show lock changes
10. **DeploymentStacksWhatIfChangeDenySettingsChange** - Show stack-level lock changes

### For Diagnostics:
11. **DeploymentStacksDiagnostic** - Warnings and errors to display

---

## Example Workflow

```csharp
// 1. SDK returns result
DeploymentStacksWhatIfResult result = await sdkClient.GetWhatIfResultAsync(...);

// 2. Extract changes
var changes = result.Properties.Changes;

// 3. Iterate resource changes
foreach (var resourceChange in changes.ResourceChanges)
{
    // Display resource identity
    Console.WriteLine($"Resource: {resourceChange.Id}");
    Console.WriteLine($"Type: {resourceChange.Type}");
    
    // Display change type with color
    string symbol = GetSymbolForChangeType(resourceChange.ChangeType);
    Color color = GetColorForChangeType(resourceChange.ChangeType);
    ColorWrite($"{symbol} {resourceChange.ChangeType}", color);
    
    // Display certainty
    if (resourceChange.ChangeCertainty == DeploymentStacksWhatIfChangeCertainty.Potential)
    {
        Console.WriteLine(" [Potential]");
    }
    
    // Display management status change
    if (resourceChange.ManagementStatusChange != null)
    {
        Console.WriteLine($"  Management: {resourceChange.ManagementStatusChange.Before} -> {resourceChange.ManagementStatusChange.After}");
    }
    
    // Display deny status change
    if (resourceChange.DenyStatusChange != null)
    {
        Console.WriteLine($"  Lock: {resourceChange.DenyStatusChange.Before} -> {resourceChange.DenyStatusChange.After}");
    }
    
    // Display property changes
    if (resourceChange.ResourceConfigurationChanges?.Delta != null)
    {
        foreach (var propChange in resourceChange.ResourceConfigurationChanges.Delta)
        {
            DisplayPropertyChange(propChange, indent: 2);
        }
    }
}

// 4. Display stack-level changes
if (changes.DenySettingsChange != null)
{
    Console.WriteLine("Stack Deny Settings Changes:");
    DisplayDenySettingsChange(changes.DenySettingsChange);
}

// 5. Display diagnostics
foreach (var diag in result.Properties.Diagnostics ?? Enumerable.Empty<DeploymentStacksDiagnostic>())
{
    var color = GetColorForDiagnosticLevel(diag.Level);
    ColorWrite($"{diag.Level.ToUpper()}: {diag.Message}", color);
}
```

---

## Validation Notes

All models have `Validate()` methods that check:
- Required properties are not null
- String enums have valid values
- Nested objects are valid

Call `result.Validate()` to ensure SDK returned valid data.

---

## Comparison with Regular Deployment What-If

| Feature | Regular Deployment What-If | Deployment Stacks What-If |
|---------|---------------------------|---------------------------|
| Resource Changes | ? WhatIfResourceChange | ? DeploymentStacksWhatIfResourceChange |
| Property Changes | ? WhatIfPropertyChange | ? DeploymentStacksWhatIfPropertyChange |
| Change Types | Create, Delete, Modify, Ignore, Deploy, NoChange | Create, Delete, **Detach**, Modify, NoChange, Unsupported |
| Management Status | ? Not applicable | ? Managed/Unmanaged tracking |
| Deny Status | ? Not applicable | ? Resource-level lock status |
| Stack Deny Settings | ? Not applicable | ? Stack-level lock changes |
| Deployment Scope | ? Not applicable | ? Can change deployment scope |

---

## Summary

**Total Models**: 38+ in `Resources.Management.Sdk.Generated.Models`

**For What-If Implementation, you primarily need**:
- **11 core models** for displaying results
- **6 enum models** for constants and comparison
- **6 supporting models** for input parameters and metadata
- **6 header models** for SDK internals (transparent to cmdlet)

**The flow is**:
1. User provides parameters ? `ActionOnUnmanage`, `DenySettings`, `DeploymentParameter`
2. SDK returns ? `DeploymentStacksWhatIfResult`
3. Extract changes ? `result.Properties.Changes` (type: `DeploymentStacksWhatIfChange`)
4. Iterate resources ? `changes.ResourceChanges` (type: `IList<DeploymentStacksWhatIfResourceChange>`)
5. Display each change ? Use `ChangeType`, `ChangeCertainty`, property changes, status changes
6. Display diagnostics ? `result.Properties.Diagnostics`
7. Display stack changes ? `changes.DenySettingsChange`, `changes.DeploymentScopeChange`

The key insight is that **Deployment Stacks What-If extends regular deployment what-if** with management tracking (managed/unmanaged) and deny assignment (lock) tracking at both the resource and stack level.
