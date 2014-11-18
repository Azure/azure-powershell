 # ############################################################################
 #
 # Copyright (c) Microsoft Corporation. 
 #
 # This source code is subject to terms and conditions of the Apache License, Version 2.0. A 
 # copy of the license can be found in the License.html file at the root of this distribution. If 
 # you cannot locate the Apache License, Version 2.0, please send an email to 
 # vspython@microsoft.com. By using this source code in any fashion, you are agreeing to be bound 
 # by the terms of the Apache License, Version 2.0.
 #
 # You must not remove this notice, or any other, from this software.
 #
 # ###########################################################################

import sys
import struct
import cStringIO
import os
import traceback
import ctypes
from os import path
from xml.dom import minidom
import re
import datetime
import thread

__version__ = '2.0.0'

# http://www.fastcgi.com/devkit/doc/fcgi-spec.html#S3

FCGI_VERSION_1 = 1
FCGI_HEADER_LEN = 8
 
FCGI_BEGIN_REQUEST       = 1
FCGI_ABORT_REQUEST       = 2
FCGI_END_REQUEST         = 3
FCGI_PARAMS              = 4
FCGI_STDIN               = 5
FCGI_STDOUT              = 6
FCGI_STDERR              = 7
FCGI_DATA                = 8
FCGI_GET_VALUES          = 9
FCGI_GET_VALUES_RESULT  = 10
FCGI_UNKNOWN_TYPE       = 11
FCGI_MAXTYPE = FCGI_UNKNOWN_TYPE

FCGI_NULL_REQUEST_ID    = 0

FCGI_KEEP_CONN = 1

FCGI_RESPONDER  = 1
FCGI_AUTHORIZER = 2
FCGI_FILTER     = 3

FCGI_REQUEST_COMPLETE = 0
FCGI_CANT_MPX_CONN    = 1
FCGI_OVERLOADED       = 2
FCGI_UNKNOWN_ROLE     = 3

FCGI_MAX_CONNS  = "FCGI_MAX_CONNS"
FCGI_MAX_REQS   = "FCGI_MAX_REQS"
FCGI_MPXS_CONNS = "FCGI_MPXS_CONNS"

class FastCgiRecord(object):
    """Represents a FastCgiRecord.  Encapulates the type, role, flags.  Holds
onto the params which we will receive and update later."""
    def __init__(self, type, req_id, role, flags):
        self.type = type
        self.req_id = req_id
        self.role = role
        self.flags = flags
        self.params = {}
        
    def __repr__(self):
        return '<FastCgiRecord(%d, %d, %d, %d)>' % (self.type, 
                                                    self.req_id, 
                                                    self.role, 
                                                    self.flags)

#typedef struct {
#   unsigned char version;
#   unsigned char type;
#   unsigned char requestIdB1;
#   unsigned char requestIdB0;
#   unsigned char contentLengthB1;
#   unsigned char contentLengthB0;
#   unsigned char paddingLength;
#   unsigned char reserved;
#   unsigned char contentData[contentLength];
#   unsigned char paddingData[paddingLength];
#} FCGI_Record;

class _ExitException(Exception):
    pass

def read_fastcgi_record(input):
    """reads the main fast cgi record"""
    data = input.read(8)     # read record
    if not data:
        # no more data, our other process must have died...
        raise _ExitException()

    content_size = ord(data[4]) << 8 | ord(data[5])

    content = input.read(content_size)  # read content    
    input.read(ord(data[6]))     # read padding

    if ord(data[0]) != FCGI_VERSION_1:
        raise Exception('Unknown fastcgi version ' + str(data[0]))

    req_id = (ord(data[2]) << 8) | ord(data[3])
    
    reqtype = ord(data[1])
    processor = REQUEST_PROCESSORS.get(reqtype)
    if processor is None:
        # unknown type requested, send response
        send_response(req_id, FCGI_UNKNOWN_TYPE, data[1] + '\0' * 7)
        return None

    return processor(req_id, content)


def read_fastcgi_begin_request(req_id, content):
    """reads the begin request body and updates our
_REQUESTS table to include the new request"""
    #    typedef struct {
    #        unsigned char roleB1;
    #        unsigned char roleB0;
    #        unsigned char flags;
    #        unsigned char reserved[5];
    #    } FCGI_BeginRequestBody;

    # TODO: Ignore request if it exists    
    res = FastCgiRecord(
        FCGI_BEGIN_REQUEST,
        req_id,
        (ord(content[0]) << 8) | ord(content[1]),   # role
        ord(content[2]),  # flags
    )
    _REQUESTS[req_id] = res    


def read_fastcgi_keyvalue_pairs(content, offset):
    """Reads a FastCGI key/value pair stream"""

    name_len = ord(content[offset])

    if (name_len & 0x80) != 0:
        name_full_len = chr(name_len & ~0x80) + content[offset + 1:offset+4]
        name_len = int_struct.unpack(name_full_len)[0]
        offset += 4
    else:
        offset += 1
    
    value_len = ord(content[offset])

    if (value_len & 0x80) != 0:
        value_full_len = chr(value_len & ~0x80) + content[offset+1:offset+4]
        value_len = int_struct.unpack(value_full_len)[0]
        offset += 4
    else:
        offset += 1

    name = content[offset:offset+name_len]
    offset += name_len
    
    value = content[offset:offset+value_len]
    offset += value_len

    return offset, name, value


def write_name_len(io, name):
    """Writes the length of a single name for a key or value in
a key/value stream"""
    if len(name) <= 0x7f:
        io.write(chr(len(name)))
    else:
        io.write(int_struct.pack(len(name)))


def write_fastcgi_keyvalue_pairs(pairs):
    """creates a FastCGI key/value stream and returns it as a string"""
    res = cStringIO.StringIO()
    for key, value in pairs.iteritems():
        write_name_len(res, key)
        write_name_len(res, value)
        
        res.write(key)
        res.write(value)

    return res.getvalue()


def read_fastcgi_params(req_id, content):
    if not content:
        return None

    offset = 0
    res = _REQUESTS[req_id].params
    while offset < len(content):
        offset, name, value = read_fastcgi_keyvalue_pairs(content, offset)
        res[name] = value


def read_fastcgi_input(req_id, content):
    """reads FastCGI std-in and stores it in wsgi.input passed in the
wsgi environment array"""
    res = _REQUESTS[req_id].params
    if 'wsgi.input' not in res:
        res['wsgi.input'] = content
    else:
        res['wsgi.input'] += content

    if not content:
        # we've hit the end of the input stream, time to process input...
        return _REQUESTS[req_id]


def read_fastcgi_data(req_id, content):
    """reads FastCGI data stream and publishes it as wsgi.data"""
    res = _REQUESTS[req_id].params
    if 'wsgi.data' not in res:
        res['wsgi.data'] = content
    else:
        res['wsgi.data'] += content


def read_fastcgi_abort_request(req_id, content):
    """reads the wsgi abort request, which we ignore, we'll send the
finish execution request anyway..."""
    pass


def read_fastcgi_get_values(req_id, content):
    """reads the fastcgi request to get parameter values, and immediately 
responds"""
    offset = 0
    request = {}
    while offset < len(content):
        offset, name, value = read_fastcgi_keyvalue_pairs(content, offset)
        request[name] = value

    response = {}
    if FCGI_MAX_CONNS in request:
        response[FCGI_MAX_CONNS] = '1'

    if FCGI_MAX_REQS in request:
        response[FCGI_MAX_REQS] = '1'

    if FCGI_MPXS_CONNS in request:
        response[FCGI_MPXS_CONNS] = '0'

    send_response(req_id, FCGI_GET_VALUES_RESULT, 
                  write_fastcgi_keyvalue_pairs(response))


# Formatting of 4-byte ints in network order
int_struct = struct.Struct('!i')

# Our request processors for different FastCGI protocol requests.  Only
# the requests which we receive are defined here.
REQUEST_PROCESSORS = {
    FCGI_BEGIN_REQUEST : read_fastcgi_begin_request,
    FCGI_ABORT_REQUEST : read_fastcgi_abort_request,
    FCGI_PARAMS : read_fastcgi_params,
    FCGI_STDIN : read_fastcgi_input,
    FCGI_DATA : read_fastcgi_data,
    FCGI_GET_VALUES : read_fastcgi_get_values
}

def log(txt):
    """Logs fatal errors to a log file if WSGI_LOG env var is defined"""
    log_file = os.environ.get('WSGI_LOG')
    if log_file:
        f = file(log_file, 'a+')
        try:
            f.write(str(datetime.datetime.now()))
            f.write(': ')
            f.write(txt)
        finally:
          f.close()


def send_response(id, resp_type, content, streaming = True):
    """sends a response w/ the given id, type, and content to the server.
If the content is streaming then an empty record is sent at the end to 
terminate the stream"""
    offset = 0
    while 1:
        if id < 256:
            id_0 = 0
            id_1 = id
        else:
            id_0 = id >> 8
            id_1 = id & 0xff
    
        # content len, padding len, content
        len_remaining = len(content) - offset
        if len_remaining > 65535:
            len_0 = 0xff
            len_1 = 0xff
            content_str = content[offset:offset+65535]
            offset += 65535
        else:
            len_0 = len_remaining >> 8
            len_1 = len_remaining & 0xff
            content_str = content[offset:]
            offset += len_remaining

        data = '%c%c%c%c%c%c%c%c%s' % (
                FCGI_VERSION_1,     # version
                resp_type,          # type
                id_0,               # requestIdB1
                id_1,               # requestIdB0
                len_0,              # contentLengthB1
                len_1,              # contentLengthB0
                0,                  # paddingLength
                0,                  # reserved
                content_str)

        os.write(stdout, data)
        if len_remaining == 0 or not streaming:
            break
    sys.stdin.flush()

def get_environment(dir):
    web_config = path.join(dir, 'Web.config')

    d = {}

    if os.path.exists(web_config):
        try:
            wc = file(web_config) 
            try:
                doc = minidom.parse(wc)
                config = doc.getElementsByTagName('configuration')
                for configSection in config:
                    appSettings = configSection.getElementsByTagName('appSettings')
                    for appSettingsSection in appSettings:
                        values = appSettingsSection.getElementsByTagName('add')
                        for curAdd in values:
                            key = curAdd.getAttribute('key')
                            value = curAdd.getAttribute('value')
                            if key and value is not None:
                                d[key] = value
            finally:
              wc.close()
        except:
            # unable to read file
            log(traceback.format_exc())
            pass
    return d

ReadDirectoryChangesW = ctypes.WinDLL('kernel32').ReadDirectoryChangesW
ReadDirectoryChangesW.restype = ctypes.c_bool
ReadDirectoryChangesW.argtypes  = [ctypes.c_void_p,     # HANDLE hDirectory
                                   ctypes.c_void_p,     # LPVOID lpBuffer
                                   ctypes.c_uint32,     # DWORD nBufferLength
                                   ctypes.c_bool,       # BOOL bWatchSubtree
                                   ctypes.c_uint32,     # DWORD dwNotifyFilter
                                   ctypes.POINTER(ctypes.c_uint32),  # LPDWORD lpBytesReturned
                                   ctypes.c_void_p,     # LPOVERLAPPED lpOverlapped
                                   ctypes.c_void_p      # LPOVERLAPPED_COMPLETION_ROUTINE lpCompletionRoutine
                                  ]

CreateFile = ctypes.WinDLL('kernel32').CreateFileW
CreateFile.restype = ctypes.c_void_p
CreateFile.argtypes  = [ctypes.c_wchar_p,     # lpFilename
                                   ctypes.c_uint32,      # dwDesiredAccess
                                   ctypes.c_uint32,      # dwShareMode
                                   ctypes.c_voidp,       # LPSECURITY_ATTRIBUTES,
                                   ctypes.c_uint32,      # dwCreationDisposition,
                                   ctypes.c_uint32,      # dwFlagsAndAttributes,
                                   ctypes.c_void_p       # hTemplateFile
                                  ]

ExitProcess = ctypes.WinDLL('kernel32').ExitProcess
ExitProcess.restype = ctypes.c_void_p
ExitProcess.argtypes  = [ctypes.c_uint32]

FILE_LIST_DIRECTORY = 1
FILE_SHARE_READ = 0x00000001
FILE_SHARE_WRITE = 0x00000002
FILE_SHARE_DELETE = 0x00000004
OPEN_EXISTING = 3
FILE_FLAG_BACKUP_SEMANTICS = 0x02000000
MAX_PATH = 260
FILE_NOTIFY_CHANGE_LAST_WRITE  = 0x10

class FILE_NOTIFY_INFORMATION(ctypes.Structure):
    _fields_ = [('NextEntryOffset', ctypes.c_uint32),
                ('Action', ctypes.c_uint32),
                ('FileNameLength', ctypes.c_uint32),
                ('Filename', ctypes.c_wchar)]

def start_file_watcher(path, restartRegex):
    if restartRegex is None:
        restartRegex = ".*((\\.py)|(\\.config))$"
    elif not restartRegex:
        # restart regex set to empty string, no restart behavior
        return
    
    log('wfastcgi.py will restart when files in ' + path + ' are changed: ' + restartRegex + '\n')
    restart = re.compile(restartRegex)
    def watcher(path, restart):
        the_dir = CreateFile(path, 
                                FILE_LIST_DIRECTORY, 
                                FILE_SHARE_READ | FILE_SHARE_WRITE | FILE_SHARE_DELETE,
                                None,
                                OPEN_EXISTING,
                                FILE_FLAG_BACKUP_SEMANTICS,
                                None
                            )
        
        buffer = ctypes.create_string_buffer(32 * 1024)
        bytes_ret = ctypes.c_uint32()

        while ReadDirectoryChangesW(the_dir, 
                                buffer, 
                                ctypes.sizeof(buffer), 
                                True, 
                                FILE_NOTIFY_CHANGE_LAST_WRITE,
                                ctypes.byref(bytes_ret),
                                None,
                                None):
            cur_pointer = ctypes.addressof(buffer)
            while True:
                fni = ctypes.cast(cur_pointer, ctypes.POINTER(FILE_NOTIFY_INFORMATION))
                filename = ctypes.wstring_at(cur_pointer + 12)
                if restart.match(filename):
                    log('wfastcgi.py exiting because ' + filename + ' has changed, matching ' + restartRegex + '\n')
                    # we call ExitProcess directly to quickly shutdown the whole process
                    # because sys.exit(0) won't have an effect on the main thread.
                    ExitProcess(0)
                if fni.contents.NextEntryOffset == 0:
                    break
                cur_pointer = cur_pointer + fni.contents.NextEntryOffset

    thread.start_new_thread(watcher, (path, restart))

def get_wsgi_handler(handler_name):
        if not handler_name:
            raise Exception('WSGI_HANDLER env var must be set')
    
        module, _, callable = handler_name.rpartition('.')
        if not module:
            raise Exception('WSGI_HANDLER must be set to module_name.wsgi_handler, got %s' % handler_name)
    
        if isinstance(callable, unicode):
            callable = callable.encode('ascii')

        if callable.endswith('()'):
            callable = callable.rstrip('()')
            handler = getattr(__import__(module, fromlist=[callable]), callable)()
        else:
            handler = getattr(__import__(module, fromlist=[callable]), callable)
    
        if handler is None:
            raise Exception('WSGI_HANDLER "' + handler_name + '" was set to None')

        return handler

def read_wsgi_handler(physical_path):
    env = get_environment(physical_path)
    os.environ.update(env)
    for env_name in env:
        if env_name.lower() == 'pythonpath':
            # expand any environment variables in the path...
            path = env[env_name]
            for var in os.environ:
                pat = re.compile(re.escape('%' + var + '%'), re.IGNORECASE)
                path = pat.sub(lambda _:os.environ[var], path)
            

            for path_location in path.split(';'):
                sys.path.append(path_location)
            break
    
    handler_ex = None
    try:
        handler_name = os.getenv('WSGI_HANDLER')
        handler = get_wsgi_handler(handler_name)
    except:
        handler = None
        handler_ex = sys.exc_info()
    
    
    return env, handler, handler_ex

if __name__ == '__main__': 
    stdout = sys.stdin.fileno()
    try:
        import msvcrt
        msvcrt.setmode(sys.stdin.fileno(), os.O_BINARY)
    except ImportError:
        pass

    _REQUESTS = {}
    
    initialized = False
    fatal_error = False
    log('wfastcgi.py ' + __version__ + ' started\n')
    while fatal_error is False:
        try:
            record = read_fastcgi_record(sys.stdin)
            if record:
                record.params['wsgi.input'] = cStringIO.StringIO(record.params['wsgi.input'])
                record.params['wsgi.version'] = (1,0)
                record.params['wsgi.url_scheme'] = 'https' if record.params.has_key('HTTPS') and record.params['HTTPS'].lower() == 'on' else 'http'
                record.params['wsgi.multiprocess'] = True
                record.params['wsgi.multithread'] = False
                record.params['wsgi.run_once'] = False

                physical_path = record.params.get('DOCUMENT_ROOT', path.dirname(__file__))
                
                errors = sys.stderr = sys.__stderr__ = record.params['wsgi.errors'] = cStringIO.StringIO()
                output = sys.stdout = sys.__stdout__ = cStringIO.StringIO()
                
                if not initialized:
                    os.chdir(physical_path)

                    env, handler, handler_ex = read_wsgi_handler(physical_path)

                    start_file_watcher(physical_path, env.get('WSGI_RESTART_FILE_REGEX'))

                    log('wfastcgi.py ' + __version__ + ' initialized\n')
                    initialized = True
                    
                def start_response(status, headers, exc_info = None):
                    status = 'Status: ' + status + '\r\n'
                    headers = ''.join('%s: %s\r\n' % (name, value) for name, value in headers)
                    send_response(record.req_id, FCGI_STDOUT, status + headers + '\r\n')
                
                os.environ.update(env)
                if 'HTTP_X_ORIGINAL_URL' in record.params:
                    # We've been re-written for shared FastCGI hosting, send the original URL as the PATH_INFO.
                    record.params['PATH_INFO'] = record.params['HTTP_X_ORIGINAL_URL']
                
                # PATH_INFO is not supposed to include the query parameters, so remove them
                record.params['PATH_INFO'] = record.params['PATH_INFO'].partition('?')[0]

                # SCRIPT_NAME + PATH_INFO is supposed to be the full path http://www.python.org/dev/peps/pep-0333/
                # but by default (http://msdn.microsoft.com/en-us/library/ms525840(v=vs.90).aspx) IIS is sending us 
                # the full URL in PATH_INFO, so we need to clear the script name here
                if 'AllowPathInfoForScriptMappings' not in os.environ:
                    record.params['SCRIPT_NAME'] = ''

                if handler is None:
                    fatal_error = True
                    error_msg = ('Error while importing WSGI_HANDLER:\n\n' +
                                    ''.join(traceback.format_exception(*handler_ex)) + '\n\n' +
                                    'StdOut: ' + output.getvalue() + '\n\n'
                                    'StdErr: ' + errors.getvalue() + '\n\n')
                    log(error_msg)
                    send_response(record.req_id, FCGI_STDERR, error_msg)
                else:                    
                    try: 
                        for part in handler(record.params, start_response):
                            if part:
                                send_response(record.req_id, FCGI_STDOUT, part)
                    except:
                        log('Exception from handler: ' + traceback.format_exc())
                        send_response(record.req_id, FCGI_STDERR, errors.getvalue() + '\n\n' + traceback.format_exc())

                send_response(record.req_id, FCGI_END_REQUEST, '\x00\x00\x00\x00\x00\x00\x00\x00', streaming=False)
                del _REQUESTS[record.req_id]
        except _ExitException:
            break
        except:
            log('Unhandled exception in wfastcgi.py: ' + traceback.format_exc())

