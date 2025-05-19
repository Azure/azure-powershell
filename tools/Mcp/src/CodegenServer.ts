import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
import { toolParameterSchema, toolSchema } from "./types.js";
import specs from "./specs/Specs.json" assert { type: "json" };
import { toolServices } from "./services/toolServices.js";

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
                prompts: {}
            },
        });
    }

    init(): void {
        this.initTools();
        this.initPrompts();
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
        const toolSchemas = specs.tools as toolSchema[];
        for (const schema of toolSchemas) {
            const parameter = this.createToolParameterfromSchema(schema.parameters);
            const callBack = toolServices<{ [k: string]: z.ZodTypeAny }>(schema.callbackName);
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
}