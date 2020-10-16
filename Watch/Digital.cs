using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Revuo.Home.Abstractions;

namespace Watch
{
    public class Digital : ILogic, IInfo
    {
        private int _counter = 0;
        private string WindowId = null;
        private static Timer timer;

        public async Task<IResult> Do(IContext context)
        {
            if (timer == null)
            {
                timer = new Timer(state =>
                {
                    _counter++;

                    var result =
                        context.Run("Revuo.Home.Components.UI.Box",
                            new Request(
                                WindowId, 
                                "Timer",
                                DateTime.Now.ToString()
                                ))
                            .Result;

                    if (result.Success )
                    {
                        WindowId = result.Data<string>(0);
                    }
                }, _counter, 0, 1000);
            }

            return new Result();
        }

        public List<KeyValuePair<string, string>> GetInfo()
        {
            return new List<KeyValuePair<string, string>>(){
                new KeyValuePair<string, string>(MetaData.StartAble, "true")
            };
        }
    }
}
