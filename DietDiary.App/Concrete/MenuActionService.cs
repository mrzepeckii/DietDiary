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
            AddItem(new MenuAction(2, "Produkty", "Main"));
            AddItem(new MenuAction(3, "Posiłki", "Main"));
            AddItem(new MenuAction(4, "Pomiary ciała", "Main"));
            AddItem(new MenuAction(0, "Zamknij aplikację", "Main"));

            AddItem(new MenuAction(0, "Powrót do głównego menu", "UserDataMenu"));
            AddItem(new MenuAction(1, "Zaktualizuj dane", "UserDataMenu"));

            AddItem(new MenuAction(0, "Powrót do głównego menu", "ProductsMenu"));
            AddItem(new MenuAction(1, "Wyświetl wszystkie produkty", "ProductsMenu"));
            AddItem(new MenuAction(2, "Wyświetl aktualną listę produktów z danej kategorii", "ProductsMenu"));
            AddItem(new MenuAction(3, "Pokaż szczegółowe dane o danym produkcie", "ProductsMenu"));
            AddItem(new MenuAction(4, "Dodaj produkt", "ProductsMenu"));
            AddItem(new MenuAction(5, "Zaktualizuj dane o produkcie", "ProductsMenu"));
            AddItem(new MenuAction(6, "Usuń produkt", "ProductsMenu"));

            AddItem(new MenuAction(0, "Powrót do głównego menu", "MealsMenu"));
            AddItem(new MenuAction(1, "Wyświetl wszystkie posiłki z danego dnia", "MealsMenu"));
            AddItem(new MenuAction(2, "Pokaż kaloryczność wybranego dnia", "MealsMenu"));
            AddItem(new MenuAction(3, "Wyświetl wszystkie posiłki z danej kateogrii", "MealsMenu"));
            AddItem(new MenuAction(4, "Pokaż szczegółowe dane o danym posiłku", "MealsMenu"));
            AddItem(new MenuAction(5, "Dodaj posiłek", "MealsMenu"));
            AddItem(new MenuAction(6, "Zaktualizuj posiłek", "MealsMenu"));
            AddItem(new MenuAction(7, "Usuń posiłek", "MealsMenu"));
            AddItem(new MenuAction(8, "Usuń posiłek z bazy", "MealsMenu"));

            //AddItem(new MenuAction(0, "Powrót do menu listy produktów", "ProductsCategory"));
            for (int i = 1; i < 6; i++)
            {
                AddItem(new MenuAction(i, ((CategoryOfProducts)i).ToString(), "ProductsCategory"));
            }

            AddItem(new MenuAction(0, "Powrót do głównego menu", "MealsCategory"));
            for (int i = 1; i < 6; i++)
            {
                AddItem(new MenuAction(i, ((NameOfMeal)i).ToString(), "MealsCategory"));
            }

            AddItem(new MenuAction(0, "Powrót do głównego menu", "BodyMeasurementsMenu"));
            AddItem(new MenuAction(1, "Zaktualizuj pomiary", "BodyMeasurementsMenu"));
        }
    }
}
