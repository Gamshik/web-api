﻿using AutoMapper;
using Entites;
using Entites.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBL.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorDto>().ReverseMap();
            CreateMap<Author, AuthorForCreateDto>().ReverseMap();
            CreateMap<Author, AuthorForUpdateDto>().ReverseMap();
        }
    }
}
