import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";

export class CodegenServer {
    private static _instance: CodegenServer;
    private _mcp: McpServer;

    private constructor() {
        this._mcp = new McpServer({
            name: "codegen",
            version: "1.0.0",
            capabilities: {
                resources: {},
                tools: {},
            },
        });
    }

    private init(): void {
        
    }

    public static getInstance(): CodegenServer {
        if (!CodegenServer._instance) {
            CodegenServer._instance = new CodegenServer();
        }
        return CodegenServer._instance;
    }

    public async connect(transport: StdioServerTransport): Promise<void> {
        await this._mcp.connect(transport);
    }
}