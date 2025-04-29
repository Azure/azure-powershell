import { z, ZodRawShape, ZodTypeAny } from "zod";
import { ToolCallback } from "@modelcontextprotocol/sdk/server/mcp.js";
import { parameter, toolSchema } from "../types.js";

export class McpTool {
    private _name: string = undefined;
    private _description: string = undefined;
    private _parameters: ZodRawShape = undefined;
    private _callback: ToolCallback<ZodRawShape> = undefined;

    private constructor() {}

    public createToolFromSchema(schema: toolSchema) {
        const _tool = new McpTool();

        _tool._name = schema.name;
        _tool._description = schema.description;
        
        const param = schema.parameters as parameter[];
        
    }
}

// const getCallBack = <Args extends ZodRawShape>(callbackName: string, parameters: Args): ToolCallback<Args> => {
//     const args = Object.keys(parameters).map((key) => {
//         const value = parameters[key as keyof Args];
//         return { key: value };
//     }) as z.objectOutputType<Args, ZodTypeAny>[];
// }