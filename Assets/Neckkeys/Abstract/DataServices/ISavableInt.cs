namespace Neckkeys.Abstract.DataServices
{
    public interface ISavableInt
    {
        void Save(string key);
        void Load(string key);
    }
}