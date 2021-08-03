using Autofac;
using DemoLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class ContainerConfig
    {

        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();  // conatiner  - place to store the definitons of all the classes we want to instantiate

            builder.RegisterType<Application>().As<IApplication>();  //doesnt matter whcih foler the class is in

            builder.RegisterType<BusinessLogic>().As<IBusinessLogic>(); // registers a class called buisnessLogic, wherever it sees IBuisnessLogic, return BuisnessLogic

            



            //Bigin Section

            // this section amps a class to it's interface ex. DataAccses to IDataAccses
            // this is boiler plate almost and could be used in any program, just swap out "DemoLibrary" and "Utilities" for what you need in your project and youre good to go

            builder.RegisterAssemblyTypes(Assembly.Load(nameof(DemoLibrary)))
                .Where(t => t.Namespace.Contains("Utilities"))
                .As(t => t.GetInterfaces().FirstOrDefault(i => i.Name == "I" + t.Name));

            // End Section

            return builder.Build();  // builds the conatiner...
        }

    }
}
