using Report_System_Backend.model;
using Report_System_Backend.Repository;

namespace Report_System_Backend.service;



public class ReportService
{
    private readonly IRepository<Report> repository;

    public ReportService(IRepository<Report> repository)
    {
        this.repository = repository;

    }



}