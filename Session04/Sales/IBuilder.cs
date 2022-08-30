namespace Sales
{
    public interface IBuilder<T> where T:class
    {
        T Build();
    }
}