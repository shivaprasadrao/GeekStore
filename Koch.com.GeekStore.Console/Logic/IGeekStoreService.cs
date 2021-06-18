using System;

namespace Koch.com.GeekStore.Console.Logic
{
    public interface IGeekStoreService
    {
        int ToSafeInt(string input);

        Tuple<int, bool> ToSafeIntArbitrary(string input, int retunValue =0);
    }
}
