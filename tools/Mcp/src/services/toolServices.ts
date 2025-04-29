import { exec } from 'child_process';
import { z } from "zod";
import { CallToolResult } from '@modelcontextprotocol/sdk/types.js';

const _pwshCD = (path: string): string => { return `pwsh -Command "$path = resolve-path ${path} | Set-Location"` }
const _autorest = "autorest --reset; autorest"
const _pwshBuild = "pwsh -File build-module.ps1"

export const generateByAutorest = (workingDirectory: string) => {
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

// export const toolServices = (name: string, ...args: any): CallToolResult => {
//     switch (name) {
//         case "generateByAutorest":
//             return generateByAutorest(...args);
//         default:
//             throw new Error(`Tool ${name} not found`); 
//     }
// }