namespace UserManagement.Domain.Exceptions;

public class AdminCannotBeDisabledException : Exception
{
    public AdminCannotBeDisabledException()
        : base("An active admin user cannot be disabled.")
    {
    }
}
