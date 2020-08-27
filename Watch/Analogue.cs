﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Revuo.Home.Abstractions;

namespace Watch
{
    public class Analogue : ILogic
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
                        context.Run("Revuo.Home.Components.UserControl",
                            new Request(
                                WindowId, 
                                typeof(AnalogueWatch).AssemblyQualifiedName,
                                DateTime.Now.ToString()
                                ))
                            .Result;

                    if (result.Success &&
                        WindowId == null)
                    {
                        WindowId = result.Data<string>(0);
                    }
                }, _counter, 0, 1000);
            }

            return new Result();
        }
    }
}