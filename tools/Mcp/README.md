# Azure PowerShell Codegen MCP Server

A Model Context Protocol (MCP) server that provides tools for generating and managing Azure PowerShell modules using AutoRest. This server helps automate common tasks in the Azure PowerShell code generation process, including handling polymorphism, model directives, and code generation.

## Overview

This MCP server is designed to work with Azure PowerShell module development workflows. It provides specialized tools for:

- **AutoRest Code Generation**: Generate PowerShell modules from OpenAPI specifications
- **Model Management**: Handle model directives like `no-inline` and `model-cmdlet`
- **Polymorphism Support**: Automatically detect and configure polymorphic types
- **YAML Configuration**: Parse and manipulate AutoRest configuration files

## Features

### Available Tools

1. **generate-autorest**
   - Generates PowerShell code using AutoRest
   - Parameters: `workingDirectory` (absolute path to README.md)

2. **no-inline**
   - Converts flattened models to non-inline parameters
   - Parameters: `modelNames` (array of model names to make non-inline)
   - Useful for complex nested models that shouldn't be flattened

3. **model-cmdlet**
   - Creates `New-` cmdlets for specified models
   - Parameters: `modelNames` (array of model names)
   - Generates cmdlets with naming pattern: `New-Az{SubjectPrefix}{ModelName}Object`

4. **polymorphism**
   - Handles polymorphic type detection and configuration
   - Parameters: `workingDirectory` (absolute path to README.md)
   - Automatically identifies parent-child type relationships

### Available Prompts

- **create-greeting**: Generate customized greeting messages (example prompt)

## Installation

1. Clone or download this repository
2. Install dependencies:
   ```bash
   npm install
   ```
3. Build the TypeScript code:
   ```bash
   npm run build
   ```

## Usage

### Add as mcp server in Github Copilot Agent mode

- Ensure `pwsh` & `npm` is installed globally.
- Simply add this mcp server to your workspace settings `.vscode/mcp.json` in VsCode to include:

```json
{
    "inputs": [],
    "servers": {
        "az-pwsh-mcp-server": {
            "type": "stdio",
            "command": "pwsh",
            "args": ["-Command", "npm install --no-audit; npm run fresh"],
            "cwd": "${workspaceFolder}/tools/Mcp",
        }
    }
}
```

### As an MCP Server

The server runs on stdio and can be integrated with MCP-compatible clients:

```bash
node build/index.js
```

### Direct Integration

You can also use the server programmatically:

```typescript
import { CodegenServer } from './src/CodegenServer.js';
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

const server = CodegenServer.getInstance();
server.init();
const transport = new StdioServerTransport();
await server.connect(transport);
```

## Configuration

The server uses JSON configuration files for tool definitions:

- `src/specs/specs.json`: Tool specifications and parameters
- `src/specs/responses.json`: Response templates for tools

## Example Workflow

1. **Detect Polymorphism**: Use the `polymorphism` tool to identify parent-child type relationships
2. **Configure Models**: Apply `no-inline` directives for parent types
3. **Create Cmdlets**: Use `model-cmdlet` to generate creation cmdlets for child types
4. **Generate Code**: Run `generate-autorest` to build the PowerShell module

## Development

### Project Structure

```
src/
├── CodegenServer.ts       # Main MCP server implementation
├── index.ts              # Entry point
├── types.ts              # TypeScript type definitions
├── services/
│   ├── toolServices.ts   # Tool implementation logic
│   ├── utils.ts          # Utility functions
│   └── ...
└── specs/
    ├── specs.json        # Tool specifications
    └── responses.json    # Response templates
```

### Building

```bash
npm run build
```

This compiles TypeScript files to the `build/` directory.

## Dependencies

- **@modelcontextprotocol/sdk**: Core MCP functionality
- **js-yaml**: YAML parsing for AutoRest configuration
- **zod**: Runtime type validation and schema definition

## Requirements

- Node.js (ES modules support)
- TypeScript 5.8+
- AutoRest (for code generation functionality)

## License

ISC

## Contributing

This tool is part of the Azure PowerShell project and follows the same contribution guidelines. Please ensure all changes maintain compatibility with the existing Azure PowerShell development workflow.

## Related Projects

- [Azure PowerShell](https://github.com/Azure/azure-powershell)
- [AutoRest](https://github.com/Azure/autorest)
- [AutoRest PowerShell Extension](https://github.com/Azure/autorest.powershell)
- [Model Context Protocol](https://modelcontextprotocol.io)
