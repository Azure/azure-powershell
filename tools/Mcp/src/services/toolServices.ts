import { CallToolResult } from '@modelcontextprotocol/sdk/types.js';
import { z, ZodRawShape, ZodType, ZodTypeAny } from "zod";
import * as utils from "./utils.js";
import path from 'path';
import { get } from 'http';

// export const generateByAutorest = <Args extends ZodRawShape>(args: Args): CallToolResult => {
//     const workingDirectory = z.string().parse(Object.values(args)[0]);
//     utils.generateAndBuild(workingDirectory);
//     return {
//         content: [
//             {
//                 type: "text",
//                 text: "##########mcp call completed##########"
//             }
//         ]
//     };
// };

// export const handlePolymorphism = async <Args extends ZodRawShape>(args: Args): Promise<CallToolResult> => {
//     const workingDirectory = z.string().parse(Object.values(args)[0]);
//     const polymorphism = await utils.findAllPolyMorphism(workingDirectory);
//     const polyArr: [string, string[]][] = Array.from(polymorphism, ([key, valueSet]) => [key, Array.from(valueSet)]);
//     const parents = Array.from(polymorphism.keys());
//     const children = Array.from(polymorphism.values()).map(set => Array.from(set)).flat();

//     return {
//         content: [
//             {
//                 type: "text",
//                 text: `1. Call MCP tool 'no-inline' for each parent: ${parents}. 2. Call MCP tool 'model-cmdlet' for each child: ${children}, create cmdlet to create each child. 3. Call tool 'insert_edit_into_file' to add these directives to README.md under ${workingDirectory}, make sure directives are inside the yaml block. 4. regenerate code using autorest.`
//             }
//         ]
//     };
// }

// export const handleNoInline = async <Args extends ZodRawShape>(args: Args): Promise<CallToolResult> => {
//     const modelNames = z.array(z.string()).parse(Object.values(args)[0]);
//     const response = z.string().parse(Object.values(args).at(-1));
//     return {
//         content: [
//             {
//                 type: "text",
//                 text: `Add no-inline directives for models: ${modelNames}. Please update README.md with the no-inline directive for each model.`
//             }
//         ]
//     };
// }

// export const handleModelCmdlet = async <Args extends ZodRawShape>(args: Args): Promise<CallToolResult> => {
//     const modelNames = z.array(z.string()).parse(Object.values(args)[0]);
//     return {
//         content: [
//             {
//                 type: "text",
//                 text: `Add model-cmdlet directives for models: ${modelNames}. Please update README.md with the model-cmdlet directive for each model.`
//             }
//         ]
//     };
// }

// export const toolServices = <Args extends ZodRawShape>(name: string, responseTemplate: string|undefined) => {
//     switch (name) {
//         case "generateByAutorest":
//             return generateByAutorest<Args>;
//         case "handlePolymorphism":
//             return handlePolymorphism<Args>;
//         // case "handleNoInline":
//         //     return handleNoInline<Args>;
//         case "handleNoInline":
//             return constructCallback<Args>(handleNoInline, responseTemplate);
//         case "handleModelCmdlet":
//             return handleModelCmdlet<Args>;
//         default:
//             throw new Error(`Tool ${name} not found`);
//     }
// }

export const generateByAutorest = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
    const workingDirectory = z.string().parse(Object.values(args)[0]);
    utils.generateAndBuild(workingDirectory);
    return [workingDirectory];
};

export const handlePolymorphism = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
    const workingDirectory = z.string().parse(Object.values(args)[0]);
    const polymorphism = await utils.findAllPolyMorphism(workingDirectory);
    const polyArr: [string, string[]][] = Array.from(polymorphism, ([key, valueSet]) => [key, Array.from(valueSet)]);
    const parents = Array.from(polymorphism.keys());
    const children = Array.from(polymorphism.values()).map(set => Array.from(set)).flat();
    return [parents.join(', '), children.join(', '), workingDirectory];
}

export const handleNoInline = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
    const modelNames = z.array(z.string()).parse(Object.values(args)[0]);
    return [modelNames.join(', ')];
}

export const handleModelCmdlet = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
    const modelNames = z.array(z.string()).parse(Object.values(args)[0]);
    return [modelNames.join(', ')];
}

export const createExamplesFromSpecs = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
    const workingDirectory = z.string().parse(Object.values(args)[0]);
    const examplePath = path.join(workingDirectory, "examples");
    const exampleSpecsPath = await utils.getExamplesFromSpecs(workingDirectory);
    return [examplePath, exampleSpecsPath];
}

export const createTestsFromSpecs = async <Args extends ZodRawShape>(args: Args): Promise<string[]> => {
    const workingDirectory = z.string().parse(Object.values(args)[0]);
    const testPath = path.join(workingDirectory, "test");
    const exampleSpecsPath = await utils.getExamplesFromSpecs(workingDirectory);
    return [testPath, exampleSpecsPath];
}

export const toolServices = <Args extends ZodRawShape>(name: string, responseTemplate: string|undefined) => {
    let func;
    switch (name) {
        case "generateByAutorest":
            func = generateByAutorest<Args>;
            break;
        case "handlePolymorphism":
            func = handlePolymorphism<Args>;
            break;
        case "handleNoInline":
            func = handleNoInline<Args>;
            break;
        case "handleModelCmdlet":
            func = handleModelCmdlet<Args>;
            break;
        case "createExamplesFromSpecs":
            func = createExamplesFromSpecs<Args>;
            break;
        case "createTestsFromSpecs":
            func = createTestsFromSpecs<Args>;
            break;
        default:
            throw new Error(`Tool ${name} not found`);
    }
    return constructCallback<Args>(func, responseTemplate);
}

const constructCallback = <Args extends ZodRawShape>(fn: (arr: Args) => Promise<string[]>, responseTemplate: string|undefined): (args: Args) => Promise<CallToolResult> => {
    return async (args: Args): Promise<CallToolResult> => {
        const argsArray = await fn(args);
        const response = getResponseString(argsArray, responseTemplate) ?? "";
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

function getResponseString(args: string[], responseTemplate: string|undefined): string|undefined {
    if (!args || args.length === 0) {
        return responseTemplate;
    }
    let response = responseTemplate;;
    for (let i = 0; i < args.length; i++) {
        response = response?.replaceAll(`{${i}}`, args[i]);
    }
    return response
}