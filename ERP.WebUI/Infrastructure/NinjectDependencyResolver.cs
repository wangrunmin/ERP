﻿using ERP.Domain.Abstract;
using ERP.Domain.Concrete;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.WebUI.Infrastructure
{
  public class NinjectDependencyResolver : IDependencyResolver
  {
    private IKernel kernel;
    public NinjectDependencyResolver(IKernel kernelParam)
    {
      kernel = kernelParam;
      AddBindings();
    }

    public object GetService(Type serviceType)
    {
      return kernel.TryGet(serviceType);
    }

    public IEnumerable<object> GetServices(Type serviceType)
    {
      return kernel.GetAll(serviceType);
    }

    private void AddBindings()
    {
      kernel.Bind<IERPRepository>().To<EFProductRepository>();
    }
  }
}