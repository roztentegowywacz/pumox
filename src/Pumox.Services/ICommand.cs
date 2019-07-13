namespace Pumox.Services
{
    // Marker interface
    public interface ICommand
    {
    }

    public interface ICommand<TResult> : ICommand
    {
    }
}