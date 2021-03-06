﻿using System;
using Ninject;
using System.Reflection;
using SampleSPAAzureAD.API.Services;

namespace SampleSPAAzureAD.API
{
    public static class NinjectConfig
    {
        public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>(() =>
        {
            StandardKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            RegisterServices(kernel);

            return kernel;
        });

        private static void RegisterServices(KernelBase kernel)
        {
            // TODO - put in registrations here...

            kernel.Bind<IFakeService>().To<FakeService>();
        }
    }
}