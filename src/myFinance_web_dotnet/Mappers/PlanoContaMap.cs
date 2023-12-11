using System.Data.Entity;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore.Internal;
using myFinance_web_dotnet.Domain;
using myFinance_web_dotnet.Models;
using QuickFix.Config;

namespace myFinance_web_dotnet.Mappers
{
    public class PlanoContaMap : Profile
    {
        public PlanoContaMap()
        {
            CreateMap<PlanoContaModel, PlanoConta>().ReverseMap();
        }
    }
}
