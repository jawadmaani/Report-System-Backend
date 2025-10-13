using Microsoft.EntityFrameworkCore;
using Report_System_Backend.Data;
using Report_System_Backend.model;

namespace Report_System_Backend.Repository;

public class ReportRepository:IRepository<Report>
{
    private readonly AppDbContext _context;

    public ReportRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Report>> GetAllAsync()
    {
        return await _context.Reports.ToListAsync();
    }

    public async Task<Report?> GetByIdAsync(int id)
    {
        return await  _context.Reports.FindAsync(id);
    }

    public async Task CreateAsync(Report report)
    {
         await _context.Reports.AddAsync(report);
    }

    public Task UpdateAsync(Report report)
    {
         _context.Reports.Update(report);
         return Task.CompletedTask;

    }

    public async  Task DeleteAsync(int id)
    {
        var report = await  _context.Reports.FindAsync(id);
        if (report != null)
            _context.Reports.Remove(report);
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}