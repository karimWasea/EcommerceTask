﻿using AutoMapper;

namespace AutoMapperServess
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Data__Access__layer.School, SchoolDto>().ReverseMap();
            //CreateMap<Data__Access__layer.School, CreateSchoolDto>().ReverseMap();

            //CreateMap<Data__Access__layer.Room, RoomlDto>().ForMember(dest => dest.DepartmentName,
            //    src => src.MapFrom(src => src.Department.DepartmentName)).ReverseMap();

            //CreateMap<Room, CreateRoomlDto>().ReverseMap();


            //CreateMap<Department, DepartmentDto>()
            //         .ForMember(dest => dest.SchoolName,
            //         src => src.MapFrom(src => src.School.SchoolName)).ReverseMap();
            //CreateMap<Department, CreateDepartmentDto>().ReverseMap();





            //    .ForMember(dest => dest.Id, src => src.MapFrom(src => src.BookId))
            //    .ForMember(dest => dest.IsFree, src => src.MapFrom(src => src.Price == 0))

        }
    }
}