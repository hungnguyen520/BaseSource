﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BaseSource.Api.Startup))]

namespace BaseSource.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}