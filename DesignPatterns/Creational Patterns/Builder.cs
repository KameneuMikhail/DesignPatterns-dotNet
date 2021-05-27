using System;

namespace DesignPatterns.Creational
{
    /// <summary>
    /*
     Паттерн Строитель предлагает вынести конструирование объекта за пределы его собственного класса, поручив это дело отдельным объектам, называемым строителями.

    Строитель позволяет создавать сложные объекты пошагово. Промежуточный результат всегда остаётся защищён.

    Паттерн предлагает разбить процесс конструирования объекта на отдельные шаги (например, построитьСтены, вставитьДвери и другие). Чтобы создать объект, вам нужно поочерёдно вызывать методы строителя. Причём не нужно запускать все шаги, а только те, что нужны для производства объекта определённой конфигурации.

    Зачастую один и тот же шаг строительства может отличаться для разных вариаций производимых объектов. Например, деревянный дом потребует строительства стен из дерева, а каменный — из камня.

    В этом случае вы можете создать несколько классов строителей, выполняющих одни и те же шаги по-разному. Используя этих строителей в одном и том же строительном процессе, вы сможете получать на выходе различные объекты.

    Разные строители выполнят одну и ту же задачу по-разному.

    Например, один строитель делает стены из дерева и стекла, другой из камня и железа, третий из золота и бриллиантов. Вызвав одни и те же шаги строительства, в первом случае вы получите обычный жилой дом, во втором — маленькую крепость, а в третьем — роскошное жилище. Замечу, что код, который вызывает шаги строительства, должен работать со строителями через общий интерфейс, чтобы их можно было свободно взаимозаменять.
     */
    /// </summary>
    public class Builder
    {
        #region Building

        public class Building: ICloneable
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Wall { get; set; }
            public string Floor { get; set; }
            public string Window { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        #endregion

        #region Builder
        
        public class BuildingBuilder
        {
            private Building building;
            public BuildingBuilder()
            {
                building = new Building();
            }

            public BuildingBuilder SetId(int id)
            {
                building.Id = id;
                return this;
            }

            public BuildingBuilder SetName(string name)
            {
                building.Name = name;
                return this;
            }

            public BuildingBuilder SetWall(string wall)
            {
                building.Wall = wall;
                return this;
            }

            public BuildingBuilder SetFloor(string floor)
            {
                building.Floor = floor;
                return this;
            }

            public BuildingBuilder SetWindow(string window)
            {
                building.Window = window;
                return this;
            }

            public Building Build()
            {
                var result = (Building)building.Clone();
                building = new Building();
                return result;
            }
        }

        #endregion

        #region BuilderManager

        public class BuilderManager
        {
            public Building CreateCheapBuilding()
            {
                var builder = new BuildingBuilder();
                return builder.SetId(1).SetName("Willage").SetWall("Wooden").SetFloor("Wooden").SetWindow("Wooden").Build();
            }
        }

        #endregion
    }
}
