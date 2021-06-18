namespace Koch.com.GeekStore.Console
{
    using System;

    using Koch.com.GeekStore.Console.App_Start;

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ContainerConfig.Init();
                var runner = ContainerConfig.GetInstance<IRunner>();

                runner.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: " + e.Message);
                Console.ReadKey();
            }
        }
    }
}
