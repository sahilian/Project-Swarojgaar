using AutoMapper;
using Swarojgaar.Models;
using Swarojgaar.Repository.Interface;
using Swarojgaar.Services.Interface;
using Swarojgaar.ViewModel.JobVM;

namespace Swarojgaar.Services.Implementation;

public class JobService : IJobService
{
    private readonly IGenericRepository<Job> _jobRepository;
    private readonly IMapper _mapper;
    public JobService(IGenericRepository<Job> jobRepository, IMapper mapper)
    {
        _jobRepository = jobRepository;
        _mapper = mapper;
    }
    public List<GetAllJobsVM> GetAllJobs()
    {
        try
        {
            List<Job> jobs = _jobRepository.GetAll();
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

    public void CreateJob(CreateJobVM createViewModel)
    {

        try
        {
            Job job = _mapper.Map<Job>(createViewModel);
            _jobRepository.Create(job);
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

    public void EditJob(EditJobVM editViewModel)
    {
        Job job = _mapper.Map<Job>(editViewModel);
        try
        {
            _jobRepository.Edit(job);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public void DeleteJob(int id)
    {
        try
        {
            _jobRepository.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}