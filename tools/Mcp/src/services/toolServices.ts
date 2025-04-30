import { CallToolResult } from '@modelcontextprotocol/sdk/types.js';
import { exec } from 'child_process';
import { z, ZodRawShape } from "zod";

const _pwshCD = (path: string): string => { return `pwsh -Command "$path = resolve-path ${path} | Set-Location"` }
const _autorest = "autorest --reset; autorest"
const _pwshBuild = "pwsh -File build-module.ps1"

export const generateByAutorest = <Args extends ZodRawShape>(args: Args): CallToolResult => {
    const workingDirectory = z.string().parse(Object.values(args)[0]);
    const command = [_pwshCD(workingDirectory), _autorest, _pwshBuild].join(";");
    exec(command);
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