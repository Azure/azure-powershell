import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
import { responseSchema, toolParameterSchema, toolSchema } from "./types.js";
import { toolServices } from "./services/toolServices.js";

import { readFileSync } from "fs";
import path from "path";
import { fileURLToPath } from "url";

const __dirname = path.dirname(fileURLToPath(import.meta.url));
const srcPath = path.resolve(__dirname, "..", "src");

const specs = JSON.parse(readFileSync(path.join(srcPath, "specs/specs.json"), "utf-8"));
const responses = JSON.parse(readFileSync(path.join(srcPath, "specs/responses.json"), "utf-8"));

export class CodegenServer {
    private static _instance: CodegenServer;
    private _server: McpServer;
    private _responses = new Map<string, string>();

    private constructor() {
        this._server = new McpServer({
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
        this.readResponses();
        this.initTools();
        this.initPrompts();
    }

    /**
     * Singleton instance of CodegenServer
     * @returns {CodegenServer} The singleton instance
     */
    public static getInstance(): CodegenServer {
        if (!CodegenServer._instance) {
            CodegenServer._instance = new CodegenServer();
        }
        return CodegenServer._instance;
    }

    /**
     * Connects the server to a transport layer
     * @param {StdioServerTransport} transport - The transport layer to connect to
     * @returns {Promise<void>} A promise that resolves when the connection is established
     */
    public async connect(transport: StdioServerTransport): Promise<void> {
        await this._server.connect(transport);
    }

    readResponses() {
        (responses as responseSchema[])?.forEach((response: responseSchema) => {
            this._responses.set(response.name, response.text);
        });
    }

    /**
     * Creates tool parameters from the provided schema
     * @param {toolParameterSchema[]} schemas - The schemas to create parameters from
     * @returns {Object} An object containing the created parameters
     */
    createToolParameterfromSchema(schemas: toolParameterSchema[]){
        const parameter: {[k: string]: z.ZodTypeAny} = {}; 
        for (const schema of schemas) {
            switch (schema.type) {
                case "string":
                    parameter[schema.name] = z.string().describe(schema.description);
                    break;
                case "number":
                    parameter[schema.name] = z.number().describe(schema.description);
                    break;
                case "boolean": 
                parameter[schema.name] = z.boolean().describe(schema.description);
                    break;
                case "array":
                    parameter[schema.name] = z.array(z.string()).describe(schema.description);
                    break;
                // object parameter not supported yet    
                // case "object":
                //     parameter[schema.name] = z.object({}).describe(input.description); // Placeholder for object type
                //     break;
                default:
                    throw new Error(`Unsupported parameter type: ${schema.type}`);
            }
        }
        return parameter;
    }

    /**
     * Initializes the prompts for the server
     * This method registers a prompt for generating a customized greeting message.
     */
    initPrompts() {
        this._server.prompt(
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

    /**
     * Initializes the tools for the server
     * This method registers tools based on the provided specifications.
     */
    initTools() {
        const toolSchemas = specs.tools as toolSchema[];
        for (const schema of toolSchemas) {
            const parameter = this.createToolParameterfromSchema(schema.parameters);
            const callBack = toolServices<{ [k: string]: z.ZodTypeAny }>(schema.callbackName, this._responses.get(schema.name));
            this._server.tool(
                schema.name,
                schema.description,
                parameter,
                (parameter) => callBack(parameter)
            );
        }
    }

}