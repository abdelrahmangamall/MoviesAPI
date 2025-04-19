﻿using AutoMapper;

namespace MoviesAPI.Helper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie,MovieDetailsDto>();
            CreateMap<CreateMovieDto, Movie>().ForMember(src => src.Poster, opt => opt.Ignore());
        }
    }
}
