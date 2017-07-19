using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class CalculatorEngine
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;
            try
            {
                var result = numbers.Split(',')
                    .Where(x=> !string.IsNullOrWhiteSpace(x))
                    .Sum(x => UInt16.Parse(x));
               // var result = int.Parse(numbers);
                return result;
            }
            catch
            {
                throw new ArgumentException();
            }
            
        }
    }
}
