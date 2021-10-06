namespace Neckkeys.Abstract.StringServices
{
    public interface ILogMessages
    {
        string NeedToBeAssignedMessage(string assignee);
        string NeedToHaveComponentMessage(string component);

        string NeedComponentInChildrenMessage(string component);

        string NeedToHaveAComponentOfTypeInTheScene(string componentType);
    }
}