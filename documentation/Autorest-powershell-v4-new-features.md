# Autorest PowerShell V4 Features from the End Users' Perspective

## 1. Support for piping parent object: 
    This allows users to pipe parent objects into cmdlets, simplifying commands. 

## 2. Progress bar for long running operations:
    Users will see a visual indicator during long operations. Important to note it's just visual, no impact on functionality. 

## 3. Auto completer for enum parameters: 
    Enums are now strings with tab completion. Users can still tab through possible values, which is more flexible. 

## 4. Switch between table and list views: 
    Automatically changes based on the number of results. Single result shows detailed list, multiple show concise table. 

## 5. ExternalDocs in help: 
    Adds links to external documentation directly in the cmdlet help. Helps users find more info easily. 

## 6. Non-fixed size arrays: 
    Now lists instead of fixed arrays, making it easier to add elements. Simplifies scripting. 

## 7. Removal of API version from namespace: 
    More consistent naming in generated code, but users probably won't notice unless they work with the code directly. 

## 8. JSON import for resources: 
    Users can create resources via JSON files or strings. Provides flexibility, especially for complex configurations. 

## 9. x-ms-mutability support: 
    Better handling of create vs update operations based on HTTP methods. Helps ensure correct cmdlet usage. 

## 10. Managed Identity alignment: 
    Changes parameter types for identity settings. Users need to adjust to new parameter names and types (switch parameters for enabling, string arrays for identities). 

## 11. Retry policies: 
    Automatically retries on certain errors. Users benefit from increased reliability. Can configure via environment variables. 

## 12. Update via GET and PUT: 
    For resources without PATCH, updates use GET then PUT. Might affect performance but ensures compatibility. Conflicts possible, so mention the disable option. 

## 13. Discriminator parameter hidden: 
    Removes redundant parameters in model cmdlets, making them cleaner. Users won't have to input fixed values. 
