namespace DevJobs.API.Models
{
    public record AddJobVacancyInputMoldel(
        string Title,
        string Description,
        string Company,
        bool IsRemote,
        string SalaryRange)
    {

        
    }
}