

namespace Koch.com.GeekStore.Console.Logic
{
    using System;
    public class GeekStoreService : IGeekStoreService
    {
    
        public GeekStoreService()
        {
        }

        public int ToSafeInt(string input)
        {
            int output = 0;
            try
            {
                output = int.Parse(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Could not be parsed due to execption: {0} ", ex.Message);
            }
            return output;
        }

        public Tuple<int, bool> ToSafeIntArbitrary(string input, int retunValue)
        {
            int number = 0;

            bool isParsable = Int32.TryParse(input, out number);

            //return new Tuple<int, bool>(min, max);
            if (isParsable)
              return new Tuple<int, bool>(number, isParsable);
            else
                return new Tuple<int, bool>(retunValue, isParsable);
        }
    }
}
