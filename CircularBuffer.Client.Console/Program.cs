using CircularBuffer.Core.Services;
using Buffer = CircularBuffer.Core.Domain.Buffer;
using System.Threading;
using CircularBuffer.Core.Domain;
using System.ComponentModel;

namespace CircularBuffer.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new Buffer(3);
            var bufferService = new BufferService(buffer);

            WriteInThread(bufferService);
            buffer.ToConsole();
            //System.Console.ReadLine();

            Thread.Sleep(2000);

            WriteInBackgroundWorker(bufferService);
            buffer.ToConsole();
            //   System.Console.ReadLine();

            Thread.Sleep(2000);

            bufferService.Write(new Page { Content = "2" });
            buffer.ToConsole();
            System.Console.ReadLine();

        }

        private static void WriteInThread(BufferService bufferService)
        {
            Thread oThread = new Thread(new ThreadStart(() => bufferService.Write(new Page { Content = "t" })));
            oThread.Start();

          //  Thread.Sleep(1000);
            System.Console.WriteLine("Sleep end");

            oThread.Abort();
        }

        private static void WriteInBackgroundWorker(BufferService bufferService)
        {
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.WorkerReportsProgress = true;

            backgroundWorker.DoWork += new DoWorkEventHandler(doWork);

            backgroundWorker.RunWorkerAsync(bufferService);

       //     Thread.Sleep(1000);
            System.Console.WriteLine("Sleep end");

            backgroundWorker.CancelAsync();
        }

        private static void doWork(object sender, DoWorkEventArgs e)
        {
            var bufferService = (BufferService)e.Argument;

            bufferService.Write(new Page { Content = "b" });
        }
    }
}
