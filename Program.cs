namespace semaphore_mutex;

class Program
{
    // static Queue<int> buffer = new Queue<int>();
    // static SemaphoreSlim semaforo = new SemaphoreSlim(0);
    // static object lockObj = new object();

    // static async Task Produtor(){
    //     var rand = new Random();

    //     for(int i =0; i < 5; i++){
    //         int item = rand.Next(1,100);

    //         lock(lockObj){
    //             buffer.Enqueue(item);
    //             Console.WriteLine($"{item}");
    //         }
    //         semaforo.Release();
    //         await Task.Delay(rand.Next(300,1000));
    //     }
    // }

    // static async Task Consumidor(){
    //     for(int i=0; i < 5; i++){
    //         await semaforo.WaitAsync();
    //         int item;

    //         lock(lockObj){
    //             item = buffer.Dequeue();
    //         }

    //         Console.WriteLine($"{item}");
    //         await Task.Delay(500);

    //     }
    // }
    static Mutex mutex = new Mutex();

    static async Task Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");

        // var produtor = Produtor();
        // var consumidor = Consumidor();

        // await Task.WhenAll(produtor, consumidor);
        // Console.WriteLine("Fim");

        for(int i =0; i <= 3; i++){
            Thread t = new Thread(AcessarRecurso);
            t.Name = $"Thread {i}";
            t.Start();
        }
    }

    static void AcessarRecurso(){
        mutex.WaitOne();
        Random rand = new Random();
        int n = rand.Next(100,2000);
        Thread.Sleep(n);
        Console.WriteLine($" {Thread.CurrentThread.Name} liberou");
        mutex.ReleaseMutex();;
    }
}
