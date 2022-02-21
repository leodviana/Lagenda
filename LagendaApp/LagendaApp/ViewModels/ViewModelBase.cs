﻿using Prism;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace LagendaApp.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible, IActiveAware
    {
        protected INavigationService NavigationService { get; private set; }
        protected IPageDialogService PageDialogService { get; private set; }
        private string _title;

        public event EventHandler IsActiveChanged;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value, RaiseIsActiveChanged);
        }

        protected virtual void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);
        }

        protected ViewModelBase(INavigationService navigationService, IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;

            this.Title = $"Default";
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public static bool InternetConnectivity()
        {

            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                return true;
            }

            return false;
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }
        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }
        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }
        /*public async Task exibeErro(string _mensagem)
        {
            var navigationParams = new NavigationParameters();
            navigationParams.Add("mensagem", _mensagem);
            // await NavigationService.NavigateAsync("PopupMensagemPage", navigationParams, useModalNavigation: true);
            await NavigationService.NavigateAsync("PopupMensagemPage", navigationParams, true, true);
        }*/
        public virtual void Destroy()
        {

        }
    }
}
