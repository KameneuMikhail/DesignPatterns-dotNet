namespace DesignPatterns.Structural
{
    /// <summary>
    /*
     Вы можете создать адаптер. Это объект-переводчик, который трансформирует интерфейс или данные одного объекта в такой вид, чтобы он стал понятен другому объекту.

    При этом адаптер оборачивает один из объектов, так что другой объект даже не знает о наличии первого.
    Например, вы можете обернуть объект, работающий в метрах, адаптером, который бы конвертировал данные в футы.

    Адаптеры могут не только переводить данные из одного формата в другой, но и помогать объектам с разными интерфейсами работать сообща. Это работает так:

    Адаптер имеет интерфейс, который совместим с одним из объектов.
    Поэтому этот объект может свободно вызывать методы адаптера.
    Адаптер получает эти вызовы и перенаправляет их второму объекту, но уже в том формате и последовательности, которые понятны второму объекту.
    Иногда возможно создать даже двухсторонний адаптер, который работал бы в обе стороны.
     */
    /// </summary>
    public class Adapter
    {
        #region Converter

        public interface IConvert
        {
            string Convert(int text);
            string Save(int id);
        }

        public class XMLConverter : IConvert
        {
            public string Convert(int text) => $"XML converter - { text }";

            public string Save(int id) => $"Save - { id }";
        }

        #endregion

        #region Adapter
        public interface IAdapter
        {
            string Convert(string text);
            string Save(string id);
        }

        public class XMLAdapter : IAdapter
        {
            private IConvert converter;

            public XMLAdapter(IConvert converter)
            {
                this.converter = converter;
            }

            public string Convert(string text)
            {
                int txt;
                int.TryParse(text, out txt);
                return this.converter.Convert(txt);
            }

            public string Save(string id)
            {
                int txt;
                int.TryParse(id, out txt);
                return this.converter.Save(txt);
            }
        }

        #endregion
    }
}
