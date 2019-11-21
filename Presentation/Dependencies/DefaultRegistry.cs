using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Presentation.Dependencies
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            Scan(
               scan => {
                   scan.TheCallingAssembly();

                   scan.WithDefaultConventions();

                   scan.AssembliesFromApplicationBaseDirectory(
                       filter => filter.FullName.StartsWith("CleanArchitecture"));
               });
        }
    }
}
