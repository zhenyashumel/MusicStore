using MusicStore.BLL.Interfaces;
using MusicStore.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Web.Util
{
    public class BllServices : NinjectModule
    {
        public override void Load()
        {
            Bind<IMusicService>().To<MusicService>();
        }
    }
}