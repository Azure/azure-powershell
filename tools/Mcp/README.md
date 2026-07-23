# Azure PowerShell Codegen MCP Server

A Model Context Protocol (MCP) server that provides tools for generating and managing Azure PowerShell modules using AutoRest. It now also orchestrates help‑driven example generation, CRUD test scaffolding, and an opinionated partner workflow to keep outputs deterministic and consistent.

## Overview

This MCP server is designed to work with Azure PowerShell module development workflows. It provides specialized tools for:

- **Module Scaffolding**: Interactive selection of service → provider → API version and creation of the `<ModuleName>.Autorest` structure
- **AutoRest Code Generation**: Generate PowerShell modules from OpenAPI specifications (reset/generate/build sequence)
- **Example Generation**: Create example scripts from swagger example JSON while filtering strictly to parameters documented in help markdown
- **Test Generation**: Produce per‑resource CRUD test files (idempotent, includes negative test) using the same help‑driven parameter filtering
- **Help‑Driven Parameter Filtering**: Only parameters present in the generated help (`/src/<Module>/help/*.md`) are allowed in examples/tests
- **Model Management**: Handle model directives like `no-inline` and `model-cmdlet`
- **Polymorphism Support**: Automatically detect and configure parent/child discriminator relationships
- **YAML Configuration Utilities**: Parse and manipulate AutoRest configuration blocks
- **Partner Workflow Prompt**: A single prompt that encodes the end‑to‑end deterministic workflow

## Features

### Available Tools

1. **setup-module-structure**
   - Interactive service → provider → API version selection and module name capture
   - Scaffolds `src/<Module>/<Module>.Autorest/` plus initial `README.md`
   - Output placeholder `{0}` = module name

2. **generate-autorest**
   - Executes Autorest reset, generate, and PowerShell build steps within the given working directory
   - Parameters: `workingDirectory` (absolute path to the Autorest folder containing README.md)
   - Output placeholder `{0}` = working directory

3. **create-example**
   - Downloads swagger example JSON, filters parameters to those documented in help markdown (`/src/<Module>/help/<Cmdlet>.md`), and writes example scripts under `examples/`
   - Parameters: `workingDirectory`
   - Output placeholders: `{0}` = harvested specs path, `{1}` = examples dir, `{2}` = reference ideal example dirs

4. **create-test**
   - Generates new `<ResourceName>.Crud.Tests.ps1` files (does not modify stubs) with Create/Get/List/Update/Delete/Negative blocks, using help‑filtered parameters
   - Parameters: `workingDirectory`
   - Output placeholders: `{0}` = harvested specs path, `{1}` = test dir, `{2}` = reference ideal test dirs

5. **polymorphism**
   - Detects discriminator parents and child model names to aid directive insertion
   - Parameters: `workingDirectory`
   - Output placeholders: `{0}` = parents, `{1}` = children, `{2}` = working directory

6. **no-inline**
   - Lists models to be marked `no-inline` (caller inserts directive into README Autorest YAML)
   - Parameters: `modelNames` (array)
   - Output `{0}` = comma-separated model list

7. **model-cmdlet**
   - Lists models for which `New-` object construction cmdlets should be added via directives
   - Parameters: `modelNames` (array)
   - Output `{0}` = comma-separated model list

### Available Prompts

- **partner-module-workflow**: Canonical end‑to‑end instruction set (module structure → generation → examples → tests → regeneration)
- **create-greeting**: Sample/demo greeting prompt

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

## Contributing

This tool is part of the Azure PowerShell project and follows the same contribution guidelines. Please ensure all changes maintain compatibility with the existing Azure PowerShell development workflow.

## Related Projects

- [Azure PowerShell](https://github.com/Azure/azure-powershell)
- [AutoRest](https://github.com/Azure/autorest)
- [AutoRest PowerShell Extension](https://github.com/Azure/autorest.powershell)
- [Model Context Protocol](https://modelcontextprotocol.io)
