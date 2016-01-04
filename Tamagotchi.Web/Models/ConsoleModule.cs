﻿using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagotchi.Web.Models
{
    class WebModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITamagotchiRepository>().To<WCFTamagotchiRepository>();
        }
    }
}
