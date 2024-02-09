using ScoreBoard.App.Common;
using ScoreBoard.Domain.Entity;

namespace ScoreBoard.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService()
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
            }
            return result;
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "Start a new game", "Main"));
            AddItem(new MenuAction(2, "Update score", "Main"));
            AddItem(new MenuAction(3, "Finish game currently in progress", "Main"));
            AddItem(new MenuAction(4, "Get a summary of games in progress", "Main"));
            AddItem(new MenuAction(5, "Exit", "Main"));

        }
    }
}
