using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Plugin.Battery;
using Plugin.Battery.Abstractions;
using Prism.Mvvm;
using Prism.Unity;
using TextSpeaker.Model;
using TextSpeaker.ViewModels;
using TextSpeaker.Views;
using Xamarin.Forms;

namespace TextSpeaker
{
    public class App : PrismApplication
    {
        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterType<ICounter, Counter>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IBattery, Battery>(new TransientLifetimeManager());

            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<TextSpeechPage>();
            Container.RegisterTypeForNavigation<CounterPage>();
            Container.RegisterTypeForNavigation<BatteryPage>();
        }

        ViewTypeToViewModelTypeResolver _resolver;
        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            _resolver = new ViewTypeToViewModelTypeResolver(typeof(MainPageViewModel).GetTypeInfo().Assembly); // とりあえず適当なVMからAssembly取得して設定しておく
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(_resolver.Resolve);
        }
    }

    public class ViewTypeToViewModelTypeResolver
    {
        private readonly Assembly _assembly;

        public ViewTypeToViewModelTypeResolver(Assembly assembly)
        {
            _assembly = assembly;
        }

        public Type Resolve(Type viewType)
        {
            if (viewType == null) throw new ArgumentNullException(nameof(viewType));

            // ReSharper disable once PossibleNullReferenceException
            var vmTypeName = $"{viewType.Namespace.Replace("Views", "ViewModels")}.{viewType.Name}ViewModel";
            var vmType = _assembly.GetType(vmTypeName);
            return vmType;
        }
    }
}
