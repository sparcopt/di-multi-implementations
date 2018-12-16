namespace Application.Services
{
    public interface IService<T> { }

    public class GenericServiceA : IService<int> { }

    public class GenericServiceB : IService<string> { }

    public class GenericServiceC : IService<bool> { }
}
