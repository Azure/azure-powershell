import { McpServer } from "@modelcontextprotocol/sdk/server/mcp.js";
import { StdioServerTransport } from "@modelcontextprotocol/sdk/server/stdio.js";
import { z } from "zod";
import { responseSchema, toolParameterSchema, toolSchema, promptSchema, resourceSchema } from "./types.js";
import { ToolsService } from "./services/toolsService.js";
import { PromptsService } from "./services/promptsService.js";
import { ResourcesService } from "./services/resourcesService.js";
import { readFileSync } from "fs";
import path from "path";
import { fileURLToPath } from "url";
import { RequestOptions } from "https";
import { ElicitRequest, ElicitResult } from "@modelcontextprotocol/sdk/types.js";
import { logger } from "./services/logger.js";

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
        this.initResources();
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

    public getResponseTemplate(name: string): string | undefined {
        return this._responses.get(name);
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
        const promptsService = PromptsService.getInstance().setServer(this);
        const promptsSchemas = (specs.prompts || []) as promptSchema[];
        for (const schema of promptsSchemas) {
            const parameter = promptsService.createPromptParametersFromSchema(schema.parameters);
            const callback = promptsService.getPrompts(schema.callbackName, this._responses.get(schema.name));
            this._mcp.prompt(
                schema.name,
                schema.description,
                parameter,
                async (args: any) => {
                    const correlationId = `${schema.name}-${Date.now()}-${Math.random().toString(16).slice(2,8)}`;
                    logger.debug('Prompt started', { prompt: schema.name, correlationId });
                    try {
                        const result = await callback(args);
                        logger.info('Prompt completed', { prompt: schema.name, correlationId });
                        return result;
                    } catch (err: any) {
                        logger.error('Prompt failed', { prompt: schema.name, correlationId }, err);
                        throw err;
                    }
                }
            );
        }
    }

    initResources() {
        const resourcesService = ResourcesService.getInstance().setServer(this);
        const resourcesSchemas = (specs.resources || []) as resourceSchema[];
        for (const schema of resourcesSchemas) {
            const parameter = resourcesService.createResourceParametersFromSchema(schema.parameters || []);
            const callback = resourcesService.getResources(schema.callbackName, this._responses.get(schema.name));
            this._mcp.resource(
                schema.name,
                schema.description,
                parameter,
                async (args: any) => {
                    const correlationId = `${schema.name}-${Date.now()}-${Math.random().toString(16).slice(2,8)}`;
                    logger.debug('Resource requested', { resource: schema.name, correlationId });
                    try {
                        const result = await callback(args);
                        logger.info('Resource provided', { resource: schema.name, correlationId });
                        return result;
                    } catch (err: any) {
                        logger.error('Resource failed', { resource: schema.name, correlationId }, err);
                        throw err;
                    }
                }
            );
        }
    }

    initResponses() {
        (responses as responseSchema[])?.forEach((response: responseSchema) => {
            let text = response.text;
            if (text.startsWith("@file:")) {
                const relPath = text.replace("@file:", "");
                const absPath = path.join(srcPath, relPath);
                try {
                    text = readFileSync(absPath, "utf-8");
                } catch (e: any) {
                    logger.error(`Failed to load prompt file`, { absPath }, e as Error);
                }
            }
            this._responses.set(response.name, text);
        });
    }


}
