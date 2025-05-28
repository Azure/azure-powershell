import { CallToolResult } from '@modelcontextprotocol/sdk/types.js';
import { z, ZodRawShape, ZodType, ZodTypeAny } from "zod";
import * as utils from "./utils.js";
import path from 'path';
import { get } from 'http';

export const generateByAutorest = <Args extends ZodRawShape>(args: Args): CallToolResult => {
    const workingDirectory = z.string().parse(Object.values(args)[0]);
    utils.generateAndBuild(workingDirectory);
    return {
        content: [
            {
                type: "text",
                text: "##########mcp call completed##########"
            }
        ]
    };
};

export const handlePolymorphism = async <Args extends ZodRawShape>(args: Args): Promise<CallToolResult> => {
    const workingDirectory = z.string().parse(Object.values(args)[0]);
    const polymorphism = await utils.findAllPolyMorphism(workingDirectory);
    const polyArr: [string, string[]][] = Array.from(polymorphism, ([key, valueSet]) => [key, Array.from(valueSet)]);
    const parents = Array.from(polymorphism.keys());
    const children = Array.from(polymorphism.values()).map(set => Array.from(set)).flat();

    return {
        content: [
            {
                type: "text",
                text: `1. Call MCP tool 'no-inline' for each parent: ${parents}. 2. Call MCP tool 'model-cmdlet' for each child: ${children}, create cmdlet to create each child. 3. Call tool 'insert_edit_into_file' to add these directives to README.md under ${workingDirectory}, make sure directives are inside the yaml block. 4. regenerate code using autorest.`
            }
        ]
    };
}

export const handleNoInline = async <Args extends ZodRawShape>(args: Args): Promise<CallToolResult> => {
    const modelNames = z.array(z.string()).parse(Object.values(args)[0]);
    const response = z.string().parse(Object.values(args).at(-1));
    return {
        content: [
            {
                type: "text",
                text: `Add no-inline directives for models: ${modelNames}. Please update README.md with the no-inline directive for each model.`
            }
        ]
    };
}

export const handleModelCmdlet = async <Args extends ZodRawShape>(args: Args): Promise<CallToolResult> => {
    const modelNames = z.array(z.string()).parse(Object.values(args)[0]);
    return {
        content: [
            {
                type: "text",
                text: `Add model-cmdlet directives for models: ${modelNames}. Please update README.md with the no-inline directive for each model.`
            }
        ]
    };
}

export const toolServices = <Args extends ZodRawShape>(name: string) => {
    switch (name) {
        case "generateByAutorest":
            return generateByAutorest<Args>;
        case "handlePolymorphism":
            return handlePolymorphism<Args>;
        case "handleNoInline":
            return handleNoInline<Args>;
        case "handleModelCmdlet":
            return handleModelCmdlet<Args>;
        default:
            throw new Error(`Tool ${name} not found`);
    }
}

const constructCallback = <Args extends ZodRawShape>(fn: (arr: ZodTypeAny) => string[]): (args: Args) => Promise<CallToolResult> => {
    return async (args: Args): Promise<CallToolResult> => {
        const [argsRaw, responseRaw] = getArgsAndResponse(args);
        const argsArray = fn(argsRaw);
        const response = getResponseString(argsArray, z.string().parse(responseRaw));
        return {
            content: [
                {
                    type: "text",
                    text: response
                }
            ]
        };
    };
}

function getArgsAndResponse<Args extends ZodRawShape>(args: Args): [ZodTypeAny, ZodType]  {
    const {argsArr, ['response']:response} = args
    return [argsArr, response];
}

function getResponseString(args: string[], response: string): string {
    if (args.length === 0) {
        return response;
    }
    for (let i = 0; i < args.length; i++) {
        response = response.replace(`{${i}}`, args[i]);
    }
    return response
}