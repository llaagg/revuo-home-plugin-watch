using System;
using System.Threading;
using System.Threading.Tasks;
using Revuo.Home.Abstractions;

namespace Watch
{
    public class Console : ILogic
    {
        private int _counter = 0;
        private string WindowId = null;
        private static Timer timer;

        public async Task<IResult> Do(IContext context)
        {
            System.Console.WriteLine( DateTime.Now.ToString());
            return new Result();
        }
    }
}
