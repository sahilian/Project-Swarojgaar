﻿using AutoMapper;
using Swarojgaar.Models;
using Swarojgaar.ViewModel.JobApplicationVM;
using Swarojgaar.ViewModel.JobVM;

namespace Swarojgaar.MapperProfile
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Job, GetAllJobsVM>();
            CreateMap<Job, EditJobVM>().ReverseMap();
            CreateMap<Job, DetailsJobVM>();
            CreateMap<Job, CreateJobVM>().ReverseMap();
            CreateMap<Job, DeleteJobVM>().ReverseMap();
            CreateMap<JobApplication, CreateJobApplicationVM>().ReverseMap();
            CreateMap<JobApplication, GetAllJobApplicationsVM>().ReverseMap();

        }
    }
}
