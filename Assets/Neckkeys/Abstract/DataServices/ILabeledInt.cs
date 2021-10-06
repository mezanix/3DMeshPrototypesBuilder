namespace Neckkeys.Abstract.DataServices
{
    public interface ILabeledInt
    {
        void Increment(int by);
        void SetValue(int v);
        int GetValue();
        string GetLabel();
    }
}