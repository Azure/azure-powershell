import { z, ZodRawShape } from "zod";
import { promptSchema, promptParameterSchema } from "../types.js";
import { CodegenServer } from "../CodegenServer.js";


export class PromptsService {
    private static _instance: PromptsService;
    private _server: CodegenServer | null = null;
    private constructor() {}

    static getInstance(): PromptsService {
        if (!PromptsService._instance) {
            PromptsService._instance = new PromptsService();
        }
        return PromptsService._instance;
    }

    setServer(server: CodegenServer): PromptsService {
        this._server = server;
        return this;
    }

    getPrompts<Args extends ZodRawShape>(name: string, responseTemplate: string | undefined) {
        let func;
        switch (name) {
            case "createGreetingPrompt":
                func = this.createGreetingPrompt<Args>;
                break;
            case "createPartnerModuleWorkflow":
                func = this.createPartnerModuleWorkflow<Args>;
                break;
            default:
                throw new Error(`Prompt ${name} not found`);
        }
        return this.constructCallback<Args>(func, responseTemplate);
    }

    constructCallback<Args extends ZodRawShape>(fn: (arr: Args) => Promise<string[]>, responseTemplate: string | undefined) {
        return async (args: Args) => {
            const argsArray = await fn(args);
            const response = this.getResponseString(argsArray, responseTemplate) ?? "";
            return {
                messages: [
                    {
                        role: "user" as const,
                        content: {
                            type: "text" as const,
                            text: response
                        }
                    }
                ]
            };
        };
    }

    getResponseString(args: string[], responseTemplate: string | undefined): string | undefined {
        if (!args || args.length === 0) {
            return responseTemplate;
        }
        let response = responseTemplate;
        for (let i = 0; i < args.length; i++) {
            response = response?.replaceAll(`{${i}}`, args[i]);
        }
        return response;
    }

    createPromptParametersFromSchema(schemas: promptParameterSchema[]) {
        const parameter: { [k: string]: any } = {};
        for (const schema of schemas) {
            const base = schema.optional ? z.any().optional() : z.any();
            switch (schema.type) {
                case "string":
                    parameter[schema.name] = (schema.optional ? z.string().optional() : z.string()).describe(schema.description);
                    break;
                case "number":
                    parameter[schema.name] = (schema.optional ? z.number().optional() : z.number()).describe(schema.description);
                    break;
                case "boolean":
                    parameter[schema.name] = (schema.optional ? z.boolean().optional() : z.boolean()).describe(schema.description);
                    break;
                case "array":
                    parameter[schema.name] = (schema.optional ? z.array(z.string()).optional() : z.array(z.string())).describe(schema.description);
                    break;
                default:
                    throw new Error(`Unsupported parameter type: ${schema.type}`);
            }
        }
        return parameter;
    }

    // prompt implementations
    createGreetingPrompt = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        const values = Object.values(args);
        const name = values[0] as unknown as string; // required
        const style = (values[1] as unknown as string) || "casual"; // optional fallback
        return [name, style];
    };


    createPartnerModuleWorkflow = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
        const { } = args as any;
        return [];
    };
}
