using System;
using System.IO.Pipes;

var server = new NamedPipeServerStream("test", PipeDirection.InOut, NamedPipeServerStream.MaxAllowedServerInstances,
                    PipeTransmissionMode.Byte, PipeOptions.Asynchronous, inBufferSize: 0, outBufferSize: 0);

await server.WaitForConnectionAsync();

var bytes = new byte[1024];
int count;

while ((count = await server.ReadAsync(bytes)) > 0)
{
    Console.WriteLine($"Received {count} bytes.");
}