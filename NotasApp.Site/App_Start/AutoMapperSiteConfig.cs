using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using NotasApp.Domain.Entities;
using NotasApp.Site.Models;

namespace NotasApp.Site.App_Start
{
    public class AutoMapperSiteConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new TodoItemProfile());
            });
        }
    }

    public class TodoItemProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ToDoItem, TodoItemModel>().ReverseMap();
        }
    }
}