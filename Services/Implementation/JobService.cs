using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobVM;

namespace Swarojgaar.Services.Implementation;

public class JobService : IJobService
{
    private readonly IGenericRepository<Job> _jobRepository;
    private readonly IMapper _mapper;
    private readonly UserManager<IdentityUser> _userManager;

    public JobService(IGenericRepository<Job> jobRepository, IMapper mapper, UserManager<IdentityUser> userManager)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
        _userManager = userManager;
    }
    public List<GetAllJobsVM> GetAllJobs()
    {
        try
        {
            IOrderedEnumerable<Job> jobs = _jobRepository.GetAll().OrderByDescending(job => job.JobId);
            List<GetAllJobsVM> getAllJobs = _mapper.Map<List<GetAllJobsVM>>(jobs);
            return getAllJobs;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public DetailsJobVM GetJobDetails(int id)
    {
        try
        {
            Job job = _jobRepository.GetDetails(id);
            DetailsJobVM details = _mapper.Map<DetailsJobVM>(job);
            return details;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool CreateJob(CreateJobVM createViewModel, string userId)
    {

        try
        {
            Job job = _mapper.Map<Job>(createViewModel);
            return _jobRepository.Create(job);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public EditJobVM EditJob(int id)
    {
        try
        {
            Job job = _jobRepository.GetDetails(id);
            EditJobVM editViewModel = _mapper.Map<EditJobVM>(job);
            return editViewModel;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public bool EditJob(EditJobVM editViewModel)
    {
        try
        {
            Job job = _mapper.Map<Job>(editViewModel);
            return _jobRepository.Edit(job);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public bool DeleteJob(int id)
    {
        try
        {
            return _jobRepository.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}