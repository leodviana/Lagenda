using System;
using LagendaApp.Interfaces;
using LagendaApp.Models;
using LagendaApp.Services;
using LagendaApp.ViewModels;
using LagendaApp.Views;
using Newtonsoft.Json;
using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Essentials;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace LagendaApp
{
    public partial class App: PrismApplication

    {
        public static Usuario usuariologado { get; set; }
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            Application.Current.UserAppTheme = OSAppTheme.Light;
            string usuario_logado = Preferences.Get("dentistaserializado", "");
            App.usuariologado = JsonConvert.DeserializeObject<Usuario>(usuario_logado);


            if (App.usuariologado == null)
            {

                await this.NavigationService.NavigateAsync("LoginPage");
            }
            else

            {
                try
                {

                
                  if (usuariologado.ImagePath==null)
                  {
                      usuariologado.ImagePath = "profile";
                  }
               
                    var mainPage = $"{nameof(NavigationPage)}/{nameof(MainPage)}";
                    await this.NavigationService.NavigateAsync(mainPage);
    
                }
                catch(Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("",ex.ToString(),"");
                }
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
            containerRegistry.RegisterSingleton<IApiService, ApiService>();

           
        }
    }
}
