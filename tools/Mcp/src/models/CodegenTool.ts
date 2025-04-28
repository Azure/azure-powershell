import { z, ZodRawShape, ZodTypeAny } from "zod";
import { ToolCallback } from "@modelcontextprotocol/sdk/server/mcp.js";
import { toolServices } from "../services/toolServices.js";

export class McpTool<Args extends ZodRawShape> {
    private _name: string;
    private _description: string;
    private _parameters: Args;
    private _callbackname: string;
    private _callback: ToolCallback<Args>;

    constructor(name: string, description: string, parameters: Args, callbackname: string) {
        this._name = name;
        this._description = description;
        this._parameters = parameters;
        const tmp = getCallBack(callbackname, parameters);
    }
}

const getCallBack = <Args extends ZodRawShape>(callbackName: string, parameters: Args): ToolCallback<Args> => {
    const args = Object.keys(parameters).map((key) => {
        const value = parameters[key as keyof Args];
        return { key: value };
    }) as z.objectOutputType<Args, ZodTypeAny>[];
}

const tool = new McpTool('name', 'description', {workingdirectory: z.string()}, 'callbackname');