using Neckkeys.Abstract.StringServices;

namespace Neckkeys.Utilities.StringServices
{
    public class LogMessages : ILogMessages
    {
        private string owner;

        public LogMessages(string owner)
        {
            this.owner = owner;
        }

        string ILogMessages.NeedToBeAssignedMessage(string assignee)
        {
            return owner + ": " + assignee + " needs to be assigned.";
        }

        string ILogMessages.NeedToHaveAComponentOfTypeInTheScene(string componentType)
        {
            return owner + ": " + " needs to have a component of type: " + componentType + " In the same Scene";
        }

        string ILogMessages.NeedToHaveComponentMessage(string component)
        {
            return owner + ": " + " needs to have the component: " + component + " In the same Game Object";
        }
        string ILogMessages.NeedComponentInChildrenMessage(string component)
        {
            return owner + ": " + " needs to have the component: " + component + " In the a child Game Object";
        }
    }
}