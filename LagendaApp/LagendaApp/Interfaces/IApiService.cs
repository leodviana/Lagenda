using System;
using System.Threading.Tasks;
using LagendaApp.Models;
using LagendaApp.ViewModels;

namespace LagendaApp.Interfaces
{
    public interface IApiService
    {
        Task<Response> getUsuario(Usuario usuario);

       
    }
}
