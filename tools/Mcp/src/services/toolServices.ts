import { CallToolResult } from '@modelcontextprotocol/sdk/types.js';
import { z, ZodRawShape } from "zod";
import * as utils from "./utils.js";
import path from 'path';

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

    const polymorphism = new Map<string, Set<string>>();

    const moduleReadmePath = path.join(workingDirectory, "README.md");
    const readmeContent = utils.getYamlContentFromReadMe(moduleReadmePath);
    const swaggerUrls = utils.getSwaggerUrl(readmeContent.commit, readmeContent['input-file'] as string[]);
    for (const url of swaggerUrls) {
        const definitions = (await utils.getSwaggerContentFromUrl(url))['definitions'];    
        for (const key of Object.keys(definitions)) {
            if (!definitions[key]['x-ms-discriminator-value']) {
                continue;
            }
            const parent = definitions[key]['allOf']?.[0]['$ref']?.split('/').pop();
            if (!polymorphism.has(parent)) {
                polymorphism.set(parent, new Set<string>());
            }
            polymorphism.get(parent)?.add(key);
        }
    }
    const parents = Array.from(polymorphism.keys());
    const children = Array.from(polymorphism.values()).map(set => Array.from(set)).flat();

    return {
        content: [
            {
                type: "text",
                text: `call tool no-inline for each parent: ${parents}. And call tool model-cmdlet for each children: ${children}`
            }
        ]
    };
}

export const writeDirective = <Args extends ZodRawShape>(args: Args): CallToolResult => {
    //const directive = z.string().parse(args);
    const directive = Object.values(args)[0];
    return {
        content: [
            {
                type: "text",
                text: `${directive}`
            }
        ]
    };
}

export const toolServices = <Args extends ZodRawShape>(name: string) => {
    switch (name) {
        case "generateByAutorest":
            return generateByAutorest<Args>;
        case "writeDirective":
            return writeDirective<Args>;
        case "handlePolymorphism":
            return handlePolymorphism<Args>;
        default:
            throw new Error(`Tool ${name} not found`);
    }
}