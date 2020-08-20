using DietDiary.App.Common;
using DietDiary.Domain.Common;
using DietDiary.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DietDiary.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        //  private List<MenuAction> menuActions;

        /* public MenuActionService()
         {
             menuActions = new List<MenuAction>();
         }*/

        /*   public void AddNewMenuAction(int id, string name, string menuName)
           {
               MenuAction menuAction = new MenuAction { Id = id, MenuName = menuName, Name = name };
               menuActions.Add(menuAction);
           }*/
        public MenuActionService()
        {
            Initialize();
        }
        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> resultAction = new List<MenuAction>();
            foreach (var action in Items)
                if (action.MenuName == menuName)
                    resultAction.Add(action);
            return resultAction;
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "Dane uzytkownika", "Main"));
            AddItem(new MenuAction(2, "Lista produktów", "Main"));
            AddItem(new MenuAction(3, "Dodaj posiłek", "Main"));
            AddItem(new MenuAction(4, "Usuń posiłek", "Main"));
            AddItem(new MenuAction(5, "Wyświetl aktualne posiłki", "Main"));
            AddItem(new MenuAction(6, "Pomiary ciała", "Main"));
            AddItem(new MenuAction(0, "Zamknij aplikację", "Main"));

            AddItem(new MenuAction(0, "Powrót do głównego menu", "UserDataMenu"));
            AddItem(new MenuAction(1, "Zaktualizuj dane", "UserDataMenu"));

            AddItem(new MenuAction(0, "Powrót do głównego menu", "ProductsMenu"));
            AddItem(new MenuAction(2, "Wyświetl aktualną listę produktów", "ProductsMenu"));
            AddItem(new MenuAction(3, "Dodaj produkt", "ProductsMenu"));
            AddItem(new MenuAction(4, "Usuń produkt", "ProductsMenu"));

            AddItem(new MenuAction(0, "Powrót do menu listy porduktów", "ProductsCategory"));
            AddItem(new MenuAction(1, "Mięso", "ProductsMenu"));
            AddItem(new MenuAction(2, "Warzywa", "ProductsMenu"));
            AddItem(new MenuAction(3, "Owoce", "ProductsMenu"));
            AddItem(new MenuAction(4, "Produkty zbożowe", "ProductsMenu"));
            AddItem(new MenuAction(5, "Nabiał", "ProductsMenu"));

            AddItem(new MenuAction(0, "Powrót do głównego menu", "AddNewMealMenu"));
            for (int i = 1; i < 6; i++)
            {
                AddItem(new MenuAction(i, ((NameOfMeal)i).ToString(), "AddNewMealMenu"));
            }

            AddItem(new MenuAction(0, "Powrót do głównego menu", "BodyMeasurementsMenu"));
            AddItem(new MenuAction(1, "Zaktualizuj pomiary", "BodyMeasurementsMenu"));
        }
    }
}
