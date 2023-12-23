﻿using AutoMapper;
using cinemaBLL.Profiles;

namespace cinemaApi.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfiles(new List<Profile>
            {
                new AuthorProfile(),
                new MovieProfile()
            }));

            services.AddScoped<IMapper>(x => new Mapper(config));
        }
    }
}
