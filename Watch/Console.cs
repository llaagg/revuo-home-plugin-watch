using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Revuo.Home.Abstractions;

namespace Watch
{
    public class Console : ILogic, IInfo
    {
        public async Task<IResult> Do(IContext context)
        {
            System.Console.WriteLine( DateTime.Now.ToString());
            return new Result();
        }

        public List<KeyValuePair<string, string>> GetInfo()
        {
            return new List<KeyValuePair<string, string>>(){
                new KeyValuePair<string, string>(MetaData.StartAble,"true")
            };
        }
    }
}
