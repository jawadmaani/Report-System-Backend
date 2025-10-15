namespace Report_System_Backend.exception;

public class EmptyDatabaseFromReports:Exception
{
    public EmptyDatabaseFromReports(string message) : base(message)
    {
    }
    
}