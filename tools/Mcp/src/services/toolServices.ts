import { CallToolResult } from '@modelcontextprotocol/sdk/types.js';
import { z, ZodRawShape } from "zod";
import * as utils from "./utils.js";

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

export const toolServices = <Args extends ZodRawShape>(name: string) => {
    switch (name) {
        case "generateByAutorest":
            return generateByAutorest<Args>;
        default:
            throw new Error(`Tool ${name} not found`);
    }
}