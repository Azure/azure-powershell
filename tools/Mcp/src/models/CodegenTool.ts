import { z, ZodRawShape, ZodTypeAny } from "zod";
import { ToolCallback } from "@modelcontextprotocol/sdk/server/mcp.js";
import { toolParameterSchema, toolSchema } from "../types.js";
import { toolServices } from "../services/toolServices.js";

export class CodegenTool<Args extends ZodRawShape> {
    name: string;
    description: string;
    parameter: ZodRawShape;
    callback: ToolCallback<ZodRawShape>;

    private constructor(schema: toolSchema) {
        this.name = schema.name;
        this.description = schema.description;
        this.parameter = this.createParameterfromSchema(schema.parameters);
        const callback = toolServices<Args>(schema.callbackName);
    }

    private createParameterfromSchema(schemas: toolParameterSchema[]): ZodRawShape {
        const parameter: ZodRawShape = {}; 
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

// const getCallBack = <Args extends ZodRawShape>(callbackName: string, parameters: Args): ToolCallback<Args> => {
//     const args = Object.keys(parameters).map((key) => {
//         const value = parameters[key as keyof Args];
//         return { key: value };
//     }) as z.objectOutputType<Args, ZodTypeAny>[];
// }