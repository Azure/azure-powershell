import { McpServer, ResourceTemplate } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { exec } from 'child_process';
import { z } from "zod";
import { g, generateByAutorest } from "./services/tools/utils.js";

// Create server instance
const server = new McpServer({
    name: "codegen",
    version: "1.0.0",
    capabilities: {
      resources: {},
      tools: {},
    },
});

server.tool(
    "generate-autorest",
    "Generate code using autorest",
    {workingDirectory: z.string().describe("absolute path of the README.md where the code will be generated")},
    ({workingDirectory}) => generateByAutorest(workingDirectory),
);

async function main() {
    const transport = new StdioServerTransport();
    await server.connect(transport);
    console.log("Codegen MCP Server running on stdio");
}

main().catch((error) => {
    console.error("Fatal error in main():", error);
    process.exit(1);
})