import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
import { responseSchema, toolParameterSchema, toolSchema } from "./types.js";
import { ToolsService } from "./services/toolsService.js";
import { readFileSync } from "fs";
import path from "path";
import { fileURLToPath } from "url";
import { RequestOptions } from "https";
import { ElicitRequest, ElicitResult } from "@modelcontextprotocol/sdk/types.js";

const __dirname = path.dirname(fileURLToPath(import.meta.url));
const srcPath = path.resolve(__dirname, "..", "src");

const specs = JSON.parse(readFileSync(path.join(srcPath, "specs/specs.json"), "utf-8"));
const responses = JSON.parse(readFileSync(path.join(srcPath, "specs/responses.json"), "utf-8"));

export class CodegenServer {
    private static _instance: CodegenServer;
    private _mcp: McpServer;
    private _responses = new Map<string, string>();

    private constructor() {
        this._mcp = new McpServer({
            name: "codegen",
            version: "1.0.0",
            capabilities: {
                resources: {},
                tools: {},
                prompts: {}
            },
        });
    }

    init(): void {
        this.initResponses();
        this.initTools();
        this.initPrompts();
    }

    // dummy method for sending sampling request
    public createMessage() {
        return this._mcp.server.createMessage({
            messages: [
                {
                    role: "user",
                    content: {
                        type: "text",
                        text: `This is a test sampling request`,
                    },
                },
            ],
            maxTokens: 500
        });
    }

    // server elicitation request
    public elicitInput(
        params: ElicitRequest["params"],
        options?: RequestOptions
    ): Promise<ElicitResult> {
        //TODO: add log
        return this._mcp.server.elicitInput(params, options);
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


    initTools() {
        const toolsService = ToolsService.getInstance().setServer(this);
        const toolSchemas = specs.tools as toolSchema[];
        for (const schema of toolSchemas) {
            const parameter = toolsService.createToolParameterfromSchema(schema.parameters);
            const callBack = toolsService.getTools<{ [k: string]: z.ZodTypeAny }>(schema.callbackName, this._responses.get(schema.name));
            this._mcp.tool(
                schema.name,
                schema.description,
                parameter,
                (parameter) => callBack(parameter)
            );
        }
    }

    initPrompts() {
        this._mcp.prompt(
            "create-greeting", 
            "Generate a customized greeting message", 
            { name: z.string().describe("Name of the person to greet"), style: z.string().describe("The style of greeting, such a formal, excited, or casual. If not specified casual will be used")}, 
            ({ name, style = "casual" }: { name: string, style?: string }) => {
            return {
                messages: [
                    {
                        role: "user",
                        content: {
                            type: "text",
                            text: `Please generate a greeting in ${style} style to ${name}.`,
                        },
                    },
                ],
            };
        });
    }

    initResponses() {
        (responses as responseSchema[])?.forEach((response: responseSchema) => {
            this._responses.set(response.name, response.text);
        });
    }
}
