using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Web;
using System.Web.Mvc;

namespace Sure.Quartz.NET.Web.App_Start
{
    public class MEFDependencySolver : IDependencyResolver
    {
        private readonly ComposablePartCatalog composablePartCatalog;
        private const string HttpContextKey = "MefContainerKey";

        public MEFDependencySolver(ComposablePartCatalog catalog)
        {
            composablePartCatalog = catalog;
        }

        public CompositionContainer Container
        {
            get
            {
                if (!HttpContext.Current.Items.Contains(HttpContextKey))
                {
                    HttpContext.Current.Items.Add(HttpContextKey, new CompositionContainer(composablePartCatalog));
                }
                CompositionContainer container = (CompositionContainer)HttpContext.Current.Items[HttpContextKey];
                HttpContext.Current.Application["Container"] = container;
                return container;
            }
        }


        #region IDependencyResolver Members

        public object GetService(Type serviceType)
        {
            try
            {
                string contractName = AttributedModelServices.GetContractName(serviceType);
                return Container.GetExportedValueOrDefault<object>(contractName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return Container.GetExportedValues<object>(serviceType.FullName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}