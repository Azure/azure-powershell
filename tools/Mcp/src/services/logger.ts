/*
 * Lightweight structured logger for the MCP Codegen server.
 *
 * Design goals:
 *  - Never emit on stdout (protocol channel) – only stderr.
 *  - Optional JSON line format for machine ingest (set MCP_LOG_JSON=1).
 *  - Human readable fallback when MCP_LOG_JSON not enabled.
 *  - Log levels with env control (MCP_LOG_LEVEL: debug|info|warn|error).
 *  - Daily rotating file output stored under tools/Mcp/.logs (gitignored).
 *  - Minimal runtime overhead when level filters out the message.
 */
/* NOTE: This file has been updated to support daily file rotation logging. */

export type LogLevel = 'debug' | 'info' | 'warn' | 'error';

const LEVEL_ORDER: Record<LogLevel, number> = {
  debug: 10,
  info: 20,
  warn: 30,
  error: 40,
};

let envLevel = (process.env.MCP_LOG_LEVEL || 'info').toLowerCase() as LogLevel;
let activeLevel: LogLevel = ['debug','info','warn','error'].includes(envLevel) ? envLevel : 'info';
let jsonMode = process.env.MCP_LOG_JSON === '1' || process.env.MCP_LOG_JSON === 'true';

let seq = 0; // monotonically increasing sequence number for log correlation

function levelEnabled(_level: LogLevel): boolean {
  return true;
}

function formatTs(d: Date): string {
  return d.toISOString();
}

import fs from 'fs';
import path from 'path';

// In ESM, __dirname is not defined. We deliberately rely on process.cwd(), which
// for the MCP server is expected to be the tools/Mcp directory. This avoids the
// need for fileURLToPath and remains robust when transpiled to build/.
// If the working directory differs, set MCP_LOG_ROOT to override.
const LOG_ROOT = process.env.MCP_LOG_ROOT ? path.resolve(process.env.MCP_LOG_ROOT) : process.cwd();

let currentDateStr: string | null = null;
let logStream: fs.WriteStream | null = null;
const logsDir = path.join(LOG_ROOT, '.logs');

function ensureStream(d: Date) {
  const ds = d.toISOString().slice(0,10); // YYYY-MM-DD
  if (ds !== currentDateStr || !logStream) {
    currentDateStr = ds;
    if (!fs.existsSync(logsDir)) fs.mkdirSync(logsDir, { recursive: true });
    if (logStream) { try { logStream.end(); } catch { /* ignore */ } }
    const file = path.join(logsDir, `${ds}.log`);
    logStream = fs.createWriteStream(file, { flags: 'a', encoding: 'utf-8' });
  }
}

function writeLine(obj: any, fallback: string, ts: Date) {
  ensureStream(ts);
  if (jsonMode) {
    try {
      const ordered = Object.keys(obj).sort().reduce((acc: any, k) => { acc[k] = obj[k]; return acc; }, {} as any);
      logStream!.write(JSON.stringify(ordered) + '\n');
      return;
    } catch { /* fall back */ }
  }
  logStream!.write(fallback + '\n');
}

export interface LogContext {
  // Arbitrary supplemental data – keep it small to avoid stdout noise.
  [k: string]: any;
}

// Timing helpers removed (wall clock timestamps only now)
export interface TimingHandle { end: () => number; startTime: bigint; }
export function startTimer(): TimingHandle { return { startTime: BigInt(0), end: () => 0 }; }

const bufferLimit = 1000;
const ringBuffer: any[] = [];

function baseLog(level: LogLevel, msg: string, ctx?: LogContext, err?: Error) {
  if (!levelEnabled(level)) return;
  const ts = new Date();
  const record: any = {
    seq: ++seq,
    ts: formatTs(ts),
    level,
    msg,
  };
  if (ctx) record.ctx = ctx;
  if (err) record.error = { name: err.name, message: err.message, stack: err.stack };
  ringBuffer.push(record);
  if (ringBuffer.length > bufferLimit) ringBuffer.shift();
  const fallback = `[${record.ts}] [${level.toUpperCase()}] ${msg}` + (ctx ? ` ${JSON.stringify(ctx)}` : '') + (err ? ` error=${err.message}` : '');
  writeLine(record, fallback, ts);
}

function reconfigure(opts: { level?: LogLevel; json?: boolean }) {
  if (opts.level && LEVEL_ORDER[opts.level] !== undefined) {
    activeLevel = opts.level;
  }
  if (typeof opts.json === 'boolean') {
    jsonMode = opts.json;
  }
}

export const logger = {
  get level() { return activeLevel; },
  get jsonMode() { return jsonMode; },
  setLevel(level: LogLevel) { reconfigure({ level }); },
  setJsonMode(json: boolean) { reconfigure({ json }); },
  reconfigure,
  debug: (msg: string, ctx?: LogContext) => baseLog('debug', msg, ctx),
  info: (msg: string, ctx?: LogContext) => baseLog('info', msg, ctx),
  warn: (msg: string, ctx?: LogContext) => baseLog('warn', msg, ctx),
  error: (msg: string, ctx?: LogContext, err?: Error) => baseLog('error', msg, ctx, err),
  timed<T>(label: string, fn: () => Promise<T>, ctx?: LogContext): Promise<T> {
    baseLog('debug', `${label} started`, ctx);
    return fn().then(r => { baseLog('info', `${label} finished`, ctx); return r; })
      .catch(e => { baseLog('error', `${label} failed`, ctx, e as Error); throw e; });
  },
  recent(limit: number = 200) { return ringBuffer.slice(-limit); }
};

// Convenience wrapper for synchronous code blocks.
export function timedSync<T>(label: string, fn: () => T, ctx?: LogContext): T {
  baseLog('debug', `${label} started`, ctx);
  try {
    const result = fn();
    baseLog('info', `${label} finished`, ctx);
    return result;
  } catch (err: any) {
    baseLog('error', `${label} failed`, ctx, err);
    throw err;
  }
}

export default logger;
