using System;
using System.IO.Pipes;
using System.Threading.Tasks;

var pipe = new NamedPipeClientStream(".", "test", PipeDirection.InOut, PipeOptions.Asynchronous);

await pipe.ConnectAsync();

var bytes = new byte[3000];

while (true)
{
    pipe.Write(bytes);
    await Task.Delay(TimeSpan.FromSeconds(20));
}